using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ToDoList_WPF.Entitats;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using MongoDB.Bson;
using ToDoList_WPF.API;

namespace ToDoList_WPF
{
    public partial class Finestra_ToDoList : Window
    {

        public Finestra_ToDoList()
        {
            InitializeComponent();
        }

        private void BotoTreballadors_Click(object sender, RoutedEventArgs e)
        {
            FinestraTreballadors ftreball = new FinestraTreballadors();
            ftreball.ShowDialog();
        }

        private void BotoAfegirTasca_Click(object sender, RoutedEventArgs e)
        {
            Finestra_Tasca ftasca = new Finestra_Tasca();
            ftasca.ShowDialog();
            ActualitzarTaula();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            ActualitzarTaula();
        }

        private async void BotoEnviarDoing_Click(object sender, RoutedEventArgs e)
        {
            
            Tasca Tasca = (Tasca)LlistaToDo.SelectedItem;
            TascaAPI TAPI = new TascaAPI();

            if (LlistaToDo.SelectedItem != null)
            {
                Tasca.Estat = "Doing";
                await TAPI.UpdateAsync(Tasca);
                ActualitzarTaula();
            }
            else
            {
                MessageBox.Show("Selecciona un element de la llista", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }

        private async void BotoRetornarToDo_Click(object sender, RoutedEventArgs e)
        {
            
            Tasca Tasca = (Tasca)LlistaDoing.SelectedItem;
            TascaAPI TAPI = new TascaAPI();

            if (LlistaDoing.SelectedItem != null)
            {
                Tasca.Estat = "ToDo";
                await TAPI.UpdateAsync(Tasca);
                ActualitzarTaula();
            }
            else
            {
                MessageBox.Show("Selecciona un element de la llista", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }
        private async void BotoRetornarDoing_Click(object sender, RoutedEventArgs e)
        {
            
            Tasca Tasca = (Tasca)LlistaDone.SelectedItem;
            TascaAPI TAPI = new TascaAPI();

            if (LlistaDone.SelectedItem != null)
            {
                Tasca.Estat = "Doing";
                await TAPI.UpdateAsync(Tasca);
                ActualitzarTaula();
            }
            else
            {
                MessageBox.Show("Selecciona un element de la llista", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }

        private async void BotoEnviarDone_Click(object sender, RoutedEventArgs e)
        {
            
            Tasca Tasca = (Tasca)LlistaDoing.SelectedItem;
            TascaAPI TAPI = new TascaAPI();

            if (LlistaDoing.SelectedItem != null)
            {
                Tasca.Estat = "Done";
                await TAPI.UpdateAsync(Tasca);
                ActualitzarTaula();
            }
            else
            {
                MessageBox.Show("Selecciona un element de la llista", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }

        private async void ActualitzarTaula()
        {
            TascaAPI TAPI = new TascaAPI();
            LlistaToDo.Items.Clear();
            LlistaDoing.Items.Clear();
            LlistaDone.Items.Clear();
            List<Tasca> Tasca = await TAPI.GetTascaAsync();
            foreach (var i in Tasca)
            {
                if (i.Estat == "ToDo")
                {
                    LlistaToDo.Items.Add(i);
                }
                else if (i.Estat == "Doing")
                {
                    LlistaDoing.Items.Add(i);
                }
                else if (i.Estat == "Done")
                {
                    LlistaDone.Items.Add(i);
                }

            }
        }

        private void BotoModificar_Click(object sender, RoutedEventArgs e)
        {
            TascaAPI TAPI = new TascaAPI();
            Finestra_Tasca ftasca = new Finestra_Tasca((sender as Button).Tag.ToString());
            ftasca.ShowDialog();
            ActualitzarTaula();
        }

        private async void BotoEliminar_Click(object sender, RoutedEventArgs e)
        {
            
            if (MessageBox.Show("Vols eliminar la tasca?", "Advertència", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                TascaAPI TAPI = new TascaAPI();
                await TAPI.DeleteAsync((sender as Button).Tag.ToString());
                ActualitzarTaula();
            }
            
        }

        private void Llista_GotFocus(object sender, RoutedEventArgs e)
        {
            var selected = ((ListBox)sender).SelectedItem;
            LlistaToDo.UnselectAll();
            LlistaDoing.UnselectAll();
            LlistaDone.UnselectAll();
            ((ListBox)sender).SelectedItem = selected;
        }

        private static object GetTascaFromListBox(ListBox source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object tasca = DependencyProperty.UnsetValue;
                while (tasca == DependencyProperty.UnsetValue)
                {
                    tasca = source.ItemContainerGenerator.ItemFromContainer(element);

                    if (tasca == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }

                    if (element == source)
                    {
                        return null;
                    }
                }

                if (tasca != DependencyProperty.UnsetValue)
                {
                    return tasca;
                }
            }

            return null;
        }

        private async void Llista_Drop(object sender, DragEventArgs e)
        {

            TascaAPI TAPI = new TascaAPI();
            String nom = ((ListBox)sender).Name;
            Tasca Tasca = ((Tasca)e.Data.GetData(typeof(Tasca)));
            if(nom == "LlistaToDo")
            {
                Tasca.Estat = "ToDo";
                await TAPI.UpdateAsync(Tasca);
                ActualitzarTaula();
            }
            else if (nom == "LlistaDoing")
            {
                Tasca.Estat = "Doing";
                await TAPI.UpdateAsync(Tasca);
                ActualitzarTaula();
            }
            else
            {
                Tasca.Estat = "Done";
                await TAPI.UpdateAsync(Tasca);
                ActualitzarTaula();
            }
            
        }

        private void Llista_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object Tasca = GetTascaFromListBox((ListBox)sender, e.GetPosition((ListBox)sender));

            if (Tasca != null)
            {
                DragDrop.DoDragDrop((ListBox)sender, Tasca, DragDropEffects.Move);
            }
        }

        private void BotoActualitzar_Click(object sender, RoutedEventArgs e)
        {
            ActualitzarTaula();
        }
    }
}