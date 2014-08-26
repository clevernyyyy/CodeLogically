<%@ Page Title="Surveys" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="Surveys.aspx.vb" Inherits="CodeLogically.Surveys" %>

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
    <script type="text/javascript" src="/Scripts/Surveys/Surveys.js?cachebreak=08162014"></script>
    
    <!-- favicon -->
    <link rel="shortcut icon" href="/img/favicon.ico?v=2" type="image/x-icon" />    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body
        {
            background: white !important;
        }
    </style>
    <div id="divSurveyMainPage" runat="server" class="container">

        <div class="col-xs-12 col-sm-12">
            <div id="gridDetails" class="row">
                <div class="col-8 col-sm-8 col-lg-5 jumbotron">
                    <h4>
                        Create a Survey!</h4>
                        <a ID="btnCreateSurvey" runat="server" class="btn btn-default" href="/Forms/Surveys/CreateSurvey.aspx" role="button">Create &raquo;</a>
                </div>
                <div class="col-md-2">
                </div>
                <div class="col-8 col-sm-8 col-lg-5 jumbotron">
                    <h4>
                        Take a Survey!</h4>
                        <a ID="btnTakeSurvey" runat="server" class="btn btn-default" href="/Forms/Surveys/TakeSurvey.aspx" role="button">Take &raquo;</a>
                </div>
            </div>
        </div>
        <!--/row-->
    </div>
    <!--/.container-->
    
    <div style="clear: both;" />

</asp:Content>
