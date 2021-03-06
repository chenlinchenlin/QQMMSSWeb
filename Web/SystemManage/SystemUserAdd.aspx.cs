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

public partial class SystemManage_SystemUserAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ZWL.Common.PublicMethod.CheckSession();
            //设置上传的附件为空
            ZWL.Common.PublicMethod.SetSessionValue("WenJianList","");
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //判断是否超过最大用户限制
            if (ZWL.Common.PublicMethod.IFExists("UserName", "ERPUser", 0, this.TextBox1.Text) == true)
            {
                if (ZWL.Common.PublicMethod.IFExists("Serils", "ERPUser", 0, this.TextBox4.Text) == true)
                {
                    ZWL.BLL.ERPUser MyBuMen = new ZWL.BLL.ERPUser();
                    MyBuMen.UserName = this.TextBox1.Text;
                    MyBuMen.UserPwd = ZWL.Common.DEncrypt.DESEncrypt.Encrypt(this.TextBox2.Text);
                    MyBuMen.TrueName = this.TextBox3.Text;
                    MyBuMen.Serils = this.TextBox4.Text;
                    MyBuMen.Department = this.TextBox5.Text;
                    MyBuMen.JiaoSe = this.TextBox6.Text;
                    MyBuMen.GroupName = this.txt_gn.Text;
                    MyBuMen.ZhiWei = this.TextBox7.Text;
                    MyBuMen.ZaiGang = this.rbl_wstate.SelectedItem.Text;
                    MyBuMen.EmailStr = this.TextBox9.Text;
                    MyBuMen.IfLogin = this.RadioButtonList1.SelectedItem.Text;
                    MyBuMen.Sex = this.rbl_sex.SelectedItem.Text;
                    MyBuMen.BackInfo = this.TextBox11.Text;
                    MyBuMen.BirthDay = this.TextBox12.Text;
                    MyBuMen.MingZu = this.TextBox13.Text;
                    MyBuMen.SFZSerils = this.TextBox14.Text;
                    MyBuMen.HunYing = this.TextBox15.Text;
                    MyBuMen.ZhengZhiMianMao = this.TextBox16.Text;
                    MyBuMen.JiGuan = this.TextBox17.Text;
                    MyBuMen.HuKou = this.TextBox18.Text;
                    MyBuMen.XueLi = this.TextBox19.Text;
                    MyBuMen.ZhiCheng = this.TextBox20.Text;
                    MyBuMen.BiYeYuanXiao = this.TextBox21.Text;
                    MyBuMen.ZhuanYe = this.TextBox22.Text;
                    MyBuMen.CanJiaGongZuoTime = this.TextBox23.Text;
                    MyBuMen.JiaRuBenDanWeiTime = this.TextBox24.Text;
                    MyBuMen.JiaTingDianHua = this.TextBox25.Text;
                    MyBuMen.JiaTingAddress = this.TextBox26.Text;
                    MyBuMen.GangWeiBianDong = this.TextBox27.Text;
                    MyBuMen.JiaoYueBeiJing = this.TextBox28.Text;
                    MyBuMen.GongZuoJianLi = this.TextBox29.Text;
                    MyBuMen.SheHuiGuanXi = this.TextBox30.Text;
                    MyBuMen.JiangChengJiLu = this.TextBox31.Text;
                    MyBuMen.ZhiWuQingKuang = this.TextBox32.Text;
                    MyBuMen.PeiXunJiLu = this.TextBox33.Text;
                    MyBuMen.DanBaoJiLu = this.TextBox34.Text;
                    MyBuMen.NaoDongHeTong = this.TextBox35.Text;
                    MyBuMen.SheBaoJiaoNa = this.TextBox36.Text;
                    MyBuMen.TiJianJiLu = this.TextBox37.Text;
                    MyBuMen.BeiZhuStr = this.TextBox38.Text;
                    MyBuMen.FuJian = ZWL.Common.PublicMethod.GetSessionValue("WenJianList");
                    MyBuMen.Add();
                    //写系统日志
                    ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
                    MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
                    MyRiZhi.DoSomething = "用户添加新用户(" + this.TextBox1.Text + ")";
                    MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                    MyRiZhi.Add();
                    ZWL.Common.MessageBox.ShowAndRedirect(this, "用户信息添加成功！", "SystemUser.aspx");
                }
                else
                {
                    ZWL.Common.MessageBox.Show(this, "该用户编号已经存在，请更改其他用户编号！");
                }
            }
            else
            {
                ZWL.Common.MessageBox.Show(this, "该用户名已经存在，请更改其他用户名！");
            }
        
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
                if (this.CheckBoxList1.Items[i].Selected==true)
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