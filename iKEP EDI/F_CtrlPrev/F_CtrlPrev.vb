Public Class F_CtrlPrev

    Public conSqlERP As New OleDb.OleDbConnection


    Sub AfficheCde()
        Dim Ssql As String = ""
        Dim lers As OleDb.OleDbDataReader
        Dim lId As String = ""

        If Me.lSIte.SelectedIndex < 0 Then Exit Sub
        Me.gImport.Rows.Clear()

        My.Settings.DelaiSaisi = Val(Me.tDelaiSaisie.Text)
        My.Settings.DelaiAfferme = Val(Me.tDelaiAff.Text)
        My.Settings.Save()

        Select Case Me.lSIte.SelectedItem.Text
            Case "Soucy", "Laxou", "Casablanca"
                Ssql = "select L.Nocommande NumCde,  nolignecommande NumLigne , L.codearticleprestto ArtCode, L.CodeClient CliCode , datesouhplustard DateLivre" _
                    & " , ResteLivrer QtePTF, QtePrevueOuFerme TypeCde , E.DateCreation Datecrea, C.nomClient CliNom" _
                    & " From comc L inner Join COME E on L.Nocommande=E.Nocommande And L.CodeClient = E.CodeClient" _
                    & " inner join CLI C on C.CodeClient = E.CodeClient " _
                    & " inner join (" _
                    & " Select codearticleprestto, max(DateCreation) as DateCrea from COME inner join COMC on COME.NoCommande=COMC.NoCommande where DateSouhPlusTard<'" & Me.dLiv.Value.ToString("dd/MM/yyyy") & "'" _
                    & " group by codearticleprestto ) T  on T.CodeArticleprestto = L.CodeArticleprestto" _
                    & " where resteExpedier ='O'" _
                    & " and datesouhplustard<'" & Me.dLiv.Value.ToString("dd/MM/yyyy") & "'"


                If Me.tCodeClient.Text <> "" Then Ssql &= " and L.codeCLient like '%" & Me.tCodeClient.Text & "%'"
                If Me.tCodeArticle.Text <> "" Then Ssql &= " and L.codearticleprestto like '%" & Me.tCodeArticle.Text & "%'"

                Ssql &= " order by  T.DateCrea desc ,L.CodeArticleprestto, DateSouhPlusTard,E.codeclient"

            Case "Montauban", "Toulouse"
                Ssql = "SELECT  NUMCDE,NUMLIGNE, QTEPTF,  DATELIVRE , ARTCODE, TYPECDE ,CLINOM, CLICODE, DateCrea FROM ( SELECT C.NUM_CMDE NUMCDE,L.NUM_LIGNE NUMLIGNE, " _
                & " Case WHEN NVL(E.ID_CMDE_LIGNE,0)=0 THEN L.QTE_TOTAL -NVL(L.QTE_LIVRE,0) ELSE E.QTE_TOTAL - NVL(E.QTE_LIVRE,0) END  AS QTEPTF, " _
                & " CASE WHEN NVL(E.ID_CMDE_LIGNE,0)=0 THEN L.DATE_LIVRE ELSE E.DATE_LIVRE END  AS DATELIVRE , A.REFERENCE ARTCODE, CASE WHEN C.ID_TYPE_CMDE = 2 THEN 'P' ELSE 'F' END TYPECDE" _
                & " ,T_CLIENT.RAISON_SOCIALE CLINOM, T_CLIENT.CODE CLICODE, l.DATE_CREATION DateCrea " _
                & " FROM T_CMDE_LIGNE L INNER JOIN T_CMDE C ON C.ID_CMDE=L.ID_CMDE LEFT JOIN T_CMDE_CAD E ON E.ID_CMDE_LIGNE=L.ID_CMDE_LIGNE " _
                & " LEFT JOIN T_ARTICLE A ON A.ID_ARTICLE=L.ID_ARTICLE LEFT JOIN T_TYPE_CMDE T ON T.ID_TYPE_CMDE = C.ID_TYPE_CMDE  LEFT JOIN T_CLIENT  ON T_CLIENT.ID_CLIENT = C.ID_CLIENT " _
                & " WHERE C.ID_COMPANY IN(1, 2)  And  EXTRACT( YEAR FROM  L.DATE_LIVRE)>2019  And  NVL(L.QTE_LIVRE,0) < NVL(L.QTE_TOTAL,0)  And  NVL(L.B_CLOSED,0)=0 And NVL(C.B_CLOSED,0)=0 ) " _
                & " WHERE DATELIVRE <'" & Me.dLiv.Value.ToString("yyyy-MM-dd") & "'"
                If Me.tCodeClient.Text <> "" Then Ssql &= " AND CLINOM like '%" & Me.tCodeClient.Text & "%'"
                If Me.tCodeArticle.Text <> "" Then Ssql &= " AND ARTCODE like '%" & Me.tCodeArticle.Text & "%'"
                Ssql &= "  order by  DateCrea desc ,ARTCODE, DATELIVRE,CLICODE"
        End Select

                Try


            Me.gImport.Visible = False

            lers = SqlLit(Ssql, conSqlERP)

            While lers.Read

                If lId <> lers("ArtCode") Then
                    lId = lers("ArtCode")
                    gImport.Rows.Add(False)
                    gImport.Rows(gImport.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGray
                    gImport.Rows(gImport.RowCount - 1).ReadOnly = True
                End If

                Me.gImport.Rows.Add(False, lers("ArtCode"), lers("DateLivre"), lers("TypeCde"), lers("QtePTF"), lers("NumCde"), lers("NumLigne"), lers("CliCode"), lers("CliNom"), lers("DateCrea"))

                'Cde créer dans le délai
                If DateDiff(DateInterval.Day, lers("DateCrea"), Now) < Val(Me.tDelaiSaisie.Text) Then
                    gImport.Rows(gImport.RowCount - 1).Cells("DateCrea").Style.BackColor = Me.tMsgSaisie.BackColor
                End If

                'Date liv dans les délai affermissement
                If (DateDiff(DateInterval.Day, Now, lers("DateLivre")) < Val(Me.tDelaiAff.Text)) And (lers("TypeCde") = "P") Then
                    gImport.Rows(gImport.RowCount - 1).Cells("DateLiv").Style.BackColor = Me.tMsgAff.BackColor
                    gImport.Rows(gImport.RowCount - 1).Cells("TypeCde").Style.BackColor = Me.tMsgAff.BackColor
                End If

                'Meme date que la ligne précédente
                If gImport.Rows(gImport.RowCount - 1).Cells("DateLiv").Value = gImport.Rows(gImport.RowCount - 2).Cells("DateLiv").Value And gImport.RowCount > 1 Then
                    gImport.Rows(gImport.RowCount - 1).Cells("DateLiv").Style.ForeColor = Me.tMsgDate.ForeColor
                    gImport.Rows(gImport.RowCount - 2).Cells("DateLiv").Style.ForeColor = Me.tMsgDate.ForeColor
                End If
            End While

            'controle les Cdes Prev avant la derniere cde ferme
            Dim letype As String = "P"
            For i = Me.gImport.RowCount - 1 To 0 Step -1
                If Nz(Me.gImport.Rows(i).Cells("TypeCde").Value, "") = "" Then letype = "P"
                If Nz(Me.gImport.Rows(i).Cells("TypeCde").Value, "") = "F" Then letype = "F"
                If Nz(Me.gImport.Rows(i).Cells("TypeCde").Value, "") = "P" And letype = "F" Then
                    gImport.Rows(i).Cells("TypeCde").Style.BackColor = Me.tMsgPrev.BackColor
                End If

            Next

            Me.gImport.Visible = True

        Catch ex As Exception

        End Try

    End Sub

    Private Sub F_CtrlPrev_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sSql As String

        Me.WindowState = FormWindowState.Maximized
        sSql = " select S.siteid, S.SiteNom from app.site S inner join app.UserSite U on S.SiteId= U.SiteId   where UserId= " & leUser.Id
        ComboRempli(sSql, Me.lSIte, conSqlEDI)
        Me.dLiv.Value = Now.AddMonths(2)

        My.Settings.Reload()
        Me.tDelaiSaisie.Text = My.Settings.DelaiSaisi
        Me.tDelaiAff.Text = My.Settings.DelaiAfferme

    End Sub

    Private Sub lSIte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lSIte.SelectedIndexChanged
        conSqlERP.Close()
        conSqlERP.Dispose()

        Select Case lSIte.SelectedItem.text
            Case "Soucy" : ConnexionInit("Provider=SQLOLEDB.1;Persist Security Info=True;Password=SilmoMacro;User ID=ZCBN;Server=sqlc2;Database=KTISSOUCY;Persist Security Info=True;", conSqlERP)
            Case "Laxou" : ConnexionInit("Provider=SQLOLEDB.1;Persist Security Info=True;Password=SilmoMacro;User ID=ZCBN;Server=sqlc2;Database=KTISLAXOU;Persist Security Info=True;", conSqlERP)
            Case "Casablanca" : ConnexionInit("Provider=SQLOLEDB.1;Persist Security Info=True;Password=SilmoMacro;User ID=ZCBN;Server=sqlc2;Database=KMTM;Persist Security Info=True;", conSqlERP)
            Case "Montauban", "Toulouse" : ConnexionInit("provider = OraOLEDB.Oracle.1;data source=TOP;User ID=TOPERP;Password=TOPERP", conSqlERP)
        End Select
        Call AfficheCde()
    End Sub

    Private Sub bAfficher_Click(sender As Object, e As EventArgs) Handles bAfficher.Click
        Call AfficheCde()
    End Sub

    Private Sub tCodeClient_TextChanged(sender As Object, e As EventArgs) Handles tCodeClient.TextChanged

    End Sub

    Private Sub tCodeClient_KeyUp(sender As Object, e As KeyEventArgs) Handles tCodeClient.KeyUp, tDelaiAff.KeyUp, tDelaiSaisie.KeyUp, tCodeArticle.KeyUp
        If e.KeyCode = Keys.Enter Then AfficheCde()

    End Sub

    Private Sub tDelaiAff_TextChanged(sender As Object, e As EventArgs) Handles tDelaiAff.TextChanged

    End Sub

    Private Sub bSuppr_Click(sender As Object, e As EventArgs) Handles bSuppr.Click
        Dim sSql As String = ""
        '        Dim d As Date
        Dim StatutLigne As String = ""
        Dim typeBesoin As String = ""
        Dim lesParam As New List(Of SSISParam)
        Dim limport As Integer = -1

        ' ...
        If MsgBox("Supprimer les commandes sélectionnées ?", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question) = MsgBoxResult.Ok Then
            Try
                'Ecrit dans la table Transfert
                For i = 0 To Me.gImport.RowCount - 2

                    With Me.gImport.Rows(i)
                        If Nz(.Cells(0).Value, False) = True Then

                            sSql &= "INSERT INTO CommandeVente_Transfert ( ImportId, DateBesoin, QteBesoin, NumCde_ERP, NumLigne_ERP, DateCde, QteCde, ArtCode_ERP, NumLigne_Prop,DateTransfert, StatutTransfert, CodeClient, StatutAffiche,siteId )" _
                            & " VALUES (" & limport _
                            & ", '" & Nz(.Cells("DateLiv").Value, "") & "', 0" & Txt2sql(Nz(.Cells("QtePTF").Value, "0")) & ", " _
                            & "'" & Nz(.Cells("NumCde").Value, "") & "', '" & Nz(.Cells("NumLigne").Value, "") & "', '" & Nz(.Cells("DateLiv").Value, "") & "', 0" & Txt2sql(Nz(.Cells("QtePTF").Value, "0")) & ", " _
                            & "'" & Nz(.Cells("CodeArt").Value, "") & "', '', '" & Now & "', 'D', '" & .Cells("CodeClient").Value & "', 1," & Me.lSIte.SelectedItem.value & ");"
                        End If
                    End With
                Next i

                SqlDo(sSql, conSqlEDI)


                My.Settings.Reload()
                lesParam.Clear()
                lesParam.Add(New SSISParam("ImportId", limport, "PACKAGE"))
                lesParam.Add(New SSISParam("SiteId", lSIte.SelectedItem.Value, "PACKAGE"))
                lesParam.Add(New SSISParam("UserLogin", leUser.Login, "PACKAGE"))
                SSISexecute(leUser.RepSSIS, "DM_IN_CDV_Integre.dtsx", lesParam, "Ecriture des données -> ERP")


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            AfficheCde()
        End If
    End Sub
End Class


