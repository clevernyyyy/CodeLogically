Imports System.Data.SqlClient
Public Class TakeSurvey
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            'Clear Everything


            'Initialize Survey Gridview
            Dim cTitle As String = ""
            Dim cUser As String = ""
            Dim dCreated As DateTime = Date.Now

            LoadSurveys(cTitle, cUser, dCreated)

        End If
    End Sub


#Region "Data Retrieval"

    Private Sub LoadSurveys(ByVal cTitle As String, ByVal cUser As String, ByVal dCreated As DateTime,
                            Optional ByVal lSetFocusToTop As Boolean = False)
        Dim dt As DataTable = Nothing

        Dim cmd = SqlCommand("Lookup.usp_Get_SurveyTypes")

        With cmd.Parameters
            '.AddWithValue("@cDescription", cDescription)
            '.AddWithValue("@nUserNum", nUser)
            '.AddWithValue("@dCreated", dCreated)
        End With

        dt = FillDataTable(cmd)

        dvgPack.DataSource = dt
        dvgPack.DataBind()


        If lSetFocusToTop Then
            Dim pageList As DropDownList = CType(dvgPack.TopPagerRow.FindControl("dgvPackDDL"), DropDownList)
            If Not pageList Is Nothing Then
                ScriptManager.GetCurrent(Page).SetFocus(pageList.ClientID)
            End If
        End If
    End Sub

    Private Sub LoadSelectedSurvey(ByVal cTitle As String, ByVal cUser As String, ByVal dCreated As DateTime, ByVal nSurveryID As Integer)
        'FillSession(cTitle, cUser, dCreated, nSurveyID)

        Dim objSurvey = New Survey(nSurveryID, 0, "cTitle", 1, Date.Now())
        objSurvey.LoadSurvey()
        Session("Survey") = objSurvey

        OpenSurveyEditor()


    End Sub

#End Region

#Region "Popup"
    Private Sub OpenSurveyEditor()
        Dim strJava As String = "OpenSurveyEditor();"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenSurveyEditor", strJava, True)
    End Sub
#End Region



#Region "Search Grid Stuff"
    Private Sub dvgPackages_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvgPack.SelectedIndexChanged
        'This might be where I start search
        Dim strTitle As String = ""
        Dim strUser As String = ""
        Dim dCreated As DateTime
        Dim nSurveyType As Integer  'Identity Column

        strTitle = Server.HtmlDecode(dvgPack.SelectedRow.Cells(0).Text)
        strUser = Server.HtmlDecode(dvgPack.SelectedRow.Cells(1).Text)
        dCreated = dvgPack.SelectedRow.Cells(2).Text
        nSurveyType = dvgPack.SelectedRow.Cells(3).Text

        LoadSelectedSurvey(strTitle, strUser, dCreated, nSurveyType)
    End Sub

    Private Sub dvgPack_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dvgPack.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Height = 35
            Dim d As DateTime = e.Row.Cells(2).Text
            e.Row.Cells(2).Text = d.ToShortDateString
            ''This code allows the gridview to be selectable
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer'; this.style.backgroundColor='#E0EECA';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';")
            e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(sender, "Select$" + e.Row.RowIndex.ToString))
        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            ' Retrieve the DropDownList and Label controls from the row.
            Dim pageList As DropDownList = CType(e.Row.Cells(0).FindControl("dgvPackDDL"), DropDownList)
            For i As Integer = 0 To dvgPack.PageCount - 1

                ' Create a ListItem object to represent a page.
                Dim pageNumber As Integer = i + 1
                Dim item As ListItem = New ListItem(pageNumber.ToString())

                ' If the ListItem object matches the currently selected
                ' page, flag the ListItem object as being selected. Because
                ' the DropDownList control is recreated each time the pager
                ' row gets created, this will persist the selected item in
                ' the DropDownList control.   
                If i = dvgPack.PageIndex Then

                    item.Selected = True

                End If

                ' Add the ListItem object to the Items collection of the 
                ' DropDownList.
                pageList.Items.Add(item)
            Next

            'Fix up 'out of' label
            Dim lblPages As Label = CType(e.Row.Cells(0).FindControl("lblPages"), Label)
            lblPages.Text = dvgPack.PageCount

            'Hide nav buttons if necessary
            'If dvgPack.PageIndex = 0 Then
            '    Dim btnPrev As UserControls_CustomButton = CType(e.Row.Cells(0).FindControl("btnPrev"), UserControls_CustomButton)
            '    btnPrev.Style.Item("visibility") = "hidden"
            'ElseIf dvgPack.PageIndex >= dvgPack.PageCount - 1 Then
            '    Dim btnNext As UserControls_CustomButton = CType(e.Row.Cells(0).FindControl("btnNext"), UserControls_CustomButton)
            '    btnNext.Style.Item("visibility") = "hidden"
            'End If
        End If
    End Sub

    Protected Sub dgvPackDDL_SelectedIndexChanged(ByVal pageList As DropDownList, ByVal e As EventArgs)
        ' Set the PageIndex property to display that page selected by the user.
        dvgPack.PageIndex = pageList.SelectedIndex
        PassSearchData(True)
    End Sub

    Protected Sub dgvPackPrev_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Set the PageIndex property to display that page selected by the user.
        dvgPack.PageIndex -= 1
        PassSearchData(True)
    End Sub

    Protected Sub dgvPackNext_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Set the PageIndex property to display that page selected by the user.
        dvgPack.PageIndex += 1
        PassSearchData(True)
    End Sub

    Protected Sub dgvPack_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs)
        Dim dv As New DataView(Session("dtSearch"))
        If (e.SortExpression = "dDateOfLoss" OrElse e.SortExpression = "nEntryID") Then
            dv.Sort = e.SortExpression & " DESC"
        Else
            dv.Sort = e.SortExpression & " ASC"
        End If
        HttpContext.Current.Session("strSortedBy") = dv.Sort.ToString
        dvgPack.DataSource = dv
        dvgPack.DataBind()
        'If GetServer() = enmServer.Live Then
        'dvgPack.Columns(6).Visible = False
        'End If
    End Sub


    Private Sub PassSearchData(Optional ByVal lSetFocusToTop As Boolean = False)
        Dim cTitle As String = ""
        Dim cUser As String = ""
        Dim dCreated As DateTime = Date.Now

        'Can add logic, like a search to this page.
        'If txtPolNum.Text.Trim <> "" Then
        '    cPolNum = Replace(txtPolNum.Text, "-", "").Trim
        'End If

        'cName = txtSearchName.Text.Trim

        'If uctrlEffDate.Value <> "" Then
        '    cMinDate = uctrlEffDate.Value
        'End If

        'If uctrlExpDate.Value <> "" Then
        '    cMaxDate = uctrlExpDate.Value
        'End If

        'If txtPhoneNum.Text <> "Phone Number" Then
        '    cPhone = txtPhoneNum.Text
        'End If

        LoadSurveys(cTitle, cUser, dCreated, lSetFocusToTop)
    End Sub
#End Region



End Class