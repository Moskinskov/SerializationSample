using System;
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
    }
}