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
    public class DalClienteIndividuo
    {
        private int nuevoClienteIndId;
        public int NuevoClienteIndId
        {
            get
            {
                return nuevoClienteIndId;
            }
            set
            {
                nuevoClienteIndId = value;
            }
        }
        public static string SQL = string.Empty;

        public static SqlTransaction objTransaction = null;

        public DataSet NuevoClienteIndividuo()
        {
            SQL = "SELECT * FROM CLIENTEINDIVIDUO ORDER BY ID DESC";


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
        public int NuevoCliente(string pNombre, string pApellido, string pCuit, string pEmail,
            string pTelefono, string pDireccion, string pfotoJpg) 
        {
            SQL = "INSERT INTO CLIENTEINDIVIDUO(NOMBRE, APELLIDO, CUIT ,MAIL, TELEFONO , DIRECCION, FOTOCLIENTEINDIVIDUO) VALUES";
            SQL = SQL + "(@pNombre, @pApellido, @pCuit, @pEmail, @pTelefono, @pDireccion, @pfotoJpg)";

            SqlConnection con = new SqlConnection(Conexion.sConnection);
            SqlCommand com = new SqlCommand(SQL, con);
            SqlParameter retParam = com.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
            retParam.Direction = ParameterDirection.ReturnValue;

            com.Parameters.Add("@pNombre", SqlDbType.VarChar, 100).Value = pNombre;
            com.Parameters.Add("@pApellido", SqlDbType.VarChar, 100).Value = pApellido;
            com.Parameters.Add("@pCuit", SqlDbType.VarChar, 13).Value = pCuit;
            com.Parameters.Add("@pEmail", SqlDbType.VarChar, 30).Value = pEmail;
            com.Parameters.Add("@pTelefono", SqlDbType.VarChar, 15).Value = pTelefono;
            com.Parameters.Add("@pDireccion", SqlDbType.VarChar, 100).Value = pDireccion;
            com.Parameters.Add("@pfotoJpg", SqlDbType.VarChar, 100).Value = pfotoJpg;

            try
            {
                con.Open();
                //declara un objeto Transaction y comienza la transaccion
                objTransaction = con.BeginTransaction();
                com.Transaction = objTransaction;

                com.ExecuteNonQuery();
                nuevoClienteIndId = Convert.ToInt32(retParam.Value);
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
            return nuevoClienteIndId;
        }

        public int ActualizarCliente(string pNombre, string pApellido, string pCuit, string pEmail,
    string pTelefono, string pDireccion, string pfotoJpg)
        {
            SQL = "UPDATE CLIENTEINDIVIDUO SET NOMBRE=@pNombre, APELLIDO=@pApellido, CUIT=@pCuit ,MAIL=@pEmail, TELEFONO=@pTelefono, DIRECCION=@pDireccion, FOTOCLIENTEINDIVIDUO=@pfotoJpg WHERE CUIT='" + pCuit + "'";
            

            SqlConnection con = new SqlConnection(Conexion.sConnection);
            SqlCommand com = new SqlCommand(SQL, con);
            SqlParameter retParam = com.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
            retParam.Direction = ParameterDirection.ReturnValue;

            com.Parameters.Add("@pNombre", SqlDbType.VarChar, 100).Value = pNombre;
            com.Parameters.Add("@pApellido", SqlDbType.VarChar, 100).Value = pApellido;
            com.Parameters.Add("@pCuit", SqlDbType.VarChar, 13).Value = pCuit;
            com.Parameters.Add("@pEmail", SqlDbType.VarChar, 30).Value = pEmail;
            com.Parameters.Add("@pTelefono", SqlDbType.VarChar, 15).Value = pTelefono;
            com.Parameters.Add("@pDireccion", SqlDbType.VarChar, 100).Value = pDireccion;
            com.Parameters.Add("@pfotoJpg", SqlDbType.VarChar, 100).Value = pfotoJpg;

            try
            {
                con.Open();
                //declara un objeto Transaction y comienza la transaccion
                objTransaction = con.BeginTransaction();
                com.Transaction = objTransaction;

                com.ExecuteNonQuery();
                nuevoClienteIndId = Convert.ToInt32(retParam.Value);
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
            return nuevoClienteIndId;
        }
        public DataSet ListarClientesIndividuo()
        {
            SQL = "SELECT * FROM CLIENTEINDIVIDUO ORDER BY ID ASC";

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
        public DataSet BuscarIdClienteIndividuo(int idClienteInd) 
        {
            SQL = "SELECT * FROM CLIENTEINDIVIDUO WHERE ID ='"+idClienteInd+"' ";

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
        public DataSet BuscarNombreClienteIndividuo(string apellidoClienteInd) 
        {
            SQL = "SELECT * FROM CLIENTEINDIVIDUO WHERE APELLIDO LIKE '%' + '" + apellidoClienteInd + "' + '%'";

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
        public DataSet EliminarClienteIndividuo(string idClienteInd) 
        {
            SQL = "DELETE FROM CLIENTEINDIVIDUO ";
            SQL = SQL + "WHERE ID = '"+ idClienteInd + "'";

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

    }
}
