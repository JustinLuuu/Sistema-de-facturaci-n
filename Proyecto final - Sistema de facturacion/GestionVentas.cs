using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proyecto_final___Sistema_de_facturacion
{
    public partial class GestionVentas : Form
    {
        private string[] separarCadena;
        private string elemento;

        private int maxCantidadProducto;
        SqlConnection conect;

        public GestionVentas(SqlConnection conect)
        {
            InitializeComponent();
            this.conect = conect;

            checkbxPremium.AutoCheck = false;  // para hacer el checkbox uncheckable
            checkbxRegular.AutoCheck = false;  // para hacer el checkbox uncheckable
        }

        private void GestionVentas_Load(object sender, EventArgs e)
        {
     
            Factura loadForm = new Factura(conect);
            alternarColorFilasInventario(dgvListaFacturas);

            loadForm.Peticion(dgvListaFacturas, "Select * from dbo.Facturacion");
            agregarColumna(dgvListaFacturas);
            loadForm.LlenarCombo(cmbCliente, "Select IdCliente , Nombre from dbo.Cliente");
            loadForm.LlenarCombo(cmbProducto, "select Producto.Nombre from Inventario inner join Producto on Inventario.IdProducto = Producto.IdProducto");
         
            this.dgvListaFacturas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;   // AJUSTAR LAS COLUMNAS Y CELDAS DEL DATAGRIDVIEW


            conect.Open();

            SqlCommand comando = new SqlCommand("Select count(*) from dbo.Facturacion", conect);
            int numFilas = Convert.ToInt32(comando.ExecuteScalar());

            if(numFilas > 0)
            {
                DataGridViewButtonColumn botones = new DataGridViewButtonColumn();
                botones.Name = "botones";
                botones.HeaderText = ""; 
                botones.Text = "Facturar";
                botones.UseColumnTextForButtonValue = true;
                dgvListaFacturas.Columns.Add(botones);

            }


            // LLENAR COMBOBOX DE BUSCAR LOS CLIENTES 

            List<int> listaId = new List<int>();
            comando = new SqlCommand("Select IdCliente from dbo.Facturacion group by IdCliente", conect);
            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                listaId.Add(Convert.ToInt32(lector["IdCliente"]));
            }


            for (int i = 0; i < listaId.Count; i++)
            {
                lector.Close();

                comando = new SqlCommand($"Select Nombre from dbo.Cliente where IdCliente = {Convert.ToInt32(listaId[i])}", conect);
                lector = comando.ExecuteReader(); 

                while (lector.Read())
                {
                    cmbBuscarCliente.Items.Add("ID [ " + listaId[i].ToString() + " ]  " + lector["Nombre"].ToString() );
                }
            }

            lector.Close();
            conect.Close();
        }

        
        private void cmbCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbCliente.Text != "Elija ID del cliente a servir" && cmbCliente.Text != "" && cmbProducto.Text != string.Empty)
            {
                iClienteCategoria mutante = null;  // USANDO LA INTERFAZ COMO UN OBJETO POLIMÓRFICO, YA QUE EN CONCEPTO ES ABSTRACTO PERO DE IGUAL MANERA PUEDE ACTUAR 
                // COMO CLASES DIFERENTES SIEMPRE Y CUANDO DERIRVEN DE ESTA

                conect.Open();

                separarCadena = cmbCliente.Text.Split(' ');  
                elemento = separarCadena[2]; 
                cmbCliente.Text = elemento;

               
                string categoria;
                SqlCommand comando = new SqlCommand("Select Categoria from dbo.Cliente where IdCliente = @ID", conect);  //para capturar la categoria del ID del cliente que elegimos
                comando.Parameters.AddWithValue("@ID", cmbCliente.Text); 

                categoria = Convert.ToString(comando.ExecuteScalar()); // capturamos la categoria 

                if (categoria == "PREMIUM")   // si el id que elegimos tiene categoria PREMIUM entrara a ese proceso
                {
                    mutante = new Premium();  // POLIMORFISMO 
                    mutante.checkCategoria(checkbxPremium, checkbxRegular);   // hacemos uso del polimorfismo, haciendo que el objeto abstracto haga un checked en el checkbox que le corresponde a la categoria PREMIUM
                    txtDescuento.Text = "5%";  // si es de categoria PREMIUM entonces al txt de Descuento le agregamos 5%
                }

                else  // de lo contrario, si el id que elegimos no tiene categoria PREMIUM, o sea, que es REGULAR, entrara a este proceso
                {
                    mutante = new Regular();  // POLIMORFISMO
                    mutante.checkCategoria(checkbxPremium, checkbxRegular);   // hacemos uso del polimorfismo, haciendo que el objeto abstracto haga un checked en el checkbox que le corresponde a la categoria REGULAR
                    txtDescuento.Text = "ninguno"; // si es de categoria REGULAR entonces al txt de Descuento le agregamos > 'ninguno'
                }

                if (txtPrecio.Text != "" || txtPrecio.Text != string.Empty) // esto es en caso de que los demas txt que ayudan a sacar el total de la venta tengan algun valor y asi empezar a sacar el valor desde alli, en caso de que lo cambien o algo
                {
                    if (numUP.Value != 0)  // la misma razon de arriba
                    {
                        Factura factura = new Factura(conect);

                        if(txtDescuento.Text == "5%")
                        {
                            factura.DESCUENTO = 5;
                            factura.PRECIO = Convert.ToDecimal(txtPrecio.Text);
                            factura.CANTIDAD = Convert.ToDecimal(numUP.Value);

                            mutante = new Premium();  // POLIMORFISMO

                            txtTotal.Text = Convert.ToString(mutante.calcularTotal(factura.DESCUENTO, factura.PRECIO, factura.CANTIDAD));
                        }

                        else
                        {
                            factura.DESCUENTO = 0;
                            factura.PRECIO = Convert.ToDecimal(txtPrecio.Text);
                            factura.CANTIDAD = Convert.ToDecimal(numUP.Value);

                            mutante = new Regular();  // POLIMORFISMO

                            txtTotal.Text = Convert.ToString(mutante.calcularTotal(factura.DESCUENTO, factura.PRECIO, factura.CANTIDAD));
                        }
                    }
                }

                comando = new SqlCommand("Select Nombre from dbo.Cliente where IdCliente = @ID", conect); // para capturar el nombre del ID que elegimos en el combobox
                comando.Parameters.AddWithValue("@ID", cmbCliente.Text);

                string nombreCliente = Convert.ToString(comando.ExecuteScalar());  // capturar el nombre del ID que elegimos en el combobox

                lblClienteNombre.Text = "Cliente: " + nombreCliente; // lo agregamos a un label
                lblClienteNombre.Visible = true;  // alternamos su visibilidad
                 
                conect.Close();
            }

        }



        private void cmbProducto_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbProducto.Text != "Elija un producto" && cmbProducto.Text != "" && cmbProducto.Text != string.Empty)
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Select Precio from dbo.Producto where Nombre = @NombreProducto", conect);  // para obtener datos del precio de ese producto
                comando.Parameters.AddWithValue("@NombreProducto", cmbProducto.Text);

                string precio = Convert.ToString(comando.ExecuteScalar()); // la variable captura el precio del producto mediante el comando
                txtPrecio.Text = precio;  // el txt del precio recibe entonces el valor que recopilamos

                List<string> listaProv = new List<string>(); // el motivo de la existencia de esta lista es porque al hacer la consulta de abajo:  del inner join
                // me devolvia mas de un valor o mas de un proveedor
                //ya que se vincula por la tabla ENTRADAS y como ENTRADAS es una tabla historica, basicamente no se borra nada de ahi, 
                // puede que se hayan insertado el mismo producto varias veces pero con diferentes proveedores ya sea por capricho del usuario de este programa o algo,
                // entonces me di cuenta que el ultimo proveedor que se le haya asignado al mismo producto o de cualquiera queda en la ultima posicion, entonces vemos que mas abajo leemos 
                // el resultado de la consulta por medio de un DATAREADER, el DATAREADER lee el resultado de la consulta de arriba hacia abajo en orden entonces 
                // al ser asi podemos ver que mucho mas abajo usamos el metodo REVERSE por la lista y asi deforma los ordenes colocando lo que fue el ultimo resultado
                // en la primera posicion 

                comando = new SqlCommand("Select Proveedor.Nombre from Entradas inner join Proveedor" +
                 " on Entradas.IdProveedor = Proveedor.IdProveedor where NombreProducto = @NombreProducto ", conect); // consulta para obtener proveedor o proveedores xd

                comando.Parameters.AddWithValue("@NombreProducto", cmbProducto.Text);
                SqlDataReader lector = comando.ExecuteReader(); // leemos

                while (lector.Read()) // leemos
                {
                    listaProv.Add(lector["Nombre"].ToString());  // agregamos lo que vamos leyendo a la lista
                }

                listaProv.Reverse();  // invertimos los ordenes

                txtProveedor.Text = listaProv[0];  // insertamos en el txt del proveedor el elemento de la primera posicion en la lista que era el ultimo en un principio. 

                lector.Close();

                comando = new SqlCommand($"Select Cantidad from Inventario where IdProducto = (Select IdProducto from Producto where Nombre = '{cmbProducto.Text}') ", conect);  // extraer la cantidad maxima de ese producto
                maxCantidadProducto = Convert.ToInt32(comando.ExecuteScalar());  // capturar la cantidad maxima por medio del query para tener un control 

                conect.Close();
            }
        }


        // CALCULO DEL TOTAL 

        private void txtPrecio_TextChanged(object sender, EventArgs e)  // ESTO ES EN CASO DE QUE LOS DEMAS TXT QUE AYUDAN A SACAR EL TOTAL DE LA VENTA TENGAN ALGUN VALOR AñADIDO Y ASI SACAR DE FORMA SEGUIDA EL TOTAL DE LA VENTA EN SI
        {
            iClienteCategoria mutante = null;
            Factura factura = new Factura(conect);

            if (numUP.Value != 0)
            {
                if (txtPrecio.Text != "" && txtPrecio.Text != string.Empty)
                {

                    if (txtDescuento.Text == "5%")
                    {

                        factura.DESCUENTO = 5;
                        factura.PRECIO = Convert.ToDecimal(txtPrecio.Text);
                        factura.CANTIDAD = Convert.ToDecimal(numUP.Value);

                        mutante = new Premium();

                        txtTotal.Text = Convert.ToString(mutante.calcularTotal(factura.DESCUENTO, factura.PRECIO, factura.CANTIDAD));
                    }

                    else
                    {
                        factura.DESCUENTO = 5;
                        factura.PRECIO = Convert.ToDecimal(txtPrecio.Text);
                        factura.CANTIDAD = Convert.ToDecimal(numUP.Value);

                        mutante = new Regular();

                        txtTotal.Text = Convert.ToString(mutante.calcularTotal(factura.DESCUENTO, factura.PRECIO, factura.CANTIDAD));

                    }

                }
            }
        }

        // AGREGAR FACTURA


        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "" || txtPrecio.Text == string.Empty || cmbCliente.Text == "Elija ID del cliente a servir") 
            {
                MessageBox.Show("IMPOSIBLE HACER VENTA CON CAMPOS VACIOS ");
            }

            else
            {
                if (numUP.Value != 0)
                {
                    conect.Open();

                    SqlCommand comando;
                    Factura factura = new Factura(conect);

                    separarCadena = cmbCliente.Text.Split(' ');
                    elemento = separarCadena[2];
                    cmbCliente.Text = elemento;

                    factura.IDCLIENTE = Convert.ToInt32(cmbCliente.Text);  // llenando propiedad del ID del cliente

                    comando = new SqlCommand($"Select IdProducto from dbo.Producto where Nombre = '{cmbProducto.Text}'", conect);  // extraer ID del producto que seleccionamos
                    int idProducto = Convert.ToInt32(comando.ExecuteScalar());  // capturamos el ID del producto
                    factura.IDPRODUCTO = idProducto; // llenamos propiedad del ID del producto luego de capturar el id del producto

                    factura.PRECIO = Convert.ToDecimal(txtPrecio.Text); // llenamos la propiedad del precio del producto

                    comando = new SqlCommand($"Select IdProveedor from dbo.Proveedor where Nombre = '{txtProveedor.Text}'", conect);  // extraer ID del proveedor del producto que seleccionamos
                    int idProveedor = Convert.ToInt32(comando.ExecuteScalar()); // capturamos el ID del proveedor del producto
                    factura.IDPROVEEDOR = idProveedor;

                    conect.Close();

                    factura.CANTIDAD = Convert.ToInt32(numUP.Value); // llenamos la propiedad de CANTIDAD

                    if (txtDescuento.Text == "5%")
                    {
                        factura.DESCUENTO = 5;
                    }

                    else
                    {
                        factura.DESCUENTO = 0;
                    }

                    factura.TOTAL = Convert.ToDecimal(txtTotal.Text);


                    factura.Agregar();  // agregar a la tabla de facturacion 

                    conect.Open();

                    comando = new SqlCommand($"Select Cantidad from dbo.Inventario where IdProducto = {idProducto}", conect);
                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());

                    cantidad = cantidad - Convert.ToInt32(numUP.Value);

                    if (cantidad == 0)
                    {
                        comando = new SqlCommand($"Delete from dbo.Inventario where IdProducto = {idProducto}", conect);
                        comando.ExecuteNonQuery();
                        MessageBox.Show($"SE HA AGOTADO EL PRODUCTO [ {cmbProducto.Text} ] POR LO QUE SE HA BORRADO DEL INVENTARIO ");
                    }

                    else
                    {
                        comando = new SqlCommand($"Update dbo.Inventario set Cantidad = {cantidad} where IdProducto = {idProducto} ", conect);
                        comando.ExecuteNonQuery();
                    }

                    conect.Close();

                    dgvListaFacturas.Columns.Clear();
                    factura.Peticion(dgvListaFacturas, "Select * from dbo.Facturacion");  
                    agregarColumna(dgvListaFacturas);
                    factura.LlenarCombo(cmbProducto, "Select Producto.Nombre from Inventario inner join Producto on Inventario.IdProducto = Producto.IdProducto");
                    limpiarTodo.limpiar(this);

                    DataGridViewButtonColumn botones = new DataGridViewButtonColumn();
                    botones.Name = "botones";
                    botones.HeaderText = "";
                    botones.Text = "Facturar";
                    botones.UseColumnTextForButtonValue = true;
                    dgvListaFacturas.Columns.Add(botones);


                }
                else
                {
                    MessageBox.Show("LA CANTIDAD DE PRODUCTOS A VENDER NUNCA PUEDE SER 0");
                }
            }

        }


        private void agregarColumna(DataGridView tablalogica)
        {
            conect.Open();

            SqlCommand comando;
            SqlDataReader lector;

            dgvListaFacturas.Columns.Remove("IdProducto");
            dgvListaFacturas.Columns.Remove("IdProveedor");

            DataGridViewColumn col1 = new DataGridViewColumn();  // CREAR OBJETO DE COLUMNA PARA AGREGARLO AL DATAGRIDVIEW
            col1.DataPropertyName = "Micolumna";   // AGREGARLE UN NOMBRE POR ETICA
            col1.Name = "Cliente";  // AGREGARLE EL TITULO CON EL CUAL SE MOSTRARA EN EL DATAGRIDVIEW
            col1.CellTemplate = new DataGridViewTextBoxCell();   // DEFINIR COLUMNA FORMATO DE TEXTO
            tablalogica.Columns.Insert(2, col1);   // INSERTAR LA COLUMNA YA CREADA EN UNA POSICION EN ESPECIFICO

            List<string> clienteNombre = new List<string>(); // LISTA PARA RETENER LOS ID'S DEL INVENTARIO
            comando = new SqlCommand("select Cliente.Nombre from Facturacion inner join Cliente on Facturacion.IdCliente = Cliente.IdCliente ", conect);
            lector = comando.ExecuteReader();

            int acum = 0;

            while (lector.Read())
            {
                tablalogica.Rows[acum].Cells["Cliente"].Value = lector["Nombre"].ToString();  // agregar valores en la columna PRODUCTO iterando sus celdas a la vez con el acumulador (ACUM)
                acum++;
            }

            lector.Close();

            DataGridViewColumn col2 = new DataGridViewColumn();  // CREAR OBJETO DE COLUMNA PARA AGREGARLO AL DATAGRIDVIEW
            col2.DataPropertyName = "Micolumna";   // AGREGARLE UN NOMBRE POR ETICA
            col2.Name = "Producto";  // AGREGARLE EL TITULO CON EL CUAL SE MOSTRARA EN EL DATAGRIDVIEW
            col2.CellTemplate = new DataGridViewTextBoxCell();   // DEFINIR COLUMNA FORMATO DE TEXTO
            tablalogica.Columns.Insert(3, col2);   // INSERTAR LA COLUMNA YA CREADA EN UNA POSICION EN ESPECIFICO

            comando = new SqlCommand("Select Producto.Nombre from Facturacion inner join Producto on Facturacion.IdProducto = Producto.IdProducto",conect);
            lector = comando.ExecuteReader();

            acum = 0;

            while (lector.Read())
            {
                tablalogica.Rows[acum].Cells["Producto"].Value = lector["Nombre"].ToString();  // agregar valores en la columna PRODUCTO iterando sus celdas a la vez con el acumulador (ACUM)
                acum++;
            }

            lector.Close();

          
            dgvListaFacturas.Columns["IdCliente"].DisplayIndex = 2;

            dgvListaFacturas.Columns["CantidadProducto"].HeaderText = "Cantidad";
           dgvListaFacturas.Columns[6].HeaderText = "Precio";


            conect.Close();
        }




        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 volver = new Form1();
            this.Hide();
            volver.ShowDialog();
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpCalendario.Value = DateTime.Now;
            dtpCalendario.Visible = false;

            limpiarTodo.limpiar(this);
            numUP.Value = 0;
            Factura dd = new Factura(conect);
            dgvListaFacturas.Columns.Clear();
            dd.Peticion(dgvListaFacturas, "Select * from dbo.Facturacion");
            gbListaTitulo.Text = "Lista De Facturas";
            gbListaTitulo.ForeColor = Color.Black;
            gbListaTitulo.BackColor = Color.White;
            agregarColumna(dgvListaFacturas);

            conect.Open();

            SqlCommand comando = new SqlCommand("Select count(*) from dbo.Facturacion", conect);
            int numFilas = Convert.ToInt32(comando.ExecuteScalar());

            if (numFilas > 0)
            {
                DataGridViewButtonColumn botones = new DataGridViewButtonColumn();
                botones.Name = "botones";
                botones.HeaderText = "";
                botones.Text = "Facturar";
                botones.UseColumnTextForButtonValue = true;
                dgvListaFacturas.Columns.Add(botones);

            }

            conect.Close();
        
        }



        private void dgvListaFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                conect.Open();

                decimal precio, total;
                int idCliente, idFactura, idProducto, cantidad, descuento, impuesto;
                string nombre, telefono, email, cedula, descripcionProducto, fecha;


                idCliente = Convert.ToInt32(dgvListaFacturas.Rows[e.RowIndex].Cells["IdCliente"].Value);  // SELECCIONAR CONTENIDO DE ESA FILA JAJAJ
                nombre  = Convert.ToString(dgvListaFacturas.Rows[e.RowIndex].Cells["Cliente"].Value);
                descripcionProducto = Convert.ToString(dgvListaFacturas.Rows[e.RowIndex].Cells["Producto"].Value);
                precio = Convert.ToInt32(dgvListaFacturas.Rows[e.RowIndex].Cells["PrecioProducto"].Value);
                cantidad = Convert.ToInt32(dgvListaFacturas.Rows[e.RowIndex].Cells["CantidadProducto"].Value);
                idFactura = Convert.ToInt32(dgvListaFacturas.Rows[e.RowIndex].Cells["IdFactura"].Value);
                descuento = Convert.ToInt32(dgvListaFacturas.Rows[e.RowIndex].Cells["Descuento"].Value);
                impuesto = Convert.ToInt32(dgvListaFacturas.Rows[e.RowIndex].Cells["Itbis"].Value);
                total = Convert.ToDecimal(dgvListaFacturas.Rows[e.RowIndex].Cells["Total"].Value);

                SqlCommand comando = new SqlCommand($"Select Telefono from dbo.Cliente where IdCliente = {idCliente}", conect);
                telefono = Convert.ToString(comando.ExecuteScalar());
                comando = new SqlCommand($"Select Email from dbo.Cliente where IdCliente = {idCliente}", conect);
                 email = Convert.ToString(comando.ExecuteScalar());              
                comando = new SqlCommand($"Select Cedula from dbo.Cliente where IdCliente = {idCliente}", conect);
                cedula = Convert.ToString(comando.ExecuteScalar());             
                comando = new SqlCommand($"Select IdProducto from dbo.Producto where Nombre = '{descripcionProducto}'", conect);
                idProducto = Convert.ToInt32(comando.ExecuteScalar());                
                comando = new SqlCommand("Select getdate()", conect);
                string receptor = Convert.ToString(comando.ExecuteScalar());
                separarCadena = receptor.Split(' ');
                fecha = separarCadena[0];
                
                conect.Close();

                mostrarInforme mostrar = new mostrarInforme(idFactura, idCliente, nombre, telefono, email, cedula, descripcionProducto, precio, cantidad, descuento, impuesto, total, fecha, idProducto);
                mostrar.ShowDialog();
            }
            catch
            {
                conect.Close();
                MessageBox.Show("IMPOSIBLE FACTURAR PORQUE LA FILA QUE SELECCIONO NO TIENE DATOS DE NINGUNA VENTA");
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////



        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbmBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }



        private void numUP_ValueChanged(object sender, EventArgs e)
        {
            bool error = false;


            if (txtPrecio.Text != "")
            {
                 if (numUP.Value != 0 && cmbProducto.Text != "" && cmbProducto.Text != string.Empty && cmbProducto.Text.Length > 0)
                 {
                    if (Convert.ToInt32(numUP.Value) > maxCantidadProducto)
                    {
                        MessageBox.Show($"ESA CANTIDAD ES SUPERIOR A LA CANTIDAD DISPONIBLE ! ");
                        numUP.Value = numUP.Value - 1;
                        error = true;
                    }

                    if (error == false)
                    {
                        if (numUP.Value != 0)
                        {
                            iClienteCategoria mutante = null; // objeto abstracto
                            Factura factura = new Factura(conect);

                            if (txtDescuento.Text == "5%")
                            {
                                factura.DESCUENTO = 5; // tiene descuento porque es premium por eso el 5 de 5%
                                factura.PRECIO = Convert.ToDecimal(txtPrecio.Text);
                                factura.CANTIDAD = Convert.ToDecimal(numUP.Value);

                                mutante = new Premium();  // POLIMORFISMO

                                txtTotal.Text = Convert.ToString(mutante.calcularTotal(factura.DESCUENTO, factura.PRECIO, factura.CANTIDAD));
                            }

                            else
                            {
                                factura.DESCUENTO = 0; // no tiene descuento por eso el 0, aunque le pasamos este valor como parametro al metodo, dentro de su espacio no hace nada con este valor
                                factura.PRECIO = Convert.ToDecimal(txtPrecio.Text);
                                factura.CANTIDAD = Convert.ToDecimal(numUP.Value);

                                mutante = new Regular();  // POLIMORFISMO

                                txtTotal.Text = Convert.ToString(mutante.calcularTotal(factura.DESCUENTO, factura.PRECIO, factura.CANTIDAD));
                            }
                        }

                        else
                        {
                            txtTotal.Clear();
                        }
                    }
                 }

                else
                {
                    txtTotal.Clear();
                }
            }

            else
            {
                MessageBox.Show("IMPOSIBLE COLOCAR CANTIDAD SIN HABER ELEGIDO EL PRODUCTO");
                numUP.Value = 0;
            }

        }

        private void cbmBusqueda_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbmBusqueda.SelectedIndex ==  1)
            {
                dtpCalendario.Visible = true;
                cmbBuscarCliente.Visible = false;
            }

            else if(cbmBusqueda.SelectedIndex == 2)
            {
                cmbBuscarCliente.Visible = true;
                dtpCalendario.Visible = false;
            }

            else
            {
                cmbBuscarCliente.Visible = false;
                dtpCalendario.Visible = false;
            }


        }

        private void cmbBuscarCliente_SelectedValueChanged(object sender, EventArgs e)
        {

            if(cmbBuscarCliente.Text != "Elija la cuenta del cliente")
            {
                conect.Open();

                separarCadena = cmbBuscarCliente.Text.Split(' ');
                elemento = separarCadena[2];
                cmbBuscarCliente.Text = elemento;

                gbListaTitulo.Text = $"Resultado facturado del Cliente con el ID [ {cmbBuscarCliente.Text} ]";
                gbListaTitulo.ForeColor = Color.DarkRed;
                gbListaTitulo.BackColor = Color.White;

                SqlCommand comando = new SqlCommand($"Select * from dbo.Facturacion where IdCliente = {Convert.ToInt32(cmbBuscarCliente.Text)}", conect);
                SqlDataAdapter adp = new SqlDataAdapter(comando);
                DataTable tab = new DataTable();
                adp.Fill(tab);
                dgvListaFacturas.Columns.Clear();
                dgvListaFacturas.DataSource = tab;



                conect.Close();
            }

        }

     
        private void dtpCalendario_ValueChanged(object sender, EventArgs e)
        {
            string fechareal = dtpCalendario.Value.ToString("dd/MM/yyyy");  // convertir el valor de seleccion del DateTimePicker a string en formato (day/month/year)
           
            string query = $"Select * from dbo.Facturacion where Fecha = '{fechareal}'";
            dgvListaFacturas.Columns.Clear();
            Factura ins = new Factura(conect);
            ins.Peticion(dgvListaFacturas, query);

            conect.Open();

            SqlCommand com = new SqlCommand($"Select count(*) from dbo.Facturacion where Fecha = '{fechareal}'", conect);
            int numFactura = Convert.ToInt32(com.ExecuteScalar());

            gbListaTitulo.Text = $"En la fecha [ {fechareal} ] se generaron [ {numFactura} ] cantidad de facturas";
            gbListaTitulo.ForeColor = Color.DarkRed;
            gbListaTitulo.BackColor = Color.White;

            conect.Close();

        }


        public void alternarColorFilasInventario(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.Pink;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }
      
    }  
}