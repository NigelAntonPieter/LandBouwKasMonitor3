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
            _httpClient = new HttpClient();
           
            using (var db = new AppDbContext())
            {
                _httpClient = new HttpClient();
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        private void Zone_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
