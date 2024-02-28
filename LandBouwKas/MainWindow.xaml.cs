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
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using LandBouwKas.Model;
using System.Threading.Tasks;
using LandBouwKas.ApiModels;
using System.Net.Http;
using Newtonsoft.Json;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LandBouwKas
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        private const string ApiBaseUrl = "https://api.jsonbin.io/v3/b/65c3a601266cfc3fde871b78";
        private HttpClient _httpClient;
        public MainWindow()
        {
            this.InitializeComponent();
            using (var db = new AppDbContext())
            {
                _httpClient = new HttpClient();
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        private async Task<List<Gewassen>> GetGewassenForZoneAsync(string zoneName)
        {
            try
            {
                // Construct the API endpoint URL
                string apiUrl = $"{ApiBaseUrl}/gewassen?zone={Uri.EscapeDataString(zoneName)}";

                // Call the API and get the response
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                // Read the response content as string
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response to a list of Gewas objects
                List<Gewassen> gewassen = JsonConvert.DeserializeObject<List<Gewassen>>(responseBody);

                return gewassen;
            }
            catch (Exception ex)
            {
                // Handle any exceptions, such as network errors or deserialization errors
                Console.WriteLine($"Error getting gewassen: {ex.Message}");
                return new List<Gewassen>(); // Return an empty list in case of error
            }
        }

        private async void Zone_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string zoneName = btn.Content.ToString();

            
            List<Gewassen> gewassen = await GetGewassenForZoneAsync(zoneName);

            GewasWindow gewasWindow = new GewasWindow(gewassen);
            gewasWindow.Activate();
        }

    }
}
