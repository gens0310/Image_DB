using MySqlConnector;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Image_DB
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        /* < Database Structure >
        ---------- imgDB ----------
        | userTBL    | imgTBL     |
        ---------------------------
        | userID(PK) | userID(FK) |
        | userNAME   | imgFNAME   |
        | userDEPART | imgTOPIC   |
        | userRANK   | imgDATE    |
        |            | imgCREATOR |
        |            | imgCOL     |
        |            | imgROW     |
        |            | imgBYTE    |
        |            | imgMIN     |
        |            | imgMAX     |
        |            | imgMEAN    |
        |            | imgMIDDLE  |
        |            | imgDATA    |
        --------------------------- */
        // Variable
        string FULLNAME;
        static byte[,] inIMG;
        static int inH, inW;
        Bitmap inPaper;
        string cnnSTR = "Server=192.168.56.101;Uid=nickUSER;Pwd=1234;Database=imgDB;Charset=UTF8";
        // string cnnSTR = "Server=127.0.0.1;Uid=nickUSER;Pwd=1234;Database=imgDB;Charset=UTF8";
        MySqlConnection cnn;
        MySqlCommand cmd;
        string sql;
        // Common Method
        public void openIMG()
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.DefaultExt = "raw";
            OFD.Filter = "로우 이미지 | *.raw; *.RAW";
            OFD.ShowDialog();
            FULLNAME = OFD.FileName;
            BinaryReader BR = new BinaryReader(File.Open(FULLNAME, FileMode.Open));
            long FILESIZE = new FileInfo(FULLNAME).Length;
            inH = inW = (int)Math.Sqrt(FILESIZE);
            inIMG = new byte[inH, inW];
            for (int i = 0; i < inH; i++)
                for (int j = 0; j < inW; j++)
                    inIMG[i, j] = BR.ReadByte();
            BR.Close();
            printInIMG();
        }
        public void printInIMG()
        {
            inPaper = new Bitmap(inH, inW);
            pbinIMG.Size = new Size(inH, inW);
            pbinIMG.Location = new Point(0, menuStrip1.Height);
            this.ClientSize = new Size(inH, inW + menuStrip1.Height);
            Color Pen;
            for (int i = 0; i < inH; i++)
                for (int j = 0; j < inW; j++)
                {
                    byte Ink = inIMG[i, j];
                    Pen = Color.FromArgb(Ink, Ink, Ink);
                    inPaper.SetPixel(j, i, Pen);
                }
            pbinIMG.Image = inPaper;
        }
        // Event Method
        private void mainForm_Load(object sender, EventArgs e)
        {
            cnn = new MySqlConnection(cnnSTR);
            cnn.Open();
            cmd = new MySqlCommand("", cnn);
        }
        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cnn.Close();
            MessageBox.Show("Image DB Closed");
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openIMG();
        }
        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userID;
            userID = tbID.Text.ToString();
            SlctForm slct = new SlctForm(userID);
            slct.ShowDialog();
        }
        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userID;
            userID = tbID.Text.ToString();
            IsrtForm isrt = new IsrtForm(userID, inIMG, inH, inW);
            isrt.ShowDialog();
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userID;
            userID = tbID.Text.ToString();
            UpdtForm upd = new UpdtForm(userID, inIMG, inH, inW);
            upd.ShowDialog();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userID;
            userID = tbID.Text.ToString();
            DelForm del = new DelForm(userID);
            del.ShowDialog();
        }
        private void imageDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userID;
            userID = tbID.Text.ToString();
            DownForm down = new DownForm(userID);
            down.ShowDialog();
        }
    }
}