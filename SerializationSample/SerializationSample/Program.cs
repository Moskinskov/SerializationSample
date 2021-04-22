using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using SerializationSample.Serialization;

namespace SerializationSample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //example
            string pathBytes = "D:/DATA_SAMPLE.save";
            string pathJson = "D:/DATA_SAMPLE.json";
            string timeSerializationBytes = string.Empty;
            string timeDeserializationBytes = string.Empty;
            string timeSerializationJson = string.Empty;
            string timeDeserializationJson = string.Empty;
            DataSample data = new DataSample()
            {
                intValue = 101,
                floatValue = 101.1f,
                stringValue = "101"
            };

            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            File.WriteAllBytes(pathBytes, data.ToBytes());
            stopwatch.Stop();
            timeSerializationBytes = stopwatch.ElapsedMilliseconds.ToString();

            stopwatch.Reset();
            stopwatch.Start();
            data = File.ReadAllBytes(pathBytes).GetData();
            stopwatch.Stop();
            timeDeserializationBytes = stopwatch.ElapsedMilliseconds.ToString();


            Console.WriteLine($"Bytes serialization time: {timeSerializationBytes}");
            Console.WriteLine($"Bytes deserialization time: {timeDeserializationBytes}");
            Console.WriteLine($"**********");

            stopwatch.Reset();
            stopwatch.Start();
            File.WriteAllText(pathJson, JsonConvert.SerializeObject(data));
            stopwatch.Stop();
            timeSerializationJson = stopwatch.ElapsedMilliseconds.ToString();

            stopwatch.Reset();
            stopwatch.Start();
            data = JsonConvert.DeserializeObject<DataSample>(File.ReadAllText(pathJson));
            stopwatch.Stop();
            timeDeserializationJson = stopwatch.ElapsedMilliseconds.ToString();


            Console.WriteLine($"JSON serialization time: {timeSerializationJson}");
            Console.WriteLine($"JSON deserialization time: {timeDeserializationJson}");
            
            // Bytes serialization time: 5
            // Bytes deserialization time: 2
            //     **********
            // JSON serialization time: 613
            // JSON deserialization time: 111



            Console.ReadKey();
        }
    }
}