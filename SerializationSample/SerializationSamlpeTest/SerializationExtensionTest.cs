using NUnit.Framework;
using SerializationSample.Serialization;

namespace SerializationSamlpeTest
{
    [TestFixture]
    public class SerializationExtensionTest
    {
        private DataSample data;

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

        #region int

        [Test]
        public void IntToBytes_ConvertToBytes_ArrayIsNotEmpty()
        {
            int expected = data.intValue;
            byte[] actual = expected.ToBytes();

            Assert.IsNotEmpty(actual);
        }

        [Test]
        public void BytesToInt_ConvertToInt_AreEqual()
        {
            int expected = data.intValue;
            int actual = expected.ToBytes().GetInt();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region float

        [Test]
        public void FloatToBytes_ConvertToBytes_ArrayIsNotEmpty()
        {
            float expected = data.floatValue;
            byte[] actual = expected.ToBytes();

            Assert.IsNotEmpty(actual);
        }

        [Test]
        public void BytesToFloat_ConvertToFloat_AreEqual()
        {
            float expected = data.floatValue;
            float actual = expected.ToBytes().GetFloat();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region string

        [Test]
        public void StringToBytes_ConvertToBytes_ArrayIsNotEmpty()
        {
            string expected = data.stringValue;
            byte[] actual = expected.ToBytes();

            Assert.IsNotEmpty(actual);
        }

        [Test]
        public void BytesToString_ConvertToString_AreEqual()
        {
            string expected = data.stringValue;
            string actual = expected.ToBytes().GetString();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region DataSample

        [Test]
        public void DataSampleToBytes_ConvertToBytes_ArrayIsNotEmpty()
        {
            DataSample expected = data;
            byte[] actual = expected.ToBytes();

            Assert.IsNotEmpty(actual);
        }

        [Test]
        public void BytesToDataSample_ConvertToDataSample_AreEqual()
        {
            DataSample expected = data;
            DataSample actual = expected.ToBytes().GetData();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.intValue, actual.intValue);
            Assert.AreEqual(expected.floatValue, actual.floatValue);
            Assert.AreEqual(expected.stringValue, actual.stringValue);
        }

        #endregion
    }
}