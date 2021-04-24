using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;

/// <summary>
/// Summary description for CustomerDAL
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.DAL
{
    public class CustomerDAL:DatabaseConfig
    {
        #region Constructor
        public CustomerDAL()
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
                        objCmd.CommandText = "PR_Customer_SelectAll";
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
        public CustomerENT SelectByPK(SqlInt32 CustomerID)
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
                        objCmd.CommandText = "PR_Customer_SelectByPK";
                        objCmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                        #endregion Prepare Command

                        #region Read Data & Set Controls
                        CustomerENT entCustomer = new CustomerENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CustomerID"].Equals(DBNull.Value))
                                    entCustomer.CustomerID = Convert.ToInt32(objSDR["CustomerID"]);
                                if (!objSDR["CustomerName"].Equals(DBNull.Value))
                                    entCustomer.CustomerName = Convert.ToString(objSDR["CustomerName"]);
                                if (!objSDR["ContactNo"].Equals(DBNull.Value))
                                    entCustomer.ContactNo = Convert.ToString(objSDR["ContactNo"]);
                                if (!objSDR["PaymentMethod"].Equals(DBNull.Value))
                                    entCustomer.PaymentMethod = Convert.ToString(objSDR["PaymentMethod"]);
                                if (!objSDR["Amount"].Equals(DBNull.Value))
                                    entCustomer.Amount = Convert.ToDecimal(objSDR["Amount"]);
                            }
                            return entCustomer;
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
        public Boolean Insert(CustomerENT entCustomer)
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
                        objCmd.CommandText = "PR_Customer_Insert";
                        objCmd.Parameters.Add("@CustomerID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@CustomerName", entCustomer.CustomerName);
                        objCmd.Parameters.AddWithValue("@ContactNo", entCustomer.ContactNo);
                        objCmd.Parameters.AddWithValue("@PaymentMethod", entCustomer.PaymentMethod);
                        objCmd.Parameters.AddWithValue("@Amount", entCustomer.Amount);
                       
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        if (objCmd.Parameters["@CustomerID"] != null)
                            entCustomer.CustomerID = Convert.ToInt32(objCmd.Parameters["@CustomerID"].Value);
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
        public Boolean Delete(SqlInt32 CustomerID)
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
                        objCmd.CommandText = "PR_Customer_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@CustomerID", CustomerID);
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
        public Boolean Update(CustomerENT entCustomer)
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
                        objCmd.CommandText = "PR_Customer_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@CustomerID", entCustomer.CustomerID);
                        objCmd.Parameters.AddWithValue("@CustomerName", entCustomer.CustomerName);
                        objCmd.Parameters.AddWithValue("@ContactNo", entCustomer.ContactNo);
                        objCmd.Parameters.AddWithValue("@PaymentMethod", entCustomer.PaymentMethod);
                        objCmd.Parameters.AddWithValue("@Amount", entCustomer.Amount);
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
