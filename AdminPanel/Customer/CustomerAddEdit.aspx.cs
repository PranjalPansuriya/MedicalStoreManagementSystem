using MedicalStoreManagementSystem_AdminPanel.BAL;
using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Customer_CustomerAddEdit : System.Web.UI.Page
{
    #region Page_Load
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
            if (Request.QueryString["CustomerID"] == null)
            {
                lblHeading.Text = "Customer Add";
            }
            else
            {
                lblHeading.Text = "Customer Edit";
                FillCustomerForm(Convert.ToInt32(Request.QueryString["CustomerID"]));
            }
        }
    }
    #endregion Page_Load

    #region FillCustomerForm
    private void FillCustomerForm(SqlInt32 CustomerID)
    {
        CustomerBAL balCustomer = new CustomerBAL();
        CustomerENT entCustomer = new CustomerENT();
        entCustomer = balCustomer.SelectByPK(CustomerID);

        #region Fill Controls
        txtCustomerName.Text = Convert.ToString(entCustomer.CustomerName);
        txtContactNo.Text = Convert.ToString(entCustomer.ContactNo);
        #endregion Fill Controls

    }

    #endregion FillCustomerForm

    #region btnSave : Onclick
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMsg = "";
       
        if (txtContactNo.Text == "")
        {
            strErrorMsg += "- Enter ContactNo </br>";
        }
        if (txtCustomerName.Text == "")
        {
            strErrorMsg += "- Enter CustomerName </br>";
        }
        
        if (strErrorMsg != "")
        {
            lblErrorMessage.Text = strErrorMsg;
            return;
        }

        #endregion Server Side Validation

        #region Collect Data
        CustomerENT entCustomer = new CustomerENT();
        
        if (txtContactNo.Text != "")
        {
            entCustomer.ContactNo = txtContactNo.Text.Trim();
        }
        if (txtCustomerName.Text.Trim() != "")
        {
            entCustomer.CustomerName = txtCustomerName.Text.Trim();
            //also adding payment method & Total amount here
            entCustomer.PaymentMethod = "By Cash";
            entCustomer.TotalAmount = 0;
        }
        
        #endregion Collect Data
        CustomerBAL balCustomer = new CustomerBAL();
        if (Request.QueryString["CustomerID"] == null)
        {
            #region Customer Add
            if (balCustomer.Insert(entCustomer))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "insertAlert();", true);
                txtContactNo.Text = "";
                txtCustomerName.Text = "";

            }
            else
            {
                lblErrorMessage.Text = balCustomer.Message;
            }
            #endregion Customer Add
        }
        else
        {
            #region Customer Edit
            entCustomer.CustomerID = Convert.ToInt32(Request.QueryString["CustomerID"]);
            if (balCustomer.Update(entCustomer))
            {
                txtContactNo.Text = "";
                txtCustomerName.Text = "";
                Response.Redirect("~/AdminPanel/Customer/CustomerList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balCustomer.Message;
            }
            #endregion Customer Edit
        }
    }
    #endregion btnSave : Onclick

    #region btnCancel :  Onclick
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtContactNo.Text = "";
        txtCustomerName.Text = "";
        Response.Redirect("~/AdminPanel/Customer/CustomerList.aspx");
    }
    #endregion btnCancel :  Onclick
}