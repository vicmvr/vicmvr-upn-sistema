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
    public class alumnoDal
    {
        //Primero y siguiendo el orden de las acciones CRUD
        //Crearemos un Método que se encarga de insertar un nuevo Pacient es nuestra tabla Pacient
        /// <summary>
        /// Inserta un nuevo Alumno en la tabla Alumno
        /// </summary>
        /// <param name="alumno">Entidad contenedora de los valores a insertar</param>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public void Insert(EAlumno alumno)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            { 
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO Alumno (apellidop,apellidom,nombre, sexo) VALUES (@apellidop,@apellidom, @nombre, @sexo)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                    //ya no leeremos controles sino usaremos las propiedades del Objeto EProducto de nuestra capa
                    //de entidades...
                    cmd.Parameters.AddWithValue("@apellidop", alumno.apellidop);
                    cmd.Parameters.AddWithValue("@apellidom", alumno.apellidom);
                    cmd.Parameters.AddWithValue("@nombre", alumno.nombre);
                    cmd.Parameters.AddWithValue("@sexo", alumno.sexo);
                    //cmd.Parameters.AddWithValue("@id", alumno.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
            /// <summary>
            /// Devuelve una lista de Productos ordenados por el campo Id de manera Ascendente
            /// </summary>
            /// <returns>Lista de productos</returns>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public List<EAlumno> GetAll()
            {
                //Declaramos una lista del objeto EProducto la cual será la encargada de
                //regresar una colección de los elementos que se obtengan de la BD
                //
                //La lista substituye a DataTable utilizado en el proyecto de ejemplo
                List<EAlumno> alumnos = new List<EAlumno>();
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();

                    const string sqlQuery = "SELECT * FROM alumno ORDER BY Id ASC";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        //
                        //Preguntamos si el DataReader fue devuelto con datos
                        while (dataReader.Read())
                        {
                            //
                            //Instanciamos al objeto Eproducto para llenar sus propiedades
                            EAlumno alumno = new EAlumno
                            {
                                id = Convert.ToInt32(dataReader["id"]),
                                apellidop = Convert.ToString(dataReader["apellidop"]),
                                apellidom = Convert.ToString(dataReader["apellidom"]),
                                nombre = Convert.ToString(dataReader["nombre"]),
                                sexo = Convert.ToString(dataReader["sexo"]),

                                programa = Convert.ToString(dataReader["programa"]),
                                grupo = Convert.ToString(dataReader["grupo"]),
                                matricula = Convert.ToString(dataReader["matricula"]),
                                curp = Convert.ToString(dataReader["curp"]),
                                idcreson = Convert.ToString(dataReader["idcreson"]),
                                referencia = Convert.ToString(dataReader["referencia"]),
                                sangre = Convert.ToString(dataReader["sangre"]),
                                fechaNacimiento = Convert.ToDateTime(dataReader["fechanac"]),
                                nss = Convert.ToString(dataReader["nss"]),
                                telefonoCelular= Convert.ToString(dataReader["celular"]),
                                telefonoCasa = Convert.ToString(dataReader["telefono"]),
                                edonac = Convert.ToString(dataReader["edonac"]),
                                generacion = Convert.ToString(dataReader["generacion"]),
                                correo = Convert.ToString(dataReader["correo"]),
                                bachillerato = Convert.ToString(dataReader["bachillerato"]),
                                prombachillerato = Convert.ToString(dataReader["prombachillerato"]),
                                comentario = Convert.ToString(dataReader["comentario"]),
                                direccion = Convert.ToString(dataReader["direccion"]),
                                //foto
                            };
                            //
                            //Insertamos el objeto Producto dentro de la lista Productos
                            alumnos.Add(alumno);
                        }
                    }
                }
                return alumnos;
            }
            /// <summary>
            /// Devuelve un Objeto Producto
            /// </summary>
            /// <param name="idProducto">Id del producto a buscar</param>
            /// <returns>Un registro con los valores del Producto</returns>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public EAlumno GetByid(int idAlumno)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            //using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString()))
            {
                    cnx.Open();

                    const string sqlGetById = "SELECT * FROM alumno WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                    {
                        //
                        //Utilizamos el valor del parámetro idProducto para enviarlo al parámetro declarado en la consulta
                        //de selección SQL
                        cmd.Parameters.AddWithValue("@id", idAlumno);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        if (dataReader.Read())
                        {
                        EAlumno alumno = new EAlumno
                        {
                            id = Convert.ToInt32(dataReader["id"]),
                            apellidop = Convert.ToString(dataReader["apellidop"]),
                            apellidom = Convert.ToString(dataReader["apellidom"]),
                            nombre = Convert.ToString(dataReader["nombre"]),
                            sexo = Convert.ToString(dataReader["sexo"]),

                            programa = Convert.ToString(dataReader["programa"]),
                            grupo = Convert.ToString(dataReader["grupo"]),
                            matricula = Convert.ToString(dataReader["matricula"]),
                            curp = Convert.ToString(dataReader["curp"]),
                            idcreson = Convert.ToString(dataReader["idcreson"]),
                            referencia = Convert.ToString(dataReader["referencia"]),
                            sangre = Convert.ToString(dataReader["sangre"]),
                            fechaNacimiento = Convert.ToDateTime(dataReader["fechanac"]),
                            nss = Convert.ToString(dataReader["nss"]),
                            telefonoCelular = Convert.ToString(dataReader["celular"]),
                            telefonoCasa = Convert.ToString(dataReader["telefono"]),
                            edonac = Convert.ToString(dataReader["edonac"]),
                            generacion = Convert.ToString(dataReader["generacion"]),
                            correo = Convert.ToString(dataReader["correo"]),
                            bachillerato = Convert.ToString(dataReader["bachillerato"]),
                            prombachillerato = Convert.ToString(dataReader["prombachillerato"]),
                            comentario = Convert.ToString(dataReader["comentario"]),
                            direccion = Convert.ToString(dataReader["direccion"]),
                            //foto = Convert.ToString(dataReader["direccion"])
                            };

                            return alumno;
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
            public void Update(EAlumno alumno)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery =
                        "UPDATE alumno SET apellidop = @apellidop,apellidom = @apellidom, nombre = @nombre, idcreson=@idcreson, programa=@programa, grupo= @grupo,matricula=@matricula, curp=@curp, referencia= @referencia, sangre= @sangre, fechanac= @fechanac, sexo= @sexo,nss= @nss, celular= @celular, telefono= @telefono, edonac= @edonac, generacion= @generacion, correo= @correo, bachillerato= @bachillerato, prombachillerato= @prombachillerato, comentario= @comentario, direccion= @direccion WHERE Id = @id";                
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", alumno.id);
                    cmd.Parameters.AddWithValue("@idcreson", alumno.idcreson);
                    cmd.Parameters.AddWithValue("@apellidop", alumno.apellidop);
                    cmd.Parameters.AddWithValue("@apellidom", alumno.apellidom);
                    cmd.Parameters.AddWithValue("@nombre", alumno.nombre);
                    cmd.Parameters.AddWithValue("@matricula", alumno.matricula);
                    cmd.Parameters.AddWithValue("@curp", alumno.curp);
                    cmd.Parameters.AddWithValue("@referencia", alumno.referencia);
                    cmd.Parameters.AddWithValue("@programa", alumno.programa);
                    cmd.Parameters.AddWithValue("@grupo", alumno.grupo);
                    cmd.Parameters.AddWithValue("@generacion", alumno.generacion);
                    cmd.Parameters.AddWithValue("@fechanac", alumno.fechaNacimiento);
                    cmd.Parameters.AddWithValue("@edonac", alumno.edonac);
                    cmd.Parameters.AddWithValue("@sexo", alumno.sexo);
                    cmd.Parameters.AddWithValue("@nss", alumno.nss);
                    cmd.Parameters.AddWithValue("@sangre", alumno.sangre);
                    cmd.Parameters.AddWithValue("@celular", alumno.telefonoCelular);
                    cmd.Parameters.AddWithValue("@telefono", alumno.telefonoCasa);
                    cmd.Parameters.AddWithValue("@correo", alumno.correo);
                    cmd.Parameters.AddWithValue("@bachillerato", alumno.bachillerato);
                    cmd.Parameters.AddWithValue("@prombachillerato", alumno.prombachillerato);
                    cmd.Parameters.AddWithValue("@direccion", alumno.direccion);
                    cmd.Parameters.AddWithValue("@comentario", alumno.comentario);

                    cmd.ExecuteNonQuery();
                    }
                }
            }

            /// <summary>
            /// Elimina un registro coincidente con el Id Proporcionado
            /// </summary>
            /// <param name="idproducto">Id del registro a Eliminar</param>
            /// <autor>Víctor Manuel Villagómez Ramos</autor>
            public void Delete(int idalumno)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                    const string sqlQuery = "DELETE FROM alumno WHERE Id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@id", idalumno);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }