using System;
using System.Collections.Generic;
using System.Windows;
using ToDoList_WPF.Entitats;
using ToDoList_WPF.API;
using System.Linq;
using MongoDB.Bson;

namespace ToDoList_WPF
{
    public partial class Finestra_Tasca : Window
    {
        Tasca TascaInicial = new Tasca();
        public Finestra_Tasca()
        {
            InitializeComponent();
        }
        public Finestra_Tasca(String id)
        {
            TascaAPI TAPI = new TascaAPI();
            GetTasca(id);
        }
        private async void GetTasca(string id)
        {
            TascaAPI TAPI = new TascaAPI();
            TascaInicial = await TAPI.GetTascaAsync(id);
            this.DataContext = TascaInicial;
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {   
            if(tbTitol.Text != "" && tbDescripcio.Text != "" && tbDCreacio.SelectedDate != null && tbDFinal.SelectedDate != null && lbPrioritats.SelectedItem != null && lbRepresentant.SelectedItem != null)
            {
                Tasca Tasca = new Tasca();
                Tasca.Titol = tbTitol.Text;
                Tasca.Descripcio = tbDescripcio.Text;
                Tasca.dCreacio = (DateTime)tbDCreacio.SelectedDate;
                Tasca.dFinalitzacio = (DateTime)tbDFinal.SelectedDate;
                int opcioPrioritat = lbPrioritats.SelectedIndex;
                if (opcioPrioritat == 0)
                {
                    Tasca.Prioritat = "Alta";
                }
                else if (opcioPrioritat == 1)
                {
                    Tasca.Prioritat = "Mitja";
                }
                else
                {
                    Tasca.Prioritat = "Baixa";
                }
                Treballador t1 = (Treballador)lbRepresentant.SelectedItem;
                Tasca.Representant = t1.Nom;

                TascaAPI TAPI = new TascaAPI();

                if (tbCodi.Text == "")
                {

                    Tasca.Estat = "ToDo";
                    await TAPI.AddAsync(Tasca);
                    Close();
                }
                else
                {
                    Tasca.Estat = TascaInicial.Estat;
                    Tasca._id = tbCodi.Text;
                    await TAPI.UpdateAsync(Tasca);
                    Close();
                    
                }
            }
            else
            {
                MessageBox.Show("S'han d'emplenar tots els camps.","Informació",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            
        }



        private async void Window_ContentRendered(object sender, EventArgs e)
        {
            TreballadorAPI TAPI = new TreballadorAPI();
            lbRepresentant.ItemsSource = await TAPI.GetTreballadorsAsync();
            if (this.DataContext != null)
            {
                tbCodi.Text = ((Tasca)this.DataContext)._id;
                int contador = 0;
                bool trobat = false;
                int i = 0;
                List<Treballador> Treballadors = await TAPI.GetTreballadorsAsync();
                while (contador < Treballadors.Count() && !trobat)
                {
                    if (Treballadors[i].Nom == ((Tasca)this.DataContext).Representant)
                    {
                        lbRepresentant.SelectedIndex = contador;
                        trobat = true;
                    }
                    else
                    {
                        contador++;
                    }
                    i++;
                }
                if(trobat == false)
                {
                    MessageBox.Show("S'ha eliminat el treballador d'aquesta tasca, selecciona un de nou.", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                if(((Tasca)this.DataContext).Prioritat == "Alta")
                {
                    lbPrioritats.SelectedIndex = 0;
                }
                else if(((Tasca)this.DataContext).Prioritat == "Mitja")
                {
                    lbPrioritats.SelectedIndex = 1;
                }
                else
                {
                    lbPrioritats.SelectedIndex = 2;
                }
            }
            else
            {
                tbCodi.Text = "";

            }
        }
    }
}
