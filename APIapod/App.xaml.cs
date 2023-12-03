using APIapod.Services;
using APIapod.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.IO;
using APIapod.Models;
using Xamarin.Forms.Xaml;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace APIapod
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        public static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "save");
        protected override void OnStart()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            LoadAll();
        }
        protected override void OnSleep()
        {
            SaveAll();
        }

        public static void SaveAll()
        {
            if (Directory.Exists(path))
            {
                foreach (Item item in MockDataStore.items)
                {
                    item.SaveToFile();
                }
            }
        }
        public static void LoadAll()
        {
            if (Directory.Exists(path))
            {
                // Get all files in the directory
                string[] files = Directory.GetFiles(path);

                // Display the list of files

                foreach (string file in files)
                {
                    Item item = new Item();
                    item.LoadfromFile(file);
                    items.Add(item);
                }               
            }
        }
        public static List<Item> items = new List<Item>();
        protected override void OnResume()
        {
            LoadAll();
        }
    }
}
