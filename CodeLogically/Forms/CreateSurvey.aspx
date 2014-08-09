<%@ Page Title="Create Survey" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="CreateSurvey.aspx.vb" Inherits="CodeLogically.CreateSurvey" %>

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
    <script type="text/javascript" src="/Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="/Scripts/modernizr.custom.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body
        {
            background: white !important;
        }
    </style>
    <div class="container centered">
        <div class="row row-offcanvas row-offcanvas-right">
            <h2 class="centered" style="color: #3399FF; font-size: 36px;">
                Create a Survey!
            </h2>
            <p>
                Use our software to create simple surveys!</p>
            <!-- Four columns of text below the carousel -->
            <div class="col-xs-12 col-sm-12">
                <div id="gridDetails" class="row">
                    <div class="col-8 col-sm-8 col-lg-5 jumbotron">
                        <h4>
                            Create a Yes/No Survey!</h4>
                            <a class="btn btn-default" href="" role="button">Create &raquo;</a>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-8 col-sm-8 col-lg-5 jumbotron">
                        <h4>
                            Create a Multiple Choice Survey!</h4>
                            <a class="btn btn-default" href="" role="button">Create &raquo;</a>
                    </div>
                    <div class="col-8 col-sm-8 col-lg-5 jumbotron">
                        <h4>
                            Create a Rating Scale Survey!</h4>
                            <a class="btn btn-default" href="" role="button">Create &raquo;</a>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-8 col-sm-8 col-lg-5 jumbotron">
                        <h4>
                            Create a Chain Survey!</h4>
                            <a class="btn btn-default" href="" role="button">Create &raquo;</a>
                    </div>
                </div>
            </div>
        </div>
        <!--/row-->
    </div>
    <!--/.container-->
</asp:Content>
