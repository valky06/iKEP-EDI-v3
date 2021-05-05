<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Afferme
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tClient = New System.Windows.Forms.TextBox()
        Me.lblUniteHorizon = New System.Windows.Forms.Label()
        Me.lblHorizon = New System.Windows.Forms.Label()
        Me.tHorizon = New System.Windows.Forms.TextBox()
        Me.gAfferme = New System.Windows.Forms.DataGridView()
        Me.Sel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SiteCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Client = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumCde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumLigne = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Article = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumCdeEDI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumLigneEDI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QteCde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodeClient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TmoJ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSel = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPtoF = New System.Windows.Forms.Button()
        Me.bAfficher = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tArticle = New System.Windows.Forms.TextBox()
        Me.lSiteAfferm = New System.Windows.Forms.ComboBox()
        Me.bTmo = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnChargPrev = New System.Windows.Forms.Button()
        Me.bRetard = New System.Windows.Forms.CheckBox()
        CType(Me.gAfferme, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tClient
        '
        Me.tClient.Location = New System.Drawing.Point(594, 11)
        Me.tClient.Name = "tClient"
        Me.tClient.Size = New System.Drawing.Size(113, 20)
        Me.tClient.TabIndex = 1
        '
        'lblUniteHorizon
        '
        Me.lblUniteHorizon.AutoSize = True
        Me.lblUniteHorizon.Location = New System.Drawing.Point(481, 36)
        Me.lblUniteHorizon.Name = "lblUniteHorizon"
        Me.lblUniteHorizon.Size = New System.Drawing.Size(38, 13)
        Me.lblUniteHorizon.TabIndex = 39
        Me.lblUniteHorizon.Text = "Jour(s)"
        '
        'lblHorizon
        '
        Me.lblHorizon.AutoSize = True
        Me.lblHorizon.Location = New System.Drawing.Point(380, 36)
        Me.lblHorizon.Name = "lblHorizon"
        Me.lblHorizon.Size = New System.Drawing.Size(53, 13)
        Me.lblHorizon.TabIndex = 38
        Me.lblHorizon.Text = "Décalage"
        '
        'tHorizon
        '
        Me.tHorizon.Location = New System.Drawing.Point(439, 33)
        Me.tHorizon.Name = "tHorizon"
        Me.tHorizon.Size = New System.Drawing.Size(36, 20)
        Me.tHorizon.TabIndex = 0
        Me.tHorizon.Text = "0"
        Me.tHorizon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gAfferme
        '
        Me.gAfferme.AllowUserToAddRows = False
        Me.gAfferme.AllowUserToDeleteRows = False
        Me.gAfferme.AllowUserToResizeRows = False
        Me.gAfferme.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gAfferme.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gAfferme.BackgroundColor = System.Drawing.SystemColors.Control
        Me.gAfferme.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gAfferme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gAfferme.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sel, Me.SiteCode, Me.Client, Me.NumCde, Me.NumLigne, Me.Article, Me.NumCdeEDI, Me.NumLigneEDI, Me.DateCde, Me.QteCde, Me.CodeClient, Me.TmoJ})
        Me.gAfferme.Location = New System.Drawing.Point(12, 64)
        Me.gAfferme.MultiSelect = False
        Me.gAfferme.Name = "gAfferme"
        Me.gAfferme.RowHeadersVisible = False
        Me.gAfferme.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gAfferme.Size = New System.Drawing.Size(1287, 462)
        Me.gAfferme.TabIndex = 33
        '
        'Sel
        '
        Me.Sel.FillWeight = 15.0!
        Me.Sel.HeaderText = "Sel"
        Me.Sel.Name = "Sel"
        Me.Sel.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'SiteCode
        '
        Me.SiteCode.FillWeight = 20.0!
        Me.SiteCode.HeaderText = "Site"
        Me.SiteCode.Name = "SiteCode"
        '
        'Client
        '
        Me.Client.HeaderText = "Client"
        Me.Client.Name = "Client"
        Me.Client.ReadOnly = True
        '
        'NumCde
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NumCde.DefaultCellStyle = DataGridViewCellStyle5
        Me.NumCde.FillWeight = 30.0!
        Me.NumCde.HeaderText = "N°Cde"
        Me.NumCde.Name = "NumCde"
        Me.NumCde.ReadOnly = True
        '
        'NumLigne
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NumLigne.DefaultCellStyle = DataGridViewCellStyle6
        Me.NumLigne.FillWeight = 20.0!
        Me.NumLigne.HeaderText = "Ligne"
        Me.NumLigne.Name = "NumLigne"
        Me.NumLigne.ReadOnly = True
        Me.NumLigne.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Article
        '
        Me.Article.FillWeight = 80.0!
        Me.Article.HeaderText = "Article"
        Me.Article.Name = "Article"
        Me.Article.ReadOnly = True
        '
        'NumCdeEDI
        '
        Me.NumCdeEDI.HeaderText = "Commande EDI"
        Me.NumCdeEDI.Name = "NumCdeEDI"
        '
        'NumLigneEDI
        '
        Me.NumLigneEDI.FillWeight = 20.0!
        Me.NumLigneEDI.HeaderText = "Ligne EDI"
        Me.NumLigneEDI.Name = "NumLigneEDI"
        '
        'DateCde
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Format = "d"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.DateCde.DefaultCellStyle = DataGridViewCellStyle7
        Me.DateCde.FillWeight = 30.0!
        Me.DateCde.HeaderText = "Date Cde"
        Me.DateCde.Name = "DateCde"
        Me.DateCde.ReadOnly = True
        Me.DateCde.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'QteCde
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.QteCde.DefaultCellStyle = DataGridViewCellStyle8
        Me.QteCde.FillWeight = 30.0!
        Me.QteCde.HeaderText = "Qté Totale"
        Me.QteCde.Name = "QteCde"
        Me.QteCde.ReadOnly = True
        '
        'CodeClient
        '
        Me.CodeClient.HeaderText = "CodeClient"
        Me.CodeClient.Name = "CodeClient"
        Me.CodeClient.Visible = False
        '
        'TmoJ
        '
        Me.TmoJ.HeaderText = "TMO"
        Me.TmoJ.Name = "TmoJ"
        Me.TmoJ.Visible = False
        '
        'cSel
        '
        Me.cSel.AutoSize = True
        Me.cSel.Location = New System.Drawing.Point(13, 41)
        Me.cSel.Name = "cSel"
        Me.cSel.Size = New System.Drawing.Size(48, 17)
        Me.cSel.TabIndex = 4
        Me.cSel.Text = "Tout"
        Me.cSel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(555, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Client"
        '
        'btnPtoF
        '
        Me.btnPtoF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPtoF.Image = Global.WindowsApplication1.My.Resources.Resources.bAfferme_fw
        Me.btnPtoF.Location = New System.Drawing.Point(1175, 12)
        Me.btnPtoF.Name = "btnPtoF"
        Me.btnPtoF.Size = New System.Drawing.Size(124, 42)
        Me.btnPtoF.TabIndex = 5
        Me.btnPtoF.Text = "Prév > Ferme"
        Me.btnPtoF.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnPtoF.UseVisualStyleBackColor = True
        '
        'bAfficher
        '
        Me.bAfficher.Image = Global.WindowsApplication1.My.Resources.Resources.filtre_fw
        Me.bAfficher.Location = New System.Drawing.Point(809, 11)
        Me.bAfficher.Name = "bAfficher"
        Me.bAfficher.Size = New System.Drawing.Size(134, 42)
        Me.bAfficher.TabIndex = 3
        Me.bAfficher.Text = "Filtrer"
        Me.bAfficher.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bAfficher.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(552, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Article"
        '
        'tArticle
        '
        Me.tArticle.Location = New System.Drawing.Point(594, 33)
        Me.tArticle.Name = "tArticle"
        Me.tArticle.Size = New System.Drawing.Size(113, 20)
        Me.tArticle.TabIndex = 2
        '
        'lSiteAfferm
        '
        Me.lSiteAfferm.FormattingEnabled = True
        Me.lSiteAfferm.Location = New System.Drawing.Point(64, 7)
        Me.lSiteAfferm.Name = "lSiteAfferm"
        Me.lSiteAfferm.Size = New System.Drawing.Size(121, 21)
        Me.lSiteAfferm.TabIndex = 47
        '
        'bTmo
        '
        Me.bTmo.AutoSize = True
        Me.bTmo.Location = New System.Drawing.Point(384, 10)
        Me.bTmo.Name = "bTmo"
        Me.bTmo.Size = New System.Drawing.Size(50, 17)
        Me.bTmo.TabIndex = 48
        Me.bTmo.Text = "TMO"
        Me.bTmo.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Site"
        '
        'btnChargPrev
        '
        Me.btnChargPrev.Image = Global.WindowsApplication1.My.Resources.Resources.bimport_fw
        Me.btnChargPrev.Location = New System.Drawing.Point(191, 7)
        Me.btnChargPrev.Name = "btnChargPrev"
        Me.btnChargPrev.Size = New System.Drawing.Size(134, 42)
        Me.btnChargPrev.TabIndex = 50
        Me.btnChargPrev.Text = "Chargement"
        Me.btnChargPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnChargPrev.UseVisualStyleBackColor = True
        '
        'bRetard
        '
        Me.bRetard.AutoSize = True
        Me.bRetard.Location = New System.Drawing.Point(461, 9)
        Me.bRetard.Name = "bRetard"
        Me.bRetard.Size = New System.Drawing.Size(58, 17)
        Me.bRetard.TabIndex = 51
        Me.bRetard.Text = "Retard"
        Me.bRetard.UseVisualStyleBackColor = True
        '
        'F_Afferme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1311, 538)
        Me.ControlBox = False
        Me.Controls.Add(Me.bRetard)
        Me.Controls.Add(Me.btnChargPrev)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.bTmo)
        Me.Controls.Add(Me.lSiteAfferm)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tArticle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPtoF)
        Me.Controls.Add(Me.cSel)
        Me.Controls.Add(Me.tClient)
        Me.Controls.Add(Me.lblUniteHorizon)
        Me.Controls.Add(Me.lblHorizon)
        Me.Controls.Add(Me.tHorizon)
        Me.Controls.Add(Me.bAfficher)
        Me.Controls.Add(Me.gAfferme)
        Me.Name = "F_Afferme"
        Me.Text = "SIlog - Commandes Prévisionnelles"
        CType(Me.gAfferme, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tClient As TextBox
    Friend WithEvents lblUniteHorizon As Label
    Friend WithEvents lblHorizon As Label
    Friend WithEvents tHorizon As TextBox
    Friend WithEvents bAfficher As Button
    Friend WithEvents gAfferme As DataGridView
    Friend WithEvents cSel As CheckBox
    Friend WithEvents btnPtoF As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tArticle As TextBox
    Friend WithEvents lSiteAfferm As ComboBox
    Friend WithEvents bTmo As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Sel As DataGridViewCheckBoxColumn
    Friend WithEvents SiteCode As DataGridViewTextBoxColumn
    Friend WithEvents Client As DataGridViewTextBoxColumn
    Friend WithEvents NumCde As DataGridViewTextBoxColumn
    Friend WithEvents NumLigne As DataGridViewTextBoxColumn
    Friend WithEvents Article As DataGridViewTextBoxColumn
    Friend WithEvents NumCdeEDI As DataGridViewTextBoxColumn
    Friend WithEvents NumLigneEDI As DataGridViewTextBoxColumn
    Friend WithEvents DateCde As DataGridViewTextBoxColumn
    Friend WithEvents QteCde As DataGridViewTextBoxColumn
    Friend WithEvents CodeClient As DataGridViewTextBoxColumn
    Friend WithEvents TmoJ As DataGridViewTextBoxColumn
    Friend WithEvents btnChargPrev As Button
    Friend WithEvents bRetard As CheckBox
End Class
