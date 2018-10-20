using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> points = new Dictionary<string, int>
            {
                { "James", 9001 },
                { "Jo", 3474 },
                { "Jess", 11926 }
            };
            points.Add("abcd", 89);
            points.Add("BCA", 2);
            points.Add("BTech", 3);
            points.Add("MTech", 4);
            foreach (KeyValuePair<string, int> pair in points)
            {
                Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
            }

            //REMOVE the element
            points.Remove("BTech");
            points.Remove("BCA");
            Console.WriteLine("after removal the dictionary items are:");

            foreach (KeyValuePair<string, int> pair in points)
            {
                Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
            }
            FileStream fs = new FileStream("F://asmt//serial_demo.txt", FileMode.OpenOrCreate);
            BinaryFormatter bfm = new BinaryFormatter();
         
            bfm.Serialize(fs, points);
            fs.Close();
            Console.WriteLine("Serialization completed");

            string json = JsonConvert.SerializeObject(points, Formatting.Indented);

            Console.WriteLine(json);
            Console.Read();
        }
    }
}
