using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace collection
{
    class Program2
    {
        static void Main(string[] args)
        {
            var con = new ConcurrentDictionary<string, int>();
            con.TryAdd("cat", 1);
            con.TryAdd("dog", 2);
            con.TryUpdate("cat", 100, 1);
            Console.WriteLine(con["cat"]);

            con.AddOrUpdate("dog", 5, (k, v) => v + 1);

            // Display dog value.
            Console.WriteLine(con["dog"]);

            // Get mouse or add it with value of 4.
            int mouse = con.GetOrAdd("mouse", 4);
            Console.WriteLine(mouse);

            // Get mouse or add it with value of 660.
            mouse = con.GetOrAdd("mouse", 660);
            Console.WriteLine(mouse);



            FileStream fs = new FileStream("F://asmt//serial_demo.txt", FileMode.OpenOrCreate);
            BinaryFormatter bfm = new BinaryFormatter();

            bfm.Serialize(fs, con);
            fs.Close();
            Console.WriteLine("Serialization completed");

            string json = JsonConvert.SerializeObject(con, Formatting.Indented);

            Console.WriteLine(json);
            Console.Read();
        }
    }
}
