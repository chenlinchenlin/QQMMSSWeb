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

public partial class SystemManage_SystemJiaoSeModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ZWL.Common.PublicMethod.CheckSession();

            //加载节点进入CheCkBoxList中
            ZWL.Common.PublicMethod.AddItmesInCheCKList(this.CheckBoxList1);

            ZWL.BLL.ERPJiaoSe MyModel = new ZWL.BLL.ERPJiaoSe();
            MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            if (MyModel!=null)
            {
                this.TextBox1.Text = MyModel.JiaoSeName;
                this.TextBox2.Text = MyModel.BackInfo;
                ZWL.Common.PublicMethod.GetCheckList(this.CheckBoxList1, MyModel.QuanXian);
            }
           

            for (int i = 0; i < this.CheckBoxList1.Items.Count; i++)
            {
                if (this.CheckBoxList1.Items[i].Text.Trim() == "")
                {
                    this.CheckBoxList1.Items[i].Enabled = false;
                    this.CheckBoxList1.Items[i].Attributes.CssStyle.Add("DISPLAY", "none");
                }
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (ZWL.Common.PublicMethod.IFExists("JiaoSeName", "ERPJiaoSe", int.Parse(Request.QueryString["ID"].ToString()), this.TextBox1.Text) == true)
        {
            ZWL.BLL.ERPJiaoSe MyModel = new ZWL.BLL.ERPJiaoSe();
            MyModel.ID = int.Parse(Request.QueryString["ID"].ToString());
            MyModel.JiaoSeName = this.TextBox1.Text;
            MyModel.BackInfo = this.TextBox2.Text;
            MyModel.QuanXian = ZWL.Common.PublicMethod.GetStringFromCheckList(this.CheckBoxList1);
            MyModel.Update();

            //写系统日志
            ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
            MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户修改角色信息(" + this.TextBox1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            ZWL.Common.MessageBox.ShowAndRedirect(this, "角色信息修改成功！", "SystemJiaoSe.aspx");
        }
        else
        {
            ZWL.Common.MessageBox.Show(this, "该角色名已经存在，请更换其他名称！");
        }
    }
}
