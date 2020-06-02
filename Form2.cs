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
        string[] BilValues = new string[13];
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

        private void HämtaData_Click(object sender, EventArgs e)
        {
            MySqlConnection connection;

            string connectionstring = "SERVER=Localhost;DATABASE=bilhyr;" +
               "UID=KurtKurtsson;PASSWORD=ljuset;";




            textBox1.Clear();
            BilProperties.Clear();
            SeleBil = listBox1.GetItemText(listBox1.SelectedItem);
            connection = new MySqlConnection(connectionstring);
            connection.Open();
            MySqlDataReader dataReader = null;
            string sqlsats = "SELECT * FROM kunder WHERE Namn = " + "\"" + SeleBil + "\"";
            MySqlCommand cmd = new MySqlCommand(sqlsats, connection);
            dataReader = cmd.ExecuteReader();
            dataReader.Read();
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                BilProperties.Add(dataReader.GetName(i));
            }
            foreach (string str in BilProperties)
            {
                textBox1.AppendText(Environment.NewLine + dataReader[str].ToString());
            }

            connection.Close();
        }

        private void Change_Click(object sender, EventArgs e)
        {
            for (int i = 2; i < BilValues.Length; i++)
            {
                BilValues[i] = textBox1.Lines[i];
            }
            string valuesDisplay = string.Join(Environment.NewLine, BilValues);
            MessageBox.Show("Företagets värden har justerats till " + valuesDisplay);
            connection = new MySqlConnection(connectionstring);
            connection.Open();
            MySqlDataReader dataReader = null;
            string sqlsats = "UPDATE kunder SET Namn = \"" + BilValues[3] + "\", Nummer? = \"" +
                BilValues[4] + "\", Telefon = \"" + BilValues[5] + "\", Address = \"" +
                BilValues[6] + "\", Stad = \"" + BilValues[7] + "\", Region = \"" +
                BilValues[8] + "\", Land = \"" +  "\" WHERE Namn = \"" + SeleBil + "\"";
            textBox1.Text = sqlsats;
            MySqlCommand cmd = new MySqlCommand(sqlsats, connection);
            dataReader = cmd.ExecuteReader();
            connection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
