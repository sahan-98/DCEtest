using ABCStore.Models.BEL;
using ABCStore.Models.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ABCStore.Controllers
{
   
    public class CustomerController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(string userId)
        {
            string msg = string.Empty;
            Customers customers = new Customers();
            try
            {
                customers = new CustomerService().GetCustomer(userId);
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            return Ok(new { msg });
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            string msg = string.Empty;
            Customers customers = new Customers();
            try
            {
                customers = new CustomerService().GetAllCustomer();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Ok(new { msg });
        }


        [HttpGet]
        public IHttpActionResult GetOrders(string userId)
        {
            string msg = string.Empty;
            Customers customers = new Customers();
            try
            {
                customers = new CustomerService().GetOrders(userId);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Ok(new { msg });
        }


        [HttpPost]
        public IHttpActionResult Insert(Customers customers)
        {
            string msg = string.Empty;
            try
            {
                msg = new CustomerService().Insert(customers);
            }
            catch(Exception ex)
            {
                msg = ex.Message;
               
            }
            return Ok(new { msg });
        }

        [HttpPut]
        public IHttpActionResult Update(Customers customers)
        {
            string msg = string.Empty;
            try
            {
                msg = new CustomerService().Update(customers);
            }
            catch (Exception ex)
            {
                msg = ex.Message;

            }
            return Ok(new { msg });
        }

        [HttpDelete]
        public IHttpActionResult Delete(string userId)
        {
            string msg = string.Empty;
            try
            {
                if(new CustomerService().Delete(userId))
                {
                    msg = "successful";
                }
                else {
                    msg = "unsuccessful";
                }
                
            }
            catch (Exception ex)
            {
                msg = ex.Message;

            }
            return Ok(new { msg });
        }
    }
}
