using MedicalStoreManagementSystem_AdminPanel.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Customer_CustomerList : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check_for_Valid_User
        if(Session["UserName"]==null)
        {
            Response.Redirect("~/AdminPanel/Login/Login.aspx");
        }
        #endregion Check_for_Valid_User
        if (!Page.IsPostBack)
        {
            FillGridViewCustomer();
        }
    }
    #endregion PageLoad

    #region Fill GridView Customer
    private void FillGridViewCustomer()
    {
        CustomerBAL balCustomer = new CustomerBAL();
        DataTable dtCustomer = new DataTable();
        dtCustomer = balCustomer.SelectAll();

        if (dtCustomer != null && dtCustomer.Rows.Count > 0)
        {
            gvCustomer.DataSource = dtCustomer;
            gvCustomer.DataBind();
        }
    }
    #endregion Fill GridView Customer

    #region Delete Customer
    protected void gvCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteCustomer")
        {
            CustomerBAL balCustomer = new CustomerBAL();
            if (e.CommandArgument != null)
            {
                if (balCustomer.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "deleteAlert();", true);
                    FillGridViewCustomer();
                }
                else
                {
                    lblErrorMessage.Text = balCustomer.Message;
                }

            }
        }
    }
    #endregion Delete Customer

}