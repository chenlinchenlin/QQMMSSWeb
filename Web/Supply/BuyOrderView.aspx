<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuyOrderView.aspx.cs" Inherits="Supply_BuyOrderView" %>

<html>
<head>
    <title>
        <%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
    <link href="../Style/Style.css" type="text/css" rel="STYLESHEET">
    <script language="javascript">
        function PrintTable() {
            document.getElementById("PrintHide").style.visibility = "hidden"
            print();
            document.getElementById("PrintHide").style.visibility = "visible"
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
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;采购订单&nbsp;>>&nbsp;查看采购订单信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <img class="HerCss" onclick="PrintTable()" src="../images/Button/BtnPrint.jpg" />
                    <img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;
                </td>
            </tr>
            <tr>
                <td height="3px" colspan="2" style="background-color: #ffffff">
                </td>
            </tr>
        </table>
        <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    订单名称：
                </td>
                <td style="padding-left: 5px; width: 35%; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblOrderName" runat="server"></asp:Label>
                </td>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    供应商名称：
                </td>
                <td style="padding-left: 5px; width: 35%; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblGongYingShangName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    订单编号：
                </td>
                <td style="padding-left: 5px; width: 35%; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblSerils" runat="server"></asp:Label>
                </td>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    订单类型：
                </td>
                <td style="padding-left: 5px; width: 35%; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblDingDanLeiXing" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    订单描述：
                </td>
                <td style="padding-left: 5px; width: 35%; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblDingDanMiaoShu" runat="server"></asp:Label>
                </td>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    付款日期：
                </td>
                <td style="padding-left: 5px; width: 35%; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblCreateDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    到货日期：
                </td>
                <td style="padding-left: 5px; width: 35%; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblLaiHuoDate" runat="server"></asp:Label>
                </td>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    提醒日期：
                </td>
                <td style="padding-left: 5px; width: 35%; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblTiXingDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    创建人：
                </td>
                <td style="padding-left: 5px; width: 35%; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblChuangJianRen" runat="server"></asp:Label>
                </td>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    负责人：
                </td>
                <td style="padding-left: 5px; width: 35%; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblFuZeRen" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    附件文件：
                </td>
                <td style="padding-left: 5px; width: 35%: height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblFuJianList" runat="server"></asp:Label>
                </td>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    当前状态：
                </td>
                <td style="padding-left: 5px; width: 35%; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblNowState" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    审核人：
                </td>
                <td style="padding-left: 5px; width: 35%; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblShenPiTongGuoRen" runat="server"></asp:Label>
                </td>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    备注说明：
                </td>
                <td style="padding-left: 5px; width: 35%; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblBackInfo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    录入人：
                </td>
                <td style="padding-left: 5px; width: 35%; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblUserName" runat="server"></asp:Label>
                </td>
                <td style="width: 15%; height: 25px; background-color: #D6E2F3" align="right">
                    录入时间：
                </td>
                <td style="padding-left: 5px; width: 35%; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblTimeStr" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <hr style="height: 1px; color: #003333;">
        &nbsp;&nbsp;
        <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="BuyLog.aspx?OrderName=<%=OrderName %>">订单产品记录</a>&nbsp;&nbsp;
        <hr style="height: 1px; color: #003333;">
        <iframe name="RMid" frameborder="0" marginheight="0" marginwidth="0" width="100%"
            height="500" bordercolor="#ffffFF" src="BuyLog.aspx?OrderName=<%=OrderName %>"
            border="0"></iframe>
    </div>
    </form>
</body>
</html>
