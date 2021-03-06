﻿<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.vb" Inherits="CodeLogically._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="CodeOne Test Site">
    <meta name="author" content="Adam Schaal">
    <link rel="shortcut icon" href="">
    <title>CodeOne Test Site</title>
    
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
    
    <!-- favicon -->
    <link rel="shortcut icon" href="/img/favicon.ico?v=2" type="image/x-icon" />    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="playArea">
        <div id="welcome">
            <h1 class="centered" style="color: white; font-size: 72px;">
                CodeOne Test Site
            </h1>
            <h2 class="centered" style="color: white; font-size: 24px;">
                Test Site since 1940!
            </h2>
        </div>
        <div id="container">
            <div class="col-xs-12 col-sm-12">
                <div id="gridDetails" class="row">
                    <div class="col-md-2">
                    </div>
                    <div class="col-8 col-sm-8 col-lg-4">
                        <h4 style="color:White">
                            View Project Survey!</h4>
                        <a id="btnViewSurvey" runat="server" class="btn btn-default" href="/Forms/Surveys/Surveys.aspx" role="button">View
                            &raquo;</a>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-8 col-sm-8 col-lg-4">
                        <h4 style="color:White">
                            View Project X!</h4>
                        <a id="btnViewX" runat="server" class="btn btn-default" href="" role="button">View &raquo;</a>
                    </div>
                </div>
            <br />
            <br />
            <br />
            <br />
            <div class="centered">
                *** Coming Soon ***
                <br />
                <button type="button" class="btn btn-lg btn-default" style="width: 250px">
                    Button!</button>
            </div>
            </div>
        </div>
    </div>
    <br />
    <div id="footerwrap">
        <div class="container">
            <h2 class="centered" style="color: white;">
                Created by <a href="http://www.adamschaal.com">A</a>/ 
                           <a href="">S</a>/
                           <a href="http://www.leightoneash.com">L</a>
            </h2>
        </div>
    </div>
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script type="text/javascript" src="../Styles/site_css/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Styles/site_css/docs.min.js"></script>
</asp:Content>
