namespace FZeroGXTools.Serialization
{
	// Orientation info associated with all FZObjects
	public class FZOrientation : IBinarySerializable
	{
		public int address;
		public Vector3 right; // Forward and right vectors might be switched (unconfirmed)
		public float positionX; // X position of the object/orientation vectors (seems redundant since the object already has this info)
		public Vector3 up;
		public float positionY; // Y position of the object/orientation vectors
		public Vector3 forward;
		public float positionZ; // Z position of the object/orientation vectors

		public void Serialize(FZWriter writer)
		{
			writer.Write(right);
			writer.Write(-positionX);
			writer.Write(up);
			writer.Write(positionY);
			writer.Write(forward);
			writer.Write(positionZ);
		}

		public static FZOrientation Deserialize(FZReader reader)
		{
			var obj = new FZOrientation();

			obj.address = (int)reader.BaseStream.Position;
			obj.right = reader.ReadVector3();
			obj.positionX = -reader.ReadSingle();
			obj.up = reader.ReadVector3();
			obj.positionY = reader.ReadSingle();
			obj.forward = reader.ReadVector3();
			obj.positionZ = reader.ReadSingle();

			return obj;
		}
	}
}
