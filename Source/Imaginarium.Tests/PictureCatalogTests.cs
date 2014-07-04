using NUnit.Framework;
using System;
using FluentAssertions;
using System.IO;
using System.Linq;

namespace Imaginarium.Tests
{
	[TestFixture ()]
	public class Test
	{
		public string _PictureFilePath { get; set; }

		public Test ()
		{
			var filePath = System.Configuration.ConfigurationManager.AppSettings ["PictureFilePath"].ToString();

			if (!Directory.Exists (filePath))
				throw new DirectoryNotFoundException ("Could not initialize tests, because the path in app.config doesn't exist");

			_PictureFilePath = filePath;
		}

		[Test ()]
		public void PictureCatalog_Should_Be_Initializable ()
		{
			// act + arrange
			var target = new PictureCatalog ();

			// assert
			target.Should ().NotBeNull ();
		}

		[Test]
		[ExpectedException(typeof(DirectoryNotFoundException))]
		public void PictureCatalog_FromPath_Should_Throw_DirectoryNotFoundException_With_Unexisting_Path()
		{
			// arrange
			var path = "/non_existing_path";

			// act
			var target = PictureCatalog.FromPath (path);

			// assert
			Assert.Fail ("Test should throw 'DirectoryNotFoundException', but found: " + target.ToString());
		}

		[Test]
		public void PictureCatalog_FromPath_Should_Return_Filled_Catalog()
		{
			// arrange
			var path = _PictureFilePath;

			// act
			var target = PictureCatalog.FromPath (path);

			// assert
			target.Should ().NotBeNull ();
			target.Pictures.Count.Should ().BeGreaterOrEqualTo (1);
		}
	}
}

