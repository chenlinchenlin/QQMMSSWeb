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

public partial class DocFile_PeiXunAdd : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			ZWL.Common.PublicMethod.CheckSession();
			//设置上传的附件为空
			 ZWL.Common.PublicMethod.SetSessionValue("WenJianList", "");
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		ZWL.BLL.ERPPeiXun Model = new ZWL.BLL.ERPPeiXun();
		
		Model.PeiXunName=this.txtPeiXunName.Text.ToString();
		Model.PeiXunUser=this.txtPeiXunUser.Text.ToString();
		Model.CanYuUser=this.txtCanYuUser.Text.ToString();
		Model.StartDate=this.txtStartDate.Text.ToString();
		Model.EndDate=this.txtEndDate.Text.ToString();
		Model.PeiXunMuDi=this.txtPeiXunMuDi.Text.ToString();
		Model.PeiXunNeiRong=this.txtPeiXunNeiRong.Text.ToString();
		Model.XiaoGuo=this.txtXiaoGuo.Text.ToString();
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		Model.FuJianList=ZWL.Common.PublicMethod.GetSessionValue("WenJianList");
		Model.UserName=ZWL.Common.PublicMethod.GetSessionValue("UserName");
		Model.TimeStr=DateTime.Now;
		
		Model.Add();
		
		//写系统日志
		ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
		MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加培训信息(" + this.txtPeiXunName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        ZWL.Common.MessageBox.ShowAndRedirect(this, "培训信息添加成功！", "PeiXun.aspx");
	}
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string FileNameStr = ZWL.Common.PublicMethod.UploadFileIntoDir(this.FileUpload1, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName));
        if (ZWL.Common.PublicMethod.GetSessionValue("WenJianList").Trim() == "")
        {
            ZWL.Common.PublicMethod.SetSessionValue("WenJianList", FileNameStr);
        }
        else
        {
            ZWL.Common.PublicMethod.SetSessionValue("WenJianList", ZWL.Common.PublicMethod.GetSessionValue("WenJianList") + "|" + FileNameStr);
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

    
}
