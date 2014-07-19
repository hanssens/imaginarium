using System;
using System.IO;
using MonoMac.Foundation;
using MonoMac.ImageKit;

namespace Imaginarium
{
	public class BrowseItem : IKImageBrowserItem
	{
		public BrowseItem (NSUrl uri)
		{
			_uri = uri;
		}
		private NSUrl _uri;

		public override string ImageUID {
			get {
				return _uri.Path;
			}
		}

		public override NSString ImageRepresentationType {
			get {
				return IKImageBrowserItem.NSURLRepresentationType;
			}
		}

		public override NSObject ImageRepresentation {
			get {
				return _uri;
			}
		}

		public override string ImageTitle {
			get {
				return Path.GetFileNameWithoutExtension(_uri.Path);
			}
		}
	}
}

