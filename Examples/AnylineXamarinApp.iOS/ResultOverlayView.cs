using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UIKit;

namespace AnylineXamarinApp.iOS
{
    class ResultOverlayView : UIView
    {
        public UILabel Result { get; set; }        
        private UIImageView backgroundView;

        public ResultOverlayView() : base()
        {
            SetupView();
        }

        public ResultOverlayView(CGRect frame, UIImage backgroundImage) : base(frame)
        {
            //background:
            if (backgroundImage != null)
            {                
                backgroundView = new UIImageView(new CGRect(0, 0, 320, frame.Size.Height));
                backgroundView.Image = backgroundImage;
                backgroundView.ContentMode = UIViewContentMode.ScaleAspectFit;
                backgroundView.Center = new CGPoint(frame.Width / 2, frame.Height / 2);

                AddSubview(backgroundView);
                SendSubviewToBack(backgroundView);
            }

            SetupView();
        }

        private void SetupView()
        {            
            //label:

            nfloat lx = 250;
            nfloat ly = 160;
        
            nfloat rx = backgroundView.Center.X - lx/2;
            nfloat ry = backgroundView.Center.Y - ly/2;
        
            nfloat width  = lx;
            nfloat height = ly;
        
            Result = new UILabel(new CGRect(rx,ry,width,height));
            Result.Text = "--result--";
            Result.TextColor = UIColor.Black;
            Result.TextAlignment = UITextAlignment.Center;
            Result.AdjustsFontSizeToFitWidth = true;
            Result.Font = UIFont.BoldSystemFontOfSize(20);

            AddSubview(Result);

        }
        
        public void UpdateResult(string result)
        {            
            Result.Text = result;
        }

        /*
         A little fade-in animation.
         */
        public void AnimateFadeIn(UIView parent)
        {            
            //properties before animation
            Center = parent.Center;
            Alpha = 0;
            Transform = CGAffineTransform.MakeScale((nfloat)0.2, (nfloat)0.2);

            Animate(0.3, 0, UIViewAnimationOptions.CurveEaseInOut, () =>
            {
                Alpha = 1;
                Transform = CGAffineTransform.MakeScale((nfloat)1.1, (nfloat)1.1);
            },
            () =>
            {
                Animate(0.2, 0, UIViewAnimationOptions.CurveEaseInOut, () =>
                {
                    Transform = CGAffineTransform.MakeScale((nfloat)1, (nfloat)1);
                }, null);
            });
        }

        /*
         Fade-out animation and action after finishing the animation.
         */
        public void AnimateFadeOut(UIView parent, Action resultAction)
        {
            Transform = CGAffineTransform.MakeScale((nfloat)1, (nfloat)1);
            if (Alpha == 1.0)
            {
                Animate(0.5, 0, UIViewAnimationOptions.CurveEaseInOut, () =>
                {
                    Alpha = 0;
                    Transform = CGAffineTransform.MakeScale((nfloat)0, (nfloat)0);
                }, resultAction);
            }
        }
    }
}
