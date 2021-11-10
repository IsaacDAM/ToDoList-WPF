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
    /// Lógica de interacción para FinestraTreballadors.xaml
    /// </summary>
    public partial class FinestraTreballadors : Window
    {
        public FinestraTreballadors()
        {
            InitializeComponent();
        }

        private void BotoEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Vols eliminar al treballador?","Advertència",MessageBoxButton.YesNo,MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {

            }
        }
    }
}
