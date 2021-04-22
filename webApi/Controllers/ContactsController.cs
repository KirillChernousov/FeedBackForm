/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using webApi.Models;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ContactsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select contactID, contactName, email, phoneNumber                    
                    from dbo.Contacts
                    ";

            DataTable table = new DataTable();
            string sqlDataSourse = _configuration.GetConnectionString("FeedBackAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSourse))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Contacts cnt)
        {
            string query = @"
                    insert into dbo.Contacts
                    (contactName,email,phoneNumber)
                    values 
                    (
                    '" + cnt.contactName + @"'
                    ,'" + cnt.email + @"'
                    ,'" + cnt.phoneNumber + @"'
                    )
                    ";
            DataTable table = new DataTable();
            string sqlDataSourse = _configuration.GetConnectionString("FeedBackAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSourse))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added");
        }
        [HttpPut]
        public JsonResult Put(Contacts cnt)
        {
            string query = @"
                    update dbo.Contacts set
                    contactName = '" + cnt.contactName + @"'
                    ,email = '" + cnt.email + @"'
                    ,phoneNumber = '" + cnt.phoneNumber + @"'
                    where contactID = " + cnt.contactID + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSourse = _configuration.GetConnectionString("FeedBackAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSourse))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                    delete from dbo.Contacts
                    where contactID = " + id + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSourse = _configuration.GetConnectionString("FeedBackAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSourse))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted");
        }
    }
}*/