﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class DsoFramer_ReadFile : System.Web.UI.Page
{
   public string FileType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
             FileType = Request.QueryString["FilePath"].ToString().Remove(0, Request.QueryString["FilePath"].ToString().LastIndexOf('.') + 1);
            //if (FileType.ToLower().Trim() == "doc" || FileType.ToLower().Trim() == "xls" || FileType.ToLower().Trim() == "ppt")
            //{

            //}
            //else
            //{
            //    Response.Write("<script>alert('该文件格式不能进行在线阅读！');window.close();</script>");
            //}
        }
        catch
        {
            Response.Write("<script>alert('该文件格式不能进行在线阅读！');window.close();</script>");
        }
    }
}
