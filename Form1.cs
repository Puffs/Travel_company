using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlTypes;
    
namespace TurAgent
{
    public partial class Form1 : Form
    {

        public Form1()
        {          
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormStatus status = FormStatus.Close;

            do
            {
                Form3 Three = new Form3();
                Three.ShowDialog();
                status = Three.Status;
            }
            while (status != FormStatus.Close);
            
        }

        private void btnAddClinet_Click(object sender, EventArgs e)
        {
            Form2 Second = new Form2();
            Second.ShowDialog();
        }
    }
}