using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final___Sistema_de_facturacion
{
    class limpiarTodo
    {
       public static void limpiar(Form formulario)
       {
           foreach(Control control in formulario.Controls)
           {

                if (control is GroupBox)    // PARA GROUPBOXES
                {
                    if (control.Name == "gboxInformacion")
                    {
                        control.Text = "Informacion Del Cliente";

                        foreach (Control controlcito in control.Controls)
                        {
                            if (controlcito is TextBox)
                            {
                                controlcito.Text = string.Empty;
                            }

                            if (controlcito is ComboBox)
                            {
                                controlcito.Text = "Elegir Categoria";
                            }
                        }
                    }


                    if(control.Name == "gboxInformacionProveedor")
                    {
                        control.Text = "Informacion Del Proveedor";

                        foreach (Control controlcito in control.Controls)
                        {
                            if (controlcito is TextBox)
                            {
                                controlcito.Text = string.Empty;
                            }
                         
                        }
                    }

                    if(control.Name == "gboxInformacionProducto")
                    {
                        control.Text = "Informacion Del Producto";

                        foreach(Control controlcito in control.Controls)
                        {
                            if(controlcito is TextBox)
                            {
                                controlcito.Text = string.Empty;
                            }
                        }

                    }

                    if(control.Name == "gboxInfoProductoIngreso")
                    {
                        control.Text = "Venta y Facturacion";

                        foreach (Control controlcito in control.Controls)
                        {
                            if (controlcito is TextBox)
                            {
                                controlcito.Text = string.Empty;
                            }

                            if(controlcito is ComboBox)
                            {
                                if(controlcito.Name == "cmbProducto")
                                {
                                    controlcito.Text = "Elija producto a ingresar";
                                }

                                else
                                {
                                    controlcito.Text = "Elija proveedor de producto";
                                }

                            }

                        }

                    }

                    if(control.Name == "gboxFactura")
                    {
                        foreach (Control controlcito in control.Controls)
                        {
                            if (controlcito is TextBox)
                            {
                                controlcito.Text = string.Empty;
                            }

                            if (controlcito is ComboBox)
                            {
                                if (controlcito.Name == "cmbCliente")
                                {
                                    controlcito.Text = "Elija ID del cliente a servir";
                                }

                                else
                                {
                                    controlcito.Text = "Elija un producto";
                                }

                            }

                            if (controlcito is CheckBox)
                            {
                                ((CheckBox)controlcito).Checked = false;
                            }

                            if (controlcito is Label)
                            {
                                if (controlcito.Name == "lblClienteNombre")
                                {
                                    controlcito.Visible = false;
                                }
                                   
                            }

                        }


                    }


                }

                if(control is Label)
                {
                    if(control.Name == "lblConsultarFecha")
                    {
                        control.Visible = false;
                    }
                }

                if(control is MonthCalendar)
                {
                    control.Visible = false;
                }
                 
                if (control is Panel)     // PARA PANELES
                {

                    if (control.Name == "panelClientes2")
                    {
                        foreach (Control controlcito in control.Controls)
                        {
                            if (controlcito is ComboBox)
                            {
                                if (controlcito.Name == "cmbUpdate")
                                {
                                    controlcito.Text = "Seleccione ID cliente a actualizar";
                                }

                                else if (controlcito.Name == "cmbEliminar")
                                {
                                    controlcito.Text = "Seleccione ID cliente a eliminar";
                                }
                            }
                           
                        }
                       
                    }

                    if (control.Name == "panelClientes1")
                    {
                        foreach (Control controlcito in control.Controls)
                        {
                            if (controlcito is TextBox)
                            {
                                controlcito.Visible = false;
                            }

                            if (controlcito is ComboBox)
                            {
                                controlcito.Text = "Filtro de busqueda";
                            }
                        }
                    }

                    if (control.Name == "panelProveedores1")
                    {
                        foreach (Control controlcito in control.Controls)
                        {
                            if (controlcito is ComboBox)
                            {
                                if (controlcito.Name == "cmbUpdate")
                                {
                                    controlcito.Text = "Seleccione ID proveedor a actualizar";
                                }

                                else if (controlcito.Name == "cmbEliminar")
                                {
                                    controlcito.Text = "Seleccione ID proveedor a eliminar";
                                }
                            }

                        }
                    }

                    if(control.Name == "panelProveedores2")
                    {
                        foreach (Control controlcito in control.Controls)
                        {
                            if (controlcito is TextBox)
                            {
                                controlcito.Visible = false;

                                if(controlcito.Name == "txtBuscarProveedorEmail")
                                {
                                    controlcito.Text = "Escriba el email de proveedor";
                                    controlcito.ForeColor = Color.Gray;
                                }

                                else if(controlcito.Name == "txtBuscarProveedorName")
                                {
                                    controlcito.Text = "Escriba el nombre de proveedor";
                                    controlcito.ForeColor = Color.Gray;
                                }
                            }

                            if(controlcito is ComboBox)
                            {
                                controlcito.Text = "Filtro de busqueda";
                            }

                        }
                    }

                    if(control.Name == "panelProductos1")
                    {
                        foreach (Control controlcito in control.Controls)
                        {

                            if (controlcito is ComboBox)
                            {
                                if(controlcito.Name == "cmbUpdate")
                                {
                                    controlcito.Text = "Seleccione producto a actualizar";
                                }

                                if(controlcito.Name == "cmbEliminar")
                                {
                                    controlcito.Text = "Seleccione producto a eliminar";
                                }

                            }

                        }
                    }

                    if(control.Name == "panelProductos2")
                    {
                        foreach (Control controlcito in control.Controls)
                        {
                            if (controlcito is ComboBox)
                            {
                                controlcito.Text = "Filtro de busqueda";

                            }
                            
                            if(controlcito is TextBox)
                            {
                                controlcito.Visible = false;
                                controlcito.Text = "Escriba el nombre del producto";
                                controlcito.ForeColor = Color.Gray;

                            }

                        }
                    }

                    if(control.Name == "panelEliminarInventario")
                    {
                        foreach(Control controlcito in control.Controls)
                        {
                            if(controlcito is ComboBox)
                            {
                                controlcito.Text = "Seleccione Item a eliminar";
                            }
                        }
                    }

                    if(control.Name == "panelFactura")
                    {
                        foreach (Control controlcito in control.Controls)
                        {
                            if (controlcito is ComboBox)
                            {
                                if (controlcito.Name == "cmbBuscarCliente")
                                {
                                    controlcito.Text = "Elija la cuenta del cliente";
                                    controlcito.Visible = false;
                                }

                                else
                                {
                                    controlcito.Text = "Filtro de busqueda";
                                }

                            }                            
                           
                        }

                    }


                }

           }


       }

    }
}
