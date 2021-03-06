﻿using NUnit.Framework;
using System.IO;
using System.Reflection;

namespace FZeroGXTools.Serialization.Tests
{
	[TestFixture]
	public class ColiFileTests
	{
		private const string courseFile = @"GameData\stage\COLI_COURSE03.lz";

		[Test]
		public void CanDeserializeColiFile()
		{
			var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			var coursePath = Path.Combine(currentDir, courseFile);
			using (var loader = new LZUnpacker(coursePath))
			using (var reader = new FZReader(loader.GetStream()))
			{
				var file = ColiFile.Deserialize(reader);
			}
		}
	}
}
