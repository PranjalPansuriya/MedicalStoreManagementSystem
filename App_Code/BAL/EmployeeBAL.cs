using MedicalStoreManagementSystem_AdminPanel.DAL;
using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Web;

/// <summary>
/// Summary description for EmployeeBAL
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.BAL 
{
    public class EmployeeBAL
    {
        #region Constructor
        public EmployeeBAL()
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
            EmployeeDAL dalEmployee = new EmployeeDAL();
            return dalEmployee.SelectAll();
        }
        #endregion SelectAll

        #region SelectByPK
        public EmployeeENT SelectByPK(SqlInt32 EmployeeID)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            return dalEmployee.SelectByPK(EmployeeID);
        }
        #endregion SelectByPK

        #region Delete Operation
        public Boolean Delete(SqlInt32 EmployeeID)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            if(dalEmployee.Delete(EmployeeID))
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
        public Boolean Insert(EmployeeENT entEmployee)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            if(dalEmployee.Insert(entEmployee))
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
        public Boolean Update(EmployeeENT entEmployee)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            if(dalEmployee.Update(entEmployee))
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
