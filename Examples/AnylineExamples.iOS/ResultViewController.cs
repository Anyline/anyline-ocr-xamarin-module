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

            EdgesForExtendedLayout = UIRectEdge.None;
        }

        nfloat height = 0;
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            var scrollView = new UIScrollView(View.Bounds) {  };
            View.AddSubview(scrollView);

            UIView resultView = CreateResultView(_scanResult);
            scrollView.AddSubview(resultView);

            NSLayoutConstraint.Create(resultView, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, View, NSLayoutAttribute.LeadingMargin, 1.0f, 0.0f).Active = true;
            NSLayoutConstraint.Create(resultView, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, View, NSLayoutAttribute.TrailingMargin, 1.0f, 0.0f).Active = true;

            NSLayoutConstraint.Create(resultView, NSLayoutAttribute.Width, NSLayoutRelation.Equal, View, NSLayoutAttribute.Width, 1.0f, 0.0f).Active = true;
            NSLayoutConstraint.Create(resultView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1.0f, 0.0f).Active = true;

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
            bool darkMode = TraitCollection.UserInterfaceStyle == UIUserInterfaceStyle.Dark;

            var stackContent = new UIStackView(View.Bounds)
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Axis = UILayoutConstraintAxis.Vertical,
                Spacing = 5,
                LayoutMarginsRelativeArrangement = true,
                DirectionalLayoutMargins = new NSDirectionalEdgeInsets(10, 10, 0, 10),
                BackgroundColor = darkMode ? UIColor.FromRGB(0, 0, 0) : UIColor.FromRGB(247, 247, 247)
            };

            foreach (var item in dict)
            {
                var attributedString = new NSMutableAttributedString(item.Key);
                int spaceIndex = item.Key.IndexOf(" ");
                attributedString.AddAttribute(UIStringAttributeKey.Font, UIFont.BoldSystemFontOfSize(14), new NSRange(0, spaceIndex));
                attributedString.AddAttribute(UIStringAttributeKey.Font, UIFont.SystemFontOfSize(9), new NSRange(spaceIndex + 1, item.Key.Length - spaceIndex - 1));

                UILabel lbPluginName = new UILabel()
                {
                    AttributedText = attributedString,
                    LineBreakMode = UILineBreakMode.WordWrap,
                    Lines = 0,
                    TextColor = UIColor.FromRGB(0, 122, 255),
                };
                stackContent.AddArrangedSubview(lbPluginName);

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
                        stackContent.AddArrangedSubview(iv);
                    }
                }
                else if (item.Value is Dictionary<string, object> subItems)
                {
                    stackContent.AddArrangedSubview(CreateResultView(subItems));
                }
                else
                {
                    UILabel lbPropertyValue = new UILabel()
                    {
                        Text = item.Value.ToString(),
                        LineBreakMode = UILineBreakMode.WordWrap,
                        Lines = 0,
                        TextColor = darkMode ? UIColor.White : UIColor.Black,
                        Font = UIFont.BoldSystemFontOfSize(17),
                    };
                    stackContent.AddArrangedSubview(lbPropertyValue);
                }
            }

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
    }
}