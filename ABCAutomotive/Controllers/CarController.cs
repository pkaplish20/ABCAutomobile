using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using ABCAutomotive.Models;

namespace ABCAutomotive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CarController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //get values from database
        [HttpPost]
        public JsonResult Post(DateTime date)
        {
            DataTable result;
            string query = @"select * from dbo.Car";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AutomotiveCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    GetCarPriceService calPrice = new GetCarPriceService();
                    result=calPrice.GetPrice(table,date);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(result);
        }
    }
}
