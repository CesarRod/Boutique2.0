﻿using System;
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
    /// Interaction logic for proveedoresBaja.xaml
    /// </summary>
    public partial class proveedoresBaja : Window
    {
        Conexion con;
       
        public proveedoresBaja()
        {            
            InitializeComponent();
            con = new Conexion();
            //lista.RecordContextMenu = new ContextMenu();
            //lista.RecordContextMenu.Items.Add(new MenuItem { Header = "Eliminar alv" });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lista.ItemsSource = con.QueryTable("SELECT * FROM proveedor WHERE nombre ilike '%" + nombre.Text + "%'").DefaultView;
            lista.Columns[0].Visibility = Visibility.Collapsed;
        }
        private void borrar(object sender, RoutedEventArgs e )
        {
            var selectedItem = (DataRowView) lista.SelectedItem;
            var idToErase = selectedItem["id_proveedor"].ToString();
            
            try
            {
                var result = MessageBox.Show("¿Seguro que desea eliminar este proveedor?", "Warning", MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                {
                    con.Query("DELETE FROM proveedor WHERE id_proveedor=" + idToErase);
                    MessageBox.Show("Proveedor eliminado correctamente", "Exito");

                    this.Close();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

       
    }
}
