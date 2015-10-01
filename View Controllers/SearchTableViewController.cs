using Foundation;
using System;
using System.Collections.ObjectModel;
using System.CodeDom.Compiler;
using UIKit;
using Acr.UserDialogs;
using BreweryDB.Models;
using SDWebImage;

namespace BasicBeer
{
	partial class SearchTableViewController : UITableViewController
	{

        SearchViewModel viewModel = new SearchViewModel();
		public SearchTableViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupUI();
            SetupEvents();
        }

        void SetupUI()
        {
            //Set the searchfields text to match other fonts within the app
            var textfield = searchBar.Subviews[0].Subviews[1] as UITextField;
            if (textfield != null)
                textfield.Font = UIFont.FromName("Avenir-Book", 14);
        }

        void SetupEvents()
        {  
            searchBar.SearchButtonClicked += delegate
            {
                UserDialogs.Instance.ShowLoading("Searching");
                viewModel.SearchForBeersCommand(searchBar.Text);
            };

            viewModel.Beers.CollectionChanged += delegate
            {
                //Create our data source
                var datasource = new SearchDataSource(viewModel.Beers);
                datasource.DidSelectBeer += delegate
                {
                    TableView.DeselectRow(TableView.IndexPathForSelectedRow, false);
                };

                TableView.Source = datasource;
                TableView.ReloadData();
                UserDialogs.Instance.HideLoading();
            };
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.Identifier != "beerDescriptionSegue")
                return;

            // set in Storyboard
            var navctlr = segue.DestinationViewController as BeerDescriptionViewController;
            if (navctlr == null)
                return;

            navctlr.Selectedbeer = viewModel.Beers[TableView.IndexPathForSelectedRow.Row];

        }
	}

    class SearchDataSource : UITableViewSource
    {

        NSString cellIdentifier = new NSString("beerCell");
        ObservableCollection<Beer> beers;
        public SearchDataSource(ObservableCollection<Beer> beers)
        {
            this.beers = beers;
        }

        #region implemented abstract members of UITableViewSource
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //We'll pass back a cell here but we want to reuse offscreen cells to keep memory usage low.
            var beer = beers[indexPath.Row];

            var cell = tableView.DequeueReusableCell(cellIdentifier) as BeerTableViewCell ?? new BeerTableViewCell(cellIdentifier);

            cell.Name = beer.Name;
            cell.Abv = beer.Abv;
            if (beer.Labels != null)
                cell.Image.SetImage(new NSUrl(beer.Labels.Icon), UIImage.FromBundle("BeerDrinkin.png")
                );
            else
            {
                cell.Image.Image = UIImage.FromBundle("BeerDrinkin.png");
            }

            return cell;
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            //Magic ints for 32/64 bit
            return (nint)beers.Count;
        }
        #endregion

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            DidSelectBeer?.Invoke(beers[indexPath.Row]);
        }

        public delegate void RowSelectedHandler(Beer beer);
        public event RowSelectedHandler DidSelectBeer;
    }
}
