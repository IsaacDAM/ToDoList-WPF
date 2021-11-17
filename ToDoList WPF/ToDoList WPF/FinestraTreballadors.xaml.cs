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
            if (MessageBox.Show("Vols eliminar al treballador?","Advertència",MessageBoxButton.YesNo,MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                using (var ctx = DbContext.GetInstance())
                {
                    var query = $"DELETE FROM treballador WHERE nom like '{LlistaDeTreballadors.SelectedItem.ToString()}';";

                    var command = new SQLiteCommand(query,ctx);

                    command.ExecuteNonQuery();

                    LlistaDeTreballadors.Items.Remove(LlistaDeTreballadors.SelectedItem.ToString());
                }
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT nom FROM treballador";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LlistaDeTreballadors.Items.Add(reader["nom"].ToString());
                        }
                    }
                }

            }
        }

        private void LlistaDeTreballadors_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
