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
            TreballadorDades TNIF = (TreballadorDades)LlistaDeTreballadors.SelectedItem;
            if (TNIF == null)
            {
                MessageBox.Show("No s'ha seleccionat un treballador.", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (MessageBox.Show("Vols eliminar al treballador?", "Advertència", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
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

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            LlistaDeTreballadors.ItemsSource = TreballadorServei.GetAll();
        }

        private void BotoModificar_Click(object sender, RoutedEventArgs e)
        {
            TreballadorDades TNIF = (TreballadorDades)LlistaDeTreballadors.SelectedItem;
            if(TNIF == null)
            {
                MessageBox.Show("No s'ha seleccionat un treballador.", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                TreballadorDades Treballador = new TreballadorDades();

                Treballador.Nom = tbNom.Text;
                Treballador.Cognoms = tbCnom.Text;
                Treballador.NIF = tbNIF.Text;
                Treballador.Telefon = tbTel.Text;
                Treballador.Correu = tbEmail.Text;

                TreballadorServei TServei = new TreballadorServei();
                String NIF = TNIF.NIF;
                TServei.Update(Treballador, NIF);

                LlistaDeTreballadors.ItemsSource = TreballadorServei.GetAll();
            }
            


        }

        private void BotoAfegir_Click(object sender, RoutedEventArgs e)
        {
            if (tbNIF.Text != "" && tbNom.Text != "")
            {
                TreballadorDades Treballador = new TreballadorDades();

                Treballador.Nom = tbNom.Text;
                Treballador.Cognoms = tbCnom.Text;
                Treballador.NIF = tbNIF.Text;
                Treballador.Telefon = tbTel.Text;
                Treballador.Correu = tbEmail.Text;
                TreballadorServei TServei = new TreballadorServei();
                if (TServei.Add(Treballador) == 0)
                {
                    MessageBox.Show("Ja existeix un treballador amb aquest NIF.", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    LlistaDeTreballadors.ItemsSource = TreballadorServei.GetAll();
                }
            }
            else
            {
                MessageBox.Show("Els camps marcats amb * son obligatoris", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
