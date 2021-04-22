Public Class F_Tiers
    Private _tiersId As Integer

    Public Property TiersId() As Integer
        Get
            Return _tiersId
        End Get
        Set(ByVal value As Integer)
            _tiersId = value
        End Set
    End Property

    Sub ListeSiteERP()
        gTiersSiteERP.Rows.Clear()

        Dim leRs As OleDb.OleDbDataReader = SqlLit("SELECT TrsErpId, SiteId, CodeERP FROM app.TiersSiteERP WHERE TiersId = 0" & _tiersId, conSqlEDI)
        While leRs.Read
            gTiersSiteERP.Rows.Add(leRs("TrsErpId"), leRs("SiteId"), leRs("CodeERP"))
        End While
        leRs.Close()

    End Sub

    Sub ListeUser()
        gUser.Rows.Clear()

        Dim leRs As OleDb.OleDbDataReader = SqlLit("SELECT UserId FROM app.TiersUser WHERE TiersId = 0" & _tiersId, conSqlEDI)
        While leRs.Read
            gUser.Rows.Add(leRs("UserId"))
        End While
        leRs.Close()

    End Sub

    Sub ListeTrait()
        gTypeTrait.Rows.Clear()

        Dim leRs As OleDb.OleDbDataReader = SqlLit("SELECT TypeTraitId,TypeTraitNom,Ordre FROM app.TiersTypeTraitement WHERE TiersId = 0" & _tiersId, conSqlEDI)
        While leRs.Read
            gTypeTrait.Rows.Add(leRs("TypeTraitId"), leRs("TypeTraitNom"), leRs("Ordre"))
        End While
        leRs.Close()

    End Sub

    Private Sub F_Tiers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim leRs As OleDb.OleDbDataReader

        Try
            'Site
            Dim dcSite As DataTable = New DataTable

            dcSite.Columns.Add("SiteId", GetType(Integer))
            dcSite.Columns.Add("SiteCode", GetType(String))

            Dim cbxSite As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn With {
                .Name = gTiersSiteERP.Columns(1).Name,
                .HeaderText = gTiersSiteERP.Columns(1).HeaderText
            }
            cbxSite.Items.Clear()

            leRs = SqlLit("SELECT SiteId, SiteCode FROM app.Site", conSqlEDI)

            While leRs.Read()
                dcSite.Rows.Add(leRs("SiteId"), leRs("SiteCode"))
            End While
            leRs.Close()

            cbxSite.DataSource = dcSite
            cbxSite.DisplayMember = "SiteCode"
            cbxSite.ValueMember = "SiteId"

            gTiersSiteERP.Columns.Remove(gTiersSiteERP.Columns(1).Name)
            gTiersSiteERP.Columns.Insert(1, cbxSite)

            'User
            Dim dcUser As DataTable = New DataTable

            dcUser.Columns.Add("UserId", GetType(Integer))
            dcUser.Columns.Add("UserLogin", GetType(String))

            Dim cbxUser As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn With {
                .Name = gUser.Columns(0).Name,
                .HeaderText = gUser.Columns(0).HeaderText
            }
            cbxUser.Items.Clear()

            leRs = SqlLit("SELECT UserId, UserLogin FROM app.Users", conSqlEDI)

            While leRs.Read()
                dcUser.Rows.Add(leRs("UserId"), leRs("UserLogin"))
            End While
            leRs.Close()

            cbxUser.DataSource = dcUser
            cbxUser.DisplayMember = "UserLogin"
            cbxUser.ValueMember = "UserId"

            gUser.Columns.Remove(gUser.Columns(0).Name)
            gUser.Columns.Insert(0, cbxUser)

            'Init value
            FormVide(Me)
            gUser.Rows.Clear()

            If TiersId <> 0 Then
                FormRempli(Me, "SELECT TiersId, TiersNom, TiersLoadFile FROM app.Tiers WHERE TiersId = 0" & _tiersId, conSqlEDI)
                ListeUser()
                ListeSiteERP()
                ListeTrait()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Valider(sender As System.Object, e As System.EventArgs) Handles bOK.Click
        _tiersId = FormEnreg(Me, "app.Tiers", conSqlEDI)

        SqlDo("DELETE FROM app.TiersUser WHERE TiersId = 0" & _tiersId, conSqlEDI)
        For i = 0 To gUser.Rows.Count - 1
            With gUser.Rows(i)
                If Nz(.Cells("UserId").Value, 0) <> 0 Then
                    SqlDo("INSERT INTO app.TiersUser (TiersId, UserId) VALUES (" & _tiersId & ",'" & .Cells("UserId").Value & "')", conSqlEDI)
                End If
            End With
        Next

        SqlDo("DELETE FROM app.TiersSiteERP WHERE TiersId = 0" & _tiersId, conSqlEDI)
        For i = 0 To gTiersSiteERP.Rows.Count - 1
            With gTiersSiteERP.Rows(i)
                If Nz(.Cells("SiteId").Value, 0) <> 0 Then
                    SqlDo("INSERT INTO app.TiersSiteERP (TiersId, SiteId, CodeERP) VALUES (" & _tiersId & ", '" & .Cells("SiteId").Value & "', '" & .Cells("CodeERP").Value & "')", conSqlEDI)
                End If
            End With
        Next

        SqlDo("DELETE FROM app.TiersTypeTraitement WHERE TiersId = 0" & _tiersId, conSqlEDI)
        For i = 0 To gTypeTrait.Rows.Count - 1
            With gTypeTrait.Rows(i)
                If Nz(.Cells("TypeNom").Value, "") <> "" Then
                    SqlDo("INSERT INTO app.TiersTypeTraitement (TiersId,TypeTraitNom,Ordre) VALUES (" & _tiersId & ",'" & .Cells("TypeNom").Value & "','" & .Cells("TypeOrdre").Value & "')", conSqlEDI)
                End If
            End With
        Next

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Annuler(sender As System.Object, e As System.EventArgs) Handles bAnnul.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As System.Object, ByVal e As DataGridViewEditingControlShowingEventArgs) 'Handles gTiersSiteERP.EditingControlShowing
        ' Only for a DatagridComboBoxColumn at ColumnIndex 1.
        If gTiersSiteERP.CurrentCell.ColumnIndex = 1 Then
            Dim combo As ComboBox = CType(e.Control, ComboBox)
            If (combo IsNot Nothing) Then
                ' Remove an existing event-handler, if present, to avoid 
                ' adding multiple handlers when the editing control is reused.
                RemoveHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted)

                ' Add the event handler. 
                AddHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted)
            End If
        End If
    End Sub

    Private Sub ComboBox_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If gTiersSiteERP.CurrentCell.RowIndex = 0 Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class