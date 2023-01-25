using CoreGraphics;
using Foundation;
using GameController;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using UIKit;

namespace AnylineExamples.iOS
{
    public class ResultViewController : UIViewController
    {
        Dictionary<string, object> _scanResult;

        public ResultViewController(object scanResult, string title)
        {
            // in our example app, we dynamically extract result values from the object via reflection.
            // For your use-case, you can access the properties directly
            _scanResult = scanResult.CreatePropertyDictionary();

            Title = "Results";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.LeftBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Done, (sender, args) =>
            {
                NavigationController?.PopViewController(false);
            });

        }

        nfloat height = 0;
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var scrollView = new UIScrollView(View.Bounds)
            {
                BackgroundColor = UIColor.White,
                AutoresizingMask = UIViewAutoresizing.FlexibleDimensions
            };
            View.AddSubview(scrollView);

            UIView resultView = CreateResultView(_scanResult);
            scrollView.AddSubview(resultView);

            resultView.LayoutIfNeeded();

            scrollView.ContentSize = new CGSize(resultView.Frame.Width, resultView.Frame.Height);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            Dispose();
        }

        new void Dispose()
        {
            base.Dispose();
        }

        private UIView CreateResultView(Dictionary<string, object> dict)
        {
            List<UIStackView> stackViewList = new List<UIStackView>();
            UIStackView stackContent = new UIStackView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Alignment = UIStackViewAlignment.Fill,
                Distribution = UIStackViewDistribution.FillProportionally,
                Axis = UILayoutConstraintAxis.Vertical,
                Spacing = 0,
                ClipsToBounds = true,
                LayoutMargins = UIEdgeInsets.Zero
            };

            int indexResult = 0;
            foreach (var item in dict)
            {
                bool darkMode = TraitCollection.UserInterfaceStyle == UIUserInterfaceStyle.Dark;

                UIStackView stackView = new UIStackView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Alignment = UIStackViewAlignment.Fill,
                    Distribution = UIStackViewDistribution.FillProportionally,
                    Axis = UILayoutConstraintAxis.Vertical,
                    Spacing = 0,
                    BackgroundColor = darkMode ? UIColor.FromRGB(0, 0, 0) : UIColor.FromRGB(247, 247, 247),
                    ClipsToBounds = true,
                    LayoutMarginsRelativeArrangement = true,
                };

                stackView.LayoutMargins = new UIEdgeInsets(0, 20, 0, 20);

                indexResult++;
                stackView.AddArrangedSubview(new UIView(new CoreGraphics.CGRect(0, 0, 50, 50)));

                UILabel lbPluginName = new UILabel()
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Text = item.Key.ToString(),
                    LineBreakMode = UILineBreakMode.WordWrap,
                    Font = UIFont.BoldSystemFontOfSize(15),
                    TextColor = UIColor.FromRGB(0, 122, 255),
                    AutoresizingMask = UIViewAutoresizing.FlexibleHeight
                };
                stackView.AddArrangedSubview(lbPluginName);
                height += 50;

                if (item.Value is byte[] imageBytes)
                {
                    using (NSData imageData = NSData.FromArray(imageBytes))
                    {
                        UIImage image = new UIImage(imageData);

                        UIImageView iv;
                        if (image.Size.Width > View.LayoutMarginsGuide.LayoutFrame.Width)
                        {
                            image = ResizeImage(image, View.LayoutMarginsGuide.LayoutFrame.Width);
                        }
                        iv = new UIImageView(image);
                        iv.ContentMode = UIViewContentMode.Center;
                        stackView.AddArrangedSubview(iv);
                    }
                    height += 150;
                }
                else if (item.Value is Dictionary<string, object> subItems)
                {
                    stackView.AddArrangedSubview(CreateResultView(subItems));
                }
                else
                {
                    UILabel lbPropertyValue = new UILabel()
                    {
                        TranslatesAutoresizingMaskIntoConstraints = false,
                        Text = item.Value.ToString(),
                        LineBreakMode = UILineBreakMode.WordWrap,
                        Lines = 2,
                        TextColor = darkMode ? UIColor.White : UIColor.Black,
                        Font = UIFont.BoldSystemFontOfSize(17),
                    };
                    stackView.AddArrangedSubview(lbPropertyValue);
                    height += 50;
                }
                stackViewList.Add(stackView);
            }

            foreach (var stack in stackViewList)
            {
                stackContent.AddArrangedSubview(stack);
            }

            //// define constraints for the content of the Serial Scanning results
            //NSLayoutConstraint.Create(stackContent, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, this, NSLayoutAttribute.LeadingMargin, 1.0f, 0.0f).Active = true;
            //NSLayoutConstraint.Create(stackContent, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, this, NSLayoutAttribute.TrailingMargin, 1.0f, 0.0f).Active = true;

            //NSLayoutConstraint.Create(stackContent, NSLayoutAttribute.Width, NSLayoutRelation.Equal, this, NSLayoutAttribute.Width, 1.0f, 0.0f).Active = true;
            //NSLayoutConstraint.Create(stackContent, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this, NSLayoutAttribute.Left, 1.0f, 0.0f).Active = true;

            //// define constraints for stacking each plugin after the previous one
            //for (int i = 0; i < stackViewList.Count; i++)
            //{
            //    if (i == 0)
            //    {
            //        stackViewList[i].LeadingAnchor.ConstraintEqualTo(stackContent.LeadingAnchor).Active = true;
            //        if (!UIDevice.CurrentDevice.CheckSystemVersion(12, 0))
            //            stackViewList[i].TopAnchor.ConstraintEqualTo(stackContent.TopAnchor).Active = true;
            //    }
            //    else if (i == stackViewList.Count - 1)
            //    {
            //        stackViewList[i].TrailingAnchor.ConstraintEqualTo(stackContent.TrailingAnchor).Active = true;
            //        if (!UIDevice.CurrentDevice.CheckSystemVersion(12, 0))
            //            stackViewList[i].BottomAnchor.ConstraintEqualTo(stackContent.BottomAnchor).Active = true;
            //    }
            //    else
            //    {
            //        stackViewList[i].LeadingAnchor.ConstraintEqualTo(stackViewList[i - 1].TrailingAnchor).Active = true;
            //        if (!UIDevice.CurrentDevice.CheckSystemVersion(12, 0))
            //            stackViewList[i].TopAnchor.ConstraintEqualTo(stackViewList[i - 1].BottomAnchor).Active = true;
            //    }
            //}

            return stackContent;
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

        // this cell represents the results of a Composite scan
        // for this example we work with 'object' results so any combination of plugins can be used
        // usually you would just cast the results to the object type that matches your ScanPlugin types
        public class ResultsView : UIView
        {
            public ResultsView(IntPtr p) : base(p)
            {

            }

            public ResultsView(Dictionary<string, object> results)
            {

                List<UIStackView> stackViewList = new List<UIStackView>();
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

                bool darkMode = TraitCollection.UserInterfaceStyle == UIUserInterfaceStyle.Dark;
                BackgroundColor = darkMode ? UIColor.FromRGB(0, 0, 0) : UIColor.FromRGB(247, 247, 247);
                ClipsToBounds = true;
                LayoutMargins = UIEdgeInsets.Zero;

                int indexResult = 0;
                foreach (var result in results)
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
                        Text = result.Key.ToString(),
                        TextAlignment = UITextAlignment.Center,
                        Font = UIFont.BoldSystemFontOfSize(26),
                        TextColor = UIColor.FromRGB(0, 122, 255),
                        AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight
                    };
                    stackView.AddArrangedSubview(lbPluginName);

                    if (result.Value is Dictionary<string, object> dictPluginValue)
                    {
                        foreach (var property in dictPluginValue)
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
                    }
                    stackView.AddArrangedSubview(new UIView(new CoreGraphics.CGRect(0, 0, 50, 50)));

                    stackViewList.Add(stackView);
                }
                foreach (var stack in stackViewList)
                {
                    stackContent.AddArrangedSubview(stack);
                }
                Add(stackContent);

                // define constraints for the content of the Serial Scanning results
                NSLayoutConstraint.Create(stackContent, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, this, NSLayoutAttribute.LeadingMargin, 1.0f, 0.0f).Active = true;
                NSLayoutConstraint.Create(stackContent, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, this, NSLayoutAttribute.TrailingMargin, 1.0f, 0.0f).Active = true;

                NSLayoutConstraint.Create(stackContent, NSLayoutAttribute.Width, NSLayoutRelation.Equal, this, NSLayoutAttribute.Width, 1.0f, 0.0f).Active = true;
                NSLayoutConstraint.Create(stackContent, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this, NSLayoutAttribute.Left, 1.0f, 0.0f).Active = true;

                // define constraints for stacking each plugin after the previous one
                for (int i = 0; i < stackViewList.Count; i++)
                {
                    if (i == 0)
                    {
                        stackViewList[i].LeadingAnchor.ConstraintEqualTo(stackContent.LeadingAnchor).Active = true;
                        if (!UIDevice.CurrentDevice.CheckSystemVersion(12, 0))
                            stackViewList[i].TopAnchor.ConstraintEqualTo(stackContent.TopAnchor).Active = true;
                    }
                    else if (i == stackViewList.Count - 1)
                    {
                        stackViewList[i].TrailingAnchor.ConstraintEqualTo(stackContent.TrailingAnchor).Active = true;
                        if (!UIDevice.CurrentDevice.CheckSystemVersion(12, 0))
                            stackViewList[i].BottomAnchor.ConstraintEqualTo(stackContent.BottomAnchor).Active = true;
                    }
                    else
                    {
                        stackViewList[i].LeadingAnchor.ConstraintEqualTo(stackViewList[i - 1].TrailingAnchor).Active = true;
                        if (!UIDevice.CurrentDevice.CheckSystemVersion(12, 0))
                            stackViewList[i].TopAnchor.ConstraintEqualTo(stackViewList[i - 1].BottomAnchor).Active = true;
                    }
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
}


//    /// <summary>
//    /// This TableSource defines how the ResultViewController presents results in a visual way.
//    /// </summary>
//    public class TableSource : UITableViewSource
//    {
//        protected Dictionary<string, object> TableItems;


//        public TableSource(Dictionary<string, object> scanResult, ResultTableViewController parent)
//        {
//            //TableItems = scanResult;
//            TableItems = FlattenDict(scanResult);
//        }

//        int index = 0;
//        private Dictionary<string,object> FlattenDict(Dictionary<string, object> dict)
//        {
//            Dictionary<string, object> flatDict = new Dictionary<string, object>();
//            foreach (var item in dict)
//            {
//                if (item.Value is Dictionary<string, object> innerDict)
//                {
//                    flatDict.Add($"{item.Key}_{index}", FlattenDict(innerDict));
//                }
//                else
//                {
//                    flatDict.Add($"{item.Key}_{index}", item.Value);
//                }
//            }
//            return flatDict;
//        }

//        public override string TitleForHeader(UITableView tableView, nint section)
//        {
//            try
//            {
//                return TableItems.ElementAt((int)section).Key;
//            }
//            catch (Exception)
//            {
//                return null;
//            }
//        }

//        public override nint RowsInSection(UITableView tableview, nint section)
//        {
//            if (TableItems.ElementAt(0).Value is Dictionary<string, object> dict)
//            {
//                return dict.Keys.Count;
//            }
//            return 1;
//        }

//        public override nint NumberOfSections(UITableView tableView)
//        {
//            int count = CountSections(TableItems);
//            return count;
//        }

//        private int CountSections(Dictionary<string, object> dict)
//        {
//            int number = 0;
//            foreach (var item in dict)
//            {
//                if (item.Value is Dictionary<string, object> innerDict)
//                {
//                    number = number + CountSections(innerDict);
//                }
//                else
//                {
//                    number++;
//                }
//            }
//            return number;
//        }

//        //public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
//        //{
//            //var result = TableItems.ElementAt(indexPath.Section).Value;

//            //if (TableItems.ElementAt(indexPath.Section).Value is Dictionary<string, object> plugin)
//            //{
//            //    nfloat height = 0;
//            //    foreach (var pluginResult in plugin)
//            //    {
//            //        if (pluginResult.Value is Dictionary<string, object> dictPluginResultValue)
//            //        {
//            //            foreach (var property in dictPluginResultValue)
//            //            {
//            //                if (property.Value is UIImage img)
//            //                {
//            //                    nfloat oldWidth = img.Size.Width;
//            //                    nfloat scaleFactor = (tableView.Frame.Width / oldWidth);

//            //                    nfloat finalHeight = img.Size.Height * scaleFactor;
//            //                    nfloat scalingCorrection = 360 * (1 - scaleFactor);
//            //                    height += finalHeight + scalingCorrection;
//            //                }
//            //                else
//            //                {
//            //                    height += 64;
//            //                }
//            //            }
//            //        }
//            //    }
//            //    return height;
//            //}
//            //else
//            //{
//                //if (result is UIImage img)
//                //{
//                //    var w = tableView.Bounds.Width;
//                //    var h = (float)tableView.Bounds.Width / ((float)img.CGImage.Width / (float)img.CGImage.Height);

//                //    return h;
//                //}
//                //else
//                //{
//                //    var fontSize = GetCell(tableView, indexPath).TextLabel.Font.PointSize;
//                //    var rows = result.ToString().Split(Environment.NewLine).Length;
//                //    return 44 + (rows - 1) * fontSize;
//                //}
//            //}
//        //}

//        //public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
//        //{
//            //var currentItem = TableItems.ElementAt(indexPath.Section).Value;

//            //if (currentItem is Dictionary<string, object> plugins)
//            //{
//            //    var pluginCell = tableView.DequeueReusableCell(ScanResultsDictionaryTableCellIdentifier) as PluginResultsCell;
//            //    pluginCell = new PluginResultsCell(plugins, tableView);
//            //    return pluginCell;
//            //}

//            //var cell = tableView.DequeueReusableCell(ScanResultsTableCellIdentifier);
//            //if (cell == null)
//            //{
//            //    cell = new UITableViewCell(UITableViewCellStyle.Default, ScanResultsTableCellIdentifier);
//            //    cell.SelectionStyle = UITableViewCellSelectionStyle.None;
//            //    cell.Accessory = UITableViewCellAccessory.None;
//            //    cell.AccessoryView = null;
//            //}

//            //if (currentItem is UIImage image)
//            //{
//            //    cell.BackgroundView = new UIImageView(image);
//            //    cell.TextLabel.Text = "";
//            //    cell.TextLabel.Lines = 1;
//            //}
//            //else
//            //{
//            //    cell.BackgroundView = null;

//            //    // set text label
//            //    cell.TextLabel.Text = currentItem.ToString();
//            //    cell.TextLabel.LineBreakMode = UILineBreakMode.WordWrap;

//            //    // translante linebreaks in strings to number of lines
//            //    var split = currentItem.ToString().Split(Environment.NewLine);
//            //    var numberOfLines = cell.TextLabel.Lines + split.Length;
//            //    cell.TextLabel.Lines = numberOfLines;
//            //}

//            //return cell;
//        //}

//        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
//        {
//        }

//        new void Dispose()
//        {
//            foreach (var i in TableItems)
//            {
//                (i.Value as NSObject).Dispose();
//            }
//            TableItems.Clear();
//            TableItems = null;
//            base.Dispose();
//        }
//    };
//};
