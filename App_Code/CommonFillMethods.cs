using MedicalStoreManagementSystem_AdminPanel.BAL;
using System;
using System.Collections.Generic;
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
    }
}
