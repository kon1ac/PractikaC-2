using System;
using System.Windows;
using System.Windows.Controls;

namespace PractikaC_2
{
    public partial class EditCustomerWindow : Window
    {
        public TextBox NameTextBox { get; set; }
        public TextBox ContactTextBox { get; set; }
        public TextBox AddressTextBox { get; set; }
        public TextBox CityTextBox { get; set; }
        public TextBox PostalCodeTextBox { get; set; }
        public TextBox CountryTextBox { get; set; }

        public EditCustomerWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
