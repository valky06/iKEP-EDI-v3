Public Class F_Afferme

    Sub ListeSite()
        ComboRempli("SELECT DISTINCT S.SiteId, S.SiteNom FROM app.UserSite US INNER JOIN app.Site S on S.SiteId = US.SiteId WHERE US.UserId = 0" & leUser.Id, lSiteAfferm, conSqlEDI)

        If lSiteAfferm.Items.Count > 0 Then
            lSiteAfferm.SelectedIndex = 0
            'lSite_SelectedIndexChanged(Nothing, Nothing)
        End If

    End Sub

    Private Sub ChargPrev(sender As Object, e As EventArgs) Handles btnChargPrev.Click
        Dim lesParam As New List(Of SSISParam)

        bAfficher.Enabled = True
        btnPtoF.Enabled = True

        lesParam.Add(New SSISParam("UserLogin", leUser.Login, "PACKAGE"))
        lesParam.Add(New SSISParam("SiteId", lSiteAfferm.SelectedItem.value, "PACKAGE"))
        SSISexecute(leUser.RepSSIS, "DM_IN_CDV_PREV.dtsx", lesParam, "Commandes prévisionnelles ...")

        AfficheAfferme()
    End Sub

    Sub AfficheAfferme()
        Dim sSql As String
        Dim lers As OleDb.OleDbDataReader
        Dim selC As Boolean

        Try
            gAfferme.Visible = False
            gAfferme.Rows.Clear()

            sSql = "SELECT P.SiteCode, P.NumCommande, P.LigneCommande, P.CliCode, P.CliNom, P.DateLivr, P.ArtCode, P.Qte, P.NumCdeEDI, P.NumLigneEDI, P.TmoJour, P.Statut, A.AffId " _
                        & " FROM CommandeVente_Prev AS P " _
                        & " LEFT JOIN CommandeVente_Affermie AS A ON P.SiteCode = A.SiteCode And P.NumCommande = A.NumCde And P.LigneCommande = A.NumLigne AND P.DateLivr = A.DateBesoin " _
                        & " WHERE P.UserLogin = '" & leUser.Login & "' "
            If tClient.Text <> "" Then sSql &= " AND ( P.CliCode LIKE '%" & tClient.Text & "%' OR P.CliNom LIKE '%" & Me.tClient.Text & "%')"
            If tArticle.Text <> "" Then sSql &= " AND P.ArtCode LIKE '%" & tArticle.Text & "%'"
            If bRetard.Checked Then sSql &= " AND P.DateLivr <= GETDATE()" & Nz("+" & tHorizon.Text, "") & If(bTmo.Checked, "+P.TmoJour", "")
            sSql &= " ORDER BY P.CliCode, P.NumCommande, P.LigneCommande, P.DateLivr"

            lers = SqlLit(sSql, conSqlEDI)
            While lers.Read
                If Nz(lers("AffId"), 0) = 0 Then
                    selC = False
                Else
                    selC = True
                End If

                gAfferme.Rows.Add(False, Nz(lers("SiteCode"), ""), Nz(lers("CliCode"), "") & " - " & Nz(lers("CliNom"), ""), Nz(lers("NumCommande"), ""), Nz(lers("LigneCommande"), ""), Nz(lers("ArtCode"), ""), Nz(lers("NumCdeEDI"), ""), Nz(lers("NumLigneEDI"), ""), Nz(lers("Statut"), ""), Val(Nz(lers("TmoJour"), 0)), Nz(lers("DateLivr"), ""), Val(Nz(lers("Qte"), 0)), lers("CliCode"))
                gAfferme.Rows(gAfferme.Rows.Count - 1).Cells(0).ReadOnly = selC

                'Mise en forme des cellules de la  nouvelle ligne
                With gAfferme.Rows(gAfferme.RowCount - 1)
                    If .Cells("DateCde").Value <> "" Then
                        Dim dShift As Date = Now.AddDays(If(Nz(tHorizon.Text, "0") <> "0", Int32.Parse(tHorizon.Text), 0)).AddDays(If(bTmo.Checked, Int32.Parse(.Cells("TmoJ").Value), 0))
                        If dShift > CDate(.Cells("DateCde").Value) Then
                            .Cells("DateCde").Style.BackColor = coulRecule
                        End If
                    End If

                    If .Cells("Sel").ReadOnly Then
                        .Cells("Sel").Style.BackColor = Color.LightGray
                    End If

                    If .Cells("Statut").Value = "F" Then
                        .Cells("Statut").Style.BackColor = coulAvance
                        .Cells("Sel").ReadOnly = True
                        .Cells("Sel").Style.BackColor = Color.LightGray
                    End If

                End With
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
        ListeSite()
        tHorizon.Text = My.Settings.HorizonAfferme
        btnPtoF.Enabled = False
        bAfficher.Enabled = False


    End Sub

    Private Sub GContrat_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gAfferme.CellContentDoubleClick
        GImportContrat_CellContentClick(sender, e)
    End Sub

    Private Sub GImportContrat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) 'Handles gAfferme.CellContentClick
        Dim i As Integer
        Dim Laligne As Integer = e.RowIndex
        Dim b As Boolean
        If e.ColumnIndex < 1 AndAlso Nz(gAfferme.Rows(Laligne).Cells("NumCde").Value, "") <> "" AndAlso Nz(gAfferme.Rows(Laligne).Cells("NumLigne").Value, 0) <> 0 Then
            i = Laligne
            b = gAfferme(0, i).Value

            ' Remonte à la 1ere ligne de la commande
            While i > 0 AndAlso Nz(gAfferme.Rows(i - 1).Cells("NumCde").Value, "") = gAfferme.Rows(Laligne).Cells("NumCde").Value AndAlso Nz(gAfferme.Rows(i - 1).Cells("NumLigne").Value, 0) = gAfferme.Rows(Laligne).Cells("NumLigne").Value : i -= 1 : End While

            'coche les lignes de la commande
            While gAfferme.Rows(i).Cells("NumCde").Value = gAfferme.Rows(Laligne).Cells("NumCde").Value And gAfferme.Rows(i).Cells("NumLigne").Value = gAfferme.Rows(Laligne).Cells("NumLigne").Value And Not gAfferme.Rows(i).Cells("Sel").ReadOnly And i < gAfferme.RowCount - 1
                gAfferme.Rows(i).Cells("Sel").Value = Not b
                i += 1
            End While
        End If
    End Sub

    ' Selection TOUT
    Private Sub CSel_CheckedChanged(sender As Object, e As EventArgs) 'Handles cSel.CheckedChanged
        For i = 0 To Me.gAfferme.RowCount - 1
            If gAfferme.Rows(i).Cells("NumCde").Value <> "" And gAfferme.Rows(i).Cells("NumLigne").Value <> 0 And Not gAfferme.Rows(i).Cells("Sel").ReadOnly Then
                gAfferme.Rows(i).Cells("Sel").Value = cSel.Checked
            End If
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
        If MsgBox("Affermir les commandes ?", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Sub

        Dim sSql As String
        Dim lers, lers2 As OleDb.OleDbDataReader

        Try
            AttenteDemarre("Génération lignes ...")
            For i = 0 To gAfferme.RowCount - 1
                With gAfferme.Rows(i)
                    If Nz(.Cells("Sel").Value, False) = True Then
                        InsertAffermie(.Cells("SiteCode").Value, .Cells("CodeClient").Value, .Cells("NumCde").Value, .Cells("NumLigne").Value, .Cells("Article").Value, .Cells("NumCdeEDI").Value, .Cells("NumLigneEDI").Value, Nz(.Cells("QteCde").Value, 0), .Cells("DateCde").Value, "P", "F", leUser.Login)
                    End If
                End With
            Next

            sSql = "SELECT P.SiteCode, P.CliCode, P.NumCommande, P.LigneCommande, P.DateLivr, P.ArtCode, P.Qte, P.NumCdeEDI, P.NumLigneEDI, A.UserLogin " _
                    & " FROM CommandeVente_Affermie AS A " _
                    & " INNER JOIN CommandeVente_Prev AS P ON A.CodeClient = P.CliCode AND A.NumCde = P.NumCommande AND A.NumLigne = P.LigneCommande AND A.DateBesoin <> P.DateLivr " _
                    & " WHERE A.UserLogin = '" & leUser.Login & "' "

            lers = SqlLit(sSql, conSqlEDI)
            While lers.Read
                sSql = "SELECT AffId " _
                    & " FROM CommandeVente_Affermie " _
                    & " WHERE SiteCode = '" & lers("SiteCode") & "' AND CodeClient = '" & lers("CliCode") & "' AND NumCde = '" & lers("NumCommande") & "' AND NumLigne = '" & lers("LigneCommande") & "' AND DateBesoin = '" & lers("DateLivr") & "'"

                lers2 = SqlLit(sSql, conSqlEDI)
                If Not lers2.HasRows Then
                    InsertAffermie(lers("SiteCode"), lers("CliCode"), lers("NumCommande"), lers("LigneCommande"), lers("ArtCode"), lers("NumCdeEDI"), lers("NumLigneEDI"), Nz(lers("Qte"), 0), lers("DateLivr"), "P", "P", leUser.Login)
                End If

            End While
            AttenteFin()

            Dim leFichier As String = "EDI_PF_" & Now.ToString("ddMMyy_HHmm") & ".txt"

            Dim lesParam As New List(Of SSISParam)
            lesParam.Add(New SSISParam("SiteId", lSiteAfferm.SelectedItem.Value, "PACKAGE"))
            lesParam.Add(New SSISParam("UserLogin", leUser.Login, "PACKAGE"))
            lesParam.Add(New SSISParam("LeFichier", "\\pmssqlc1\EDI\Export\" & leFichier, "PACKAGE"))
            SSISexecute(leUser.RepSSIS, "DM_IN_CDV_Affermie.dtsx", lesParam, "Affermissement commandes ...")

            FileCopy("\\pmssqlc1\EDI\Export\" & leFichier, My.Settings.CheminExportTOPS & leFichier)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        AfficheAfferme()
    End Sub

    Private Sub tArticle_KeyUp(sender As Object, e As KeyEventArgs) Handles tArticle.KeyUp
        If e.KeyCode = Keys.Enter Then AfficheAfferme()
    End Sub

    Private Sub ClosingAfferme(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SqlDo("DELETE FROM CommandeVente_Affermie WHERE UserLogin = '" & leUser.Login & "' ", conSqlEDI)
    End Sub

    Private Sub bRetard_CheckedChanged(sender As Object, e As EventArgs) Handles bRetard.CheckedChanged
        AfficheAfferme()
    End Sub

    Private Sub bTmo_CheckedChanged(sender As Object, e As EventArgs) Handles bTmo.CheckedChanged
        AfficheAfferme()
    End Sub

    Private Sub tHorizon_TextChanged(sender As Object, e As EventArgs) Handles tHorizon.TextChanged
        If tHorizon.Text = "" Then tHorizon.Text = "0"
    End Sub

    Private Sub lSiteAfferm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lSiteAfferm.SelectedIndexChanged
        ' 3 = MTB et 4 = TLS
        If lSiteAfferm.SelectedItem.Value = 3 Or lSiteAfferm.SelectedItem.Value = 4 Then
            ShowTMO()
        Else
            HideTMO()
        End If
    End Sub

    Private Sub HideTMO()
        bTmo.Visible = False
        lblHorizon.Visible = False
        tHorizon.Visible = False
        lblUniteHorizon.Visible = False
        tHorizon.Text = "0"
    End Sub

    Private Sub ShowTMO()
        bTmo.Visible = True
        lblHorizon.Visible = True
        tHorizon.Visible = True
        lblUniteHorizon.Visible = True
        tHorizon.Text = My.Settings.HorizonAfferme
    End Sub

    Private Sub InsertAffermie(SiteCode As String, CodeClient As String, NumCde As String, NumLigne As String, Article As String, NumCdeEDI As String, NumLigneEDI As String, QteCde As Integer, DateCde As Date, TypeCde As String, TypeBesoin As String, leUser As String)
        SqlDo("INSERT INTO CommandeVente_Affermie (SiteCode, CodeClient, NumCde, NumLigne, CodeArticle, NumCdeEDI, NumLigneEDI, QteBesoin, DateBesoin, TypeCde, TypeBesoin, UserLogin) VALUES (" _
                                        & "'" & SiteCode & "', '" & CodeClient & "', '" & NumCde & "', '" & NumLigne & "', '" & Article & "', " _
                                       & "'" & NumCdeEDI & "',  '" & NumLigneEDI & "', 0" & QteCde & ", '" & DateCde & "', '" & TypeCde & "', '" & TypeBesoin & "', '" & leUser & "')", conSqlEDI)
    End Sub
End Class