using System;
using System.IO;
using System.Text;

namespace FZeroGXTools.Serialization
{
	public class FZWriter : BinaryWriter
	{
		public FZWriter(Stream output) : base(output)
		{
		}

		public FZWriter(Stream output, Encoding encoding) : base(output, encoding)
		{
		}

		public FZWriter(Stream output, Encoding encoding, bool leaveOpen) : base(output, encoding, leaveOpen)
		{
		}

		protected FZWriter()
		{
		}

		public void Write(Vector3 value)
		{
			Write(-value.x);
			Write(value.y);
			Write(value.z);
		}

		public void Write(int[] values)
		{
			foreach (var value in values)
				Write(value);
		}

		public override void Write(int value)
		{
			var bytes = BitConverter.GetBytes(value);
			Array.Reverse(bytes);
			Write(bytes);
		}

		public override void Write(float value)
		{
			var bytes = BitConverter.GetBytes(value);
			Array.Reverse(bytes);
			Write(bytes);
		}

		public void Write(IBinarySerializable item)
		{
			item.Serialize(this);
		}

		public void WriteAtOffset(IBinarySerializable item, int offset)
		{
			var returnAddress = BaseStream.Position;
			BaseStream.Seek(offset, SeekOrigin.Begin);

			Write(item);

			BaseStream.Seek(returnAddress, SeekOrigin.Begin);
		}

		public void WriteAtOffset(IBinarySerializable[] item, int offset)
		{
			var returnAddress = BaseStream.Position;
			BaseStream.Seek(offset, SeekOrigin.Begin);

			foreach (var serializable in item)
				Write(serializable);

			BaseStream.Seek(returnAddress, SeekOrigin.Begin);
		}
	}
}
