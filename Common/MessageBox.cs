using System;
using System.Text;
namespace ZWL.Common
{
	/// <summary>
	/// ��ʾ��Ϣ��ʾ�Ի���
    /// ��Ϊ��
    /// 2008.4
	/// </summary>
	public class MessageBox
	{		
		private  MessageBox()
		{			
		}

		/// <summary>
		/// ��ʾ��Ϣ��ʾ�Ի���
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
        public static void Show(System.Web.UI.Page page, string msg)
        {
            //page.ClientScript.RegisterStartupScript(page.GetType(),"message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", @" <link href='../Controls/artdialog/skins/default.css' rel='stylesheet' type='text/css' />
            <script src='../Controls/artdialog/artDialog.js' type='text/javascript'>
            </script><script language='javascript' defer>art.dialog({title:'ϵͳ��ʾ', content: '"+msg.ToString()+"', ok: true });</script>");
        }

		/// <summary>
		/// �ؼ���� ��Ϣȷ����ʾ��
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
		public static void  ShowConfirm(System.Web.UI.WebControls.WebControl Control,string msg)
		{
			//Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');") ;
		}

		/// <summary>
		/// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
		/// <param name="url">��ת��Ŀ��URL</param>
		public static void ShowAndRedirect(System.Web.UI.Page page,string msg,string url)
		{
            string str = @" <link href='../Controls/artdialog/skins/default.css' rel='stylesheet' type='text/css' />
            <script src='../Controls/artdialog/artDialog.js' type='text/javascript'>
            </script><script language='javascript' defer>art.dialog({title:'ϵͳ��ʾ', content: '" + msg.ToString() + "', ok: function () {window.location.href='" + url + "' } });</script>";
			StringBuilder Builder=new StringBuilder();
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", str);

		}
		/// <summary>
		/// ����Զ���ű���Ϣ
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="script">����ű�</param>
		public static void ResponseScript(System.Web.UI.Page page,string script)
		{
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
             
		}

	}
}