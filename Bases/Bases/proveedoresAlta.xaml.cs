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
using Npgsql;

namespace Bases
{
    /// <summary>
    /// Interaction logic for proveedoresAlta.xaml
    /// </summary>
    public partial class proveedoresAlta : Window
    {
        Conexion conn;

        public proveedoresAlta()
        {
            InitializeComponent();
            List<String> listaEstados = new List<String>();
            listaEstados.Add("Aguascalientes");
            listaEstados.Add("Baja California");
            listaEstados.Add("Baja California Sur");
            listaEstados.Add("Campeche");
            listaEstados.Add("Chiapas");
            listaEstados.Add("Chihuahua");
            listaEstados.Add("Coahuila");
            listaEstados.Add("Colima");
            listaEstados.Add("Durango");
            listaEstados.Add("Estado de México");
            listaEstados.Add("Guanajuato");
            listaEstados.Add("Guerrero");
            listaEstados.Add("Hidalgo");
            listaEstados.Add("Jalisco");
            listaEstados.Add("Michoacan");
            listaEstados.Add("Morelos");
            listaEstados.Add("Nayarit");
            listaEstados.Add("Nuevo Leon");
            listaEstados.Add("Oaxaca");
            listaEstados.Add("Puebla");
            listaEstados.Add("Queretaro");
            listaEstados.Add("San Luis Potosi");
            listaEstados.Add("Sinaloa");
            listaEstados.Add("Sonora");
            listaEstados.Add("Tabasco");
            listaEstados.Add("Tamaulipas");
            listaEstados.Add("Tlaxcala");
            listaEstados.Add("Veracruz");
            listaEstados.Add("Yucatan");
            listaEstados.Add("Zacatecas");
            listaEstados.Add("CDMX");
            estados.CustomSource = listaEstados;

            conn = new Conexion();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            conn.CloseConection();
            this.Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            website.IsEnabled = true;
            email.IsEnabled = true;
        }
        private void CheckBox_NotChecked(object sender, RoutedEventArgs e)
        {
            website.IsEnabled = false;
            email.IsEnabled = false;
            website.Clear();
            email.Clear();
        }
        private void InsertProveedor(object sender, RoutedEventArgs e)
        {
            agregar.IsEnabled = false;
            string campos = "DEFAULT,'"+nombre.Text + "','" + telefono.Text + "','" + estados.SelectedValue + "','" +
                ciudad.Text + "','" + calle.Text + "','" + numero.Text + "','" + colonia.Text+"','"+codigoPostal.Text+ "'";
            string query = "INSERT INTO proveedor(id_proveedor,nombre,telefono,estado,ciudad,calle,numero,colonia,cp) values(" + campos + ");";

            try
            {
                conn.Query(query).Close();               
                if (porPedido.IsChecked.Value)
                {
                    string camposPedido = email.Text + "','" + website.Text;
                    string maxId = "";
                    string queryPedido = ""; 
                    NpgsqlDataReader dataReader = conn.Query("SELECT MAX(id_proveedor) from proveedor");
                    while (dataReader.Read())
                    {
                        maxId = dataReader[0].ToString(); 
                    }
                    dataReader.Close();
                    queryPedido= "INSERT INTO proveedor_por_pedido(id_proveedor,email,pagina_web) values('" + maxId + "','" + camposPedido + "');";
                    conn.Query(queryPedido).Close();
                }
                MessageBox.Show("Proveedor agregado correctamente", "Exito!");
                nombre.Clear();
                telefono.Clear();
                ciudad.Clear();
                calle.Clear();
                numero.Clear();
                colonia.Clear();
                codigoPostal.Clear();
                email.Clear();
                website.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
            finally
            {
                agregar.IsEnabled = true;
            }
          
        }    
    }
}
