using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment6.ShopWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void MemberRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ShopWebApp/MemberRegistration.aspx");
        }

        protected void MemberLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MemberLogin.aspx");
        }

        protected void MemberPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Protected/Member_Folder/Member.aspx");
        }

        protected void StaffPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~Protected/Staff_Folder/Staff.aspx");
        }
    }
}