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
    public partial class FormEmployees : System.Windows.Forms.Form
    {
        public FormEmployees()
        {
            InitializeComponent();
            ShowEmployee();
        }
        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            EmployeeSet employeesSet = new EmployeeSet();
            employeesSet.FirstName = textBoxFirstName.Text;
            employeesSet.LastName = textBoxLastName.Text;
            employeesSet.MiddleName = textBoxMiddleName.Text;
            employeesSet.Phone = textBoxPhone.Text;
            employeesSet.Address_City = textBoxAddress_City.Text;
            employeesSet.Address_House = textBoxAddress_House.Text;
            employeesSet.Address_Street = textBoxAddress_Street.Text;
            employeesSet.Address_Number = textBoxAddress_Number.Text;
            Program.master.EmployeeSet.Add(employeesSet);
            Program.master.SaveChanges();
            ShowEmployee();
        }
        void ShowEmployee()
        {
            listViewEmployees.Items.Clear();
            foreach (EmployeeSet employeesSet in Program.master.EmployeeSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    employeesSet.id.ToString(), employeesSet.FirstName,employeesSet.LastName, employeesSet.MiddleName,
                    employeesSet.Phone, employeesSet.Address_City, employeesSet.Address_Street,
                    employeesSet.Address_House, employeesSet.Address_Number
                });
                item.Tag = employeesSet;
                listViewEmployees.Items.Add(item);
            }
            listViewEmployees.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonEdit_Click_1(object sender, EventArgs e)
        {
            if (listViewEmployees.SelectedItems.Count == 1)
            {
                EmployeeSet employeesSet = listViewEmployees.SelectedItems[0].Tag as EmployeeSet;
                employeesSet.FirstName = textBoxFirstName.Text;
                employeesSet.MiddleName = textBoxMiddleName.Text;
                employeesSet.LastName = textBoxLastName.Text;
                employeesSet.Phone = textBoxPhone.Text;
                employeesSet.Address_City = textBoxAddress_City.Text;
                employeesSet.Address_House = textBoxAddress_House.Text;
                employeesSet.Address_Street = textBoxAddress_Street.Text;
                employeesSet.Address_Number = textBoxAddress_Number.Text;
                Program.master.SaveChanges();
                ShowEmployee();
            }
        }

        private void buttonDel_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (listViewEmployees.SelectedItems.Count == 1)
                {
                    EmployeeSet employeesSet = listViewEmployees.SelectedItems[0].Tag as EmployeeSet;
                    Program.master.EmployeeSet.Remove(employeesSet);
                    Program.master.SaveChanges();
                    ShowEmployee();
                }
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxPhone.Text = "";
                textBoxAddress_City.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_Number.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEmployees.SelectedItems.Count == 1)
            {
                EmployeeSet employeesSet = listViewEmployees.SelectedItems[0].Tag as EmployeeSet;
                textBoxFirstName.Text = employeesSet.FirstName;
                textBoxMiddleName.Text = employeesSet.MiddleName;
                textBoxLastName.Text = employeesSet.LastName;
                textBoxPhone.Text = employeesSet.Phone;
                textBoxAddress_City.Text = employeesSet.Address_City;
                textBoxAddress_House.Text = employeesSet.Address_House;
                textBoxAddress_Street.Text = employeesSet.Address_Street;
                textBoxAddress_Number.Text = employeesSet.Address_Number;
            }
            else
            {
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxPhone.Text = "";
                textBoxAddress_City.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_Number.Text = "";
            }
        }
    }
}
