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

    public partial class Form2 : Form 
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

        private void Next_Click(object sender, EventArgs e)
        {
            String insertQuery = "INSERT INTO [dbo].[Clients] ([Name], [SecondName], [ThirdName], [Address], [Phone]) " +
                "VALUES (@Name, @SecondName, @ThirdName, @Address, @Phone)";


            SqlCommand command = new SqlCommand(insertQuery, ConnectionsManager.getConnection());

            command.Parameters.AddWithValue("@Name", SqlDbType.NVarChar);
            command.Parameters["@Name"].Value = tbName.Text;

            command.Parameters.AddWithValue("@SecondName", SqlDbType.NVarChar);
            command.Parameters["@SecondName"].Value = tbSecondName.Text;

            command.Parameters.AddWithValue("@ThirdName", SqlDbType.NVarChar);
            command.Parameters["@ThirdName"].Value = tbThirdName.Text;

            command.Parameters.AddWithValue("@Address", SqlDbType.NVarChar);
            command.Parameters["@Address"].Value = tbAddress.Text;

            command.Parameters.AddWithValue("@Phone", SqlDbType.NVarChar);
            command.Parameters["@Phone"].Value = tbPhone.Text;

            command.ExecuteNonQuery();

            Close();

        }

        private void textBoxes_TextChanged(object sender, EventArgs e)
        {
            Next.Enabled = isFormValid();
        }

        private Boolean isFormValid()
        {
            return tbSecondName.Text != "" && tbName.Text != "" && tbAddress.Text != "" && tbPhone.Text != "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}