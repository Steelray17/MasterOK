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
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
            ShowProduct();
            ShowClients();
            ShowEmployees();
            ShowOrderSet();
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

        void ShowClients()
        {
            comboBoxClient.Items.Clear();
            foreach (ClientsSet clientsSet in Program.master.ClientsSet)
            {
                string[] item = { clientsSet.id.ToString() + ".", clientsSet.LastName + " ", clientsSet.FirstName + " ", clientsSet.MiddleName };
                comboBoxClient.Items.Add(string.Join(" ", item));
            }
        }

        void ShowEmployees()
        {
            comboBoxEmployee.Items.Clear();
            foreach (EmployeeSet employeeSet in Program.master.EmployeeSet)
            {
                string[] item = { employeeSet.id.ToString() + ".", employeeSet.LastName + " ", employeeSet.FirstName + " ", employeeSet.MiddleName };
                comboBoxEmployee.Items.Add(string.Join(" ", item));
            }
        }
        void ShowOrderSet()
        {
            //Предварительно очищаем все listView
            listViewOrders.Items.Clear();
            //Проходим по коллекции клиентов, которые находятся в базе
            foreach (OrderSet orderSet in Program.master.OrderSet)
            {
                //создадим новый элемент в listView с помощью массива строк
                ListViewItem item = new ListViewItem(new string[]
                {
                    orderSet.ClientsSet.LastName+" "+orderSet.ClientsSet.FirstName+" "+orderSet.ClientsSet.MiddleName,
                    orderSet.EmployeeSet.LastName+" "+orderSet.EmployeeSet.FirstName+" "+orderSet.EmployeeSet.MiddleName,
                    orderSet.ProductSet.NameProduct,
                    orderSet.Date
                }) ;
                //Указываем по какому тегу выбраны элементы
                item.Tag = orderSet;
                //Добавляем элементы в listViewSupplySet для отображения
                listViewOrders.Items.Add(item);
            }
            listViewOrders.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OrderSet orderSet = new OrderSet();

            orderSet.idClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
            orderSet.idEmployee = Convert.ToInt32(comboBoxEmployee.SelectedItem.ToString().Split('.')[0]);
            orderSet.idProduct = Convert.ToInt32(comboBoxProduct.SelectedItem.ToString().Split('.')[0]);
            orderSet.Date = textBoxDate.Text;

            Program.master.OrderSet.Add(orderSet);
            Program.master.SaveChanges();
            ShowOrderSet();
        }

        private void listViewOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOrders.SelectedItems.Count == 1)
            {
                OrderSet orderSet = listViewOrders.SelectedItems[0].Tag as OrderSet;

                comboBoxClient.SelectedIndex = comboBoxClient.FindString(orderSet.idClient.ToString());
                comboBoxEmployee.SelectedIndex = comboBoxEmployee.FindString(orderSet.idEmployee.ToString());
                comboBoxProduct.SelectedIndex = comboBoxProduct.FindString(orderSet.idProduct.ToString());
                textBoxDate.Text = orderSet.Date;
            }
            else
            {
                comboBoxClient.SelectedItem = null;
                comboBoxEmployee.SelectedItem = null;
                comboBoxProduct.SelectedItem = null;
                textBoxDate.Text = "";
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewOrders.SelectedItems.Count == 1)
            {
                OrderSet orderSet = listViewOrders.SelectedItems[0].Tag as OrderSet;

                orderSet.idClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                orderSet.idEmployee = Convert.ToInt32(comboBoxEmployee.SelectedItem.ToString().Split('.')[0]);
                orderSet.idProduct = Convert.ToInt32(comboBoxProduct.SelectedItem.ToString().Split('.')[0]);
                orderSet.Date = textBoxDate.Text;

                Program.master.SaveChanges();
                ShowOrderSet();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewOrders.SelectedItems.Count == 1)
                {
                    OrderSet orderSet = listViewOrders.SelectedItems[0].Tag as OrderSet;
                    Program.master.OrderSet.Remove(orderSet);

                    Program.master.SaveChanges();
                    ShowOrderSet();
                }
                comboBoxClient.SelectedItem = null;
                comboBoxEmployee.SelectedItem = null;
                comboBoxProduct.SelectedItem = null;
                textBoxDate.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
