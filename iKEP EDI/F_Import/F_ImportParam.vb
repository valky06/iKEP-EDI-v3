Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.Remoting.Messaging
Imports Microsoft.Office.Interop.Excel


Public Class F_ImportParam

    Public LeFichier As String
    Public LeTiersId As String
    Public LeParam As String
    Public LeTraitId As Integer = 0
    Public LeTypeTrait As String
    Public Lextension As String


    Dim lesColHeader As New Dictionary(Of Integer, String)
    Dim lesColValeur As New Dictionary(Of Integer, String)


    Private Sub CloseExcel(xlapp As Application)
        Try
            xlapp.ActiveWorkbook.Close()
            xlapp.Quit()
            Runtime.InteropServices.Marshal.ReleaseComObject(xlapp)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub F_ImportListe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MAZ des objets
        tabMapping.Enabled = False
        bOK.Enabled = False
        Me.gTypeCSV.Visible = False
        Me.gTypeXLS.Visible = False
        lblFile.Text = LeFichier

        'Remplissage des onglets excel
        If LeFichier.EndsWith(".xls") Or LeFichier.EndsWith(".xlsx") Then
            AttenteDemarre("Chargement des données ...", 2)

            'Rempli liste des Onglets
            Dim xlApp As New Application()
            Dim xlWorkSheet As Worksheet
            xlApp.Workbooks.Open(LeFichier, 0, False)
            cSheet.Items.Clear()
            For i = 1 To xlApp.Sheets.Count
                'Attention, certaines feuilles ne sont pas des feuilles de calcul mais des graf... il faut donc tester
                Try
                    xlWorkSheet = xlApp.Sheets(i)
                    cSheet.Items.Add(New ListItem(xlWorkSheet.Name, xlWorkSheet.Name))

                Catch ex As Exception

                End Try

            Next

            CloseExcel(xlApp)
            xlApp = Nothing

            AttenteFin()
            Me.Focus()

            Me.gTypeXLS.Visible = True

        Else
            Me.gTypeCSV.Visible = True
        End If


        If LeParam <> "" Then
            If LeParam.Split("|")(0).Split(";")(0) = "XL" Then
                Me.tNumLigneEntete.Text = LeParam.Split("|")(0).Split(";")(1)
                Call ComboSelectTxt(LeParam.Split("|")(0).Split(";")(2), Me.cSheet)
            End If

            If LeParam.Split("|")(0).Split(";")(0) = "CSV" Then Me.cDelimiter.Text = LeParam.Split("|")(0).Split(";")(1)

            For Each cmp As System.Windows.Forms.Control In Me.oMapping.Controls
                If TypeOf (cmp) Is System.Windows.Forms.TextBox And cmp.Tag <> "" Then
                    For Each s In LeParam.Split("|")
                        If cmp.Tag.ToString.Split(";")(0) = s.Split(";")(0) Then cmp.Text = s.Split(";")(1)
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub Save(sender As Object, e As EventArgs) Handles bOK.Click
        Dim Obligatoire As Boolean = True

        If Me.gTypeCSV.Visible Then LeParam = "CSV;" & Me.cDelimiter.Text
        If Me.gTypeXLS.Visible Then LeParam = "XL;" & Me.tNumLigneEntete.Text & ";" & Txt2sql(Me.cSheet.Text)

        For Each cmp As System.Windows.Forms.Control In Me.oMapping.Controls
            If TypeOf (cmp) Is System.Windows.Forms.TextBox Then
                LeParam &= "|" & cmp.Tag.ToString.Split(";")(0) & ";" & cmp.Text
                If Nz(cmp.Tag, "").ToString.Contains(";o") AndAlso cmp.Text = "" Then Obligatoire = False
            End If
        Next

        If Not Obligatoire Then
            MsgBox("Tous les champs obligatoires doivent être renseignés")
        Else
            If LeTraitId = 0 Then
                SqlDo("INSERT INTO app.TiersTraitement (TiersId, TypeTraitement, Extension, LesParam ) VALUES ('" & LeTiersId & "', '" & LeTypeTrait & "','" & Lextension & "','" & LeParam & "')", conSqlEDI, True)
            Else
                SqlDo("UPDATE app.TiersTraitement set LesParam= '" & LeParam & "' WHERE TiersTraitId = " & LeTraitId, conSqlEDI)
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Cancel(sender As Object, e As EventArgs) Handles bAnnul.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub LoadHeader(sender As Object, e As EventArgs) Handles cSheet.SelectedIndexChanged, tNumLigneEntete.TextChanged, cDelimiter.SelectedIndexChanged
        If LeFichier = "" Then Exit Sub

        If Me.cSheet.SelectedIndex < 0 Then Exit Sub

        tabMapping.Enabled = False
        bOK.Enabled = False
        ClearAllParam(oMapping.Controls)
        Try
            AttenteDemarre("Chargement de l'entête ...", 2)

            Dim xlApp As New Application()
            Dim xlWorkSheet As Worksheet

            If LeFichier.Contains(".xls") Then
                xlApp.Workbooks.Open(LeFichier, 0, False)
                xlWorkSheet = xlApp.Worksheets(cSheet.Text)
            Else
                xlApp.Workbooks.Open(LeFichier, 0, False, Me.cDelimiter.SelectedIndex)
                xlWorkSheet = xlApp.ActiveSheet
            End If

            'lit les entetes et la première ligne de valeur
            lesColHeader.Clear()
            lesColValeur.Clear()
            lesColHeader.Add(0, "")
            lesColValeur.Add(0, "")
            For x As Integer = 1 To xlWorkSheet.Cells(Val(Me.tNumLigneEntete.Text), xlWorkSheet.Columns.Count).End(XlDirection.xlToLeft).Column
                If tNumLigneEntete.Text = 0 Then
                    lesColHeader.Add(x, x.ToString)
                Else
                    If xlWorkSheet.Cells(Val(Me.tNumLigneEntete.Text), x).Value <> "" Then
                        lesColHeader.Add(x, xlWorkSheet.Cells(Val(Me.tNumLigneEntete.Text), x).Value)
                        If xlWorkSheet.Cells(Val(Me.tNumLigneEntete.Text) + 1, x).value Is Nothing Then
                            lesColValeur.Add(x, "Col" & x)
                        Else
                            If (xlWorkSheet.Cells(Val(Me.tNumLigneEntete.Text) + 1, x).formula.ToString + " ").Substring(0, 1) = "=" Then '  = xlWorkSheet.Cells(Val(Me.tNumLigneEntete.Text) + 1, x).value.ToString Then '                                 Or xlWorkSheet.Cells(Val(Me.tNumLigneEntete.Text) + 1, x).value.GetType.ToString.Contains("Date") Then
                                lesColValeur.Add(x, xlWorkSheet.Cells(Val(Me.tNumLigneEntete.Text) + 1, x).formula)
                            Else
                                lesColValeur.Add(x, "Col" & x)
                            End If

                        End If
                    End If
                End If
            Next

            CloseExcel(xlApp)

            Call FillAllComboBox()

            AttenteFin()
            Me.Focus()

            bOK.Enabled = True
            tabMapping.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ClearAllParam(lsCtrls As Control.ControlCollection)
        For Each cmp As Object In lsCtrls
            If TypeOf cmp Is ComboBox Then cmp.Items.Clear()
            If TypeOf cmp Is System.Windows.Forms.TextBox Then cmp.text = ""
        Next
    End Sub

    Private Sub ComboSelChange(sender As Object, e As EventArgs) Handles cArtCli.SelectedIndexChanged, cQte.SelectedIndexChanged, cDateDem.SelectedIndexChanged _
        , ComboBox1.SelectedIndexChanged, ComboBox10.SelectedIndexChanged, ComboBox11.SelectedIndexChanged, ComboBox12.SelectedIndexChanged, ComboBox13.SelectedIndexChanged _
        , ComboBox3.SelectedIndexChanged, ComboBox4.SelectedIndexChanged, ComboBox5.SelectedIndexChanged, ComboBox6.SelectedIndexChanged, ComboBox7.SelectedIndexChanged

        For Each x In lesColHeader
            If sender.text = x.Value Then Me.oMapping.Controls(sender.tag.ToString.Split(";")(0).ToString).Text = lesColValeur(x.Key)

        Next
    End Sub

    Private Sub FillAllComboBox()
        'rempli les combo avec les valeurs
        For Each cmp As Object In Me.oMapping.Controls
            If TypeOf cmp Is ComboBox Then
                For Each val As String In lesColHeader.Values : cmp.Items.Add(val) : Next
            End If
        Next
    End Sub

End Class