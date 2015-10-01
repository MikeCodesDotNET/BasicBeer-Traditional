// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BasicBeer
{
	[Register ("BeerTableViewCell")]
	partial class BeerTableViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblBeerABV { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblBeerName { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (imageView != null) {
				imageView.Dispose ();
				imageView = null;
			}
			if (lblBeerABV != null) {
				lblBeerABV.Dispose ();
				lblBeerABV = null;
			}
			if (lblBeerName != null) {
				lblBeerName.Dispose ();
				lblBeerName = null;
			}
		}
	}
}
