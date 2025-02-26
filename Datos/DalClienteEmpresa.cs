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
    public class DalClienteEmpresa
    {
        public static string SQL = string.Empty;

        public DataSet ListarClientesEmpresa()
        {
            SQL = "SELECT * FROM CLIENTEEMPRESA ORDER BY ID DESC";

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
        public DataSet ListarIdClienteEmpresa(int idClienteEmpresa) 
        {
            SQL = "SELECT * FROM CLIENTEEMPRESA WHERE ID='" + idClienteEmpresa + "'";

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
        public DataSet ListarContactoClienteEmpresa(string contactoClienteEmpresa)
        {
            SQL = "SELECT * FROM CLIENTEEMPRESA WHERE CONTACTO LIKE '%" + contactoClienteEmpresa + "%' ";

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
        private int nuevoClienteEmpresaId;
        public int NuevoClienteEmpresaIndId
        {
            get
            {
                return nuevoClienteEmpresaId;
            }
            set
            {
                nuevoClienteEmpresaId = value;
            }
        }
        public DataSet EliminarClienteEmpresa(string idClienteEmpresaInd)
        {
            SQL = "DELETE FROM CLIENTEEMPRESA ";
            SQL = SQL + "WHERE ID = '" + idClienteEmpresaInd + "'";

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


        public static SqlTransaction objTransaction = null;
        public int NuevoClienteEmpresa(string pNombre, string pContacto, string pCuit, string pEmail,
            string pTelefono, string pDireccion, string pFotoJpg)
        {
            SQL = "INSERT INTO CLIENTEEMPRESA(NOMBRE, CONTACTO, CUIT ,MAIL, TELEFONO , DIRECCION, FOTOCLIENTEEMPRESA) VALUES";
            SQL = SQL + "(@pNombre, @pContacto, @pCuit, @pEmail, @pTelefono, @pDireccion, @pFotoJpg)";

            SqlConnection con = new SqlConnection(Conexion.sConnection);
            SqlCommand com = new SqlCommand(SQL, con);
            SqlParameter retParam = com.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
            retParam.Direction = ParameterDirection.ReturnValue;

            com.Parameters.Add("@pNombre", SqlDbType.VarChar, 100).Value = pNombre;
            com.Parameters.Add("@pContacto", SqlDbType.VarChar, 100).Value = pContacto;
            com.Parameters.Add("@pCuit", SqlDbType.VarChar, 13).Value = pCuit;
            com.Parameters.Add("@pEmail", SqlDbType.VarChar, 30).Value = pEmail;
            com.Parameters.Add("@pTelefono", SqlDbType.VarChar, 15).Value = pTelefono;
            com.Parameters.Add("@pDireccion", SqlDbType.VarChar, 100).Value = pDireccion;
            com.Parameters.Add("@pFotoJpg", SqlDbType.VarChar, 100).Value = pFotoJpg;

            try
            {
                con.Open();
                //declara un objeto Transaction y comienza la transaccion
                objTransaction = con.BeginTransaction();
                com.Transaction = objTransaction;

                com.ExecuteNonQuery();
                nuevoClienteEmpresaId = Convert.ToInt32(retParam.Value);
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
            return nuevoClienteEmpresaId;
        }

        public int ActualizarClienteEmpresa(string pNombre, string pContacto, string pCuit, string pEmail,
            string pTelefono, string pDireccion, string pFotoJpg)
        {
            SQL = "UPDATE CLIENTEEMPRESA SET NOMBRE=@pNombre, CONTACTO=@pContacto, CUIT=@pCuit ,MAIL=@pEmail, TELEFONO=@pTelefono, DIRECCION=@pDireccion, FOTOCLIENTEEMPRESA=@pfotoJpg WHERE CUIT='" + pCuit + "'";


            SqlConnection con = new SqlConnection(Conexion.sConnection);
            SqlCommand com = new SqlCommand(SQL, con);
            SqlParameter retParam = com.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
            retParam.Direction = ParameterDirection.ReturnValue;

            com.Parameters.Add("@pNombre", SqlDbType.VarChar, 100).Value = pNombre;
            com.Parameters.Add("@pContacto", SqlDbType.VarChar, 100).Value = pContacto;
            com.Parameters.Add("@pCuit", SqlDbType.VarChar, 13).Value = pCuit;
            com.Parameters.Add("@pEmail", SqlDbType.VarChar, 30).Value = pEmail;
            com.Parameters.Add("@pTelefono", SqlDbType.VarChar, 15).Value = pTelefono;
            com.Parameters.Add("@pDireccion", SqlDbType.VarChar, 100).Value = pDireccion;
            com.Parameters.Add("@pFotoJpg", SqlDbType.VarChar, 100).Value = pFotoJpg;

            try
            {
                con.Open();
                //declara un objeto Transaction y comienza la transaccion
                objTransaction = con.BeginTransaction();
                com.Transaction = objTransaction;

                com.ExecuteNonQuery();
                nuevoClienteEmpresaId = Convert.ToInt32(retParam.Value);
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
            return nuevoClienteEmpresaId;
        }
    }

}
