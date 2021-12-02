﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ToDoList_WPF.Entitats;
using ToDoList_WPF.Persistence;
using ToDoList_WPF.Servei;
using System.Linq;

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
            DbContext.Up();
            ActualitzarTaula();
            
        }

        private void BotoEnviarDoing_Click(object sender, RoutedEventArgs e)
        {
            TascaDades Tasca = (TascaDades)LlistaToDo.SelectedItem;
            TascaServei TS = new TascaServei();

            if(LlistaToDo.SelectedItem != null)
            {
                TS.UpdateEstat(Tasca.Codi, "Doing");
                ActualitzarTaula();
            }
            else
            {
                MessageBox.Show("Selecciona un element de la llista", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }

        private void BotoRetornarToDo_Click(object sender, RoutedEventArgs e)
        {
            TascaDades Tasca = (TascaDades)LlistaDoing.SelectedItem;
            TascaServei TS = new TascaServei();

            if (LlistaDoing.SelectedItem != null)
            {
                TS.UpdateEstat(Tasca.Codi, "ToDo");
                ActualitzarTaula();
            }
            else
            {
                MessageBox.Show("Selecciona un element de la llista", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void BotoRetornarDoing_Click(object sender, RoutedEventArgs e)
        {
            TascaDades Tasca = (TascaDades)LlistaDone.SelectedItem;
            TascaServei TS = new TascaServei();

            if (LlistaDone.SelectedItem != null)
            {
                TS.UpdateEstat(Tasca.Codi, "Doing");
                ActualitzarTaula();
            }
            else
            {
                MessageBox.Show("Selecciona un element de la llista", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BotoEnviarDone_Click(object sender, RoutedEventArgs e)
        {
            TascaDades Tasca = (TascaDades)LlistaDoing.SelectedItem;
            TascaServei TS = new TascaServei();

            if (LlistaDoing.SelectedItem != null)
            {
                TS.UpdateEstat(Tasca.Codi, "Done");
                ActualitzarTaula();
            }
            else
            {
                MessageBox.Show("Selecciona un element de la llista", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ActualitzarTaula()
        {
            LlistaToDo.Items.Clear();
            LlistaDoing.Items.Clear();
            LlistaDone.Items.Clear();
            List<TascaDades> Tasca = TascaServei.GetAll().ToList();
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
            Finestra_Tasca ftasca = new Finestra_Tasca((Int32)(sender as Button).Tag);
            ftasca.ShowDialog();
            ActualitzarTaula();
        }

        private void BotoEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Vols eliminar la tasca?", "Advertència", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                TascaServei TS = new TascaServei();
                TS.Delete((Int32)(sender as Button).Tag);
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
    }
}