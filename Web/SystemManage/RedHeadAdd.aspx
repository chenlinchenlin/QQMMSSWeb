﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RedHeadAdd.aspx.cs" Inherits="SystemManage_RedHeadAdd" %>
<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
  <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
  <script language="javascript">
  function PrintTable()
    {
        document.getElementById("PrintHide") .style.visibility="hidden"    
        print();
        document.getElementById("PrintHide") .style.visibility="visible"    
    }
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;红头文件&nbsp;>>&nbsp;添加文件
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Button/Submit.jpg"
                        OnClick="ImageButton1_Click" />
                    <img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;</td>
            </tr>
            <tr>
            <td height="3px" colspan="2" style="background-color: #ffffff"></td>
        </tr>
        </table>
    <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
        
        <tr>
            <td align="right" style="width: 170px; background-color: #D6E2F3; height: 25px;" >
                选择文件：</td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;" >
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="350px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1"
                        ErrorMessage="*请选择文件"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                文件名称：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="TextBox1" runat="server" Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="*文件名称不可以为空"></asp:RequiredFieldValidator></td>
        </tr>
        </table></div>
    </form>
</body>
</html>