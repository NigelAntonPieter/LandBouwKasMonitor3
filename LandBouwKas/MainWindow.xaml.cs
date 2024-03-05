using LandBouwKas.ApiModels;
using LandBouwKas.data;
using LandBouwKas.Data;
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
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using LandBouwKas.Model;
using System.Threading.Tasks;
using LandBouwKas.ApiModels;
using System.Net.Http;
using Newtonsoft.Json;
using Windows.Media.Protection.PlayReady;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LandBouwKas
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        //Dit is een Basis-URL voor de API Die we hebben gekregen--> Nigel Pieter
        private const string ApiBaseUrl = "https://api.jsonbin.io/v3/b/65c3a601266cfc3fde871b78";
        private HttpClient _httpClient;
        private AppDbContext db;

        public MainWindow()
        {
            this.InitializeComponent();
            _httpClient = new HttpClient();

            //Dit zorgt voor de dat de bestaande database wordt verwijderd en weer opnieuw wordt aangemaakt--> Nigel Pieter
            using (db = new AppDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                Fetchdata();
            }
        }

        //Haalt data op van de API en zet ze weer neer in de database--> Nigel Pieter
        public void Fetchdata()
        {
            String data = _httpClient.GetStringAsync("https://api.jsonbin.io/v3/b/65c3a601266cfc3fde871b78/").Result;
            CashData cashData = new CashData();
            cashData.FetchDate = DateTime.Now;
            cashData.Date = DateTime.Now;
            cashData.JSONDATA = data;

            db.CashData.Add(cashData);
            db.SaveChanges();
        }

        private async void Zone_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                var zoneId = clickedButton.Tag as string;
                Zone selectedZone = null;

                if (int.TryParse(zoneId, out int id))
                {
                    // Wijs geselecteerde zone toe op basis van de geklikte knop--> Nigel Pieter
                    switch (id)
                    {
                        case 1:
                            selectedZone = new Zone { id = 1, zoneNaam = "Zone 1", gewassen = new List<Gewas>() };
                            break;
                        case 2:
                            selectedZone = new Zone { id = 2, zoneNaam = "Zone 2", gewassen = new List<Gewas>() };
                            break;
                        case 3:
                            selectedZone = new Zone { id = 3, zoneNaam = "Zone 3", gewassen = new List<Gewas>() };
                            break;
                        case 4:
                            selectedZone = new Zone { id = 4, zoneNaam = "Zone 4", gewassen = new List<Gewas>() };
                            break;
                        case 5:
                            selectedZone = new Zone { id = 5, zoneNaam = "Zone 5", gewassen = new List<Gewas>() };
                            break;
                        case 6:
                            selectedZone = new Zone { id = 6, zoneNaam = "Zone 6", gewassen = new List<Gewas>() };
                            break;
                        default:
                            break;
                    }
                    if (selectedZone != null)
                    {
                    
                        CashData cashData = new CashData();
                        cashData.FetchDate = DateTime.Now;
                        cashData.Date = DateTime.Now;
                        cashData.JSONDATA = _httpClient.GetStringAsync(ApiBaseUrl).Result;

                    
                        Root root = cashData.ToRoot();
                        List<Gewas> gewassen = null;
                        if (root != null && root.record != null && root.record.metingen != null)
                        {
                            foreach (var meting in root.record.metingen)
                            {
                                foreach (var zone in meting.zones)
                                {
                                    
                                    if (zone.id == selectedZone.id)
                                    {
                                        gewassen = zone.gewassen;
                                        break; 
                                    }
                                }
                                if (gewassen != null)
                                    break; 
                            }
                        }
                        // Als gewassen worden gevonden, toon ze in een venster, anders toon een foutmeldingsvenster--> Nigel Pieter
                        if (gewassen != null)
                        {
                            selectedZone.gewassen = gewassen;
                            GewasWindow gewasWindow = new GewasWindow(selectedZone.gewassen);
                            gewasWindow.Activate();
                        }
                        else
                        {
                            await gewasDialog.ShowAsync();
                        }
                    }
                }
            }
        }
    }
}