using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using BreweryDB.Models;

namespace BasicBeer
{
	partial class BeerDescriptionViewController : UIViewController
	{
		public BeerDescriptionViewController (IntPtr handle) : base (handle)
		{
		}

        public Beer Selectedbeer{get; set;}

      
	}
}
