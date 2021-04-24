using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;

/// <summary>
/// Summary description for EmployeeDAL
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.DAL
{
    public class EmployeeDAL : DatabaseConfig
    {
        #region Constructor
        public EmployeeDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region LocalVariable
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
        #endregion LocalVariable

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Employee_SelectAll";
                        #endregion Prepare Command

                        #region Read Data & Set Control
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            //Convert.ToDateTime(objSDR["BirthDate"].ToString()).ToString("MM/dd/yyyy");
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion Read Data & Set Control
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion SelectAll

        #region SelectByPK
        public EmployeeENT SelectByPK(SqlInt32 EmployeeID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Employee_SelectByPK";
                        objCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        #endregion Prepare Command

                        #region Read Data & Set Controls
                        EmployeeENT entEmployee = new EmployeeENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["EmployeeID"].Equals(DBNull.Value))
                                    entEmployee.EmployeeID = Convert.ToInt32(objSDR["EmployeeID"]);
                                if (!objSDR["EmployeeName"].Equals(DBNull.Value))
                                    entEmployee.EmployeeName = Convert.ToString(objSDR["EmployeeName"]);
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                    entEmployee.Address = Convert.ToString(objSDR["Address"]);
                                if (!objSDR["BirthDate"].Equals(DBNull.Value))
                                    entEmployee.BirthDate = Convert.ToDateTime(objSDR["BirthDate"]);
                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                    entEmployee.MobileNo = Convert.ToString(objSDR["MobileNo"]);
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                    entEmployee.Email = Convert.ToString(objSDR["Email"]);
                                if (!objSDR["Post"].Equals(DBNull.Value))
                                    entEmployee.Post = Convert.ToString(objSDR["Post"]);
                                if (!objSDR["JoiningDate"].Equals(DBNull.Value))
                                    entEmployee.JoiningDate = Convert.ToDateTime(objSDR["JoiningDate"]);

                            }
                            return entEmployee;
                        }
                        #endregion Read Data & Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion SelectByPK

        #endregion Select Operation

        #region Insert Operation
        public Boolean Insert(EmployeeENT entEmployee)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Employee_Insert";
                        objCmd.Parameters.Add("@EmployeeID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@EmployeeName", entEmployee.EmployeeName);
                        objCmd.Parameters.AddWithValue("@BirthDate", entEmployee.BirthDate);
                        objCmd.Parameters.AddWithValue("@Address", entEmployee.Address);
                        objCmd.Parameters.AddWithValue("@MobileNo", entEmployee.MobileNo);
                        objCmd.Parameters.AddWithValue("@Email", entEmployee.Email);
                        objCmd.Parameters.AddWithValue("@Post", entEmployee.Post);
                        objCmd.Parameters.AddWithValue("JoiningDate", entEmployee.JoiningDate);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        if (objCmd.Parameters["@EmployeeID"] != null)
                            entEmployee.EmployeeID = Convert.ToInt32(objCmd.Parameters["@EmployeeID"].Value);
                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Insert Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 EmployeeID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare_Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Employee_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        #endregion Prepare_Command

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion Delete Operation

        #region Update Operation
        public Boolean Update(EmployeeENT entEmployee)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Employee_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@EmployeeID", entEmployee.EmployeeID);
                        objCmd.Parameters.AddWithValue("@EmployeeName", entEmployee.EmployeeName);
                        objCmd.Parameters.AddWithValue("@Address", entEmployee.Address);
                        objCmd.Parameters.AddWithValue("@Email", entEmployee.Email);
                        objCmd.Parameters.AddWithValue("@MobileNo", entEmployee.MobileNo);
                        objCmd.Parameters.AddWithValue("@BirthDate", entEmployee.BirthDate);
                        objCmd.Parameters.AddWithValue("@JoiningDate", entEmployee.JoiningDate);
                        objCmd.Parameters.AddWithValue("@Post", entEmployee.Post);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        return true;
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Update Operation
    }
}
