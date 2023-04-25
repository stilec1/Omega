using MySql.Data.MySqlClient;
using Omega.Class;
using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Omega
{
    class DbCar
    {
        /*Metoda se používá pro připojení k databázi.
         * Čte informace o připojení z konfiguračního souboru na disku a sestavuje z nich řetězec připojení.
         * Pokud se nepodaří připojit k databázi, vyvolá se chyba.GetConnection*/
        public static MySqlConnection GetConnection()
        {
            string fileName = "config.txt";
            string directory = AppDomain.CurrentDomain.BaseDirectory; 
            string filePath = Path.Combine(directory, fileName);
            string[] lines = File.ReadAllLines(filePath);
            string sql = "";
            foreach (string line in lines)
            {
                if (line.StartsWith("datasource="))
                    sql += line.Trim() + ";";
                else if (line.StartsWith("port="))
                    sql += line.Trim() + ";";
                else if (line.StartsWith("username="))
                    sql += line.Trim() + ";";
                else if (line.StartsWith("password="))
                    sql += line.Trim() + ";";
                else if (line.StartsWith("database="))
                    sql += line.Trim() + ";";
            }
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }
            /*Metoda slouží k exportu dat z tabulek do textového souboru export.txt. 
             * Používá SQL dotaz pro načtení dat a zapíše je do souboru. */
            public static void ExportData()
        {
            string[] tableNames = { "auta", "motorky","nakladaky" };
            MySqlConnection con = GetConnection();
            using (StreamWriter sw = new StreamWriter("export.txt"))
            {
                foreach (string tableName in tableNames)
                {
                    string sql = "SELECT * FROM " + tableName; 
                    MySqlCommand cmd = new MySqlCommand(sql, con); 
                    cmd.CommandType = CommandType.Text;
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string row = "";
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                row += dr.GetValue(i).ToString() + ";";
                            }
                            sw.WriteLine(tableName + "-" + row.TrimEnd(';'));
                        }
                    }
                }
            }
            MessageBox.Show("Data byla exportována do souboru export.txt.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }
        /*Metoda slouží k přidání nového záznamu do tabulky aut. 
         * Vytváří SQL dotaz pro vložení nového záznamu a používá parametry pro předání hodnot auta do dotazu. 
         * Pokud se nepodaří přidat záznam do tabulky, vyvolá se chyba.AddCar*/
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
        public static void AddMotorbike(Motorbike mo)
        {
            string sql = "INSERT INTO motorky VALUES (NULL,@MotorbikeZnacka,@MotorbikeModel,@MotorbikeRok_vyroby,@MotorbikeBarva,@MotorbikeCena,@MotorbikeStav_tachometru,@MotorbikePocet_vlastniku)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd1 = new MySqlCommand(sql, con);
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.Add("@MotorbikeZnacka", MySqlDbType.VarChar).Value = mo.Znacka1;
            cmd1.Parameters.Add("@MotorbikeModel", MySqlDbType.VarChar).Value = mo.Model;
            cmd1.Parameters.Add("@MotorbikeRok_vyroby", MySqlDbType.VarChar).Value = mo.Rok_vyroby1;
            cmd1.Parameters.Add("@MotorbikeBarva", MySqlDbType.VarChar).Value = mo.Barva;
            cmd1.Parameters.Add("@MotorbikeCena", MySqlDbType.VarChar).Value = mo.Cena1;
            cmd1.Parameters.Add("@MotorbikeStav_tachometru", MySqlDbType.VarChar).Value = mo.Stav_tachometru;
            cmd1.Parameters.Add("@MotorbikePocet_vlastniku", MySqlDbType.VarChar).Value = mo.Pocet_vlastniku;
            try
            {
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Přidáno Uspěšně.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Motorka není vloženo. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void AddTruck(Truck tr)
        {
            string sql = "INSERT INTO nakladaky VALUES (NULL,@TruckZnacka,@TruckModel,@TruckNosnost,@TruckCena,@TruckRok_vyroby,@TruckPalivo)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd2 = new MySqlCommand(sql, con);
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("@TruckZnacka", MySqlDbType.VarChar).Value = tr.Znacka2;
            cmd2.Parameters.Add("@TruckModel", MySqlDbType.VarChar).Value = tr.Model1;
            cmd2.Parameters.Add("@TruckNosnost", MySqlDbType.VarChar).Value = tr.Nosnost;
            cmd2.Parameters.Add("@TruckCena", MySqlDbType.VarChar).Value = tr.Cena2;
            cmd2.Parameters.Add("@TruckRok_vyroby", MySqlDbType.VarChar).Value = tr.Rok_vyroby2;
            cmd2.Parameters.Add("@TruckPalivo", MySqlDbType.VarChar).Value = tr.Palivo;
            try
            {
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Přidáno Uspěšně.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nakladak není vloženo. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        /*Metoda aktualizuje existující záznam v tabulce aut. 
         * Vytváří SQL dotaz pro aktualizaci záznamu a opět používá parametry pro předání hodnot auta a identifikátoru záznamu.
         * Pokud se nepodaří aktualizovat záznam, vyvolá se chyba.UpdateCar*/
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
        public static void UpdateMotorbike(Motorbike mo, string id)
        {
            string sql = "UPDATE motorky SET Znacka = @MotorbikeZnacka,Model = @MotorbikeModel ,Rok_vyroby = @MotorbikeRok_vyroby,Barva = @MotorbikeBarva, Cena = @MotorbikeCena,Stav_tachometru = @MotorbikeStav_tachometru,Pocet_vlastniku = @MotorbikePocet_vlastniku WHERE id = @Motorbikeid";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd1 = new MySqlCommand(sql, con);
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.Add("@Motorbikeid", MySqlDbType.VarChar).Value = id;
            cmd1.Parameters.Add("@MotorbikeZnacka", MySqlDbType.VarChar).Value = mo.Znacka1;
            cmd1.Parameters.Add("@MotorbikeModel", MySqlDbType.VarChar).Value = mo.Model;
            cmd1.Parameters.Add("@MotorbikeRok_vyroby", MySqlDbType.VarChar).Value = mo.Rok_vyroby1;
            cmd1.Parameters.Add("@MotorbikeBarva", MySqlDbType.VarChar).Value = mo.Barva;
            cmd1.Parameters.Add("@MotorbikeCena", MySqlDbType.VarChar).Value = mo.Cena1;
            cmd1.Parameters.Add("@MotorbikeStav_tachometru", MySqlDbType.VarChar).Value = mo.Stav_tachometru;
            cmd1.Parameters.Add("@MotorbikePocet_vlastniku", MySqlDbType.VarChar).Value = mo.Pocet_vlastniku;
            try
            {
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Upaveno Uspěšně.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Motorky není upraveno. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }

        public static void UpdateTruck(Truck tr, string id)
        {
            string sql = "UPDATE nakladaky SET Znacka = @TruckZnacka,Model = @TruckModel,Nosnost = @TruckNosnost ,Cena = @TruckCena ,Rok_vyroby = @TruckRok_vyroby ,Palivo = @TruckPalivo  WHERE id = @Truckid";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd2 = new MySqlCommand(sql, con);
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("@Truckid", MySqlDbType.VarChar).Value = id;
            cmd2.Parameters.Add("@TruckZnacka", MySqlDbType.VarChar).Value = tr.Znacka2;
            cmd2.Parameters.Add("@TruckModel", MySqlDbType.VarChar).Value = tr.Model1;
            cmd2.Parameters.Add("@TruckNosnost", MySqlDbType.VarChar).Value = tr.Nosnost;
            cmd2.Parameters.Add("@TruckCena", MySqlDbType.VarChar).Value = tr.Cena2;
            cmd2.Parameters.Add("@TruckRok_vyroby", MySqlDbType.VarChar).Value = tr.Rok_vyroby2;
            cmd2.Parameters.Add("@TruckPalivo", MySqlDbType.VarChar).Value = tr.Palivo;
            try
            {
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Upaveno Uspěšně.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nakladaky není upraveno. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }
        /*Metoda odstraňuje záznam z tabulky aut. 
         * Vytváří SQL dotaz pro odstranění záznamu a používá parametry pro předání identifikátoru záznamu. 
         * Pokud se nepodaří odstranit záznam, vyvolá se chyba.
         * DeleteCar*/
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
                MessageBox.Show("Auta není vymazano. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DeleteMotorbike(string id)
        {
            string sql = "DELETE FROM motorky WHERE id = @Motorbikeid";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd1 = new MySqlCommand(sql, con);
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.Add("@Motorbikeid", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Vymazáno Uspěšně.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Motorky není vymazano. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DeleteTruck(string id)
        {
            string sql = "DELETE FROM nakladaky WHERE id = @Truckid";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd2 = new MySqlCommand(sql, con);
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("@Truckid", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Vymazáno Uspěšně.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nakladaky není vymazano. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        /*Metoda slouží k zobrazení dat z tabulky aut v . 
         * Vytváří SQL dotaz na základě předaného dotazu a používá adaptér pro načtení dat z databáze do datové tabulky. 
         * Datová tabulka se poté přidá do . Pokud se nepodaří načíst data z databáze, vyvolá se chyba.
         * DisplayAndSearchDataGridViewDataGridView*/
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
        public static void DisplayAndSearch1(string query, DataGridView dg)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd1 = new MySqlCommand(sql, con);
            MySqlDataAdapter ad = new MySqlDataAdapter(cmd1);
            DataTable tb2 = new DataTable();
            ad.Fill(tb2);
            dg.DataSource = tb2;
            con.Close();

        }
        public static void DisplayAndSearch2(string query, DataGridView dag)
        {
            string sql = query; MySqlConnection con = GetConnection(); MySqlCommand cmd2 = new MySqlCommand(sql, con); MySqlDataAdapter adap = new MySqlDataAdapter(cmd2); DataTable tb3 = new DataTable(); adap.Fill(tb3); dag.DataSource = tb3; con.Close();

        }

    }
}


