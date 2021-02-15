<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F_Users
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.bAnnul = New System.Windows.Forms.Button()
        Me.bOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.tID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cDroit = New System.Windows.Forms.ComboBox()
        Me.cConfig = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SelOld = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SiteCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SIteId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gSite = New System.Windows.Forms.DataGridView()
        CType(Me.gSite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bAnnul
        '
        Me.bAnnul.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bAnnul.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bAnnul.Location = New System.Drawing.Point(18, 304)
        Me.bAnnul.Name = "bAnnul"
        Me.bAnnul.Size = New System.Drawing.Size(75, 25)
        Me.bAnnul.TabIndex = 5
        Me.bAnnul.Text = "Annuler"
        Me.bAnnul.UseVisualStyleBackColor = True
        '
        'bOK
        '
        Me.bOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bOK.Location = New System.Drawing.Point(191, 304)
        Me.bOK.Name = "bOK"
        Me.bOK.Size = New System.Drawing.Size(75, 25)
        Me.bOK.TabIndex = 4
        Me.bOK.Text = "OK"
        Me.bOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Login"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(91, 30)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(178, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Tag = "UserLogin,t"
        '
        'tID
        '
        Me.tID.Enabled = False
        Me.tID.Location = New System.Drawing.Point(246, 4)
        Me.tID.Name = "tID"
        Me.tID.ReadOnly = True
        Me.tID.Size = New System.Drawing.Size(23, 20)
        Me.tID.TabIndex = 6
        Me.tID.Tag = "UserId,k"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Droit"
        '
        'cDroit
        '
        Me.cDroit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cDroit.FormattingEnabled = True
        Me.cDroit.Location = New System.Drawing.Point(91, 56)
        Me.cDroit.Name = "cDroit"
        Me.cDroit.Size = New System.Drawing.Size(178, 21)
        Me.cDroit.TabIndex = 3
        Me.cDroit.Tag = "Droit,n"
        '
        'cConfig
        '
        Me.cConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cConfig.FormattingEnabled = True
        Me.cConfig.Location = New System.Drawing.Point(91, 83)
        Me.cConfig.Name = "cConfig"
        Me.cConfig.Size = New System.Drawing.Size(178, 21)
        Me.cConfig.TabIndex = 9
        Me.cConfig.Tag = "CfgId,n"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Config"
        '
        'SelOld
        '
        Me.SelOld.HeaderText = "SelOld"
        Me.SelOld.Name = "SelOld"
        Me.SelOld.Visible = False
        '
        'Sel
        '
        Me.Sel.FillWeight = 20.0!
        Me.Sel.HeaderText = "Sel"
        Me.Sel.Name = "Sel"
        '
        'SiteCode
        '
        Me.SiteCode.HeaderText = "Site"
        Me.SiteCode.Name = "SiteCode"
        Me.SiteCode.ReadOnly = True
        Me.SiteCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SiteCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SIteId
        '
        Me.SIteId.HeaderText = "SiteId"
        Me.SIteId.Name = "SIteId"
        Me.SIteId.Visible = False
        '
        'gSite
        '
        Me.gSite.AllowUserToAddRows = False
        Me.gSite.AllowUserToDeleteRows = False
        Me.gSite.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gSite.BackgroundColor = System.Drawing.Color.White
        Me.gSite.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gSite.ColumnHeadersHeight = 30
        Me.gSite.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SIteId, Me.SiteCode, Me.Sel, Me.SelOld})
        Me.gSite.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.gSite.Location = New System.Drawing.Point(20, 110)
        Me.gSite.MultiSelect = False
        Me.gSite.Name = "gSite"
        Me.gSite.RowHeadersVisible = False
        Me.gSite.RowHeadersWidth = 32
        Me.gSite.Size = New System.Drawing.Size(249, 177)
        Me.gSite.TabIndex = 11
        '
        'F_Users
        '
        Me.AcceptButton = Me.bOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.bAnnul
        Me.ClientSize = New System.Drawing.Size(283, 348)
        Me.Controls.Add(Me.gSite)
        Me.Controls.Add(Me.cConfig)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cDroit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tID)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bOK)
        Me.Controls.Add(Me.bAnnul)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "F_Users"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Utilisateur"
        CType(Me.gSite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bAnnul As System.Windows.Forms.Button
    Friend WithEvents bOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents tID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cDroit As System.Windows.Forms.ComboBox
    Friend WithEvents cConfig As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents SelOld As DataGridViewTextBoxColumn
    Friend WithEvents Sel As DataGridViewCheckBoxColumn
    Friend WithEvents SiteCode As DataGridViewTextBoxColumn
    Friend WithEvents SIteId As DataGridViewTextBoxColumn
    Friend WithEvents gSite As DataGridView
End Class
