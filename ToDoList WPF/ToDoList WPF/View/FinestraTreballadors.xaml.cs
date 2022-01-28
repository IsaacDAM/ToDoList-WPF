﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ToDoList_WPF.API;
using ToDoList_WPF.Entitats;

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
            TreballadorAPI TAPI = new TreballadorAPI();

            Treballador TNIF = (Treballador)LlistaDeTreballadors.SelectedItem;
            if (TNIF == null)
            {
                MessageBox.Show("No s'ha seleccionat un treballador.", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (MessageBox.Show("Vols eliminar al treballador?", "Advertència", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Treballador Treballador = (Treballador)LlistaDeTreballadors.SelectedItem;
                try
                {
                    await TAPI.DeleteAsync(Treballador.NIF);
                    MessageBox.Show("S'ha eliminat el treballador correctament.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al eliminar treballador: " + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
                LlistaDeTreballadors.ItemsSource = await TAPI.GetTreballadorsAsync();
            }
        }

        private void LlistaDeTreballadors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Treballador Treballador = (Treballador)LlistaDeTreballadors.SelectedItem;
            if(Treballador != null)
            {
                tbNom.Text = Treballador.Nom;
                tbCnom.Text = Treballador.Cognoms;
                tbNIF.Text = Treballador.NIF;
                tbTel.Text = Treballador.Telefon;
                tbEmail.Text = Treballador.Correu;
            }    
        }

        private async void Window_ContentRendered(object sender, EventArgs e)
        {
            TreballadorAPI TAPI = new TreballadorAPI();
            LlistaDeTreballadors.ItemsSource = await TAPI.GetTreballadorsAsync();
        }

        private async void BotoModificar_Click(object sender, RoutedEventArgs e)
        {
            Treballador TNIF = (Treballador)LlistaDeTreballadors.SelectedItem;
            if(TNIF == null)
            {
                MessageBox.Show("No s'ha seleccionat un treballador.", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (tbNIF.Text != "" && tbNom.Text != "")
                {
                    Treballador MongoCodi = (Treballador)LlistaDeTreballadors.SelectedItem;
                    Treballador Treballador = new Treballador
                    {
                        _id = MongoCodi._id,
                        Nom = tbNom.Text,
                        Cognoms = tbCnom.Text,
                        NIF = tbNIF.Text,
                        Telefon = tbTel.Text,
                        Correu = tbEmail.Text
                    };

                    TreballadorAPI TAPI = new TreballadorAPI();
                    String NIF = TNIF.NIF;
                    Treballador tempt = await TAPI.GetTreballadorAsync(Treballador.NIF);
                    if (tempt != null && tempt._id != Treballador._id)
                    {
                        MessageBox.Show("Ja existeix un treballador amb aquest NIF.", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        await TAPI.UpdateAsync(Treballador, TNIF.NIF);
                        LlistaDeTreballadors.ItemsSource = await TAPI.GetTreballadorsAsync();
                    }
                }
                else
                {
                    MessageBox.Show("Els camps marcats amb * son obligatoris", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private async void BotoAfegir_Click(object sender, RoutedEventArgs e)
        {
            TreballadorAPI TAPI = new TreballadorAPI();
            if (tbNIF.Text != "" && tbNom.Text != "")
            {
                Treballador Treballador = new Treballador
                {
                    Nom = tbNom.Text,
                    Cognoms = tbCnom.Text,
                    NIF = tbNIF.Text,
                    Telefon = tbTel.Text,
                    Correu = tbEmail.Text
                };

                if (await TAPI.GetTreballadorAsync(Treballador.NIF) != null)
                {
                    MessageBox.Show("Ja existeix un treballador amb aquest NIF.", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    await TAPI.AddAsync(Treballador);
                    LlistaDeTreballadors.ItemsSource = await TAPI.GetTreballadorsAsync();
                }
            }
            else
            {
                MessageBox.Show("Els camps marcats amb * son obligatoris", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}