<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XinChouAdd.aspx.cs" Inherits="DocFile_XinChouAdd" %>
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
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;薪酬数据&nbsp;>>&nbsp;添加信息
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
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		薪酬管理名称：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtXCName" runat="server" Width="350px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtXCName" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		简要说明：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtJianJie" runat="server" Width="350px" Height="60px" TextMode="MultiLine"></asp:TextBox></td></tr>
    <tr>
        <td colspan="2" style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:Label ID="Label1" runat="server"></asp:Label></td>
    </tr>
</table>
		</div>
	</form>
</body>
</html>
