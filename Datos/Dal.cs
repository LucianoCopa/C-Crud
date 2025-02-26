
    using System;
    using System.Collections.Generic;
  
    using System.Linq;
    using System.Text;

    using System.Threading.Tasks;

using Microsoft.Data.SqlClient;
using System.Data;
using Integrador2024.Entidades;
using System.Data.Common;
using System.Drawing;


namespace Integrador2024.Datos
    {
        public class Dal 
        {
            public static string SQL = string.Empty;

        public bool ValidarUsuario(string usuario, string contrasena)
        {
            string SQL = "SELECT COUNT(*) FROM USUARIO WHERE LOGIN = @usuario AND PASSW = @contrasena;";

            using (SqlConnection con = new SqlConnection(Conexion.sConnection))
            using (SqlCommand com = new SqlCommand(SQL, con))
            {
                // Agregar parámetros para evitar SQL Injection
                com.Parameters.AddWithValue("@usuario", usuario);
                com.Parameters.AddWithValue("@contrasena", contrasena);

                try
                {
                    con.Open();
                    int resultado = (int)com.ExecuteScalar(); // Devuelve el número de coincidencias
                    return resultado > 0; // Devuelve true si las credenciales son válidas
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error en la base de datos: " + ex.Message);
                }
            }
        }

        public DataSet BuscarProducto()
        {
            SQL = "SELECT * FROM PRODUCTO ORDER BY ID_PRODUCTO DESC";   

            //SQL = "SELECT * FROM PRODUCTO WHERE ID_PRODUCTO = '" + idProducto + "'";

            SqlConnection con = new SqlConnection(Conexion.sConnection);
            //Clase DataSet: es un objeto contenedor, almacena temporalmente la información de la base de datos
            DataSet objDataset = new DataSet();
            //Clase SqlCommand: permite ejecutar comandos(sentencias Sql o procedimientos almacenados (Sp))
            SqlCommand com = new SqlCommand(SQL, con); // como parametro utiliza la variable SQL con el comando Select...
            //Clase SqlDataAdapter:sirve como puente entre DataSet y SQL Server para recuperar y guardar datos
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com;

            try
            {
                //SqlDataAdapter proporciona este puente mediante la asignación de Fill
                da.Fill(objDataset); //Agrega o actualiza filas en el DataSet
            }
            catch (SqlException ex) //La excepción que se produce cuando SQL devuelve una advertencia o un error
            {
                throw new Exception("error en la base de datos" + ex.Message);
            }
            finally
            {
                con.Dispose();  //Libera todos los recursos que usa la conexion
                com.Dispose();  //Libera todos los recursos que usa los comandos/sentencias
            }
            return objDataset;  //retorna información
        }
        public DataSet ProductoEdit(string nombreEdit)
        {
            SQL = "SELECT * FROM PRODUCTO WHERE NOMBRE ='" + nombreEdit + "'";

            

            SqlConnection con = new SqlConnection(Conexion.sConnection);
            
            DataSet objDataset = new DataSet();
            
            SqlCommand com = new SqlCommand(SQL, con); 
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com;

            try
            {
               
                da.Fill(objDataset); 
            }
            catch (SqlException ex) 
            {
                throw new Exception("error en la base de datos" + ex.Message);
            }
            finally
            {
                con.Dispose();  
                com.Dispose();  
            }
            return objDataset;  
        }
        public DataSet ValidarLogin(string usuarioV, string contrasenaV)
        {
            SQL = "SELECT * FROM USUARIO WHERE LOGIN ='" + usuarioV + "' AND PASSW='" + contrasenaV + "'";

            

            SqlConnection con = new SqlConnection(Conexion.sConnection);
            
            DataSet objDataset = new DataSet();
            
            SqlCommand com = new SqlCommand(SQL, con); 
            
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com;

            try
            {
                
                da.Fill(objDataset); 
            }
            catch (SqlException ex) 
            {
                throw new Exception("error en la base de datos" + ex.Message);
            }
            finally
            {
                con.Dispose();  
                com.Dispose();  
            }
            return objDataset;  
        }

        public DataSet BuscarProductoId(int idProducto)
        {
            SQL = "SELECT * FROM PRODUCTO WHERE ID_PRODUCTO ='" + idProducto + "'";

            

            SqlConnection con = new SqlConnection(Conexion.sConnection);
           
            DataSet objDataset = new DataSet();
          
            SqlCommand com = new SqlCommand(SQL, con);
            
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com;

            try
            {
                
                da.Fill(objDataset); 
            }
            catch (SqlException ex) 
            {
                throw new Exception("error en la base de datos" + ex.Message);
            }
            finally
            {
                con.Dispose();  
                com.Dispose();  
            }
            return objDataset; 
        }
        public DataSet BuscarProductoNombre(string nombreProducto)
        {
            SQL = "SELECT * FROM PRODUCTO WHERE NOMBRE LIKE '%' + '" + nombreProducto + "' + '%'";
          

            SqlConnection con = new SqlConnection(Conexion.sConnection);
           
            DataSet objDataset = new DataSet();
            
            SqlCommand com = new SqlCommand(SQL, con); 
            
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com;

            try
            {
                
                da.Fill(objDataset); 
            }
            catch (SqlException ex) 
            {
                throw new Exception("error en la base de datos" + ex.Message);
            }
            finally
            {
                con.Dispose();  
                com.Dispose();  
            }
            return objDataset;  
        }
        public DataSet BuscarVendedor()
        {
            SQL = "SELECT * FROM VENDEDOR ORDER BY ID_VENDEDOR DESC";

            SqlConnection con = new SqlConnection(Conexion.sConnection);
           
            DataSet objDataset = new DataSet();
            
            SqlCommand com = new SqlCommand(SQL, con); 
            
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com;

            try
            {
               
                da.Fill(objDataset); 
            }
            catch (SqlException ex) 
            {
                throw new Exception("error en la base de datos" + ex.Message);
            }
            finally
            {
                con.Dispose();  
                com.Dispose();  
            }
            return objDataset;  
        }
        public DataSet BuscarVendedorGrilla(string dniVendedor)
        {
            SQL = "SELECT * FROM VENDEDOR WHERE DNI='" + dniVendedor + "'";

            SqlConnection con = new SqlConnection(Conexion.sConnection);
            //Clase DataSet: es un objeto contenedor, almacena temporalmente la información de la base de datos
            DataSet objDataset = new DataSet();
            //Clase SqlCommand: permite ejecutar comandos(sentencias Sql o procedimientos almacenados (Sp))
            SqlCommand com = new SqlCommand(SQL, con); // como parametro utiliza la variable SQL con el comando Select...
            //Clase SqlDataAdapter:sirve como puente entre DataSet y SQL Server para recuperar y guardar datos
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com;

            try
            {
                //SqlDataAdapter proporciona este puente mediante la asignación de Fill
                da.Fill(objDataset); //Agrega o actualiza filas en el DataSet
            }
            catch (SqlException ex) //La excepción que se produce cuando SQL devuelve una advertencia o un error
            {
                throw new Exception("error en la base de datos" + ex.Message);
            }
            finally
            {
                con.Dispose();  //Libera todos los recursos que usa la conexion
                com.Dispose();  //Libera todos los recursos que usa los comandos/sentencias
            }
            return objDataset;  //retorna información
        }

        public DataSet BuscarNombreGrilla(string nombreVendedor) 
        {
            SQL = "SELECT * FROM VENDEDOR WHERE NOMBRE LIKE '%' + '" + nombreVendedor + "' + '%'";
            SqlConnection con = new SqlConnection(Conexion.sConnection);
            
            DataSet objDataset = new DataSet();
            
            SqlCommand com = new SqlCommand(SQL, con); 
     
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com;

            try
            {
                
                da.Fill(objDataset); 
            }
            catch (SqlException ex) 
            {
                throw new Exception("error en la base de datos" + ex.Message);
            }
            finally
            {
                con.Dispose();  
                com.Dispose();  
            }
            return objDataset;  
        }

        private int identidad;
        public int Identidad
        {
            get
            {
                return identidad;
            }
            set
            {
                identidad = value;
            }
        }

        public static SqlTransaction objTransaction = null;
        public int AgregarProducto(string pNOmbre, string pDescripcion, decimal pPrecioCosto
            , double pMargen, double pIVA, decimal pPrecioBruto, decimal pPrecioVenta
            , string pProveedor, string pCategoria, string pSubcategoria, string productoFotoJpg) 
        {
            SQL = "INSERT INTO PRODUCTO(NOMBRE, DESCRIPCION, PRECIOCOSTO, MARGEN, IVA, PRECIOBRUTO, PRECIOVENTA, PROVEEDOR, CATEGORIA, SUBCATEGORIA, FOTO_JPG) VALUES";
            SQL = SQL + "(@pNOmbre, @pDescripcion, @pPrecioCosto, @pMargen, @pIVA,@pPrecioBruto,@pPrecioVenta, @pProveedor, @pCategoria, @pSubcategoria, @productoFotoJpg)";

            SqlConnection con = new SqlConnection(Conexion.sConnection);
            SqlCommand com = new SqlCommand(SQL, con);
            SqlParameter retParam = com.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
            retParam.Direction = ParameterDirection.ReturnValue;

            com.Parameters.Add("@pNombre", SqlDbType. VarChar, 30).Value = pNOmbre;
            com.Parameters.Add("@pDescripcion", SqlDbType.VarChar, 150).Value = pDescripcion;
            com.Parameters.Add("@pPrecioCosto", SqlDbType.Money).Value = pPrecioCosto;
            com.Parameters.Add("@pMargen", SqlDbType.Decimal, 10).Value = pMargen;
            com.Parameters.Add("@pIVA", SqlDbType.Int).Value = pIVA;
            com.Parameters.Add("@pPrecioBruto", SqlDbType.Money).Value = pPrecioBruto;
            com.Parameters.Add("@pPrecioVenta", SqlDbType.Money).Value = pPrecioVenta;
            com.Parameters.Add("@pProveedor", SqlDbType.VarChar, 100).Value = pProveedor;
            com.Parameters.Add("@pCategoria", SqlDbType.VarChar, 15).Value = pCategoria; 
            com.Parameters.Add("@pSubcategoria", SqlDbType.VarChar, 20).Value = pSubcategoria;
            com.Parameters.Add("@productoFotoJpg", SqlDbType.VarChar, 100).Value = productoFotoJpg;

            try
            {
                con.Open();
                //declara un objeto Transaction y comienza la transaccion
                objTransaction = con.BeginTransaction();
                com.Transaction = objTransaction;

                com.ExecuteNonQuery();
                identidad = Convert.ToInt32(retParam.Value);
                //Commit: confirma los comandos que se han ejecutadoen el contexto de la transaccion
                objTransaction.Commit(); 
            }
            catch (SqlException ex)
            {
                //Rollback:cancela los comandos que se han ejecutado en el contexto de la transaccion
                objTransaction.Rollback();
                throw new Exception("Error en Base de Datos " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Dispose();
                com.Dispose();
            }
            return identidad;


        }

        public int ModificarProducto(string pNombre, string pDescripcion, decimal pPrecioCosto
    , double pMargen, double pIVA, decimal pPrecioBruto, decimal pPrecioVenta
    , string pProveedor, string pCategoria, string pSubcategoria, string productoFotoJpg)
        {
            SQL = "UPDATE PRODUCTO SET DESCRIPCION=@pDescripcion, PRECIOCOSTO=@pPrecioCosto, MARGEN=@pMargen, "; 
            SQL= SQL + "IVA=@pIVA, PRECIOBRUTO=@pPrecioBruto, PRECIOVENTA=@pPrecioVenta, PROVEEDOR=@pProveedor, CATEGORIA=@pCategoria, SUBCATEGORIA=@pSubcategoria, FOTO_JPG=@productoFotoJpg ";
          //  SQL = SQL + "(@pDescripcion, @pPrecioCosto, @pMargen, @pIVA,@pPrecioBruto,@pPrecioVenta, @pProveedor, @pCategoria, @pSubcategoria)"; ayuda de memoria
            SQL = SQL + "WHERE NOMBRE = '"+ pNombre  +"'";

            SqlConnection con = new SqlConnection(Conexion.sConnection);
            SqlCommand com = new SqlCommand(SQL, con);
            SqlParameter retParam = com.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
            retParam.Direction = ParameterDirection.ReturnValue;

            com.Parameters.Add("@pNombre", SqlDbType.VarChar, 30).Value = pNombre;
            com.Parameters.Add("@pDescripcion", SqlDbType.VarChar, 150).Value = pDescripcion;
            com.Parameters.Add("@pPrecioCosto", SqlDbType.Money).Value = pPrecioCosto;
            com.Parameters.Add("@pMargen", SqlDbType.Decimal, 10).Value = pMargen;
            com.Parameters.Add("@pIVA", SqlDbType.Int).Value = pIVA;
            com.Parameters.Add("@pPrecioBruto", SqlDbType.Money).Value = pPrecioBruto;
            com.Parameters.Add("@pPrecioVenta", SqlDbType.Money).Value = pPrecioVenta;
            com.Parameters.Add("@pProveedor", SqlDbType.VarChar, 100).Value = pProveedor;
            com.Parameters.Add("@pCategoria", SqlDbType.VarChar, 15).Value = pCategoria;
            com.Parameters.Add("@pSubcategoria", SqlDbType.VarChar, 20).Value = pSubcategoria;
            com.Parameters.Add("@productoFotoJpg", SqlDbType.VarChar, 100).Value= productoFotoJpg;

            try
            {
                con.Open();
               
                objTransaction = con.BeginTransaction();
                com.Transaction = objTransaction;

                com.ExecuteNonQuery();
                identidad = Convert.ToInt32(retParam.Value);
              
                objTransaction.Commit(); 
            }
            catch (SqlException ex)
            {
                objTransaction.Rollback();
                throw new Exception("Error en Base de Datos " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Dispose();
                com.Dispose();
            }
            return identidad;


        }
        public DataSet EliminarProducto(string nombrePoducto) 
        {
            SQL = "DELETE FROM PRODUCTO ";
            SQL = SQL + "WHERE NOMBRE='" + nombrePoducto + "'";


            SqlConnection con = new SqlConnection(Conexion.sConnection);
  
            DataSet objDataset = new DataSet();

            SqlCommand com = new SqlCommand(SQL, con); 

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com;

            try
            {

                da.Fill(objDataset);
            }
            catch (SqlException ex) 
            {
                throw new Exception("error en la base de datos" + ex.Message);
            }
            finally
            {
                con.Dispose();  
                com.Dispose();  
            }
            return objDataset; 
        }
        public DataSet EliminarVendedor1(string dniVendedor1)
        {
            SQL = "DELETE FROM VENDEDOR ";
            SQL = SQL + "WHERE DNI='" + dniVendedor1 + "'";


            SqlConnection con = new SqlConnection(Conexion.sConnection);

            DataSet objDataset = new DataSet();

            SqlCommand com = new SqlCommand(SQL, con);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com;

            try
            {

                da.Fill(objDataset);
            }
            catch (SqlException ex)
            {
                throw new Exception("error en la base de datos" + ex.Message);
            }
            finally
            {
                con.Dispose();
                com.Dispose();
            }
            return objDataset;
        }


        public int RegistrarVendedor(string pNombreV, string pApellidoV, string pDniV, string pCuilV, string pFotoJpgV)
        {
            SQL = "INSERT INTO VENDEDOR(NOMBRE, APELLIDO, DNI, CUIT, FOTOVENDEDOR_JPG) VALUES";
            SQL = SQL + "(@pNombreV, @pApellidoV, @pDniV, @pCuilV, @pFotoJpgV)";

            SqlConnection con = new SqlConnection(Conexion.sConnection);
            SqlCommand com = new SqlCommand(SQL, con);
            SqlParameter retParam = com.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
            retParam.Direction = ParameterDirection.ReturnValue;

            com.Parameters.Add("@pNombreV", SqlDbType.VarChar, 100).Value = pNombreV;
            com.Parameters.Add("@pApellidoV", SqlDbType.VarChar, 100).Value = pApellidoV;
            com.Parameters.Add("@pDniV", SqlDbType.VarChar, 8).Value = pDniV;
            com.Parameters.Add("@pCuilV", SqlDbType.VarChar, 13).Value = pCuilV;
            com.Parameters.Add("@pFOtoJpgV", SqlDbType.VarChar, 100).Value = pFotoJpgV;


            try
            {
                con.Open();
               
                objTransaction = con.BeginTransaction();
                com.Transaction = objTransaction;

                com.ExecuteNonQuery();
                identidad = Convert.ToInt32(retParam.Value);
          
                objTransaction.Commit(); 
            }
            catch (SqlException ex)
            {
  
                objTransaction.Rollback();
                throw new Exception("Error en Base de Datos " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Dispose();
                com.Dispose();
            }
            return identidad;


        }

        public int ModificarVendedor(string pNombreV, string pApellidoV, string pDniV, string pCuilV, string pFotoJpgV)
        {
            SQL = "UPDATE VENDEDOR SET NOMBRE=@pNombreV, APELLIDO=@pApellidoV, ";
            SQL = SQL + "CUIT=@pCuilV, FOTOVENDEDOR_JPG=@pFotoJpgV ";
            //  SQL = SQL + "(@pDescripcion, @pPrecioCosto, @pMargen, @pIVA,@pPrecioBruto,@pPrecioVenta, @pProveedor, @pCategoria, @pSubcategoria)"; ayuda de  memoria
            SQL = SQL + "WHERE DNI='" + pDniV + "'";

                        SqlConnection con = new SqlConnection(Conexion.sConnection);
            SqlCommand com = new SqlCommand(SQL, con);
            SqlParameter retParam = com.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
            retParam.Direction = ParameterDirection.ReturnValue;

            com.Parameters.Add("@pNombreV", SqlDbType.VarChar, 100).Value = pNombreV;
            com.Parameters.Add("@pApellidoV", SqlDbType.VarChar, 100).Value = pApellidoV;
            com.Parameters.Add("@pDniV", SqlDbType.VarChar, 8).Value = pDniV;
            com.Parameters.Add("@pCuilV", SqlDbType.VarChar, 13).Value = pCuilV;
            com.Parameters.Add("@pFOtoJpgV", SqlDbType.VarChar, 100).Value = pFotoJpgV;


            try
            {
                con.Open();

                objTransaction = con.BeginTransaction();
                com.Transaction = objTransaction;

                com.ExecuteNonQuery();
                identidad = Convert.ToInt32(retParam.Value);
         
                objTransaction.Commit();  
            }
            catch (SqlException ex)
            {

                objTransaction.Rollback();
                throw new Exception("Error en Base de Datos " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Dispose();
                com.Dispose();
            }
            return identidad;
        }

        public int EliminarVendedor(string dniVendedor) 
        {
            SQL = "DELETE FROM VENDEDOR ";
            SQL = SQL + "WHERE DNI='" + dniVendedor + "'";

       
            SqlConnection con = new SqlConnection(Conexion.sConnection);

            DataSet objDataset = new DataSet();
            SqlCommand com = new SqlCommand(SQL, con); 
          
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com;

            try
            {
                da.Fill(objDataset); 
            }
            catch (SqlException ex)
            {
                throw new Exception("error en la base de datos" + ex.Message);
            }
            finally
            {
                con.Dispose();  
                com.Dispose(); 
            }
            return identidad;  //retorna información
        }


    }
    }
