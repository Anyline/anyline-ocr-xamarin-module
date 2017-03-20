using System;
using CoreGraphics;
using UIKit;

namespace AnylineXamarinApp.iOS.Modules.Document.View
{
    /*
     * Custom Label
     */

    sealed class NotificationView : UIView
    {

        public UILabel TextLabel;
        private readonly nfloat _cornerRadius;
        
        public CGColor FillColor;
        public CGColor BorderColor;
        
        public NotificationView(CGRect frame)
            : base(frame)
        {
            // Initialization code
            TextLabel = new UILabel(new CGRect(0, 0, frame.Size.Width, frame.Size.Height))
            {
                BackgroundColor = UIColor.Clear,
                TextAlignment = UITextAlignment.Center,
                TextColor = UIColor.White
            };

            AddSubview(TextLabel);

            BackgroundColor = UIColor.Clear;

            BorderColor = UIColor.Clear.CGColor;
            FillColor = UIColor.Yellow.CGColor;
            
            _cornerRadius = 15;
            Opaque = false;
        }

        public override void Draw(CGRect rect)
        {            
            using (var context = UIGraphics.GetCurrentContext())
            {
                context.SetLineWidth(4);
                context.SetFillColor(FillColor);
                context.SetStrokeColor(BorderColor);
                
                var roundedRect = UIBezierPath.FromRoundedRect(rect, _cornerRadius);

                context.AddPath(roundedRect.CGPath);

                context.DrawPath(CGPathDrawingMode.FillStroke);

                roundedRect.Dispose();
            }
        }
    }
}
