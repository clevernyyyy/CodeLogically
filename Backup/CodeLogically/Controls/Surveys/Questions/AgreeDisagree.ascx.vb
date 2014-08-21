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
    Public Overrides ReadOnly Property Value As Object
        Get
            Dim dicValue As New Dictionary(Of Integer, String)
            Dim intOption As Integer = 0
            For Each item In rptOptions.Items
                Dim rbtStrongDisagree As RadioButton = item.FindControl("rbtSD")
                Dim rbtDisagree As RadioButton = item.FindControl("rbtD")
                Dim rbtNeutral As RadioButton = item.FindControl("rbtN")
                Dim rbtAgree As RadioButton = item.FindControl("rbtA")
                Dim rbtStrongAgree As RadioButton = item.FindControl("rbtSA")

                Select Case True
                    Case rbtStrongDisagree.Checked
                        dicValue.Add(intOption, "0")
                    Case rbtDisagree.Checked
                        dicValue.Add(intOption, "1")
                    Case rbtNeutral.Checked
                        dicValue.Add(intOption, "2")
                    Case rbtAgree.Checked
                        dicValue.Add(intOption, "3")
                    Case rbtStrongAgree.Checked
                        dicValue.Add(intOption, "4")
                End Select
                intOption += 1
            Next

            Return dicValue
        End Get

    End Property
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