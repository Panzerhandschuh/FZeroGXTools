using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace FZeroGXTools.Serialization
{
	// TODO: Add pack and unpack methods
	public class LZUnpacker : IDisposable
	{
		private string unpackedFile;
		private Stream stream;

		private const string gxpandExe = @"gxpand.exe";

		/// <param name="packedFile">Path of COLI_COURSE##.lz file to be unpacked</param>
		public LZUnpacker(string packedFile)
		{
			var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			var gxpandPath = Path.Combine(currentDir, gxpandExe);
			var args = GetGxpandArgs(packedFile);

			var process = Process.Start(gxpandPath, args);
			process.WaitForExit();

			unpackedFile = packedFile.Substring(0, packedFile.Length - 3) + ",lz";
			stream = File.Open(unpackedFile, FileMode.Open);
		}

		private string GetGxpandArgs(string packedFile)
		{
			return $"unpack \"{packedFile}\" \"{packedFile}\"";
		}

		public Stream GetStream()
		{
			return stream;
		}

		public void Dispose()
		{
			File.Delete(unpackedFile);
			stream.Close();
		}
	}
}
