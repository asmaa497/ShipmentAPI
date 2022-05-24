using ShipmentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipmentAPI.Repository
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly Context context;

        public ShipmentRepository(Context context)
        {
            this.context = context;
        }
        public Shipment Add(Shipment shipment)
        {
            context.shipments.Add(shipment);
            context.SaveChanges();
            return shipment;
        }

        public List<Shipment> GetShipmentsByDate(DateTime Pickup_Date, DateTime Delivery_Date)
        {
            return context.shipments
                .Where(shipment => shipment.Pickup_date == Pickup_Date 
                && shipment.Delivery_date == Delivery_Date).ToList();
        }
    }
}
