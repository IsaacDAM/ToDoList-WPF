using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ToDoList_WPF.Entitats;
using ToDoList_WPF.Servei;
using System.Linq;

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
        public Finestra_Tasca(int entrada)
        {
            InitializeComponent();
            TascaServei TS = new TascaServei();
            TascaDades Tasca = TS.Get(entrada);
            this.DataContext = Tasca;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            if(tbTitol.Text != "" && tbDescripcio.Text != "" && tbDCreacio.SelectedDate != null && tbDFinal.SelectedDate != null && lbPrioritats.SelectedItem != null && lbRepresentant.SelectedItem != null)
            {
                TascaDades Tasca = new TascaDades();
                if (tbCodi.Text != "")
                {
                    Tasca.Codi = Int32.Parse(tbCodi.Text);
                }
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

                TascaServei ts = new TascaServei();

                if (tbCodi.Text == "")
                {

                    Tasca.Estat = "ToDo";
                    ts.Add(Tasca);
                    Close();
                }
                else
                {
                    TascaDades estat = ts.Get(Int32.Parse(tbCodi.Text));
                    Tasca.Estat = estat.Estat;
                    ts.Update(Tasca);
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
        }
    }
}
