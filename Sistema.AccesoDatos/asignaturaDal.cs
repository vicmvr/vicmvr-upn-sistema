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
    public class asignaturaDal
    {
        //Primero y siguiendo el orden de las acciones CRUD
        //Crearemos un Método que se encarga de insertar un nuevo Pacient es nuestra tabla asignatura
        /// <summary>
        /// Inserta un nuevo asignatura en la tabla asignatura
        /// </summary>
        /// <param name="docente">Entidad contenedora de los valores a insertar</param>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public void Insert(EAsignatura asignatura)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones

            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            { 
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO asignatura (nombre,idcarrera) VALUES (@nombre,@idcarrera)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                    //ya no leeremos controles sino usaremos las propiedades del Objeto EDocente de nuestra capa
                    //de entidades...
                    cmd.Parameters.AddWithValue("@nombre", asignatura.nombre);
                    cmd.Parameters.AddWithValue("@idcarrera", asignatura.idcarrera);
                    //cmd.Parameters.AddWithValue("@sexo", docente.sexo);
                    //cmd.Parameters.AddWithValue("@id", docente.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista de asignaturas filtradas y ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de Asignaturas</returns>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public List<EAsignatura> GetAllFiltrado(int idcarrera,int idsemestre)
        {
            //Declaramos una lista del objeto EAsignatura la cual será la encargada de
            //regresar una colección de los elementos que se obtengan de la BD
            //
            //La lista substituye a DataTable utilizado en el proyecto de ejemplo
            List<EAsignatura> asignaturas = new List<EAsignatura>();
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();

                string sqlQuery = "SELECT asig.idasignatura,asig.idcarrera,asig.nombre,asig.idsemestre,carr.nombre as carrera FROM asignatura asig INNER JOIN carrera carr ON asig.idcarrera = carr.idcarrera INNER JOIN semestre sem ON asig.idsemestre = sem.idsemestre WHERE asig.idcarrera = " + idcarrera + " AND sem.idsemestre =" + idsemestre + " ORDER BY idasignatura ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto ECartga para llenar sus propiedades
                        EAsignatura asignatura = new EAsignatura
                        {
                            idasignatura = Convert.ToInt32(dataReader["idasignatura"]),
                            nombre = Convert.ToString(dataReader["nombre"]),
                            idcarrera = Convert.ToString(dataReader["idcarrera"]),
                            idsemestre = Convert.ToString(dataReader["idsemestre"])
                            //sexo = Convert.ToString(dataReader["sexo"])
                        };
                        //
                        //Insertamos el objeto Carga dentro de la lista Cargas
                        asignaturas.Add(asignatura);
                    }
                }
            }
            return asignaturas;
        }

        /// <summary>
        /// Devuelve una lista de asignaturas ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de Asignaturas</returns>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public List<EAsignatura> GetAll()
            {
                //Declaramos una lista del objeto EAsignatura la cual será la encargada de
                //regresar una colección de los elementos que se obtengan de la BD
                //
                //La lista substituye a DataTable utilizado en el proyecto de ejemplo
                List<EAsignatura> asignaturas = new List<EAsignatura>();
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();

                    const string sqlQuery = "SELECT * FROM asignatura ORDER BY idasignatura ASC";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        //
                        //Preguntamos si el DataReader fue devuelto con datos
                        while (dataReader.Read())
                        {
                            //
                            //Instanciamos al objeto ECartga para llenar sus propiedades
                            EAsignatura asignatura = new EAsignatura
                            {
                                idasignatura = Convert.ToInt32(dataReader["idasignatura"]),
                                nombre = Convert.ToString(dataReader["nombre"]),
                                idcarrera = Convert.ToString(dataReader["idcarrera"]),
                                idsemestre = Convert.ToString(dataReader["idsemestre"])
                                //sexo = Convert.ToString(dataReader["sexo"])
                            };
                        //
                        //Insertamos el objeto Carga dentro de la lista Cargas
                        asignaturas.Add(asignatura);
                        }
                    }
                }
                return asignaturas;
            }

        /// <summary>
        /// Devuelve un Objeto Asignatura
        /// </summary>
        /// <param name="idasignatura">Id de asignatura a buscar</param>
        /// <returns>Un registro con los valores de asignatura</returns>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        //public EAsignatura GetByid(int idcarrera, int idasignatura)
        public EAsignatura GetByid(int idasignatura)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                conn.Open();

                const string sqlGetById = "SELECT asignatura.idasignatura,asignatura.idcarrera,asignatura.nombre,asignatura.idsemestre,carrera.idcarrera,carrera.nombre  FROM asignatura WHERE idasignatura = @idasignatura INNER JOIN carrera ON carrera.idcarrera = 1 ";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, conn))
                {
                    //
                    //Utilizamos el valor del parámetro idDocente para enviarlo al parámetro declarado en la consulta
                    //de selección SQL
                    cmd.Parameters.AddWithValue("@idasignatura", idasignatura);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EAsignatura asignatura = new EAsignatura
                        {
                            idasignatura = Convert.ToInt32(dataReader["idasignatura"]),
                            nombre = Convert.ToString(dataReader["nombre"]),
                            idcarrera = Convert.ToString(dataReader["idcarrera"])
                            //sexo = Convert.ToString(dataReader["sexo"])
                        };

                        return asignatura;
                    }
                }
            }

            return null;
        }
       
        /// <summary>
        /// Actualiza Asignatura correspondiente al Id proporcionado
        /// </summary>
        /// <param name="Asignatura">Valores utilizados para hacer el Update al registro</param>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public void Update(EAsignatura asignatura)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery =
                        "UPDATE asignatura SET  nombre = @nombre, idcarrera = @idcarrera WHERE idasignatura = @idasignatura";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                    cmd.Parameters.AddWithValue("@idasignatura", asignatura.idasignatura);
                    cmd.Parameters.AddWithValue("@nombre", asignatura.nombre);
                    cmd.Parameters.AddWithValue("@idcarrera", asignatura.idcarrera);
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
            public void Delete(int idasignatura)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery = "DELETE FROM asignatura WHERE idasignatura = @idasignatura";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@idasignatura", idasignatura);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }