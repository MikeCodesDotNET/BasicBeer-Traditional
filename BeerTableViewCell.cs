using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BasicBeer
{
	partial class BeerTableViewCell : UITableViewCell
	{
        public BeerTableViewCell(IntPtr handle): base(handle)
        {
        }

        //Used with cell reuse
        public BeerTableViewCell(NSString cellId): base(UITableViewCellStyle.Default, cellId)
        {
        }

        public string Name
        {
            get { return lblBeerName.Text; }
            set { lblBeerName.Text = value; }
        }

        public string Abv
        {
            get{ return lblBeerABV.Text; }
            set{ lblBeerABV.Text = value; }
        }

        public UIImageView Image
        {
            get { return imageView; }
            set { imageView = value; }
        }
	}
}
