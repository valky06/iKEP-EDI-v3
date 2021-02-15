<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F_ImportParam
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    '<System.Diagnostics.DebuggerNonUserCode()>
    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '    Try
    '        If disposing AndAlso components IsNot Nothing Then
    '            components.Dispose()
    '        End If
    '    Finally
    '        MyBase.Dispose(disposing)
    '    End Try
    'End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.bOK = New System.Windows.Forms.Button()
        Me.bAnnul = New System.Windows.Forms.Button()
        Me.oFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.lblNumLigneEntete = New System.Windows.Forms.Label()
        Me.tNumLigneEntete = New System.Windows.Forms.TextBox()
        Me.lblSeparateurColonne = New System.Windows.Forms.Label()
        Me.lblOnglet = New System.Windows.Forms.Label()
        Me.cSheet = New System.Windows.Forms.ComboBox()
        Me.cDelimiter = New System.Windows.Forms.ComboBox()
        Me.oMapping = New System.Windows.Forms.TabPage()
        Me.tCommentaire = New System.Windows.Forms.TextBox()
        Me.tDateEmisPrg = New System.Windows.Forms.TextBox()
        Me.tArtDesc = New System.Windows.Forms.TextBox()
        Me.tLieuLivraison = New System.Windows.Forms.TextBox()
        Me.tPrixUnitaire = New System.Windows.Forms.TextBox()
        Me.tDevise = New System.Windows.Forms.TextBox()
        Me.tCodeClient = New System.Windows.Forms.TextBox()
        Me.tUnite = New System.Windows.Forms.TextBox()
        Me.tTypeBesoin = New System.Windows.Forms.TextBox()
        Me.tNumLigne = New System.Windows.Forms.TextBox()
        Me.tNumCde = New System.Windows.Forms.TextBox()
        Me.tDateBesoin = New System.Windows.Forms.TextBox()
        Me.tQteBesoin = New System.Windows.Forms.TextBox()
        Me.tArtRefClient = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.ComboBox8 = New System.Windows.Forms.ComboBox()
        Me.ComboBox10 = New System.Windows.Forms.ComboBox()
        Me.ComboBox11 = New System.Windows.Forms.ComboBox()
        Me.ComboBox12 = New System.Windows.Forms.ComboBox()
        Me.ComboBox13 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cDateDem = New System.Windows.Forms.ComboBox()
        Me.cQte = New System.Windows.Forms.ComboBox()
        Me.cArtCli = New System.Windows.Forms.ComboBox()
        Me.lblDateDem = New System.Windows.Forms.Label()
        Me.lblQte = New System.Windows.Forms.Label()
        Me.lblArtCli = New System.Windows.Forms.Label()
        Me.tabMapping = New System.Windows.Forms.TabControl()
        Me.gTypeCSV = New System.Windows.Forms.GroupBox()
        Me.gTypeXLS = New System.Windows.Forms.GroupBox()
        Me.oMapping.SuspendLayout()
        Me.tabMapping.SuspendLayout()
        Me.gTypeCSV.SuspendLayout()
        Me.gTypeXLS.SuspendLayout()
        Me.SuspendLayout()
        '
        'bOK
        '
        Me.bOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bOK.Enabled = False
        Me.bOK.Location = New System.Drawing.Point(501, 576)
        Me.bOK.Name = "bOK"
        Me.bOK.Size = New System.Drawing.Size(98, 31)
        Me.bOK.TabIndex = 10
        Me.bOK.Text = "OK"
        Me.bOK.UseVisualStyleBackColor = True
        '
        'bAnnul
        '
        Me.bAnnul.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bAnnul.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bAnnul.Location = New System.Drawing.Point(12, 576)
        Me.bAnnul.Name = "bAnnul"
        Me.bAnnul.Size = New System.Drawing.Size(98, 31)
        Me.bAnnul.TabIndex = 11
        Me.bAnnul.Text = "Annuler"
        Me.bAnnul.UseVisualStyleBackColor = True
        '
        'lblFile
        '
        Me.lblFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFile.ForeColor = System.Drawing.Color.Maroon
        Me.lblFile.Location = New System.Drawing.Point(12, 9)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(587, 29)
        Me.lblFile.TabIndex = 13
        Me.lblFile.Text = "..."
        '
        'lblNumLigneEntete
        '
        Me.lblNumLigneEntete.AutoSize = True
        Me.lblNumLigneEntete.Location = New System.Drawing.Point(10, 23)
        Me.lblNumLigneEntete.Name = "lblNumLigneEntete"
        Me.lblNumLigneEntete.Size = New System.Drawing.Size(73, 13)
        Me.lblNumLigneEntete.TabIndex = 14
        Me.lblNumLigneEntete.Text = "n°ligne Entête"
        '
        'tNumLigneEntete
        '
        Me.tNumLigneEntete.Location = New System.Drawing.Point(103, 20)
        Me.tNumLigneEntete.Name = "tNumLigneEntete"
        Me.tNumLigneEntete.Size = New System.Drawing.Size(32, 20)
        Me.tNumLigneEntete.TabIndex = 15
        Me.tNumLigneEntete.Text = "1"
        Me.tNumLigneEntete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSeparateurColonne
        '
        Me.lblSeparateurColonne.AutoSize = True
        Me.lblSeparateurColonne.Location = New System.Drawing.Point(6, 23)
        Me.lblSeparateurColonne.Name = "lblSeparateurColonne"
        Me.lblSeparateurColonne.Size = New System.Drawing.Size(101, 13)
        Me.lblSeparateurColonne.TabIndex = 18
        Me.lblSeparateurColonne.Text = "Séparateur Colonne"
        '
        'lblOnglet
        '
        Me.lblOnglet.AutoSize = True
        Me.lblOnglet.Location = New System.Drawing.Point(145, 22)
        Me.lblOnglet.Name = "lblOnglet"
        Me.lblOnglet.Size = New System.Drawing.Size(38, 13)
        Me.lblOnglet.TabIndex = 20
        Me.lblOnglet.Text = "Onglet"
        '
        'cSheet
        '
        Me.cSheet.FormattingEnabled = True
        Me.cSheet.Location = New System.Drawing.Point(189, 19)
        Me.cSheet.Name = "cSheet"
        Me.cSheet.Size = New System.Drawing.Size(127, 21)
        Me.cSheet.TabIndex = 21
        '
        'cDelimiter
        '
        Me.cDelimiter.FormattingEnabled = True
        Me.cDelimiter.Items.AddRange(New Object() {"", "Tabulation", "Virgule", "Espace", "Point virgule"})
        Me.cDelimiter.Location = New System.Drawing.Point(113, 19)
        Me.cDelimiter.Name = "cDelimiter"
        Me.cDelimiter.Size = New System.Drawing.Size(115, 21)
        Me.cDelimiter.TabIndex = 24
        '
        'oMapping
        '
        Me.oMapping.Controls.Add(Me.tCommentaire)
        Me.oMapping.Controls.Add(Me.tDateEmisPrg)
        Me.oMapping.Controls.Add(Me.tArtDesc)
        Me.oMapping.Controls.Add(Me.tLieuLivraison)
        Me.oMapping.Controls.Add(Me.tPrixUnitaire)
        Me.oMapping.Controls.Add(Me.tDevise)
        Me.oMapping.Controls.Add(Me.tCodeClient)
        Me.oMapping.Controls.Add(Me.tUnite)
        Me.oMapping.Controls.Add(Me.tTypeBesoin)
        Me.oMapping.Controls.Add(Me.tNumLigne)
        Me.oMapping.Controls.Add(Me.tNumCde)
        Me.oMapping.Controls.Add(Me.tDateBesoin)
        Me.oMapping.Controls.Add(Me.tQteBesoin)
        Me.oMapping.Controls.Add(Me.tArtRefClient)
        Me.oMapping.Controls.Add(Me.Label1)
        Me.oMapping.Controls.Add(Me.ComboBox1)
        Me.oMapping.Controls.Add(Me.ComboBox3)
        Me.oMapping.Controls.Add(Me.ComboBox4)
        Me.oMapping.Controls.Add(Me.ComboBox5)
        Me.oMapping.Controls.Add(Me.ComboBox6)
        Me.oMapping.Controls.Add(Me.ComboBox7)
        Me.oMapping.Controls.Add(Me.ComboBox8)
        Me.oMapping.Controls.Add(Me.ComboBox10)
        Me.oMapping.Controls.Add(Me.ComboBox11)
        Me.oMapping.Controls.Add(Me.ComboBox12)
        Me.oMapping.Controls.Add(Me.ComboBox13)
        Me.oMapping.Controls.Add(Me.Label3)
        Me.oMapping.Controls.Add(Me.Label4)
        Me.oMapping.Controls.Add(Me.Label5)
        Me.oMapping.Controls.Add(Me.Label6)
        Me.oMapping.Controls.Add(Me.Label7)
        Me.oMapping.Controls.Add(Me.Label8)
        Me.oMapping.Controls.Add(Me.Label10)
        Me.oMapping.Controls.Add(Me.Label11)
        Me.oMapping.Controls.Add(Me.Label12)
        Me.oMapping.Controls.Add(Me.Label13)
        Me.oMapping.Controls.Add(Me.cDateDem)
        Me.oMapping.Controls.Add(Me.cQte)
        Me.oMapping.Controls.Add(Me.cArtCli)
        Me.oMapping.Controls.Add(Me.lblDateDem)
        Me.oMapping.Controls.Add(Me.lblQte)
        Me.oMapping.Controls.Add(Me.lblArtCli)
        Me.oMapping.Location = New System.Drawing.Point(4, 22)
        Me.oMapping.Name = "oMapping"
        Me.oMapping.Padding = New System.Windows.Forms.Padding(3)
        Me.oMapping.Size = New System.Drawing.Size(583, 431)
        Me.oMapping.TabIndex = 0
        Me.oMapping.Text = "Mapping"
        Me.oMapping.UseVisualStyleBackColor = True
        '
        'tCommentaire
        '
        Me.tCommentaire.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tCommentaire.Location = New System.Drawing.Point(114, 393)
        Me.tCommentaire.Name = "tCommentaire"
        Me.tCommentaire.ReadOnly = True
        Me.tCommentaire.Size = New System.Drawing.Size(276, 20)
        Me.tCommentaire.TabIndex = 74
        Me.tCommentaire.Tag = "Commentaire"
        '
        'tDateEmisPrg
        '
        Me.tDateEmisPrg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tDateEmisPrg.Location = New System.Drawing.Point(114, 366)
        Me.tDateEmisPrg.Name = "tDateEmisPrg"
        Me.tDateEmisPrg.ReadOnly = True
        Me.tDateEmisPrg.Size = New System.Drawing.Size(276, 20)
        Me.tDateEmisPrg.TabIndex = 73
        Me.tDateEmisPrg.Tag = "DateEmisPrg"
        '
        'tArtDesc
        '
        Me.tArtDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tArtDesc.Location = New System.Drawing.Point(114, 337)
        Me.tArtDesc.Name = "tArtDesc"
        Me.tArtDesc.ReadOnly = True
        Me.tArtDesc.Size = New System.Drawing.Size(276, 20)
        Me.tArtDesc.TabIndex = 72
        Me.tArtDesc.Tag = "ArtDesc"
        '
        'tLieuLivraison
        '
        Me.tLieuLivraison.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tLieuLivraison.Location = New System.Drawing.Point(114, 310)
        Me.tLieuLivraison.Name = "tLieuLivraison"
        Me.tLieuLivraison.ReadOnly = True
        Me.tLieuLivraison.Size = New System.Drawing.Size(276, 20)
        Me.tLieuLivraison.TabIndex = 71
        Me.tLieuLivraison.Tag = "LieuLivraison"
        '
        'tPrixUnitaire
        '
        Me.tPrixUnitaire.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tPrixUnitaire.Location = New System.Drawing.Point(114, 283)
        Me.tPrixUnitaire.Name = "tPrixUnitaire"
        Me.tPrixUnitaire.ReadOnly = True
        Me.tPrixUnitaire.Size = New System.Drawing.Size(276, 20)
        Me.tPrixUnitaire.TabIndex = 70
        Me.tPrixUnitaire.Tag = "PrixUnitaire"
        '
        'tDevise
        '
        Me.tDevise.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tDevise.Location = New System.Drawing.Point(115, 256)
        Me.tDevise.Name = "tDevise"
        Me.tDevise.ReadOnly = True
        Me.tDevise.Size = New System.Drawing.Size(276, 20)
        Me.tDevise.TabIndex = 69
        Me.tDevise.Tag = "Devise"
        '
        'tCodeClient
        '
        Me.tCodeClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tCodeClient.Location = New System.Drawing.Point(115, 230)
        Me.tCodeClient.Name = "tCodeClient"
        Me.tCodeClient.ReadOnly = True
        Me.tCodeClient.Size = New System.Drawing.Size(276, 20)
        Me.tCodeClient.TabIndex = 68
        Me.tCodeClient.Tag = "CodeClient"
        '
        'tUnite
        '
        Me.tUnite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tUnite.Location = New System.Drawing.Point(115, 202)
        Me.tUnite.Name = "tUnite"
        Me.tUnite.ReadOnly = True
        Me.tUnite.Size = New System.Drawing.Size(276, 20)
        Me.tUnite.TabIndex = 67
        Me.tUnite.Tag = "Unite"
        '
        'tTypeBesoin
        '
        Me.tTypeBesoin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tTypeBesoin.Location = New System.Drawing.Point(115, 158)
        Me.tTypeBesoin.Name = "tTypeBesoin"
        Me.tTypeBesoin.ReadOnly = True
        Me.tTypeBesoin.Size = New System.Drawing.Size(276, 20)
        Me.tTypeBesoin.TabIndex = 66
        Me.tTypeBesoin.Tag = "TypeBesoin;o"
        '
        'tNumLigne
        '
        Me.tNumLigne.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tNumLigne.Location = New System.Drawing.Point(115, 131)
        Me.tNumLigne.Name = "tNumLigne"
        Me.tNumLigne.ReadOnly = True
        Me.tNumLigne.Size = New System.Drawing.Size(276, 20)
        Me.tNumLigne.TabIndex = 65
        Me.tNumLigne.Tag = "NumLigne;o"
        '
        'tNumCde
        '
        Me.tNumCde.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tNumCde.Location = New System.Drawing.Point(115, 104)
        Me.tNumCde.Name = "tNumCde"
        Me.tNumCde.ReadOnly = True
        Me.tNumCde.Size = New System.Drawing.Size(276, 20)
        Me.tNumCde.TabIndex = 64
        Me.tNumCde.Tag = "NumCde;o"
        '
        'tDateBesoin
        '
        Me.tDateBesoin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tDateBesoin.Location = New System.Drawing.Point(116, 77)
        Me.tDateBesoin.Name = "tDateBesoin"
        Me.tDateBesoin.ReadOnly = True
        Me.tDateBesoin.Size = New System.Drawing.Size(276, 20)
        Me.tDateBesoin.TabIndex = 63
        Me.tDateBesoin.Tag = "DateBesoin;o"
        '
        'tQteBesoin
        '
        Me.tQteBesoin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tQteBesoin.Location = New System.Drawing.Point(116, 51)
        Me.tQteBesoin.Name = "tQteBesoin"
        Me.tQteBesoin.ReadOnly = True
        Me.tQteBesoin.Size = New System.Drawing.Size(276, 20)
        Me.tQteBesoin.TabIndex = 62
        Me.tQteBesoin.Tag = "QteBesoin;o"
        '
        'tArtRefClient
        '
        Me.tArtRefClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tArtRefClient.Location = New System.Drawing.Point(116, 23)
        Me.tArtRefClient.Name = "tArtRefClient"
        Me.tArtRefClient.ReadOnly = True
        Me.tArtRefClient.Size = New System.Drawing.Size(276, 20)
        Me.tArtRefClient.TabIndex = 61
        Me.tArtRefClient.Tag = "ArtRefClient;o"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 313)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Lieu Livraison"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(396, 310)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(160, 21)
        Me.ComboBox1.TabIndex = 59
        Me.ComboBox1.Tag = "tLieuLivraison"
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(396, 391)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(160, 21)
        Me.ComboBox3.TabIndex = 56
        Me.ComboBox3.Tag = "tCommentaire"
        '
        'ComboBox4
        '
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(396, 283)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(160, 21)
        Me.ComboBox4.TabIndex = 55
        Me.ComboBox4.Tag = "tPrixUnitaire"
        '
        'ComboBox5
        '
        Me.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(396, 256)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(160, 21)
        Me.ComboBox5.TabIndex = 54
        Me.ComboBox5.Tag = "tDevise"
        '
        'ComboBox6
        '
        Me.ComboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(396, 364)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(160, 21)
        Me.ComboBox6.TabIndex = 53
        Me.ComboBox6.Tag = "tDateEmisPrg"
        '
        'ComboBox7
        '
        Me.ComboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox7.FormattingEnabled = True
        Me.ComboBox7.Location = New System.Drawing.Point(396, 337)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(160, 21)
        Me.ComboBox7.TabIndex = 52
        Me.ComboBox7.Tag = "tArtDesc"
        '
        'ComboBox8
        '
        Me.ComboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox8.FormattingEnabled = True
        Me.ComboBox8.Location = New System.Drawing.Point(396, 229)
        Me.ComboBox8.Name = "ComboBox8"
        Me.ComboBox8.Size = New System.Drawing.Size(160, 21)
        Me.ComboBox8.TabIndex = 51
        Me.ComboBox8.Tag = "tCodeClient"
        '
        'ComboBox10
        '
        Me.ComboBox10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox10.FormattingEnabled = True
        Me.ComboBox10.Location = New System.Drawing.Point(396, 202)
        Me.ComboBox10.Name = "ComboBox10"
        Me.ComboBox10.Size = New System.Drawing.Size(160, 21)
        Me.ComboBox10.TabIndex = 49
        Me.ComboBox10.Tag = "tUnite"
        '
        'ComboBox11
        '
        Me.ComboBox11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox11.FormattingEnabled = True
        Me.ComboBox11.Location = New System.Drawing.Point(396, 158)
        Me.ComboBox11.Name = "ComboBox11"
        Me.ComboBox11.Size = New System.Drawing.Size(160, 21)
        Me.ComboBox11.TabIndex = 48
        Me.ComboBox11.Tag = "tTypeBesoin"
        '
        'ComboBox12
        '
        Me.ComboBox12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox12.FormattingEnabled = True
        Me.ComboBox12.Location = New System.Drawing.Point(396, 131)
        Me.ComboBox12.Name = "ComboBox12"
        Me.ComboBox12.Size = New System.Drawing.Size(160, 21)
        Me.ComboBox12.TabIndex = 47
        Me.ComboBox12.Tag = "tNumLigne"
        '
        'ComboBox13
        '
        Me.ComboBox13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox13.FormattingEnabled = True
        Me.ComboBox13.Location = New System.Drawing.Point(396, 104)
        Me.ComboBox13.Name = "ComboBox13"
        Me.ComboBox13.Size = New System.Drawing.Size(160, 21)
        Me.ComboBox13.TabIndex = 46
        Me.ComboBox13.Tag = "tNumCde"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 394)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Commentaire"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 288)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Prix Unitaire"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 259)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Devise"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 366)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Date Emission"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 340)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 13)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Désignation Article"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 232)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Code Client"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 205)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Unité"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(14, 158)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Type Besoin"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.Location = New System.Drawing.Point(14, 134)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "n°Ligne"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(14, 107)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "n°Commande"
        '
        'cDateDem
        '
        Me.cDateDem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cDateDem.FormattingEnabled = True
        Me.cDateDem.Location = New System.Drawing.Point(396, 77)
        Me.cDateDem.Name = "cDateDem"
        Me.cDateDem.Size = New System.Drawing.Size(160, 21)
        Me.cDateDem.TabIndex = 9
        Me.cDateDem.Tag = "tDateBesoin"
        '
        'cQte
        '
        Me.cQte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cQte.FormattingEnabled = True
        Me.cQte.Location = New System.Drawing.Point(396, 50)
        Me.cQte.Name = "cQte"
        Me.cQte.Size = New System.Drawing.Size(160, 21)
        Me.cQte.TabIndex = 8
        Me.cQte.Tag = "tQteBesoin"
        '
        'cArtCli
        '
        Me.cArtCli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cArtCli.FormattingEnabled = True
        Me.cArtCli.Location = New System.Drawing.Point(396, 23)
        Me.cArtCli.Name = "cArtCli"
        Me.cArtCli.Size = New System.Drawing.Size(160, 21)
        Me.cArtCli.TabIndex = 7
        Me.cArtCli.Tag = "tArtRefClient"
        '
        'lblDateDem
        '
        Me.lblDateDem.AutoSize = True
        Me.lblDateDem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateDem.ForeColor = System.Drawing.Color.Maroon
        Me.lblDateDem.Location = New System.Drawing.Point(14, 80)
        Me.lblDateDem.Name = "lblDateDem"
        Me.lblDateDem.Size = New System.Drawing.Size(98, 13)
        Me.lblDateDem.TabIndex = 6
        Me.lblDateDem.Text = "Date Demandée"
        '
        'lblQte
        '
        Me.lblQte.AutoSize = True
        Me.lblQte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQte.ForeColor = System.Drawing.Color.Maroon
        Me.lblQte.Location = New System.Drawing.Point(14, 53)
        Me.lblQte.Name = "lblQte"
        Me.lblQte.Size = New System.Drawing.Size(55, 13)
        Me.lblQte.TabIndex = 3
        Me.lblQte.Text = "Quantité"
        '
        'lblArtCli
        '
        Me.lblArtCli.AutoSize = True
        Me.lblArtCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArtCli.ForeColor = System.Drawing.Color.Maroon
        Me.lblArtCli.Location = New System.Drawing.Point(14, 26)
        Me.lblArtCli.Name = "lblArtCli"
        Me.lblArtCli.Size = New System.Drawing.Size(79, 13)
        Me.lblArtCli.TabIndex = 2
        Me.lblArtCli.Text = "Article Client"
        '
        'tabMapping
        '
        Me.tabMapping.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMapping.Controls.Add(Me.oMapping)
        Me.tabMapping.Location = New System.Drawing.Point(12, 101)
        Me.tabMapping.Name = "tabMapping"
        Me.tabMapping.SelectedIndex = 0
        Me.tabMapping.Size = New System.Drawing.Size(591, 457)
        Me.tabMapping.TabIndex = 12
        '
        'gTypeCSV
        '
        Me.gTypeCSV.Controls.Add(Me.cDelimiter)
        Me.gTypeCSV.Controls.Add(Me.lblSeparateurColonne)
        Me.gTypeCSV.Location = New System.Drawing.Point(186, 23)
        Me.gTypeCSV.Name = "gTypeCSV"
        Me.gTypeCSV.Size = New System.Drawing.Size(587, 54)
        Me.gTypeCSV.TabIndex = 27
        Me.gTypeCSV.TabStop = False
        Me.gTypeCSV.Text = "CSV / Text"
        Me.gTypeCSV.Visible = False
        '
        'gTypeXLS
        '
        Me.gTypeXLS.Controls.Add(Me.tNumLigneEntete)
        Me.gTypeXLS.Controls.Add(Me.lblNumLigneEntete)
        Me.gTypeXLS.Controls.Add(Me.cSheet)
        Me.gTypeXLS.Controls.Add(Me.lblOnglet)
        Me.gTypeXLS.Location = New System.Drawing.Point(12, 41)
        Me.gTypeXLS.Name = "gTypeXLS"
        Me.gTypeXLS.Size = New System.Drawing.Size(584, 54)
        Me.gTypeXLS.TabIndex = 28
        Me.gTypeXLS.TabStop = False
        Me.gTypeXLS.Text = "Excel"
        Me.gTypeXLS.Visible = False
        '
        'F_ImportParam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 619)
        Me.Controls.Add(Me.lblFile)
        Me.Controls.Add(Me.tabMapping)
        Me.Controls.Add(Me.gTypeCSV)
        Me.Controls.Add(Me.bOK)
        Me.Controls.Add(Me.bAnnul)
        Me.Controls.Add(Me.gTypeXLS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "F_ImportParam"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mapping Fichier"
        Me.oMapping.ResumeLayout(False)
        Me.oMapping.PerformLayout()
        Me.tabMapping.ResumeLayout(False)
        Me.gTypeCSV.ResumeLayout(False)
        Me.gTypeCSV.PerformLayout()
        Me.gTypeXLS.ResumeLayout(False)
        Me.gTypeXLS.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bOK As Button
    Friend WithEvents bAnnul As Button
    Friend WithEvents oFileDialog As OpenFileDialog
    Friend WithEvents lblFile As Label
    Friend WithEvents lblNumLigneEntete As Label
    Friend WithEvents tNumLigneEntete As TextBox
    Friend WithEvents lblSeparateurColonne As Label
    Friend WithEvents lblOnglet As Label
    Friend WithEvents cSheet As ComboBox
    Friend WithEvents cDelimiter As ComboBox
    Friend WithEvents oMapping As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents ComboBox5 As ComboBox
    Friend WithEvents ComboBox6 As ComboBox
    Friend WithEvents ComboBox7 As ComboBox
    Friend WithEvents ComboBox8 As ComboBox
    Friend WithEvents ComboBox10 As ComboBox
    Friend WithEvents ComboBox11 As ComboBox
    Friend WithEvents ComboBox12 As ComboBox
    Friend WithEvents ComboBox13 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cDateDem As ComboBox
    Friend WithEvents cQte As ComboBox
    Friend WithEvents cArtCli As ComboBox
    Friend WithEvents lblDateDem As Label
    Friend WithEvents lblQte As Label
    Friend WithEvents lblArtCli As Label
    Friend WithEvents tabMapping As TabControl
    Friend WithEvents gTypeCSV As GroupBox
    Friend WithEvents gTypeXLS As GroupBox
    Friend WithEvents tCommentaire As TextBox
    Friend WithEvents tDateEmisPrg As TextBox
    Friend WithEvents tArtDesc As TextBox
    Friend WithEvents tLieuLivraison As TextBox
    Friend WithEvents tPrixUnitaire As TextBox
    Friend WithEvents tDevise As TextBox
    Friend WithEvents tCodeClient As TextBox
    Friend WithEvents tUnite As TextBox
    Friend WithEvents tTypeBesoin As TextBox
    Friend WithEvents tNumLigne As TextBox
    Friend WithEvents tNumCde As TextBox
    Friend WithEvents tDateBesoin As TextBox
    Friend WithEvents tQteBesoin As TextBox
    Friend WithEvents tArtRefClient As TextBox
End Class
