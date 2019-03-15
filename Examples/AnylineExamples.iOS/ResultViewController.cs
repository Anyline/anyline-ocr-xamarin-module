using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnylineXamarinSDK.iOS;
using Foundation;
using UIKit;
using System.Reflection;
using System.Diagnostics;

namespace AnylineExamples.iOS
{
    public class ResultViewController : UITableViewController
    {

        object _scanResult;

        public ResultViewController(object scanResult)
        {
            _scanResult = scanResult;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView = new UITableView(View.Bounds, UITableViewStyle.Grouped);
            TableView.Source = new TableSource(_scanResult, this);

            NavigationItem.LeftBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Done, (sender, args) => {
                NavigationController?.PopViewController(false);
            });            
        }
        
        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            Dispose();
        }

        new void Dispose()
        {
            TableView.Source.Dispose();
            TableView.Source = null;
            TableView.Dispose();
            base.Dispose();
        }

        public class TableSource : UITableViewSource
        {
            protected Dictionary<string, object> TableItems;
            protected ResultViewController ResultViewController;
            protected string CellIdentifier = "TableCell";
            
            public TableSource(object scanResult, ResultViewController parent)
            {
                TableItems = scanResult.CreatePropertyDictionary();
                ResultViewController = parent;
            }

            public override string TitleForHeader(UITableView tableView, nint section)
            {
                try
                {
                    return TableItems.Keys.ToList().ElementAt((int)section);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return 1;
            }

            public override nint NumberOfSections(UITableView tableView)
            {
                return (nint)TableItems.Keys.Count;
            }
            
            public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
            {
                var o = TableItems.ElementAt(indexPath.Section).Value;

                if (o is UIImage)
                {
                    var img = o as UIImage;

                    var w = tableView.Bounds.Width;
                    var h = (float)tableView.Bounds.Width / ((float)img.CGImage.Width / (float)img.CGImage.Height);

                    return h;
                } else
                {
                    var fontSize = GetCell(tableView, indexPath).TextLabel.Font.PointSize;
                    var rows = o.ToString().Split(Environment.NewLine).Length;
                    return 44 + (rows - 1) * fontSize;
                }
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var o = TableItems.ElementAt(indexPath.Section).Value;

                var cell = tableView.DequeueReusableCell(CellIdentifier);
                if (cell == null)
                {
                    cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
                    cell.SelectionStyle = UITableViewCellSelectionStyle.None;
                    cell.Accessory = UITableViewCellAccessory.None;
                    cell.AccessoryView = null;
                }

                if (o is UIImage) // for image presentation
                {
                    var image = o as UIImage;
                    cell.BackgroundView = new UIImageView(image);
                    cell.TextLabel.Text = "";
                    cell.TextLabel.Lines = 1;

                }
                else // for text presentation
                {
                    cell.BackgroundView = null;

                    // set text label
                    cell.TextLabel.Text = o.ToString();
                    cell.TextLabel.LineBreakMode = UILineBreakMode.WordWrap;

                    // translante linebreaks in strings to number of lines
                    var split = o.ToString().Split(Environment.NewLine);
                    var numberOfLines = cell.TextLabel.Lines + split.Length;
                    cell.TextLabel.Lines = numberOfLines;
                }
                
                return cell;
            }
            
            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
            }

            new void Dispose()
            {
                foreach(var i in TableItems)
                {
                    (i.Value as NSObject).Dispose();
                }
                TableItems.Clear();
                TableItems = null;
                base.Dispose();
            }
        };

    };
}