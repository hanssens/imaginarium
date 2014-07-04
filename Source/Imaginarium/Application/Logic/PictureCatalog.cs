using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Imaginarium
{
	public class PictureCatalog
	{
		public List<Picture> Pictures { get; private set; }

		public PictureCatalog ()
		{
			Pictures = new List<Picture> ();
		}

		/// <summary>
		/// Initializes a filled PictureCatalog based on the provided filepath.
		/// </summary>
		/// <returns>Filled PictureCatalog instance.</returns>
		/// <param name="path">The full file path e.g. directory to spider through.</param>
		public static PictureCatalog FromPath(string path)
		{
			if (!Directory.Exists (path))
				throw new DirectoryNotFoundException ("Path doesn not exist: " + path);

			// fetch directoryinfo 
			var directories = new DirectoryInfo (path);

			// fetch *all* files
			var all_files = directories.GetFiles ("*.jpg", SearchOption.AllDirectories);

			// filter out only the picture files
			// TODO: we need more than just jpg's :)
			var pictures = all_files.Where (p => p.Extension == ".jpg").ToList ();

			// TODO: Make parallel...
			var returnValue = new PictureCatalog ();

			foreach (var file in pictures) {
				returnValue.Pictures.Add (MapFileToPicture (file));
			}

			return returnValue;
		}

		private static Picture MapFileToPicture(FileInfo file)
		{
			var returnValue = new Picture () {
				Id = Guid.NewGuid(),
				Filename = file.Name
			};

			return returnValue;
		}
	}
}

