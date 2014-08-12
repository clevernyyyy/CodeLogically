<%@ Page Title="Surveys" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Surveys.aspx.vb" Inherits="CodeLogically.Surveys" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="CodeOne Test Site">
    <meta name="author" content="Adam Schaal">
    <link rel="shortcut icon" href="">
    <title>Surveys</title>

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

    <!-- Scripts -->
    <script type="text/javascript" src="/Scripts/site_scripts/jquery.min.js"></script>
    <script type="text/javascript" src="/Scripts/site_scripts/modernizr.custom.js"></script>
    <script type="text/javascript" src="/Scripts/PerPage/TakeSurvey.js?cachebreak=08092014"></script>
    
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
    <div id="divSurveyMainPage" runat="server" class="container">
    
        <p>I think we should have a login here</p>
        <p>If there is no user create a login</p>    
        <br />
        <p>We should probably make a login control for this</p>
        <p>So that we can implement it everywhere if needed</p>
        <br />
        <p>I can even create a second database specifically for logins and user management</p>
        <p>logins can be another one of our "modules"</p>
        
        <br />
        <p>If they succesfully login in they'll see something like below, but bigger, bolder and cooler looking</p>
        <br />
        <br />
        <br />
        <br />
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
    </div>
</asp:Content>
