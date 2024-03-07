using LandBouwKas.ApiModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Aspose.Foundation;
using Aspose.Pdf;
using LandBouwKas.Model;



// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LandBouwKas
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GegevensGewasWindow : Window
    {
        public GegevensGewasWindow(Gewas gewas)
        {
            this.InitializeComponent();
            LoadGewasGegevens(gewas);

            
        }

        public void LoadGewasGegevens(Gewas gewas)
        {
            GegevensGewasListView.ItemsSource = new List<Gewas> { gewas };
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            
            var mainWindow = new MainWindow();
            mainWindow.Activate();
            this.Close();
        }

        

        private void GegevensGewasListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedGewas = e.ClickedItem as Gewas;
            var temp = selectedGewas.temperatuur.waarde;
            var vocht = selectedGewas.vochtigheid.waarde;
            var bodemgezondheid = selectedGewas.bodemgezondheid.ph;
            var zonlicht = selectedGewas.zonlicht.intensiteit;
            var bodemvoedingfos = selectedGewas.bodemgezondheid.voedingsstoffen.fosfor;
            var bodemvoedingkal = selectedGewas.bodemgezondheid.voedingsstoffen.kalium;
            var bodemvoedingsti = selectedGewas.bodemgezondheid.voedingsstoffen.stikstof;

            /*The path to the documents directory.*/
            string dataDir = "C:\\pdfkas\\offertekas.pdf";

            // Initialize document object
            Aspose.Pdf.Document document = new Aspose.Pdf.Document();
            // Add page
            Aspose.Pdf.Page page = document.Pages.Add();
            // Add text to new page
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment($"temperatuur: {temp}\temperatuur: {vocht}\bodemgezondheid: {bodemgezondheid}\bzonlicht: {zonlicht} \bfosfor: {bodemvoedingfos} \bkalium: {bodemvoedingkal} \bstikstof: {bodemvoedingsti} "));
            // Save updated PDF
            document.Save(dataDir + "offertekas.pdf");
        }
    }
}