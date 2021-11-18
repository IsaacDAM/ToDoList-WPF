using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToDoList_WPF.Entitats;
using ToDoList_WPF.Servei;
using ToDoList_WPF.Persistence;
using System.Data.SQLite;

namespace ToDoList_WPF
{
    /// <summary>
    /// Lógica de interacción para Finestra_Tasca.xaml
    /// </summary>
    public partial class Finestra_Tasca : Window
    {
        public Finestra_Tasca()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            lbRepresentant.ItemsSource = TreballadorServei.GetAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void lbRepresentant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
