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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LandBouwKas
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private const string ApiBaseUrl = "https://api.jsonbin.io/v3/b/65c3a601266cfc3fde871b78"; // API base URL
        private HttpClient _httpClient;
        public MainWindow()
        {
            this.InitializeComponent();
            _httpClient = new HttpClient();
            LoadDataAsync();


            using (var db = new AppDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        private async void LoadDataAsync()
        {
            try
            {
                var jsonString = await GetZones();
                var zones = JsonSerializer.Deserialize<List<Zone>>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (zones != null && zones.Any())
                {
                    var firstZoneName = zones.First().gewassen[0].gewasNaam;
                    // Do something with firstZoneName, or iterate through zones to access other data
                }
                else
                {
                    // Handle empty or null response
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

        private async Task<string> GetZones()
        {
            var response = await _httpClient.GetAsync($"{ApiBaseUrl}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        //private void zone1_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void zone2_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void zone3_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void zone4_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void zone5_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void zone6_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
