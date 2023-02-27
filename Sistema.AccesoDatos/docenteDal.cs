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
    public class docenteDal
    {
        //Primero y siguiendo el orden de las acciones CRUD
        //Crearemos un Método que se encarga de insertar un nuevo Pacient es nuestra tabla Pacient
        /// <summary>
        /// Inserta un nuevo docente en la tabla docente
        /// </summary>
        /// <param name="docente">Entidad contenedora de los valores a insertar</param>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public void Insert(EDocente docente)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones

            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            { 
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO docente (nombre,apellidop,apellidom,rfc,curp,correo,telefono) VALUES (@nombre,@apellidop,@apellidom,@rfc,@curp,@correo,@telefono)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                    //ya no leeremos controles sino usaremos las propiedades del Objeto EDocente de nuestra capa
                    //de entidades...
                    cmd.Parameters.AddWithValue("@nombre", docente.nombre);
                    cmd.Parameters.AddWithValue("@apellidop", docente.apellidop);
                    cmd.Parameters.AddWithValue("@apellidom", docente.apellidom);
                    cmd.Parameters.AddWithValue("@rfc", docente.rfc);
                    cmd.Parameters.AddWithValue("@curp", docente.curp);
                    cmd.Parameters.AddWithValue("@correo", docente.correo);
                    cmd.Parameters.AddWithValue("@telefono", docente.telefono);
                    //cmd.Parameters.AddWithValue("@sexo", docente.sexo);
                    //cmd.Parameters.AddWithValue("@id", docente.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Devuelve una lista de Docentes ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de Docentes</returns>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public List<EDocente> GetAll()
            {
                //Declaramos una lista del objeto EDocente la cual será la encargada de
                //regresar una colección de los elementos que se obtengan de la BD
                //
                //La lista substituye a DataTable utilizado en el proyecto de ejemplo
                List<EDocente> docentes = new List<EDocente>();
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();

                    const string sqlQuery = "SELECT * FROM docente ORDER BY iddocente ASC";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        //
                        //Preguntamos si el DataReader fue devuelto con datos
                        while (dataReader.Read())
                        {
                            //
                            //Instanciamos al objeto EDocente para llenar sus propiedades
                            EDocente docente = new EDocente
                            {
                                iddocente = Convert.ToInt32(dataReader["iddocente"]),
                                nombre = Convert.ToString(dataReader["nombre"]),
                                apellidop = Convert.ToString(dataReader["apellidop"]),
                                apellidom = Convert.ToString(dataReader["apellidom"]),
                                rfc = Convert.ToString(dataReader["rfc"]),
                                curp = Convert.ToString(dataReader["curp"]),
                                correo = Convert.ToString(dataReader["correo"]),
                                telefono = Convert.ToString(dataReader["telefono"]),
                                //sexo = Convert.ToString(dataReader["sexo"])
                            };
                            //
                            //Insertamos el objeto Docente dentro de la lista Docentes
                            docentes.Add(docente);
                        }
                    }
                }
                return docentes;
            }
            /// <summary>
            /// Devuelve un Objeto Docente
            /// </summary>
            /// <param name="idDocente">Id del Docente a buscar</param>
            /// <returns>Un registro con los valores del Docente</returns>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public EDocente GetByid(int iddocente)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                conn.Open();

                const string sqlGetById = "SELECT * FROM docente WHERE iddocente = @iddocente";
                    using (MySqlCommand cmd = new MySqlCommand(sqlGetById, conn))
                    {
                        //
                        //Utilizamos el valor del parámetro idDocente para enviarlo al parámetro declarado en la consulta
                        //de selección SQL
                        cmd.Parameters.AddWithValue("@iddocente", iddocente);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        if (dataReader.Read())
                        {
                            EDocente docente = new EDocente
                            {
                                iddocente = Convert.ToInt32(dataReader["iddocente"]),
                                nombre = Convert.ToString(dataReader["nombre"]),
                                apellidop = Convert.ToString(dataReader["apellidop"]),
                                apellidom = Convert.ToString(dataReader["apellidom"]),
                                rfc = Convert.ToString(dataReader["rfc"]),
                                curp = Convert.ToString(dataReader["curp"]),
                                correo = Convert.ToString(dataReader["correo"]),
                                telefono = Convert.ToString(dataReader["telefono"]),
                                //sexo = Convert.ToString(dataReader["sexo"])
                            };

                            return docente;
                        }
                    }
                }

                return null;
            }

            /// <summary>
            /// Actualiza el Docente correspondiente al Id proporcionado
            /// </summary>
            /// <param name="Docente">Valores utilizados para hacer el Update al registro</param>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public void Update(EDocente docente)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery =
                        "UPDATE docente SET  nombre = @nombre, apellidop = @apellidop, apellidom = @apellidom, rfc = @rfc, curp = @curp, correo = @correo, telefono = @telefono WHERE iddocente = @iddocente";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                    cmd.Parameters.AddWithValue("@iddocente", docente.iddocente);
                    cmd.Parameters.AddWithValue("@nombre", docente.nombre);
                    cmd.Parameters.AddWithValue("@apellidop", docente.apellidop);
                    cmd.Parameters.AddWithValue("@apellidom", docente.apellidom);
                    cmd.Parameters.AddWithValue("@rfc", docente.rfc);
                    cmd.Parameters.AddWithValue("@curp", docente.curp);
                    cmd.Parameters.AddWithValue("@correo", docente.correo);
                    cmd.Parameters.AddWithValue("@telefono", docente.telefono);
                    //cmd.Parameters.AddWithValue("@sexo", docente.sexo);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            /// <summary>
            /// Elimina un registro coincidente con el Id Proporcionado
            /// </summary>
            /// <param name="idDocente">Id del registro a Eliminar</param>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public void Delete(int iddocente)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery = "DELETE FROM docente WHERE iddocente = @iddocente";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@iddocente", iddocente);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }