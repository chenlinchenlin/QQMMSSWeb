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

public partial class GongGao_GongGao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ZWL.Common.PublicMethod.CheckSession();
            DataBindToGridview();

            //设定按钮权限
            if (Request.QueryString["Type"].ToString().Trim() == "单位")
            {
                ImageButton1.Visible = ZWL.Common.PublicMethod.StrIFIn("|004A|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));
                ImageButton5.Visible = ZWL.Common.PublicMethod.StrIFIn("|004M|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));
                ImageButton3.Visible = ZWL.Common.PublicMethod.StrIFIn("|004D|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));
                ImageButton2.Visible = ZWL.Common.PublicMethod.StrIFIn("|004E|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));
            }
            else
            {
                //部门的按钮权限
            }
        }
    }
    public void DataBindToGridview()
    {
        ZWL.BLL.ERPGongGao MyModel = new ZWL.BLL.ERPGongGao();
        DataSet ds = new DataSet();
        if (Request.QueryString["Type"].ToString().Trim() == "单位")
        {
            ds = MyModel.GetList("TypeStr='" + Request.QueryString["Type"].ToString().Trim() + "' and ( TitleStr Like '%" + this.TextBox1.Text + "%' or NoticeType Like '%" + this.TextBox1.Text + "%' ) and (UserBuMen='所有部门' or UserName='" + ZWL.Common.PublicMethod.GetSessionValue("UserName") + "' or ','+UserBuMen+',' like '%," + ZWL.Common.PublicMethod.GetSessionValue("Department") + ",%') order by ID desc");
        }
        else
        {
            ds = MyModel.GetList("TypeStr='" + Request.QueryString["Type"].ToString().Trim() + "' and ( TitleStr Like '%" + this.TextBox1.Text + "%' or  NoticeType Like '%" + this.TextBox1.Text + "%' ) and UserBuMen='" + ZWL.Common.PublicMethod.GetSessionValue("Department") + "' order by ID desc");
        }
        if (ds != null)
        {


            GVData.DataSource = ds;
            GVData.DataBind();
            LabPageSum.Text = Convert.ToString(GVData.PageCount);
            LabCurrentPage.Text = Convert.ToString(((int)GVData.PageIndex + 1));
            this.GoPage.Text = LabCurrentPage.Text.ToString();
        }
    }
    #region  分页方法
    protected void ButtonGo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (GoPage.Text.Trim().ToString() == "")
            {
                Response.Write("<script language='javascript'>alert('页码不可以为空!');</script>");
            }
            else if (GoPage.Text.Trim().ToString() == "0" || Convert.ToInt32(GoPage.Text.Trim().ToString()) > GVData.PageCount)
            {
                Response.Write("<script language='javascript'>alert('页码不是一个有效值!');</script>");
            }
            else if (GoPage.Text.Trim() != "")
            {
                int PageI = Int32.Parse(GoPage.Text.Trim()) - 1;
                if (PageI >= 0 && PageI < (GVData.PageCount))
                {
                    GVData.PageIndex = PageI;
                }
            }

            if (TxtPageSize.Text.Trim().ToString() == "")
            {
                Response.Write("<script language='javascript'>alert('每页显示行数不可以为空!');</script>");
            }
            else if (TxtPageSize.Text.Trim().ToString() == "0")
            {
                Response.Write("<script language='javascript'>alert('每页显示行数不是一个有效值!');</script>");
            }
            else if (TxtPageSize.Text.Trim() != "")
            {
                try
                {
                    int MyPageSize = int.Parse(TxtPageSize.Text.ToString().Trim());
                    this.GVData.PageSize = MyPageSize;
                }
                catch
                {
                    Response.Write("<script language='javascript'>alert('每页显示行数不是一个有效值!');</script>");
                }
            }

            DataBindToGridview();
        }
        catch
        {
            DataBindToGridview();
            Response.Write("<script language='javascript'>alert('请输入有效数字！');</script>");
        }
    }
    protected void PagerButtonClick(object sender, ImageClickEventArgs e)
    {
        //获得Button的参数值
        string arg = ((ImageButton)sender).CommandName.ToString();
        switch (arg)
        {
            case ("Next"):
                if (this.GVData.PageIndex < (GVData.PageCount - 1))
                    GVData.PageIndex++;
                break;
            case ("Pre"):
                if (GVData.PageIndex > 0)
                    GVData.PageIndex--;
                break;
            case ("Last"):
                try
                {
                    GVData.PageIndex = (GVData.PageCount - 1);
                }
                catch
                {
                    GVData.PageIndex = 0;
                }

                break;
            default:
                //本页值
                GVData.PageIndex = 0;
                break;
        }
        DataBindToGridview();
    }
    #endregion
    protected void GVData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ZWL.Common.PublicMethod.GridViewRowDataBound(e);
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        DataBindToGridview();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("GongGaoAdd.aspx?Type="+Request.QueryString["Type"].ToString());
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string IDlist = ZWL.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        if (ZWL.DBUtility.DbHelperSQL.ExecuteSQL("delete from ERPGongGao where ID in (" + IDlist + ")") == -1)
        {
            Response.Write("<script>alert('删除选中记录时发生错误！请重新登陆后重试！');</script>");
        }
        else
        {
            DataBindToGridview();
            //写系统日志
            ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
            MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户删除公告通知";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string IDList = "0";
        for (int i = 0; i < GVData.Rows.Count; i++)
        {
            Label LabVis = (Label)GVData.Rows[i].FindControl("LabVisible");
            IDList = IDList + "," + LabVis.Text.ToString();
        }
        Hashtable MyTable = new Hashtable();
        MyTable.Add("TitleStr", "信息主题");
        MyTable.Add("UserName", "发布人");
        MyTable.Add("TimeStr", "发布时间");

        ZWL.Common.DataToExcel.GridViewToExcel(ZWL.DBUtility.DbHelperSQL.GetDataSet("select TitleStr,UserName,TimeStr from ERPGongGao where ID in (" + IDList + ") order by ID desc"), MyTable, "Excel报表");
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        string CheckStr = ZWL.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        string[] CheckStrArray = CheckStr.Split(',');
        Response.Redirect("GongGaoModify.aspx?Type="+Request.QueryString["Type"].ToString()+"&ID=" + CheckStrArray[0].ToString());
    }
}