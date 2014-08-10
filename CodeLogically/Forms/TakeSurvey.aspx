<%@ Page Title="Take Survey" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="TakeSurvey.aspx.vb" Inherits="CodeLogically.TakeSurvey" %>


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
    <!-- Custom styles for this template -->
    <link href='/Styles/custom.css' rel='stylesheet' type='text/css' />
    <script type="text/javascript" src="/Scripts/site_scripts/jquery.min.js"></script>
    <script type="text/javascript" src="/Scripts/site_scripts/modernizr.custom.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body
        {
            background: white !important;
        }
    </style>
    <div id="CreateSurveyPage" class="container centered">
        <div class="row row-offcanvas row-offcanvas-right">
            <h2 class="centered" style="color: #3399FF; font-size: 36px;">
            Take a Survey
            </h2>
            <p>
                Select from our list of surveys!</p>
            
        <!-- Survery Gridview -->
        <div id="Retrieve">
        <div class="rowClassSpace">
            &nbsp;</div>
            <div id="Retrieve_GridViewContainer" class="gridViewContainer">
                <asp:GridView ID="dvgPack" runat="server" CssClass="tableClass" AutoGenerateColumns="false"
                    OnSorting="dgvPack_Sorting" AllowSorting="true" CellPadding="3" Width="880" TabIndex="6"
                    PageSize="10" AllowPaging="true" PagerSettings-Position="TopAndBottom" PagerStyle-HorizontalAlign="Center">
                    <%--runat="server" CssClass="tableClass" AutoGenerateColumns="false"
                    DataKeyNames="nPID" Width="895" TabIndex="7" PageSize="50" AllowPaging="true"
                    PagerSettings-Position="TopAndBottom" PagerStyle-HorizontalAlign="Center">--%>
                    <HeaderStyle ForeColor="Navy" Font-Underline="false" />
                    <Columns>
                        <%--0--%><asp:BoundField DataField="cTitle" HeaderText="Survey Title" SortExpression="cTitle"
                            ItemStyle-Width="430" />
                        <%--1--%><asp:BoundField DataField="cUser" HeaderText="Survey Author" SortExpression="cUser"
                            ItemStyle-Width="230" />
                        <%--2--%><asp:BoundField DataField="dCreated" HeaderText="Date Created" DataFormatString="{0:d}"
                            SortExpression="dCreated" ItemStyle-Width="100" />
                        <%--3--%><asp:BoundField DataField="nSurveyType" HeaderText="SurveyID" ItemStyle-Width="40"
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
    </div>
</asp:Content>
