using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BMR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> GenderList = new List<string>() { "Мужской", "Женский" };

        List<string> ActList = new List<string>() { "Сидячий образ", "Маленькая активность", "Средния активность", "Сильная активность", "Максимальная активность" };
        public MainWindow()
        {
            InitializeComponent();
            Gender.ItemsSource = GenderList;
            Act.ItemsSource = ActList;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            txtAge.Clear();
            txtHgt.Clear();
            txtMas.Clear();
        }
        private void Result_Click(object sender, RoutedEventArgs e)
        {
            double Mas = Convert.ToDouble(txtMas.Text);
            double Age = Convert.ToDouble(txtAge.Text);
            double Hgt = Convert.ToDouble(txtHgt.Text);

            double BMR = 0;
            if (Gender.SelectedItem.ToString() == "Мужской")
            {
                BMR = 66 + (9.6 * Mas) + (5 * Hgt) - (6.8 * Age);
            }
            else
            {
                BMR = 655 + (9.6 * Mas) + (1.8 * Hgt) - (4.7 * Age);
            }

            double BMRfinish = 0;

            if ( Act.SelectedItem.ToString() == "Сидячий образ")
            {
                BMRfinish = BMR * 1.2;
            }
            if (Act.SelectedItem.ToString() == "Маленькая активность")
            {
                BMRfinish = BMR * 1.375;
            }
            if (Act.SelectedItem.ToString() == "Средния активность")
            {
                BMRfinish = BMR * 1.55;
            }
            if (Act.SelectedItem.ToString() == "Сильная активность")
            {
                BMRfinish = BMR * 1.725;
            }
            if (Act.SelectedItem.ToString() == "Максимальная активность")
            {
                BMRfinish = BMR * 1.9;
            }


            this.Hide();
            Finish finish = new Finish(BMRfinish.ToString());
            finish.ShowDialog();
            this.Show();

        }
    }
}
