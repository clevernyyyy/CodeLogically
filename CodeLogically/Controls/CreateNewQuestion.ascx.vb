Public Class CreateNewQuestion
    Inherits CreateQuestion

    Private Property _QuestionType As Enums.enmQuestionType
    Public Property QuestionType As Enums.enmQuestionType
        Get
            Return _QuestionType
        End Get
        Set(value As Enums.enmQuestionType)
            _QuestionType = value
        End Set
    End Property
    Private Sub LoadQuestionTypes()
        Dim dt As DataTable = FillDataTable(SqlCommand("Lookup.usp_Get_SurveyQuestionTypes"))
        SetDataSource(ddlQuestionType, dt, "cDescription", "nQuestionType")
    End Sub
    Public Sub New(S As Survey, Optional ByVal enmQType As Enums.enmQuestionType = 0)
        ParentSurvey = S
        If enmQType > 0 Then
            QuestionType = enmQType
            ddlQuestionType.Visible = False
        Else
            ddlQuestionType.Visible = True
        End If
    End Sub
    Public Sub New()
        ParentSurvey = New Survey(1, 0)
        _QuestionType = 0
    End Sub
    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            HideTheQuestionStuff()
            LoadQuestionTypes()
        End If
    End Sub
    Public Overrides Function SaveQuestion() As Boolean
        If ddlQuestionType.Visible Then
            QuestionType = ddlQuestionType.SelectedValue
        End If
        Dim Q As New Question(txtQuestionText.Text, _QuestionType)
        ParentSurvey.AddQuestion(Q)
        Return True
    End Function

    Private Sub ddlQuestionType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlQuestionType.SelectedIndexChanged
        Dim nType As Enums.enmQuestionType = ddlQuestionType.SelectedValue
        HideTheQuestionStuff()
        Select Case nType
            Case Enums.enmQuestionType.YesNo, Enums.enmQuestionType.YesNoIDK
                chkIDKMyBFFJill.Visible = True
                chkIDKMyBFFJill.Checked = (nType = Enums.enmQuestionType.YesNoIDK)
            Case Enums.enmQuestionType.SingleLine, Enums.enmQuestionType.MultiLine
                chkMultiLine.Visible = True
                chkMultiLine.Checked = (nType = Enums.enmQuestionType.MultiLine)
            Case Enums.enmQuestionType.DropDown
                Dim lstOptions As New List(Of String)
                lstOptions.Add("")
                rptUserOptions.Visible = True
                rptUserOptions.DataSource = lstOptions
                rptUserOptions.DataBind()
                btnAddOption.visible = True
        End Select
    End Sub
    Private Sub HideTheQuestionStuff()
        chkIDKMyBFFJill.Visible = False
        chkMultiLine.Visible = False
        rptUserOptions.Visible = False
        btnAddOption.Visible = False
    End Sub

    Private Sub rptUserOptions_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptUserOptions.ItemDataBound
        Dim strOption As String = e.Item.DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ctrl As UserOption = DirectCast(e.Item.FindControl("ctrlUO"), UserOption)
            ctrl.OptionText = strOption
        End If
    End Sub
    Private Sub AddOptionRow()
        Dim lstOptions As New List(Of String)
        For Each i As RepeaterItem In rptUserOptions.Items
            Dim ctrl As UserOption = DirectCast(i.FindControl("ctrlUO"), UserOption)
            Dim cOption As String = ctrl.OptionText
            If lstOptions.Contains(cOption) = False Then
                lstOptions.Add(cOption)
            End If
        Next
        If lstOptions.Contains("") = False Then
            lstOptions.Add("")
        End If
        rptUserOptions.DataSource = Nothing
        rptUserOptions.DataSource = lstOptions
        rptUserOptions.DataBind()
    End Sub

    Private Sub btnAddOption_Click(sender As Object, e As System.EventArgs) Handles btnAddOption.Click
        AddOptionRow()
    End Sub
End Class