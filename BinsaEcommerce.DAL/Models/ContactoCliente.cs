using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinsaEcommerce.DAL.Models
{
    public class ContactoCliente
    {
        public int id_contactoCli { get; set; }
        public int id_Cliente { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }

    }
}
