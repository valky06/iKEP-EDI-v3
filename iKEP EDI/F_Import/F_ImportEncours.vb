Public Class F_ImportEncours
    Public leSiteId As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Sub AfficheNbLigne()
        Dim leRs As OleDb.OleDbDataReader
        Dim sSql As String
        Dim nbLignes As Integer = 0
        Dim lesParam As New List(Of SSISParam)

        Me.gEncours.Visible = False
        Me.gEncours.Rows.Clear()

        lesParam.Add(New SSISParam("UserLogin", leUser.Login, "PACKAGE"))
        lesParam.Add(New SSISParam("SiteId", leSiteId, "PACKAGE"))
        SSISexecute(leUser.RepSSIS, "DM_IN_CDV_IntegreEnCours.dtsx", lesParam, "Actualisation commandes ...")

        sSql = "select CliCode, NoCommande, NbLigne from CommandeVente_Integration where Siteid =" & leSiteId
        leRs = SqlLit(sSql, conSqlEDI)
        While leRs.Read
            Me.gEncours.Rows.Add(leRs("CliCode"), leRs("NoCommande"), leRs("NbLigne"))
            nbLignes += leRs("NbLigne")
        End While
        leRs.Close()

        Me.tNbLigJour.Text = nbLignes

        Me.gEncours.Visible = True
    End Sub

    Private Sub F_Encours_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call AfficheNbLigne()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call AfficheNbLigne()
    End Sub
End Class