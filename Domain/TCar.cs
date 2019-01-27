using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TCar
    {
        public string CarCol { get; set; }
        public Guid IdCar { get; set; }
        public string CarYear { get; set; }
        public string CarNroPlaca { get; set; }
        public string CarNroAsien { get; set; }
        public string CarIsMec { get; set; }
        public string CarIsFull { get; set; }
        public string CarMarca { get; set; }
        public Guid? MarcaId { get; set; }

        public virtual TMarca Marca { get; set; }
    }
}
