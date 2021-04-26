using System;
using System.IO;

namespace SerializationSample.Serialization
{
    public class DataSample : IByteSerializable<DataSample>
    {
        public int intValue;
        public float floatValue;
        public string stringValue;

        public byte[] ToBytes()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                byte[] intBytes = intValue.ToBytes();
                stream.Write(intBytes, 0, sizeof(int));

                byte[] floatBytes = floatValue.ToBytes();
                stream.Write(floatBytes, 0, sizeof(float));

                byte[] stringBytes = stringValue.ToBytes();
                byte[] stringLenghtBytes = stringBytes.Length.ToBytes();
                stream.Write(stringLenghtBytes, 0, sizeof(int));
                stream.Write(stringBytes, 0, stringBytes.Length);

                return stream.ToArray();
            }
        }

        public DataSample FromBytes(byte[] src)
        {
            byte[] buffer;
            int offset = 0;
            int lenght = 0;

            lenght = sizeof(int);
            buffer = new byte[lenght];
            Buffer.BlockCopy(src, offset, buffer, 0, lenght);
            offset += lenght;
            intValue = buffer.GetInt();

            lenght = sizeof(float);
            buffer = new byte[lenght];
            Buffer.BlockCopy(src, offset, buffer, 0, lenght);
            offset += lenght;
            floatValue = buffer.GetFloat();

            lenght = sizeof(int);
            buffer = new byte[lenght];
            Buffer.BlockCopy(src, offset, buffer, 0, lenght);
            offset += lenght;
            lenght = buffer.GetInt();
            buffer = new byte[lenght];
            Buffer.BlockCopy(src, offset, buffer, 0, lenght);
            offset += lenght;
            stringValue = buffer.GetString();

            return this;
        }
    }
}