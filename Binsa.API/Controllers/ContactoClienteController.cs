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
    public class ContactoClienteController : ControllerBase
    {
        private IContactoClienteRepositorio _contactoClienteRepositorio;
        public ContactoClienteController(IContactoClienteRepositorio contactoClienteRepositorio)
        {
            this._contactoClienteRepositorio = contactoClienteRepositorio;
        }


        //GET 
        [HttpGet]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<ContactoCliente>>> Get()
        {
            try
            {
                List<ContactoCliente> cliente = await _contactoClienteRepositorio.GetListadoContactoClientes();
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
        public async Task<ActionResult<ContactoCliente>> Get(int id)
        {
            try
            {
                ContactoCliente clienteId = await _contactoClienteRepositorio.GetContactoClienteID(id);
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
        public async Task<bool> Post(ContactoCliente contactoCliente)
        {
            try
            {
                bool result = await _contactoClienteRepositorio.Grabar(contactoCliente);
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
                bool resultado = await _contactoClienteRepositorio.Eliminar(id);
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
