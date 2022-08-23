using MySqlConnector;
using System;
using System.Collections;
using System.Windows.Forms;

namespace Image_DB
{
    public partial class UpdtForm : Form
    {
        string userID;
        byte[,] imgFILE;
        int imgHEIGHT, imgWIDTH;
        public UpdtForm(string para, byte[,] IMAGE, int ROW, int COL)
        {
            InitializeComponent();
            userID = para;
            imgFILE = IMAGE;
            imgHEIGHT = ROW;
            imgWIDTH = COL;
        }
        string cnnSTR = "Server=192.168.56.101;Uid=nickUSER;Pwd=1234;Database=imgDB;Charset=UTF8";
        // string cnnSTR = "Server=127.0.0.1;Uid=nickUSER;Pwd=1234;Database=imgDB;Charset=UTF8";
        MySqlConnection cnn;
        MySqlCommand cmd;
        string sql, imgFNAME, imgTOPIC, imgDATE, imgCREATOR, imgCOL, imgROW, imgBYTE, imgMIN, imgMAX, imgMEAN, imgMIDDLE;
        private void UpdtForm_Load(object sender, EventArgs e)
        {
            cnn = new MySqlConnection(cnnSTR);
            cnn.Open();
            cmd = new MySqlCommand("", cnn);
            tbID.Text = userID;
        }
        private void UpdtForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cnn.Close();
            MessageBox.Show("Update Closed");
        }
        private void btnSLCT_Click(object sender, EventArgs e)
        {
            imgFNAME = tbFNAME.Text;
            sql = "SELECT * FROM imgTBL WHERE userID = '";
            sql += userID + "' AND ";
            sql += "imgFNAME = '" + imgFNAME + "';";
            cmd.CommandText = sql;
            MySqlDataReader reader = cmd.ExecuteReader();
            imgTOPIC = imgCREATOR = "NULL";
            while (reader.Read())
            {
                imgTOPIC = (string)reader["imgTOPIC"];
                imgCREATOR = (string)reader["imgCREATOR"];
            }
            tbID.Text = userID;
            tbFNAME.Text = imgFNAME;
            tbTOPIC.Text = imgTOPIC;
            tbCRTR.Text = imgCREATOR;
            reader.Close();
        }
        private void btnCON_Click(object sender, EventArgs e)
        {
            imgTOPIC = tbTOPIC.Text.ToString();
            imgCREATOR = tbCRTR.Text.ToString();
            // imgDATE
            var toDay = DateTime.Now;
            imgDATE = toDay.Date.ToString("yyyy-M-d");
            // imgCOL
            imgCOL = imgWIDTH.ToString();
            // imgROW
            imgROW = imgHEIGHT.ToString();
            // imgBYTE, imgMIN, imgMAX, imgMEAN, imgMIDDLE
            ArrayList imgList = new ArrayList();
            int pxlSUM = 0;
            for (int i = 0; i < imgHEIGHT; i++)
                for (int j = 0; j < imgWIDTH; j++)
                {
                    pxlSUM += imgFILE[i, j];
                    imgList.Add(imgFILE[i, j]);
                }
            imgList.Sort();
            imgBYTE = (imgHEIGHT * imgWIDTH).ToString();
            imgMIN = imgList[0].ToString();
            imgMAX = imgList[imgList.Count - 1].ToString();
            imgMEAN = (pxlSUM / (imgHEIGHT * imgWIDTH)).ToString();
            imgMIDDLE = imgList[imgList.Count / 2].ToString();
            // imgDATA
            byte[] imgDATA = new byte[imgHEIGHT * imgWIDTH];
            for (int i = 0; i < imgHEIGHT; i++)
                for (int j = 0; j < imgWIDTH; j++)
                    imgDATA[i * imgHEIGHT + j] = imgFILE[i, j];
            // UPDATE imgTBL SET
            // imgTOPIC = 'LENNA',
            // imgDATE = '2022-8-19',
            // imgCREATOR = 'NICK89',
            // imgCOL = 256,
            // imgROW = 256,
            // imgBYTE = 1,
            // imgMEAN = 5,
            // imgMIDDLE = 10,
            // imgMIN = 1,
            // imgMAX = 255,
            // imgDATA = 0000
            // WHERE imgFNAME = 'BSD';
            sql = "UPDATE imgTBL SET ";
            sql += "imgTOPIC = '" + imgTOPIC + "', ";
            sql += "imgDATE = '" + imgDATE + "', ";
            sql += "imgCREATOR = '" + imgCREATOR + "', ";
            sql += "imgCOL = " + imgCOL + ", ";
            sql += "imgROW = " + imgROW + ", ";
            sql += "imgBYTE = " + imgBYTE + ", ";
            sql += "imgMEAN = " + imgMEAN + ", ";
            sql += "imgMIDDLE = " + imgMIDDLE + ", ";
            sql += "imgMIN = " + imgMIN + ", ";
            sql += "imgMAX = " + imgMAX + ", ";
            sql += "imgDATA = @BLOB ";
            sql += "WHERE imgFNAME = '" + imgFNAME + "';";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@BLOB", imgDATA);
            cmd.ExecuteNonQuery();
            tbID.Clear();
            tbFNAME.Clear();
            tbTOPIC.Clear();
            tbCRTR.Clear();
        }
    }
}