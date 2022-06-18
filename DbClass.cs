using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class DbClass
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
        public static void AddClass(Classr clr)
        {
            string sql = "INSERT INTO class_table VALUES (@ClassrNumber,@ClassrName)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;


            cmd.Parameters.Add("@ClassrNumber", MySqlDbType.VarChar).Value = clr.Number;
            cmd.Parameters.Add("@ClassrName", MySqlDbType.VarChar).Value = clr.Name;
         
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Class not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            con.Close();
        }
        public static void UpdateClass(Classr clr )
        {
            string sql = "UPDATE   class_table SET  Name=@ClassrName  WHERE Number=@ClassrNumber ";
               
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ClassrNumber", MySqlDbType.VarChar).Value = clr.Number;
            cmd.Parameters.Add("@ClassrName", MySqlDbType.VarChar).Value = clr.Name;
           
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Class not Update. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            con.Close();
        }
        public static void DeleteClass(Classr clr)
        {
            string sql = "DELETE FROM class_table WHERE Number=@ClassrNumber";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ClassrNumber", MySqlDbType.VarChar).Value = clr.Number;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Class not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            con.Close();
        }
        public static void DisplayAndSearchClass(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            DataTable tb = dataTable;
            adp.Fill(tb);
            dgv.DataSource = tb;
            con.Close();
        }
        

    }
}
