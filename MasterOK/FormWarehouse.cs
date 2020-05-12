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
    public partial class FormWarehouse : Form
    {
        public FormWarehouse()
        {
            InitializeComponent();
            ShowProduct();
            ShowProvider();
            ShowPWarehouseSet();
        }

        void ShowProduct()
        {
            comboBoxProduct.Items.Clear();
            foreach (ProductSet productSet in Program.master.ProductSet)
            {
                string[] item = { productSet.id.ToString() + ".", productSet.NameProduct };
                comboBoxProduct.Items.Add(string.Join(" ", item));
            }
        }

        void ShowProvider()
        {
            comboBoxProvider.Items.Clear();
            foreach (ProviderSet providerSet in Program.master.ProviderSet)
            {
                string[] item = { providerSet.id.ToString() + ".", providerSet.Company };
                comboBoxProvider.Items.Add(string.Join(" ", item));
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            WarehouseSet warehouseSet = new WarehouseSet();

            warehouseSet.idProduct = Convert.ToInt32(comboBoxProduct.SelectedItem.ToString().Split('.')[0]);
            warehouseSet.idProvider = Convert.ToInt32(comboBoxProvider.SelectedItem.ToString().Split('.')[0]);
            Program.master.WarehouseSet.Add(warehouseSet);
            Program.master.SaveChanges();
            ShowPWarehouseSet();
        }

        void ShowPWarehouseSet()
        {
            listViewWarehouse.Items.Clear();
            foreach (WarehouseSet warehouseSet in Program.master.WarehouseSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    warehouseSet.ProductSet.NameProduct,
                    warehouseSet.ProviderSet.Company,
                    warehouseSet.ProductSet.Quantity
                });
                item.Tag = warehouseSet;
                listViewWarehouse.Items.Add(item);
            }
            listViewWarehouse.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listViewWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewWarehouse.SelectedItems.Count == 1)
            {
                WarehouseSet warehouseSet = listViewWarehouse.SelectedItems[0].Tag as WarehouseSet;

                comboBoxProduct.SelectedIndex = comboBoxProduct.FindString(warehouseSet.idProduct.ToString());
                comboBoxProvider.SelectedIndex = comboBoxProvider.FindString(warehouseSet.idProvider.ToString());
            }
            else
            {
                comboBoxProduct.SelectedItem = null;
                comboBoxProvider.SelectedItem = null;
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewWarehouse.SelectedItems.Count == 1)
                {
                    WarehouseSet warehouseSet = listViewWarehouse.SelectedItems[0].Tag as WarehouseSet;
                    Program.master.WarehouseSet.Remove(warehouseSet);
                    Program.master.SaveChanges();
                    ShowPWarehouseSet();
                }
                comboBoxProduct.SelectedItem = null;
                comboBoxProvider.SelectedItem = null;
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewWarehouse.SelectedItems.Count == 1)
            {
                WarehouseSet warehouseSet = listViewWarehouse.SelectedItems[0].Tag as WarehouseSet;

                warehouseSet.idProduct = Convert.ToInt32(comboBoxProduct.SelectedItem.ToString().Split('.')[0]);
                warehouseSet.idProvider = Convert.ToInt32(comboBoxProvider.SelectedItem.ToString().Split('.')[0]);

                Program.master.SaveChanges();
                ShowPWarehouseSet();
            }
        }
    }
}
