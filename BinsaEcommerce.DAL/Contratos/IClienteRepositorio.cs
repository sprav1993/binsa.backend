using BinsaEcommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinsaEcommerce.DAL.Contratos
{
    public interface IClienteRepositorio:IRepositorioGenerico<Cliente>
    {
        Task<Cliente> GetClienteID(int id);
        Task<List<Cliente>> GetListadoClientes();
    }
}
