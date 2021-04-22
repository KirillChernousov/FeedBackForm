using System;
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
    public class TMessagesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TMessagesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public JsonResult Post(TMessages mes)
        {
            string query = @"
                    select * from dbo.Contacts
                    where email = '" + mes.email + @"' and 
                          phoneNumber = '" + mes.phone + @"' 
                    ";

            DataTable table = new DataTable();
            table = DoSqlRequest(query);

            if (table.Rows.Count == 0) //если пользователя нет в бд заносим его 
            {
                query = @"
                     insert into dbo.Contacts
                     (contactName,email,phoneNumber)
                     values 
                     (
                     '" + mes.contact + @"'
                     ,'" + mes.email + @"'
                     ,'" + mes.phone + @"'
                     )
                     ";
                DoSqlRequest(query);

                query = @"
                    select * from dbo.Contacts
                    where email = '" + mes.email + @"' 
                    ";
                table = DoSqlRequest(query);
            }
            // берём id контакта
            mes.contact = table.Rows[0][0].ToString();

            //заносим сообщение в бд
            AddMessage(mes);
            return new JsonResult("Added");
        }
        public void AddMessage(TMessages mes)
        {

            //заносим сообщение в базу
            string query = @"
                        insert into dbo.TMessages
                        (contactID,messageText,topicID)
                        values 
                        (
                        '" + mes.contact + @"',
                        '" + mes.messageText + @"',
                        '" + mes.topic + @"'
                        )
                        ";
            DoSqlRequest(query);

        }
        public DataTable DoSqlRequest(string query)
        {
            DataTable table = new DataTable();
            string sqlDataSourse = _configuration.GetConnectionString("FeedBackAppConnection");
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

            return table;
        }
        /*[HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select messageID, contactID, topicID, messageText                    
                    from dbo.TMessages
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


        [HttpPut]
        public JsonResult Put(TMessages mes)
        {
            string query = @"
                    update dbo.TMessage set
                    contactID = '" + mes.contactID + @"'
                    ,messageText = '" + mes.messageText + @"'
                    ,topicsID = '" + mes.topicsID + @"'
                    where messageID = " + mes.messageID + @" 
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
                    delete from dbo.TMessage
                    where messageID = " + id + @" 
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

        [Route("GetAllMessagesInfo")]
        public JsonResult GetAllMessagesInfo()
        {
            string query = @"
                    select 
                            dbo.Contacts.contactName, dbo.Contacts.email, dbo.Contacts.phoneNumber, dbo.Topics.topicName, dbo.TMessages.messageText 
                    from    
                            dbo.Contacts, dbo.Topics, dbo.TMessages
                    where   
                            dbo.Contacts.contactID  = dbo.TMessages.contactID AND
                            dbo.Topics.topicID      = dbo.TMessages.topicID
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("FeedBackAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }*/
    }
}
