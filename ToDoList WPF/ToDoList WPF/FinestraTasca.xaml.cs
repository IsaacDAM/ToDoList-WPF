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
    /// Lógica de interacción para Finestra_Tasca.xaml
    /// </summary>
    public partial class Finestra_Tasca : Window
    {
        public Finestra_Tasca()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TascaDades Tasca = new TascaDades();

            Tasca.Titol = tbTitol.Text;
            Tasca.Descripcio = tbDescripcio.Text;
            Tasca.dCreacio = (DateTime)tbDCreacio.SelectedDate;
            Tasca.dFinalitzacio = (DateTime)tbDFinal.SelectedDate;
            int opcioPrioritat= lbPrioritats.SelectedIndex;
            if (opcioPrioritat == 0)
            {
                Tasca.Prioritat = "Alta";
            }
            else if(opcioPrioritat == 1)
            {
                Tasca.Prioritat = "Mitja";
            }
            else
            {
                Tasca.Prioritat = "Baixa";
            }
            TreballadorDades t1 = (TreballadorDades)lbRepresentant.SelectedItem;
            Tasca.Representant = t1.Nom;
            Tasca.Estat = "ToDo";

            TascaServei ts = new TascaServei();
            ts.Add(Tasca);

            Close();
        }

        private void lbRepresentant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TreballadorDades Treballador = (TreballadorDades)lbRepresentant.SelectedItem;

        }

        private void lbPrioritats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            lbRepresentant.ItemsSource = TreballadorServei.GetAll();

        }


    }
}
