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
                Ssql = " select * From ( Select Case C.num_cmde NumCde,L.num_ligne NumLigne, Case when nvl(e.id_cmde_ligne,0)=0 then l.qte_total -nvl(l.qte_livre,0) else e.qte_total - nvl(e.qte_livre,0) end  as QtePTF," _
                    & " Case when nvl(e.id_cmde_ligne,0)=0 then e.date_livre  else l.date_livre end  as DateLivre , a.reference ArtNom, case when c.id_type_cmde = 2 then 'P' else 'F' end TypeCde,t_client.raison_sociale CliNom, t_client.code CliCode" _
                    & " From t_cmde_ligne L inner Join t_cmde C on C.id_cmde=l.id_cmde" _
                    & " Left Join t_cmde_cad E on e.id_cmde_ligne=l.id_cmde_ligne  Left Join t_article A on a.id_article=l.id_article" _
                & " Left Join t_type_cmde T on t.id_type_cmde = c.id_type_cmde  Left Join t_client  on t_client.id_client = C.id_client" _
                & " where c.id_company In(1, 2) And  extract( year from  l.date_livre)>2019  And  nvl(l.qte_livre,0) < nvl(l.qte_total,0)  And  NVL(l.b_closed,0)=0 And nvl(c.b_closed,0)=0 ) T" _
                & " where DateLivre <'" & Me.dLiv.Value.ToString("dd/MM/yyyy") & "'"


                If Me.tCodeClient.Text <> "" Then Ssql &= " and CliNom like '%" & Me.tCodeClient.Text & "%'"
                If Me.tCodeArticle.Text <> "" Then Ssql &= " and ArtCode like '%" & Me.tCodeArticle.Text & "%'"
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
            Case "Montauban" : ConnexionInit("provider = OraOLEDB.Oracle.1;data source=TOP;User ID=TOPERP;Password=TOPERP", conSqlERP)
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
End Class


