using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterOK
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
            if (FormAuthorization.users.type == "Client")
            { 
                buttonOpenEmployees.Enabled = false;
                buttonOpenProviders.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonOpenClients_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form formClients = new FormClients();
            formClients.Show();
        }

        private void buttonOpenEmployees_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form formEmployees = new FormEmployees();
            formEmployees.Show();
        }

        private void buttonOpenProducts_Click(object sender, EventArgs e)
        {
            Form formProducts = new FormProducts();
            formProducts.Show();
        }

        private void buttonOpenProviders_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form formProvider = new FormProvider();
            formProvider.Show();
        }

        private void buttonOpenWarehouse_Click(object sender, EventArgs e)
        {
            Form formWarehouse = new FormWarehouse();
            formWarehouse.Show();
        }

        private void buttonOpenOrders_Click(object sender, EventArgs e)
        {
            Form formOrder = new FormOrder();
            formOrder.Show();
        }
    }
}
