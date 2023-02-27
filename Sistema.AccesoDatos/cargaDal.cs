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
    public class cargaDal
    {
        //Primero y siguiendo el orden de las acciones CRUD
        //Crearemos un Método que se encarga de insertar un nuevo Pacient es nuestra tabla carga
        /// <summary>
        /// Inserta un nuevo carga en la tabla carga
        /// </summary>
        /// <param name="docente">Entidad contenedora de los valores a insertar</param>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public void Insert(ECarga carga)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones

            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            { 
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO carga (ano,periodo) VALUES (@ano,@periodo)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                    //ya no leeremos controles sino usaremos las propiedades del Objeto EDocente de nuestra capa
                    //de entidades...
                    cmd.Parameters.AddWithValue("@ano", carga.ano);
                    cmd.Parameters.AddWithValue("@periodo", carga.periodo);
                    //cmd.Parameters.AddWithValue("@sexo", docente.sexo);
                    //cmd.Parameters.AddWithValue("@id", docente.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Devuelve una lista de Cargas ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de Cargas</returns>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public List<ECarga> GetAll()
            {
                //Declaramos una lista del objeto ECarga la cual será la encargada de
                //regresar una colección de los elementos que se obtengan de la BD
                //
                //La lista substituye a DataTable utilizado en el proyecto de ejemplo
                List<ECarga> cargas = new List<ECarga>();
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();

                    const string sqlQuery = "SELECT * FROM carga ORDER BY idcarga ASC";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        //
                        //Preguntamos si el DataReader fue devuelto con datos
                        while (dataReader.Read())
                        {
                            //
                            //Instanciamos al objeto ECartga para llenar sus propiedades
                            ECarga carga = new ECarga
                            {
                                idcarga = Convert.ToInt32(dataReader["idcarga"]),
                                ano = Convert.ToString(dataReader["ano"]),
                                periodo = Convert.ToString(dataReader["periodo"])
                                //sexo = Convert.ToString(dataReader["sexo"])
                            };
                        //
                        //Insertamos el objeto Carga dentro de la lista Cargas
                        cargas.Add(carga);
                        }
                    }
                }
                return cargas;
            }
            /// <summary>
            /// Devuelve un Objeto Docente
            /// </summary>
            /// <param name="idcarga">Id de carga a buscar</param>
            /// <returns>Un registro con los valores de carga</returns>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public ECarga GetByid(int idcarga)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                conn.Open();

                const string sqlGetById = "SELECT * FROM carga WHERE idcarga = @idcarga";
                    using (MySqlCommand cmd = new MySqlCommand(sqlGetById, conn))
                    {
                        //
                        //Utilizamos el valor del parámetro idDocente para enviarlo al parámetro declarado en la consulta
                        //de selección SQL
                        cmd.Parameters.AddWithValue("@idcarga", idcarga);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        if (dataReader.Read())
                        {
                            ECarga carga = new ECarga
                            {
                                idcarga = Convert.ToInt32(dataReader["idcarga"]),
                                ano = Convert.ToString(dataReader["ano"]),
                                periodo = Convert.ToString(dataReader["periodo"])
                                //sexo = Convert.ToString(dataReader["sexo"])
                            };

                            return carga;
                        }
                    }
                }

                return null;
            }

            /// <summary>
            /// Actualiza Carga correspondiente al Id proporcionado
            /// </summary>
            /// <param name="Carga">Valores utilizados para hacer el Update al registro</param>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public void Update(ECarga carga)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery =
                        "UPDATE carga SET  ano = @ano, periodo = @periodo WHERE idcarga = @idcarga";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                    cmd.Parameters.AddWithValue("@idcarga", carga.idcarga);
                    cmd.Parameters.AddWithValue("@ano", carga.ano);
                    cmd.Parameters.AddWithValue("@periodo", carga.periodo);
                    //cmd.Parameters.AddWithValue("@sexo", docente.sexo);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            /// <summary>
            /// Elimina un registro coincidente con el Id Proporcionado
            /// </summary>
            /// <param name="idCarga">Id del registro a Eliminar</param>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public void Delete(int idcarga)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery = "DELETE FROM carga WHERE idcarga = @idcarga";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@idcarga", idcarga);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }