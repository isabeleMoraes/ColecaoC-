using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace Colecao.dao
{
    class Conection
    {
        SqlConnection con;

        public Conection()
        {
            con = new SqlConnection("Server = BABY; Database = Colecao; User ID = root; Password = 123");
        }


        //Inserir - Alterar - Excluir
        public void manipularDados(String comando)
        {

            try
            {
                SqlCommand cmd = new SqlCommand(comando, con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Erro " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        //Consultar
        public DataTable colsultarDados(String comando)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(comando, con);
                con.Open();

                // define o tipo de comando 
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //preenche o dataTable com o dataAdapter
                adapter.Fill(dataTable);

                con.Close();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Erro " + e.Message);
            }


            return dataTable;
        }
    }
}
