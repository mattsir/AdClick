using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdClick.hroot
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string ip = Sub.urlSub.getIP();
                //Response.Write(ip);
                if (Sub.urlSub.ReadAdminXml())
                {
                    bind();
                }
                else
                {
                    Response.Redirect("/");
                }
            }
        }

        public string GetUrl(string id)
        {
            HRootPassword.Password pass=new HRootPassword.Password();
            string passid = pass.StringEnCode(id);
            return System.Configuration.ConfigurationSettings.AppSettings["URL"].ToString() + "?p=" + passid;
        }

        public void bind()
        {
            Repeater1.DataSource = Sub.urlSub.GetUrlList();
            Repeater1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pro = TextBox1.Text;
            string url = TextBox2.Text;

            Sub.urlSub.InsertPro(pro, url);
            Response.Redirect("./");
        }
    }
}