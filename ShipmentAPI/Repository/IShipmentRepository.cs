using ShipmentAPI.Models;
using System;
using System.Collections.Generic;

namespace ShipmentAPI.Repository
{
    public interface IShipmentRepository
    {
        public Shipment Add(Shipment shipment);
        public List<Shipment> GetShipmentsByDate(DateTime Pickup_Date, DateTime Delivery_Date);
    }
}
