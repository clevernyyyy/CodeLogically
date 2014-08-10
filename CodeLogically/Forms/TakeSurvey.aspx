<%@ Page Title="Take Survey" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="TakeSurvey.aspx.vb" Inherits="CodeLogically.TakeSurvey"  EnableEventValidation="false" %>

<%@ Register Src="~/Controls/TakeSurvey.ascx" TagPrefix="uctrl" TagName="TS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="CodeOne Test Site">
    <meta name="author" content="Adam Schaal">
    <link rel="shortcut icon" href="">
    <title>Survey</title>
    <link type="text/css" rel="stylesheet" href="/Styles/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
    <link type="text/css" rel="stylesheet" href="https://code.jquery.com/ui/1.10.1/themes/base/jquery-ui.css" />
    <!-- Custom styles for this template -->
    <link href="/Styles/main.css" rel="stylesheet" />
    <link href="/Styles/icomoon.css" rel="stylesheet" />
    <link href="/Styles/animate-custom.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic'
        rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Raleway:400,300,700' rel='stylesheet'
        type='text/css' />
    <script type="text/javascript" src="/Scripts/site_scripts/jquery.min.js"></script>
    <script type="text/javascript" src="/Scripts/site_scripts/modernizr.custom.js"></script>
    <script type="text/javascript" src="/Scripts/PerPage/TakeSurvey.js?cachebreak=08092014"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body
        {
            background: white !important;
        }
    </style>
    <div id="TakeSurveyPage" class="container centered">
            <h2 class="centered" style="color: #3399FF; font-size: 36px;">
            Take a Survey
            </h2>
            <p>
                Select from our list of surveys!</p>
            
        <!-- Survery Gridview -->
        <div id="Retrieve" class="centered">
        <div class="rowClassSpace">
            &nbsp;</div>
            <div id="Retrieve_GridViewContainer" class="gridViewContainer">
                <asp:GridView ID="dvgPack" runat="server" CssClass="tableClass" AutoGenerateColumns="false"
                    OnSorting="dgvPack_Sorting" AllowSorting="true" CellPadding="3" TabIndex="4"
                    PageSize="10" AllowPaging="true" PagerSettings-Position="TopAndBottom" PagerStyle-HorizontalAlign="Center">
                    <HeaderStyle ForeColor="Navy" Font-Underline="false"/>
                    <Columns>
                        <%--0--%><asp:BoundField DataField="cDescription" HeaderText="Survey Title" SortExpression="cDescription"
                            ItemStyle-Width="430" />
                        <%--1--%><asp:BoundField DataField="cUserName" HeaderText="Survey Author" SortExpression="cUserName"
                            ItemStyle-Width="200" />
                        <%--2--%><asp:BoundField DataField="dCreated" HeaderText="Date Created" DataFormatString="{0:d}"
                            SortExpression="dCreated" ItemStyle-Width="120" />
                        <%--3--%><asp:BoundField DataField="nSurveyType" HeaderText="SurveyID" ItemStyle-Width="50"
                            SortExpression="nSurveyType" />
                        <%-- HeaderStyle-CssClass="nodisplay" ItemStyle-CssClass="nodisplay" />--%>
                    </Columns>
                    <PagerStyle CssClass="pager" />
                    <PagerTemplate>
<%--                        <uctrl:CustomButton ID="btnPrev" Text="<<" Width="75px" runat="server" CausesValidation="true"
                            OnClick="dgvPackPrev_Click" />--%>
                        <span style="display: inline-block; text-align: center; font-weight: bold;">Page
                            <asp:DropDownList ID="dgvPackDDL" AutoPostBack="true" OnSelectedIndexChanged="dgvPackDDL_SelectedIndexChanged"
                                runat="server" />
                            out of
                            <asp:Label ID="lblPages" runat="server"></asp:Label>
                        </span>
<%--                        <uctrl:CustomButton ID="btnNext" Text=">>" Width="75px" runat="server" CausesValidation="true"
                            OnClick="dgvPackNext_Click" />--%>
                    </PagerTemplate>
                </asp:GridView>
            </div>
        </div>

    <div style="clear: both;" />

    <div class="none border" id="divTakeSurvey" title="Take Survey">
        <uctrl:TS ID="Take_Survey" runat="server" />
    </div>

</asp:Content>
