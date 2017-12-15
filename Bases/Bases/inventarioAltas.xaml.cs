using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bases
{
    /// <summary>
    /// Interaction logic for inventario.xaml
    /// </summary>
    public partial class Inventario : Window
    {
        Conexion con;
        string modeloIn = "";
        public Inventario(string modeloIn="")
        {
            this.modeloIn = modeloIn;
            List<String> tipos = new List<String>();
            tipos.Add("Sweater");
            tipos.Add("Blusa");
            tipos.Add("Chaleco");
            tipos.Add("Vestio");
            tipos.Add("Chamarra");
            tipos.Add("Pantalon");
            tipos.Add("Short");
            tipos.Add("Falda");
            tipos.Add("Playera");
            tipos.Add("Crop top");
            tipos.Add("Conjunto");
            tipos.Add("Saco");
            tipos.Add("Leggin");
            tipos.Add("Jumpsuit");
            
            InitializeComponent();
            tipoPrenda.CustomSource = tipos;
            con = new Conexion();
            if (modeloIn != "")
            {
                string query = "SELECT * FROM articulo where modelo='" + modeloIn+"'";
                NpgsqlDataReader dataReader = con.Query(query);
                while (dataReader.Read())
                {
                    modelo.Text = dataReader[1].ToString();
                    precioVenta.Text = dataReader[2].ToString();
                    precioProv.Text = dataReader[3].ToString();
                    description.Text = dataReader[4].ToString();
                    tipoPrenda.Text = dataReader[5].ToString();

                }
                dataReader.Close();
                agregar.Content = "Guardar";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query = "";
            if(modeloIn == "")
            {
                string valores = "DEFAULT,'" + modelo.Text + "',"
               + precioVenta.Text + "," + precioProv.Text + ",'" +
               description.Text + "','" + tipoPrenda.SelectedValue + "'";
                query = "INSERT INTO articulo(id_articulo,modelo,precio_venta, precio_proveedor, descripcion,tipo_prenda)" +
                    "VALUES(" + valores + ");";
                agregar.IsEnabled = false;
            }
            else
            {
                query = "UPDATE articulo set(precio_venta, precio_proveedor, descripcion, tipo_prenda) = " +
                    "('"+precioVenta.Text+"', '"+precioProv.Text+"', '"+description.Text+"', '"+tipoPrenda.Text+"') WHERE modelo = '"+modeloIn+"';";
            }
           
            try
            {
                
                con.Query(query);
                if(modeloIn == "")
                {
                    MessageBox.Show("Articulo agregado exitosamente");
                }
                else
                {
                    MessageBox.Show("Articulo modificado exitosamente");
                    this.Close();
                }

                
                modelo.Clear();
                precioVenta.Clear();
                precioProv.Clear();
                description.Clear();
                description.Clear();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                agregar.IsEnabled = true;
            }
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();
        }
    }
}
