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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Albums
{
    /// <summary>
    /// Logique d'interaction pour PisteListView.xaml
    /// </summary>
    public partial class PisteListView : UserControl
    {
        public PisteListView()
        {
            InitializeComponent();
        }

        private void Piste_AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AlbumViewModel a)
            {
                a.AddPiste();
            }
        }

        private void Piste_ModifiyButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AlbumViewModel a)
            {
                a.ModifyPiste();
            }
        }

        

        private void Piste_RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AlbumViewModel a)
            {
                a.RemovePiste();
            }
        }

    }
}
