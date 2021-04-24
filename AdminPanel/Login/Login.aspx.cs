using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Login_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region btnLogin : OnClick
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if(txtUserName.Text.Trim() != "admin")
        {
            lblLogin.Text = "Invalid UserName / Password";
        }
        else
        {
            if(txtPassword.Text.Trim()!="admin")
            {
                lblLogin.Text = "Invalid UserName / Password";
            }
            else
            {
                Session["UserName"] = txtUserName.Text.ToString();
                Session["Password"] = txtPassword.Text.ToString();

                Response.Redirect("~/AdminPanel/AdminIndex/index.aspx");
            }
        }
        
    }
    #endregion btnLogin : OnClick
}