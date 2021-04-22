<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Tiers
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.bAnnul = New System.Windows.Forms.Button()
        Me.bOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.tID = New System.Windows.Forms.TextBox()
        Me.gUser = New System.Windows.Forms.DataGridView()
        Me.UserId = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.gTiersSiteERP = New System.Windows.Forms.DataGridView()
        Me.TrsErpId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SiteId = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.CodeERP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.gTypeTrait = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeNom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeOrdre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gTiersSiteERP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gTypeTrait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bAnnul
        '
        Me.bAnnul.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.bAnnul.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bAnnul.Location = New System.Drawing.Point(16, 441)
        Me.bAnnul.Name = "bAnnul"
        Me.bAnnul.Size = New System.Drawing.Size(75, 25)
        Me.bAnnul.TabIndex = 6
        Me.bAnnul.Text = "Annuler"
        Me.bAnnul.UseVisualStyleBackColor = True
        '
        'bOK
        '
        Me.bOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.bOK.Location = New System.Drawing.Point(551, 441)
        Me.bOK.Name = "bOK"
        Me.bOK.Size = New System.Drawing.Size(75, 25)
        Me.bOK.TabIndex = 5
        Me.bOK.Text = "OK"
        Me.bOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nom"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(87, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(231, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Tag = "TiersNom,t"
        '
        'tID
        '
        Me.tID.Location = New System.Drawing.Point(924, 15)
        Me.tID.Name = "tID"
        Me.tID.ReadOnly = True
        Me.tID.Size = New System.Drawing.Size(49, 20)
        Me.tID.TabIndex = 6
        Me.tID.Tag = "TiersId,k"
        '
        'gUser
        '
        Me.gUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gUser.BackgroundColor = System.Drawing.Color.White
        Me.gUser.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gUser.ColumnHeadersHeight = 30
        Me.gUser.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UserId})
        Me.gUser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.gUser.Location = New System.Drawing.Point(16, 63)
        Me.gUser.MultiSelect = False
        Me.gUser.Name = "gUser"
        Me.gUser.RowHeadersWidth = 32
        Me.gUser.Size = New System.Drawing.Size(300, 360)
        Me.gUser.TabIndex = 4
        '
        'UserId
        '
        Me.UserId.HeaderText = "Utilisateur"
        Me.UserId.Name = "UserId"
        Me.UserId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.UserId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'gTiersSiteERP
        '
        Me.gTiersSiteERP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gTiersSiteERP.BackgroundColor = System.Drawing.Color.White
        Me.gTiersSiteERP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gTiersSiteERP.ColumnHeadersHeight = 30
        Me.gTiersSiteERP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TrsErpId, Me.SiteId, Me.CodeERP})
        Me.gTiersSiteERP.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.gTiersSiteERP.Location = New System.Drawing.Point(322, 63)
        Me.gTiersSiteERP.MultiSelect = False
        Me.gTiersSiteERP.Name = "gTiersSiteERP"
        Me.gTiersSiteERP.RowHeadersWidth = 32
        Me.gTiersSiteERP.Size = New System.Drawing.Size(304, 177)
        Me.gTiersSiteERP.TabIndex = 12
        '
        'TrsErpId
        '
        Me.TrsErpId.HeaderText = "TrsEIdrp"
        Me.TrsErpId.Name = "TrsErpId"
        Me.TrsErpId.Visible = False
        '
        'SiteId
        '
        Me.SiteId.HeaderText = "Site"
        Me.SiteId.Name = "SiteId"
        Me.SiteId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SiteId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'CodeERP
        '
        Me.CodeERP.HeaderText = "Code ERP"
        Me.CodeERP.Name = "CodeERP"
        Me.CodeERP.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(343, 15)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(132, 17)
        Me.CheckBox1.TabIndex = 15
        Me.CheckBox1.Tag = "TiersLoadFile,b"
        Me.CheckBox1.Text = "Chargement par fichier"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'gTypeTrait
        '
        Me.gTypeTrait.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gTypeTrait.BackgroundColor = System.Drawing.Color.White
        Me.gTypeTrait.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gTypeTrait.ColumnHeadersHeight = 30
        Me.gTypeTrait.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.TypeNom, Me.TypeOrdre})
        Me.gTypeTrait.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.gTypeTrait.Location = New System.Drawing.Point(322, 246)
        Me.gTypeTrait.MultiSelect = False
        Me.gTypeTrait.Name = "gTypeTrait"
        Me.gTypeTrait.RowHeadersWidth = 32
        Me.gTypeTrait.Size = New System.Drawing.Size(304, 177)
        Me.gTypeTrait.TabIndex = 16
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "TTTId"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'TypeNom
        '
        Me.TypeNom.HeaderText = "Type Nom"
        Me.TypeNom.Name = "TypeNom"
        '
        'TypeOrdre
        '
        Me.TypeOrdre.FillWeight = 30.0!
        Me.TypeOrdre.HeaderText = "Ordre"
        Me.TypeOrdre.Name = "TypeOrdre"
        '
        'F_Tiers
        '
        Me.AcceptButton = Me.bOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.bAnnul
        Me.ClientSize = New System.Drawing.Size(640, 478)
        Me.Controls.Add(Me.gTypeTrait)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.gTiersSiteERP)
        Me.Controls.Add(Me.gUser)
        Me.Controls.Add(Me.tID)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bOK)
        Me.Controls.Add(Me.bAnnul)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "F_Tiers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tiers"
        CType(Me.gUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gTiersSiteERP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gTypeTrait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bAnnul As System.Windows.Forms.Button
    Friend WithEvents bOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents tID As System.Windows.Forms.TextBox
    Friend WithEvents gUser As System.Windows.Forms.DataGridView
    Friend WithEvents gTiersSiteERP As System.Windows.Forms.DataGridView
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents UserId As DataGridViewComboBoxColumn
    Friend WithEvents TrsErpId As DataGridViewTextBoxColumn
    Friend WithEvents SiteId As DataGridViewComboBoxColumn
    Friend WithEvents CodeERP As DataGridViewTextBoxColumn
    Friend WithEvents gTypeTrait As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents TypeNom As DataGridViewTextBoxColumn
    Friend WithEvents TypeOrdre As DataGridViewTextBoxColumn
End Class
