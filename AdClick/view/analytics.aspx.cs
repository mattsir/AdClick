using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdClick.view
{
    public partial class analytics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Sub.urlSub.ReadAdminXml())
                {
                    bind();
                }

            }
        }


        public void bind()
        {
            if (Request.QueryString["id"] != null)
            {

                string p = Request.QueryString["id"].ToString();
                if (p.Length > 0)
                {
                    Sub.urlSub.UpdateClickArea(p);
                    string[] arr = Sub.urlSub.getCount(p);
                    Product.InnerText = arr[0];
                    Total.InnerText = arr[1];
                    Repeater2.DataSource = Sub.urlSub.GetClickList(p, "area");
                    Repeater2.DataBind();

                    Repeater3.DataSource = Sub.urlSub.GetClickList(p, "region");
                    Repeater3.DataBind();

                    Repeater4.DataSource = Sub.urlSub.GetClickList(p, "city");
                    Repeater4.DataBind();

                    SysRpt.DataSource = Sub.urlSub.GetClickList(p, "system");
                    SysRpt.DataBind();

                    BroRpt.DataSource = Sub.urlSub.GetClickList(p, "browser");
                    BroRpt.DataBind();
                }
            }
        }
        
    }
}