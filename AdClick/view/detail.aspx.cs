using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdClick.hroot
{
    public partial class detail : System.Web.UI.Page
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


                    Repeater1.DataSource = Sub.urlSub.GetClickList(p);
                    Repeater1.DataBind();

                }
            }
        }
        
    }
}