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
            //Создаём новый экземпляр класса Клиент
            EmployeeSet employeesSet = new EmployeeSet();
            //Делаем ссылку на обьект, который хранится в textBox-ax
            employeesSet.FirstName = textBoxFirstName.Text;
            employeesSet.LastName = textBoxLastName.Text;
            employeesSet.MiddleName = textBoxMiddleName.Text;
            employeesSet.Phone = textBoxPhone.Text;
            employeesSet.Address_City = textBoxAddress_City.Text;
            employeesSet.Address_House = textBoxAddress_House.Text;
            employeesSet.Address_Street = textBoxAddress_Street.Text;
            employeesSet.Address_Number = textBoxAddress_Number.Text;
            //Добавляем в таблицу ClientsSet нового клиента clientSet
            Program.master.EmployeeSet.Add(employeesSet);
            //Сохраняем изменения в модели wftDb
            Program.master.SaveChanges();
            ShowEmployee();
        }
        void ShowEmployee()
        {
            //предварительно очищаем listView
            listViewEmployees.Items.Clear();
            //проходимся по коллекции клиентов, которые находятся в базе с помощью foreach
            foreach (EmployeeSet employeesSet in Program.master.EmployeeSet)
            {
                //создаем новый элемент в listView
                //для этого создаем новый массив строк
                ListViewItem item = new ListViewItem(new string[]
                {
                    //указываем необходимые поля
                    employeesSet.id.ToString(), employeesSet.FirstName,employeesSet.LastName, employeesSet.MiddleName,
                    employeesSet.Phone, employeesSet.Address_City, employeesSet.Address_Street,
                    employeesSet.Address_House, employeesSet.Address_Number
                });
                //указываем по какому тегу будем брать элементы
                item.Tag = employeesSet;
                //добавляем элементы в listView для отображения
                listViewEmployees.Items.Add(item);
            }
            //выравниваем колонки в listView
            listViewEmployees.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonEdit_Click_1(object sender, EventArgs e)
        {
            //условие, если в listView выбран 1 элемент
            if (listViewEmployees.SelectedItems.Count == 1)
            {
                //ищем элемент из таблицы по тегу
                EmployeeSet employeesSet = listViewEmployees.SelectedItems[0].Tag as EmployeeSet;
                //указываем, что может быть изменено
                employeesSet.FirstName = textBoxFirstName.Text;
                employeesSet.MiddleName = textBoxMiddleName.Text;
                employeesSet.LastName = textBoxLastName.Text;
                employeesSet.Phone = textBoxPhone.Text;
                employeesSet.Address_City = textBoxAddress_City.Text;
                employeesSet.Address_House = textBoxAddress_House.Text;
                employeesSet.Address_Street = textBoxAddress_Street.Text;
                employeesSet.Address_Number = textBoxAddress_Number.Text;
                //Сохраняем изменения в модели wftDb
                Program.master.SaveChanges();
                //отображение в listView
                ShowEmployee();
            }
        }

        private void buttonDel_Click_1(object sender, EventArgs e)
        {
            //пробуем совершить действие
            try
            {
                //если выбран 1 элемент из listView
                if (listViewEmployees.SelectedItems.Count == 1)
                {
                    //ищем этот элемент, сверяем его
                    EmployeeSet employeesSet = listViewEmployees.SelectedItems[0].Tag as EmployeeSet;
                    //удаляем из модели и базы данных
                    Program.master.EmployeeSet.Remove(employeesSet);
                    //сохраняем изменения
                    Program.master.SaveChanges();
                    //отображаем обновленный список
                    ShowEmployee();
                }
                //очищаем textBox-ы
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxPhone.Text = "";
                textBoxAddress_City.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_Number.Text = "";
            }
            //если возникает какая-то ошибка, к примеру, запись используется, выводим всплывающее сообщение
            catch
            {
                //вызываем метод для всплывающего окна, в котором указываем текст, заголовок, кнопку и иконку
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            //условие, если выбран 1 элемент
            if (listViewEmployees.SelectedItems.Count == 1)
            {
                //ищем элемент из таблицы по тегу
                EmployeeSet employeesSet = listViewEmployees.SelectedItems[0].Tag as EmployeeSet;
                //указываем, что может быть изменено
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
                //условие, иначе, если не выбран ни один элемент, то задаем пустые поля
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
