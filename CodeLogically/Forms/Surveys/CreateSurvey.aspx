<%@ Page Title="Create Survey" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="CreateSurvey.aspx.vb" Inherits="CodeLogically.CreateSurvey" %>
        
<%@ Register Src="~/Controls/PopUp/CreateSurvey.ascx" TagPrefix="uctrl" TagName="CS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="CodeOne Test Site">
    <meta name="author" content="Adam Schaal">
    <link rel="shortcut icon" href="">
    <title>Survey</title>

    <!-- Custom styles for this template -->
    <link type="text/css" rel="stylesheet" href="/Styles/site_css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
    <link type="text/css" rel="stylesheet" href="https://code.jquery.com/ui/1.10.1/themes/base/jquery-ui.css" />
    <link href="/Styles/site_css/main.css" rel="stylesheet" />
    <link href="/Styles/site_css/icomoon.css" rel="stylesheet" />
    <link href="/Styles/site_css/animate-custom.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic'
        rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Raleway:400,300,700' rel='stylesheet'
        type='text/css' />
    <link href='/Styles/site_css/custom.css' rel='stylesheet' type='text/css' />

    <!-- Scripts -->
    <script type="text/javascript" src="/Scripts/site_scripts/jquery.min.js"></script>
    <script type="text/javascript" src="/Scripts/site_scripts/modernizr.custom.js"></script>
    <script type="text/javascript" src="/Scripts/PerPage/CreateSurvey.js?cachebreak=08092014"></script>
    
    <!-- favicon -->
    <link rel="shortcut icon" href="/img/favicon.ico" type="image/x-icon" />    
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
                Create a Survey!
            </h2>
            <p>
                Use our software to create simple surveys!</p>
            <!-- Four columns of text below the header -->
            <div class="col-xs-12 col-sm-12">
                <div id="gridDetails" class="row">
                    <div class="col-8 col-sm-8 col-lg-5 jumbotron">
                        <h4>
                            Create a Dynamic Survey!</h4>
                            <a ID="btnDynamicSurvey" runat="server" class="btn btn-default" href="" role="button">Create &raquo;</a>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-8 col-sm-8 col-lg-5 jumbotron">
                        <h4>
                            Create a Yes/No Survey!</h4>
                            <a ID="btnYesNoSurvey" runat="server" class="btn btn-default" href="" role="button">Create &raquo;</a>
                    </div>
                    <div class="col-8 col-sm-8 col-lg-5 jumbotron">
                        <h4>
                            Create a Multiple Choice Survey!</h4>
                            <a ID="btnMCSurvey" runat="server" class="btn btn-default" href="" role="button">Create &raquo;</a>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-8 col-sm-8 col-lg-5 jumbotron">
                        <h4>
                            Create a Rating Scale Survey!</h4>
                            <%--http://jqueryui.com/slider/#steps--%>
                            <a ID="btnRatingSurvey" runat="server" class="btn btn-default" href="" role="button">Create &raquo;</a>
                    </div>
                    <div class="col-8 col-sm-8 col-lg-5 jumbotron">
                        <h4>
                            Create an Agree/Disagree Survey!</h4>
                            <a ID="btnADSurvey" runat="server" class="btn btn-default" href="" role="button">Create &raquo;</a>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-8 col-sm-8 col-lg-5 jumbotron">
                        <h4>
                            Create a Chain/Tree Survey!</h4>
                            <a ID="btnChainSurvey" runat="server" class="btn btn-default" href="" role="button">Create &raquo;</a>
                    </div>
                </div>
            </div>
        </div>
        <!--/row-->
    </div>
    <!--/.container-->
    
    <div style="clear: both;" />

    <div class="none border" id="divCreateSurvey" title="Create Survey">
        <uctrl:CS ID="Create_Survey" runat="server" />
    </div>

</asp:Content>

