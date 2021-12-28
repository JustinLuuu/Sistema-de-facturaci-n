using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final___Sistema_de_facturacion
{
    public partial class GestionProveedor : Form            
    {

        SqlConnection conect;

        public GestionProveedor(SqlConnection conect)
        {
            InitializeComponent();
            this.conect = conect;
        }

        private void GestionProveedor_Load(object sender, EventArgs e)
        {
            Proveedores loadForm = new Proveedores(conect);
            loadForm.Peticion(dgvListaProveedores, "Select * from dbo.Proveedor");

            loadForm.LlenarCombo(cmbUpdate, "Select IdProveedor from dbo.Proveedor");
            loadForm.LlenarCombo(cmbEliminar, "Select IdProveedor from dbo.Proveedor");

            alternarColorFilas(dgvListaProveedores);

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 volver = new Form1();
            this.Hide();
            volver.ShowDialog();
        }

      
        private void cmbUpdate_Leave(object sender, EventArgs e)   // COMBOBOX UPDATE - LEAVE
        {
            if (cmbUpdate.Text == string.Empty || cmbUpdate.Text == "")
            {
                cmbUpdate.Text = "Seleccione ID proveedor a actualizar";
            }
        }

        private void cmbEliminar_Leave(object sender, EventArgs e)
        {
            if (cmbEliminar.Text == string.Empty || cmbEliminar.Text == "")
            {
                cmbEliminar.Text = "Seleccione ID proveedor a eliminar";
            }
        }

        private void cmbUpdate_SelectedValueChanged(object sender, EventArgs e)  // cuando se seleccione algo
        {
            if (cmbUpdate.Text != "Seleccione ID cliente a actualizar" && cmbUpdate.Text != "")
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Select Nombre, Cedula, Telefono, Email from dbo.Proveedor where IdProveedor = @ID", conect);
                comando.Parameters.AddWithValue("@ID", Convert.ToInt32(cmbUpdate.Text));

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    txtNombre.Text = lector["Nombre"].ToString();               // llenar campos de datos recopilados luego de seleccionar un ID en comboBox Update
                    txtCedula.Text = lector["Cedula"].ToString();               // llenar campos de datos recopilados luego de seleccionar un ID en comboBox Update
                    txtTelefono.Text = lector["Telefono"].ToString();           // llenar campos de datos recopilados luego de seleccionar un ID en comboBox Update
                    txtEmail.Text = lector["Email"].ToString();                 // llenar campos de datos recopilados luego de seleccionar un ID en comboBox Update
                }

                gboxInformacionProveedor.Text = "Informacion recopilada a actualizar";   // al recuperar la informacion cambiamos el titulo del groupBox


                lector.Close();
                conect.Close();
            }
        }

        private void cmbEliminar_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbEliminar.Text != "Seleccione ID cliente a eliminar" && cmbEliminar.Text != "")
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Select Nombre, Cedula, Telefono, Email from dbo.Proveedor where IdProveedor = @ID", conect);
                comando.Parameters.AddWithValue("@ID", Convert.ToInt32(cmbEliminar.Text));

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    txtNombre.Text = lector["Nombre"].ToString();         // llenar campos de datos recopilados en comboBox eliminar
                    txtCedula.Text = lector["Cedula"].ToString();         // llenar campos de datos recopilados en comboBox eliminar
                    txtTelefono.Text = lector["Telefono"].ToString();     // llenar campos de datos recopilados en comboBox eliminar
                    txtEmail.Text = lector["Email"].ToString();           // llenar campos de datos recopilados en comboBox eliminar
                }

                gboxInformacionProveedor.Text = "Informacion recopilada a eliminar";

                lector.Close();
                conect.Close();

            }
        }

        private void cmbUpdate_Click(object sender, EventArgs e)
        {
           if (cmbEliminar.Text != "Seleccione ID proveedor a eliminar")
               limpiarTodo.limpiar(this);
        }

        private void cmbEliminar_Click(object sender, EventArgs e)
        {
            if (cmbUpdate.Text != "Seleccione ID proveedor a actualizar")
                limpiarTodo.limpiar (this);
        }



        private void btnAgregar_Click(object sender, EventArgs e)   // AGREGAR PROVEEDOR
        {
            if (txtCedula.Text == "" || txtEmail.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "")
            {
                MessageBox.Show("IMPOSIBLE AGREGAR PROVEEDOR CON CAMPOS VACIOS !");
            }


            else
            {
                bool error1 = false;
                bool error2 = false;

                try { Convert.ToDecimal(txtCedula.Text); } catch { error1 = true; MessageBox.Show("SOLO SE PERMITEN VALORES NUMERICOS EN EL CAMPO CEDULA !"); txtCedula.Text = ""; }

                try { Convert.ToDecimal(txtTelefono.Text); } catch { error2 = true; MessageBox.Show("SOLO SE PERMITEN VALORES NUMERICOS EN EL CAMPO TELEFONO"); txtTelefono.Text = ""; }

                if (error1 == false && error2 == false)
                {
                    if (txtCedula.Text.Length >= 5)
                    {
                        if (txtTelefono.Text.Length >= 5)
                        {
                           Proveedores proveedor = new Proveedores(conect);

                           proveedor.NOMBRE = txtNombre.Text;
                           proveedor.CEDULA = txtCedula.Text;
                           proveedor.TELEFONO = txtTelefono.Text;
                           proveedor.EMAIL = txtEmail.Text;

                            proveedor.Agregar();

                            limpiarTodo.limpiar(this);
                            proveedor.Peticion(dgvListaProveedores, "Select * from dbo.Proveedor");

                            proveedor.LlenarCombo(cmbUpdate, "Select IdProveedor from dbo.Proveedor");
                            proveedor.LlenarCombo(cmbEliminar, "Select IdProveedor from dbo.Proveedor");
                        }

                        else
                        {
                            MessageBox.Show("NUMERO DE TELEFONO DEBE TENER AL MENOS 5 DIGITOS");
                        }

                    }

                    else
                    {
                        MessageBox.Show("NUMERO DE CEDULA DEBE TENER AL MENOS 5 DIGITOS");
                    }

                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)  // ACTUALIZAR PROVEEDOR
        {
            if (cmbUpdate.Text == "Seleccione ID cliente a actualizar" || cmbUpdate.SelectedIndex == -1)
            {
                MessageBox.Show("IMPOSIBLE ACTUALIZAR PROVEEDOR SIN HABER SELECCIONADO SU ID ");
            }

            else if (txtCedula.Text == string.Empty || txtEmail.Text == string.Empty || txtNombre.Text == string.Empty || txtTelefono.Text == string.Empty)
            {
                MessageBox.Show("IMPOSIBLE ACTUALIZAR PROVEEDOR CON CAMPOS VACIOS");
            }


            else
            {
                bool error1 = false;
                bool error2 = false;

                try { Convert.ToInt32(txtCedula.Text); } catch { error1 = true; MessageBox.Show("SOLO SE PERMITEN VALORES NUMERICOS EN EL CAMPO CEDULA"); }

                try { Convert.ToInt32(txtTelefono.Text); } catch { error2 = true; MessageBox.Show("SOLO SE PERMITEN VALORES NUMERICOS EN EL CAMPO DE TELEFONO"); }


                if (error1 == false && error2 == false)
                {

                    if (txtCedula.Text.Length >= 5)
                    {

                        if (txtTelefono.Text.Length >= 5)
                        {
                            Proveedores update = new Proveedores(conect);
                            update.NOMBRE = txtNombre.Text;
                            update.CEDULA = txtCedula.Text;
                            update.TELEFONO = txtTelefono.Text;
                            update.EMAIL = txtEmail.Text;

                            update.Actualizar(Convert.ToInt32(cmbUpdate.Text));  // actualizar

                            limpiarTodo.limpiar(this);
                            update.Peticion(dgvListaProveedores, "Select * from dbo.Proveedor");
                            
                        }

                        else
                        {
                            MessageBox.Show("CAMPO DE TELEFONO DEBE TENER AL MENOS 5 DIGITOS");
                        }

                    }

                    else
                    {
                        MessageBox.Show("CAMPO DE CEDULA DEBE TENER AL MENOS 5 DIGITOS");
                    }

                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)   // ELIMINAR
        {
            if (cmbEliminar.Text == "Seleccione ID proveedor a eliminar" || cmbEliminar.Text == "")
            {
                MessageBox.Show("IMPOSIBLE ELIMINAR SIN HABER SELECCIONADO EL ID DEL PROVEEDOR ");
            }

            else
            {
                DialogResult r = MessageBox.Show("Si elimina el usuario del ID " + "[ " + cmbEliminar.Text + " ]" + " se borrará todo lo concerniente a este \r\n\t\t ¿ Seguro que desea eliminarlo ?", "¿ Seguro ?", MessageBoxButtons.YesNo);

                if (r == DialogResult.No)
                {
                    MessageBox.Show("PROCESO CANCELADO !");

                    limpiarTodo.limpiar(this);      // limpiar form

                    gboxInformacionProveedor.Text = "Informacion Del Proveedor";
                }

                else
                {
                    Proveedores eliminar = new Proveedores(conect);
                    eliminar.Eliminar(Convert.ToInt32(cmbEliminar.Text));  // eliminar

                    eliminar.Peticion(dgvListaProveedores, "Select * from dbo.Proveedor");

                    limpiarTodo.limpiar(this);

                    eliminar.LlenarCombo(cmbUpdate, "Select IdProveedor from dbo.Proveedor");
                    eliminar.LlenarCombo(cmbEliminar, "Select IdProveedor from dbo.Proveedor");
                }

            }

        }
        
        private void cbmBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbmBusqueda.SelectedIndex == 0)
            {
                txtBuscarProveedorEmail.Visible = false;
                txtBuscarProveedorName.Visible = false;
            }

            else if(cbmBusqueda.SelectedIndex == 1)
            {
                txtBuscarProveedorName.Visible = true;
                txtBuscarProveedorEmail.Visible = false;
            }

            else
            {
                txtBuscarProveedorEmail.Visible = true;
                txtBuscarProveedorName.Visible = false;
            }

        }


  
        private void txtBuscarProveedorEmail_Enter(object sender, EventArgs e)
        {
            if (txtBuscarProveedorEmail.Text == "Escriba el email de proveedor")
            {
                txtBuscarProveedorEmail.Text = "";
                txtBuscarProveedorEmail.ForeColor = Color.Black;
            }

        }

        private void txtBuscarProveedorName_Enter(object sender, EventArgs e)
        {
            if (txtBuscarProveedorName.Text == "Escriba el nombre de proveedor")
            {
                txtBuscarProveedorName.Text = "";
                txtBuscarProveedorName.ForeColor = Color.Black;
            }
        }

      
        private void txtBuscarProveedorName_TextChanged(object sender, EventArgs e)
        {
            bool esNumerico = true;

            try { Convert.ToInt32(txtBuscarProveedorName.Text); MessageBox.Show("NO SE PERMITEN VALORES NUMERICOS EN LA BUSQUEDA"); txtBuscarProveedorName.Text = ""; } catch { esNumerico = false; }

            if (txtBuscarProveedorName.Text != "Escriba el nombre de proveedor" && esNumerico == false)
            {
                Proveedores buscarNombre = new Proveedores(conect);
                buscarNombre.Peticion(dgvListaProveedores, $"Select * from dbo.Proveedor where Nombre like '%{txtBuscarProveedorName.Text}%'");
            }

            else if (txtBuscarProveedorName.Text == string.Empty)
            {
                Proveedores buscarTodo = new Proveedores(conect);
                buscarTodo.Peticion(dgvListaProveedores, "Select * from dbo.Proveedor");
            }
        }

        private void txtBuscarProveedorEmail_TextChanged(object sender, EventArgs e)
        {
            bool esNumerico = true;

            try { Convert.ToInt32(txtBuscarProveedorEmail.Text); MessageBox.Show("NO SE PERMITEN VALORES NUMERICOS EN LA BUSQUEDA"); txtBuscarProveedorEmail.Text = ""; } catch { esNumerico = false; }

            if (txtBuscarProveedorEmail.Text != "Escriba el email del proveedor" && esNumerico == false)
            {
                Proveedores buscarNombre = new Proveedores(conect);
                buscarNombre.Peticion(dgvListaProveedores, $"Select * from dbo.Proveedor where Email like '%{txtBuscarProveedorEmail.Text}%'");
            }

            else if (txtBuscarProveedorEmail.Text == string.Empty)
            {
                Proveedores buscarTodo = new Proveedores(conect);
                buscarTodo.Peticion(dgvListaProveedores, "Select * from dbo.Proveedor");
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarTodo.limpiar(this);
            Proveedores showAll = new Proveedores(conect);
            showAll.Peticion(dgvListaProveedores, "Select * from dbo.Proveedor");


        }

        public void alternarColorFilas(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }


        // DESACTIVAR ESCRITURA EN COMBOBOX


        private void cbmBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbEliminar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }




    }
}
