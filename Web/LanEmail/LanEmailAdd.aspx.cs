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

public partial class LanEmail_LanEmailAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //if (Request.Params["fanhui"] != null && Request.Params["fanhui"].Trim() != "")
            //{
            //    this.fanhui.Style.Add("display", "");

            //}
            //else
            //{
            //    this.fanhui.Style.Add("display", "");
            //}


            ZWL.Common.PublicMethod.CheckSession();
            //设置上传的附件为空
            ZWL.Common.PublicMethod.SetSessionValue("WenJianList", "");

            try
            {
                this.TextBox2.Text = Request.QueryString["UserName"].ToString();
            }
            catch
            { }

            //检测是回复或者转发
            try
            {
                if (Request.QueryString["Type"].ToString().Trim() == "HuiFu")
                {
                    ZWL.BLL.ERPLanEmail MyModel = new ZWL.BLL.ERPLanEmail();
                    MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
                    //设置页面数据
                    this.TextBox1.Text = "Re：" + MyModel.EmailTitle;
                    this.TextBox2.Text = MyModel.FromUser;
                }
            }
            catch
            { }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            try
            {
                if (Request.QueryString["Type"].ToString().Trim() == "ZhuanFa")
                {
                    ZWL.BLL.ERPLanEmail MyModel = new ZWL.BLL.ERPLanEmail();
                    MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
                    //设置页面数据
                    this.TextBox1.Text = "RW：" + MyModel.EmailTitle;
                    this.TxtContent.Text = MyModel.EmailContent;
                    ZWL.Common.PublicMethod.SetSessionValue("WenJianList", MyModel.FuJian);
                    ZWL.Common.PublicMethod.BindDDL(this.CheckBoxList1, ZWL.Common.PublicMethod.GetSessionValue("WenJianList"));
                }
            }
            catch
            { }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ZWL.BLL.ERPLanEmail MyModel = new ZWL.BLL.ERPLanEmail();

        MyModel.EmailTitle = this.TextBox1.Text;
        MyModel.EmailContent = this.TxtContent.Text;
        MyModel.FuJian = ZWL.Common.PublicMethod.GetSessionValue("WenJianList");
        MyModel.FromUser = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyModel.EmailState = "已发";
        MyModel.TimeStr = DateTime.Now;
        MyModel.ToUser = this.TextBox2.Text.Trim();
        MyModel.Add();

        ZWL.BLL.ERPLanEmailShou MyModelShou = new ZWL.BLL.ERPLanEmailShou();

        MyModelShou.EmailTitle = MyModel.EmailTitle;
        MyModelShou.EmailContent = MyModel.EmailContent;
        MyModelShou.FuJian = MyModel.FuJian;
        MyModelShou.FromUser = MyModel.FromUser;
        MyModelShou.EmailState = "未读";
        MyModelShou.TimeStr = MyModel.TimeStr;
        MyModelShou.ToUser = MyModel.ToUser;

        string[] ToWhoList = this.TextBox2.Text.Trim().Split(',');
        for (int i = 0; i < ToWhoList.Length; i++)
        {
            if (ToWhoList[i].Trim().Length > 0)
            {
                MyModelShou.ShouUser = ToWhoList[i].Trim();
                MyModelShou.Add();
            }
        }

        //写系统日志
        ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
        MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加新邮件(" + this.TextBox1.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        ZWL.Common.MessageBox.ShowAndRedirect(this, "内部邮件发送成功！", "LanEmailShou.aspx");
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string FileNameStr = ZWL.Common.PublicMethod.UploadFileIntoDir(this.FileUpload1, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName));
        //if (ZWL.Common.PublicMethod.GetSessionValue("WenJianList").Trim() == "")
        //{
        //    ZWL.Common.PublicMethod.SetSessionValue("WenJianList", FileNameStr);
        //}
        //else
        //{
        //    ZWL.Common.PublicMethod.SetSessionValue("WenJianList", ZWL.Common.PublicMethod.GetSessionValue("WenJianList") + "|" + FileNameStr);
        //}

        if (ZWL.Common.PublicMethod.GetSessionValue("WenJianList") == null)
        {
            ZWL.Common.PublicMethod.SetSessionValue("WenJianList", FileNameStr);
        }
        else
        {
            if (ZWL.Common.PublicMethod.GetSessionValue("WenJianList").Trim() == "")
            {
                ZWL.Common.PublicMethod.SetSessionValue("WenJianList", FileNameStr);
            }
            else
            {
                ZWL.Common.PublicMethod.SetSessionValue("WenJianList", ZWL.Common.PublicMethod.GetSessionValue("WenJianList") + "|" + FileNameStr);
            }
        }

        ZWL.Common.PublicMethod.BindDDL(this.CheckBoxList1, ZWL.Common.PublicMethod.GetSessionValue("WenJianList"));
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            for (int i = 0; i < this.CheckBoxList1.Items.Count; i++)
            {
                if (this.CheckBoxList1.Items[i].Selected == true)
                {
                    ZWL.Common.PublicMethod.SetSessionValue("WenJianList", ZWL.Common.PublicMethod.GetSessionValue("WenJianList").Replace(this.CheckBoxList1.Items[i].Value, "").Replace("||", "|"));
                }
            }
            ZWL.Common.PublicMethod.BindDDL(this.CheckBoxList1, ZWL.Common.PublicMethod.GetSessionValue("WenJianList"));
        }
        catch
        { }
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        //草稿
        ZWL.BLL.ERPLanEmail MyModel = new ZWL.BLL.ERPLanEmail();

        MyModel.EmailTitle = this.TextBox1.Text;
        MyModel.EmailContent = this.TxtContent.Text;
        MyModel.FuJian = ZWL.Common.PublicMethod.GetSessionValue("WenJianList");
        MyModel.FromUser = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyModel.EmailState = "草稿";
        MyModel.ToUser = this.TextBox2.Text.Trim();

        MyModel.Add();
        //string[] ToWhoList = this.TextBox2.Text.Trim().Split(',');
        //for (int i = 0; i < ToWhoList.Length; i++)
        //{
        //    if (ToWhoList[i].Trim().Length > 0)
        //    {
        //        MyModel.ToUser = ToWhoList[i].Trim();
        //        MyModel.Add();
        //    }
        //}

        //写系统日志
        ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
        MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加新邮件(" + this.TextBox1.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        ZWL.Common.MessageBox.ShowAndRedirect(this, "草稿保存成功！", "LanEmailShou.aspx");
    }
}