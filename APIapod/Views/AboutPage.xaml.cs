using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using System.Data;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

    // Nuget newtonsoft.Json


namespace APIapod.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            APIget();                        
        }
        public async void APIget()
        {
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM-dd");
            const string API = "954hYMwBVLdwtNnIqnQn3PYlU0o0GW495SprSBJ1";
            HttpClient client = new HttpClient();
            string url = $"https://api.nasa.gov/planetary/apod?api_key={API}&date={date}";
            string response = await client.GetStringAsync(url);

            var json = JObject.Parse(response);
            string Jurl = json["url"].ToString();
            string Jtitle = json["title"].ToString();
            string Jexplanation = json["explanation"].ToString();
            resultlabel.Text = Jtitle;
            explain.Text = Jexplanation;
            URLImage.Source = new UriImageSource()
            {
                Uri = new Uri(Jurl)
            };
        }
    }
}