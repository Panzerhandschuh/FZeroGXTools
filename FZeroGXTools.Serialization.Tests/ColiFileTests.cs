using NUnit.Framework;
using System.IO;

namespace FZeroGXTools.Serialization.Tests
{
	[TestFixture]
	public class ColiFileTests
	{
		private const string course01 = @"Game Files\stage\COLI_COURSE03.lz";

		[Test]
		public void CanDeserializeColiFile()
		{
			using (var loader = new GXPandLoader(course01))
			using (var reader = new FZReader(loader.GetStream()))
			{
				var file = ColiFile.Deserialize(reader);
			}
		}
	}
}
