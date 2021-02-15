Public Class F_Afferme

    Sub AfficheAfferme()
        Dim sSql As String
        Dim lers As OleDb.OleDbDataReader
        Dim lesParam As New List(Of SSISParam)
        Dim selC As Boolean

        Try
            gAfferme.Visible = False
            gAfferme.Rows.Clear()

            lesParam.Add(New SSISParam("UserLogin", leUser.Login, "PACKAGE"))
            SSISexecute(leUser.RepSSIS, "DM_IN_CDV_PREV.dtsx", lesParam, "Commandes prévisionnelles ...")

            sSql = "SELECT P.SiteCode, P.NumCommande, P.LigneCommande, P.CliCode, P.CliNom, P.DateLivr, P.ArtCode, P.Qte, P.NumCdeEDI, P.NumLigneEDI, A.AffId FROM CommandeVente_Prev AS P " _
                        & " LEFT JOIN CommandeVente_Affermie AS A ON P.SiteCode = A.SiteCode And P.NumCommande = A.NumCde And P.LigneCommande = A.NumLigne  " _
                        & " WHERE P.UserLogin = '" & leUser.Login & "' "
            If tClient.Text <> "" Then sSql &= " AND ( P.CliCode LIKE '%" & tClient.Text & "%' OR P.CliNom LIKE '%" & Me.tClient.Text & "%')"
            If tArticle.Text <> "" Then sSql &= " AND P.ArtCode LIKE '%" & tArticle.Text & "%'"
            sSql &= " AND P.DateLivr <= '" & Now.AddMonths(tHorizon.Text).ToShortDateString & "' "
            sSql &= " ORDER BY P.CliCode, P.NumCommande, P.LigneCommande, P.DateLivr"

            lers = SqlLit(sSql, conSqlEDI)
            While lers.Read
                If Nz(lers("AffId"), 0) = 0 Then
                    selC = False
                Else
                    selC = True
                End If

                gAfferme.Rows.Add(selC, Nz(lers("SiteCode"), ""), Nz(lers("CliCode"), "") & " - " & Nz(lers("CliNom"), ""), Nz(lers("NumCommande"), ""), Nz(lers("LigneCommande"), ""), Nz(lers("ArtCode"), ""), Nz(lers("NumCdeEDI"), ""), Nz(lers("NumLigneEDI"), ""), Nz(lers("DateLivr"), ""), Val(Nz(lers("Qte"), 0)), lers("CliCode"))

            End While

            lers.Close()
            gAfferme.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub F_Afferme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        My.Settings.Reload()
        tHorizon.Text = My.Settings.HorizonAfferme
    End Sub

    Private Sub CSel_CheckedChanged(sender As Object, e As EventArgs) Handles cSel.CheckedChanged
        For i = 0 To Me.gAfferme.RowCount - 1
            If gAfferme.Rows(i).Cells("Client").Value <> "" Then gAfferme.Rows(i).Cells("sel").Value = Me.cSel.Checked
        Next
    End Sub

    Private Sub BAfficher_Click(sender As Object, e As EventArgs) Handles bAfficher.Click
        My.Settings.HorizonAfferme = Val(tHorizon.Text)
        My.Settings.Save()
        AfficheAfferme()
    End Sub

    Private Sub tClient_KeyUp(sender As Object, e As KeyEventArgs) Handles tClient.KeyUp
        If e.KeyCode = Keys.Enter Then AfficheAfferme()
    End Sub

    Private Sub tHorizon_KeyUp(sender As Object, e As KeyEventArgs) Handles tHorizon.KeyUp
        If e.KeyCode = Keys.Enter Then Call AfficheAfferme()
    End Sub

    Private Sub Affermir(sender As Object, e As EventArgs) Handles btnPtoF.Click

        Dim sSql As String = ""
        Dim lesParam As New List(Of SSISParam)

        If MsgBox("Affermir les commandes  ?", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Sub

        Try

            For i = 0 To gAfferme.RowCount - 1
                With gAfferme.Rows(i)
                    If Nz(.Cells("Sel").Value, False) = True Then

                        sSql = "INSERT INTO CommandeVente_Affermie (SiteCode, CodeClient, NumCde, NumLigne, CodeArticle, NumCdeEDI, NumLigneEDI, QteBesoin, DateBesoin, TypeBesoin, UserLogin) VALUES (" _
                                        & "'" & .Cells("SiteCode").Value & "', '" & .Cells("CodeClient").Value & "', '" & .Cells("NumCde").Value & "', '" & .Cells("NumLigne").Value & "', '" & .Cells("Article").Value & "', " _
                                       & "'" & .Cells("NumCdeEDI").Value & "',  '" & .Cells("NumLigneEDI").Value & "', 0" & Nz(.Cells("QteCde").Value, 0) & ", '" & .Cells("DateCde").Value & "', 'F','" & leUser.Login & "')"

                        SqlDo(sSql, conSqlEDI)
                    End If
                End With
            Next

            lesParam.Add(New SSISParam("UserLogin", leUser.Login, "PACKAGE"))
            SSISexecute(leUser.RepSSIS, "DM_IN_CDV_Affermie.dtsx", lesParam, "Affermissement commandes ...")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        AfficheAfferme()
    End Sub

    Private Sub tArticle_KeyUp(sender As Object, e As KeyEventArgs) Handles tArticle.KeyUp
        If e.KeyCode = Keys.Enter Then AfficheAfferme()
    End Sub

    Private Sub ClosingAfferme(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SqlDo("DELETE FROM CommandeVente_Prev WHERE UserLogin = '" & leUser.Login & "' ", conSqlEDI)
    End Sub
End Class