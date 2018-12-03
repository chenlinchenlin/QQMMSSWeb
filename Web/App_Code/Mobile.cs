using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Mobile 的摘要说明
/// </summary>
public class Mobile
{
    public Mobile()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public static void SendSMS(string FaSongUser, string ToUserList, string ContentStr)
    {
        //针对不同的短信猫接口，请修改此方法   
        //根据用户名列表获取手机号码 admin,test,zwl,test123
        DataSet MyDT = ZWL.DBUtility.DbHelperSQL.GetDataSet("select JiaTingDianHua from ERPUser where UserName in('" + ToUserList.Replace(",", "','") + "')");
        for (int i = 0; i < MyDT.Tables[0].Rows.Count; i++)
        {
            if (!string.IsNullOrEmpty(MyDT.Tables[0].Rows[i]["JiaTingDianHua"].ToString()))
            {
                //TWoExpressMail mail = new TWoExpressMail();
                //mail.Body = ContentStr;
                //mail.Subject = "提醒";
                //mail.ToMail = MyDT.Tables[0].Rows[i]["JiaTingDianHua"].ToString();
                //mail.SendMail();
                TWoExpressSms.SendMsg(MyDT.Tables[0].Rows[i]["JiaTingDianHua"].ToString(), ContentStr);
                   
            }
        }
        
        //发送短信
        //MobCallClient.SMS MySms = new MobCallClient.SMS();
        //string StateStr=MySms.SendSMS(ConfigurationManager.AppSettings["enCode"], ConfigurationManager.AppSettings["enPassword"], ConfigurationManager.AppSettings["userName"], MobTelList, ContentStr);
    }


    //发送外部短信，直接是手机号码列表
    public static void SendSMS2(string FaSongUser, string ToUserList, string ContentStr)
    {
        string[] sr=ToUserList.Split(',');
        for (int i = 0; i < sr.Length;i++ )
        {
            if(!string.IsNullOrEmpty(sr[i]))
            {
                string MobTelList = sr[i];
                //TWoExpressMail mail = new TWoExpressMail();
                //mail.Body = ContentStr;
                //mail.Subject = "提醒";
                //mail.ToMail = MobTelList;
                //mail.SendMail();
                TWoExpressSms.SendMsg(MobTelList, ContentStr);
            }
        }
       
        //发送短信
        //MobCallClient.SMS MySms = new MobCallClient.SMS();
        //string StateStr = MySms.SendSMS(ConfigurationManager.AppSettings["enCode"], ConfigurationManager.AppSettings["enPassword"], ConfigurationManager.AppSettings["userName"], MobTelList, ContentStr);
    }
}
