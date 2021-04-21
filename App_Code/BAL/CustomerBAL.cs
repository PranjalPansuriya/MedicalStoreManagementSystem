using MedicalStoreManagementSystem_AdminPanel.DAL;
using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerBAL
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.BAL
{
    public class CustomerBAL
    {
        #region Constructor
        public CustomerBAL()
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

        #region SelectAll
        public DataTable SelectAll()
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            return dalCustomer.SelectAll();
        }
        #endregion SelectAll
                
        #region SelectByPK
        public CustomerENT SelectByPK(SqlInt32 CustomerID)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            return dalCustomer.SelectByPK(CustomerID);

        }
        #endregion SelectByPK

        #region Delete Operation
        public Boolean Delete(SqlInt32 CustomerID)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            if (dalCustomer.Delete(CustomerID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Delete Operation

        #region Insert Operation
        public Boolean Insert(CustomerENT entCustomer)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            if (dalCustomer.Insert(entCustomer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(CustomerENT entCustomer)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            if (dalCustomer.Update(entCustomer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Update Operation
    }
}
