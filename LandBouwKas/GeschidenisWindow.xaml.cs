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
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LandBouwKas
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GeschidenisWindow : Window
    {
        private Zone selectedZone;
        public ObservableCollection<GewasData> GewassenData { get; set; }
        public GeschidenisWindow(Zone zone)
        {
            this.InitializeComponent();
            selectedZone = zone;

            GewassenData = new ObservableCollection<GewasData>();

            // Vul de GewassenData ObservableCollection met de gegevens van de geselecteerde zone
            foreach (var gewas in selectedZone.gewassen)
            {
                GewassenData.Add(new GewasData
                {
                    GewasNaam = gewas.gewasNaam,
                    Temperatuur = $"{gewas.temperatuur.waarde} {gewas.temperatuur.eenheid}",
                    Vochtigheid = $"{gewas.vochtigheid.waarde} {gewas.vochtigheid.eenheid}",
                    PH = gewas.bodemgezondheid.ph.ToString(),
                    Stikstof = gewas.bodemgezondheid.voedingsftoffen.stikstof.ToString(),
                    Fosfor = gewas.bodemgezondheid.voedingsftoffen.fosfor.ToString(),
                    Kalium = gewas.bodemgezondheid.voedingsftoffen.kalium.ToString(),
                    ZonlichtIntensiteit = gewas.zonlicht.intensiteit,
                    UrenPerDag = gewas.zonlicht.urenPerDag.ToString()
                });
            }

            zoneListBox.ItemsSource = GewassenData;
        }
    }

    public class GewasData
    {
        public string GewasNaam { get; set; }
        public string Temperatuur { get; set; }
        public string Vochtigheid { get; set; }
        public string PH { get; set; }
        public string Stikstof { get; set; }
        public string Fosfor { get; set; }
        public string Kalium { get; set; }
        public string ZonlichtIntensiteit { get; set; }
        public string UrenPerDag { get; set; }
    }

}

        
    

