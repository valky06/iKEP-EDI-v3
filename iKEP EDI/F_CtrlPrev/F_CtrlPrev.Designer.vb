<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_CtrlPrev
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dLiv = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tCodeClient = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tDelaiAff = New System.Windows.Forms.TextBox()
        Me.bAfficher = New System.Windows.Forms.Button()
        Me.gImport = New System.Windows.Forms.DataGridView()
        Me.SelContrat = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CodeClient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomClient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodeArt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateLiv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeCde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumCde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumLigne = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtePTF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCrea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tDelaiSaisie = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lSIte = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tCodeArticle = New System.Windows.Forms.TextBox()
        Me.tMsgSaisie = New System.Windows.Forms.TextBox()
        Me.tMsgAff = New System.Windows.Forms.TextBox()
        Me.tMsgDate = New System.Windows.Forms.TextBox()
        Me.tMsgPrev = New System.Windows.Forms.TextBox()
        CType(Me.gImport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dLiv
        '
        Me.dLiv.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dLiv.Location = New System.Drawing.Point(110, 40)
        Me.dLiv.Name = "dLiv"
        Me.dLiv.Size = New System.Drawing.Size(92, 20)
        Me.dLiv.TabIndex = 63
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(253, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "Code Client"
        '
        'tCodeClient
        '
        Me.tCodeClient.Location = New System.Drawing.Point(323, 11)
        Me.tCodeClient.Name = "tCodeClient"
        Me.tCodeClient.Size = New System.Drawing.Size(128, 20)
        Me.tCodeClient.TabIndex = 58
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(472, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Délai Affermissement"
        '
        'tDelaiAff
        '
        Me.tDelaiAff.BackColor = System.Drawing.Color.White
        Me.tDelaiAff.Location = New System.Drawing.Point(583, 11)
        Me.tDelaiAff.Name = "tDelaiAff"
        Me.tDelaiAff.Size = New System.Drawing.Size(43, 20)
        Me.tDelaiAff.TabIndex = 57
        Me.tDelaiAff.Text = "30"
        Me.tDelaiAff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bAfficher
        '
        Me.bAfficher.Image = Global.WindowsApplication1.My.Resources.Resources.filtre_fw
        Me.bAfficher.Location = New System.Drawing.Point(681, 12)
        Me.bAfficher.Name = "bAfficher"
        Me.bAfficher.Size = New System.Drawing.Size(111, 45)
        Me.bAfficher.TabIndex = 60
        Me.bAfficher.Text = "Filtrer"
        Me.bAfficher.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bAfficher.UseVisualStyleBackColor = True
        '
        'gImport
        '
        Me.gImport.AllowUserToAddRows = False
        Me.gImport.AllowUserToDeleteRows = False
        Me.gImport.AllowUserToResizeRows = False
        Me.gImport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gImport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gImport.BackgroundColor = System.Drawing.SystemColors.Control
        Me.gImport.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gImport.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gImport.ColumnHeadersHeight = 38
        Me.gImport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelContrat, Me.CodeClient, Me.NomClient, Me.CodeArt, Me.DateLiv, Me.TypeCde, Me.NumCde, Me.NumLigne, Me.QtePTF, Me.DateCrea})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gImport.DefaultCellStyle = DataGridViewCellStyle6
        Me.gImport.Location = New System.Drawing.Point(12, 66)
        Me.gImport.Name = "gImport"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gImport.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.gImport.RowHeadersVisible = False
        Me.gImport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gImport.ShowCellErrors = False
        Me.gImport.ShowCellToolTips = False
        Me.gImport.ShowEditingIcon = False
        Me.gImport.ShowRowErrors = False
        Me.gImport.Size = New System.Drawing.Size(1201, 397)
        Me.gImport.TabIndex = 59
        Me.gImport.TabStop = False
        '
        'SelContrat
        '
        Me.SelContrat.FillWeight = 15.0!
        Me.SelContrat.HeaderText = "Sel"
        Me.SelContrat.Name = "SelContrat"
        Me.SelContrat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'CodeClient
        '
        Me.CodeClient.FillWeight = 30.0!
        Me.CodeClient.HeaderText = "Code Client"
        Me.CodeClient.Name = "CodeClient"
        Me.CodeClient.ReadOnly = True
        Me.CodeClient.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NomClient
        '
        Me.NomClient.HeaderText = "Client"
        Me.NomClient.Name = "NomClient"
        '
        'CodeArt
        '
        Me.CodeArt.FillWeight = 40.0!
        Me.CodeArt.HeaderText = "Article KEP"
        Me.CodeArt.Name = "CodeArt"
        Me.CodeArt.ReadOnly = True
        Me.CodeArt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DateLiv
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        Me.DateLiv.DefaultCellStyle = DataGridViewCellStyle2
        Me.DateLiv.FillWeight = 30.0!
        Me.DateLiv.HeaderText = "Date Liv"
        Me.DateLiv.Name = "DateLiv"
        '
        'TypeCde
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TypeCde.DefaultCellStyle = DataGridViewCellStyle3
        Me.TypeCde.FillWeight = 15.0!
        Me.TypeCde.HeaderText = "Type Cde"
        Me.TypeCde.Name = "TypeCde"
        Me.TypeCde.ReadOnly = True
        Me.TypeCde.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NumCde
        '
        Me.NumCde.FillWeight = 30.0!
        Me.NumCde.HeaderText = "N°Cde"
        Me.NumCde.Name = "NumCde"
        Me.NumCde.ReadOnly = True
        Me.NumCde.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NumLigne
        '
        Me.NumLigne.FillWeight = 20.0!
        Me.NumLigne.HeaderText = "N° Ligne"
        Me.NumLigne.Name = "NumLigne"
        Me.NumLigne.ReadOnly = True
        Me.NumLigne.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'QtePTF
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.QtePTF.DefaultCellStyle = DataGridViewCellStyle4
        Me.QtePTF.FillWeight = 25.0!
        Me.QtePTF.HeaderText = "Qté PTF"
        Me.QtePTF.Name = "QtePTF"
        Me.QtePTF.ReadOnly = True
        Me.QtePTF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DateCrea
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "d"
        Me.DateCrea.DefaultCellStyle = DataGridViewCellStyle5
        Me.DateCrea.FillWeight = 30.0!
        Me.DateCrea.HeaderText = "Date Saisie"
        Me.DateCrea.Name = "DateCrea"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Livraison avant le "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(472, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Délai Saisie"
        '
        'tDelaiSaisie
        '
        Me.tDelaiSaisie.BackColor = System.Drawing.Color.White
        Me.tDelaiSaisie.Location = New System.Drawing.Point(583, 35)
        Me.tDelaiSaisie.Name = "tDelaiSaisie"
        Me.tDelaiSaisie.Size = New System.Drawing.Size(43, 20)
        Me.tDelaiSaisie.TabIndex = 65
        Me.tDelaiSaisie.Text = "5"
        Me.tDelaiSaisie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(632, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "Jours"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(632, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Jours"
        '
        'lSIte
        '
        Me.lSIte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lSIte.FormattingEnabled = True
        Me.lSIte.Location = New System.Drawing.Point(43, 11)
        Me.lSIte.Name = "lSIte"
        Me.lSIte.Size = New System.Drawing.Size(159, 21)
        Me.lSIte.TabIndex = 69
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 13)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "Site"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(253, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "Code Article"
        '
        'tCodeArticle
        '
        Me.tCodeArticle.Location = New System.Drawing.Point(323, 40)
        Me.tCodeArticle.Name = "tCodeArticle"
        Me.tCodeArticle.Size = New System.Drawing.Size(128, 20)
        Me.tCodeArticle.TabIndex = 71
        '
        'tMsgSaisie
        '
        Me.tMsgSaisie.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tMsgSaisie.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tMsgSaisie.Location = New System.Drawing.Point(608, 469)
        Me.tMsgSaisie.Name = "tMsgSaisie"
        Me.tMsgSaisie.Size = New System.Drawing.Size(137, 20)
        Me.tMsgSaisie.TabIndex = 74
        Me.tMsgSaisie.Text = "date saisie < Délai Saisie"
        Me.tMsgSaisie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tMsgAff
        '
        Me.tMsgAff.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tMsgAff.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tMsgAff.Location = New System.Drawing.Point(763, 469)
        Me.tMsgAff.Name = "tMsgAff"
        Me.tMsgAff.Size = New System.Drawing.Size(137, 20)
        Me.tMsgAff.TabIndex = 73
        Me.tMsgAff.Text = "date liv.  < délai Afferm."
        Me.tMsgAff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tMsgDate
        '
        Me.tMsgDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tMsgDate.BackColor = System.Drawing.Color.White
        Me.tMsgDate.ForeColor = System.Drawing.Color.Red
        Me.tMsgDate.Location = New System.Drawing.Point(911, 469)
        Me.tMsgDate.Name = "tMsgDate"
        Me.tMsgDate.Size = New System.Drawing.Size(143, 20)
        Me.tMsgDate.TabIndex = 76
        Me.tMsgDate.Text = "Dates identiques"
        Me.tMsgDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tMsgPrev
        '
        Me.tMsgPrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tMsgPrev.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tMsgPrev.Location = New System.Drawing.Point(1070, 469)
        Me.tMsgPrev.Name = "tMsgPrev"
        Me.tMsgPrev.Size = New System.Drawing.Size(143, 20)
        Me.tMsgPrev.TabIndex = 75
        Me.tMsgPrev.Text = "Prév avant Ferme"
        Me.tMsgPrev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'F_CtrlPrev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1225, 497)
        Me.ControlBox = False
        Me.Controls.Add(Me.tMsgDate)
        Me.Controls.Add(Me.tMsgPrev)
        Me.Controls.Add(Me.tMsgSaisie)
        Me.Controls.Add(Me.tMsgAff)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tCodeArticle)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lSIte)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tDelaiSaisie)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dLiv)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tCodeClient)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tDelaiAff)
        Me.Controls.Add(Me.bAfficher)
        Me.Controls.Add(Me.gImport)
        Me.Name = "F_CtrlPrev"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Contrôle Prévisions"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gImport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dLiv As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents tCodeClient As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tDelaiAff As TextBox
    Friend WithEvents bAfficher As Button
    Friend WithEvents gImport As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tDelaiSaisie As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lSIte As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tCodeArticle As TextBox
    Friend WithEvents SelContrat As DataGridViewCheckBoxColumn
    Friend WithEvents CodeClient As DataGridViewTextBoxColumn
    Friend WithEvents NomClient As DataGridViewTextBoxColumn
    Friend WithEvents CodeArt As DataGridViewTextBoxColumn
    Friend WithEvents DateLiv As DataGridViewTextBoxColumn
    Friend WithEvents TypeCde As DataGridViewTextBoxColumn
    Friend WithEvents NumCde As DataGridViewTextBoxColumn
    Friend WithEvents NumLigne As DataGridViewTextBoxColumn
    Friend WithEvents QtePTF As DataGridViewTextBoxColumn
    Friend WithEvents DateCrea As DataGridViewTextBoxColumn
    Friend WithEvents tMsgSaisie As TextBox
    Friend WithEvents tMsgAff As TextBox
    Friend WithEvents tMsgDate As TextBox
    Friend WithEvents tMsgPrev As TextBox
End Class
