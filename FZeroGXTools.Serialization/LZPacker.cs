using System.Diagnostics;
using System.IO;

namespace FZeroGXTools.Serialization
{
	public static class LZPacker
	{
		private const string gxpandExe = @"gxpand.exe";

		public static void Pack(string unpackedFile)
		{
			var currentDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			var gxpandPath = Path.Combine(currentDir, gxpandExe);
			var args = GetGxpandArgs(unpackedFile);

			var process = Process.Start(gxpandPath, args);
			process.WaitForExit();
		}

		private static string GetGxpandArgs(string unpackedFile)
		{
			return $"pack \"{unpackedFile}\" \"{unpackedFile}\"";
		}
	}
}
