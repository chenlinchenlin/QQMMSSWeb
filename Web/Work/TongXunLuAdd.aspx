﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TongXunLuAdd.aspx.cs" Inherits="Work_TongXunLuAdd" %>
<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
  <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
  <script src="../UEditor/editor_config.js" type="text/javascript"></script>
    <script src="../UEditor/editor_all.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../UEditor/themes/default/ueditor.css" />
        <script src="../Controls/My97DatePicker/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
  <script type="text/javascript" language="javascript">
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
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;通讯簿&nbsp;>>&nbsp;添加联系人
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
                所属类别：</td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;" >
                    <asp:TextBox ID="TextBox1" onfocus="this.blur()" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?type=tongxunlu&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('TextBox1').value=wName;}"
                        src="../images/Button/search.gif" /></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                是否共享：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>是</asp:ListItem>
                    <asp:ListItem Selected="True">否</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td colspan="2" style="padding-left: 5px; height: 25px; background-color: #ffffff;
                text-align: center">
                <strong>个人信息</strong></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                姓名：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox2" runat="server" Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                性别：</td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:RadioButtonList ID="RBL_Sex" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                生日：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox4" onfocus="this.blur()" runat="server" Width="350px"></asp:TextBox>
                <img onclick="WdatePicker({el:'<%=TextBox4.ClientID %>'})" src="../Controls/My97DatePicker/My97DatePicker/skin/datePicker.gif" width="16" height="22" align="absmiddle">
</td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                昵称：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox5" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                职务：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox6" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                配偶：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox7" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                子女：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox8" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="padding-left: 5px; height: 25px; background-color: #ffffff;
                text-align: center">
                <strong>联系方式（单位）</strong></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                单位名称：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox9" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                单位地址：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox10" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                单位邮编：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox11" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                单位电话：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox12" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                单位传真：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox13" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="padding-left: 5px; height: 25px; background-color: #ffffff;
                text-align: center">
                <strong>联系方式（家庭）</strong></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                家庭住址：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox14" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                家庭邮编：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox15" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                家庭电话：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox16" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                手机：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox17" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                备用手机：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox18" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                电子邮件：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox19" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                QQ号码：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox20" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                MSN：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:TextBox ID="TextBox21" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                备注：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
               <asp:TextBox ID="TxtContent" runat="server" Width="100%" Rows="10" TextMode="MultiLine"></asp:TextBox>
                    <script type="text/javascript">
                        var editor = new baidu.editor.ui.Editor({ id: 'editor', minFrameHeight: 300 }); editor.render("TxtContent");
                    </script>
            </td>
        </tr>
        </table></div>
    </form>
</body>
</html>