using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ABCStore.Models.DAL
{
    public class DBFunction
    {
        String connstr = string.Empty;
        DataTable _dt;
        public DBFunction()
        {
            connstr = ConfigurationManager.ConnectionStrings["conStr"].ToString();
            _dt = new DataTable();
        }

        public object executeScalerWithProc(string procName, params SqlParameter[] param) { 
        
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand(procName, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if(param != null)
                {
                    foreach(SqlParameter p in param)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                con.Open();
                return cmd.ExecuteScalar();
            }
        }

        public object executeScalerWithProcUpdate(string procName, params SqlParameter[] param)
        {

            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand(procName, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (param != null)
                {
                    foreach (SqlParameter p in param)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                con.Open();
                return cmd.ExecuteScalar();
            }
        }
        public DataSet returnDSWithProc_adapter(String procName, params SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlDataAdapter da = new SqlDataAdapter(procName, connstr);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if(param != null)
                {
                    foreach (SqlParameter p in param)
                    {
                        da.SelectCommand.Parameters.Add(p);
                    }
                }


                DataSet ds = new DataSet();

                con.Open();
                da.Fill(ds);

                return ds;
            }
        }


        public DataSet returnDSWithProc_adapterOrder(String procName, params SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlDataAdapter da = new SqlDataAdapter(procName, connstr);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (param != null)
                {
                    foreach (SqlParameter p in param)
                    {
                        da.SelectCommand.Parameters.Add(p);
                    }
                }


                DataSet ds = new DataSet();

                con.Open();
                da.Fill(ds);

                return ds;
            }
        }

        internal Boolean returnDTWithProc_adapter(String param)
        {

            using (SqlConnection con = new SqlConnection(connstr))
            {
                string sql = $"Delete From Customers Where Id='{param}'";
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    con.Open();
                    if (command.ExecuteNonQuery()>0)
                    {
                        con.Close();
                        return true;
                    }
                    else {
                        con.Close();
                        return false;

                    }
                    
                  
                }
            }
           
        }
    }
}