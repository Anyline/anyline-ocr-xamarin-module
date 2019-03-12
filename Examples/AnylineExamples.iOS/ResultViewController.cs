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
        }
        
        public class TableSource : UITableViewSource
        {
            protected Dictionary<string, object> TableItems; // <header string, <result property string or image>
            protected ResultViewController ResultViewController;
            protected string CellIdentifier = "TableCell";
            
            public TableSource(object scanResult, ResultViewController parent)
            {
                Dictionary<string, object> tableItems = CreatePropertyListFromObject(scanResult);
                
                TableItems = tableItems;
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
            
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var o = TableItems.ElementAt(indexPath.Section).Value;
                
                UITableViewCell cell = new UITableViewCell();
                
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
                cell.Accessory = UITableViewCellAccessory.None;

                if (o.GetType() == typeof(UIImage)) // for image presentation
                {
                    var image = o as UIImage;

                    var w = cell.Bounds.Width;
                    var h = cell.Bounds.Width / (image.CGImage.Width / image.CGImage.Height);
                    cell.Bounds = new CoreGraphics.CGRect(cell.Bounds.X, cell.Bounds.Y, w, h);

                    // set image view
                    cell.ImageView.Image = image;
                    cell.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;

                }
                else // for text presentation
                {
                    // set text label
                    cell.TextLabel.Text = o.ToString();
                    cell.TextLabel.LineBreakMode = UILineBreakMode.WordWrap;

                    // translante linebreaks in strings to number of lines
                    var split = o.ToString().Split('\n');
                    var numberOfLines = split.Length;

                    cell.TextLabel.Lines = numberOfLines;
                }

                cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

                return cell;
            }
            
            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
            }
            
            // dynamically creates the result dictionary for the table view from any object
            private Dictionary<string, object> CreatePropertyListFromObject(object obj)
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();

                if (obj is UIImage)
                {
                    dict.Add("UIImage", obj);
                }
                else
                {
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        switch (prop.Name)
                        {
                            // filter out properties that we don't want to display
                            case "Handle":
                            case "PeerReference":
                            case "Outline":
                            case "Class":
                            case "Self":
                            case "ClassHandle":
                            case "Description":
                            case "DebugDescription":
                            case "IsProxy":
                            case "RetainCount":
                            case "Superclass":
                            case "Zone":
                            case "SuperHandle":
                                break;
                            default:

                                var value = prop.GetValue(obj, null);

                                Debug.WriteLine("{0}: {1}", prop.Name, value);
                                if (value != null)
                                {
                                    if (value is ALMRZIdentification || value is ALDrivingLicenseIdentification)
                                    //|| value is ALGERMANFRONTIDIDENTIFICATON!!!)
                                    {
                                        var subDict = CreatePropertyListFromObject(value);
                                        foreach (var sd in subDict)
                                        {
                                            dict.Add(sd.Key, sd.Value);
                                        }
                                    }
                                    else if (value is UIImage && value != null)
                                    {
                                        dict.Add(prop.Name, value);
                                    }
                                    else if (value.ToString() != "")
                                    {
                                        var str = value.ToString().Replace("\\n", Environment.NewLine);
                                        dict.Add(prop.Name, str);
                                    }
                                }
                                break;
                        }
                    }
                }
                    return dict;
            }
        };

    };
}