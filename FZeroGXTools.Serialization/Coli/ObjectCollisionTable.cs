﻿namespace FZeroGXTools.Serialization
{
	public class ObjectCollisionTable : IBinarySerializable
	{
		public int numEntries;
		public int offset;
		public ObjectCollisionData[] objectCollisions;

		public void Serialize(FZWriter writer)
		{
			writer.Write(numEntries);
			writer.Write(offset);
			writer.WriteAtOffset(objectCollisions, offset);
		}

		public static ObjectCollisionTable Deserialize(FZReader reader)
		{
			var table = new ObjectCollisionTable();

			table.numEntries = reader.ReadInt32();
			table.offset = reader.ReadInt32();
			table.objectCollisions = reader.ReadArrayAtOffset(table.offset, table.numEntries, ObjectCollisionData.Deserialize);

			return table;
		}
	}
}
