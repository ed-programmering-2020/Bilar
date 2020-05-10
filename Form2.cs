using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BilHyr
{
    public partial class Form2 : Form
    {
        MySqlConnection connection;

        string SeleBil = null;
        List<string> BilProperties = new List<string>();
        string connectionstring = "SERVER=Localhost;DATABASE=bilhyr;" +
            "UID=KurtKurtsson;PASSWORD=ljuset;";


        public Form2()
        {
            InitializeComponent();


            List<string> Namn = new List<string>();

            connection = new MySqlConnection(connectionstring);
            connection.Open();

            MySqlDataReader dataReader = null;
            string sqlsats = "Select ID,Namn from kunder";

            MySqlCommand cmd = new MySqlCommand(sqlsats, connection);

            dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                listBox1.Items.Add(dataReader["Namn"].ToString());

            }



            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 server = new Form2();
            server.Close();
        }
    }
}
