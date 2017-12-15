using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for preferences.xaml
    /// </summary>
    public partial class preferences : Window
    {
        Conexion con;
        string idClient = "";
        public preferences()
        {
            InitializeComponent();
            con = new Conexion();
            List<string> tallas = new List<string>();
            tallas.Add("XS");
            tallas.Add("S");
            tallas.Add("M");
            tallas.Add("L");
            tallas.Add("XL");
            tallas.Add("XXL");
            tallas.Add("Porn Size");

            talla.CustomSource = tallas;
            talla.IsEnabled = false;

            List<string> tipos = new List<string>();
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

            tipoPrenda.CustomSource = tipos;
            tipoPrenda.IsEnabled = false;
            descripcion.IsEnabled = false;
        }

        private  void busqueda( object sender, RoutedEventArgs e)
        {
            lista.ItemsSource = con.QueryTable("SELECT * FROM cliente WHERE nombre ilike '%" + nombre.Text + "%'").DefaultView;
            lista.Columns[0].Visibility = Visibility.Collapsed;
        }
        private void seleccionarFunc (object sender, RoutedEventArgs e)
        {
            var selectedItem = (DataRowView) lista.SelectedItem;
            idClient = selectedItem["id_cliente"].ToString();
            tipoPrenda.IsEnabled = true;
            descripcion.IsEnabled = true;
            talla.IsEnabled = true;
            MessageBox.Show("Seleccionado correctamente");

        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();
        }
        private void agregarPreferencia (object sender, RoutedEventArgs e)
        {
            string idPref = "";
            int idPrefOp;
            string query = $"SELECT MAX(id_preferencia) FROM  preferencia WHERE id_cliente={idClient}";
            try
            {
                NpgsqlDataReader dataReader = con.Query(query);
                while (dataReader.Read())
                {
                    idPref = dataReader[0].ToString();
                }
                dataReader.Close();
                if (idPref != null)
                {
                    int.TryParse(idPref, out idPrefOp);
                    idPrefOp++;
                }
                else
                {
                    idPrefOp = 1;
                }
                query = $"INSERT INTO preferencia(id_preferencia,id_cliente,talla,descripcion,tipo_prenda) " +
                    $" VALUES({idPrefOp},{idClient},'{talla.Text}','{descripcion.Text}','{tipoPrenda.Text}')";
                con.Query(query);
                MessageBox.Show("Se ha insertado preferencia correctamente");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
