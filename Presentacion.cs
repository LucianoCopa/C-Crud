using System.Data;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Integrador2024.Datos;
using Integrador2024.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace Integrador2024
{
    public partial class frmsPrincipal : Form
    {
        public frmsPrincipal()
        {
            InitializeComponent();

            txt_cIndividuoNombre.Enabled = false;
            txt_cIndividuoApellido.Enabled = false;
            msk_cIndividuoCuit.Enabled = false;
            txt_cIndividuoEmail.Enabled = false;
            txt_cIndividuoTelefono.Enabled = false;
            txt_cIndividuoDireccion.Enabled = false;

            btn_cancelarCliente.Visible = false;
            btn_guardarNuevo.Visible = false;
            btn_actualizarGuardar.Visible = false;

            this.dtw_clienteIndividuo.ReadOnly = true;
            this.dtw_clienteEmpresa.ReadOnly = true;
            this.dtw_vendedor.ReadOnly = true;
            this.dataGridView1.ReadOnly = true;

            //  dtw_clienteIndividuo.CurrentRow.Index = -1;

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btn_vEditar_Click(object sender, EventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                Datos.Dal objdal = new Datos.Dal();

                if (rdb_idProducto.Checked == true)
                {
                    if (string.IsNullOrEmpty(txt_bLegajo.Text) == true)
                    {
                        //NO devuelve nada
                    }
                    else
                    {
                        string s = txt_bLegajo.Text;
                        Int32 result = 0;
                        Int32.TryParse(s, out result);

                        if (result == 0)
                        {
                            MessageBox.Show("Valor Inválido: " + "' " + txt_bLegajo.Text + " '", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DataSet ds1 = new DataSet();
                            ds1 = objdal.BuscarProductoId(Convert.ToInt32(txt_bLegajo.Text));
                            DataTable dtProductos = ds1.Tables[0];
                            dataGridView1.DataSource = dtProductos;

                        }
                    }
                }
                else
                {//buscar por Nombre
                    DataSet ds1 = new DataSet(); //instancio clase Dataset
                    ds1 = objdal.BuscarProductoNombre(txt_bLegajo.Text.ToUpper()); //busca datos

                    DataTable dtProductos = ds1.Tables[0]; //representa la tabla de un DataSet.
                    dataGridView1.DataSource = dtProductos;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Al Buscar Datos. " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        public void Limpiar()
        {
            txt_nombre.Clear();
            txt_descripcion.Clear();
            txt_precio.Clear();
            txt_margen.Clear();
            txt_iva.Clear();
            txt_pBruto.Clear();
            txt_venta.Clear();
            txt_proveedor.Clear();
            cmb_categoria.SelectedIndex = -1;
            cmb_subCategoria.SelectedIndex = -1;

        }

        public void LimpiarVendedor()
        {
            txt_vApellido.Clear();
            txt_vNombre.Clear();
            txt_vDni.Clear();
            mtb_vCuil.Clear();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_descripcion.Text))
            {
                DialogResult resultado = MessageBox.Show("Debe ingresar Datos Obligatorios (*)", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.OK)
                { //corregir e ingresar bien datos
                    txt_nombre.Select(0, 0);
                    txt_nombre.Focus();
                }
            }
            else
            {
                string mostrarCampos;
                mostrarCampos = "" + "\n\r" + "" + "\n\r" + "Nombre: " + txt_nombre.Text.ToUpper()
                    + "\n\r" + "Descripcion: " + txt_descripcion.Text.ToUpper() + "\n\r" + "Precio: " + txt_precio.Text + "\n\r" + "Margen: " + txt_margen.Text + "\n\r" + "IVA: " + txt_iva.Text + "\n\r" + "Precio Bruto: " + txt_pBruto.Text + "\n\r" + "Venta: " + txt_venta.Text + "\n\r" + "Proveedor: " + txt_proveedor.Text + "\n\r" + "Categoria: " + cmb_categoria.Text;

                DialogResult resultado = MessageBox.Show("¿Confirma los datos? " + mostrarCampos, "Aviso", MessageBoxButtons.OKCancel,
    MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    string fotoProducto = txt_nombre.Text + ".jpg";


                    Dal objdal1 = new Dal();

                    objdal1.AgregarProducto(txt_nombre.Text.ToUpper(), txt_descripcion.Text.ToUpper(), Convert.ToDecimal(txt_precio.Text), Convert.ToDouble(txt_margen.Text), Convert.ToDouble(txt_iva.Text), Convert.ToDecimal(txt_pBruto.Text), Convert.ToDecimal(txt_venta.Text), txt_proveedor.Text, cmb_categoria.Text, cmb_subCategoria.Text, fotoProducto);
                }

                else
                {
                    return;
                }

                Datos.Dal objdal = new Datos.Dal();
                Producto objProduc = new Producto();
                DataSet objds = new DataSet();

                objds = objdal.BuscarProducto();

                DataTable dtProductos = objds.Tables[0];
                dataGridView1.DataSource = dtProductos;

            }

            Limpiar();

        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_descripcion.Text) || string.IsNullOrEmpty(txt_proveedor.Text))
            {
                DialogResult resultado = MessageBox.Show("Debe ingresar Datos Obligatorios (*)" + "\n\r" + "Nombre:" + "\n\r" + "Descripcion" + "\n\r" + "Proveedo:", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.OK)
                { //corregir e ingresar bien datos
                    txt_nombre.Select(0, 0);
                    txt_nombre.Focus();
                }
            }
            else
            {
                string mostrarCampos;
                mostrarCampos = "" + "\n\r" + "" + "\n\r" + "Nombre: " + txt_nombre.Text.ToUpper()
                    + "\n\r" + "Descripcion: " + txt_descripcion.Text.ToUpper() + "\n\r" + "Precio: " + txt_precio.Text + "\n\r" + "Margen: " + txt_margen.Text + "\n\r" + "IVA: " + txt_iva.Text + "\n\r" + "Precio Bruto: " + txt_pBruto + "\n\r" + "Venta: " + txt_venta.Text + "\n\r" + "Proveedor: " + txt_proveedor.Text.ToUpper() + "\n\r" + "Categoria: " + cmb_categoria.Text;

                DialogResult resultado = MessageBox.Show("¿Confirma los cambios? " + mostrarCampos, "Aviso", MessageBoxButtons.OKCancel,
    MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    string fotoProducto = txt_nombre.Text + ".jpg";

                    Dal objdal1 = new Dal();

                    objdal1.ModificarProducto(txt_nombre.Text.ToUpper(), txt_descripcion.Text.ToUpper(), Convert.ToDecimal(txt_precio.Text), Convert.ToDouble(txt_margen.Text),
                       Convert.ToDouble(txt_iva.Text), Convert.ToDecimal(txt_pBruto.Text), Convert.ToDecimal(txt_venta.Text), txt_proveedor.Text.ToUpper(), cmb_categoria.Text, cmb_subCategoria.Text, fotoProducto);
                }

                else
                {
                    return;
                }

                Datos.Dal objdal = new Datos.Dal();
                Producto objProduc = new Producto();
                DataSet objds = new DataSet();

                objds = objdal.ProductoEdit(txt_nombre.Text.ToUpper());

                DataTable dtProductos = objds.Tables[0];
                dataGridView1.DataSource = dtProductos;

            }

            Limpiar();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_nombre.Text))
            {
                DialogResult opcion = MessageBox.Show("Debe ingresar el Nombre que desea Eliminar", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    txt_nombre.Select(0, 0);
                    txt_nombre.Focus();
                }
            }
            else
            {

                Datos.Dal objdal = new Datos.Dal();

                DataSet ds1 = new DataSet();
                ds1 = objdal.EliminarProducto(txt_nombre.Text);
                MessageBox.Show("Usted ha eliminado " + txt_nombre.Text, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Datos.Dal objdal2 = new Datos.Dal();
                Producto objProduc = new Producto();
                DataSet objds = new DataSet();

                objds = objdal.BuscarProducto();

                DataTable dtProductos = objds.Tables[0];
                dataGridView1.DataSource = dtProductos;

            }
            Limpiar();
        }

        private void grp_Enter(object sender, EventArgs e)
        {

        }

        private void btn_vInsertar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_vNombre.Text.ToUpper()) || string.IsNullOrEmpty(txt_vDni.Text))
            {
                DialogResult resultado = MessageBox.Show("Debe ingresar Datos Obligatorios (*)\n\r Ingrese su Nombre:\n\r Ingrese su Dni", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.OK)
                { //corregir e ingresar bien datos
                    txt_vNombre.Select(0, 0);
                    txt_vNombre.Focus();
                }
            }
            else
            {
                string mostrarCamposVendedor;
                mostrarCamposVendedor = "" + "\n\r" + "" + "\n\r" + "Nombre: " + txt_vNombre.Text.ToUpper()
                    + "\n\r" + "Apellido: " + txt_vApellido.Text.ToUpper() + "\n\r" + "DNI: " + txt_vDni.Text + "\n\r" + "Cuil: " + mtb_vCuil.Text;

                DialogResult resultado = MessageBox.Show("¿Confirma los datos? " + mostrarCamposVendedor, "Aviso", MessageBoxButtons.OKCancel,
    MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    string fotoProducto = txt_vDni.Text + ".jpg";


                    Dal objdal1 = new Dal();

                    objdal1.ModificarVendedor(txt_vNombre.Text.ToUpper(), txt_vApellido.Text.ToUpper(), txt_vDni.Text, mtb_vCuil.Text, fotoProducto);
                }

                else
                {
                    return;
                }

                Datos.Dal objdal = new Datos.Dal();
                Vendedor objProduc = new Vendedor();
                DataSet objds = new DataSet();

                objds = objdal.BuscarVendedor();

                DataTable dtProductos = objds.Tables[0];
                dtw_vendedor.DataSource = dtProductos;

            }

            LimpiarVendedor();
        }

        private void grpbox_infoVendedor_Enter(object sender, EventArgs e)
        {

        }

        private void btn_vEditar_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_vDni.Text) || string.IsNullOrEmpty(txt_vNombre.Text))
            {
                DialogResult resultado = MessageBox.Show("Debe ingresar Datos Obligatorios (*)\n\r Ingrese su Nombre:\n\r Ingrese su DNI:", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.OK)
                { //corregir e ingresar bien datos
                    txt_vNombre.Select(0, 0);
                    txt_vNombre.Focus();
                }
            }
            else
            {
                string mostrarCamposVendedor;
                mostrarCamposVendedor = "" + "\n\r" + "" + "\n\r" + "Nombre: " + txt_vNombre.Text
                    + "\n\r" + "Apellido: " + txt_vApellido.Text + "\n\r" + "DNI: " + txt_vDni.Text + "\n\r" + "Cuil: " + mtb_vCuil.Text;

                DialogResult resultado = MessageBox.Show("¿Confirma los datos? " + mostrarCamposVendedor, "Aviso", MessageBoxButtons.OKCancel,
    MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    string fotoProducto = txt_vDni.Text + ".jpg";


                    Dal objdal1 = new Dal();

                    objdal1.ModificarVendedor(txt_vNombre.Text, txt_vApellido.Text, txt_vDni.Text, mtb_vCuil.Text, fotoProducto);
                }

                else
                {
                    return;
                }

                Datos.Dal objdal = new Datos.Dal();
                Vendedor objProduc = new Vendedor();
                DataSet objds = new DataSet();

                objds = objdal.BuscarVendedor();

                DataTable dtProductos = objds.Tables[0];
                dtw_vendedor.DataSource = dtProductos;

            }

            LimpiarVendedor();
        }

        private void btn_vBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_vDni.Text))
            {
                DialogResult opcion = MessageBox.Show("Debe ingresar Dni que desea Eliminar", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    txt_vDni.Select(0, 0);
                    txt_vDni.Focus();
                }
            }
            else
            {
                Datos.Dal objdal = new Datos.Dal();

                DataSet ds2 = new DataSet();
                ds2 = objdal.EliminarVendedor1(txt_vDni.Text);
                MessageBox.Show("Usted elimino vendedor con DNI: " + txt_vDni.Text, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Datos.Dal objdatos = new Datos.Dal();
                Vendedor objProduc = new Vendedor();
                DataSet objds = new DataSet();

                objds = objdal.BuscarVendedor();

                DataTable dtVendedor = objds.Tables[0];
                dtw_vendedor.DataSource = dtVendedor;

            }

            LimpiarVendedor();
        }

        public string nombreVendedor;
        private void btn_vBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                Datos.Dal objdal = new Datos.Dal();
                if (rdb_buscarDni.Checked == true)
                {

                    if (string.IsNullOrEmpty(txt_buscadorVendedor.Text) == true)
                    {
                        //NO devuelve nada
                    }
                    else
                    {
                        string buscar = txt_buscadorVendedor.Text;
                        Int32 resultado = 0;
                        Int32.TryParse(buscar, out resultado);

                        if (resultado == 0)
                        {
                            MessageBox.Show("Dato incorrecto: " + "' " + txt_buscadorVendedor.Text + " '", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                        else
                        {
                            DataSet ds1 = new DataSet(); //instancio clase Dataset
                            ds1 = objdal.BuscarVendedorGrilla(txt_buscadorVendedor.Text); //busca datos

                            DataTable dtProductos = ds1.Tables[0]; //representa la tabla de un DataSet.
                            dtw_vendedor.DataSource = dtProductos;  //carga grilla con datos
                        }
                    }

                }
                else
                {//buscar por Nombre
                    DataSet ds1 = new DataSet(); //instancio clase Dataset
                    ds1 = objdal.BuscarNombreGrilla(txt_buscadorVendedor.Text.ToUpper()); //busca datos

                    DataTable dtProductos = ds1.Tables[0]; //representa la tabla de un DataSet.
                    dtw_vendedor.DataSource = dtProductos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Datos incorrectos" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txt_buscadorVendedor.Text = null;
        }

        private void txt_proveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmsPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void AnchoDtw()
        {
            dtw_clienteIndividuo.Columns[0].Width = 30;
            dtw_clienteIndividuo.Columns[4].Width = 200;
            dtw_clienteIndividuo.Columns[6].Width = 200;
            dtw_clienteIndividuo.Columns[7].Width = 200;

        }
        private void AnchoDtw1()
        {
            dtw_clienteEmpresa.Columns[0].Width = 30;
            dtw_clienteEmpresa.Columns[2].Width = 150;
            dtw_clienteEmpresa.Columns[4].Width = 200;
            dtw_clienteEmpresa.Columns[6].Width = 150;
            dtw_clienteEmpresa.Columns[7].Width = 130;

        }

        private void MostrarCamposEmpresaNuevo(bool estadoEmpN)
        {
            txt_cEmpresaNombre.Enabled = estadoEmpN;
            txt_cEmpresaContacto.Enabled = estadoEmpN;
            msk_cEmpresaCuit.Enabled = estadoEmpN;
            txt_cEmpresaMail.Enabled = estadoEmpN;
            txt_cEmpresaTelefono.Enabled = estadoEmpN;
            txt_cEmpresaDireccion.Enabled = estadoEmpN;

            btn_actuallizarClienteEmpresa.Enabled = !estadoEmpN;
            btn_eliminarClienteEmpresa.Enabled = !estadoEmpN;

        }
        private void ActualizarCamposEmpresaNuevo(bool estadoEmpN)
        {
            txt_cEmpresaNombre.Enabled = estadoEmpN;
            txt_cEmpresaContacto.Enabled = estadoEmpN;
            msk_cEmpresaCuit.Enabled = estadoEmpN;
            txt_cEmpresaMail.Enabled = estadoEmpN;
            txt_cEmpresaTelefono.Enabled = estadoEmpN;
            txt_cEmpresaDireccion.Enabled = estadoEmpN;

            btn_nuevoClienteEmpresa.Enabled = !estadoEmpN;
            btn_eliminarClienteEmpresa.Enabled = !estadoEmpN;
        }
        private void MostrarCamposNuevo(bool estadoN)
        {
            txt_idCLienteIndividuo.Enabled = estadoN;
            txt_cIndividuoNombre.Enabled = estadoN;
            txt_cIndividuoApellido.Enabled = estadoN;
            msk_cIndividuoCuit.Enabled = estadoN;
            txt_cIndividuoEmail.Enabled = estadoN;
            txt_cIndividuoTelefono.Enabled = estadoN;
            txt_cIndividuoDireccion.Enabled = estadoN;

            btn_actualizarCliente.Enabled = !estadoN;
            btn_eliminarCliente.Enabled = !estadoN;
            //btn_reporteCliente.Enabled = !estadoN;
        }

        private void MostrarCamposActualizar(bool estadoA)
        {

            txt_idCLienteIndividuo.Enabled = estadoA;
            txt_cIndividuoNombre.Enabled = estadoA;
            txt_cIndividuoApellido.Enabled = estadoA;
            msk_cIndividuoCuit.Enabled = estadoA;
            txt_cIndividuoEmail.Enabled = estadoA;
            txt_cIndividuoTelefono.Enabled = estadoA;
            txt_cIndividuoDireccion.Enabled = estadoA;

            btn_nuevoCliente.Enabled = !estadoA;
            btn_eliminarCliente.Enabled = !estadoA;
            //btn_reporteCliente.Enabled = !estadoA;
        }
        private void MostrarCamposEliminar(bool estadoE)
        {

            txt_idCLienteIndividuo.Enabled = estadoE;
            txt_cIndividuoNombre.Enabled = estadoE;
            txt_cIndividuoApellido.Enabled = estadoE;
            msk_cIndividuoCuit.Enabled = estadoE;
            txt_cIndividuoEmail.Enabled = estadoE;
            txt_cIndividuoTelefono.Enabled = estadoE;
            txt_cIndividuoDireccion.Enabled = estadoE;

            btn_actualizarCliente.Enabled = !estadoE;
            btn_nuevoCliente.Enabled = !estadoE;
            //btn_reporteCliente.Enabled = !estadoE;
        }

        private void MostrarCamposReporte(bool estadoR)
        {
            txt_idCLienteIndividuo.Enabled = estadoR;
            txt_cIndividuoNombre.Enabled = estadoR;
            txt_cIndividuoApellido.Enabled = estadoR;
            msk_cIndividuoCuit.Enabled = estadoR;
            txt_cIndividuoEmail.Enabled = estadoR;
            txt_cIndividuoTelefono.Enabled = estadoR;
            txt_cIndividuoDireccion.Enabled = estadoR;

            btn_nuevoCliente.Enabled = !estadoR;
            btn_actualizarCliente.Enabled = !estadoR;
            btn_eliminarCliente.Enabled = !estadoR;
        }

        private void mostrarButton(bool estadoCancel)
        {

            btn_cancelarCliente.Visible = estadoCancel;

        }
        private void mostrarButtonEmpresa(bool estadoCancel)
        {

            btn_cancelarEmpresa.Visible = estadoCancel;

        }
        private void LimpiarCamposCLiente()
        {
            pbx_fotoClienteInd.Image = null;
            txt_idCLienteIndividuo.Text = null;
            txt_cIndividuoNombre.Text = null;
            txt_cIndividuoApellido.Text = null;
            msk_cIndividuoCuit.Text = null;
            txt_cIndividuoEmail.Text = null;
            txt_cIndividuoTelefono.Text = null;
            txt_cIndividuoDireccion.Text = null;
        }
        private void LimpiarCamposClienteEmpresa()
        {
            pbx_fotoClienteEmpresa.Image = null;
            txt_idClienteEmpresa.Text = null;
            txt_cEmpresaNombre.Text = null;
            txt_cEmpresaContacto.Text = null;
            msk_cEmpresaCuit.Text = null;
            txt_cEmpresaMail.Text = null;
            txt_cEmpresaTelefono.Text = null;
            txt_cEmpresaDireccion.Text = null;

        }
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Datos.DalClienteIndividuo objdal = new Datos.DalClienteIndividuo();
                if (rdb_checkId.Checked == true)
                {
                    if (string.IsNullOrEmpty(txt_buscadorClienteIndividuo.Text) == true)
                    {
                        DataSet ds1 = new DataSet(); //instancio clase Dataset
                        ds1 = objdal.ListarClientesIndividuo(); //busca datos

                        DataTable dtProductos = ds1.Tables[0]; //representa la tabla de un DataSet.
                        dtw_clienteEmpresa.DataSource = dtProductos;
                    }
                    else
                    {
                        string buscar = txt_buscadorClienteIndividuo.Text;
                        Int32 resultado = 0;
                        Int32.TryParse(buscar, out resultado);

                        if (resultado == 0)
                        {
                            MessageBox.Show("Dato incorrecto: " + "' " + txt_buscadorClienteIndividuo.Text + " '", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {

                            DataSet ds1 = new DataSet(); //instancio clase Dataset
                            ds1 = objdal.BuscarIdClienteIndividuo(Convert.ToInt32(txt_buscadorClienteIndividuo.Text)); //busca datos

                            DataTable dtProductos = ds1.Tables[0]; //representa la tabla de un DataSet.
                            dtw_clienteIndividuo.DataSource = dtProductos;
                        }
                    }

                }
                else
                {
                    DataSet ds2 = new DataSet(); //instancio clase Dataset
                    ds2 = objdal.BuscarNombreClienteIndividuo(txt_buscadorClienteIndividuo.Text); //busca datos

                    DataTable dtClienteIndividuo = ds2.Tables[0]; //representa la tabla de un DataSet.
                    dtw_clienteIndividuo.DataSource = dtClienteIndividuo;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Datos incorrectos" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            AnchoDtw();
            txt_buscadorClienteIndividuo.Text = null;
        }

        private void txt_buscadorClienteIndividuo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_buscadorClienteEmpresa_Click(object sender, EventArgs e)
        {

        }

        private void btn_buscadorClienteEmpresa_Click_1(object sender, EventArgs e)
        {
            try
            {
                Datos.DalClienteEmpresa objdal = new Datos.DalClienteEmpresa();

                if (rdb_idEmpresaCheck.Checked == true)
                {
                    if (string.IsNullOrEmpty(txt_buscadorClienteEmpresa.Text) == true)
                    {
                        DataSet ds1 = new DataSet(); //instancio clase Dataset
                        ds1 = objdal.ListarClientesEmpresa(); //busca datos

                        DataTable dtProductos = ds1.Tables[0]; //representa la tabla de un DataSet.
                        dtw_clienteEmpresa.DataSource = dtProductos;
                    }
                    string buscar = txt_buscadorClienteEmpresa.Text;
                    Int32 resultado = 0;
                    Int32.TryParse(buscar, out resultado);
                    if (resultado == 0)
                    {
                        MessageBox.Show("Dato incorrecto: " + "' " + txt_buscadorClienteEmpresa.Text + " '", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DataSet ds1 = new DataSet(); //instancio clase Dataset
                        ds1 = objdal.ListarIdClienteEmpresa(Convert.ToInt32(txt_buscadorClienteEmpresa.Text)); //busca datos

                        DataTable dtProductos = ds1.Tables[0]; //representa la tabla de un DataSet.
                        dtw_clienteEmpresa.DataSource = dtProductos;
                    }
                }
                else
                {
                    DataSet ds1 = new DataSet(); //instancio clase Dataset
                    ds1 = objdal.ListarContactoClienteEmpresa(txt_buscadorClienteEmpresa.Text); //busca datos

                    DataTable dtProductos = ds1.Tables[0]; //representa la tabla de un DataSet.
                    dtw_clienteEmpresa.DataSource = dtProductos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Datos incorrectos" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            AnchoDtw1();
            txt_buscadorClienteEmpresa.Text = null;
        }

        private void tbcClienteIndividuo_Click(object sender, EventArgs e)
        {

        }

        private void btn_nuevoCliente_Click(object sender, EventArgs e)
        {
            MostrarCamposNuevo(true);
            btn_guardarNuevo.Visible = true;
            mostrarButton(true);
            txt_cIndividuoNombre.Select();
            dtw_clienteIndividuo.Enabled = false;
            LimpiarCamposCLiente();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MostrarCamposNuevo(false);
            btn_guardarNuevo.Visible = false;
            btn_actualizarGuardar.Visible = false;
            MostrarCamposActualizar(false);
            MostrarCamposEliminar(false);
            MostrarCamposReporte(false);
            mostrarButton(false);
            LimpiarCamposCLiente();
            dtw_clienteIndividuo.Enabled = true;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btn_guardarCliente_Click(object sender, EventArgs e)
        {
            LimpiarCamposCLiente();
        }

        private void btn_actualizarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idCLienteIndividuo.Text) == true)
            {
                MessageBox.Show("Por favor, seleccione un Cliente antes de continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                dtw_clienteIndividuo.Enabled = false;
                MostrarCamposActualizar(true);
                btn_actualizarGuardar.Visible = true;
                msk_cIndividuoCuit.Enabled = false;
                mostrarButton(true);
                txt_cIndividuoNombre.Select();
            }

        }

        private void btn_eliminarCliente_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_idCLienteIndividuo.Text))
            {
                DialogResult opcion = MessageBox.Show("Debe seleccionar el Cliente que desea Eliminar", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {

                }
            }
            else
            {
                string mostrarCamposClienteIndividuo;
                mostrarCamposClienteIndividuo = "" + "\n\r" + "" + "\n\r" + "Nombre: " + txt_cIndividuoNombre.Text
                    + "\n\r" + "Apellido: " + txt_cIndividuoApellido.Text + "\n\r" + "CUIT: " + msk_cIndividuoCuit.Text + "\n\r" + "Email: " + txt_cIndividuoEmail.Text + "\n\r" + "Telefono: " + txt_cIndividuoTelefono.Text + "\n\r"
                    + "Direccion: " + txt_cIndividuoDireccion.Text;

                DialogResult resultado = MessageBox.Show("¿Usted desea Eliminar al cliente? " + txt_idCLienteIndividuo.Text + "\n\r" + "Datos:" + mostrarCamposClienteIndividuo, "Aviso", MessageBoxButtons.OKCancel,
    MessageBoxIcon.Question);
                if (resultado == DialogResult.OK)
                {
                    Datos.DalClienteIndividuo objdal = new Datos.DalClienteIndividuo();

                    DataSet ds2 = new DataSet();

                    ds2 = objdal.EliminarClienteIndividuo(txt_idCLienteIndividuo.Text);
                    Datos.DalClienteIndividuo objdatos = new Datos.DalClienteIndividuo();
                    ClienteIndividuo objProduc = new ClienteIndividuo();
                    DataSet objds = new DataSet();

                    objds = objdal.NuevoClienteIndividuo();

                    DataTable dtClienteInd = objds.Tables[0];
                    dtw_clienteIndividuo.DataSource = dtClienteInd;
                }
                else
                {
                    return;
                }

                //MessageBox.Show("Usted elimino cliente con ID: " + txt_idCLienteIndividuo.Text, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            LimpiarCamposCLiente();
        }

        private void btn_reporteCliente_Click(object sender, EventArgs e)
        {

        }
        // int codigoClienteIndividuo;
        private void EnviarDatosClientes()
        {
            txt_idCLienteIndividuo.Text = dtw_clienteIndividuo.CurrentRow.Cells[0].Value.ToString();
            txt_cIndividuoNombre.Text = dtw_clienteIndividuo.CurrentRow.Cells[1].Value.ToString();
            txt_cIndividuoApellido.Text = dtw_clienteIndividuo.CurrentRow.Cells[2].Value.ToString();
            msk_cIndividuoCuit.Text = dtw_clienteIndividuo.CurrentRow.Cells[3].Value.ToString();
            txt_cIndividuoEmail.Text = dtw_clienteIndividuo.CurrentRow.Cells[4].Value.ToString();
            txt_cIndividuoTelefono.Text = dtw_clienteIndividuo.CurrentRow.Cells[5].Value.ToString();
            txt_cIndividuoDireccion.Text = dtw_clienteIndividuo.CurrentRow.Cells[6].Value.ToString();

            //pbx_fotoClienteInd.Image = null;
            try
            {
                // Rutas de las fotos
                string rutaFotoPersonalizada = "C:\\Users\\mcastillo\\Documents\\FACU-LUCHO\\C#-Iconos\\TRABAJOFINAL-POO\\ClientePersona\\"
                                                + msk_cIndividuoCuit.Text + ".jpg";
                string rutaFotoPredeterminada = "C:\\Users\\mcastillo\\Documents\\FACU-LUCHO\\C#-Iconos\\TRABAJOFINAL-POO\\ClientePersona\\sinfoto.jpg";

                // Determinar la ruta a usar
                string rutaFoto = File.Exists(rutaFotoPersonalizada) ? rutaFotoPersonalizada : rutaFotoPredeterminada;

                // Asignar la imagen al PictureBox
                pbx_fotoClienteInd.Image = Image.FromFile(rutaFoto);
                lbl_fotoClienteIndividuo.Visible = false; // Oculta el label si la foto se carga correctamente
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la foto: {ex.Message}");
                pbx_fotoClienteInd.Image = null; // Limpia el PictureBox si hay un error
                lbl_fotoClienteIndividuo.Visible = true; // Muestra el label en caso de error
            }
        }

        private void EnviarDatosClientesEmpresa()
        {
            txt_idClienteEmpresa.Text = dtw_clienteEmpresa.CurrentRow.Cells[0].Value.ToString();
            txt_cEmpresaNombre.Text = dtw_clienteEmpresa.CurrentRow.Cells[1].Value.ToString();
            txt_cEmpresaContacto.Text = dtw_clienteEmpresa.CurrentRow.Cells[2].Value.ToString();
            msk_cEmpresaCuit.Text = dtw_clienteEmpresa.CurrentRow.Cells[3].Value.ToString();
            txt_cEmpresaMail.Text = dtw_clienteEmpresa.CurrentRow.Cells[4].Value.ToString();
            txt_cEmpresaTelefono.Text = dtw_clienteEmpresa.CurrentRow.Cells[5].Value.ToString();
            txt_cEmpresaDireccion.Text = dtw_clienteEmpresa.CurrentRow.Cells[6].Value.ToString();

            try
            {

                string rutaFotoPersonalizadaEmpresa = "C:\\Users\\mcastillo\\Documents\\FACU-LUCHO\\C#-Iconos\\TRABAJOFINAL-POO\\ClienteEmpresa\\"
                                                + msk_cEmpresaCuit.Text + ".jpg";
                string rutaFotoPredeterminadaEmpresa = "C:\\Users\\mcastillo\\Documents\\FACU-LUCHO\\C#-Iconos\\TRABAJOFINAL-POO\\ClienteEmpresa\\sinfotoEmpresa.jpg";


                string rutaFotoEmpresa = File.Exists(rutaFotoPersonalizadaEmpresa) ? rutaFotoPersonalizadaEmpresa : rutaFotoPredeterminadaEmpresa;


                pbx_fotoClienteEmpresa.Image = Image.FromFile(rutaFotoEmpresa);
                lbl_fotoClienteEmpresa.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la foto: {ex.Message}");
                pbx_fotoClienteEmpresa.Image = null; // Limpia el PictureBox si hay un error
                lbl_fotoClienteEmpresa.Visible = true; // Muestra el label en caso de error
            }
        }

        private void dtw_clienteIndividuo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            EnviarDatosClientes();

        }

        private void btn_guardarNuevo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_cIndividuoNombre.Text) || string.IsNullOrEmpty(msk_cIndividuoCuit.Text) || string.IsNullOrEmpty(txt_cIndividuoDireccion.Text) || string.IsNullOrEmpty(txt_cIndividuoEmail.Text))
            {
                DialogResult resultado = MessageBox.Show("Debe ingresar Datos Obligatorios (*) \n\r Nombre(*) \n\r CUIT(*) \n\r Direccion(*) \n\r Email(*)", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.OK)
                { //corregir e ingresar bien datos
                    txt_cIndividuoNombre.Select(0, 0);
                    txt_cIndividuoNombre.Focus();
                }

            }
            else
            {
                string mostrarCamposClienteIndividuo;
                mostrarCamposClienteIndividuo = "" + "\n\r" + "" + "\n\r" + "Nombre: " + txt_cIndividuoNombre.Text
                    + "\n\r" + "Apellido: " + txt_cIndividuoApellido.Text + "\n\r" + "CUIT: " + msk_cIndividuoCuit.Text + "\n\r" + "Email: " + txt_cIndividuoEmail.Text + "\n\r" + "Telefono: " + txt_cIndividuoTelefono.Text + "\n\r"
                    + "Direccion: " + txt_cIndividuoDireccion.Text;

                DialogResult resultado = MessageBox.Show("¿Confirma los datos? " + mostrarCamposClienteIndividuo, "Aviso", MessageBoxButtons.OKCancel,
    MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    string fotoProductoClienteIndividuo = msk_cIndividuoCuit.Text + ".jpg";


                    DalClienteIndividuo objdal1 = new DalClienteIndividuo();

                    objdal1.NuevoCliente(txt_cIndividuoNombre.Text, txt_cIndividuoApellido.Text, msk_cIndividuoCuit.Text, txt_cIndividuoEmail.Text, txt_cIndividuoTelefono.Text, txt_cIndividuoDireccion.Text, fotoProductoClienteIndividuo);
                }

                else
                {
                    return;
                }

                Datos.DalClienteIndividuo objdal = new Datos.DalClienteIndividuo();
                ClienteIndividuo objProduc = new ClienteIndividuo();
                DataSet objds = new DataSet();

                objds = objdal.NuevoClienteIndividuo();

                DataTable dtProductos = objds.Tables[0];
                dtw_clienteIndividuo.DataSource = dtProductos;



                LimpiarCamposCLiente();
            }
        }

        private void btn_actualizarGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_cIndividuoNombre.Text) || string.IsNullOrEmpty(msk_cIndividuoCuit.Text) || string.IsNullOrEmpty(txt_cIndividuoDireccion.Text) || string.IsNullOrEmpty(txt_cIndividuoEmail.Text))
            {
                DialogResult resultado = MessageBox.Show("Debe ingresar Datos Obligatorios (*) \n\r Nombre(*) \n\r CUIT(*) \n\r Direccion(*) \n\r Email(*)", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.OK)
                { //corregir e ingresar bien datos
                    txt_cIndividuoNombre.Select(0, 0);
                    txt_cIndividuoNombre.Focus();
                }

            }
            else
            {
                string mostrarCamposClienteIndividuo;
                mostrarCamposClienteIndividuo = "" + "\n\r" + "" + "\n\r" + "Nombre: " + txt_cIndividuoNombre.Text
                    + "\n\r" + "Apellido: " + txt_cIndividuoApellido.Text + "\n\r" + "CUIT: " + msk_cIndividuoCuit.Text + "\n\r" + "Email: " + txt_cIndividuoEmail.Text + "\n\r" + "Telefono: " + txt_cIndividuoTelefono.Text + "\n\r"
                    + "Direccion: " + txt_cIndividuoDireccion.Text;

                DialogResult resultado = MessageBox.Show("¿Confirma los cambios? " + mostrarCamposClienteIndividuo, "Aviso", MessageBoxButtons.OKCancel,
    MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    string fotoProductoClienteIndividuo = msk_cIndividuoCuit.Text + ".jpg";


                    DalClienteIndividuo objdal1 = new DalClienteIndividuo();

                    objdal1.ActualizarCliente(txt_cIndividuoNombre.Text, txt_cIndividuoApellido.Text, msk_cIndividuoCuit.Text, txt_cIndividuoEmail.Text, txt_cIndividuoTelefono.Text, txt_cIndividuoDireccion.Text, fotoProductoClienteIndividuo);
                }

                else
                {
                    return;
                }

                Datos.DalClienteIndividuo objdal = new Datos.DalClienteIndividuo();
                ClienteIndividuo objProduc = new ClienteIndividuo();
                DataSet objds = new DataSet();

                objds = objdal.NuevoClienteIndividuo();

                DataTable dtProductos = objds.Tables[0];
                dtw_clienteIndividuo.DataSource = dtProductos;



                LimpiarCamposCLiente();
            }
        }

        private void tbcEmpresas_Click(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void btn_nuevoClienteEmpresa_Click(object sender, EventArgs e)
        {
            MostrarCamposEmpresaNuevo(true);
            mostrarButtonEmpresa(true);
            dtw_clienteEmpresa.Enabled = false;
            btn_nuevoEmpresa.Visible = true;
            txt_cEmpresaNombre.Select();
            LimpiarCamposClienteEmpresa();
        }

        private void btn_actuallizarClienteEmpresa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idClienteEmpresa.Text) == true)
            {
                MessageBox.Show("Por favor, seleccione un Cliente antes de continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                ActualizarCamposEmpresaNuevo(true);
                mostrarButtonEmpresa(true);
                dtw_clienteEmpresa.Enabled = false;
                btn_actualizarEmpresa.Visible = true;
                msk_cEmpresaCuit.Enabled = false;
            }
        }

        private void btn_cancelarEmpresa_Click(object sender, EventArgs e)
        {
            MostrarCamposEmpresaNuevo(false);
            ActualizarCamposEmpresaNuevo(false);
            mostrarButtonEmpresa(false);
            btn_actualizarEmpresa.Visible = false;
            btn_nuevoEmpresa.Visible = false;
            dtw_clienteEmpresa.Enabled = true;
        }

        private void dtw_clienteEmpresa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EnviarDatosClientesEmpresa();

        }

        private void btn_nuevoEmpresa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_cEmpresaMail.Text) || string.IsNullOrEmpty(txt_cEmpresaDireccion.Text) || string.IsNullOrEmpty(msk_cEmpresaCuit.Text))
            {
                DialogResult resultado = MessageBox.Show("Debe ingresar Datos Obligatorios (*) \n\r Email(*) \n\r CUIT(*) \n\r Direccion(*)", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.OK)
                { //corregir e ingresar bien datos
                    txt_cEmpresaNombre.Select(0, 0);
                    txt_cEmpresaNombre.Focus();
                }

            }
            else
            {
                string mostrarCamposClienteEmpresa;
                mostrarCamposClienteEmpresa = "" + "\n\r" + "" + "\n\r" + "Nombre: " + txt_cEmpresaNombre.Text
                    + "\n\r" + "Contacto: " + txt_cEmpresaContacto.Text + "\n\r" + "CUIT: " + msk_cEmpresaCuit.Text + "\n\r" + "Email: " + txt_cEmpresaMail.Text + "\n\r" + "Telefono: " + txt_cEmpresaTelefono.Text + "\n\r"
                    + "Direccion: " + txt_cEmpresaDireccion.Text;

                DialogResult resultado = MessageBox.Show("¿Confirma los datos? " + mostrarCamposClienteEmpresa, "Aviso", MessageBoxButtons.OKCancel,
    MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    string fotoProductoClienteEmpresa = msk_cEmpresaCuit.Text + ".jpg";


                    DalClienteEmpresa objdal1 = new DalClienteEmpresa();

                    objdal1.NuevoClienteEmpresa(txt_cEmpresaNombre.Text, txt_cEmpresaContacto.Text, msk_cEmpresaCuit.Text, txt_cEmpresaMail.Text, txt_cEmpresaTelefono.Text, txt_cEmpresaDireccion.Text, fotoProductoClienteEmpresa);
                }

                else
                {
                    return;
                }

                Datos.DalClienteEmpresa objdal = new Datos.DalClienteEmpresa();
                ClienteEmpresa objProduc = new ClienteEmpresa();
                DataSet objds = new DataSet();

                objds = objdal.ListarClientesEmpresa();

                DataTable dtProductos = objds.Tables[0];
                dtw_clienteEmpresa.DataSource = dtProductos;



                LimpiarCamposClienteEmpresa();
            }
        }

        private void btn_actualizarEmpresa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_cEmpresaMail.Text) || string.IsNullOrEmpty(txt_cEmpresaDireccion.Text) || string.IsNullOrEmpty(msk_cEmpresaCuit.Text))
            {
                DialogResult resultado = MessageBox.Show("Debe ingresar Datos Obligatorios (*) \n\r CUIT(*) \n\r Email(*) \n\r Direccion(*)", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.OK)
                { //corregir e ingresar bien datos
                    txt_cEmpresaMail.Select(0, 0);
                    txt_cEmpresaMail.Focus();
                }

            }
            else
            {
                string mostrarCamposClienteEmpresa;
                mostrarCamposClienteEmpresa = "" + "\n\r" + "" + "\n\r" + "Nombre: " + txt_cEmpresaNombre.Text
                    + "\n\r" + "Contacto: " + txt_cEmpresaContacto.Text + "\n\r" + "CUIT: " + msk_cEmpresaCuit.Text + "\n\r" + "Email: " + txt_cEmpresaMail.Text + "\n\r" + "Telefono: " + txt_cEmpresaTelefono.Text + "\n\r"
                    + "Direccion: " + txt_cEmpresaDireccion.Text;

                DialogResult resultado = MessageBox.Show("¿Confirma los cambios? " + mostrarCamposClienteEmpresa, "Aviso", MessageBoxButtons.OKCancel,
    MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    string fotoProductoClienteEmpresa = msk_cEmpresaCuit.Text + ".jpg";


                    DalClienteEmpresa objdal1 = new DalClienteEmpresa();

                    objdal1.ActualizarClienteEmpresa(txt_cEmpresaNombre.Text, txt_cEmpresaContacto.Text, msk_cEmpresaCuit.Text, txt_cEmpresaMail.Text, txt_cEmpresaTelefono.Text, txt_cEmpresaDireccion.Text, fotoProductoClienteEmpresa);
                }

                else
                {
                    return;
                }

                Datos.DalClienteEmpresa objdal = new Datos.DalClienteEmpresa();
                ClienteEmpresa objProduc = new ClienteEmpresa();
                DataSet objds = new DataSet();

                objds = objdal.ListarClientesEmpresa();

                DataTable dtProductos = objds.Tables[0];
                dtw_clienteEmpresa.DataSource = dtProductos;



                LimpiarCamposClienteEmpresa();
            }
        }

        private void btn_eliminarClienteEmpresa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idClienteEmpresa.Text))
            {
                DialogResult opcion = MessageBox.Show("Debe seleccionar el Cliente que desea Eliminar", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {

                }
            }
            else
            {
                string mostrarCamposClienteEmpresa;
                mostrarCamposClienteEmpresa = "" + "\n\r" + "" + "\n\r" + "Nombre: " + txt_cEmpresaNombre.Text
                    + "\n\r" + "Contacto: " + txt_cEmpresaContacto.Text + "\n\r" + "CUIT: " + msk_cEmpresaCuit.Text + "\n\r" + "Email: " + txt_cEmpresaMail.Text + "\n\r" + "Telefono: " + txt_cEmpresaTelefono.Text + "\n\r"
                    + "Direccion: " + txt_cEmpresaDireccion.Text;

                DialogResult resultado = MessageBox.Show("¿Usted desea Eliminar al cliente? " + txt_idClienteEmpresa.Text + "\n\r" + "Datos:" + mostrarCamposClienteEmpresa, "Aviso", MessageBoxButtons.OKCancel,
    MessageBoxIcon.Question);
                if (resultado == DialogResult.OK)
                {
                    Datos.DalClienteEmpresa objdal = new Datos.DalClienteEmpresa();

                    DataSet ds2 = new DataSet();

                    ds2 = objdal.EliminarClienteEmpresa(txt_idClienteEmpresa.Text);
                    Datos.DalClienteEmpresa objdatos = new Datos.DalClienteEmpresa();
                    ClienteEmpresa objProduc = new ClienteEmpresa();
                    DataSet objds = new DataSet();

                    objds = objdal.ListarClientesEmpresa();

                    DataTable dtClienteEmpresa = objds.Tables[0];
                    dtw_clienteEmpresa.DataSource = dtClienteEmpresa;
                }
                else
                {
                    return;
                }

                //MessageBox.Show("Usted elimino cliente con ID: " + txt_idCLienteIndividuo.Text, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            LimpiarCamposClienteEmpresa();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void btn_cerrarLogin_Click(object sender, EventArgs e)
        {
            frmLogin cerrarLogin = new frmLogin();

            cerrarLogin.Show();
            Close();
        }

        private void tcbProducto_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmLogin cerrarProduc = new frmLogin();
            cerrarProduc.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmLogin cerrarVendedor = new frmLogin();
            cerrarVendedor.Show();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmLogin cerrarClienteInd = new frmLogin();
            cerrarClienteInd.Show();
            Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            frmLogin cerrarClienteEmpresa = new frmLogin();
            cerrarClienteEmpresa.Show();
            Close();
        }
    }
}
