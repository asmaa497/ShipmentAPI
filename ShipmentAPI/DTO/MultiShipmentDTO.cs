using System.Collections.Generic;

namespace ShipmentAPI.DTO
{
    public class MultiShipmentDTO
    {
       public List<ShipmentDTO> shipmentDTOs { set; get; }
        public MultiShipmentDTO()
        {
            shipmentDTOs = new List<ShipmentDTO>();
        }
    }
}
