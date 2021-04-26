using System;
using System.IO;

namespace SerializationSample.Serialization
{
    public static class ByteSerialization
    {
        public static uint Serialize<T>(string path, IByteSerializable<T> serializableObject)
        {
            byte[] src = serializableObject.ToBytes();
            uint hash = Crc32.ComputeHash(src);
            File.WriteAllBytes(path, src);
            return hash;
        }

        public static T Deserialize<T>(string path, uint exeptedHash) where T : IByteSerializable<T>, new()
        {
            byte[] bytes = File.ReadAllBytes(path);

            uint actualHash = Crc32.ComputeHash(bytes);
            if (exeptedHash == actualHash)
            {
                return new T().FromBytes(bytes);
            }
            else
            {
                throw new NullReferenceException("Broken object.");
            }
        }
    }
}