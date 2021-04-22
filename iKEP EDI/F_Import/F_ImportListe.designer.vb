<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_ImportListe
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_ImportListe))
        Me.TiersMoins = New System.Windows.Forms.Button()
        Me.TiersPLus = New System.Windows.Forms.Button()
        Me.gFichier = New System.Windows.Forms.DataGridView()
        Me.bOK = New System.Windows.Forms.Button()
        Me.bAnnul = New System.Windows.Forms.Button()
        Me.oFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.FicLocal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Extension = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeTraitNom = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ParamImg = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Param = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParamId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gFichier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TiersMoins
        '
        Me.TiersMoins.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TiersMoins.Location = New System.Drawing.Point(761, 50)
        Me.TiersMoins.Name = "TiersMoins"
        Me.TiersMoins.Size = New System.Drawing.Size(32, 32)
        Me.TiersMoins.TabIndex = 9
        Me.TiersMoins.Text = "-"
        Me.TiersMoins.UseVisualStyleBackColor = True
        '
        'TiersPLus
        '
        Me.TiersPLus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TiersPLus.Location = New System.Drawing.Point(761, 12)
        Me.TiersPLus.Name = "TiersPLus"
        Me.TiersPLus.Size = New System.Drawing.Size(32, 32)
        Me.TiersPLus.TabIndex = 8
        Me.TiersPLus.Text = "+"
        Me.TiersPLus.UseVisualStyleBackColor = True
        '
        'gFichier
        '
        Me.gFichier.AllowUserToAddRows = False
        Me.gFichier.AllowUserToDeleteRows = False
        Me.gFichier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gFichier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gFichier.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.gFichier.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gFichier.ColumnHeadersHeight = 30
        Me.gFichier.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FicLocal, Me.Extension, Me.TypeTraitNom, Me.ParamImg, Me.Param, Me.ParamId})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gFichier.DefaultCellStyle = DataGridViewCellStyle1
        Me.gFichier.Location = New System.Drawing.Point(12, 12)
        Me.gFichier.MultiSelect = False
        Me.gFichier.Name = "gFichier"
        Me.gFichier.RowHeadersVisible = False
        Me.gFichier.RowHeadersWidth = 32
        Me.gFichier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gFichier.Size = New System.Drawing.Size(743, 177)
        Me.gFichier.TabIndex = 7
        '
        'bOK
        '
        Me.bOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bOK.Location = New System.Drawing.Point(657, 204)
        Me.bOK.Name = "bOK"
        Me.bOK.Size = New System.Drawing.Size(98, 38)
        Me.bOK.TabIndex = 10
        Me.bOK.Text = "OK"
        Me.bOK.UseVisualStyleBackColor = True
        '
        'bAnnul
        '
        Me.bAnnul.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bAnnul.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bAnnul.Location = New System.Drawing.Point(12, 204)
        Me.bAnnul.Name = "bAnnul"
        Me.bAnnul.Size = New System.Drawing.Size(98, 38)
        Me.bAnnul.TabIndex = 11
        Me.bAnnul.Text = "Annuler"
        Me.bAnnul.UseVisualStyleBackColor = True
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.WindowsApplication1.My.Resources.Resources.Param16_fw
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 254
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "Param16.fw.png")
        Me.ImageList.Images.SetKeyName(1, "Param16vert.fw.png")
        '
        'FicLocal
        '
        Me.FicLocal.FillWeight = 80.0!
        Me.FicLocal.HeaderText = "Fichier"
        Me.FicLocal.Name = "FicLocal"
        Me.FicLocal.ReadOnly = True
        '
        'Extension
        '
        Me.Extension.FillWeight = 10.0!
        Me.Extension.HeaderText = "Extension"
        Me.Extension.Name = "Extension"
        '
        'TypeTraitNom
        '
        Me.TypeTraitNom.FillWeight = 30.0!
        Me.TypeTraitNom.HeaderText = "Type"
        Me.TypeTraitNom.Items.AddRange(New Object() {"Cdes et Prév", "Commandes", "Prévisions"})
        Me.TypeTraitNom.Name = "TypeTraitNom"
        '
        'ParamImg
        '
        Me.ParamImg.FillWeight = 10.0!
        Me.ParamImg.HeaderText = "Param"
        Me.ParamImg.Name = "ParamImg"
        '
        'Param
        '
        Me.Param.HeaderText = "LeParam"
        Me.Param.Name = "Param"
        Me.Param.Visible = False
        '
        'ParamId
        '
        Me.ParamId.HeaderText = "LeParamId"
        Me.ParamId.Name = "ParamId"
        Me.ParamId.Visible = False
        '
        'F_ImportListe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 259)
        Me.Controls.Add(Me.bOK)
        Me.Controls.Add(Me.bAnnul)
        Me.Controls.Add(Me.TiersMoins)
        Me.Controls.Add(Me.TiersPLus)
        Me.Controls.Add(Me.gFichier)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "F_ImportListe"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Imports"
        CType(Me.gFichier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TiersMoins As Button
    Friend WithEvents TiersPLus As Button
    Friend WithEvents gFichier As DataGridView
    Friend WithEvents bOK As Button
    Friend WithEvents bAnnul As Button
    Friend WithEvents oFileDialog As OpenFileDialog
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents ImageList As ImageList
    Friend WithEvents FicLocal As DataGridViewTextBoxColumn
    Friend WithEvents Extension As DataGridViewTextBoxColumn
    Friend WithEvents TypeTraitNom As DataGridViewComboBoxColumn
    Friend WithEvents ParamImg As DataGridViewImageColumn
    Friend WithEvents Param As DataGridViewTextBoxColumn
    Friend WithEvents ParamId As DataGridViewTextBoxColumn
End Class
