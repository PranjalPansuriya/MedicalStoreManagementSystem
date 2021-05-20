using MedicalStoreManagementSystem_AdminPanel.DAL;
using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Web;

/// <summary>
/// Summary description for CustomerBAL
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.BAL
{
    public class CustomerWiseProductBAL
    {
        #region Constructor
        public CustomerWiseProductBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Local_Variable
        protected string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion Local_Variable

        #region Insert Operation
        public Boolean Insert(CustomerWiseProductENT entCustomerWiseProduct)
        {
            CustomerWiseProductDAL dalCustomerWiseProduct = new CustomerWiseProductDAL();
            if (dalCustomerWiseProduct.Insert(entCustomerWiseProduct))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Insert Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 CustomerID,SqlInt32 ProductID)
        {
            CustomerWiseProductDAL dalCustomerWiseProduct = new CustomerWiseProductDAL();
            if(dalCustomerWiseProduct.Delete(CustomerID, ProductID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Delete Operation
    }
}