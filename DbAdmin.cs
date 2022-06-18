using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class DbAdmin
    {
        public static MySqlConnection GetConnection()
        {
          
           

            string sql = "Server=localhost;database=admin;UID=root;Password=;Port=3307";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
              
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return con;
        }
        public static void AddAdmin(Admin adm)
        {
            string sql = "INSERT INTO admin_table VALUES (NULL,@AdminNom,@AdminPrénom,@AdminEmail,@AdminPassword,NULL)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
           cmd.CommandType = CommandType.Text;
        

            cmd.Parameters.Add("@AdminNom", MySqlDbType.VarChar).Value = adm.Nom;
            cmd.Parameters.Add("@AdminPrénom", MySqlDbType.VarChar).Value = adm.Prénom;
            cmd.Parameters.Add("@AdminEmail", MySqlDbType.VarChar).Value = adm.Email;
            cmd.Parameters.Add("@AdminPassword", MySqlDbType.VarChar).Value = adm.Password;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Admin not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            con.Close();
        }
        public static void UpdateAdmin(Admin adm, string id)
        {
            string sql = "UPDATE   admin_table SET Nom=@AdminNom, Prénom=@AdminPrénom," +
                " Email=@AdminEmail,Password=@AdminPassword WHERE ID=@AdminId";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@AdminID", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@AdminNom", MySqlDbType.VarChar).Value = adm.Nom;
            cmd.Parameters.Add("@AdminPrénom", MySqlDbType.VarChar).Value = adm.Prénom;
            cmd.Parameters.Add("@AdminEmail", MySqlDbType.VarChar).Value = adm.Email;
            cmd.Parameters.Add("@AdminPassword", MySqlDbType.VarChar).Value = adm.Password;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Admin not Update. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            con.Close();
        }
        public static void DeleteAdmin(string id)
        {
            string sql = "DELETE FROM admin_table WHERE Id=@AdminId";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@AdminId", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Admin not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            con.Close();
        }
        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            DataTable tbl = dataTable;
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();

        }
    }
}
