using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;

namespace AnylineXamarinApp.iOS
{
    class LicensePlateResultOverlayView : ResultOverlayView
    {
        public UILabel Country { get; set; }

        public LicensePlateResultOverlayView(CGRect frame, UIImage backgroundImage) : base(frame, backgroundImage)
        {
            SetupView();
        }

        private void SetupView()
        {
            //label:
            
            nfloat rx = Result.Frame.X;
            nfloat ry = Result.Frame.Y;

            nfloat width = Result.Frame.Width;
            nfloat height = Result.Frame.Height;

            Country = new UILabel(new CGRect(rx, ry, width, height));
            Country.Text = "--";
            Country.TextColor = UIColor.White;
            Country.TextAlignment = UITextAlignment.Center;
            Country.AdjustsFontSizeToFitWidth = true;
            Country.Font = UIFont.BoldSystemFontOfSize(12);

            AddSubview(Country);

        }

        public void UpdateCountry(string country)
        {
            Country.Text = country;
        }
    }
}