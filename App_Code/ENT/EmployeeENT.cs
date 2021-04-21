using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeENT
/// </summary>

namespace MedicalStoreManagementSystem_AdminPanel.ENT
{
    public class EmployeeENT
    {
        #region Constructor
        public EmployeeENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region EmployeeID
        protected SqlInt32 _EmployeeID;
        public SqlInt32 EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
            }
        }
        #endregion EmployeeID

        #region EmployeeName
        protected SqlString _EmployeeName;
        public SqlString EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }
        #endregion EmployeeID

        #region BirthDate
        protected SqlDateTime _BirthDate;
        public SqlDateTime BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                _BirthDate = value;
            }
        }
        #endregion BirthDate

        #region Address
        protected SqlString _Address;
        public SqlString Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }

        #endregion Address

        #region MobileNo
        protected SqlString _MobileNo;
        public SqlString MobileNo
        {
            get
            {
                return _MobileNo;
            }
            set
            {
                _MobileNo = value;
            }
        }
        #endregion MobileNo

        #region Email
        protected SqlString _Email;
        public SqlString Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
        #endregion Email

        #region Post
        protected SqlString _Post;
        public SqlString Post
        {
            get
            {
                return _Post;
            }
            set
            {
                _Post = value;
            }
        }
        #endregion Email

        #region JoiningDate
        protected SqlDateTime _JoiningDate;
        public SqlDateTime JoiningDate
        {
            get
            {
                return _JoiningDate;
            }
            set
            {
                _JoiningDate = value;
            }
        }
        #endregion JoiningDate

    }
}
