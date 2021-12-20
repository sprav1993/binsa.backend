using BinsaEcommerce.DAL.Contratos;
using BinsaEcommerce.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Binsa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            this._clienteRepositorio = clienteRepositorio;
        }


        //GET 
        [HttpGet]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            try
            {
                List<Cliente> cliente = await _clienteRepositorio.GetListadoClientes();
                return cliente;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //GET 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            try
            {
                Cliente clienteId = await _clienteRepositorio.GetClienteID(id);
                return clienteId;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //POST
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> Post(Cliente cliente)
        {
            try
            {
                bool result = await _clienteRepositorio.Grabar(cliente);
                return result;

            }
            catch (Exception)
            {

                return false;
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool resultado = await _clienteRepositorio.Eliminar(id);
                if (!resultado)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
