using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipmentAPI.Models;
using System;
using ShipmentAPI.Repository;
using ShipmentAPI.DTO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace ShipmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class ShipmentController : ControllerBase
    {
        private readonly Context context;
        private readonly IShipmentRepository shipmentRepository;

        public ShipmentController(Context context,IShipmentRepository shipmentRepository)
        {
            this.context = context;
            this.shipmentRepository = shipmentRepository;
        }
        private void SaveOneShipment(ShipmentDTO shipmentDTO)
        {
            Shipment shipment = new Shipment();
            shipment.ID = shipmentDTO.ID;
            shipment.Pickup_point_address = shipmentDTO.Pickup_point_address;
            shipment.Pickup_shipper_phone = shipmentDTO.Pickup_shipper_phone;
            shipment.Delivery_address = shipmentDTO.Delivery_address;
            shipment.Delivery_shipper_name = shipmentDTO.Delivery_shipper_name;
            shipment.Delivery_shipper_phone = shipmentDTO.Delivery_shipper_phone;
            shipment.Pickup_date = shipmentDTO.Pickup_date;
            shipment.Delivery_date = shipmentDTO.Delivery_date;
            foreach (var item in shipmentDTO.Commodities)
            {
                shipment.Commodities.Add(new Commodity { ID = item.ID, Name = item.Name, Price = item.Price });
            }
            shipmentRepository.Add(shipment);
        }
        [HttpPost]
        
        public IActionResult NewShipment(ShipmentDTO shipmentDTO)
        {
            if (ModelState.IsValid)
            {
                try
                { 
                    SaveOneShipment(shipmentDTO);
                    return StatusCode(200, "Data Saved");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);
        }


        [HttpPost]

        [Route("NewMultiShipment")]
        public IActionResult NewMultiShipment(MultiShipmentDTO MultiShipmentDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var item in MultiShipmentDTO.shipmentDTOs)
                    {
                        SaveOneShipment(item);
                    }
                    return StatusCode(200, "Data Saved");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }
        [HttpGet]
        public IActionResult GetShipmentsByDate(DateTime Pickup_Date, DateTime Delivery_Date)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   List<Shipment> shipments= shipmentRepository.GetShipmentsByDate(Pickup_Date, Delivery_Date);
                    return StatusCode(200, shipments);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
