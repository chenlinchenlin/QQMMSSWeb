<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
  
    <title>
        <%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
<%--    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />--%>
      <script src="../JS/jquery-1.3.2.min.js" type="text/javascript"></script>
    <link href="Style/login.css" type="text/css" rel="STYLESHEET" />

        <script type="text/javascript">
            function Reset()
            {
                for (i = 0; i < window.document.forms[0].elements.length; i++)
                {
                    if (window.document.forms[0].elements[i].type == "text")
                    {
                        window.document.forms[0].elements[i].value = "";
                    }
                }
                $("#Reset").css("background-color", "transparent");
                $("#Reset").css("border", "0px");
                $('#Reset').select();
                return false;
            }

            //window.onload = function () {
            //    var a = document.getElementById("a");//获取div块对象
            //    var Height = document.documentElement.clientHeight;//取得浏览器页面可视区域的宽度
            //    var Width = document.documentElement.clientWidth;//取得浏览器页面可视区域的宽度
            //    var gao1 = a.offsetHeight;//获取div块的高度值
            //    var gao2 = a.offsetWidth;//获取div块的宽度值
            //    var Sgao1 = (Height - gao1) / 2 + "px";
            //    var Sgao2 = (Width - gao2) / 2 + "px";
            //    a.style.top = Sgao1;
            //    a.style.left = Sgao2;
            //    var userName = "xiaoming";
            //    alert(userName);
            //}

            $(function () {
                var a = document.getElementById("a");//获取div块对象
                var Height = document.documentElement.clientHeight;//取得浏览器页面可视区域的宽度
                var Width = document.documentElement.clientWidth;//取得浏览器页面可视区域的宽度
                var gao1 = a.offsetHeight;//获取div块的高度值
                var gao2 = a.offsetWidth;//获取div块的宽度值
                var Sgao1 = (Height - gao1) / 2 + "px";
                var Sgao2 = (Width - gao2) / 2 + "px";
                a.style.top = Sgao1;
                a.style.left = Sgao2;
            });


            //if (document.readyState == "complete")
            //{
            //    var a = document.getElementById("a");//获取div块对象
            //    var Height = document.documentElement.clientHeight;//取得浏览器页面可视区域的宽度
            //    var Width = document.documentElement.clientWidth;//取得浏览器页面可视区域的宽度
            //    var gao1 = a.offsetHeight;//获取div块的高度值
            //    var gao2 = a.offsetWidth;//获取div块的宽度值
            //    var Sgao1 = (Height - gao1) / 2 + "px";
            //    var Sgao2 = (Width - gao2) / 2 + "px";
            //    a.style.top = Sgao1;
            //    a.style.left = Sgao2;
            //}

         </script>

    <style type="text/css">       

    </style>
</head>
<body onload="javascript:form.TxtUserName.focus();">
    <form id="form" runat="server">
        <div class="Login" id="a" >
         
                <div class="userName">               
                        <asp:TextBox ID="TxtUserName" runat="server" Font-Name="微软雅黑" Font-Size="10.5" CssClass  ="userName_textbox" BorderStyle="None"></asp:TextBox>               
                </div>  
                                
                    <div class="userPwd">
                        <asp:TextBox ID="TxtUserPwd" runat="server" Font-Name="微软雅黑" Font-Size="10.5"  CssClass="userPwd_textbox" TextMode="Password">
                        </asp:TextBox>
                    </div>
                   
                    <div class="rem_pass">
                        <asp:CheckBox ID="cbRememberId" runat="server" Text="记住用户" Font-Name="微软雅黑" Font-Size="9"  CssClass="cbRemembe"   />
                        &nbsp;&nbsp;&nbsp;
                        <input id="Reset" type="reset"  style="color:OliveDrab;background-color:transparent;border:0px; float:right; margin-right:65px; "  onclick="Reset" value ="重 置" />
                    </div>

                <div class="btn_submit">
                    <asp:Button ID="submitButton" runat="server" Text="登  录" Font-Name="微软雅黑" Font-Size="10.5"  CssClass="submitBtn"  OnClick="submitButton_Click"  />
                </div>                
        </div>
    </form>

</body>
</html>
