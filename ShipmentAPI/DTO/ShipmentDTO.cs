using ShipmentAPI.Models;
using System;
using System.Collections.Generic;

namespace ShipmentAPI.DTO
{
    public class ShipmentDTO
    {
        public int ID { get; set; }
        public string Pickup_point_address { get; set; }
        public string Pickup_shipper_name { get; set; }
        public string Pickup_shipper_phone { get; set; }
        public string Delivery_address { get; set; }
        public string Delivery_shipper_name { get; set; }
        public string Delivery_shipper_phone { get; set; }
        public DateTime Pickup_date { get; set; }
        public DateTime Delivery_date { get; set; }
        public  List<Commodity> Commodities { get; set; }

        public ShipmentDTO()
        {
            Commodities = new List<Commodity>();
        }
    }

}
