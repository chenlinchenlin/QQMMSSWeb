<%@ WebHandler  Language="C#"  Class="getContent" %>
/**
 * Created by visual studio 2010
 * User: xuheng
 * Date: 12-3-6
 * Time: ����21:23
 * To get the value of editor and output the value .
 */
using System;
using System.Web;

public class getContent : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";

        //��ȡ����
        string content = context.Server.HtmlEncode(context.Request.Form["myEditor"]);
        string content1 = context.Server.HtmlEncode(context.Request.Form["myEditor1"]);
        //�������ݿ������������
        //-------------

        //��ʾ
        context.Response.Write("��1���༭����ֵ");
        context.Response.Write(context.Server.HtmlDecode(content));
        context.Response.Write("<br/>��2���༭����ֵ<br/>");
        context.Response.Write(context.Server.HtmlDecode("<textarea style='width:500px;height:300px;'>"+content1+"</textarea><br/>"));
        context.Response.Write("<input type='button' value='�������' onclick='javascript:location.href = \"../_examples/submitFormDemo.html\"' />");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}