Public Class F_TiersListe

    Sub ListeTiers()
        Dim leRs As OleDb.OleDbDataReader

        Me.gTiers.Rows.Clear()
        leRs = SqlLit("SELECT TiersId, TiersNom FROM app.Tiers order by tiersnom", conSqlEDI)
        While leRs.Read
            Me.gTiers.Rows.Add(leRs("TiersId"), leRs("TiersNom"))
        End While
        leRs.Close()

    End Sub

    Private Sub F_ParamTiers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ListeTiers()
    End Sub


    Private Sub TiersPLus_Click(sender As System.Object, e As System.EventArgs) Handles TiersPLus.Click
        Dim cfgTiers As New F_Tiers With {
            .TiersId = 0
        }
        If cfgTiers.ShowDialog = Windows.Forms.DialogResult.OK Then ListeTiers()
        cfgTiers.Dispose()
    End Sub

    Private Sub gTiers_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gTiers.CellDoubleClick
        Dim cfgTiers As New F_Tiers With {
            .TiersId = gTiers.Rows(e.RowIndex).Cells("TiersId").Value
        }
        If cfgTiers.ShowDialog = Windows.Forms.DialogResult.OK Then ListeTiers()
        cfgTiers.Dispose()
    End Sub

    Private Sub TiersMoins_Click(sender As Object, e As EventArgs) Handles TiersMoins.Click
        If MsgBox("Supprimer le tiers " & Me.gTiers.SelectedRows(0).Cells("Nom").Value & " ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            SqlDo("DELETE FROM app.Tiers WHERE TiersId = 0" & Me.gTiers.SelectedRows(0).Cells("Tiersid").Value, conSqlEDI)
            SqlDo("DELETE FROM app.TiersSiteERP WHERE TiersId = 0" & Me.gTiers.SelectedRows(0).Cells("Tiersid").Value, conSqlEDI)
            'SqlDo("DELETE FROM app.TiersUser WHERE TiersId = 0" & Me.gTiers.SelectedRows(0).Cells("Tiersid").Value, conSqlEDI)
            ListeTiers()
        End If
    End Sub
End Class