using MySqlConnector;
using System;
using System.Windows.Forms;

namespace Image_DB
{
    public partial class DelForm : Form
    {
        string userID;
        public DelForm(string para)
        {
            InitializeComponent();
            userID = para;
        }
        string cnnSTR = "Server=192.168.56.101;Uid=nickUSER;Pwd=1234;Database=imgDB;Charset=UTF8";
        // string cnnSTR = "Server=127.0.0.1;Uid=nickUSER;Pwd=1234;Database=imgDB;Charset=UTF8";
        MySqlConnection cnn;
        MySqlCommand cmd;
        string sql, imgFNAME;
        private void DelForm_Load(object sender, EventArgs e)
        {
            cnn = new MySqlConnection(cnnSTR);
            cnn.Open();
            cmd = new MySqlCommand("", cnn);
            tbID.Text = userID;
            sql = "SELECT imgFNAME, imgTOPIC, imgDATE, imgCREATOR FROM imgTBL WHERE userID = '";
            sql += userID + "';";
            cmd.CommandText = sql;
            MySqlDataReader reader = cmd.ExecuteReader();
            listView1.View = View.Details;
            listView1.Columns.Add("ID");
            listView1.Columns.Add("FILE NAME");
            listView1.Columns.Add("IMAGE TOPIC");
            listView1.Columns.Add("MAKE DATE");
            listView1.Columns.Add("CREATOR");
            ListViewItem item;
            string imgTOPIC, imgDATE, imgCREATOR;
            while (reader.Read())
            {
                imgFNAME = (string)reader["imgFNAME"];
                imgTOPIC = (string)reader["imgTOPIC"];
                imgDATE = reader["imgDATE"].ToString();
                imgCREATOR = (string)reader["imgCREATOR"];
                item = new ListViewItem(userID);
                item.SubItems.Add(imgFNAME);
                item.SubItems.Add(imgTOPIC);
                item.SubItems.Add(imgDATE);
                item.SubItems.Add(imgCREATOR);
                listView1.Items.Add(item);
            }
            reader.Close();
        }
        private void DelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cnn.Close();
            MessageBox.Show("Delete Closed");
        }
        private void btnCON_Click(object sender, EventArgs e)
        {
            imgFNAME = tbFNAME.Text.ToString();
            sql = "DELETE FROM imgTBL WHERE imgFNAME = '" + imgFNAME + "'";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            tbID.Clear();
            tbFNAME.Clear();
            listView1.Clear();
        }
    }
}