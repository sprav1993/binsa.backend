using BinsaEcommerce.DAL.Contratos;
using BinsaEcommerce.DAL.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinsaEcommerce.DAL.Repositorios
{
    public class ContactoClienteDAL : IContactoClienteRepositorio
    {
        private readonly string _cadenaConexion;
        public ContactoClienteDAL(string CadenaConexion)
        {
            _cadenaConexion = CadenaConexion;
        }

        public async Task<bool> Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("SP_DEL_CONTACTO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    await con.OpenAsync();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception)
                {
                    con.Close();
                    return false;
                }
                return true;
            }

        }

        public async Task<ContactoCliente> GetContactoClienteID(int id)
        {
            ContactoCliente GetContactoID = new ContactoCliente();
            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("SP_GET_CONTACTOS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    await con.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    while (sdr.Read())
                    {

                        GetContactoID.id_contactoCli = Convert.ToInt32(sdr["Id"]);
                        GetContactoID.id_Cliente = Convert.ToInt32(sdr["ClienteId"]);
                        GetContactoID.nombre = sdr["Nombre"].ToString();
                        GetContactoID.telefono = sdr["Telefono"].ToString();
                        GetContactoID.email = sdr["Email"].ToString();
                    }
                    con.Close();
                }
                catch (Exception)
                {
                    con.Close();
                }
            }
            return GetContactoID;
        }

        public async Task<List<ContactoCliente>> GetListadoContactoClientes()
        {
            List<ContactoCliente> GetClientesList = new List<ContactoCliente>();
            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("SP_GET_CLIENTES", con);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await con.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    while (sdr.Read())
                    {
                        GetClientesList.Add(new ContactoCliente
                        {
                            id_contactoCli = Convert.ToInt32(sdr["Id"]),
                            id_Cliente = Convert.ToInt32(sdr["ClienteId"]),
                            nombre = sdr["Nombre"].ToString(),
                            telefono = sdr["Telefono"].ToString(),
                            email = sdr["Email"].ToString(),
                        });
                    }
                    con.Close();
                }
                catch (Exception)
                {
                    con.Close();
                }
            }
            return GetClientesList;
        }

        public async Task<bool> Grabar(ContactoCliente entity)
        {
            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("SP_ADD_CONTACTO", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", entity.id_Cliente);
                cmd.Parameters.AddWithValue("@ClienteId", entity.id_Cliente);
                cmd.Parameters.AddWithValue("@Nombre", entity.nombre);
                cmd.Parameters.AddWithValue("@Telefono", entity.telefono);
                cmd.Parameters.AddWithValue("@Email", entity.email);


                try
                {
                    await con.OpenAsync();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception)
                {
                    con.Close();
                    return false;
                }

            }
        }
    }
}
