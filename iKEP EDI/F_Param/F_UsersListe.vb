Public Class F_UsersListe
    Public Sub ListeUser()
        Dim leRs As OleDb.OleDbDataReader

        Me.gUser.Rows.Clear()
        leRs = SqlLit("SELECT Userid, UserLogin FROM app.Users", conSqlEDI)
        While leRs.Read
            Me.gUser.Rows.Add(leRs("UserId"), leRs("UserLogin"))
        End While
        leRs.Close()
    End Sub

    Private Sub F_ParamTiers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ListeUser()
    End Sub

    Private Sub TiersPLus_Click(sender As System.Object, e As System.EventArgs) Handles TiersPLus.Click
        F_Users.UserId = 0
        If F_Users.ShowDialog = Windows.Forms.DialogResult.OK Then ListeUser()
        F_Users.Dispose()
    End Sub

    Private Sub gTiers_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gUser.CellDoubleClick

        F_Users.UserId = gUser.Rows(e.RowIndex).Cells("UserId").Value
        If F_Users.ShowDialog = Windows.Forms.DialogResult.OK Then ListeUser()
        F_Users.Dispose()
    End Sub

    Private Sub TiersMoins_Click(sender As Object, e As EventArgs) Handles TiersMoins.Click
        If MsgBox("Supprimer l'utilisateur  " & Me.gUser.SelectedRows(0).Cells("UserLogin").Value & " ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            SqlDo("DELETE FROM app.Users WHERE UserLogin = '" & Me.gUser.SelectedRows(0).Cells("UserLogin").Value & "'", conSqlEDI)
            'SqlDo("DELETE FROM app.TiersUser WHERE UserLogin = '" & Me.gUser.SelectedRows(0).Cells("UserLogin").Value & "'", conSqlEDI)
            ListeUser()
        End If
    End Sub

    Private Sub gUser_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gUser.CellContentClick

    End Sub
End Class