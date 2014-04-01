using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdClick
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["p"] == null)
                {

                }
                else
                {
                    string p = Request.QueryString["p"].ToString();
                    if (p.Length>0)
                    {
                        HRootPassword.Password PASS = new HRootPassword.Password();
                        string ps = PASS.StringDeCode(p);
                        if (ps.Length > 0)
                        {
                            string url = Sub.urlSub.getURL(ps);
                            if (url.Length > 0)
                            {

                                Sub.urlSub.InsertURL(ps);
                                Response.Redirect(url);
                            }
                        }
                    }
                }
            }
        }
    }
}