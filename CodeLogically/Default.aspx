<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
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
    <script type="text/javascript" src="/Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="/Scripts/modernizr.custom.js"></script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="playArea">
        <div id="welcome">
            <h1 class="centered" style="color:white;font-size:72px;">
                CodeOne Test Site
            </h1>
            <h2 class="centered" style="color:white;font-size:24px;">
                Test Site since 1940!
            </h2>
        </div>
        <div id="container">
            <div class="col-md-13  main" >
                <div class="centered">
                </div>
                <br />
                <br />
                <br />
                <br />
                <div class="centered">
                    *** Coming Soon ***
                    <br />
                    <button type="button" class="btn btn-lg btn-default" style="width:250px">Button!</button>
                </div>
            </div>
        </div>
    </div>
    <br />

    <div id="footerwrap">
        <div class="container">
            <h4 class="centered">
                Created by <a href="http://www.adamschaal.com">Cyborg Pirate Ninjas</a></h4>
        </div>
    </div>

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script type="text/javascript" src="../Styles/site_css/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Styles/site_css/docs.min.js"></script>

</asp:Content>
