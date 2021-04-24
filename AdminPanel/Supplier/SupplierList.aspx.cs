using MedicalStoreManagementSystem_AdminPanel.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Supplier_SupplierList : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check_for_Valid_User
        if (Session["UserName"] == null)
        {
            Response.Redirect("~/AdminPanel/Login/Login.aspx");
        }
        #endregion Check_for_Valid_User
        if (!Page.IsPostBack)
        {
            FillGridViewSupplier();
        }
    }
    #endregion PageLoad

    #region Fill GridView Supplier
    private void FillGridViewSupplier()
    {
        SupplierBAL balSupplier = new SupplierBAL();
        DataTable dtSupplier = new DataTable();
        dtSupplier = balSupplier.SelectAll();

        if (dtSupplier != null && dtSupplier.Rows.Count > 0)
        {
            gvSupplier.DataSource = dtSupplier;
            gvSupplier.DataBind();
        }
    }
    #endregion Fill GridView Supplier

    #region Delete Employee
    protected void gvSupplier_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteSupplier")
        {
            SupplierBAL balSupplier = new SupplierBAL();
            if (e.CommandArgument != null)
            {
                if (balSupplier.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "deleteAlert();", true);
                    FillGridViewSupplier();
                }
                else
                {
                    lblErrorMessage.Text = balSupplier.Message;
                }

            }
        }
    }
    #endregion Delete Employee

    
}