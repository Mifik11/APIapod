using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Xamarin.Essentials;

namespace APIapod.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        
        public void SaveToFile()
        {
            string[] data = new string[] { Id, Text, Description, Url };
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "save");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }           
            File.WriteAllLines(Path.Combine(path, $"{Id}.txt"), data );
        }
        public void LoadfromFile(string path)
        {
            string[] data = File.ReadAllLines(path);
            Id = data[0];
            Text = data[1];
            Description = data[2];
            Url = data[3];
        }
        
    }
}