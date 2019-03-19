using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace PracticDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;
            bool findForXml = true;
            List<StarWarsPeople> peoples = new List<StarWarsPeople>();
            var serializerXml = new XmlSerializer(typeof(List<StarWarsPeople>));
            Console.WriteLine("Введите номер персонажа: ");
            choice = Console.ReadLine();

            StarWarsPeople result = new StarWarsPeople();
            if (File.Exists("xmlPerson.xml"))
            {
                using (FileStream stream = new FileStream("xmlPerson.xml", FileMode.Open))
                {
                    peoples = (List<StarWarsPeople>)serializerXml.Deserialize(stream);
                }
                foreach (StarWarsPeople sw in peoples)
                {
                    if (sw.Id == Int32.Parse(choice))
                    {
                        Console.WriteLine($"Персонаж с xml \nName: {result.Name}\n Birthd: {result.BirthYear}\n Eye: {result.EyeColor}\n Gender: {result.Gender}" +
                    $"\n Hair: {result.HairColor}\n Height: {result.Height} \n Homeworld: {result.Homeworld}\n Skin: {result.SkinColor}");
                        findForXml = false;
                        break;
                    }
                    
                }
            }
            
            if (findForXml)
            {
                WebClient client = new WebClient();
                string json = client.DownloadString("https://swapi.co/api/people/" + choice + "/");
                result = JsonConvert.DeserializeObject<StarWarsPeople>(json);
                result.Id = Int32.Parse(choice);
                Console.WriteLine($"Персонаж с сайта \nName: {result.Name}\n Birthd: {result.BirthYear}\n Eye: {result.EyeColor}\n Gender: {result.Gender}" +
                    $"\n Hair: {result.HairColor}\n Height: {result.Height} \n Homeworld: {result.Homeworld}\n Skin: {result.SkinColor}");
                peoples.Add(result);
                
                using (FileStream stream = new FileStream("xmlPerson.xml", FileMode.OpenOrCreate))
                {
                    serializerXml.Serialize(stream, peoples);
                }
            }
            
        }

    }
}
