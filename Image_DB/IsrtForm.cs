using MySqlConnector;
using System;
using System.Collections;
using System.Windows.Forms;

namespace Image_DB
{
    public partial class IsrtForm : Form
    {
        string userID;
        byte[,] imgFILE;
        int imgHEIGHT, imgWIDTH;
        public IsrtForm(string para, byte[,] IMAGE, int ROW, int COL)
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
        private void IsrtForm_Load(object sender, EventArgs e)
        {
            cnn = new MySqlConnection(cnnSTR);
            cnn.Open();
            cmd = new MySqlCommand("", cnn);
            tbID.Text = userID;
        }
        private void IsrtForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cnn.Close();
            MessageBox.Show("Insert Closed");
        }
        private void btnCON_Click(object sender, EventArgs e)
        {
            imgFNAME = tbFNAME.Text.ToString();
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
            // INSERT INTO imgTBL VALUES('gens0310', 'ASD.raw', 'Unknown', '2022-8-20', 'NICK', 128, 128, 128000, 127, 128, 0, 255, 00101010);
            sql = "INSERT INTO imgTBL(userID, imgFNAME, imgTOPIC, imgDATE, imgCREATOR, ";
            sql += "imgCOL, imgROW, imgBYTE, imgMIN, imgMAX, imgMEAN, imgMIDDLE, imgDATA) VALUES('";
            sql += userID + "', '";
            sql += imgFNAME + "', '";
            sql += imgTOPIC + "', '";
            sql += imgDATE + "', '";
            sql += imgCREATOR + "', ";
            sql += imgCOL + ", ";
            sql += imgROW + ", ";
            sql += imgBYTE + ", ";
            sql += imgMIN + ", ";
            sql += imgMAX + ", ";
            sql += imgMEAN + ", ";
            sql += imgMIDDLE + ", ";
            sql += "@BLOB);";
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