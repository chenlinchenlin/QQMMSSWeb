﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemTiXing.aspx.cs" Inherits="Personal_SystemTiXing" %>
<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
  <link href="../Style/Style.css" type="text/css" rel="STYLESHEET"/>

</head>
<body style=" background:white;">
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img alt="" style=" height:13px; width:13px;" src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;个人设置&nbsp;>>&nbsp;系统提醒
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/Button/Submit.jpg" OnClick="ImageButton1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <%--<img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;--%>
                    </td>
            </tr>
            <tr>
            <td height="3px" colspan="2" style="background-color: #ffffff"></td>
        </tr>
        </table>
    <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
        
        <tr>
            <td align="right" style="width: 170px; background-color: #D6E2F3; height: 25px;" >
                提醒间隔时间：</td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;" >
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
                        <asp:ListItem Value="10">10秒</asp:ListItem>
                        <asp:ListItem Value="30">30秒</asp:ListItem>
                        <asp:ListItem Value="60">1分钟</asp:ListItem>
                        <asp:ListItem Value="300">5分钟</asp:ListItem>
                        <asp:ListItem Value="600">10分钟</asp:ListItem>
                        <asp:ListItem Value="1800">30分钟</asp:ListItem>
                        <asp:ListItem Value="3600">60分钟</asp:ListItem>
                        <asp:ListItem Value="5400">90分钟</asp:ListItem>
                        <asp:ListItem Value="7200">120分钟</asp:ListItem>
                    </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                是否进行提醒：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:DropDownList ID="DropDownList2" runat="server" Width="150px">
                    <asp:ListItem>是</asp:ListItem>
                    <asp:ListItem>否</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        </table></div>
    </form>
</body>
</html>