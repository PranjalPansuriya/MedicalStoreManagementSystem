using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using MedicalStoreManagementSystem_AdminPanel.BAL;
using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Selling_GenerateInvoice : System.Web.UI.Page
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
        
        if(!Page.IsPostBack)
        {
            FillCustomerDetails();
            FillGridViewProductList();
        }
    }
    #endregion Page_Load

    #region FillCustomerDetail
    protected void FillCustomerDetails()
    {
        CustomerBAL balCustomer = new CustomerBAL();
        CustomerENT entCustomer = new CustomerENT();
        entCustomer = balCustomer.SelectByPK(Convert.ToInt32(Session["CustomerID"]));

        if (entCustomer != null)
        {
            lblCustomerName.Text = Convert.ToString(entCustomer.CustomerName);
            lblPaymentMethod.Text = Convert.ToString(entCustomer.PaymentMethod);

            DateTime ed;
            ed = Convert.ToDateTime(entCustomer.OrderDate.Value.ToString());
            lblOrderDate.Text = ed.ToString("dd-MM-yyyy");
            lblMobileNo.Text = Convert.ToString(entCustomer.ContactNo);
            lblTotalAmount.Text = Convert.ToString(entCustomer.TotalAmount) + " ₹";
            lblOrderID.Text = Convert.ToString(Session["CustomerID"]);
        }
    }
    #endregion FillCustomerDetail


    #region FillGridViewProductList
    protected void FillGridViewProductList()
    {
        CustomerBAL balCustomer = new CustomerBAL();
        DataTable dt = new DataTable();
        dt = balCustomer.SelectAllProductByCustomerID(Convert.ToInt32(Session["CustomerID"]));
        if (dt.Rows.Count > 0)
        {
            gvProductList.DataSource = dt;
            gvProductList.DataBind();
            Session["CustomerID"] = null;
        }
        else
        {
            gvProductList.Visible = false;
            lblErrorMessage.Text = "No Rows Found";
        }
    }
    #endregion FillGridViewProductList




    
}