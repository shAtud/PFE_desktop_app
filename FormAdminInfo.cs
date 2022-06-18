using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormAdminInfo : Form
      
    {
        FormAdmin form;
        public FormAdminInfo()
        {
            InitializeComponent();
            form = new FormAdmin(this);
        }
        public void Display()
        {
            DbAdmin.DisplayAndSearch("SELECT ID,Nom,Prénom,Email,Password FROM admin_table", dataGridView);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormAdmin form = new FormAdmin(this);
            form.ShowDialog();
        }

        private void FormAdminInfo_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            DbAdmin.DisplayAndSearch("SELECT ID,Nom,Prénom,Email,Password FROM admin_table WHERE Nom LIKE'%" + txtSearch.Text + "%'", dataGridView);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbAdmin.DisplayAndSearch("SELECT ID,Nom,Prénom,Email,Password FROM admin_table WHERE Nom LIKE'%" + txtSearch.Text + "%'", dataGridView);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                form.Clear();
                form.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.nom = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.prénom = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.email = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.password = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();

                form.UpdateInfo();
                form.ShowDialog();

                return;
            }
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Are you want to delete admin record?", "information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbAdmin.DeleteAdmin(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }

                return;
            }

        }

        private void FormAdminInfo_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
