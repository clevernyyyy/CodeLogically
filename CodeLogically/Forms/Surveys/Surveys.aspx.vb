﻿Public Class Surveys
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        hUser.Value = ctrlLogin.Username
        hPass.Value = ctrlLogin.Password
        If Not IsPostBack() Then
            If Not CheckLogin() Then
                OpenLoginDialog()
            Else
                ctrlLogin.Visible = False
                LoadUserLvlDisplay()    'Access Control
            End If
        Else
            CheckLogin()
        End If

    End Sub

    Private Sub LoadUserLvlDisplay()
        'Only show the user things they have access for

    End Sub


    Private Function CheckLogin() As Boolean
        'Only for testing, I imagine this will be in a class/module eventually
        If HttpContext.Current.Session("User") Is Nothing Then
            Dim strUserName As String = hUser.Value
            Dim strPassword As String = hPass.Value
            If strUserName <> "" And strPassword <> "" Then
                ctrlLogin.SignIn(strUserName, strPassword)
            End If
        End If
        Return HttpContext.Current.Session("User") IsNot Nothing
    End Function

    Private Sub OpenLoginDialog()
        Dim strJava As String = "OpenLoginDialog();"

        ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenLoginDialog", strJava, True)

    End Sub


End Class