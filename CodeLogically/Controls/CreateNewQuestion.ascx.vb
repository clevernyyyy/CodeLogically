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
    Public ReadOnly Property QuestionTypeBox As DropDownList
        Get
            Return ddlQuestionType
        End Get
    End Property
    Public ReadOnly Property OptionsRepeater As Repeater
        Get
            Return rptUserOptions
        End Get
    End Property
    Public ReadOnly Property RadioButtonsPanel As Panel
        Get
            Return pnlRadioButtons
        End Get
    End Property
    Public ReadOnly Property QuestionText As String
        Get
            Return txtQuestionText.Text
        End Get
    End Property
    Private Sub LoadQuestionTypes()
        Dim dt As DataTable = AddEmptyRowToBegining(FillDataTable(SqlCommand("Lookup.usp_Get_SurveyQuestionTypes")))

        SetDataSource(ddlQuestionType, dt, "cDescription", "nQuestionType")
        ddlQuestionType.SelectedIndex = -1
    End Sub
    Public Sub New(S As Survey, Optional ByVal enmQType As Enums.enmQuestionType = 0)
        MyBase.New()
        ParentSurvey = S
        If enmQType > 0 Then
            QuestionType = enmQType
            ddlQuestionType.Visible = False
        Else
            ddlQuestionType = New DropDownList
            ddlQuestionType.Visible = True
        End If
    End Sub
    Public Sub New()
        Dim intSurveyID As Integer = FillDataTable(SqlCommand("Lookup.usp_Get_NewSurvey")).Rows(0).Item("nSurveyID")
        ParentSurvey = New Survey(intSurveyID, 0, "", 1, Date.Now())
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
        If ddlQuestionType.SelectedIndex >= 0 Then
            QuestionType = ddlQuestionType.SelectedValue
            HideTheQuestionStuff()
            Select Case QuestionType
                Case Enums.enmQuestionType.YesNo, Enums.enmQuestionType.YesNoIDK
                    chkIDKMyBFFJill.Visible = True
                    chkIDKMyBFFJill.Checked = (QuestionType = Enums.enmQuestionType.YesNoIDK)
                Case Enums.enmQuestionType.SingleLine, Enums.enmQuestionType.MultiLine
                    chkMultiLine.Visible = True
                    chkMultiLine.Checked = (QuestionType = Enums.enmQuestionType.MultiLine)
                Case Enums.enmQuestionType.DropDown, Enums.enmQuestionType.MultiRadio, Enums.enmQuestionType.AgreeDisagree
                    Dim lstOptions As New List(Of String)
                    lstOptions.Add("")
                    rptUserOptions.Visible = True
                    rptUserOptions.DataSource = lstOptions
                    rptUserOptions.DataBind()
                    btnAddOption.Visible = True
                    'Case Enums.enmQuestionType.MultiRadio
                    '    txtRadioAmount.Visible = True
                    '    pnlRadioButtons.Visible = True
            End Select
        End If
    End Sub
    Private Sub HideTheQuestionStuff()
        chkIDKMyBFFJill.Visible = False
        chkMultiLine.Visible = False
        rptUserOptions.Visible = False
        btnAddOption.Visible = False
        txtRadioAmount.Visible = False
        txtRadioAmount.Text = ""
        pnlRadioButtons.Visible = False
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

    Private Sub txtRadioAmount_TextChanged(sender As Object, e As EventArgs) Handles txtRadioAmount.TextChanged
        If IsNumeric(txtRadioAmount.Text.ToString) Then
            For i As Integer = 0 To txtRadioAmount.Text - 1
                AddNewRadioButton(i)
            Next
        End If
    End Sub

    Private Sub AddNewRadioButton(ByVal name As String)

        '   Create a new radio button 
        Dim MyRadioButton As New RadioButton

        Dim txtRadioText As New TextBox
        With txtRadioText
            .ID = "txtRadioText" & name.ToString
            .AutoPostBack = True
            .Text = String.Format("Radio Button - {0}", name.ToString)
        End With

        FindControl("pnlRadioButtons").Controls.Add(txtRadioText)
    End Sub
    Public Function ValidPage() As Boolean
        Dim lValid As Boolean = True
        If txtQuestionText.Text.Trim = "" Then
            lValid = False
        End If
        Select Case _QuestionType
            Case Enums.enmQuestionType.DropDown
                If rptUserOptions.Items.Count < 2 Then
                    lValid = False
                End If
            Case Enums.enmQuestionType.MultiRadio
                If txtRadioAmount.Text.Trim = "" Then
                    lValid = False
                Else
                    Dim ctrl = From txt As Control In pnlRadioButtons.Controls
                               Where txt.ID.Contains("txtRadioText") And DirectCast(txt, TextBox).Text.Trim = ""
                               Select txt

                    If ctrl.Count <> 0 Then
                        lValid = False
                    End If
                End If
        End Select
        Return lValid
    End Function
    Public Sub ClearControls()
        txtQuestionText.Text = ""
        ddlQuestionType.SelectedIndex = -1
        HideTheQuestionStuff()

    End Sub
End Class