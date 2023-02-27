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
    public class carreraDal
    {
        //Primero y siguiendo el orden de las acciones CRUD
        //Crearemos un Método que se encarga de insertar un nuevo Pacient es nuestra tabla carrera
        /// <summary>
        /// Inserta un nuevo carrera en la tabla carrera
        /// </summary>
        /// <param name="carrera">Entidad contenedora de los valores a insertar</param>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public void Insert(ECarrera carrera)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones

            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            { 
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO carrera (nombre,idcarrera) VALUES (@nombre,@idcarrera)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                    //ya no leeremos controles sino usaremos las propiedades del Objeto ECarrera de nuestra capa
                    //de entidades...
                    cmd.Parameters.AddWithValue("@nombre", carrera.nombre);
                    cmd.Parameters.AddWithValue("@idcarrera", carrera.idcarrera);
                    //cmd.Parameters.AddWithValue("@sexo", docente.sexo);
                    //cmd.Parameters.AddWithValue("@id", docente.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Devuelve una lista de Carreras ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de Carreras</returns>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public List<ECarrera> GetAll()
            {
                //Declaramos una lista del objeto ECarrera la cual será la encargada de
                //regresar una colección de los elementos que se obtengan de la BD
                //
                //La lista substituye a DataTable utilizado en el proyecto de ejemplo
                List<ECarrera> carreras = new List<ECarrera>();
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();

                    const string sqlQuery = "SELECT * FROM carrera ORDER BY idcarrera ASC";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        //
                        //Preguntamos si el DataReader fue devuelto con datos
                        while (dataReader.Read())
                        {
                            //
                            //Instanciamos al objeto ECarrera para llenar sus propiedades
                            ECarrera carrera = new ECarrera
                            {
                                idcarrera = Convert.ToInt32(dataReader["idcarrera"]),
                                nombre = Convert.ToString(dataReader["nombre"])
                                //idcarrera = Convert.ToString(dataReader["idcarrera"]),
                                //idsemestre = Convert.ToString(dataReader["idsemestre"])
                                //sexo = Convert.ToString(dataReader["sexo"])
                            };
                        //
                        //Insertamos el objeto Carga dentro de la lista Carreras
                        carreras.Add(carrera);
                        }
                    }
                }
                return carreras;
            }
            /// <summary>
            /// Devuelve un Objeto Docente
            /// </summary>
            /// <param name="idcarrera">Id de carrera a buscar</param>
            /// <returns>Un registro con los valores de carrera</returns>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public ECarrera GetByid(int idcarrera)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                conn.Open();

                const string sqlGetById = "SELECT carrera.idcarrera,carrera.idcarrera,carrera.nombre,carrera.idsemestre,carrera.idcarrera,carrera.nombre  FROM carrera WHERE idcarrera = @idcarrera INNER JOIN carrera ON carrera.idcarrera = 1 ";
                    using (MySqlCommand cmd = new MySqlCommand(sqlGetById, conn))
                    {
                        //
                        //Utilizamos el valor del parámetro idDocente para enviarlo al parámetro declarado en la consulta
                        //de selección SQL
                        cmd.Parameters.AddWithValue("@idcarrera", idcarrera);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        if (dataReader.Read())
                        {
                            ECarrera carrera = new ECarrera
                            {
                                idcarrera = Convert.ToInt32(dataReader["idcarrera"]),
                                nombre = Convert.ToString(dataReader["nombre"]),
                                //idcarrera = Convert.ToString(dataReader["idcarrera"])
                                //sexo = Convert.ToString(dataReader["sexo"])
                            };

                            return carrera;
                        }
                    }
                }

                return null;
            }
            /// <summary>
            /// Actualiza Carga correspondiente al Id proporcionado
            /// </summary>
            /// <param name="Asignatura">Valores utilizados para hacer el Update al registro</param>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public void Update(ECarrera carrera)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery =
                        "UPDATE carrera SET  nombre = @nombre, idcarrera = @idcarrera WHERE idcarrera = @idcarrera";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                    cmd.Parameters.AddWithValue("@idcarrera", carrera.idcarrera);
                    cmd.Parameters.AddWithValue("@nombre", carrera.nombre);
                    //cmd.Parameters.AddWithValue("@idcarrera", carrera.idcarrera);
                    //cmd.Parameters.AddWithValue("@sexo", docente.sexo);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            /// <summary>
            /// Elimina un registro coincidente con el Id Proporcionado
            /// </summary>
            /// <param name="idAsignatura">Id del registro a Eliminar</param>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public void Delete(int idcarrera)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery = "DELETE FROM carrera WHERE idcarrera = @idcarrera";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@idcarrera", idcarrera);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }