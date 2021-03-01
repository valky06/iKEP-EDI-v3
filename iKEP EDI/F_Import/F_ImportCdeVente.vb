Imports System.IO
Imports System.Reflection

Public Class F_ImportCdeVente

    Dim ancVal As String
    Dim lImportId As Integer = 0
    Dim nbAnocontrat As Integer = 0
    Dim nbAnoCde As Integer = 0

    Sub AfficheContext()
        If Me.lTiers.SelectedIndex >= 0 Then F_Main.sContext.Text = "Tiers:" & Me.lTiers.SelectedItem.value

        If Me.lSite.SelectedIndex >= 0 Then F_Main.sContext.Text &= " Site:" & Me.lSite.SelectedItem.value
    End Sub

    Sub listesite()
        ComboRempli("select S.SiteId,S.SiteNom from app.UserSite US inner join app.Site S on S.SiteId= US.SiteId where US.UserId=" & leUser.Id _
            & " And S.SiteId in (select distinct SiteId from app.TiersSiteERP where tiersid=" & Me.lTiers.SelectedItem.value & " )", lSite, conSqlEDI)

        If lSite.Items.Count > 0 Then
            lSite.SelectedIndex = 0
            lSite_SelectedIndexChanged(Nothing, Nothing)
        End If

    End Sub

    Sub ListeTiers()
        ComboRempli("SELECT T.TiersId, TiersNom FROM app.Tiers T inner Join app.tiersUser TU on T.TiersId=TU.TiersId where tu.UserId = " & leUser.Id _
            & " And T.TiersId in ( Select tiersid from app.TiersSiteERP inner Join app.UserSite on UserSite.SiteId = TiersSiteERP.SiteId where UserSite.UserId=" & leUser.Id & ")" _
            & " ORDER BY TiersNom ", lTiers, conSqlEDI)
    End Sub

    Sub afficheNbCdeEDI()
        Dim lers As OleDb.OleDbDataReader
        lers = SqlLit("Select count(distinct NumCdeEDI_Tiers) as NB from CommandeVente_Bilan where ImportId = " & lImportId, conSqlEDI)
        While lers.Read
            tabImport.Text = "Commande (" & Nz(lers("Nb"), 0) & ")"
        End While
        lers.Close()
    End Sub

    Sub AfficheBilan()
        Dim d1 As Date = Now

        AttenteDemarre("Affichage en-cours")
        tabAnomalies.Text = "Anomalies Commandes"
        tabImport.Text = "Commandes"

        'affiche le dernier import
        StatutBar("Lecture des commandes")
        ListeCommande()
        afficheNbCdeEDI()

        ListeAnomalies()
        StatutBar("")
        Me.Tableaux.Visible = True

        StatutBar("")

        'System.Threading.Thread.Sleep(1000)
        AttenteFin()

        If Modedebug Then MsgBox("Affichage :" & DateDiff(DateInterval.Second, d1, Now))

        Me.Tableaux.Visible = True
    End Sub

    Sub InitBilan()

        'Me.Tableaux.Visible = False
        Me.gImport.Visible = False
        Me.gImport.Rows.Clear()
        Me.gAnoCde.Visible = False
        Me.gAnoCde.Rows.Clear()
        Me.gAnoContrat.Visible = False
        Me.gAnoContrat.Rows.Clear()

        Call StatutBar("")

    End Sub

    Sub ListeAnomalieEDI(AvecFiltre As Boolean)
        Dim lers As OleDb.OleDbDataReader
        Dim sSql As String
        Dim filtreMsg As String = ""
        Dim nbligne As Integer = 0

        If Me.lSite.SelectedIndex < 0 Then Exit Sub

        Me.gAnoContrat.Visible = False
        Me.gAnoContrat.Rows.Clear()

        If AvecFiltre Then
            If Me.OptionA.Checked Then filtreMsg &= "or MsgLigne Like '%A%'"
            If Me.OptionI.Checked Then filtreMsg &= "or MsgLigne Like '%I%'"

            '   If Me.tCde_AE.Text <> "" Then filtreMsg &= "or NumCdeEDI_Tiers like '%" & Me.tCde_AE.Text & "%'"
            '   If Me.tArt_AE.Text <> "" Then filtreMsg &= "or Article like '%" & Me.tArt_AE.Text & "%'"
            If filtreMsg <> "" Then filtreMsg = "And (" & filtreMsg.Remove(0, 3) & ")"
        End If

        sSql = "SELECT   NumCdeEDI_Tiers,  Article,  ArtDesc_Tiers,  MsgLigne, qtebesoin FROM  CommandeVente_Anomalie" _
        & " WHERE NumCdeEDI_Tiers <> '' and ImportId=" & lImportId & " and siteid=" & Me.lSite.SelectedItem.value _
        & filtreMsg

        If Me.tArt_AE.Text <> "" Then sSql &= "And article like '%" & Me.tArt_AE.Text & "%'"
        If Me.tCde_AE.Text <> "" Then sSql &= "And NumCdeEDI_Tiers like '%" & Me.tCde_AE.Text & "%'"


        sSql &= " ORDER BY NumCdeEDI_Tiers,Article"

        lers = SqlLit(sSql, conSqlEDI)
        While lers.Read
            Me.gAnoContrat.Rows.Add(lers("NumCdeEDI_Tiers"), Nz(lers("Article"), ""), Nz(lers("ArtDesc_Tiers"), ""), lers("QTeBesoin"), Nz(lers("msgLigne"), ""))
            nbligne += 1
        End While
        lers.Close()

        If Not AvecFiltre Then nbAnocontrat = Me.gAnoContrat.RowCount
        Me.gAnoContrat.Visible = True
        Me.tabAnomalies.Text = "Anomalies Contrat/Cde (" & nbAnoCde + nbAnocontrat & ")"

    End Sub

    Sub ListeAnomalieCde(AvecFiltre As Boolean)
        Dim lers As OleDb.OleDbDataReader
        Dim sSql As String
        Dim filtreMsg As String = ""

        If Me.lSite.SelectedIndex < 0 Then Exit Sub

        Me.gAnoCde.Visible = False
        Me.gAnoCde.Rows.Clear()

        If AvecFiltre Then
            If Me.optionG.Checked Then filtreMsg &= " or MsgLigne like '%G%'"
            If Me.optionH.Checked Then filtreMsg &= " or MsgLigne like '%H%'"
            If Me.optionM.Checked Then filtreMsg &= " or MsgLigne like '%M%'"
            If Me.tCde_AC.Text <> "" Then filtreMsg &= "or NumCdeEDI_ERP like '%" & Me.tCde_AC.Text & "%'"
            If Me.tCde_AC.Text <> "" Then filtreMsg &= "or NumCde_ERP like '%" & Me.tCde_AC.Text & "%'"
            If Me.tArt_AC.Text <> "" Then filtreMsg &= "or ArtCode_ERP like '%" & Me.tArt_AC.Text & "%'"
            If filtreMsg <> "" Then filtreMsg = "AND (" & filtreMsg.Remove(0, 3) & ")"
        End If

        sSql = "SELECT   codeclient,  Article, NumCde_ERP, ArtCode_ERP, ArtDesc_ERP,  MsgLigne, NumCdeEDI_ERP" _
                & " FROM  CommandeVente_Anomalie " _
                & " WHERE NumCde_ERP <> '' and ImportId=" & lImportId & " and siteid=" & Me.lSite.SelectedItem.value & filtreMsg


        If Me.tArt_AC.Text <> "" Then sSql &= "And ArtCode_ERP like '%" & Me.tArt_AC.Text & "%'"
        If Me.tCde_AC.Text <> "" Then sSql &= "And numcde_erp like '%" & Me.tCde_AC.Text & "%'"

        sSql &= " ORDER BY NumCdeEDI_ERP,Article"

        lers = SqlLit(sSql, conSqlEDI)
        While lers.Read
            Me.gAnoCde.Rows.Add(lers("NumCdeEDI_ERP"), Nz(lers("ArtCode_ERP"), ""), Nz(lers("CodeClient"), ""), Nz(lers("NumCde_ERP"), ""), Nz(lers("msgLigne"), ""))
        End While

        lers.Close()

        If Not AvecFiltre Then nbAnoCde = Me.gAnoCde.RowCount
        Me.gAnoCde.Visible = True
        Me.tabAnomalies.Text = "Anomalies Contrat/Cde (" & nbAnoCde + nbAnocontrat & ")"
    End Sub

    Sub ListeAnomalies()
        StatutBar("Lecture des anomalies EDI")
        ListeAnomalieEDI(False)
        StatutBar("Lecture des anomalies commandes")
        ListeAnomalieCde(False)
    End Sub

    Sub ListeCommande()
        Dim lers As OleDb.OleDbDataReader
        Dim precVal As String = ""
        Dim Cumul As Decimal
        Dim cumulBesoin As Decimal
        Dim CumulBesoinPC As Decimal
        Dim cumulCde As Decimal
        Dim msgCde As String = ""
        Dim ecart As Decimal
        Dim sSql As String
        Dim FiltreMsg As String
        Dim i As Integer = 0
        Dim NbCommande As Integer = 0
        Dim d1 As Date = Now
        Dim NumLigneMini As Integer

        'My.Settings.HorizonContratDeb = Me.tHorizonContratDeb.Text
        'My.Settings.HorizonContratFin = Me.tHorizonContratFin.Text
        If dModifFin.Checked Then
            My.Settings.DateModifFin = dModifFin.Value
        Else
            My.Settings.DateModifFin = CDate("01/01/2050")
        End If

        My.Settings.Save()

        gImport.Visible = False
        gImport.Rows.Clear()

        'TODO :  filtre à mettre en place
        FiltreMsg = ""
        If Me.optionToutContrat.Checked Then FiltreMsg = " Or MsgCde =''"
        If optionQ.Checked Then FiltreMsg &= " OR MsgCde LIKE '%Q%'"
        If optionF.Checked Then FiltreMsg &= " OR MsgCde LIKE '%F%'"
        If optionP.Checked Then FiltreMsg &= " OR MsgCde LIKE '%P%'"
        If optionN.Checked Then FiltreMsg &= " OR MsgCde LIKE '%N%'"
        If optionC.Checked Then FiltreMsg &= " OR MsgCde LIKE '%C%'"
        If optionB.Checked Then FiltreMsg &= " OR MsgCde LIKE '%B%'"
        If optionD.Checked Then FiltreMsg &= " OR MsgCde LIKE '%D%'"
        If optionL.Checked Then FiltreMsg &= " OR MsgCde LIKE '%L%'"
        If optionS.Checked Then FiltreMsg &= " OR MsgCde LIKE '%S%'"

        '        If Me.optionAutreMsg.Checked Then FiltreMsg &= " or msgLigneCumul <> ''"
        If FiltreMsg <> "" Then FiltreMsg = "And (" & FiltreMsg.Remove(0, 3) & ")" Else FiltreMsg = " and 1=2 "

        sSql = "SELECT NumCdeEDI_Tiers, NumLigneEDI_Tiers, Article, ArtDesc_Tiers, DateBesoin, Date_ERP, QteBesoin, ArtCode_ERP, QteCde, NumCde_ERP, CodeClient, TypeBesoin_Tiers, TypeCde_ERP " _
            & ", SoldeQteLigne, MsgLigne, NumCdeEDI_ERP, NumLigne_ERP, MsgCde, MsgLigneCumul ,QtePTF,lid, qtecde-qteLivre as qtePTF, PrixUnitaire_Tiers, PrixUnitaire_ERP" _
            & ", PrixTarif,ERP,NumLigneERP_Mini, typeImport" _
            & " FROM CommandeVente_Bilan " _
            & " WHERE ImportId = " & lImportId & " and siteid=" & Me.lSite.SelectedItem.value

        'Ajoute les filtres
        If tArticle.Text <> "" Then sSql &= " And (ArtCode_Tiers Like '%" & tArticle.Text & "%' OR ArtCode_ERP LIKE '%" & tArticle.Text & "%')"
        If tCommande.Text <> "" Then sSql &= " AND (NumCdeEDI_Tiers LIKE '%" & tCommande.Text & "%' OR NumCde_ERP LIKE '%" & tCommande.Text & "%')"
        If Me.dModifFin.Checked Then sSql &= " And dateLigne<" & Date2sql(Me.dModifFin.Value)

        'TODO:        If dModifFin.Checked Then sSql &= " AND date1ereModif <= " & Date2sql(dModifFin.Value)
        sSql &= FiltreMsg
        sSql &= " and NumCdeEDI_Tiers not in (   select distinct NumCdeEDI from CommandeVente_Transfert where ImportId = " & lImportId & " and statutaffiche=1)"
        sSql &= "order by NumCdeEDI_Tiers, article, NumLigneEDI_Tiers, dateLigne"

        lers = SqlLit(sSql, conSqlEDI)
        While lers.Read
            StatutBar("Commande EDI :" & i)

            'Nouvelle comande ?
            If Nz(lers("NumCdeEDI_Tiers"), "") <> precVal Then
                NbCommande += 1
                precVal = Nz(lers("NumCdeEDI_Tiers"), "")
                If cumulCde = 0 Then ecart = 0 Else ecart = Math.Round(((cumulBesoin / cumulCde - 1)), 2)
                If gImport.RowCount > 0 Then
                    gImport.Rows.Add(False, "", "", "", "", Me.iML.Images(0), "", "", "", "", cumulBesoin, cumulCde, IIf(ecart = 0, "", ecart.ToString("0%")),
                                      "", "", "", "", "", "", "", "", "", msgCde)
                    gImport.Rows(gImport.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGray
                    gImport.Rows(gImport.RowCount - 1).ReadOnly = True
                End If
                Cumul = 0
                cumulBesoin = 0
                cumulCde = 0
                msgCde = ""
                NumLigneMini = Max(Nz(lers("NumLigneERP_Mini"), 0), 10)
                If NumLigneMini Mod 10 <> 0 Then NumLigneMini = Int(NumLigneMini / 10 + 1) * 10
            End If

            msgCde = Nz(lers("MsgLigneCumul"), "")
            Cumul += Nz(lers("QteBeSoin"), 0) - Nz(lers("QteCde"), 0)
            cumulBesoin += Nz(lers("QteBesoin"), 0)
            cumulCde += Nz(lers("QteCde"), 0)

            i += 1
            CumulBesoinPC = 0

            If cumulCde > 0 Then CumulBesoinPC = Math.Round((cumulBesoin / cumulCde - 1) * 100, 0)

            gImport.Rows.Add(False, lers("NumCdeEDI_Tiers"), lers("NumLigneEDI_Tiers"), lers("Article"), lers("ArtDesc_tiers"), Me.iML.Images(0),
                             Date2Grid(lers("DateBesoin")), Date2Grid(lers("Date_ERP")),
                             lers("TypeBesoin_Tiers"), lers("TypeCde_ERP"),
                             lers("QteBesoin"), lers("QteCde"), lers("qtePTF"),
                             lers("PrixUnitaire_Tiers"), lers("PrixUnitaire_ERP"),
                             lers("ArtCode_ERP"), lers("CodeClient"), lers("NumCde_ERP"), lers("NumLigne_ERP"), "", Cumul, CumulBesoinPC,
                             Nz(lers("msgLigne"), ""), Nz(lers("msgLigneCumul"), ""), Nz(lers("msgCde"), ""), lers("lid"), lers("TypeImport"))

            'Mise en forme des cellules de la  nouvelle ligne
            With gImport.Rows(gImport.RowCount - 1)

                If Nz(.Cells("QteCde").Value, 0) <> Nz(.Cells("QteBesoin").Value, 0) Then .Cells("cumul").Style.BackColor = coulModif

                If .Cells("DateBesoin").Value <> "" And .Cells("DateCde").Value <> "" Then
                    If CDate(.Cells("DateBesoin").Value) < CDate(.Cells("DateCde").Value) Then
                        .Cells("DateBesoin").Style.BackColor = coulAvance
                        .Cells("DateCde").Style.BackColor = coulAvance
                        .Cells("AR").Value = Me.iML.Images(1)
                    End If
                    If CDate(.Cells("DateBesoin").Value) > CDate(.Cells("DateCde").Value) Then
                        .Cells("DateBesoin").Style.BackColor = coulRecule
                        .Cells("DateCde").Style.BackColor = coulRecule
                        .Cells("AR").Value = Me.iML.Images(2)
                    End If
                End If

                If .Cells("msgLigne").Value.Contains("F") Then
                    .Cells("TypeBesoin").Style.BackColor = coulSuppr
                    .Cells("TypeCde_ERP").Style.BackColor = coulSuppr
                End If
                If .Cells("msgLigne").Value.Contains("Q") Then
                    .Cells("QteBesoin").Style.BackColor = coulSuppr
                    .Cells("QteCde").Style.BackColor = coulSuppr
                End If

                'Numérotation
                If Nz(.Cells("QteBesoin").Value, 0) <> 0 Then
                    Select Case Me.lSite.Text
                        Case "Laxou", "Soucy", "Casablanca"
                            If Nz(.Cells("NumLigneCde_ERP").Value, "0") <> "0" Then
                                .Cells("NumLigne_Prop").Value = Nz(.Cells("NumLigneCde_ERP").Value, "")
                            Else
                                If Nz(.Cells("NumLigneEDI_Tiers").Value, "0") <> "0" Then
                                    .Cells("NumLigne_Prop").Value = Nz(.Cells("NumLigneEDI_Tiers").Value, "")
                                Else
                                    .Cells("NumLigne_Prop").Value = NumLigneMini
                                    NumLigneMini += 10
                                End If
                            End If

                        Case "Montauban", "Toulouse"
                            If Nz(.Cells("NumLigneCde_ERP").Value, "") <> "" Then
                                .Cells("NumLigne_Prop").Value = Nz(.Cells("NumLigneCde_ERP").Value, "")
                            Else
                                If Nz(.Cells("TypeImport").Value, "") = "Prévisions" Then
                                    .Cells("NumLigne_Prop").Value = 1
                                Else

                                    If Nz(.Cells("NumLigneEDI_Tiers").Value, "") <> "" Then
                                        .Cells("NumLigne_Prop").Value = Nz(.Cells("NumLigneEDI_Tiers").Value, "")
                                    Else
                                        .Cells("NumLigne_Prop").Style.BackColor = coulQUestion
                                    End If
                                End If
                            End If
                    End Select
                End If
            End With
        End While

        'Dernière Ligne de total
        If cumulCde = 0 Then ecart = 0 Else ecart = Math.Round(((cumulBesoin / cumulCde - 1)), 2)
        gImport.Rows.Add(False, "", "", "", "", Me.iML.Images(0), "", "", "", "", cumulBesoin, cumulCde, IIf(ecart = 0, "", ecart.ToString("0%")), "", "", "", "", "", "", "", "", "", msgCde)
        gImport.Rows(gImport.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGray
        gImport.Rows(gImport.RowCount - 1).ReadOnly = True

        'Fin
        lers.Close()


        gImport.Visible = True
        afficheNbCdeEDI()

        tNbContrat.Text = NbCommande & " commande"
        If NbCommande > 1 Then tNbContrat.Text += "s"

    End Sub


    Function ExecuteBilan() As Boolean
        Dim lesParam As New List(Of SSISParam)
        Try
            If lTiers.SelectedItem Is Nothing Then
                MsgBox("Choisir un Tiers !")
            ElseIf lSite.SelectedItem Is Nothing Then
                MsgBox("Choisir un Site !")
            Else
                lesParam.Clear()

                lesParam.Add(New SSISParam("ImportId", lImportId, "PACKAGE"))
                'lesParam.Add(New SSISParam("TiersId", lTiers.SelectedItem.Value, "PACKAGE"))
                lesParam.Add(New SSISParam("UserLogin", leUser.Login, "PACKAGE"))
                lesParam.Add(New SSISParam("SiteId", lSite.SelectedItem.value, "PACKAGE"))

                Return SSISexecute(leUser.RepSSIS, "DM_IN_CDV_Bilan.dtsx", lesParam, "Analyse des données Importées")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Throw New Exception(ex.Message)
            Return False
        End Try

        Return False
    End Function

    Function ImportNouveau() As Integer
        Dim idNew = SqlDo("INSERT INTO app.Import (IdUser, DateImport, TiersId) VALUES ('" & leUser.Id & "', '" & Now() & "', 0" & lTiers.SelectedItem.value & ")", conSqlEDI, True)
        Return idNew
    End Function

    Sub ImportAfficheNum(lenum As Integer, laDate As Date)
        If lenum > 0 Then
            tImport.Text = "N° " & lenum & " du " & laDate.ToString("dd/MM/yyyy HH:mm")
        Else
            tImport.Text = "N° ?"
        End If

    End Sub

    Function ImportDernier() As Integer
        Dim sSql As String
        Dim lId As Integer

        sSql = "SELECT top 1 ImportId, DateImport FROM app.Import where tiersid=" & Me.lTiers.SelectedItem.value & " order by importid desc"
        Dim leRs = SqlLit(sSql, conSqlEDI)

        If leRs.HasRows Then
            leRs.Read()
            lId = leRs("ImportId")
            Call ImportAfficheNum(lId, leRs("DateImport"))
        Else
            lId = 0
            Call ImportAfficheNum(lId, Nothing)
        End If
        leRs.Close()

        Return lId
    End Function

    Sub ImportBilan()
        Dim Nblignes As Integer = 0

        '        lImportId = ImportDernier()

        Try
            Dim leRs = SqlLit("SELECT COUNT(*) AS Nb FROM CommandeVente_EDI WHERE Importid = " & Me.lImportId, conSqlEDI)
            While leRs.Read
                Nblignes = leRs(0)
            End While
            leRs.Close()

            If Nblignes >= 0 Then
                F_Main.Focus()
                If MessageBox.Show(Nblignes & " lignes importées. Continuer ?", "Importation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then

                    Call ImportAfficheNum(Me.lImportId, Now)
                    StatutBar("Exécution Bilan")
                    If ExecuteBilan() Then
                        F_Main.Focus()
                        MessageBox.Show("Import terminé")
                        AfficheBilan()
                    End If
                End If
                StatutBar("")
            Else
                F_Main.Focus()
                MessageBox.Show("Erreur Importation")
            End If
            StatutBar("")
        Catch ex As Exception
            F_Main.Focus()
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Import(sender As System.Object, e As System.EventArgs) Handles bImporter.Click
        Dim lesParam As New List(Of SSISParam)
        Dim LoadFile As Boolean = False
        Dim sSql As String
        Dim leRs As OleDb.OleDbDataReader
        Dim bImp As Boolean = False

        If IsNothing(Me.lTiers.SelectedItem) Then Exit Sub

        Try
            StatutBar("Recherche Traitement Tiers...")

            lImportId = ImportNouveau()


            'Vérif chargement par fichier ou directement par base ERP
            sSql = "SELECT TiersLoadFile FROM app.Tiers WHERE TiersId = " & Me.lTiers.SelectedItem.Value
            leRs = SqlLit(sSql, conSqlEDI)
            If leRs.HasRows Then
                leRs.Read()
                LoadFile = leRs(0)
            End If
            leRs.Close()

            If Not LoadFile Then
                StatutBar("Import Données InterCo...")
                lesParam.Add(New SSISParam("TiersId", Me.lTiers.SelectedItem.Value, "PACKAGE"))
                lesParam.Add(New SSISParam("UserLogin", leUser.Login, "PACKAGE"))
                bImp = SSISexecute(leUser.RepSSIS, "DM_IN_ImportInterCo.dtsx", lesParam, "Import données InterCo")
            Else
                StatutBar("Import Données Fichiers...")
                F_ImportListe.leTiersId = Me.lTiers.SelectedItem.Value
                F_ImportListe.lImportId = Me.lImportId
                If F_ImportListe.ShowDialog() = DialogResult.OK Then bImp = True
                F_ImportListe.Dispose()
            End If

            If bImp Then ImportBilan()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        StatutBar("")

    End Sub

    Sub OptionAnoContratInit(b As Boolean)
        Me.OptionA.Checked = b
        Me.OptionI.Checked = b
    End Sub

    Sub OptionAnoCdeInit(b As Boolean)
        optionG.Checked = b
        optionH.Checked = b
        optionM.Checked = b
    End Sub

    Sub OptionContratInit(b As Boolean)
        optionQ.Checked = b
        optionF.Checked = b
        optionP.Checked = b
        optionN.Checked = b
        optionB.Checked = b
        optionC.Checked = b
        optionD.Checked = b
        optionL.Checked = b
        optionS.Checked = b
    End Sub

    Public Sub MakeGridViewDoubleBuffered(ByVal dgv As DataGridView)
        Dim dgvType As Type = dgv.[GetType]()
        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(dgv, True, Nothing)
    End Sub

    Private Sub F_ImportCdeVente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        ListeTiers()



        My.Settings.Reload()
        If Year(My.Settings.DateModifFin) < 2050 Then
            dModifFin.Checked = True
            dModifFin.Value = My.Settings.DateModifFin
        Else
            dModifFin.Checked = False
        End If
        MakeGridViewDoubleBuffered(gImport)
    End Sub

    Private Sub GImportContrat_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gImport.CellBeginEdit
        ancVal = Nz(Me.gImport.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, "").ToString
    End Sub

    Private Sub GImportContrat_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gImport.CellEndEdit
        Dim cumul As Decimal
        Dim CumulCde As Decimal
        Dim i As Integer
        Dim soldeligne As Decimal

        If e.ColumnIndex > 1 And Nz(Me.gImport.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, "").ToString <> ancVal Then
            Me.gImport.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.LightGreen

            If Me.gImport.Columns(e.ColumnIndex).HeaderText = "Qté Cde" Then
                ' remonte à la 1ere ligne du contrat
                i = e.RowIndex
                While Nz(Me.gImport.Rows(i - 1).Cells("NumCdeEDI_Tiers").Value, "") <> "" And i > 0
                    Me.gImport.Rows(i).Cells("SelContrat").Value = True
                    i -= 1
                End While

                'recalcul le cumul
                CumulCde = 0
                cumul = 0
                While Me.gImport.Rows(i).Cells("NumCdeEDI_Tiers").Value <> "" And i < Me.gImport.RowCount - 1
                    Me.gImport.Rows(i).Cells("Cumul").Style.BackColor = Me.gImport.RowsDefaultCellStyle.BackColor
                    CumulCde += Val(Nz(Me.gImport.Rows(i).Cells("QteCde").Value, 0))
                    soldeligne = Val(Nz(Me.gImport.Rows(i).Cells("QteCde").Value, 0)) - Val(Nz(Me.gImport.Rows(i).Cells("QteBesoin").Value, 0))
                    cumul += soldeligne
                    If soldeligne <> 0 Then Me.gImport.Rows(i).Cells("Cumul").Style.BackColor = Color.PeachPuff
                    Me.gImport.Rows(i).Cells("Cumul").Value = cumul
                    Me.gImport.Rows(i).Cells("SelContrat").Value = True

                    i += 1
                End While
                Me.gImport.Rows(i).Cells("QteCde").Value = CumulCde

            End If

        End If
    End Sub

    Function TransfertEncours() As Boolean
        '        Dim sSql As String
        '        Dim leRs As OleDb.OleDbDataReader
        Dim nbl As Integer = 0
        '        Dim listeClient As String = "('0'"
        '        Dim lesParam As New List(Of SSISParam)

        'Try
        'regarde d'abord s'il y a des lignes dans MAcro_comc 
        'TODO :             lesParam.Add(New SSISParam("UserLogin", leUser.Login, "PACKAGE"))
        'TODO :             SSISexecute(leUser.RepSSIS, "DM_IN_CDV_Integration.dtsx", lesParam, "Actualisation commandes ...")

        'sSql = "SELECT COUNT(NbLigne) AS NbL FROM CommandeVente_Integration WHERE UserLogin = '" & leUser.Login & "' GROUP BY CliCode, NoCommande"
        'leRs = SqlLit(sSql, conSqlEDI)
        'While leRs.Read
        '    nbl = leRs("NbL")
        'End While
        'leRs.Close()

        ''S'il y a des lignes dans Macro_Comc, alors on regarde si cela concerne le client sélectionné
        'If nbl <> 0 Then
        '    'cherche les codes ERP du client séléctionné
        '    sSql = "SELECT DISTINCT CodeGroupe " _
        '                & "FROM app.Tiers AS t INNER JOIN app.TiersSiteERP AS e ON t.TiersId = e.TiersId INNER JOIN app.Site AS s ON e.SiteId = s.SiteId INNER JOIN app.UserSite AS us ON us.SiteId = s.SiteId INNER JOIN app.Users AS u ON us.UserId = u.UserId " _
        '                & "WHERE t.TiersId = 0" & lTiers.SelectedItem.value
        '    leRs = SqlLit(sSql, conSqlEDI)
        '    While leRs.Read
        '        listeClient &= ",'" & leRs("CodeGroupe") & "'"
        '    End While
        '    leRs.Close()
        '    listeClient &= ")"

        '    nbl = 0
        '    sSql = "SELECT COUNT(NbLigne) AS NbL FROM CommandeVente_Integration WHERE UserLogin = '" & leUser.Login & "' AND CliCode IN " & listeClient & " GROUP BY CliCode, NoCommande"
        '    leRs = SqlLit(sSql, conSqlEDI)
        '    While leRs.Read
        '        nbl = leRs("NbL")
        '    End While
        '    leRs.Close()
        'End If

        'Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        'End Try

        Return (nbl <> 0)
    End Function

    Private Sub Retraiter(sender As System.Object, e As System.EventArgs) Handles bRetraiter.Click
        Try
            If TransfertEncours() Then
                MsgBox("Retraitement impossible car des lignes sont en cours de transfert.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Attention")
            Else
                If ExecuteBilan() Then AfficheBilan()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Afficher(sender As System.Object, e As System.EventArgs) Handles bAfficher.Click

        AttenteDemarre("Affichage en-cours")
        StatutBar("Lecture des commandes")
        ListeCommande()
        StatutBar("")
        System.Threading.Thread.Sleep(1000)
        AttenteFin()
    End Sub

    Private Sub THorizonContrat_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then ListeCommande()
    End Sub

    Private Sub THorizonContratFin_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then ListeCommande()
    End Sub

    Private Sub GImportContrat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gImport.CellContentClick
        Dim i As Integer
        Dim Laligne As Integer
        Dim b As Boolean
        If e.ColumnIndex < 1 AndAlso Nz(Me.gImport.Rows(e.RowIndex).Cells("NumCdeEDI_Tiers").Value, "") <> "" Then
            Laligne = e.RowIndex
            i = Laligne
            b = Me.gImport(0, i).Value

            ' Remonte à la 1ere ligne de la commande
            While i > 0 AndAlso Nz(Me.gImport.Rows(i - 1).Cells("NumCdeEDI_Tiers").Value, "") <> "" : i -= 1 : End While

            'coche les lignes de la commande
            While Me.gImport.Rows(i).Cells("NumCdeEDI_Tiers").Value <> "" And i < Me.gImport.RowCount - 1
                Me.gImport.Rows(i).Cells("SelContrat").Value = Not b
                i += 1
            End While
        End If
    End Sub

    Private Sub CSel_CheckedChanged(sender As Object, e As EventArgs) Handles cSel.CheckedChanged
        For i = 0 To gImport.RowCount - 1
            If Nz(gImport.Rows(i).Cells("NumCdeEDI_Tiers").Value, "") <> "" Then
                gImport.Rows(i).Cells(0).Value = cSel.Checked
            End If
        Next
    End Sub

    Private Sub LTiers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lTiers.SelectedIndexChanged

        'récupère le dernier ImportId du Tiers/Utilisateur
        lImportId = ImportDernier()
        listesite()

        'bRetraiter.Enabled = False
        bImporter.Enabled = True

        InitBilan()

        lSite_SelectedIndexChanged(Nothing, Nothing)

        Call AfficheContext()
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles tArticle.KeyUp, tCommande.KeyUp
        If e.KeyCode = Keys.Enter Then ListeCommande()
    End Sub

    Private Sub FiltrerAno(sender As Object, e As EventArgs) Handles bFiltreAno.Click
        ListeAnomalieEDI(True)
    End Sub

    Private Function CtrlVerrou()
        'TODO : vérifier si c'est necessaire

        'Dim lesContrats As String = ""
        'Dim lesEncours As String = ""
        'Dim sSql As String
        Dim lesEncoursSelect As String = ""
        'Dim lers As OleDb.OleDbDataReader
        'Dim lesParam As New List(Of SSISParam)

        'lesParam.Add(New SSISParam("UserLogin", leUser.Login, "PACKAGE"))
        'SSISexecute(leUser.RepSSIS, "DM_IN_CDV_Verrou.dtsx", lesParam, "Vérification vérrou ...")

        ''Mémorise les lignes 
        'sSql = "Select CliCode, NumCommande, LigneCommande from CommandeVente_Verrou WHERE UserLogin = '" & leUser.Login & "' "
            'lers = SqlLit(sSql, conSqlEDI)
            'While lers.Read
            '    lesEncours &= lers("CliCode") & "#" & lers("NumCommande") & "#" & lers("LigneCommande") & "!"
            'End While
            'lers.Close()

            'For i = 0 To Me.gImport.RowCount - 2
            '    If Nz(Me.gImport.Rows(i).Cells(0).Value, False) = True Then
            '        If Not lesContrats.Contains(Me.gImport.Rows(i).Cells("NumContrat_tiers").Value) Then lesContrats += ",'" & Me.gImport.Rows(i).Cells("NumContrat_tiers").Value & "'"

            '        'vérifie si la ligne n'est pas en cours
            '        For Each s In lesEncours.Split("!")
            '            If s.Contains(Me.gImport.Rows(i).Cells("CodeClient").Value & Me.gImport.Rows(i).Cells("NumCde_ERP").Value & Me.gImport.Rows(i).Cells("NumLigne_Prop").Value) Then
            '                lesEncoursSelect &= Me.gImport.Rows(i).Cells("CodeClient").Value & "#" & Me.gImport.Rows(i).Cells("NumCde_ERP").Value & "#" & Me.gImport.Rows(i).Cells("NumLigne_Prop").Value & "#" & s.Split("#")(1) & "!"
            '            End If
            '        Next
            '    End If
            'Next

            Return lesEncoursSelect
    End Function

    Private Sub ArchiveTransfertCde()
        Dim sSql As String = ""
        '        Dim d As Date
        Dim StatutLigne As String = ""
        Dim lesEncoursSelect As String = ""
        Dim lesParam As New List(Of SSISParam)

        ' ...
        If Me.lSite.Text <> "Montauban" And Me.lSite.Text <> "Toulouse" Then lesEncoursSelect = CtrlVerrou()

        If lesEncoursSelect <> "" Then
            MsgBox("Transfert impossible, des lignes sont vérouillées !", MsgBoxStyle.OkOnly & MsgBoxStyle.Exclamation)
            F_LigneVerouille.lesCde = lesEncoursSelect
            F_LigneVerouille.ShowDialog()
        Else
            If MsgBox("Transferer les commandes sélectionnées ?", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question) = MsgBoxResult.Ok Then
                Try
                    'Ecrit dans la table Transfert
                    For i = 0 To Me.gImport.RowCount - 2

                        With Me.gImport.Rows(i)
                            If Nz(.Cells(0).Value, False) = True Then
                                'Archivage transfert
                                'd = .Cells("DateBesoin").Value
                                sSql &= "INSERT INTO CommandeVente_Transfert (lId, ImportId, NumCdeEDI, NumLigneEDI, Article, ArtDesc, TypeBesoin, DateBesoin, QteBesoin, TypeCde_ERP, NumCde_ERP, NumLigne_ERP, DateCde, QteCde, ArtCode_ERP, NumLigne_Prop, DateTransfert, StatutTransfert, CodeClient, StatutAffiche,siteId )" _
                                & " VALUES (" _
                                & "'" & .Cells("lId").Value & "', 0" & lImportId & ", " _
                                & "'" & Nz(.Cells("NumCdeEDI_Tiers").Value, "") & "', '" & Nz(.Cells("NumLigneEDI_Tiers").Value, "") & "', '" & Nz(.Cells("ArtCode_Tiers").Value, "") & "', '" & Nz(.Cells("ArtDesc_Tiers").Value, "").Replace("'", "''") & "', " _
                                & "'" & Nz(.Cells("TypeBesoin").Value, "") & "', '" & Nz(.Cells("DateBesoin").Value, "") & "', 0" & Txt2sql(Nz(.Cells("QteBesoin").Value, "0")) & ", '" & Nz(.Cells("TypeCde_ERP").Value, "") & "', " _
                                & "'" & Nz(.Cells("NumCde_ERP").Value, "") & "', '" & Nz(.Cells("NumLigneCde_ERP").Value, "") & "', '" & Nz(.Cells("DateCde").Value, "") & "', 0" & Txt2sql(Nz(.Cells("QteCde").Value, "0")) & ", " _
                                & "'" & Nz(.Cells("ArtCode_ERP").Value, "") & "', '" & Nz(.Cells("NumLigne_Prop").Value, "") & "', '" & Now & "', 'D', '" & .Cells("CodeClient").Value & "', 1," & Me.lSite.SelectedItem.value & ")"
                            End If
                        End With
                    Next i

                    SqlDo(sSql, conSqlEDI)

                    Dim leFichier As String = "EDI_CDE_" & Now.ToString("ddMMyy_HHmm") & ".txt"

                    My.Settings.Reload()
                    lesParam.Clear()
                    lesParam.Add(New SSISParam("ImportId", lImportId, "PACKAGE"))
                    lesParam.Add(New SSISParam("SiteId", Me.lSite.SelectedItem.value, "PACKAGE"))
                    '                    lesParam.Add(New SSISParam("TiersId", lTiers.SelectedItem.value, "PACKAGE"))
                    lesParam.Add(New SSISParam("UserLogin", leUser.Login, "PACKAGE"))
                    lesParam.Add(New SSISParam("LeFichier", "\\pmssqlc1\EDI\Export\" & leFichier, "PACKAGE"))

                    SSISexecute(leUser.RepSSIS, "DM_IN_CDV_Integre.dtsx", lesParam, "Ecriture des données -> ERP")

                    FileCopy("\\pmssqlc1\EDI\Export\" & leFichier, My.Settings.CheminExportTOPS & leFichier)

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                AfficheBilan()
            End If
        End If
    End Sub

    Private Sub GContrat_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gImport.CellContentDoubleClick
        GImportContrat_CellContentClick(sender, e)
    End Sub


    Private Sub BTransfert_Click(sender As Object, e As EventArgs) Handles bTransfert.Click
        ArchiveTransfertCde()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        If lTiers.SelectedItem IsNot Nothing Then
            F_Doc.leTiersid = Me.lTiers.SelectedItem.value
            F_Doc.ShowDialog()
        End If
    End Sub

    Private Sub OptionToutAno_CheckedChanged(sender As Object, e As EventArgs) Handles optionToutAnoContrat.CheckedChanged
        OptionAnoContratInit(optionToutAnoContrat.Checked)
    End Sub



    Private Sub OptionToutAnoCde_CheckedChanged(sender As Object, e As EventArgs) Handles optionToutAnoCde.CheckedChanged
        OptionAnoCdeInit(optionToutAnoCde.Checked)
    End Sub

    Private Sub FiltrerAnoERP(sender As Object, e As EventArgs) Handles bFiltreAnoERP.Click
        ListeAnomalieCde(True)
    End Sub

    Private Sub OptionToutContrat_CheckedChanged(sender As Object, e As EventArgs) Handles optionToutContrat.CheckedChanged
        OptionContratInit(optionToutContrat.Checked)
    End Sub



    'Private Sub LinkLabel1_LinkClicked_2(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles bEncours.Click
    '    Dim impE As F_ImportEncours = New F_ImportEncours
    '    impE.ShowDialog()
    '    impE.Dispose()
    'End Sub

    'Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles bArchives.Click

    '    If lTiers.SelectedIndex < 0 Then Exit Sub
    '    F_ImportArchive.leTiers = lTiers.SelectedItem.value
    '    F_ImportArchive.ShowDialog()
    '    F_ImportArchive.Dispose()
    'End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub

    Private Sub lSite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lSite.SelectedIndexChanged
        If Me.lSite.SelectedIndex >= 0 Then
            bRetraiter.Enabled = True

            'vérifie que le site choisi et le dernier site du traitement
            Dim lers As OleDb.OleDbDataReader
            Dim leSiteActu As Integer = 0
            lers = SqlLit("select max(SiteId) from  ( select max(siteid) as SiteId from CommandeVente_Bilan where importid=" & lImportId & " union select max(siteid) from CommandeVente_Anomalie where importid=" & lImportId & ") t", conSqlEDI)
            While lers.Read : leSiteActu = Nz(lers(0), 0) : End While
            lers.Close()

            If lImportId > 0 Then
                If leSiteActu = Me.lSite.SelectedItem.value Then

                    Me.gImport.Rows.Clear()

                    StatutBar("Lecture des anomalies EDI")
                    ListeAnomalieEDI(False)

                    StatutBar("Lecture des anomalies commandes")
                    ListeAnomalieCde(False)

                    afficheNbCdeEDI()

                    StatutBar("")
                    Me.Tableaux.Visible = True
                Else
                    Me.Tableaux.Visible = False
                End If

            End If
        End If
        Call AfficheContext()
    End Sub

    Private Sub tCde_AE_KeyUp(sender As Object, e As KeyEventArgs) Handles tCde_AE.KeyUp
        If e.KeyCode = Keys.Enter Then ListeAnomalieEDI(True)
    End Sub

    Private Sub tArt_AE_KeyUp(sender As Object, e As KeyEventArgs) Handles tArt_AE.KeyUp
        If e.KeyCode = Keys.Enter Then ListeAnomalieEDI(True)
    End Sub

    Private Sub tCde_AC_KeyUp(sender As Object, e As KeyEventArgs) Handles tCde_AC.KeyUp
        If e.KeyCode = Keys.Enter Then ListeAnomalieCde(True)
    End Sub

    Private Sub tArt_AC_KeyUp(sender As Object, e As KeyEventArgs) Handles tArt_AC.KeyUp
        If e.KeyCode = Keys.Enter Then ListeAnomalieCde(True)
    End Sub

    Private Sub F_ImportCdeVente_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        F_Main.sContext.Text = ""
    End Sub

    Private Sub bArchives_Click(sender As Object, e As EventArgs) Handles bArchives.Click
        If Me.lTiers.SelectedIndex < 0 Then Exit Sub
        F_ImportArchive.leTiers = Me.lTiers.SelectedItem.value
        F_ImportArchive.ShowDialog()
        F_ImportArchive.Dispose()
    End Sub
End Class