using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace IQ_Test
{
    public partial class Test : Form
    {
        string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;
        Data Source = DataBase1.mdb";

        public Test()
        {
            InitializeComponent();

            jaylastir();


            // this.WindowState= FormWindowState.Maximized;
        }
        int sani = 0, id = 0;
        string juwap = "";
        Random randX=new Random();
        void jaylastir()
        {
            id = randX.Next(0, sani);

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Task1;", conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    sani = ds.Tables[0].Rows.Count;
                    answer.Text = ds.Tables[0].Rows[id]["soraw"].ToString();
                    btnA.Text = ds.Tables[0].Rows[id]["aa"].ToString();
                    btn_B.Text = ds.Tables[0].Rows[id]["bb"].ToString();
                    btn_C.Text = ds.Tables[0].Rows[id]["cc"].ToString();
                    btn_D.Text = ds.Tables[0].Rows[id]["dd"].ToString();
                    juwap= ds.Tables[0].Rows[id]["jj"].ToString();

                }
            }
          
        }
        void tekser(Guna2Button btn)
        {
            if (btn.Name == "btnA" && juwap == "1")
            {
                jaylastir();
            }
            else if (btn.Name == "btn_B" && juwap == "2")
            {
                jaylastir();
            }
            else if (btn.Name == "btn_C" && juwap == "3")
            {
                jaylastir();
            }
            else if (btn.Name == "btn_D" && juwap == "4")
            {
                jaylastir();
            }
        }
        private void Test_Load(object sender, EventArgs e)
        {

        }

        private void btnA_Click(object sender, EventArgs e)
        {
            tekser(btnA);
        }

        private void btn_B_Click(object sender, EventArgs e)
        {
            tekser(btn_B);
        }

        private void btn_C_Click(object sender, EventArgs e)
        {
            tekser(btn_C);
        }

        private void btn_D_Click(object sender, EventArgs e)
        {
            tekser(btn_D);
        }

        private void answer_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Task1;", conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    sani = ds.Tables[0].Rows.Count;
                    id = randX.Next(0, sani);
                    jaylastir();

                }
            }
        }
    }
}
