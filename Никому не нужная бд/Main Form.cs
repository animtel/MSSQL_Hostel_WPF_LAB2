using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Никому_не_нужная_бд
{
    public partial class Main_form : Form
    {

        // изначально DataGrid менять нельзя, только после "Start change" но если тыкнуть на плюсик то там эксепшены посыпятся 
        public Main_form()
        {
            InitializeComponent();
            Main_Table.ReadOnly = true;
            Main_Table.DataSource = personalBindingSource;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cafeDataSet.Personal". При необходимости она может быть перемещена или удалена.
            this.personalTableAdapter.Fill(this.cafeDataSet.Personal);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cafeDataSet.Pozitions". При необходимости она может быть перемещена или удалена.
            this.pozitionsTableAdapter.Fill(this.cafeDataSet.Pozitions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cafeDataSet.Recipes". При необходимости она может быть перемещена или удалена.
            this.recipesTableAdapter.Fill(this.cafeDataSet.Recipes);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cafeDataSet.Dishes". При необходимости она может быть перемещена или удалена.
            this.dishesTableAdapter.Fill(this.cafeDataSet.Dishes);

        }

        private void saveAllChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            personalTableAdapter.Update(cafeDataSet.Personal);
            
            Main_Table.ReadOnly = true;
        }

        private void startChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personalTableAdapter.Insert(5, "wqrr", 243);
            Main_Table.ReadOnly = false;
            
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            // this is shit-code
            if (comboBox1.Text.ToLower().Equals("personal"))
                Main_Table.DataSource = personalBindingSource;
            else if (comboBox1.Text.ToLower().Equals("position"))
                Main_Table.DataSource = pozitionsBindingSource;
            else if (comboBox1.Text.ToLower().Equals("dishes"))
                Main_Table.DataSource = dishesBindingSource;
            else if (comboBox1.Text.ToLower().Equals("reception"))
                Main_Table.DataSource = recipesBindingSource;
            Main_Table.Refresh();
        }
    }
}
