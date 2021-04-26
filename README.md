# SerializationSample
Serialization to bytes.

This serialization to bytes `ByteSerialization.Serialize(pathBytes, data)` takes `35 ms`, file size `15 byte`.

The deserialization from bytes `ByteSerialization.Deserialize<DataSample>(pathBytes, hash)` takes `13 ms`.

___

For example, the serialization to json takes `481 ms`, file size `55 byte`.

The deserialization from json takes `82 ms`.

___

Also added validation for catch broken objects before deserialization.
