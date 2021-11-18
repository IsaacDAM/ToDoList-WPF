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
                TServei.Delete(Treballador.NIF);

                LlistaDeTreballadors.ItemsSource = TreballadorServei.GetAll();
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LlistaDeTreballadors.ItemsSource = TreballadorServei.GetAll();
        }

        private void LlistaDeTreballadors_Selected(object sender, RoutedEventArgs e)
        {
            TreballadorDades Treballador = (TreballadorDades)LlistaDeTreballadors.SelectedItem;

            tbNom.Text = Treballador.Nom;
            tbCnom.Text = Treballador.Nom;
            tbNIF.Text = Treballador.Nom;
            tbTel.Text = Treballador.Nom;
            tbEmail.Text = Treballador.Nom;
        }
    }
}
