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

public partial class DocFile_XueXiXinDeView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			ZWL.Common.PublicMethod.CheckSession();
			ZWL.BLL.ERPXueXiXinDe Model = new ZWL.BLL.ERPXueXiXinDe();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblXinDeTitle.Text=Model.XinDeTitle.ToString();
			this.lblXinDeContent.Text=Model.XinDeContent.ToString();
			this.lblFuJianStr.Text=ZWL.Common.PublicMethod.GetWenJian(Model.FuJianStr.ToString(),"../UpLoadFile/");
			this.lblShenPiContent.Text=Model.ShenPiContent.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			
			//写系统日志
			ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
			MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "用户查看学习心得信息(" + this.lblXinDeTitle.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
