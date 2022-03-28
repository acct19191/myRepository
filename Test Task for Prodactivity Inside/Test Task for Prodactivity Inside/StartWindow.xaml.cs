﻿using System;
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
using System.Windows.Shapes;

namespace Test_Task_for_Prodactivity_Inside
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
         
                InitializeComponent();
           
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CurrencyConverterModel model = new CurrencyConverterModel();
                MainWindow main = new MainWindow(this);
                main.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Ошибка запуска программы! Проверьте подключение к интернету!");
            }
        }
    }
}
