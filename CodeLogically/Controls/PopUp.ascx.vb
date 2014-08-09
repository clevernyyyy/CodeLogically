<ParseChildren(True, "Content")>
<PersistChildren(False)>
Public Class PopUp
    Inherits System.Web.UI.UserControl

    Public Property Content As Control
    Public Property Buttons As Control
    Public Property PopupId As String
    Public Property Height As String

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        phContent.Controls.Add(Content)
        phButton.Controls.Add(Buttons)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public WriteOnly Property ClickOutAllowed As Boolean
        Set(ByVal value As Boolean)
            hClickOutAllowed.Value = "true"
            If Not value Then
                hClickOutAllowed.Value = "false"
            End If
        End Set
    End Property

    Property Title As String
        Get
            Return lblPopUpTitle.Text
        End Get
        Set(ByVal value As String)
            lblPopUpTitle.Text = value
        End Set
    End Property
    Public Sub Show(ByRef Page As Page, Optional ByVal pcExtraJava As String = "")
        Dim strjava As String = Me.LoadJava(pcExtraJava)
        ScriptManager.RegisterStartupScript(Page, Page.GetType, "popUp", strjava, True)
    End Sub
    Public Function LoadJava(Optional ByVal pcExtraJava As String = "") As String
        Return "loadPopupNew('" & PopupId & "');" & pcExtraJava
    End Function
End Class