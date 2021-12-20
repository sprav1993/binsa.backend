using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinsaEcommerce.DAL.Models
{
    public class Cliente
    {
        public int id_Cliente { get; set; }
        public string nombre { get; set; }
        public string domicilio { get; set; }
        public string codigoPostal { get; set; }
        public string poblacion { get; set; }

    }
}
