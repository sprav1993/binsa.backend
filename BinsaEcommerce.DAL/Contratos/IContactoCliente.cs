using BinsaEcommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinsaEcommerce.DAL.Contratos
{
    public interface IContactoCliente:IRepositorioGenerico<ContactoCliente>
    {
        Task<ContactoCliente> GetContactoClienteID(int id);
        Task<List<ContactoCliente>> GetListadoContactoClientes();
    }
}
