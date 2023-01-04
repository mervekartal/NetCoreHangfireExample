using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
    public class Container
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string ContainerName { get; set; }
        public float Latitude { get; set; }
        public int Longitude { get; set; }
        public int VehicleID { get; set; }
        public virtual Vehicle Vehicle { get; set; }

    }
}
