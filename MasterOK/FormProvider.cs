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
    public partial class FormProvider : Form
    {
        public FormProvider()
        {
            InitializeComponent();
            ShowProduct();
            ShowProviderSet();
        }

        void ShowProduct()
        {
            comboBoxNameProduct.Items.Clear();
            foreach (ProductSet productSet in Program.master.ProductSet)
            {
                string[] item = { productSet.id.ToString() + ".", productSet.NameProduct };
                comboBoxNameProduct.Items.Add(string.Join(" ", item));
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ProviderSet providerSet = new ProviderSet();
            providerSet.idProduct = Convert.ToInt32(comboBoxNameProduct.SelectedItem.ToString().Split('.')[0]);
            providerSet.NameProduct = comboBoxNameProduct.Text;
            providerSet.Company = textBoxCompany.Text;
            providerSet.Phone = textBoxPhone.Text;
            providerSet.Email = textBoxEmail.Text;

            Program.master.ProviderSet.Add(providerSet);
            Program.master.SaveChanges();
            ShowProviderSet();
        }

        void ShowProviderSet()
        {
            listViewProvider.Items.Clear();
            foreach (ProviderSet providerSet in Program.master.ProviderSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    providerSet.id.ToString(),
                    providerSet.idProduct.ToString(),
                    providerSet.NameProduct,
                    providerSet.Company,
                    providerSet.Phone,
                    providerSet.Email
                });
                item.Tag = providerSet;
                listViewProvider.Items.Add(item);
            }
            listViewProvider.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewProvider.SelectedItems.Count == 1)
            {
                ProviderSet providerSet = listViewProvider.SelectedItems[0].Tag as ProviderSet;

                providerSet.idProduct = Convert.ToInt32(comboBoxNameProduct.SelectedItem.ToString().Split('.')[0]);
                providerSet.NameProduct = comboBoxNameProduct.Text;
                providerSet.Company = textBoxCompany.Text;
                providerSet.Phone = textBoxPhone.Text;
                providerSet.Email = textBoxEmail.Text;

                Program.master.SaveChanges();
                ShowProviderSet();
            }
        }

        private void listViewProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewProvider.SelectedItems.Count == 1)
            {
                ProviderSet providerSet = listViewProvider.SelectedItems[0].Tag as ProviderSet;

                textBoxCompany.Text = providerSet.Company;
                textBoxPhone.Text = providerSet.Phone;
                textBoxEmail.Text = providerSet.Email;
                comboBoxNameProduct.Text = providerSet.NameProduct;
            }
            else 
            {
                textBoxCompany.Text = "";
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";
                comboBoxNameProduct.Text = "";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewProvider.SelectedItems.Count == 1)
                {
                    ProviderSet providerSet = listViewProvider.SelectedItems[0].Tag as ProviderSet;
                    Program.master.ProviderSet.Remove(providerSet);
                    Program.master.SaveChanges();
                    ShowProviderSet();
                }
                textBoxCompany.Text = "";
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";
                comboBoxNameProduct.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
