using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Sistema.Entidades;
using MySql.Data.MySqlClient;

namespace Sistema.AccesoDatos
{
    public class pacienteDal
    {
        //Primero y siguiendo el orden de las acciones CRUD
        //Crearemos un Método que se encarga de insertar un nuevo Pacient es nuestra tabla Pacient
        /// <summary>
        /// Inserta un nuevo Paciente en la tabla Paciente
        /// </summary>
        /// <param name="paciente">Entidad contenedora de los valores a insertar</param>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public void Insert(EPaciente paciente)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            { 
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO Paciente (apellido,nombre, sexo) VALUES (@apellido, @nombre, @sexo)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                    //ya no leeremos controles sino usaremos las propiedades del Objeto EProducto de nuestra capa
                    //de entidades...
                    cmd.Parameters.AddWithValue("@apellido", paciente.apellido);
                    cmd.Parameters.AddWithValue("@nombre", paciente.nombre);
                    cmd.Parameters.AddWithValue("@sexo", paciente.sexo);
                    //cmd.Parameters.AddWithValue("@id", paciente.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
            /// <summary>
            /// Devuelve una lista de Productos ordenados por el campo Id de manera Ascendente
            /// </summary>
            /// <returns>Lista de productos</returns>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public List<EPaciente> GetAll()
            {
                //Declaramos una lista del objeto EProducto la cual será la encargada de
                //regresar una colección de los elementos que se obtengan de la BD
                //
                //La lista substituye a DataTable utilizado en el proyecto de ejemplo
                List<EPaciente> pacientes = new List<EPaciente>();
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();

                    const string sqlQuery = "SELECT * FROM paciente ORDER BY Id ASC";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        //
                        //Preguntamos si el DataReader fue devuelto con datos
                        while (dataReader.Read())
                        {
                            //
                            //Instanciamos al objeto Eproducto para llenar sus propiedades
                            EPaciente paciente = new EPaciente
                            {
                                id = Convert.ToInt32(dataReader["id"]),
                                apellido = Convert.ToString(dataReader["apellido"]),
                                nombre = Convert.ToString(dataReader["nombre"]),
                                sexo = Convert.ToString(dataReader["sexo"])
                            };
                            //
                            //Insertamos el objeto Producto dentro de la lista Productos
                            pacientes.Add(paciente);
                        }
                    }
                }
                return pacientes;
            }
            /// <summary>
            /// Devuelve un Objeto Producto
            /// </summary>
            /// <param name="idProducto">Id del producto a buscar</param>
            /// <returns>Un registro con los valores del Producto</returns>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public EPaciente GetByid(int idPaciente)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            //using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString()))
            {
                    cnx.Open();

                    const string sqlGetById = "SELECT * FROM paciente WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                    {
                        //
                        //Utilizamos el valor del parámetro idProducto para enviarlo al parámetro declarado en la consulta
                        //de selección SQL
                        cmd.Parameters.AddWithValue("@id", idPaciente);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        if (dataReader.Read())
                        {
                            EPaciente paciente = new EPaciente
                            {
                                id = Convert.ToInt32(dataReader["id"]),
                                apellido = Convert.ToString(dataReader["apellido"]),
                                nombre = Convert.ToString(dataReader["nombre"]),
                                sexo = Convert.ToString(dataReader["sexo"])
                            };

                            return paciente;
                        }
                    }
                }

                return null;
            }

            /// <summary>
            /// Actualiza el Producto correspondiente al Id proporcionado
            /// </summary>
            /// <param name="producto">Valores utilizados para hacer el Update al registro</param>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public void Update(EPaciente paciente)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery =
                        "UPDATE paciente SET apellido = @apellidos, nombre = @nombre, sexo = @sexo WHERE Id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@apellidos", paciente.apellido);
                        cmd.Parameters.AddWithValue("@nombre", paciente.nombre);
                        cmd.Parameters.AddWithValue("@sexo", paciente.sexo);
                        cmd.Parameters.AddWithValue("@id", paciente.id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            /// <summary>
            /// Elimina un registro coincidente con el Id Proporcionado
            /// </summary>
            /// <param name="idproducto">Id del registro a Eliminar</param>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public void Delete(int idpaciente)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery = "DELETE FROM paciente WHERE Id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@id", idpaciente);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }