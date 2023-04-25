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
    public partial class FormTrucks : Form
    {
        FormTrucksWiev form;
        public FormTrucks()
        {
            InitializeComponent();
            form = new FormTrucksWiev(this);
        }


        public void Display2()
        {
            DbCar.DisplayAndSearch2("SELECT id, Znacka,Model,Nosnost,Cena,Rok_vyroby, Palivo FROM nakladaky", dataGridView2);
        }
        private void btnNew2_Click(object sender, EventArgs e)
        {
            form.Clear2();
            form.SaveInfo2();
            form.ShowDialog();
        }

        private void FormTrucks_Shown(object sender, EventArgs e)
        {
            Display2();
        }
        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            DbCar.DisplayAndSearch2("SELECT id, Znacka,Model,Nosnost,Cena,Rok_vyroby, Palivo FROM nakladaky WHERE Znacka LIKE'%" + txtSearch2.Text + "%'", dataGridView2);
        }

        private void dataGridView_CellClick2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                form.Clear2();
                form.id = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.znacka2 = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.model1 = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.nosnost = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.cena2 = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.rok_vyroby2 = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                form.palivo = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                form.UpdateInfo2();
                form.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Chcete smazat záznam nakladaky?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbCar.DeleteTruck(dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display2();
                }
                return;
            }
        }

        private void btnExport2_Click(object sender, EventArgs e)
        {
            DbCar.ExportData();
        }
    }
}
