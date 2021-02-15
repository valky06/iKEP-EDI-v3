Imports System.IO
Imports Microsoft.Office.Interop.Excel

Public Class F_ImportListe

    Public leTiersId As Integer
    Public lImportId As Integer = 0

    Private Sub F_ImportListe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call TiersPLus_Click(Nothing, Nothing)
    End Sub

    Sub VerifTraitement(laLigne As Integer)
        Dim LeRs As OleDb.OleDbDataReader
        Dim LaReq As String

        LaReq = "SELECT TiersTraitId, LesParam  FROM app.TiersTraitement where LesParam<>'' and TypeTraitement='" _
            & Me.gFichier.Rows(laLigne).Cells("TypeTrait").Value & "' and TiersId=" & leTiersId _
            & " and extension='" & Me.gFichier.Rows(laLigne).Cells("Extension").Value & "'"
        LeRs = SqlLit(LaReq, conSqlEDI)

        If LeRs.Read Then
            Me.gFichier.Rows(laLigne).Cells("ParamId").Value = LeRs(0)
            Me.gFichier.Rows(laLigne).Cells("Param").Value = LeRs(1)
            Me.gFichier.Rows(laLigne).Cells("ParamImg").Value = ImageList.Images(1)
        Else
            Me.gFichier.Rows(laLigne).Cells("ParamId").Value = 0
            Me.gFichier.Rows(laLigne).Cells("Param").Value = ""
            Me.gFichier.Rows(laLigne).Cells("ParamImg").Value = ImageList.Images(0)
        End If

        LeRs.Close()
    End Sub


    Private Sub TiersPLus_Click(sender As Object, e As EventArgs) Handles TiersPLus.Click
        Dim c As DataGridViewComboBoxCell
        oFileDialog.FileName = ""
        '    oFileDialog.Filter = "Excel|*.xls;*.xlsx|Text |*.txt;*.csv"
        oFileDialog.Filter = "Excel|*.xls;*.xlsx"

        If oFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Me.gFichier.Rows.Add(oFileDialog.FileName, FileExtension(oFileDialog.FileName))
            c = Me.gFichier.Rows(Me.gFichier.RowCount - 1).Cells("TypeTrait")
            Me.gFichier.Rows(Me.gFichier.RowCount - 1).Cells("TypeTrait").Value = c.Items(0)
            Call verifTraitement(Me.gFichier.RowCount - 1)
        End If
    End Sub

    Private Sub TiersMoins_Click(sender As Object, e As EventArgs) Handles TiersMoins.Click
        If Me.gFichier.SelectedRows.Count > 0 Then Me.gFichier.Rows.RemoveAt(Me.gFichier.SelectedRows(0).Index)
    End Sub

    Function ImportCdeVente(FichierSource As String, MAZ As String, typeimport As String) As Boolean
        Dim importOK As Boolean = False
        Dim lesParam As New List(Of SSISParam)
        Try
            StatutBar("Recherche Traitement Tiers...")
            lesParam.Clear()
            lesParam.Add(New SSISParam("FichierSource", leUser.RepImport & FichierSource, "PACKAGE"))
            lesParam.Add(New SSISParam("TiersId", Me.leTiersId.ToString, "PACKAGE"))
            lesParam.Add(New SSISParam("UserLogin", leUser.Login, "PACKAGE"))
            lesParam.Add(New SSISParam("MAZ", MAZ, "PACKAGE"))
            lesParam.Add(New SSISParam("TypeImport", typeimport, "PACKAGE"))
            If SSISexecute(leUser.RepSSIS, "DM_IN_CDV_Import.dtsx", lesParam, "Importation des données") Then importOK = True
            StatutBar("")

        Catch ex As Exception
            MsgBox(ex.Message)
            importOK = False
            Throw New Exception(ex.Message)
        End Try
        Return importOK

    End Function


    Private Sub BOK_Click(sender As Object, e As EventArgs) Handles bOK.Click
        'verif des type de chaque ligne
        Dim TraitErr As Boolean = False
        Dim leParam As String = ""
        Dim lafeuille As String = ""
        Dim laligne As Integer = 0
        Dim lextension As String = ""
        Dim leNomSourceServer As String = ""
        Dim leNomSourcelocal As String = ""
        Dim nblignes As Integer = 0
        Dim laDerCol As Integer = 0

        For i = 0 To Me.gFichier.RowCount - 1
            If Nz(Me.gFichier.Rows(i).Cells("TypeTrait").Value, "") = "" _
                Or Nz(Me.gFichier.Rows(i).Cells("Param").Value, "") = "" Then
                TraitErr = True
            End If
        Next

        If TraitErr Then
            MsgBox("Certains fichier à importer n'ont pas de type", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical)
        Else
            Try
                SqlDo("Delete from commandeVente_EDI where tiersid=" & Me.leTiersId & " And userlogin='" & leUser.Login & "'", conSqlEDI)
                ' TraitErr = False
                Dim XLApp As New Application()
                'XLApp.ScreenUpdating = False

                For i = 0 To Me.gFichier.RowCount - 1
                    Me.gFichier.Rows(i).Cells(0).Style.BackColor = Color.FromArgb(255, 100, 100)

                    'copie le fichier sur le serveur pour archive
                    StatutBar("Transfert Fichier sur serveur")
                    leNomSourcelocal = Me.gFichier.Rows(i).Cells("FicLocal").Value
                    lextension = leNomSourcelocal.Substring(leNomSourcelocal.LastIndexOf("."), leNomSourcelocal.Length - leNomSourcelocal.LastIndexOf("."))
                    leNomSourceServer = "\" & F_ImportCdeVente.lTiers.Text & "_" & Now.ToString("yyyyMMdd_HHmm") & "_" & i

                    AttenteDemarre("Transfert " & leNomSourcelocal & " du fichier sur le serveur", 2)
                    FileCopy(leNomSourcelocal, leUser.RepImport & leNomSourceServer & lextension)

                    'ouvre le fichier Excel
                    leParam = Me.gFichier.Rows(i).Cells("Param").Value.ToString
                    Dim XLSheetKEP As Worksheet


                    If Me.gFichier.Rows(i).Cells("Extension").Value.contains("xls") Then
                        XLApp.Workbooks.Open(Me.gFichier.Rows(i).Cells("FicLocal").Value, 0, False)
                        lafeuille = leParam.Split("|")(0).Split(";")(2)
                        laligne = leParam.Split("|")(0).Split(";")(1)
                    Else
                        XLApp.Workbooks.OpenText(Me.gFichier.Rows(i).Cells("FicLocal").Value,,, XlTextParsingType.xlDelimited, "'", False, False, True, False)
                        lafeuille = XLApp.ActiveSheet.name
                        laligne = 1
                    End If

                    Dim XLSheetData As Worksheet = XLApp.Worksheets(lafeuille)

                    laDerCol = XLSheetData.Cells(laligne, XLSheetData.Columns.Count).End(XlDirection.xlToLeft).Column
                    StatutBar("Mise en forme Fichier Excel")
                    'prépare la feuille Excel contenant les données retravaillées
                    '1er et 2 ligne  du tableau
                    XLSheetKEP = XLApp.Worksheets.Add()
                    '''''''''''XLApp.Visible = True
                    XLSheetKEP.Name = "EDIKEP"
                    XLSheetData.Activate()

                    For j = 1 To leParam.Split("|").Count - 1
                        XLSheetKEP.Cells(1, j).value = leParam.Split("|")(j).Split(";")(0)
                        If leParam.Split("|")(j).Split(";")(1) <> "" Then
                            If leParam.Split("|")(j).Split(";")(1).Contains("Col") Then

                                XLSheetKEP.Cells(2, j).formulaR1C1 = "='" & lafeuille & "'!R[" & (laligne - 1).ToString & "]C" & leParam.Split("|")(j).Split(";")(1).Replace("Col", "")

                            Else

                                laDerCol += 1

                                XLSheetData.Cells(laligne + 1, laDerCol).formula = leParam.Split("|")(j).Split(";")(1)
                                XLSheetData.Cells(laligne + 1, laDerCol).Copy()
                                'XLSheetData.Range(XLSheetData.Cells(3, 50), XLSheetData.Cells(25, 50)).Select()
                                XLSheetData.Range(XLSheetData.Cells(laligne + 2, laDerCol), XLSheetData.Cells(XLSheetData.UsedRange.Rows.Count, laDerCol)).Select()
                                XLSheetData.Paste()

                                XLSheetKEP.Cells(2, j).formular1c1 = "='" & lafeuille & "'!R[" & (laligne - 1).ToString & "]C" & laDerCol

                                '                                XLSheetKEP.Cells(2, j).formula = leParam.Split("|")(j).Split(";")(1)
                            End If
                        End If
                    Next

                    'Colle sur les autres lignes
                    XLSheetKEP.Activate()
                    XLSheetKEP.Range(XLSheetKEP.Cells(2, 1), XLSheetKEP.Cells(2, leParam.Split("|").Count - 1)).Copy()
                    XLSheetKEP.Range(XLSheetKEP.Cells(3, 1), XLSheetKEP.Cells(XLApp.Worksheets(lafeuille).UsedRange.rows.count, 1)).Select()
                    XLSheetKEP.Paste()

                    For j = 1 To leParam.Split("|").Count - 1
                        If leParam.Split("|")(j).Split(";")(0).Contains("Date") Then
                            XLSheetKEP.Columns(j).NumberFormat = "yyyy-mm-dd"
                        End If
                    Next

                    AttenteFin()

                    StatutBar("Transfert Fichier CSV sur serveur")
                    XLSheetKEP.SaveAs(leUser.RepImport & leNomSourceServer & ".csv", XlFileFormat.xlCSV,,,, False)
                    XLApp.ActiveWorkbook.Close(False)

                    StatutBar("Importaton des données")
                    Call ImportCdeVente(leNomSourceServer & ".csv", IIf(i = 0, "O", "N"), Me.gFichier.Rows(i).Cells("TypeTrait").Value)

                Next i

                XLApp.Quit()
                Runtime.InteropServices.Marshal.ReleaseComObject(XLApp)
                XLApp = Nothing
            Catch ex As Exception
                TraitErr = True
                Me.Focus()
                MessageBox.Show(ex.Message)
            End Try

            StatutBar("")
            Me.DialogResult = IIf(TraitErr, DialogResult.Cancel, DialogResult.OK)
            Me.Close()
            StatutBar("")

        End If
    End Sub

    Private Sub BAnnul_Click(sender As Object, e As EventArgs) Handles bAnnul.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub GFichier_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gFichier.CellContentClick
        If e.ColumnIndex = Me.gFichier.Columns("ParamImg").Index Then

            F_ImportParam.LeFichier = Me.gFichier.Rows(e.RowIndex).Cells("FicLocal").Value
            F_ImportParam.Lextension = Me.gFichier.Rows(e.RowIndex).Cells("Extension").Value
            F_ImportParam.LeTraitId = Me.gFichier.Rows(e.RowIndex).Cells("ParamId").Value
            F_ImportParam.LeTiersId = Me.leTiersId
            F_ImportParam.LeTypeTrait = Me.gFichier.Rows(e.RowIndex).Cells("TypeTrait").Value
            F_ImportParam.LeParam = Me.gFichier.Rows(e.RowIndex).Cells("Param").Value
            If F_ImportParam.ShowDialog() = DialogResult.OK Then
                For i = 0 To Me.gFichier.RowCount - 1
                    If Me.gFichier.Rows(i).Cells("TypeTrait").Value = Me.gFichier.Rows(e.RowIndex).Cells("TypeTrait").Value Then
                        Call verifTraitement(i)
                    End If
                Next
            End If
            F_ImportParam.Dispose()
        End If
    End Sub

    Private Sub GFichier_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles gFichier.CellValueChanged
    End Sub

    Private Sub GFichier_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles gFichier.CellValidated
        If e.RowIndex >= 0 And e.ColumnIndex = Me.gFichier.Columns("TypeTrait").Index Then Call verifTraitement(e.RowIndex)
    End Sub
End Class