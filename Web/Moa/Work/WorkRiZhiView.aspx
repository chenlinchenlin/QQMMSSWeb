﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkRiZhiView.aspx.cs" Inherits="Work_WorkRiZhiView" %>

<html>
<head>
    <title>深度历险移动办公平台 </title>
    <meta content="yes" name="apple-mobile-web-app-capable" />
    <meta content="index,follow" name="robots" />
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    
    <meta content="minimum-scale=1.0, width=device-width, maximum-scale=0.6667, user-scalable=no"
        name="viewport" />
    <link href="../Style/Mobile/css/Style.css" rel="stylesheet" media="screen" type="text/css" />
    <link href="../Style/Mobile/css/developer-style.css" rel="stylesheet" type="text/css" />

    <script src="../Style/Mobile/javascript/functions.js" type="text/javascript"></script>

    
</head>
<body>
    <form id="form1" runat="server">
    <div id="topbar">
        <div id="title">
            查看工作日志</div>
        <div id="leftnav">
            <a href="../Main.aspx">
                <img alt="home" src="../Style/Mobile/images/home.png" /></a>
        </div>
        <div id="rightnav">
            <a href="WorkRiZhiAdd.aspx">添加</a>
        </div>
    </div>
    <div id="content">
        <span class="graytitle">
            <asp:Label ID="Label1" runat="server"></asp:Label></span>
        <ul class="pageitem">
            <li class="textbox"><span class="header">
                <asp:Label ID="Label4" runat="server"></asp:Label>
                |
                <asp:Label ID="Label5" runat="server"></asp:Label></span>
                <p>
                    <asp:Label ID="Label2" runat="server"></asp:Label><br />
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </p>
            </li>
        </ul>
    </div>
    <div id="footer">
        <a href="#">Powered by 深度历险</a></div>
    </form>
</body>
</html>
