using APIapod.Models;
using APIapod.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APIapod.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
            APIget();   
        }
        public async void APIget()
        {
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM-dd");
            const string API = "954hYMwBVLdwtNnIqnQn3PYlU0o0GW495SprSBJ1";
            HttpClient client = new HttpClient();
            string url = $"https://api.nasa.gov/planetary/apod?api_key={API}&date=2022-11-01";
            string response = await client.GetStringAsync(url);

            var json = JObject.Parse(response);
            string Jurl = json["url"].ToString();
            URLImage.Source = new UriImageSource()
            {
                Uri = new Uri(Jurl)
            };

        }
    }
}