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

        private void BotoTreballadors_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BotoModTasca_Click(object sender, RoutedEventArgs e)
        {
            Finestra_Tasca ft = new Finestra_Tasca();
            ft.ShowDialog();
        }
    }
}
