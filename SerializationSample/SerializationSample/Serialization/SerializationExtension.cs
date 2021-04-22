using System;
using System.IO;
using System.Text;

namespace SerializationSample.Serialization
{
    public static class SerializationExtension
    {
        #region int

        public static byte[] ToBytes(this int value)
        {
            return BitConverter.GetBytes(value);
        }

        public static int GetInt(this byte[] value)
        {
            return BitConverter.ToInt32(value, 0);
        }

        #endregion

        #region float

        public static byte[] ToBytes(this float value)
        {
            return BitConverter.GetBytes(value);
        }

        public static float GetFloat(this byte[] value)
        {
            return BitConverter.ToSingle(value, 0);
        }

        #endregion

        #region string

        public static byte[] ToBytes(this string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        public static string GetString(this byte[] value)
        {
            return Encoding.UTF8.GetString(value);
        }

        #endregion

        #region DataSample

        public static byte[] ToBytes(this DataSample value)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                byte[] intBytes = value.intValue.ToBytes();
                stream.Write(intBytes, 0, sizeof(int));

                byte[] floatBytes = value.floatValue.ToBytes();
                stream.Write(floatBytes, 0, sizeof(float));

                byte[] stringBytes = value.stringValue.ToBytes();
                byte[] stringLenghtBytes = stringBytes.Length.ToBytes();
                stream.Write(stringLenghtBytes, 0, sizeof(int));
                stream.Write(stringBytes, 0, stringBytes.Length);

                return stream.ToArray();
            }
        }

        public static DataSample GetData(this byte[] value)
        {
            byte[] buffer;
            DataSample data = new DataSample();
            int offset = 0;
            int lenght = 0;

            lenght = sizeof(int);
            buffer = new byte[lenght];
            Buffer.BlockCopy(value, offset, buffer, 0, lenght);
            offset += lenght;
            data.intValue = buffer.GetInt();

            lenght = sizeof(float);
            buffer = new byte[lenght];
            Buffer.BlockCopy(value, offset, buffer, 0, lenght);
            offset += lenght;
            data.floatValue = buffer.GetFloat();

            lenght = sizeof(int);
            buffer = new byte[lenght];
            Buffer.BlockCopy(value, offset, buffer, 0, lenght);
            offset += lenght;
            lenght = buffer.GetInt();
            buffer = new byte[lenght];
            Buffer.BlockCopy(value, offset, buffer, 0, lenght);
            offset += lenght;
            data.stringValue = buffer.GetString();

            return data;
        }

        #endregion
    }
}