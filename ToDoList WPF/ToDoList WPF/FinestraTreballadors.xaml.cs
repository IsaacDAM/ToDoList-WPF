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
            if (MessageBox.Show("Vols eliminar al treballador?", "Advertència", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                TreballadorDades Treballador = (TreballadorDades)LlistaDeTreballadors.SelectedItem;
                TreballadorServei TServei = new TreballadorServei();
                TServei.Delete(Treballador);

                LlistaDeTreballadors.ItemsSource = TreballadorServei.GetAll();
            }
        }

        private void LlistaDeTreballadors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TreballadorDades Treballador = (TreballadorDades)LlistaDeTreballadors.SelectedItem;
            if(Treballador != null)
            {
                tbNom.Text = Treballador.Nom;
                tbCnom.Text = Treballador.Cognoms;
                tbNIF.Text = Treballador.NIF;
                tbTel.Text = Treballador.Telefon;
                tbEmail.Text = Treballador.Correu;
            }    
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LlistaDeTreballadors.ItemsSource = TreballadorServei.GetAll();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {

        }
    }
}
