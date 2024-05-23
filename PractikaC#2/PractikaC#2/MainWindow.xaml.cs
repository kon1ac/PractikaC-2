using PractikaC_2.Laba1DataSetTableAdapters;
using System;
using System.Data;
using System.Windows;

namespace PractikaC_2
{
    public partial class MainWindow : Window
    {
        private readonly Laba1DataSet dataSet;
        private readonly CustomersTableAdapter customersTableAdapter;
        private readonly ProductsTableAdapter productsTableAdapter;
        private readonly OrdersTableAdapter ordersTableAdapter;

        public MainWindow()
        {
            InitializeComponent();
            dataSet = new Laba1DataSet();
            customersTableAdapter = new CustomersTableAdapter();
            productsTableAdapter = new ProductsTableAdapter();
            ordersTableAdapter = new OrdersTableAdapter();

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                customersTableAdapter.Fill(dataSet.Customers);
                productsTableAdapter.Fill(dataSet.Products);
                ordersTableAdapter.Fill(dataSet.Orders);

                CustomerDataGrid.ItemsSource = dataSet.Customers;
                ProductsDataGrid.ItemsSource = dataSet.Products;
                OrdersDataGrid.ItemsSource = dataSet.Orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();
            if (addCustomerWindow.ShowDialog() == true)
            {
                Laba1DataSet.CustomersRow newCustomerRow = dataSet.Customers.NewCustomersRow();
                newCustomerRow.CustomerName = addCustomerWindow.NameTextBox.Text;
                newCustomerRow.ContactName = addCustomerWindow.ContactTextBox.Text;
                newCustomerRow.Address = addCustomerWindow.AddressTextBox.Text;
                newCustomerRow.City = addCustomerWindow.CityTextBox.Text;
                newCustomerRow.PostalCode = addCustomerWindow.PostalCodeTextBox.Text;
                newCustomerRow.Country = addCustomerWindow.CountryTextBox.Text;
                dataSet.Customers.AddCustomersRow(newCustomerRow);

                try
                {
                    customersTableAdapter.Update(dataSet.Customers);
                    CustomerDataGrid.ItemsSource = null;
                    CustomerDataGrid.ItemsSource = dataSet.Customers;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при добавлении клиента: {ex.Message}");
                }
            }
        }

        private void EditCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите клиента для редактирования.");
                return;
            }

            Laba1DataSet.CustomersRow selectedCustomerRow = (Laba1DataSet.CustomersRow)((DataRowView)CustomerDataGrid.SelectedItem).Row;
            EditCustomerWindow editCustomerWindow = new EditCustomerWindow();
            if (editCustomerWindow.ShowDialog() == true)
            {
                selectedCustomerRow.CustomerName = editCustomerWindow.NameTextBox.Text;
                selectedCustomerRow.ContactName = editCustomerWindow.ContactTextBox.Text;
                selectedCustomerRow.Address = editCustomerWindow.AddressTextBox.Text;

                selectedCustomerRow.City = editCustomerWindow.CityTextBox.Text;
                selectedCustomerRow.PostalCode = editCustomerWindow.PostalCodeTextBox.Text;
                selectedCustomerRow.Country = editCustomerWindow.CountryTextBox.Text;

                try
                {
                    customersTableAdapter.Update(dataSet.Customers);
                    CustomerDataGrid.ItemsSource = null;
                    CustomerDataGrid.ItemsSource = dataSet.Customers;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при обновлении клиента: {ex.Message}");
                }
            }
        }

        private void DeleteCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите клиента для удаления.");
                return;
            }

            Laba1DataSet.CustomersRow selectedCustomerRow = (Laba1DataSet.CustomersRow)((DataRowView)CustomerDataGrid.SelectedItem).Row;
            selectedCustomerRow.Delete();

            try
            {
                customersTableAdapter.Update(dataSet.Customers);
                CustomerDataGrid.ItemsSource = null;
                CustomerDataGrid.ItemsSource = dataSet.Customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при удалении клиента: {ex.Message}");
            }
        }
    }
}