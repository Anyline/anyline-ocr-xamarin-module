using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace AnylineExamples.iOS
{
    public class ResultViewController : UITableViewController
    {
        // we store the scan result as an object
        Dictionary<string, object> scanResult;
        public static string ScanResultsTableCellIdentifier { get; } = "ScanResultsTableCell";
        public static string ScanResultsDictionaryTableCellIdentifier { get; } = "ScanResultsDictionaryTableCell";

        public ResultViewController(object scanResult)
        {
            // in our example app, we dynamically extract result values from the object via reflection.
            // Usually, you can just cast the result to the object type that matches your ScanPlugin type (e.g. ALMeterResult for ALMeterScanPlugin etc.) and access the properties directly
            this.scanResult = scanResult.CreatePropertyDictionary();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView = new UITableView(View.Bounds, UITableViewStyle.Grouped);
            TableView.Source = new TableSource(scanResult, this);
            // this cell is responsible for displaying the scanning results
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), ScanResultsTableCellIdentifier);
            // this cell only necessary for the Serial Scanning, as it contains multiple plugin results
            TableView.RegisterClassForCellReuse(typeof(PluginResultsCell), ScanResultsDictionaryTableCellIdentifier);
            TableView.AllowsSelection = false;
            NavigationItem.LeftBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Done, (sender, args) =>
            {
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

        /// <summary>
        /// This TableSource defines how the ResultViewController presents results in a visual way.
        /// </summary>
        public class TableSource : UITableViewSource
        {
            protected Dictionary<string, object> TableItems;

            public TableSource(Dictionary<string, object> scanResult, ResultViewController parent)
            {
                TableItems = scanResult;
            }

            public override string TitleForHeader(UITableView tableView, nint section)
            {
                try
                {
                    return TableItems.ElementAt((int)section).Key;
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
                var result = TableItems.ElementAt(indexPath.Section).Value;

                if (TableItems.ElementAt(indexPath.Section).Value is Dictionary<string, object> plugin)
                {
                    // a Dictionary result represents a Serial Scanning
                    // we iterate through all different plugin results to find a suitable height for the cell
                    nfloat height = 0;
                    foreach (var pluginResult in plugin)
                    {
                        foreach (var property in pluginResult.Value as Dictionary<string, object>)
                        {
                            if (property.Value is UIImage img)
                            {
                                nfloat oldWidth = img.Size.Width;
                                nfloat scaleFactor = (tableView.Frame.Width / oldWidth);

                                nfloat finalHeight = img.Size.Height * scaleFactor;
                                nfloat scalingCorrection = 360 * (1 - scaleFactor);
                                height += finalHeight + scalingCorrection;
                            }
                            else
                            {
                                height += 64;
                            }
                        }
                    }
                    return height;
                }
                else
                {
                    if (result is UIImage img)
                    {
                        var w = tableView.Bounds.Width;
                        var h = (float)tableView.Bounds.Width / ((float)img.CGImage.Width / (float)img.CGImage.Height);

                        return h;
                    }
                    else
                    {
                        var fontSize = GetCell(tableView, indexPath).TextLabel.Font.PointSize;
                        var rows = result.ToString().Split(Environment.NewLine).Length;
                        return 44 + (rows - 1) * fontSize;
                    }
                }
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var currentItem = TableItems.ElementAt(indexPath.Section).Value;

                if (currentItem is Dictionary<string, object> plugins)
                {
                    var pluginCell = tableView.DequeueReusableCell(ScanResultsDictionaryTableCellIdentifier) as PluginResultsCell;
                    pluginCell = new PluginResultsCell(plugins, tableView);
                    return pluginCell;
                }

                var cell = tableView.DequeueReusableCell(ScanResultsTableCellIdentifier);
                if (cell == null)
                {
                    cell = new UITableViewCell(UITableViewCellStyle.Default, ScanResultsTableCellIdentifier);
                    cell.SelectionStyle = UITableViewCellSelectionStyle.None;
                    cell.Accessory = UITableViewCellAccessory.None;
                    cell.AccessoryView = null;
                }

                if (currentItem is UIImage image)
                {
                    cell.BackgroundView = new UIImageView(image);
                    cell.TextLabel.Text = "";
                    cell.TextLabel.Lines = 1;
                }
                else
                {
                    cell.BackgroundView = null;

                    // set text label
                    cell.TextLabel.Text = currentItem.ToString();
                    cell.TextLabel.LineBreakMode = UILineBreakMode.WordWrap;

                    // translante linebreaks in strings to number of lines
                    var split = currentItem.ToString().Split(Environment.NewLine);
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
                foreach (var i in TableItems)
                {
                    (i.Value as NSObject).Dispose();
                }
                TableItems.Clear();
                TableItems = null;
                base.Dispose();
            }
        };
    };

    // this cell represents the results of a Serial Scanning
    // for this example we work with 'object' results so any combination of plugins can be used
    // usually you would just cast the results to the object type that matches your ScanPlugin types
    public class PluginResultsCell : UITableViewCell
    {
        private Dictionary<string, object> plugins;
        private UITableView tableView;
        private List<UIStackView> stackViewList = new List<UIStackView>();
        UIStackView stackContent = new UIStackView
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            Alignment = UIStackViewAlignment.Fill,
            Distribution = UIStackViewDistribution.FillProportionally,
            Axis = UILayoutConstraintAxis.Vertical,
            Spacing = 20,
            ClipsToBounds = true,
            LayoutMargins = UIEdgeInsets.Zero
        };

        public PluginResultsCell(IntPtr p) : base(p)
        {

        }

        public PluginResultsCell(Dictionary<string, object> plugins, UITableView tableView)
        {
            this.plugins = plugins;
            this.tableView = tableView;

            bool darkMode = TraitCollection.UserInterfaceStyle == UIUserInterfaceStyle.Dark;

            BackgroundColor = darkMode ? UIColor.FromRGB(0, 0, 0) : UIColor.FromRGB(247, 247, 247);
            ClipsToBounds = true;
            LayoutMargins = UIEdgeInsets.Zero;

            int indexResult = 0;
            foreach (var plugin in plugins)
            {
                UIStackView stackView = new UIStackView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Alignment = UIStackViewAlignment.Fill,
                    Distribution = UIStackViewDistribution.FillProportionally,
                    Axis = UILayoutConstraintAxis.Vertical,
                    Spacing = 12
                };
                stackView.LayoutMarginsRelativeArrangement = true;
                stackView.LayoutMargins = new UIEdgeInsets(0, 20, 0, 20);

                indexResult++;
                stackView.AddArrangedSubview(new UIView(new CoreGraphics.CGRect(0, 0, 50, 50)));
                UILabel lbPluginName = new UILabel()
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Text = plugin.Key.ToString(),
                    TextAlignment = UITextAlignment.Center,
                    Font = UIFont.BoldSystemFontOfSize(26),
                    TextColor = UIColor.FromRGB(0, 122, 255)
                };
                stackView.AddArrangedSubview(lbPluginName);


                foreach (var property in plugin.Value as Dictionary<string, object>)
                {
                    UILabel lbPropertyKey = new UILabel()
                    {
                        TranslatesAutoresizingMaskIntoConstraints = false,
                        Text = property.Key,
                        TextColor = darkMode ? UIColor.White : UIColor.Black,
                        Font = UIFont.SystemFontOfSize(16)
                    };
                    stackView.AddArrangedSubview(lbPropertyKey);

                    if (property.Value is UIImage image)
                    {
                        UIImageView iv;
                        if (image.Size.Width > LayoutMarginsGuide.LayoutFrame.Width)
                        {
                            image = ResizeImage(image, LayoutMarginsGuide.LayoutFrame.Width);
                        }
                        iv = new UIImageView(image);
                        iv.ContentMode = UIViewContentMode.Center;
                        stackView.AddArrangedSubview(iv);
                    }
                    else
                    {
                        UILabel lbPropertyValue = new UILabel()
                        {
                            TranslatesAutoresizingMaskIntoConstraints = false,
                            Text = property.Value.ToString(),
                            LineBreakMode = UILineBreakMode.WordWrap,
                            Lines = 2,
                            TextColor = darkMode ? UIColor.White : UIColor.Black,
                            Font = UIFont.BoldSystemFontOfSize(17),
                        };
                        stackView.AddArrangedSubview(lbPropertyValue);
                    }
                }
                stackView.AddArrangedSubview(new UIView(new CoreGraphics.CGRect(0, 0, 50, 50)));
                stackViewList.Add(stackView);
            }
            foreach (var stack in stackViewList)
            {
                stackContent.AddArrangedSubview(stack);
            }
            ContentView.AddSubview(stackContent);

            // define constraints for the content of the Serial Scanning results
            NSLayoutConstraint.Create(stackContent, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, this, NSLayoutAttribute.LeadingMargin, 1.0f, 0.0f).Active = true;
            NSLayoutConstraint.Create(stackContent, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, this, NSLayoutAttribute.TrailingMargin, 1.0f, 0.0f).Active = true;

            NSLayoutConstraint.Create(stackContent, NSLayoutAttribute.Width, NSLayoutRelation.Equal, this, NSLayoutAttribute.Width, 1.0f, 0.0f).Active = true;
            NSLayoutConstraint.Create(stackContent, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this, NSLayoutAttribute.Left, 1.0f, 0.0f).Active = true;

            // define constraints for stacking each plugin after the previous one
            for (int i = 0; i < stackViewList.Count; i++)
            {
                if (i == 0)
                    stackViewList[i].LeadingAnchor.ConstraintEqualTo(stackContent.LeadingAnchor).Active = true;
                else if (i == stackViewList.Count - 1)
                    stackViewList[i].TrailingAnchor.ConstraintEqualTo(stackContent.TrailingAnchor).Active = true;
                else
                    stackViewList[i].LeadingAnchor.ConstraintEqualTo(stackViewList[i - 1].TrailingAnchor).Active = true;
            }
        }

        private UIImage ResizeImage(UIImage image, nfloat marginWidth)
        {
            nfloat oldWidth = image.Size.Width;
            nfloat scaleFactor = (marginWidth / oldWidth);

            nfloat newHeight = image.Size.Height * scaleFactor;
            nfloat newWidth = oldWidth * scaleFactor;
            UIGraphics.BeginImageContext(new CoreGraphics.CGSize(newWidth, newHeight));
            image.Draw(new CoreGraphics.CGRect(0, 0, newWidth, newHeight));
            UIImage newImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return newImage;
        }
    }
}