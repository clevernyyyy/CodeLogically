Public Class UserOption
    Inherits System.Web.UI.UserControl
    Public Property OptionText As String
        Get
            Return txtOptionText.Text
        End Get
        Set(value As String)
            txtOptionText.Text = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class