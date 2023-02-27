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
    public class libroDal
    {
        //Primero y siguiendo el orden de las acciones CRUD
        //Crearemos un Método que se encarga de insertar un nuevo Pacient es nuestra tabla Pacient
        /// <summary>
        /// Inserta un nuevo Libro en la tabla Libro
        /// </summary>
        /// <param name="libro">Entidad contenedora de los valores a insertar</param>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public void Insert(ELibro libro)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            { 
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO Libro (titulo,autor,clasificacion,existencias,isbn) VALUES (@titulo,@autor,@clasificacion,@existencias,@isbn)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                    //ya no leeremos controles sino usaremos las propiedades del Objeto EProducto de nuestra capa
                    //de entidades...
                    cmd.Parameters.AddWithValue("@titulo", libro.titulo);
                    cmd.Parameters.AddWithValue("@autor", libro.autor);
                    cmd.Parameters.AddWithValue("@clasificacion", libro.clasificacion);
                    cmd.Parameters.AddWithValue("@existencias", libro.existencias);
                    cmd.Parameters.AddWithValue("@isbn", libro.isbn);

                    cmd.ExecuteNonQuery();
                }
            }
        }
            /// <summary>
            /// Devuelve una lista de Productos ordenados por el campo Id de manera Ascendente
            /// </summary>
            /// <returns>Lista de productos</returns>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public List<ELibro> GetAll()
            {
                //Declaramos una lista del objeto EProducto la cual será la encargada de
                //regresar una colección de los elementos que se obtengan de la BD
                //
                //La lista substituye a DataTable utilizado en el proyecto de ejemplo
                List<ELibro> libros = new List<ELibro>();
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();

                    const string sqlQuery = "SELECT * FROM libro ORDER BY Id ASC";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        //
                        //Preguntamos si el DataReader fue devuelto con datos
                        while (dataReader.Read())
                        {
                            //
                            //Instanciamos al objeto Eproducto para llenar sus propiedades
                            ELibro libro = new ELibro
                            {
                                id = Convert.ToInt32(dataReader["id"]),
                                titulo = Convert.ToString(dataReader["titulo"]),
                                autor = Convert.ToString(dataReader["autor"]),
                                clasificacion = Convert.ToString(dataReader["clasificacion"]),
                                existencias = Convert.ToString(dataReader["existencias"]),
                                isbn = Convert.ToString(dataReader["isbn"]),
                            };
                            //
                            //Insertamos el objeto Producto dentro de la lista Productos
                            libros.Add(libro);
                        }
                    }
                }
                return libros;
            }
            /// <summary>
            /// Devuelve un Objeto Producto
            /// </summary>
            /// <param name="idProducto">Id del producto a buscar</param>
            /// <returns>Un registro con los valores del Producto</returns>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public ELibro GetByid(int idLibro)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            //using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString()))
            {
                    cnx.Open();

                    const string sqlGetById = "SELECT * FROM libro WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                    {
                        //
                        //Utilizamos el valor del parámetro idProducto para enviarlo al parámetro declarado en la consulta
                        //de selección SQL
                        cmd.Parameters.AddWithValue("@id", idLibro);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        if (dataReader.Read())
                        {
                            ELibro libro = new ELibro
                            {
                                id = Convert.ToInt32(dataReader["id"]),
                                titulo = Convert.ToString(dataReader["titulo"]),
                                autor = Convert.ToString(dataReader["autor"]),
                                clasificacion = Convert.ToString(dataReader["clasificacion"]),
                                existencias = Convert.ToString(dataReader["existencias"]),
                                isbn = Convert.ToString(dataReader["isbn"]),
                            };

                            return libro;
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
            public void Update(ELibro libro)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery =
                        "UPDATE libro SET titulo = @titulo,autor=@autor,clasificacion=@clasificacion,existencias=@existencias,isbn=@isbn WHERE Id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@titulo", libro.titulo);
                        cmd.Parameters.AddWithValue("@autor", libro.autor);
                        cmd.Parameters.AddWithValue("@clasificacion", libro.clasificacion);
                        cmd.Parameters.AddWithValue("@existencias", libro.existencias);
                        cmd.Parameters.AddWithValue("@isbn", libro.isbn);
                        cmd.Parameters.AddWithValue("@id", libro.id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            /// <summary>
            /// Elimina un registro coincidente con el Id Proporcionado
            /// </summary>
            /// <param name="idproducto">Id del registro a Eliminar</param>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public void Delete(int idlibro)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery = "DELETE FROM libro WHERE Id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@id", idlibro);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }