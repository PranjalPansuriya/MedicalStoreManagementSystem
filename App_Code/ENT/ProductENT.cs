using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductENT
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.ENT
{
    public class ProductENT
    {
        #region Constructor
        public ProductENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region ProductID
        protected SqlInt32 _ProductID;
        public SqlInt32 ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
            }
        }
        #endregion ProductID

        #region ProductName
        protected SqlString _ProductName;
        public SqlString ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                _ProductName = value;
            }
        }
        #endregion ProductName

        #region ProductCategoryID
        protected SqlInt32 _ProductCategoryID;
        public SqlInt32 ProductCategoryID
        {
            get
            {
                return _ProductCategoryID;
            }
            set
            {
                _ProductCategoryID = value;
            }
        }
        #endregion ProductCategoryID

        #region CompanyName
        protected SqlString _CompanyName;
        public SqlString CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
            }
        }
        #endregion CompanyName

        #region SupplierID
        protected SqlInt32 _SupplierID;
        public SqlInt32 SupplierID
        {
            get
            {
                return _SupplierID;
            }
            set
            {
                _SupplierID = value;
            }
        }
        #endregion SupplierID

        #region Quantity
        protected SqlInt32 _Quantity;
        public SqlInt32 Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
            }
        }
        #endregion Quantity

        #region ProductExpiryDate
        protected SqlDateTime _ProductExpiryDate;
        public SqlDateTime ProductExpiryDate
        {
            get
            {
                return _ProductExpiryDate;
            }
            set
            {
                _ProductExpiryDate = value;
            }
        }
        #endregion ProductExpiryDate

        #region DeliveryDate
        protected SqlDateTime _DeliveryDate;
        public SqlDateTime DeliveryDate
        {
            get
            {
                return _DeliveryDate;
            }
            set
            {
                _DeliveryDate = value;
            }
        }
        #endregion DeliveryDate

        #region Location
        protected SqlString _Location;
        public SqlString Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
            }
        }
        #endregion Location

        #region OtherDescription
        protected SqlString _OtherDescription;
        public SqlString OtherDescription
        {
            get
            {
                return _OtherDescription;
            }
            set
            {
                _OtherDescription = value;
            }
        }
        #endregion OtherDescription
    }
}
