using MedicalStoreManagementSystem_AdminPanel;
using MedicalStoreManagementSystem_AdminPanel.BAL;
using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Selling_SellingPanel : System.Web.UI.Page
{
    ProductENT entProductGlobal = new ProductENT();

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check_for_Valid_User
        if (Session["UserName"] == null)
        {
            Response.Redirect("~/AdminPanel/Login/Login.aspx");
        }
        #endregion Check_for_Valid_User

        if (Request.QueryString["CustomerID"] == null)
        {
            lblMainContent.Visible = false;
            lblAddCustomer.Visible = true;
        }
        else
        {
            lblMainContent.Visible = true;
            lblAddCustomer.Visible = false;
            FillGridviewShoppingCart();
        }
        if (!Page.IsPostBack)
        {
            FillDropDownListProductCategory();
            CalculateTotal();
        }
    }
    #endregion PageLoad

    #region FillDropDownListProductCategory
    public void FillDropDownListProductCategory()
    {
        CommonFillMethods.FillDropDownListProductCategory(ddlProductCategory);
    }
    #endregion FillDropDownListProductCategory

    #region FillDropDownListProductName
    public void FillDropDownListProduct()
    {
        CommonFillMethods.FillDropDownListProductNameByProductCategory(ddlProductName , Convert.ToInt32(ddlProductCategory.SelectedValue));
    }
    #endregion FillDropDownListProductName

    #region ddlProductName_SelectedIndexChanged
    protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        ProductBAL balProduct = new ProductBAL();
        ProductENT entProduct = new ProductENT();
        entProduct = balProduct.SelectByPK(Convert.ToInt32(ddlProductName.SelectedValue));
        //Add Data to our global ENT entProductGlobal
        entProductGlobal = balProduct.SelectByPK(Convert.ToInt32(ddlProductName.SelectedValue));

        txtStockAvailable.Text = Convert.ToString(entProduct.Quantity);
        txtPrice.Text = Convert.ToString(entProduct.PricePerUnit);
        if (entProduct.Quantity <= 15)
        {
            txtStockAvailable.CssClass = "text-lg text-danger form-control";
            txtStockAvailable.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            txtStockAvailable.CssClass = "text-primary text-lg form-control";
            txtStockAvailable.BorderColor = System.Drawing.Color.Empty;
        }


    }
    #endregion ddlProductName_SelectedIndexChanged

    #region btn_AddToCart : OnClick
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        #region Check for Sufficient Quantity
        if (Convert.ToInt32(txtStockAvailable.Text.ToString().Trim()) <= Convert.ToInt32(txtBuyingQuantity.Text.ToString().Trim()))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "insufficientStockAlert();", true);
            txtStockAvailable.CssClass = "text-lg text-danger form-control";
            txtStockAvailable.BorderColor = System.Drawing.Color.Red;
        }
        #endregion Check for Sufficient Quantity

        #region Add to Cart
        else
        {
            #region Validate Data
            string strErrorMessage = "";
            if (ddlProductName.SelectedIndex <= 0)
            {
                strErrorMessage += "- Select Product";
            }
            if (txtBuyingQuantity.Text == null)
            {
                strErrorMessage += "- Enter Quantity to Buy";
            }
            if (strErrorMessage != "")
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = strErrorMessage;
            }
            #endregion Validate Data

            #region Insert Into Shopping cart
            else
            {
                #region FillCustomerWiseProductENT
                CustomerWiseProductENT entCustomerWiseProduct = new CustomerWiseProductENT();
                entCustomerWiseProduct.CustomerID = Convert.ToInt32(Request.QueryString["CustomerID"]);
                entCustomerWiseProduct.ProductID = Convert.ToInt32(ddlProductName.SelectedValue);
                entCustomerWiseProduct.ProductQuantity = Convert.ToInt32(txtBuyingQuantity.Text.Trim());
                #endregion FillCustomerWiseProductENT

                CustomerWiseProductBAL balCustomerWiseProduct = new CustomerWiseProductBAL();
                if (balCustomerWiseProduct.Insert(entCustomerWiseProduct))
                {
                    #region Decrease the total Quantity If Product Added To Cart
                    ProductBAL balProduct = new ProductBAL();
                    balProduct.DecreaseQuantity(entCustomerWiseProduct.ProductID, Convert.ToInt32(txtBuyingQuantity.Text.Trim()));
                    #endregion Decrease the total Quantity If Product Added To Cart

                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "insertAlert();", true);
                    FillGridviewShoppingCart();
                    ddlProductCategory.SelectedIndex = 0;
                    ddlProductName.Items.Clear();
                    txtPrice.Text = "";
                    txtStockAvailable.Text = "";
                    txtBuyingQuantity.Text = "";
                    CalculateTotal();

                }
            }
            #endregion Insert Into Shopping cart


        }
        #endregion Add to Cart
    }
    #endregion btn_AddToCart : OnClick

    #region FillGridviewShoppingCart
    public void FillGridviewShoppingCart()
    {
        CustomerBAL balCustomer = new CustomerBAL();
        DataTable dt = new DataTable();
        dt = balCustomer.SelectAllProductByCustomerID(Convert.ToInt32(Request.QueryString["CustomerID"]));
        if (dt.Rows.Count > 0)
        {
            gvCartList.DataSource = dt;
            gvCartList.DataBind();
        }
    }
    #endregion FillGridviewShoppingCart

    #region Remove Product From Shopping Cart
    protected void gvCartList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveFromCart")
        {
            if (e.CommandArgument != null)
            {
                CustomerWiseProductBAL balCustomerWiseProduct = new CustomerWiseProductBAL();
                string[] commandArguments = e.CommandArgument.ToString().Split(new char[] { ',' });
                string ProductID = commandArguments[0];
                string Quantity = commandArguments[1];
                if (balCustomerWiseProduct.Delete(Convert.ToInt32(Request.QueryString["CustomerID"]), Convert.ToInt32(ProductID)))
                {
                    #region Increase the total Quantity If Product Removed From Cart
                    ProductBAL balProduct = new ProductBAL();
                    balProduct.IncreaseQuantity(Convert.ToInt32(ProductID), Convert.ToInt32(Quantity));
                    #endregion Increase the total Quantity If Product Removed From Cart
                    FillGridviewShoppingCart();
                    CalculateTotal();
                }
            }
        }
    }
    #endregion Remove Product From Shopping Cart


    #region Calculate Total
    protected void CalculateTotal()
    {
        double TotalAmount = 0;
        foreach (GridViewRow gvr in gvCartList.Rows)
        {
            TotalAmount += Convert.ToDouble(gvr.Cells[2].Text) * Convert.ToDouble(gvr.Cells[3].Text);
        }
        lblTotalAmount.Text = TotalAmount.ToString();
    }

    #endregion Calculate Total

    #region ddlProductCategory :IndexCahanged (Fill ddlProductName)
    protected void ddlProductCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropDownListProduct();
        txtBuyingQuantity.Text = "";
        txtPrice.Text = "";
        txtStockAvailable.Text = "";
    }
    #endregion ddlProductCategory :IndexCahanged (Fill ddlProductName)

    #region btnCheckOut : OnClick
    protected void lbCheckOut_Click(object sender, EventArgs e)
    {
        #region Update TotalAmount & PaymentMethod & Redirect to Invoice
        if (lblTotalAmount.Text != "0")
        {
            int CustomerID = Convert.ToInt32(Request.QueryString["CustomerID"]);
            double TotalAmount = Convert.ToDouble(lblTotalAmount.Text);
            string PaymentMethod = "By Cash";

            CustomerBAL balCustomer = new CustomerBAL();
            if (balCustomer.UpdateTotalAmountPaymentMethod(CustomerID, TotalAmount, PaymentMethod))
            {
                #region Set Values To Session
                Session["CustomerID"] = Request.QueryString["CustomerID"];
                #endregion Set Values To Session
                Response.Redirect("~/AdminPanel/Selling/GenerateInvoice.aspx");
            }
        }
        #endregion Update TotalAmount & PaymentMethod & Redirect to Invoice
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "emptyCartAlert();", true);
        }
    }
    #endregion btnCheckOut : OnClick
}