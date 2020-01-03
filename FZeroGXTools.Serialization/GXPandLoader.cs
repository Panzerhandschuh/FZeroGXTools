using System;
using System.Diagnostics;
using System.IO;

namespace FZeroGXTools.Serialization
{
	// TODO: Add pack and unpack methods
	public class GXPandLoader : IDisposable
	{
		//private string gxRootOutputDir;
		private string unpackedFile;
		private Stream stream;

		private const string gxpandExe = @"gxpand.exe";

		/// <param name="inputFile">Path of input COLI_COURSE##.lz file</param>
		public GXPandLoader(string inputFile/*, string gxRootOutputDir*/)
		{
			//this.gxRootOutputDir = gxRootOutputDir;

			var currentDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			var gxpandPath = Path.Combine(currentDir, gxpandExe);
			var args = GetGXPandArgs(inputFile);
			var process = Process.Start(gxpandPath, args);
			process.WaitForExit();

			unpackedFile = unpackedFile.Replace('.', ',');
			stream = File.Open(unpackedFile, FileMode.Open);
		}

		private string GetGXPandArgs(string inputFile)
		{
			var inputFileName = Path.GetFileName(inputFile);
			unpackedFile = Path.Combine(Path.GetTempPath(), inputFileName);

			return $"unpack \"{inputFile}\" \"{unpackedFile}\"";
		}

		public Stream GetStream()
		{
			return stream;
		}

		public void Dispose()
		{
			//MoveUnpackedFileToOutput();
			File.Delete(unpackedFile);
			stream.Close();
		}

		//private void MoveUnpackedFileToOutput()
		//{
		//	// TODO: Re-pack file


		//	var destinationDir = Path.Combine(gxRootOutputDir, "stage");
		//	Directory.CreateDirectory(destinationDir);

		//	var unpackedFileName = Path.GetFileName(unpackedFile).Replace(',', '.');
		//	var destinationFile = Path.Combine(destinationDir, unpackedFileName);
		//	if (File.Exists(destinationFile))
		//		File.Delete(destinationFile);

		//	File.Move(unpackedFile, destinationFile);
		//}
	}
}
