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
    public partial class FormProducts : Form
    {
        public FormProducts()
        {
            InitializeComponent();
            ShowProduct();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ProductSet productSet = new ProductSet();

            productSet.NameProduct = textBoxNameProduct.Text;
            productSet.Quantity = textBoxQuantity.Text;
            productSet.Price = Convert.ToInt32(textBoxPrice.Text);

            Program.master.ProductSet.Add(productSet);
            Program.master.SaveChanges();
            ShowProduct();
        }

        void ShowProduct()
        {
            listViewProducts.Items.Clear();

            foreach (ProductSet productSet in Program.master.ProductSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    productSet.id.ToString(),
                    productSet.NameProduct,
                    productSet.Quantity,
                    productSet.Price.ToString()
                });
                item.Tag = productSet;
                listViewProducts.Items.Add(item);
            }
            listViewProducts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewProducts.SelectedItems.Count == 1)
            {
                ProductSet productSet = listViewProducts.SelectedItems[0].Tag as ProductSet;

                productSet.NameProduct = textBoxNameProduct.Text;
                productSet.Quantity = textBoxQuantity.Text;
                productSet.Price = Convert.ToInt32(textBoxPrice.Text);

                Program.master.SaveChanges();
                ShowProduct();
            }
        }
        private void listViewProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewProducts.SelectedItems.Count == 1)
            {
                ProductSet productSet = listViewProducts.SelectedItems[0].Tag as ProductSet;

                textBoxNameProduct.Text = productSet.NameProduct;
                textBoxQuantity.Text = productSet.Quantity;
                textBoxPrice.Text = Convert.ToString(productSet.Price);
            }
            else
            {
                textBoxNameProduct.Text = "";
                textBoxQuantity.Text = "";
                textBoxPrice.Text = "";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
                if (listViewProducts.SelectedItems.Count == 1)
                {
                    ProductSet productSet = listViewProducts.SelectedItems[0].Tag as ProductSet;
                    Program.master.ProductSet.Remove(productSet);
                    Program.master.SaveChanges();
                    ShowProduct();
                }
                textBoxNameProduct.Text = "";
                textBoxQuantity.Text = "";
                textBoxPrice.Text = "";
        }
    }
}
