using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class CarDTO
    {
        public string CarCol { get; set; }
        public Guid IdCar { get; set; }
        public string CarYear { get; set; }
        public string CarNroPlaca { get; set; }
        public string CarNroAsien { get; set; }
        public string CarIsMec { get; set; }
        public string CarIsFull { get; set; }
        public string CarMarca { get; set; }
    }
}
