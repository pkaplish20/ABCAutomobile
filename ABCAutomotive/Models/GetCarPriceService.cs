using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCAutomotive.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.Json;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using FastMember;

namespace ABCAutomotive.Models
{
    //to calculate profit
    public class GetCarPriceService
    {

        DataTable table = new DataTable();
        public DataTable GetPrice(DataTable table, DateTime date)
        {
            List<Car> carList = new List<Car>();
            carList = (from DataRow dr in table.Rows
                           select new Car()
                           {
                               carMake = dr["CarMake"].ToString(),
                               carModel = dr["CarModel"].ToString(),
                               carType= Convert.ToInt32(dr["CarType"].ToString()),
                               price = Convert.ToInt32(dr["Price"].ToString())
                           }).ToList();
        
           foreach(Car car in carList)
            {
                car.profit = (car.price * 15) / 100;
                car.sellingPrice = car.price + car.profit;
                if (date.Month == 5)
                {
                    if (car.isRed)
                    {
                        car.sellingPrice = car.sellingPrice * 5;
                    }
                }
                if(car.isConvertible)
                {
                    car.sellingPrice = car.sellingPrice * 10;
                }
                car.profit = car.sellingPrice - car.price;
                }
           
             DataTable table1 = new DataTable();
            using (var reader = ObjectReader.Create(carList))
            {
                table1.Load(reader);
            }

            return table1;
        }
    }
}
