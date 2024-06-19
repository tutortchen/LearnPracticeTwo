using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using StoreLibrary;

namespace YpSonyaTwo
{
    public partial class MainWindow : Window
    {
        // Список для хранения ресурсов на складе
        private List<Warehouse> warehouses = new List<Warehouse>();
        // Строка подключения к базе данных
        private string lineConnection;

        public MainWindow()
        {
            InitializeComponent();
            // Установить строку подключения к базе данных
            Connect("GK216_7\\SQLEXPRESS", "Sonya"); // Указать данные
        }

        // Метод для установки строки подключения
        public void Connect(string servername, string dbname)
        {
            lineConnection = $"Data Source={servername};Initial Catalog={dbname};Integrated Security=True";
        }

        // Метод для загрузки ресурсов со склада из базы данных
        private void LoadWarehouse()
        {
            warehouses.Clear();
            using (SqlConnection connection = new SqlConnection(lineConnection))
            {
                connection.Open();
                string query = "SELECT Id, Semolina, Butter, Sugar, Cocoa, Water FROM Warehouse";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    warehouses.Add(new Warehouse
                    {
                        Id = reader.GetInt32(0),
                        Semolina = reader.GetDecimal(1),
                        Butter = reader.GetDecimal(2),
                        Sugar = reader.GetDecimal(3),
                        Cocoa = reader.GetDecimal(4),
                        Water = reader.GetDecimal(5)
                    });
                }
            }
            WarehouseList.ItemsSource = warehouses;
        }

        // Метод для обработки события нажатия кнопки "Login"
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginInput.Text;
            string password = PasswordInput.Password;

            using (SqlConnection connection = new SqlConnection(lineConnection))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Login = @login AND Password = @password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                int userCount = (int)command.ExecuteScalar();

                if (userCount > 0)
                {
                    MessageBox.Show("Login successful");
                    LoadWarehouse();
                }
                else
                {
                    MessageBox.Show("Invalid login or password");
                }
            }
        }

        // Метод для обработки события нажатия кнопки "Calculate Possible Products"
        private void CalculateProducts_Click(object sender, RoutedEventArgs e)
        {
            if (warehouses.Count > 0)
            {
                int possibleProducts = warehouses[0].CalculatePossibleProducts();
                MessageBox.Show($"Possible products: {possibleProducts}");
            }
        }

        // Метод для обработки события нажатия кнопки "Calculate Logistics"
        private void CalculateLogistics_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(DistanceInput.Text, out decimal distance) && decimal.TryParse(CostPerKmInput.Text, out decimal costPerKm))
            {
                decimal logisticsCost = Logistics.CalculateLogisticsCost(distance, costPerKm);
                MessageBox.Show($"Logistics cost: {logisticsCost:C}");
            }
            else
            {
                MessageBox.Show("Invalid input for distance or cost per km");
            }
        }

        // Обработчик события GotFocus для LoginInput
        private void LoginInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginInput.Text == "Enter Login")
            {
                LoginInput.Text = "";
                LoginInput.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        // Обработчик события LostFocus для LoginInput
        private void LoginInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginInput.Text))
            {
                LoginInput.Text = "Enter Login";
                LoginInput.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        // Обработчик события GotFocus для PasswordInput
        private void PasswordInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordInput.Password == "Enter Password")
            {
                PasswordInput.Password = "";
                PasswordInput.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        // Обработчик события LostFocus для PasswordInput
        private void PasswordInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordInput.Password))
            {
                PasswordInput.Password = "Enter Password";
                PasswordInput.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        // Обработчик события PasswordChanged для PasswordInput
        private void PasswordInput_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordInput.Password == "Enter Password")
            {
                PasswordInput.Password = "";
                PasswordInput.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        // Обработчик события GotFocus для DistanceInput
        private void DistanceInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DistanceInput.Text == "Enter Distance")
            {
                DistanceInput.Text = "";
                DistanceInput.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        // Обработчик события LostFocus для DistanceInput
        private void DistanceInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DistanceInput.Text))
            {
                DistanceInput.Text = "Enter Distance";
                DistanceInput.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        // Обработчик события GotFocus для CostPerKmInput
        private void CostPerKmInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CostPerKmInput.Text == "Enter Cost per Km")
            {
                CostPerKmInput.Text = "";
                CostPerKmInput.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        // Обработчик события LostFocus для CostPerKmInput
        private void CostPerKmInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CostPerKmInput.Text))
            {
                CostPerKmInput.Text = "Enter Cost per Km";
                CostPerKmInput.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }
    }
}

