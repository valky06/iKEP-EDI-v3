Public Class F_Users
    Public UserId As Integer = -1


    Sub ListeDroit()
        Me.cDroit.Items.Clear()
        Me.cDroit.Items.Add(New ListItem(0, "Admin"))
        Me.cDroit.Items.Add(New ListItem(1, "Utilisateur"))
    End Sub

    Private Sub F_Tiers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call FormVide(Me)
        Call ListeDroit()
        Me.cConfig.Items.Clear()
        ComboRempli("Select cfgid,cfgName from app.config", Me.cConfig, conSqlEDI)

        If UserId <> 0 Then
            FormRempli(Me, "SELECT UserId, UserLogin, Droit,cfgID FROM app.Users WHERE UserId = " & UserId, conSqlEDI)

            Dim lers As OleDb.OleDbDataReader
            Dim Ssql As String = "select S.SiteId,S.sitecode,U.UserId from app.Site S left join app.UserSite U on s.SiteId=u.SiteId and u.UserId = " & Me.UserId
            lers = SqlLit(Ssql, conSqlEDI)
            While lers.Read
                Me.gSite.Rows.Add(lers("SiteId").ToString, lers("SiteCode").ToString, IIf(Nz(lers("UserId"), 0) = 0, False, True), IIf(Nz(lers("UserId"), 0) = 0, 0, 1))
            End While
            lers.Close()

        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles bOK.Click
        UserId = FormEnreg(Me, "app.Users", conSqlEDI)
        'Enregistre les sites
        For i = 0 To Me.gSite.RowCount - 1
            If IIf(Me.gSite.Rows(i).Cells("Sel").Value, 1, 0) <> Me.gSite.Rows(i).Cells("SelOld").Value Then
                If Me.gSite.Rows(i).Cells("SelOld").Value = 0 Then
                    SqlDo("Insert into app.UserSite (UserId,Siteid) values ('" & Me.UserId & "','" & Me.gSite.Rows(i).Cells("SiteId").Value & "')", conSqlEDI)
                Else
                    SqlDo("delete from app.UserSite where UserId= " & Me.UserId & " and Siteid=" & Me.gSite.Rows(i).Cells("SiteId").Value, conSqlEDI)
                End If
            End If
        Next
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub bAnnul_Click(sender As System.Object, e As System.EventArgs) Handles bAnnul.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class