﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LanEmailAdd.aspx.cs" Inherits="LanEmail_LanEmailAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>
        <%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
    <link href="../Style/Style.css" type="text/css" rel="STYLESHEET" />
    <script src="../UEditor/editor_config.js" type="text/javascript"></script>
    <script src="../UEditor/editor_all.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../UEditor/themes/default/ueditor.css" />
    <script language="javascript" type="text/javascript">
        function PrintTable() {
            document.getElementById("PrintHide").style.visibility = "hidden"
            print();
            document.getElementById("PrintHide").style.visibility = "visible"
        }

        function beback() {
            alert(document.referrer);
            alert(location.href);
            //            window.history.back(-1); 

            var url = "../.." + document.referrer.substring(document.referrer.indexOf("/Web/"), document.referrer.length);
            alert(url);
            //window.location.href = url;

            window.frames[2].location.href = url;

            //            alert(window.location.href);
            //            window.open(url);

            if (navigator.userAgent.indexOf("Firefox") != -1) {
                //ff浏览器，从根目录开始拼接     
            }
            else {
                //ie浏览器,从当前目录开始
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img src="../images/BanKuaiJianTou.gif" />
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;内部邮件&nbsp;>>&nbsp;撰写新邮件
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Button/Submit.jpg"
                        OnClick="ImageButton1_Click" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/Button/SubmitCaoGao.jpg"
                        OnClick="ImageButton4_Click" />
                    &nbsp;<img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="window.location.reload()" src="../images/Button/Btnrefresh.jpg" />&nbsp;
                    <img class="HerCss" id="fanhui" onclick="javascript:history.go(-1);" src="../images/Button/BtnExit.jpg" />
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td height="3px" colspan="2" style="background-color: #ffffff">
                </td>
            </tr>
        </table>
        <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td align="right" style="width: 170px; background-color: #D6E2F3; height: 25px;">
                    邮件主题：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                    <asp:TextBox ID="TextBox1" runat="server" Width="350px" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                    接收人：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="TextBox2" runat="server" Width="350px" onfocus="this.blur()"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=ERPUser&LieName=UserName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('TextBox2').value=wName;}"
                        src="../images/Button/search.gif" />
                    &nbsp; &nbsp;
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectGroup.aspx?TableName=ERPUser&LieName=UserName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('TextBox2').value=wName;}"
                        src="../images/Button/Group.gif" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                    附件：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal"
                        RepeatColumns="4">
                    </asp:CheckBoxList>
                    &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False"
                        ImageAlign="AbsMiddle" ImageUrl="../images/Button/DelFile.jpg" OnClick="ImageButton3_Click" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                    上传附件：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="350px" />
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/Button/UpLoad.jpg"
                        OnClick="ImageButton2_Click" CausesValidation="False" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                    邮件内容：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="TxtContent" runat="server" Width="100%" Rows="10" TextMode="MultiLine"></asp:TextBox>
                    <script type="text/javascript">
                        var editor = new baidu.editor.ui.Editor({ id: 'editor', minFrameHeight: 300 }); editor.render("TxtContent");
                    </script>
                </td>
            </tr>
        </table>
    </div>
    <script language="javascript" type="text/javascript">
        window.onload = show();

        function show() {

            var url = document.URL;
            var fanhui = url.indexOf("fanhui=0");
            if (fanhui != "-1") {
                document.getElementById("fanhui").style.display = "";
            }
            else {
                document.getElementById("fanhui").style.display = "none";
            }
        }
    </script>
    </form>
</body>
</html>
