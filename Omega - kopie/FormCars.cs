using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega.Views
{
    public partial class FormCars : Form
    {
        FormCarsWiev form;
        public FormCars()
        {
            InitializeComponent();
            form = new FormCarsWiev(this);
        }
        public void Display()
        {
            DbCar.DisplayAndSearch("SELECT id,Znacka,Rok_vyroby,Cena,Vykon,Historie FROM auta", dataGridView);     
         }
        private void btnNew_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.SaveInfo();
            form.ShowDialog();
        }

        private void FormCars_Shown(object sender, EventArgs e)
        {
            Display();
        }
        private void txtSearch_TextChanged(object sender,EventArgs e)
        {
            DbCar.DisplayAndSearch("SELECT id,Znacka,Rok_vyroby,Cena,Vykon,Historie FROM auta WHERE Znacka LIKE'%"+txtSearch.Text+"%'", dataGridView);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                form.Clear();
                form.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.znacka = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.rok_vyroby = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.cena = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.@vykon = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.historie = dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            if(e.ColumnIndex == 1)
            {
                if(MessageBox.Show("Chcete smazat záznam auta?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbCar.DeleteCar(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }
        }
    }
}
