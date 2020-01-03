using NUnit.Framework;
using System;
using System.IO;

namespace FZeroGXTools.Serialization.Tests
{
	[TestFixture]
	public class ColiFileTests
	{
		private const string courseFile = @"GameData\stage\COLI_COURSE03.lz";

		[Test]
		public void CanDeserializeColiFile()
		{
			var currentDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			var coursePath = Path.Combine(currentDir, courseFile);
			using (var loader = new GXPandLoader(coursePath))
			using (var reader = new FZReader(loader.GetStream()))
			{
				var file = ColiFile.Deserialize(reader);
			}
		}
	}
}
