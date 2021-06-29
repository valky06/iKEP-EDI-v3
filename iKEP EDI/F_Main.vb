Imports System.Windows.Forms
Imports System
Imports Microsoft.Office.Interop.Excel
Imports System.IO

Public Class F_Main
    Public Sub fermetout()
        For Each ChildForm In Me.MdiChildren : ChildForm.Close() : Next
    End Sub

    Public Sub MenuDisable()
        mUtil.Enabled = False
        mConfig.Enabled = False
        mAfferme.Visible = False
        mImport.Visible = False
        mExport.Visible = False
    End Sub

    Public Sub MenuEnable()
        mAfferme.Visible = True
        mImport.Visible = True
        mExport.Visible = True
        mUtil.Enabled = leUser.IsAdmin
        mConfig.Enabled = leUser.IsAdmin
    End Sub

    Sub ParamInit()

        My.Settings.Reload()
        Modedebug = My.Settings.ModeDebug

        If conSqlEDI.State <> ConnectionState.Closed Then conSqlEDI.Close()
        conSqlEDI.ConnectionString = My.Settings.SQLConEDI & ";Connection Timeout=300"

        'Charge données utilisateur
        If leUser.LitParam(leUser.Login) Then
            sUser.Text = leUser.Login
            MenuEnable()
        Else
            MenuDisable()
        End If
    End Sub

    Private Sub F_MainLOad(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        tVersion.Text = My.Application.Info.Version.ToString
        Text = My.Application.Info.ProductName
        leUser.Login = My.User.Name
        ParamInit()
        sContext.Text = ""
    End Sub

    Private Sub UtilisateurToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mUtil.Click
        fermetout()
        F_UsersListe.ShowDialog()
        ParamInit()
    End Sub

    Private Sub ParamétresGénérauxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mConfig.Click
        fermetout()
        F_ConfigListe.ShowDialog()
        ParamInit()
    End Sub

    Private Sub ParToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mParam.Click
        If InputBox("Mot de passe ?") = "!KEP" Then
            If F_Param.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                conSqlEDI.Close()
                F_MainLOad(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub MMenu_Click(sender As Object, e As EventArgs) Handles mImport.Click
        'F_ImportListe.leTiersId = 1
        'F_ImportListe.ShowDialog()
        'F_ImportListe.Dispose()

        fermetout()
        F_ImportCdeVente.MdiParent = Me
        F_ImportCdeVente.Show()
    End Sub

    Private Sub AffermissementSilogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mAfferme.Click
        fermetout()
        F_Afferme.MdiParent = Me
        F_Afferme.Show()



    End Sub

    Private Sub F_Main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ConnexionFerme(conSqlEDI)
    End Sub

    Private Sub MExport_Click(sender As Object, e As EventArgs) Handles mExport.Click
        fermetout()
        F_Export.MdiParent = Me
        F_Export.Show()



        'Dim proc As New Process
        'proc.StartInfo.FileName = "net"
        'proc.StartInfo.UseShellExecute = True
        'proc.EnableRaisingEvents = False
        'proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden

        'proc.StartInfo.Arguments = "use \\\\NASC1\data\ACHATS /u:KEP\Administrateur Xsz23edC!"
        'proc.Start()
        'proc.WaitForExit()

        'proc.StartInfo.FileName = "cmd.exe"
        'proc.StartInfo.Arguments = "/C copy c:\temp\TEST.csv \\nasc1\data\achats\lolo45.csv"
        'proc.Start()
        'proc.WaitForExit()

    End Sub

    Private Sub AideEnLigneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AideEnLigneToolStripMenuItem.Click
        LienOuvre("https://keptechnologies.sharepoint.com/:u:/s/MS-APP/BI/EQLhxw804L9Mu8XFw9eBwP8BIJ7s4U3tiFRbxIbg4XVkFw?e=NRTu34")
        ' f_web.ShowDialog()
    End Sub

    Private Sub sUser_DoubleClick(sender As Object, e As EventArgs) Handles sUser.DoubleClick
        If InputBox("Mot de passe") = "!KEP" Then
            leUser.Login = InputBox("Login")
            ParamInit()
        End If
    End Sub

    Private Sub TVersion_Click(sender As Object, e As EventArgs) Handles tVersion.Click
        DocOuvre("http://ikep-erp.fr/2019/10/02/ikep-edi-v2/")
    End Sub

    Private Sub TiersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiersToolStripMenuItem.Click
        fermetout()
        F_TiersListe.ShowDialog()
        ParamInit()
    End Sub

    Private Sub sContext_Click(sender As Object, e As EventArgs) Handles sContext.Click

    End Sub

    Private Sub ContrôlePrévisionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContrôlePrévisionToolStripMenuItem.Click
        fermetout()
        F_CtrlPrev.MdiParent = Me
        F_CtrlPrev.Show()
    End Sub
End Class
