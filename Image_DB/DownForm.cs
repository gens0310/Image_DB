using MySqlConnector;
using System;
using System.IO;
using System.Windows.Forms;

namespace Image_DB
{
    public partial class DownForm : Form
    {
        string userID;
        public DownForm(string para)
        {
            InitializeComponent();
            userID = para;
        }
        string cnnSTR = "Server=192.168.56.101;Uid=nickUSER;Pwd=1234;Database=imgDB;Charset=UTF8";
        // string cnnSTR = "Server=127.0.0.1;Uid=nickUSER;Pwd=1234;Database=imgDB;Charset=UTF8";
        MySqlConnection cnn;
        MySqlCommand cmd;
        string sql, imgFNAME, imgTOPIC, imgDATE, imgCREATOR, imgCOL, imgROW, imgBYTE;
        private void DownForm_Load(object sender, EventArgs e)
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
        private void DownForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cnn.Close();
            MessageBox.Show("Download Closed");
        }
        private void btnCON_Click(object sender, EventArgs e)
        {
            cnn = new MySqlConnection(cnnSTR);
            cnn.Open();
            cmd = new MySqlCommand("", cnn);
            tbID.Text = userID;
            byte[] imgDATA;
            string FILENAME;
            FileStream FILESTREAM;
            imgFNAME = tbFNAME.Text.ToString();
            // SELECT imgDATA FROM imgTBL WHERE userID = 'gens0310' AND imgFNAME = 'GGG';
            sql = "SELECT imgCOL, imgROW, imgBYTE, imgDATA FROM imgTBL WHERE ";
            sql += "userID = '" + userID + "' AND ";
            sql += "imgFNAME = '" + imgFNAME + "';";
            cmd.CommandText = sql;
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            imgCOL = reader["imgCOL"].ToString();
            imgROW = reader["imgROW"].ToString();
            imgBYTE = reader["imgBYTE"].ToString();
            imgDATA = new byte[int.Parse(imgBYTE)];
            reader.GetBytes(reader.GetOrdinal("imgDATA"), 0, imgDATA, 0, int.Parse(imgBYTE));
            FILENAME = Directory.GetCurrentDirectory() + "/newfile.raw";
            FILESTREAM = new FileStream(FILENAME, FileMode.OpenOrCreate, FileAccess.Write);
            FILESTREAM.Write(imgDATA, 0, int.Parse(imgBYTE));
            FILESTREAM.Close();
            reader.Close();
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.DefaultExt = "raw";
            SFD.Filter = "로우 이미지 | *.raw";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                string SAVEFNAME = SFD.FileName;
                BinaryWriter BW = new BinaryWriter(File.Open(SAVEFNAME, FileMode.Create));
                byte[,] IMAGE = new byte[int.Parse(imgROW), int.Parse(imgCOL)];
                int tmp = 0;
                for (int i = 0; i < int.Parse(imgROW); i++)
                {
                    for (int j = 0; j < int.Parse(imgCOL); j++)
                        IMAGE[i, j] = imgDATA[j + tmp];
                    tmp += int.Parse(imgROW);
                }
                for (int i = 0; i < int.Parse(imgROW); i++)
                    for (int j = 0; j < int.Parse(imgCOL); j++)
                        BW.Write(IMAGE[i, j]);
                BW.Close();
            }
            tbID.Clear();
            tbFNAME.Clear();
            listView1.Clear();
        }
    }
}