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
    <div id="TakeSurveyPage" class="container">
            <h2 class="centered" style="color: #3399FF; font-size: 36px;">
            Take a Survey
            </h2>
            <p class="centered">
                Select from our list of surveys!</p>
        
        
            <div id="Search" class="container border" style="background-color:#f9f9f9">
                <h2>Find a particular survey!</h2>
                <div id="Retrieve_SearchContainer">
                    <div class="rowClass">
                        <span class="lblColTitle">Title:</span> <span class="textColName">
                            <asp:TextBox ID="txtSearchTitle" runat="server" CssClass="textfield" /></span>
                        <span class="lblColAuthor">Author:</span> <span class="Col">
                            <asp:TextBox ID="txtSearchAuthor" runat="server" CssClass="textfield" /></span>
                        <span class="lblSurveyID">Survey ID:</span> <span class="Col">
                            <asp:TextBox ID="txtSearchSurveyID" runat="server" CssClass="textfield" /></span>
                    </div>
                    <div class="rowClass" style="width: 790px">
                        <span class="ColEffective"><span class="labelColEffective">Date Created from</span>
<%--                            <uctrl:DateTime ID="uctrlEffDate" runat="server" HideLabel="true" HideTime="true"
                                MinDate="01/01/2010" YearRange="1900:+0" />--%>
                            <span class="labelColEffective2">to</span>
<%--                            <uctrl:DateTime ID="uctrlExpDate" runat="server" HideLabel="true" HideTime="true"
                                MinDate="01/01/2010" YearRange="1900:+0" />--%>
                        </span><span class="rightColButton">
    <%--                        <uctrl:CustomButton runat="server" ID="btnFilter" Text="Filter" />
                            <uctrl:CustomButton ID="btnOpenClaim" runat="server" Text="Open Claim" />--%>
                        </span>
                    </div>
                </div>
            </div>
            <div id="divVersion" class="right" style="float:right">
                <asp:Label ID="lblVersion" runat="server" Text="Version 1.0.0" CssClass="right"></asp:Label>
            </div>    
        <!-- Survery Gridview -->
        <div id="Retrieve" class="centered">
        

        <div class="rowClassSpace">
            &nbsp;</div>
            <div id="Retrieve_GridViewContainer" class="gridViewContainer">
                <asp:GridView ID="dvgPack" runat="server" CssClass="table table-hover table-striped table-bordered table-condensed" 
                    AutoGenerateColumns="false"
                    OnSorting="dgvPack_Sorting" AllowSorting="true" CellPadding="3" TabIndex="4"
                    PageSize="50" AllowPaging="true" PagerSettings-Position="TopAndBottom" PagerStyle-HorizontalAlign="Center">
                    <HeaderStyle ForeColor="Navy" Font-Underline="false" BorderColor="Black"/>
                    <Columns>
                        <%--0--%><asp:BoundField DataField="cDescription" HeaderText="Survey Title" SortExpression="cDescription"
                            ItemStyle-Width="430" HeaderStyle-CssClass="centered" ItemStyle-CssClass="left"/>
                        <%--1--%><asp:BoundField DataField="cUserName" HeaderText="Survey Author" SortExpression="cUserName"
                            ItemStyle-Width="200"  HeaderStyle-CssClass="centered"  />
                        <%--2--%><asp:BoundField DataField="dCreated" HeaderText="Date Created" DataFormatString="{0:d}"
                            SortExpression="dCreated" ItemStyle-Width="120"  HeaderStyle-CssClass="centered" />
                        <%--3--%><asp:BoundField DataField="nSurveyType" HeaderText="SurveyID" 
                            SortExpression="nSurveyType" ItemStyle-Width="60"  HeaderStyle-CssClass="centered" />
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
