using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class NetMail_NetEmailAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ZWL.Common.PublicMethod.CheckSession();
            try
            {
                this.TextBox2.Text = Request.QueryString["Emaillist"].ToString();
            }
            catch
            { }
            //设置上传的附件为空
            ZWL.Common.PublicMethod.SetSessionValue("WenJianList", "");


            //检测是回复或者转发
            try
            {
                if (Request.QueryString["Type"].ToString().Trim() == "HuiFu")
                {
                    ZWL.BLL.ERPNetEmail MyModel = new ZWL.BLL.ERPNetEmail();
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
                    ZWL.BLL.ERPNetEmail MyModel = new ZWL.BLL.ERPNetEmail();
                    MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
                    //设置页面数据
                    this.TextBox1.Text = "RW：" + MyModel.EmailTitle;
                    this.TxtContent.Text = MyModel.EmailContent;
                }
            }
            catch
            { }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ZWL.BLL.ERPNetEmail MyModel = new ZWL.BLL.ERPNetEmail();
        MyModel.EmailTitle = this.TextBox1.Text;
        MyModel.EmailContent = this.TxtContent.Text;
        string filelist = ZWL.Common.PublicMethod.GetSessionValue("WenJianList");
        if (filelist != null && filelist != "")
        {
            MyModel.FuJian = ZWL.Common.PublicMethod.GetSessionValue("WenJianList");
        }
        else
        {
            MyModel.FuJian = null;
        }

        MyModel.FromUser = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyModel.EmailState = "已发";
        MyModel.TimeStr = DateTime.Now;
        MyModel.ToUser = this.TextBox2.Text.Trim();

        try
        {
          

            //获取现有设置
            ZWL.BLL.ERPPOPAndSMTP MySMTPModel = new ZWL.BLL.ERPPOPAndSMTP();
            MySMTPModel.GetModel(int.Parse(ZWL.Common.PublicMethod.GetSessionValue("UserID")));
            //发送邮件到Internet地址

            //FengGu.Common.MailSender.Send(MySMTPModel.SMTPServer, MySMTPModel.SMTPFromEmail, MyModel.ToUser, MyModel.EmailTitle, MyModel.EmailContent, true, Encoding.UTF8, true, MyModel.FuJian);
            Pop3ForJmail.SendMail(MySMTPModel.SMTPUserName, MySMTPModel.SMTPUserPwd, MySMTPModel.SMTPServer, MyModel.EmailTitle, MyModel.EmailContent, MySMTPModel.SMTPFromEmail, MyModel.ToUser, MyModel.FuJian);

            MyModel.Add();

            ZWL.Common.MessageBox.ShowAndRedirect(this, "Internet邮件添加成功！", "NetMailShou.aspx");
        }
        catch
        {
            MyModel.EmailState = "草稿";

            MyModel.Add();

            Response.Write("<script>alert('发送邮件时发生错误，请检查您的邮件参数设置是否正确！已保存至草稿！');</script>");
        }
        //写系统日志
        ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
        MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加新邮件(" + this.TextBox1.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string FileNameStr = ZWL.Common.PublicMethod.UploadFileIntoDir(this.FileUpload1, this.FileUpload1.FileName.Split('.')[0] + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName));

        //string FileNameStr = FileUpload1.PostedFile.FileName.ToString(); ;

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
        ZWL.BLL.ERPNetEmail MyModel = new ZWL.BLL.ERPNetEmail();

        MyModel.EmailTitle = this.TextBox1.Text;
        MyModel.EmailContent = this.TxtContent.Text;
        MyModel.FuJian = ZWL.Common.PublicMethod.GetSessionValue("WenJianList");
        MyModel.FromUser = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyModel.EmailState = "草稿";
        MyModel.TimeStr = DateTime.Now;
        MyModel.ToUser = this.TextBox2.Text.Trim();

        MyModel.Add();

        //写系统日志
        ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
        MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加新邮件(" + this.TextBox1.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        ZWL.Common.MessageBox.ShowAndRedirect(this, "Internet邮件添加成功！", "NetMailShou.aspx");
    }
}