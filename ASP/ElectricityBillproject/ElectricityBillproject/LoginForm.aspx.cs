using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBillproject
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = "";
            }
        }
        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text; 
            string password = TextBox2.Text; 
            
            if (username == "admin" && password == "admin123")
            {
                    Session["AdminUser"] = username;
                    Response.Redirect("defaultboard.aspx");
                   
            }
            else
            {
                    Label1.Text = "Invalid username or password.";
            }

        }
    }
        
}
