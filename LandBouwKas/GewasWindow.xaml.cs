using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using LandBouwKas.Model;
using LandBouwKas.ApiModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LandBouwKas
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GewasWindow : Window
    {
        public GewasWindow(List<Gewas> gewassen)
        {
            this.InitializeComponent();
            GewasListView.ItemsSource = gewassen;
        }

        private void GewasListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Gewas gewas = e.ClickedItem as Gewas;

            var gegevensGewasWindow = new GegevensGewasWindow(gewas);
            gegevensGewasWindow.Activate();
        }
    }
}
