using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ToDoList_WPF.API;
using ToDoList_WPF.Entitats;
using ToDoList_WPF.Servei;

namespace ToDoList_WPF
{
    public partial class FinestraTreballadors : Window
    {
        public FinestraTreballadors()
        {
            InitializeComponent();
        }

        private async void BotoEliminar_Click(object sender, RoutedEventArgs e)
        {
            TreballadorDades TNIF = (TreballadorDades)LlistaDeTreballadors.SelectedItem;
            if (TNIF == null)
            {
                MessageBox.Show("No s'ha seleccionat un treballador.", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (MessageBox.Show("Vols eliminar al treballador?", "Advertència", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                TreballadorDades Treballador = (TreballadorDades)LlistaDeTreballadors.SelectedItem;
                TreballadorAPI TAPI = new TreballadorAPI();
                await TAPI.DeleteAsync(Treballador.NIF);

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
                if (tbNIF.Text != "" && tbNom.Text != "")
                {
                    TreballadorDades MongoCodi = (TreballadorDades)LlistaDeTreballadors.SelectedItem;
                    TreballadorDades Treballador = new TreballadorDades
                    {
                        CodiT = MongoCodi.CodiT,
                        Nom = tbNom.Text,
                        Cognoms = tbCnom.Text,
                        NIF = tbNIF.Text,
                        Telefon = tbTel.Text,
                        Correu = tbEmail.Text
                    };

                    TreballadorServei TServei = new TreballadorServei();
                    String NIF = TNIF.NIF;

                    if (TServei.Update(Treballador, NIF) == 0)
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

        private void BotoAfegir_Click(object sender, RoutedEventArgs e)
        {
            if (tbNIF.Text != "" && tbNom.Text != "")
            {
                TreballadorDades Treballador = new TreballadorDades
                {
                    Nom = tbNom.Text,
                    Cognoms = tbCnom.Text,
                    NIF = tbNIF.Text,
                    Telefon = tbTel.Text,
                    Correu = tbEmail.Text
                };

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
