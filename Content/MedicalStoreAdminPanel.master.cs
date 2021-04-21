using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_MedicalStoreAdminPanel : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }




    #region btn_Logout :OnClick
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/AdminPanel/Customer/CustomerList.aspx");
    }
    #endregion btn_Logout :OnClick
}
