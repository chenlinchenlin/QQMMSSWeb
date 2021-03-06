﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PeiXunView.aspx.cs" Inherits="DocFile_PeiXunView" %>

<html>
<head>
    <title>
        <%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
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
            查看培训信息</div>
        <div id="leftnav">
            <a href="../Main.aspx">
                <img alt="home" src="../Style/Mobile/images/home.png" /></a>
        </div>
    </div>
    <div id="content">
        <ul class="pageitem">
            <li class="textbox"><span class="header">培训名称：
                <asp:Label ID="lblPeiXunName" runat="server"></asp:Label>
            </span></li>
            <li class="textbox"><span class="header">培训人：
                <asp:Label ID="lblPeiXunUser" runat="server"></asp:Label>
            </span></li>
            <li class="textbox"><span class="header">参与人：
                <asp:Label ID="lblCanYuUser" runat="server"></asp:Label></span></li>
            <li class="textbox"><span class="header">开始时间：
                <asp:Label ID="lblStartDate" runat="server"></asp:Label></span></li>
            <li class="textbox"><span class="header">结束时间：
                <asp:Label ID="lblEndDate" runat="server"></asp:Label></span></li>
            <li class="textbox"><span class="header">培训目的：
                <asp:Label ID="lblPeiXunMuDi" runat="server"></asp:Label></span></li>
            <li class="textbox"><span class="header">培训内容：
                <asp:Label ID="lblPeiXunNeiRong" runat="server"></asp:Label></span></li>
            <li class="textbox"><span class="header">培训效果：
                <asp:Label ID="lblXiaoGuo" runat="server"></asp:Label></span></li>
            <li class="textbox"><span class="header">备注说明：
                <asp:Label ID="lblBackInfo" runat="server"></asp:Label></span></li>
            <li class="textbox"><span class="header">附件文件：
                <asp:Label ID="lblFuJianList" runat="server"></asp:Label></span></li>
            <li class="textbox"><span class="header">录入人：
                <asp:Label ID="lblUserName" runat="server"></asp:Label></span></li>
            <li class="textbox"><span class="header">录入时间：
                <asp:Label ID="lblTimeStr" runat="server"></asp:Label></span></li>
        </ul>
    </div>
    </form>
</body>
</html>
