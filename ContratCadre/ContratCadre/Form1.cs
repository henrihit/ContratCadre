using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace ContratCadre
{
    public partial class Form1 : Form
    {

        dbEntities dbContext = new dbEntities();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dbContext.Contracts.Load();
            this.contractBindingSource.DataSource = dbContext.Contracts.Local.ToBindingList();


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.dbContext.Dispose();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.dbContext.SaveChanges();
            this.contractDataGridView.Refresh();
            this.itemsDataGridView.Refresh();
        }

        private void contractDataGridView_Enter(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = contractBindingSource;
        }

        private void itemsDataGridView_Enter(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = itemsBindingSource;
        }
    }
}
