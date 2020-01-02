using NUnit.Framework;
using System;
using System.IO;

namespace FZeroGXTools.Serialization.Tests
{
	[TestFixture]
	public class ColiFileTests
	{
		private const string courseFile = @"Game Files\stage\COLI_COURSE03.lz";

		[Test]
		public void CanDeserializeColiFile()
		{
			var coursePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, courseFile);
			using (var loader = new GXPandLoader(coursePath))
			using (var reader = new FZReader(loader.GetStream()))
			{
				var file = ColiFile.Deserialize(reader);
			}
		}
	}
}
