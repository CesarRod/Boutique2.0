using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Windows;

namespace Bases
{
   
    public class Conexion
    {
        NpgsqlConnection conection;
        public Conexion()
        {
            string parametrosConexion = "Server=192.168.0.16; User Id=user1;Password=123; Database=boutique; ";
            //string parametrosConexion = "Server=localhost; User Id=postgres;Password=hola; Database=Boutique; ";
            conection = new NpgsqlConnection(parametrosConexion);
            try
            {
                conection.Open();
            }catch(Exception e)
            {
                MessageBox.Show("ERROR","Error en la conexion");
            }
            
            
            
        }
        public DataTable QueryTable(string query)
        {
            DataTable resultados = new DataTable();
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(query, conection);
                dataAdapter.Fill(resultados);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Error");
            }
            
            return resultados;

        }
        public NpgsqlDataReader Query(string query)
        {
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(query, conection);
                NpgsqlDataReader dataReader = command.ExecuteReader();
               
                return dataReader;
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                throw;
            }         
        }
        public void CloseConection()
        {
            conection.Close();
        }
    }
       
}
