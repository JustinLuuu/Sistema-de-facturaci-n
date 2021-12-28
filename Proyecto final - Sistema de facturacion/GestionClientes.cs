using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_final___Sistema_de_facturacion
{
    public partial class GestionClientes : Form                // CRUD DE CLIENTES
    {
        SqlConnection conect;

        public GestionClientes(SqlConnection conect)
        {
            InitializeComponent();
            this.conect = conect; 
        }


        private void GestionClientes_Load(object sender, EventArgs e)
        {
            Clientes loadForm = new Clientes(conect);
            loadForm.Peticion(dgvListaClientes, "Select * from dbo.Cliente");

            loadForm.LlenarCombo(cmbUpdate, "Select IdCliente from dbo.Cliente");     // llenar comboBox de actualizado de datos
            loadForm.LlenarCombo(cmbEliminar, "Select IdCliente from dbo.Cliente");   // llenar comboBox de eliminado de datos

            alternarColorFilas(dgvListaClientes);

        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 volver = new Form1();
            this.Hide();
            volver.ShowDialog();
        }

        private void cmbCategoria_Leave(object sender, EventArgs e)    // COMBOBOX CATEGORIA - LEAVE
        {
            if (cmbCategoria.Text == string.Empty || cmbCategoria.Text == "")
            {
                cmbCategoria.Text = "Elegir Categoria";
            } 
        }

        
        private void cmbUpdate_Leave(object sender, EventArgs e)   // COMBOBOX UPDATE - LEAVE
        {

            if (cmbUpdate.Text == string.Empty || cmbUpdate.Text == "")
            {
                cmbUpdate.Text = "Seleccione ID cliente a actualizar";
            }
           
        }

        

        private void cmbEliminar_Leave(object sender, EventArgs e)   // COMBOBOX ELIMINAR - LEAVE
        {
            if (cmbEliminar.Text == string.Empty || cmbEliminar.Text == "")
            {
                cmbEliminar.Text = "Seleccione ID cliente a eliminar";
            }
        }



        private void cmbUpdate_SelectedValueChanged_1(object sender, EventArgs e)
        {
          
            if (cmbUpdate.Text != "Seleccione ID cliente a actualizar" && cmbUpdate.Text != "")
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Select Nombre, Cedula, Telefono, Email, Categoria from dbo.Cliente where IdCliente = @ID", conect);
                comando.Parameters.AddWithValue("@ID", Convert.ToInt32(cmbUpdate.Text));

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    txtNombre.Text = lector["Nombre"].ToString();               // llenar campos de datos recopilados luego de seleccionar un ID en comboBox Update
                    txtCedula.Text = lector["Cedula"].ToString();               // llenar campos de datos recopilados luego de seleccionar un ID en comboBox Update
                    txtTelefono.Text = lector["Telefono"].ToString();           // llenar campos de datos recopilados luego de seleccionar un ID en comboBox Update
                    txtEmail.Text = lector["Email"].ToString();                 // llenar campos de datos recopilados luego de seleccionar un ID en comboBox Update
                    cmbCategoria.Text = lector["Categoria"].ToString();         // llenar campos de datos recopilados luego de seleccionar un ID en comboBox Update
                }

                gboxInformacion.Text = "Informacion recopilada a actualizar";   // al recuperar la informacion cambiamos el titulo del groupBox

                lector.Close();
                conect.Close();
            }

        }

        private void cmbEliminar_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (cmbEliminar.Text != "Seleccione ID cliente a eliminar" && cmbEliminar.Text != "")
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Select Nombre, Cedula, Telefono, Email, Categoria from dbo.Cliente where IdCliente = @ID", conect);
                comando.Parameters.AddWithValue("@ID", Convert.ToInt32(cmbEliminar.Text));

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    txtNombre.Text = lector["Nombre"].ToString();         // llenar campos de datos recopilados en comboBox eliminar
                    txtCedula.Text = lector["Cedula"].ToString();         // llenar campos de datos recopilados en comboBox eliminar
                    txtTelefono.Text = lector["Telefono"].ToString();     // llenar campos de datos recopilados en comboBox eliminar
                    txtEmail.Text = lector["Email"].ToString();           // llenar campos de datos recopilados en comboBox eliminar
                    cmbCategoria.Text = lector["Categoria"].ToString();   // llenar campos de datos recopilados en comboBox eliminar
                }

                gboxInformacion.Text = "Informacion recopilada a eliminar";

                lector.Close();
                conect.Close();
            }

        }

     

        //////////////////////// LIMPIAR TODO EN CASO DE QUE SE HAYA SELECCIONADO UNO DE ESOS ANTES QUE OTRO

        private void cmbUpdate_Click(object sender, EventArgs e)
        {
            if (cmbEliminar.Text != "Seleccione ID cliente a eliminar")
                limpiarTodo.limpiar(this);
            

        }

        private void cmbUpdate_Leave_1(object sender, EventArgs e)
        {
            if (cmbUpdate.Text == "" || cmbUpdate.Text == string.Empty)
            {
                cmbUpdate.Text = "Seleccione ID cliente a actualizar";
                limpiarTodo.limpiar(this);
            }
        }

        private void cmbEliminar_Click(object sender, EventArgs e)
        {
            if (cmbUpdate.Text != "Seleccione ID cliente a actualizar")
                limpiarTodo.limpiar(this);
        }

        private void cmbEliminar_Leave_1(object sender, EventArgs e)
        {
            if(cmbEliminar.Text == "" || cmbEliminar.Text == string.Empty)
            {
                cmbEliminar.Text = "Seleccione ID cliente a eliminar";
                limpiarTodo.limpiar(this);
            }
        }



        ///////////////////////////////////////////////////   CRUD<<<<<<<<<<<<<,

        private void btnAgregar_Click(object sender, EventArgs e)   // AGREGAR 
        {
            if (txtCedula.Text == "" || txtEmail.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "" || cmbCategoria.Text == "Elegir Categoria")
            {
                MessageBox.Show("IMPOSIBLE AGREGAR CLIENTE CON CAMPOS VACIOS !");
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
                        if(txtTelefono.Text.Length >= 5)
                        {
                            Clientes cliente = new Clientes(conect);

                            cliente.NOMBRE = txtNombre.Text;
                            cliente.CEDULA = txtCedula.Text;
                            cliente.TELEFONO = txtTelefono.Text;
                            cliente.EMAIL = txtEmail.Text;
                            cliente.CATEGORIA = cmbCategoria.Text;

                            cliente.Agregar();

                            cliente.Peticion(dgvListaClientes, "Select * from dbo.Cliente");   // llenar DataGridVIew
                            limpiarTodo.limpiar(this);
                          
                            cliente.LlenarCombo(cmbUpdate, "Select IdCliente from dbo.Cliente");     // actualizar comboBox de eliminado y actualizado
                            cliente.LlenarCombo(cmbEliminar, "Select IdCliente from dbo.Cliente");   // actualizar comboBox de eliminado y actualizado

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

        

        private void btnActualizar_Click_1(object sender, EventArgs e)       // ACTUALIZAR

        {
            if (cmbUpdate.Text == "Seleccione ID cliente a actualizar" || cmbUpdate.Text == "")
            {
                MessageBox.Show("IMPOSIBLE ACTUALIZAR CLIENTE SIN HABER SELECCIONADO SU ID ");
            }

            else if (txtCedula.Text == string.Empty || txtEmail.Text == string.Empty || txtNombre.Text == string.Empty || txtTelefono.Text == string.Empty || cmbCategoria.Text == "Elegir Categoria")
            {
                MessageBox.Show("IMPOSIBLE ACTUALIZAR CLIENTE CON CAMPOS VACIOS");
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
                            Clientes update = new Clientes(conect);
                            update.NOMBRE = txtNombre.Text;
                            update.CEDULA = txtCedula.Text;
                            update.TELEFONO = txtTelefono.Text;
                            update.EMAIL = txtEmail.Text;
                            update.CATEGORIA = cmbCategoria.Text;

                            update.Actualizar(Convert.ToInt32(cmbUpdate.Text));  // actualizar

                            limpiarTodo.limpiar(this);
                            update.Peticion(dgvListaClientes, "Select * from dbo.Cliente");
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

      
        private void btnEliminar_Click_1(object sender, EventArgs e)   // ELIMINAR
        {
            if(cmbEliminar.Text == "Seleccione ID cliente a eliminar" || cmbEliminar.Text ==  "")
            {
                MessageBox.Show("IMPOSIBLE ELIMINAR SIN HABER SELECCIONADO EL ID DEL CLIENTE ");
            } 

            else
            {
                DialogResult r = MessageBox.Show("Si elimina el usuario del ID "+ "[ " + cmbEliminar.Text + " ]" + " se borrará todo lo concerniente a este \r\n\t\t ¿ Seguro que desea eliminarlo ?", "¿ Seguro ?" ,MessageBoxButtons.YesNo);

                if (r == DialogResult.No )
                {
                    MessageBox.Show("PROCESO CANCELADO !");

                    limpiarTodo.limpiar(this);
                }

                else
                {
                    Clientes eliminar = new Clientes(conect); 
                    eliminar.Eliminar(Convert.ToInt32(cmbEliminar.Text));  // eliminar

                    SqlCommand comando = new SqlCommand("Select * from dbo.Cliente", conect);  // refrescar tablita luego de eliminar algun registro

                    limpiarTodo.limpiar(this);
                    eliminar.Peticion(dgvListaClientes, "Select * from dbo.Cliente");

                    eliminar.LlenarCombo(cmbUpdate, "Select IdCliente from dbo.Cliente");       // actualizar comboBox de eliminado y actualizado
                    eliminar.LlenarCombo(cmbEliminar, "Select IdCliente from dbo.Cliente");     // actualizar comboBox de eliminado y actualizado

                }

            }

        }


        // BUSQUEDA Y MIEMBROS DE BUSQUEDA <<<<<<<<<<<<<<<<<<<<<<<<<<<<

        private void cbmBusqueda_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(cbmBusqueda.SelectedIndex == 0)
            {
                txtBuscarNombre.Visible = false;
                cbmBusquedaCat.Visible = false; 
            }

            else if(cbmBusqueda.SelectedIndex == 1)
            {
                txtBuscarNombre.Visible = true;
                cbmBusquedaCat.Visible = false;
            }

            else
            {
                cbmBusquedaCat.Visible = true;
                txtBuscarNombre.Visible = false;
            }

        }


        private void cbmBusqueda_Leave_1(object sender, EventArgs e)
        {
            if (cbmBusqueda.Text == string.Empty)
            {
                cbmBusqueda.Text = "Filtro de busqueda";
            }
        }



        private void cbmBusquedaCat_Leave_1(object sender, EventArgs e)
        {
            cbmBusquedaCat.Text = "Filtrar categoria";
            cbmBusquedaCat.Visible = false;
        }


        private void cbmBusqueda_Click(object sender, EventArgs e)
        {
            if(cmbUpdate.Text != "Seleccione ID cliente a actualizar")
            {
                limpiarTodo.limpiar(this);
            }

            else if(cmbEliminar.Text != "Seleccione ID cliente a eliminar")
            {
                limpiarTodo.limpiar(this);
            }

        }

     
        private void txtBuscarNombre_Enter_1(object sender, EventArgs e)
        {
            if(txtBuscarNombre.Text == "Escriba el nombre de cliente")
            {
                txtBuscarNombre.Text = "";
                txtBuscarNombre.ForeColor = Color.Black;

            }
        }

        private void txtBuscarNombre_Leave_1(object sender, EventArgs e)
        {
            txtBuscarNombre.Visible = false;
            txtBuscarNombre.Text = "Escriba el nombre de cliente";
            txtBuscarNombre.ForeColor = Color.Gray;
        }

        /////////////// FILTRO DE BUSQUEDA

        private void txtBuscarNombre_TextChanged_1(object sender, EventArgs e)
        {
            bool esNumerico = true;

            try { Convert.ToInt32(txtBuscarNombre.Text);  MessageBox.Show("NO SE PERMITEN VALORES NUMERICOS EN LA BUSQUEDA"); txtBuscarNombre.Text = ""; } catch { esNumerico = false;  }

            if (txtBuscarNombre.Text != "Escriba el nombre de cliente" && esNumerico == false)
            {
                Clientes buscarNombre = new Clientes(conect);
                buscarNombre.Peticion(dgvListaClientes, $"Select * from dbo.Cliente where Nombre like '%{txtBuscarNombre.Text}%'");
            }

            else if(txtBuscarNombre.Text == string.Empty)
            {
                Clientes buscarNombre = new Clientes(conect);
                buscarNombre.Peticion(dgvListaClientes, "Select * from dbo.Cliente");
            }
        
        }

        private void cbmBusquedaCat_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string categoria;
            int numeroDeCategoria;

              if(cbmBusquedaCat.SelectedIndex == 1)  // SELECCION DE CATEGORIA PREMIUM
              {
                 categoria = cbmBusquedaCat.SelectedItem.ToString().Trim();
                 Clientes buscarCat = new Clientes(conect);
                 buscarCat.Peticion(dgvListaClientes, $"Select * from dbo.Cliente where Categoria = '{categoria}' ");

                 conect.Open();

                 SqlCommand cmd = new SqlCommand($"Select count(*) from dbo.Cliente where Categoria = '{categoria}' ", conect);
                 numeroDeCategoria = Convert.ToInt32(cmd.ExecuteScalar());   // capturar el numero de 

                 gbListaTitulo.Text = $"Hay {numeroDeCategoria} clientes PREMIUM ";

                 conect.Close();
              }
              
              else if(cbmBusquedaCat.SelectedIndex == 2)  // SELECCION DE CATEGORIA REGULAR
              {
                conect.Open();
                  
                 categoria = cbmBusquedaCat.SelectedItem.ToString().Trim();
                 Clientes buscarCat = new Clientes(conect);
                 buscarCat.Peticion(dgvListaClientes, $"Select * from dbo.Cliente where Categoria = '{categoria}' ");

                 SqlCommand cmd = new SqlCommand($"Select count(*) from dbo.Cliente where Categoria = '{categoria}' ", conect);
                 numeroDeCategoria = Convert.ToInt32(cmd.ExecuteScalar());   // capturar el numero de 
               
                 gbListaTitulo.Text = $"Hay {numeroDeCategoria} clientes REGULAR";

                conect.Close();
              }   
             
        }


        //////////////////////////////////// LIMPIAR TODO

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            gbListaTitulo.Text = "Lista De Clientes";
             limpiarTodo.limpiar(this);

            Clientes dd = new Clientes(conect);
            dd.Peticion(dgvListaClientes, "Select * from dbo.Cliente");

        }


        /////////////////////// MEJORAR APARIENCIA DE DATAGRIDVIEW
        
        public void alternarColorFilas(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }



        // DESACTIVAR ESCRITURA EN COMBOBOX


        private void cmbUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbEliminar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbmBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbmBusquedaCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
