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
    /// Lógica de interacción para Finestra_ToDoList.xaml
    /// </summary>
    public partial class Finestra_ToDoList : Window
    {
        public Finestra_ToDoList()
        {
            InitializeComponent();
        }

        private void BotoTreballadors_Click(object sender, RoutedEventArgs e)
        {
            FinestraTreballadors ftreball = new FinestraTreballadors();
            ftreball.ShowDialog();
        }

        private void BotoModTasca_Click(object sender, RoutedEventArgs e)
        {
            Finestra_Tasca ftasca = new Finestra_Tasca();
            ftasca.ShowDialog();
        }

        private void BotoGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("S'han guardat els canvis", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
