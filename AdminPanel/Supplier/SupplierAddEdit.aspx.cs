using MedicalStoreManagementSystem_AdminPanel.BAL;
using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Supplier_SupplierAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["SupplierID"] == null)
            {
                lblHeading.Text = "Supplier Add";
            }
            else
            {
                lblHeading.Text = "Supplier Edit";
                FillSupplierForm(Convert.ToInt32(Request.QueryString["SupplierID"]));
            }
        }
    }
    #endregion PageLoad

    #region FillSupplierForm
    private void FillSupplierForm(SqlInt32 SupplierID)
    {
        SupplierBAL balSupplier = new SupplierBAL();
        SupplierENT entSupplier = new SupplierENT();
        entSupplier = balSupplier.SelectByPK(SupplierID);

        #region Fill Controls
        txtSupplierName.Text = Convert.ToString(entSupplier.SupplierName);
        txtAddress.Text = Convert.ToString(entSupplier.Address);
        txtContactNo.Text = Convert.ToString(entSupplier.ContactNo);
        #endregion Fill Controls

    }

    #endregion FillSupplierForm

    #region btnSave : Onclick
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMsg = "";
        if (txtSupplierName.Text == "")
        {
            strErrorMsg += "- Enter Name </br>";
        }
        if (txtAddress.Text == "")
        {
            strErrorMsg += "- Enter Address </br>";
        }
        if (txtContactNo.Text == "")
        {
            strErrorMsg += "- Enter ContactNo </br>";
        }
        
        if (strErrorMsg != "")
        {
            lblErrorMessage.Text = strErrorMsg;
            return;
        }

        #endregion Server Side Validation

        #region Collect Data
        SupplierENT entSupplier = new SupplierENT();
        if (txtAddress.Text.Trim() != "")
        {
            entSupplier.Address = txtAddress.Text.Trim();
        }
        if (txtSupplierName.Text.Trim() != "")
        {
            entSupplier.SupplierName = txtSupplierName.Text.Trim();
        }
        if (txtContactNo.Text != "")
        {
            entSupplier.ContactNo = txtContactNo.Text.Trim();
        }
        
        #endregion Collect Data
        SupplierBAL balSupplier = new SupplierBAL();
        if (Request.QueryString["SupplierID"] == null)
        {
            #region Supplier Add
            if (balSupplier.Insert(entSupplier))
            {
                txtSupplierName.Text = "";
                txtAddress.Text = "";
                txtContactNo.Text = "";
                Response.Redirect("~/AdminPanel/Supplier/SupplierList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balSupplier.Message;
            }
            #endregion Supplier Add
        }
        else
        {
            #region Supplier Edit
            entSupplier.SupplierID = Convert.ToInt32(Request.QueryString["SupplierID"]);
            if (balSupplier.Update(entSupplier))
            {
                txtSupplierName.Text = "";
                txtAddress.Text = "";
                txtContactNo.Text = "";
                Response.Redirect("~/AdminPanel/Supplier/SupplierList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balSupplier.Message;
            }
            #endregion Supplier Edit
        }
    }
    #endregion btnSave : Onclick

    #region btnCancel :  Onclick
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtSupplierName.Text = "";
        txtAddress.Text = "";
        txtContactNo.Text = "";
        Response.Redirect("~/AdminPanel/Supplier/SupplierList.aspx");
    }
    #endregion btnCancel :  Onclick
}