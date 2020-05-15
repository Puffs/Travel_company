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
    
    public partial class Form3 : Form
    {
        public FormStatus Status { private set; get; }

        public Form3()
        {
            
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            cmbClient.DisplayMember = "Name";
            cmbClient.ValueMember = "Id";
            foreach (Client client in GetClients())
            {
                cmbClient.Items.Add(client);
            }

            cmbCountry.DisplayMember = "Name";
            cmbCountry.ValueMember = "Id";
            foreach (Country country in GetCountries())
            {
                cmbCountry.Items.Add(country);
            }
            
            List<Duration> durtionList = getDurations();
            foreach (Duration duration in durtionList)
            {
                cmbDuration.Items.Add(duration.daysCount);
            }


        }

        private List<Country> GetCountries()
        {
            List<Country> result = new List<Country>();

            String query = "select a.id, a.name, b.name as climate from Countries a, climates b where a.id_climate = b.id";
            SqlCommand queryCommand = new SqlCommand(query, ConnectionsManager.getConnection());
            using (SqlDataReader reader = queryCommand.ExecuteReader()) {
                while (reader.Read())
                {
                    Country newCountry = new Country();

                    newCountry.id = Int32.Parse(reader["id"].ToString());
                    newCountry.name = reader["name"].ToString().Trim();
                    newCountry.climate = reader["climate"].ToString().Trim();

                    result.Add(newCountry);
                }
            }

            return result;
        }

        private List<Client> GetClients()
        {
            List<Client> result = new List<Client>();

            String query = "select id, Name + ' ' + SecondName as name from Clients";
            SqlCommand queryCommand = new SqlCommand(query, ConnectionsManager.getConnection());
            using (SqlDataReader reader = queryCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Client client = new Client();

                    client.id = Int32.Parse(reader["id"].ToString());
                    client.name = reader["name"].ToString().Trim();

                    result.Add(client);
                }
            }

            return result;
        }

        private List<Duration> getDurations()
        {

            List<Duration> durations = new List<Duration>();
            
            string query = "select * from Tur_Agenstvo.dbo.Time;";
            SqlCommand queryCommand = new SqlCommand(query, ConnectionsManager.getConnection());
            using (SqlDataReader reader = queryCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Duration newDuration = new Duration();

                    newDuration.daysCount = Convert.ToInt32(reader["Duration"].ToString());
                    durations.Add(newDuration);
                }

            }

            return durations;
            
        }

        private List<Hotel> GetHotels(int countryId)
        {

            List<Hotel> hotels = new List<Hotel>();


            string query = ("select id, name, price from Hotels where id_country = @id_country");
            
            SqlCommand queryCommand = new SqlCommand(query, ConnectionsManager.getConnection());
            
            queryCommand.Parameters.AddWithValue("@id_country", SqlDbType.Int);
            queryCommand.Parameters["@id_country"].Value = countryId;

            using (SqlDataReader reader = queryCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Hotel newHotel = new Hotel();

                    newHotel.id = Int32.Parse(reader["id"].ToString());
                    newHotel.name = reader["name"].ToString().Trim();
                    newHotel.price = Int32.Parse(reader["price"].ToString());

                    hotels.Add(newHotel);
                }

            }
            return hotels;

        }

        private void cmbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (validateCmbCountry(sender))
            {
                ComboBox cmb = (ComboBox)sender;
                Country selectedCountry = (Country)cmb.SelectedItem;

                displayClimate(selectedCountry.climate);
                displayHotels(selectedCountry.id);

                return;
            }
            else
            {
                hideClimate();
            }
        }

        private Boolean validateCmbCountry(object sender)
        {
            if (sender is ComboBox)
            {
                ComboBox cmb = (ComboBox)sender;
                if (cmb.SelectedItem != null)
                {
                    if (cmb.SelectedItem is Country)
                        return true;
                }
            }

            return false;
        }

        private void hideClimate()
        {
            label4.Visible = false;
        }

        private void displayClimate(String climateName)
        {
            label4.Visible = true;
            label4.Text = climateName;
        }

        private void displayHotels(int countryId)
        {
            List<Hotel> hotels = GetHotels(countryId);

            cmbHotel.Items.Clear();
            cmbHotel.SelectedIndex = -1;
            cmbHotel.ResetText();
            cmbHotel.DisplayMember = "Name";
            cmbHotel.ValueMember = "Id";
            foreach (Hotel country in hotels)
            {
                cmbHotel.Items.Add(country);
            }
            hidePrice();
        } 


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        

        private void label8_Click(object sender, EventArgs e)
        {
            if (cmbCountry.SelectedIndex > -1 && cmbHotel.SelectedIndex > -1 && cmbDuration.SelectedIndex > -1)
                label8.Visible = true;
            else
                label8.Visible = false;
        }

        private void btnSaveTicket_Click(object sender, EventArgs e)
        {
            if (saveTicket()) { 
                Status = FormStatus.Close;
                Close();
            }
        }

        private Boolean saveTicket()
        {
            // если всё выбрано
            if (cmbClient.SelectedItem != null && cmbCountry.SelectedItem != null && cmbHotel.SelectedItem != null && cmbDuration.SelectedItem != null)
            {
                Country selectedCountry = (Country)cmbCountry.SelectedItem;
                Hotel hotel = (Hotel)cmbHotel.SelectedItem;
                int duration = (Int32)cmbDuration.SelectedItem;
                Client client = (Client)cmbClient.SelectedItem;

                String insertQuery = "INSERT INTO Tickets (Country_id, Duration, Hotel_id, Price,  Client_id) " +
                    "VALUES(@Country_id, @Duration, @Hotel_id, @Price, @Client_id)";


                SqlCommand command = new SqlCommand(insertQuery, ConnectionsManager.getConnection());

                command.Parameters.AddWithValue("@Country_id", SqlDbType.Int);
                command.Parameters["@Country_id"].Value = selectedCountry.id;

                command.Parameters.AddWithValue("@Duration", SqlDbType.Int);
                command.Parameters["@Duration"].Value = duration;

                command.Parameters.AddWithValue("@Hotel_id", SqlDbType.Int);
                command.Parameters["@Hotel_id"].Value = hotel.id;

                command.Parameters.AddWithValue("@Price", SqlDbType.Int);
                command.Parameters["@Price"].Value = getPrice();

                command.Parameters.AddWithValue("@Client_id", SqlDbType.Int);
                command.Parameters["@Client_id"].Value = client.id;

                command.ExecuteNonQuery();

                return true;
            }

            return false;
        }

        private void btnAddTickt_Click(object sender, EventArgs e)
        {
            if (saveTicket())
            {
                
                Status = FormStatus.Reopen;
                Close();
                

            }
        }

        private void checkPrice()
        {
            // если выбран отель и период
            if (validatePrice())
            {
                // вывод стоимости
                displayPrice(getPrice());
            }
            else
            {
                // иначе скрыть цену
                hidePrice();
            }
        }

        private int getPrice()
        {
            if (validatePrice())
            {
                Hotel hotel = (Hotel)cmbHotel.SelectedItem;
                int daysCount = (Int32)cmbDuration.SelectedItem;       
                    return hotel.price * daysCount;

            }
            return -1;
        }

        private void hidePrice()
        {
            label8.Visible = false;
        }

        private void displayPrice(int price)
        {
            label8.Visible = true;

            label8.Text = price.ToString();
        }

        private Boolean validatePrice()
        {
            return cmbHotel.SelectedItem != null && cmbDuration.SelectedItem != null;
        }

        private void cmbDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkPrice();
        }

        private void cmbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkPrice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
