using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega
{
    class DbCar
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=127.0.0.1;port=3306;username=root;password=;database=auto";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection!\n"+ ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }
        public static void AddCar(Car cr)
        {
            string sql = "INSERT INTO auta VALUES (NULL,@CarZnacka,@CarRok_vyroby,@CarCena,@CarVykon,@CarHistorie)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@CarZnacka", MySqlDbType.VarChar).Value = cr.Znacka;
            cmd.Parameters.Add("@CarRok_vyroby", MySqlDbType.VarChar).Value = cr.Rok_vyroby;
            cmd.Parameters.Add("@CarCena", MySqlDbType.VarChar).Value = cr.Cena;
            cmd.Parameters.Add("@CarVykon", MySqlDbType.VarChar).Value = cr.Vykon;
            cmd.Parameters.Add("@CarHistorie", MySqlDbType.VarChar).Value = cr.Historie;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Přidáno Uspěšně.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Auto není vloženo. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void UpdateCar(Car cr, string id)
        {
            string sql = "UPDATE auta SET Znacka = @CarZnacka,Rok_vyroby = @CarRok_vyroby,Cena = @CarCena,Vykon = @CarVykon,Historie = @CarHistorie WHERE id = @Carid";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Carid", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@CarZnacka", MySqlDbType.VarChar).Value = cr.Znacka;
            cmd.Parameters.Add("@CarRok_vyroby", MySqlDbType.VarChar).Value = cr.Rok_vyroby;
            cmd.Parameters.Add("@CarCena", MySqlDbType.VarChar).Value = cr.Cena;
            cmd.Parameters.Add("@CarVykon", MySqlDbType.VarChar).Value = cr.Vykon;
            cmd.Parameters.Add("@CarHistorie", MySqlDbType.VarChar).Value = cr.Historie;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Upaveno Uspěšně.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Auto není upraveno. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }
        public static void DeleteCar(string id)
        {
            string sql = "DELETE FROM auta WHERE id = @Carid";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Carid", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vymazáno Uspěšně.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Auto není vymazano. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DisplayAndSearch(string query,DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tb1 = new DataTable();
            adp.Fill(tb1);
            dgv.DataSource = tb1;
            con.Close();

        }

        
    }
}


