Public Class AgreeDisagree
    Inherits QuestionControl

    Public Overrides Property QuestionType As Enums.enmQuestionType
        Get
            Return MyBase.QuestionType
        End Get
        Set(value As Enums.enmQuestionType)
            MyBase.QuestionType = value
        End Set
    End Property



    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Overrides Function SaveAnswer() As Boolean
        Return True
    End Function
    Public Overrides Sub LoadQuestion(Q As Question)
        Me.QuestionType = Q.QuestionType
        rptOptions.DataSource = Q.QuestionOptions
        rptOptions.DataBind()
    End Sub
    Public Sub New()
        Me.rptOptions = New Repeater
    End Sub

    Private Sub rptOptions_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptOptions.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim O As QuestionOption = e.Item.DataItem
            Dim lblOptionText As Label = e.Item.FindControl("lblQuestionText")
            Dim rbtStrongDisagree As RadioButton = e.Item.FindControl("rbtSD")
            Dim rbtDisagree As RadioButton = e.Item.FindControl("rbtD")
            Dim rbtNeutral As RadioButton = e.Item.FindControl("rbtN")
            Dim rbtAgree As RadioButton = e.Item.FindControl("rbtA")
            Dim rbtStrongAgree As RadioButton = e.Item.FindControl("rbtSA")
            rbtStrongDisagree.GroupName = "rbtGroup" & O.OptionOrder.ToString
            rbtDisagree.GroupName = "rbtGroup" & O.OptionOrder.ToString
            rbtNeutral.GroupName = "rbtGroup" & O.OptionOrder.ToString
            rbtAgree.GroupName = "rbtGroup" & O.OptionOrder.ToString
            rbtStrongAgree.GroupName = "rbtGroup" & O.OptionOrder.ToString
            lblOptionText.Text = O.OptionText

        End If
    End Sub
End Class