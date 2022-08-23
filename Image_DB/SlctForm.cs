using MySqlConnector;
using System;
using System.Windows.Forms;

namespace Image_DB
{
    public partial class SlctForm : Form
    {
        string userID;
        public SlctForm(string para)
        {
            InitializeComponent();
            userID = para;
        }
        string cnnSTR = "Server=192.168.56.101;Uid=nickUSER;Pwd=1234;Database=imgDB;Charset=UTF8";
        // string cnnSTR = "Server=127.0.0.1;Uid=nickUSER;Pwd=1234;Database=imgDB;Charset=UTF8";
        MySqlConnection cnn;
        MySqlCommand cmd;
        string sql;
        private void SlctForm_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            cnn = new MySqlConnection(cnnSTR);
            cnn.Open();
            cmd = new MySqlCommand("", cnn);
            sql = "SELECT userID, imgFNAME, imgTOPIC, imgDATE, imgCREATOR, imgCOL, imgROW, ";
            sql += "imgBYTE, imgMIN, imgMAX, imgMEAN, imgMIDDLE, imgDATA FROM imgTBL WHERE userID = '";
            sql += userID + "';";
            cmd.CommandText = sql;
            MySqlDataReader reader = cmd.ExecuteReader();
            listView1.View = View.Details;
            listView1.Columns.Add("ID");
            listView1.Columns.Add("FILE NAME");
            listView1.Columns.Add("IMAGE TOPIC");
            listView1.Columns.Add("MAKE DATE");
            listView1.Columns.Add("CREATOR");
            listView1.Columns.Add("IMAGE COLUMN");
            listView1.Columns.Add("IMAGE ROW");
            listView1.Columns.Add("FILE BYTE");
            listView1.Columns.Add("MIN PIXEL VALUE");
            listView1.Columns.Add("MAX PIXEL VALUE");
            listView1.Columns.Add("MEAN PIXEL VALUE");
            listView1.Columns.Add("MIDDLE PIXEL VALUE");
            listView1.Columns.Add("BLOB FILE");
            ListViewItem item;
            string imgFNAME, imgTOPIC, imgDATE, imgCREATOR, imgCOL, imgROW, imgBYTE, imgMIN, imgMAX, imgMEAN, imgMIDDLE, imgDATA;
            while (reader.Read())
            {
                imgFNAME = (string)reader["imgFNAME"];
                imgTOPIC = (string)reader["imgTOPIC"];
                imgDATE = reader["imgDATE"].ToString();
                imgCREATOR = (string)reader["imgCREATOR"];
                imgCOL = reader["imgCOL"].ToString();
                imgROW = reader["imgROW"].ToString();
                imgBYTE = reader["imgBYTE"].ToString();
                imgMIN = reader["imgMIN"].ToString();
                imgMAX = reader["imgMAX"].ToString();
                imgMEAN = reader["imgMEAN"].ToString();
                imgMIDDLE = reader["imgMIDDLE"].ToString();
                imgDATA = reader["imgDATA"].ToString();
                item = new ListViewItem(userID);
                item.SubItems.Add(imgFNAME);
                item.SubItems.Add(imgTOPIC);
                item.SubItems.Add(imgDATE);
                item.SubItems.Add(imgCREATOR);
                item.SubItems.Add(imgCOL);
                item.SubItems.Add(imgROW);
                item.SubItems.Add(imgBYTE);
                item.SubItems.Add(imgMIN);
                item.SubItems.Add(imgMAX);
                item.SubItems.Add(imgMEAN);
                item.SubItems.Add(imgMIDDLE);
                item.SubItems.Add(imgDATA);
                listView1.Items.Add(item);
            }
            reader.Close();
        }
        private void SlctForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cnn.Close();
            MessageBox.Show("Select Closed");
        }
    }
}