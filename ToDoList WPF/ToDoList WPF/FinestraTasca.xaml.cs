using System;
using System.Collections.Generic;
using System.Windows;
using ToDoList_WPF.Entitats;
using ToDoList_WPF.Servei;
using ToDoList_WPF.API;
using System.Linq;
using MongoDB.Bson;

namespace ToDoList_WPF
{
    public partial class Finestra_Tasca : Window
    {
        TascaDades TascaInicial = new TascaDades();
        public Finestra_Tasca()
        {
            InitializeComponent();
        }
        public Finestra_Tasca(String Titol)
        {
            TascaAPI TAPI = new TascaAPI();
            GetTasca(Titol);
            TascaDades Tasca = TascaInicial;
            this.DataContext = Tasca;
            InitializeComponent();
        }
        private async void GetTasca(String Titol)
        {
            TascaAPI TAPI = new TascaAPI();
            TascaInicial = await TAPI.GetTascaAsync(Titol);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {   
            if(tbTitol.Text != "" && tbDescripcio.Text != "" && tbDCreacio.SelectedDate != null && tbDFinal.SelectedDate != null && lbPrioritats.SelectedItem != null && lbRepresentant.SelectedItem != null)
            {
                TascaDades Tasca = new TascaDades();
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
                TreballadorDades t1 = (TreballadorDades)lbRepresentant.SelectedItem;
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
                    Tasca.Codi = ObjectId.Parse(tbCodi.Text);
                    await TAPI.UpdateAsync(Tasca,TascaInicial.Titol);
                    Close();
                    
                }
            }
            else
            {
                MessageBox.Show("S'han d'emplenar tots els camps.","Informació",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            
        }



        private void Window_ContentRendered(object sender, EventArgs e)
        {
            lbRepresentant.ItemsSource = TreballadorServei.GetAll();
            if (this.DataContext != null)
            {
                tbCodi.Text = ((TascaDades)this.DataContext).Codi.ToString();
                int contador = 0;
                bool trobat = false;
                int i = 0;
                List<TreballadorDades> Treballadors = TreballadorServei.GetAll().ToList();
                while (contador < Treballadors.Count() && !trobat)
                {
                    if (Treballadors[i].Nom == ((TascaDades)this.DataContext).Representant)
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
                if(((TascaDades)this.DataContext).Prioritat == "Alta")
                {
                    lbPrioritats.SelectedIndex = 0;
                }
                else if(((TascaDades)this.DataContext).Prioritat == "Mitja")
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
