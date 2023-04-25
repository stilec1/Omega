using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega.Forms
{
    public partial class FormMotorbikes : Form
    {
        FormMotorbikesWiev form;
        public FormMotorbikes()
        {
            InitializeComponent();
            form = new FormMotorbikesWiev(this);
        }

        
        public void Display1()
        {
            DbCar.DisplayAndSearch1("SELECT id, Znacka,Model, Rok_vyroby,Barva, Cena, Stav_tachometru, Pocet_vlastniku FROM motorky", dataGridVie1);
        }
        private void btnNew1_Click(object sender, EventArgs e)
        {
            form.Clear1();
            form.SaveInfo1();
            form.ShowDialog();
        }

        private void FormMotorbikes_Shown_1(object sender, EventArgs e)
        {
            Display1();
        }
        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            DbCar.DisplayAndSearch1("SELECT id,Znacka,Model, Rok_vyroby,Barva, Cena, Stav_tachometru, Pocet_vlastniku FROM motorky WHERE Znacka LIKE'%" + txtSearch1.Text + "%'", dataGridVie1);
        }

        private void dataGridView_CellClick1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                form.Clear1();
                form.id = dataGridVie1.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.znacka1 = dataGridVie1.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.model = dataGridVie1.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.rok_vyroby1 = dataGridVie1.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.barva = dataGridVie1.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.cena1 = dataGridVie1.Rows[e.RowIndex].Cells[7].Value.ToString();
                form.stav_tachometru = dataGridVie1.Rows[e.RowIndex].Cells[8].Value.ToString();
                form.pocet_vlastniku = dataGridVie1.Rows[e.RowIndex].Cells[9].Value.ToString();
                form.UpdateInfo1();
                form.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Chcete smazat záznam motorky?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbCar.DeleteMotorbike(dataGridVie1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display1();
                }
                return;
            }
        }

        private void btnExport1_Click(object sender, EventArgs e)
        {
            DbCar.ExportData();
        }
    }
}