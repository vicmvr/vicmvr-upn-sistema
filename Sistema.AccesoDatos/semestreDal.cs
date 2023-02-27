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
    public class semestreDal
    {
        //Primero y siguiendo el orden de las acciones CRUD
        //Crearemos un Método que se encarga de insertar un nuevo entidad es nuestra tabla semestre
        /// <summary>
        /// Inserta un nuevo semestre en la tabla semestre
        /// </summary>
        /// <param name="semestre">Entidad contenedora de los valores a insertar</param>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public void Insert(ESemestre semestre)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones

            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            { 
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO semestre (semestre,idsemestre) VALUES (@semestre,@idsemestre)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                    //ya no leeremos controles sino usaremos las propiedades del Objeto ESemestre de nuestra capa
                    //de entidades...
                    cmd.Parameters.AddWithValue("@semestre", semestre.semestre);
                    cmd.Parameters.AddWithValue("@idsemestre", semestre.idsemestre);
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
        public List<ESemestre> GetAll()
            {
                //Declaramos una lista del objeto ESemestre la cual será la encargada de
                //regresar una colección de los elementos que se obtengan de la BD
                //
                //La lista substituye a DataTable utilizado en el proyecto de ejemplo
                List<ESemestre> semestres = new List<ESemestre>();
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();

                    const string sqlQuery = "SELECT * FROM semestre ORDER BY idsemestre ASC";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        //
                        //Preguntamos si el DataReader fue devuelto con datos
                        while (dataReader.Read())
                        {
                            //
                            //Instanciamos al objeto ESemestre para llenar sus propiedades
                            ESemestre semestre = new ESemestre
                            {
                                idsemestre = Convert.ToInt32(dataReader["idsemestre"]),
                                semestre = Convert.ToInt32(dataReader["semestre"])
                                //idsemestre = Convert.ToString(dataReader["idsemestre"]),
                                //idsemestre = Convert.ToString(dataReader["idsemestre"])
                                //sexo = Convert.ToString(dataReader["sexo"])
                            };
                        //
                        //Insertamos el objeto Carga dentro de la lista Carreras
                        semestres.Add(semestre);
                        }
                    }
                }
                return semestres;
            }
            /// <summary>
            /// Devuelve un Objeto Docente
            /// </summary>
            /// <param name="idsemestre">Id de semestre a buscar</param>
            /// <returns>Un registro con los valores de semestre</returns>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public ESemestre GetByid(int idsemestre)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                conn.Open();

                const string sqlGetById = "SELECT semestre.idsemestre,semestre.idsemestre,semestre.semestre,semestre.idsemestre,semestre.idsemestre,semestre.semestre  FROM semestre WHERE idsemestre = @idsemestre INNER JOIN semestre ON semestre.idsemestre = 1 ";
                    using (MySqlCommand cmd = new MySqlCommand(sqlGetById, conn))
                    {
                        //
                        //Utilizamos el valor del parámetro idDocente para enviarlo al parámetro declarado en la consulta
                        //de selección SQL
                        cmd.Parameters.AddWithValue("@idsemestre", idsemestre);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        if (dataReader.Read())
                        {
                            ESemestre semestre = new ESemestre
                            {
                                idsemestre = Convert.ToInt32(dataReader["idsemestre"]),
                                semestre = Convert.ToInt32(dataReader["semestre"]),
                                //idsemestre = Convert.ToString(dataReader["idsemestre"])
                                //sexo = Convert.ToString(dataReader["sexo"])
                            };

                            return semestre;
                        }
                    }
                }

                return null;
            }
        /// <summary>
        /// Actualiza Semestre correspondiente al Id proporcionado
        /// </summary>
        /// <param name="Semestre">Valores utilizados para hacer el Update al registro</param>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public void Update(ESemestre semestre)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery =
                        "UPDATE semestre SET  semestre = @semestre, idsemestre = @idsemestre WHERE idsemestre = @idsemestre";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                    cmd.Parameters.AddWithValue("@idsemestre", semestre.idsemestre);
                    cmd.Parameters.AddWithValue("@semestre", semestre.semestre);
                    //cmd.Parameters.AddWithValue("@idsemestre", semestre.idsemestre);
                    //cmd.Parameters.AddWithValue("@sexo", docente.sexo);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            /// <summary>
            /// Elimina un registro coincidente con el Id Proporcionado
            /// </summary>
            /// <param name="idSemestre">Id del registro a Eliminar</param>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public void Delete(int idsemestre)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery = "DELETE FROM semestre WHERE idsemestre = @idsemestre";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@idsemestre", idsemestre);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }