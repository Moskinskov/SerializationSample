using System.IO;
using NUnit.Framework;
using SerializationSample.Serialization;

namespace SerializationSamlpeTest
{
    [TestFixture]
    public class DataSampleTest
    {
        private DataSample data;
        readonly string path = "D:/testData.save";

        [OneTimeSetUp]
        public void Prepare()
        {
            data = new DataSample()
            {
                intValue = 101,
                floatValue = 101.1f,
                stringValue = "101"
            };
        }

        [OneTimeTearDown]
        public void Finish()
        {
            if(File.Exists(path))
                File.Delete(path);
        }

        [Test]
        public void ToBytes_ConvertToBytes_ArrayNotEmpty()
        {
            byte[] actual = data.ToBytes();

            Assert.IsNotEmpty(actual);
        }

        [Test]
        public void FromBytes_DeserializeData_ValuesAreEqual()
        {
            uint hash;
            DataSample actualData;

            hash = ByteSerialization.Serialize(path, data);
            actualData = ByteSerialization.Deserialize<DataSample>(path, hash);

            Assert.AreEqual(data.intValue, actualData.intValue);
            Assert.AreEqual(data.floatValue, actualData.floatValue);
            Assert.AreEqual(data.stringValue, actualData.stringValue);
        }
    }
}