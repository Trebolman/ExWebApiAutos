using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TMarca
    {
        public TMarca()
        {
            TCar = new HashSet<TCar>();
        }

        public Guid MarcaId { get; set; }
        public string MarcaName { get; set; }

        public virtual ICollection<TCar> TCar { get; set; }
    }
}
