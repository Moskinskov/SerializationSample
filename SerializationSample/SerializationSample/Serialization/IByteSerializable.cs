namespace SerializationSample.Serialization
{
    public interface IByteSerializable<T>
    {
        byte[] ToBytes();
        T FromBytes( byte[] src);
    }
}