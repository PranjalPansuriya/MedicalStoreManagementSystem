using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Web;

/// <summary>
/// Summary description for CustomerENT
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.ENT
{
    public class CustomerENT
    {
        #region Constructor
        public CustomerENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region CustomerID
        protected SqlInt32 _CustomerID;
        public SqlInt32 CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
            }
        }
        #endregion CustomerID

        #region CustomerName
        protected SqlString _CustomerName;
        public SqlString CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
            }
        }
        #endregion CustomerName

        #region PaymentMethod
        protected SqlString _PaymentMethod;
        public SqlString PaymentMethod
        {
            get
            {
                return _PaymentMethod;
            }
            set
            {
                _PaymentMethod = value;
            }
        }
        #endregion PaymentMethod

        #region Amount
        protected SqlMoney _Amount;
        public SqlMoney Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
            }
        }
        #endregion Amount

        #region ContactNo
        protected SqlString _ContactNo;
        public SqlString ContactNo
        {
            get
            {
                return _ContactNo;
            }
            set
            {
                _ContactNo = value;
            }
        }
        #endregion ContactNo
    }
}
