// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace Imaginarium
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.ImageKit.IKImageBrowserView browserView { get; set; }

		[Action ("AddButtonClicked:")]
		partial void AddButtonClicked (MonoMac.AppKit.NSButton sender);

		[Action ("SearchTextChanged:")]
		partial void SearchTextChanged (MonoMac.AppKit.NSSearchField sender);

		[Action ("SliderChanged:")]
		partial void SliderChanged (MonoMac.AppKit.NSSlider sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (browserView != null) {
				browserView.Dispose ();
				browserView = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
