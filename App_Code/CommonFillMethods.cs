using MedicalStoreManagementSystem_AdminPanel.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonFillMethods
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel
{
    public class CommonFillMethods
    {
        #region Constructor
        public CommonFillMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region FillDropDownListProductCategory
        public static void FillDropDownListProductCategory(DropDownList ddl)
        {
            ProductCategoryBAL baLProductCategory = new ProductCategoryBAL();
            ddl.DataSource = baLProductCategory.SelectAll();
            ddl.DataTextField = "ProductCategoryName";
            ddl.DataValueField = "ProductCategoryID";
            ddl.DataBind();
            ddl.Items.Insert(0,new ListItem("Select ProductCategory","-1"));
        }
        #endregion FillDropDownListProductCategory

        #region FillDropDownListSupplierName
        public static void FillDropDownListSupplierName(DropDownList ddl)
        {
            SupplierBAL balSupplier = new SupplierBAL();
            ddl.DataSource = balSupplier.SelectAll();
            ddl.DataTextField = "SupplierName";
            ddl.DataValueField = "SupplierID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Supplier", "-1"));
        }
        #endregion FillDropDownListSupplierName

        #region FillDropDownListProductName
        public static void FillDropDownListProductName(DropDownList ddl)
        {
            ProductBAL balProduct = new ProductBAL();
            ddl.DataSource = balProduct.SelectAll();
            ddl.DataTextField = "ProductName";
            ddl.DataValueField = "ProductID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Product", "-1"));
        }
        #endregion FillDropDownListProductName

        #region FillDropDownListProductNameByProductCategory
        public static void FillDropDownListProductNameByProductCategory(DropDownList ddl,SqlInt32 ProductCategoryID)
        {
            ProductBAL balProduct = new ProductBAL();
            ddl.DataSource = balProduct.SelectByProductCategory(ProductCategoryID);
            ddl.DataTextField = "ProductName";
            ddl.DataValueField = "ProductID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Product", "-1"));
        }
        #endregion FillDropDownListProductNameByProductCategory

        #region FillDropDownListCustomerName
        public static void FillDropDownListCustomerName(DropDownList ddl)
        {
            CustomerBAL balCustomer = new CustomerBAL();
            ddl.DataSource = balCustomer.SelectAll();
            ddl.DataTextField = "CustomerName";
            ddl.DataValueField = "CustomerID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Customer", "-1"));
        }
        #endregion FillDropDownListCustomerName
    }
}
