using ABCStore.Models.BEL;
using ABCStore.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ABCStore.Models.BLL
{
    public class CustomerService
    {
        DBFunction _df;
        DataTable _dt;
        SqlParameter[] _param;

        public CustomerService()
        {
            _df = new DBFunction();
        }

        public string Insert(Customers customers)
        {
            _param = new SqlParameter[]
            {
                new SqlParameter("@userId",customers.userId),
                new SqlParameter("@userName",customers.userName),
                new SqlParameter("@email",customers.email),
                new SqlParameter("@firstName",customers.firstName),
                new SqlParameter("@lastName",customers.lastName),
                new SqlParameter("@createdOn",customers.createdOn),
                new SqlParameter("@isActive",customers.IsActive)
            };
            return (string)_df.executeScalerWithProc("USP_PROC", _param);
        }


        public string Update(Customers customers)
        {
            _param = new SqlParameter[]
            {
                new SqlParameter("@userId",customers.userId),
                new SqlParameter("@userName",customers.userName),
                new SqlParameter("@email",customers.email),
                new SqlParameter("@firstName",customers.firstName),
                new SqlParameter("@lastName",customers.lastName),
                new SqlParameter("@createdOn",customers.createdOn),
                new SqlParameter("@isActive",customers.IsActive)
            };
            return (string)_df.executeScalerWithProcUpdate("USP_PROC", _param);
        }

        public Customers GetCustomer(string userId)
        {
       
                return _dt.AsEnumerable().Select(row => new Customers
                {
                    userId = row.Field<int>("userId"),
                    userName = row.Field<string>("userName"),
                    email = row.Field<string>("email"),
                    firstName = row.Field<string>("firstName"),
                    lastName = row.Field<string>("lastName"),
                    createdOn = row.Field<DateTime>("createdOn"),
                    IsActive = row.Field<Boolean>("IsActive"),

                }).FirstOrDefault();
           
        }

        public Customers GetAllCustomer()
        {

            return _dt.AsEnumerable().Select(row => new Customers
            {
                userId = row.Field<int>("userId"),
                userName = row.Field<string>("userName"),
                email = row.Field<string>("email"),
                firstName = row.Field<string>("firstName"),
                lastName = row.Field<string>("lastName"),
                createdOn = row.Field<DateTime>("createdOn"),
                IsActive = row.Field<Boolean>("IsActive"),

            }).FirstOrDefault();

        }

        public Customers GetOrders(string userId)
        {

            return _dt.AsEnumerable().Select(row => new Customers
            {
               /* userId = row.Field<int>("userId"),
                userName = row.Field<string>("userName"),
                email = row.Field<string>("email"),
                firstName = row.Field<string>("firstName"),
                lastName = row.Field<string>("lastName"),
                createdOn = row.Field<DateTime>("createdOn"),
                IsActive = row.Field<Boolean>("IsActive"),*/


            }).FirstOrDefault();

        }


        public Boolean Delete(String uid)
        {
            
            return _df.returnDTWithProc_adapter(uid);
        }



    }
}