using CoreGraphics;
using System;
using UIKit;

namespace AnylineXamarinApp.iOS
{
    class DrivingLicenseResultOverlayView : UIView, IDisposable
    {
        public UILabel Birthdate { get; set; }
        public UILabel Surname { get; set; }
        public UILabel Surname2 { get; set; }
        public UILabel GivenNames { get; set; }
        public UILabel IDNumber { get; set; }
        
        private UIImageView _backgroundView;
        private bool _disposed;

        public DrivingLicenseResultOverlayView() : base()
        {
            SetupView();
        }

        public DrivingLicenseResultOverlayView(CGRect frame) : base(frame)
        {

            UIImage backgroundImage = UIImage.FromBundle(@"drawable/driving_license_background.png");

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
            var y = 10 + (_backgroundView.Frame.Height * _backgroundView.Image.CurrentScale) / 4;

            Surname = new UILabel(new CGRect(130, y + 80, 200, 20));
            AddSubview(Surname);

            Surname2 = new UILabel(new CGRect(130, y + 100, 200, 20));
            AddSubview(Surname2);

            GivenNames = new UILabel(new CGRect(130, y + 120, 200, 20));
            AddSubview(GivenNames);

            Birthdate = new UILabel(new CGRect(130, y + 140, 200, 20));
            AddSubview(Birthdate);

            IDNumber = new UILabel(new CGRect(130, y+ 160, 200, 20));
            AddSubview(IDNumber);            
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
                    if (Birthdate != null)
                        Birthdate.Dispose();
                    if (Surname != null)
                        Surname.Dispose();
                    if (Surname2 != null)
                        Surname2.Dispose();
                    if (GivenNames != null)
                        GivenNames.Dispose();
                    if (IDNumber != null)
                        IDNumber.Dispose();

                    if (_backgroundView != null)
                        _backgroundView.Dispose();
                }

                // Indicate that the instance has been disposed.
                Birthdate = null;
                Surname = null;
                Surname2 = null;
                GivenNames = null;
                IDNumber = null;
                _backgroundView = null;

                _disposed = true;
            }
        }
    }
}
