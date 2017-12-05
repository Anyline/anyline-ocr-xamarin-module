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
    class ResultOverlayView : UIView, IDisposable
    {
        public UILabel Result { get; set; }

        private UIImageView _backgroundView;
        private bool _disposed;

        public ResultOverlayView() : base()
        {
            SetupView();
        }

        public ResultOverlayView(CGRect frame, UIImage backgroundImage) : base(frame)
        {
            //background:
            if (backgroundImage != null)
            {                
                _backgroundView = new UIImageView(new CGRect(0, 0, 320, frame.Size.Height));
                _backgroundView.Image = backgroundImage;
                _backgroundView.ContentMode = UIViewContentMode.ScaleAspectFit;
                _backgroundView.Center = new CGPoint(frame.Width / 2, frame.Height / 2);

                AddSubview(_backgroundView);
                SendSubviewToBack(_backgroundView);
            }

            SetupView();
        }

        private void SetupView()
        {            
            //label:

            nfloat lx = 250;
            nfloat ly = 160;
        
            nfloat rx = _backgroundView.Center.X - lx/2;
            nfloat ry = _backgroundView.Center.Y - ly/2;
        
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

        public new void Dispose()
        {
            Dispose(true);

            // Use SupressFinalize in case a subclass
            // of this type implements a finalizer.
            GC.SuppressFinalize(this);
        }

        protected override void Dispose(bool disposing)
        {
            // If you need thread safety, use a lock around these 
            // operations, as well as in your methods that use the resource.
            if (!_disposed)
            {
                if (disposing)
                {
                    if (Result != null)
                        Result.Dispose();

                    if (_backgroundView != null)
                        _backgroundView.Dispose();
                }

                // Indicate that the instance has been disposed.
                Result = null;
                _backgroundView = null;

                _disposed = true;
            }
        }
    }
}
