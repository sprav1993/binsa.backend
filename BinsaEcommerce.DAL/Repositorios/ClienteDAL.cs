using BinsaEcommerce.DAL.Contratos;
using BinsaEcommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinsaEcommerce.DAL.Repositorios
{
    public class ClienteDAL : IClienteRepositorio
    {
        private readonly string _cadenaConexion;

        public ClienteDAL(string CadenaConexion)
        {
            _cadenaConexion = CadenaConexion;
        }
        public async Task<bool> Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("SP_DEL_CLIENTE", con);
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

        public async  Task<Cliente> GetClienteID(int id)
        {
            Cliente GetClienteID = new Cliente();
            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("SP_GET_CLIENTES", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    await con.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    while (sdr.Read())
                    {

                        GetClienteID.id_Cliente = Convert.ToInt32(sdr["Id"]);
                        GetClienteID.nombre = sdr["Nombre"].ToString();
                        GetClienteID.domicilio = sdr["Domicilio"].ToString();
                        GetClienteID.codigoPostal = sdr["CodigoPostal"].ToString();
                        GetClienteID.poblacion = sdr["Poblacion"].ToString();

                    }
                    con.Close();
                }
                catch (Exception)
                {
                    con.Close();
                }
            }
            return GetClienteID;
        }

        public async Task<List<Cliente>> GetListadoClientes()
        {
            List<Cliente> GetClientesList = new List<Cliente>();
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
                        GetClientesList.Add(new Cliente
                        {
                            id_Cliente = Convert.ToInt32(sdr["Id"]),
                            nombre = sdr["Nombre"].ToString(),
                            domicilio = sdr["Domicilio"].ToString(),
                            codigoPostal = sdr["CodigoPostal"].ToString(),
                            poblacion = sdr["Poblacion"].ToString(),

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

        public async Task<bool> Grabar(Cliente entity)
        {
            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("SP_ADD_CLIENTE", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", entity.id_Cliente);
                cmd.Parameters.AddWithValue("@Nombre", entity.nombre);
                cmd.Parameters.AddWithValue("@Domicilio", entity.domicilio);
                cmd.Parameters.AddWithValue("@CodigoPostal", entity.codigoPostal);
                cmd.Parameters.AddWithValue("@Poblacion", entity.poblacion);
           

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
