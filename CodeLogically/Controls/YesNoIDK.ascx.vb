Public Class YesNoIDK
    Inherits System.Web.UI.UserControl
    Private _AllowIDK As Boolean = False
    Public Property AllowIDK As Boolean
        Get
            Return _AllowIDK
        End Get
        Set(value As Boolean)
            _AllowIDK = value
            If value Then
                rbtIDKMyBFFJill.Visible = True
            Else
                rbtIDKMyBFFJill.Visible = False
            End If
        End Set
    End Property

    Public Property QuestionText As String

    ReadOnly Property YesID As String
        Get
            Return rbtYes.ClientID
        End Get
    End Property
    ReadOnly Property NoID As String
        Get
            Return rbtNo.ClientID
        End Get
    End Property
    ReadOnly Property IDKID As String
        Get
            Return rbtIDKMyBFFJill.ClientID
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class