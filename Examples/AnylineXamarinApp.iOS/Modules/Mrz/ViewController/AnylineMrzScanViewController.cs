using System;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AnylineXamarinApp.iOS.Modules.Mrz.ViewController
{
    public sealed class AnylineMrzScanViewController : UIViewController, IAnylineMRZModuleDelegate
    {
        readonly string _licenseKey = AnylineViewController.LicenseKey;

        AnylineMRZModuleView _anylineMrzView;
        AnylineIdentificationView _idView;
        NSError _error;
        bool _success;
        bool _isScanning;
        public UIAlertView Alert { get; private set; }

        public AnylineMrzScanViewController (string name)
        {
            Title = name;
        }
        
        public override void ViewDi

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Initializing the MRZ module.
            CGRect frame = UIScreen.MainScreen.ApplicationFrame;
            frame = new CGRect(frame.X,
                frame.Y + NavigationController.NavigationBar.Frame.Size.Height,
                frame.Width,
                frame.Height - NavigationController.NavigationBar.Frame.Size.Height);

            _anylineMrzView = new AnylineMRZModuleView(frame);
            
            _error = null;
            // We tell the module to bootstrap itself with the license key and delegate. The delegate will later get called
            // by the module once we start receiving results.
            _success = _anylineMrzView.SetupWithLicenseKey(_licenseKey, Self, out _error);
            // SetupWithLicenseKey:delegate:error returns true if everything went fine. In the case something wrong
            // we have to check the error object for the error message.
            if (!_success)
            {
                // Something went wrong. The error object contains the error description
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }
            
            // After setup is complete we add the module to the view of this view controller
            View.AddSubview(_anylineMrzView);

            //we'll manually cancel scanning
            _anylineMrzView.CancelOnResult = false;

            //set strict mode here
            //_anylineMrzView.StrictMode = true;

            /*
             ALIdentificationView will present the scanned values. Here we start listening for taps
             to later dismiss the view.
             */
            _idView = new AnylineIdentificationView(new CGRect(0, 0, 300, 300/1.4f));
            _idView.AddGestureRecognizer(new UITapGestureRecognizer(this, new ObjCRuntime.Selector("ViewTapSelector:")));
            
            _idView.Center = View.Center;
            _idView.Alpha = 0;
            
            View.AddSubview(_idView);
        }

        /*
         Dismiss the view if the user taps the screen
         */
        [Export("ViewTapSelector:")]
        private void AnimateFadeOut(UIGestureRecognizer sender)
        {
            _idView.Transform = CGAffineTransform.MakeScale(1, 1);
            if ((int)_idView.Alpha * 1000 == 1000)
            {
                UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveEaseInOut, () =>
                {
                    _idView.Alpha = 0;
                    _idView.Transform = CGAffineTransform.MakeScale(0, 0);
                }, StartAnyline);
            }
        }

        /*
         This method will be called once the view controller and its subviews have appeared on screen
         */
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            
            // We use this subroutine to start Anyline. The reason it has its own subroutine is
            // so that we can later use it to restart the scanning process.
            StartAnyline();
        }

        /*
         A little animation for the user to see the scanned document.
         */
        private void AnimateFadeIn()
        {
            StopAnyline();

            //View.BringSubviewToFront(idView);

            //properties before animation
            _idView.Center = View.Center;
            _idView.Alpha = 0;
            _idView.Transform = CGAffineTransform.MakeScale ((nfloat)0.2, (nfloat)0.2);

            UIView.Animate(0.3, 0, UIViewAnimationOptions.CurveEaseInOut,
                    () =>
                    {
                        _idView.Alpha = 1;
                        _idView.Transform = CGAffineTransform.MakeScale((nfloat)1.1, (nfloat)1.1);
                    },
                    () =>
                    {
                        UIView.Animate(0.2, 0, UIViewAnimationOptions.CurveEaseInOut,
                            () =>
                            {
                                _idView.Transform = CGAffineTransform.MakeScale(1, 1);
                            }, null);
                    }
            );
        }

        public void StartAnyline()
        {
            if (_anylineMrzView == null) return;
            if (_isScanning) return;

            //send the identification view to the back before we start scanning
            View.SendSubviewToBack(_idView);

            _error = null;
            _success = _anylineMrzView.StartScanningAndReturnError(out _error);
            if (!_success)
            {
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();                
            }
            else
                _isScanning = true;
        }

        public void StopAnyline()
        {
            if (!_isScanning) return;
            _isScanning = false;

            if (_anylineMrzView == null || _idView == null)
                return;

            _error = null;
            if (!_anylineMrzView.CancelScanningAndReturnError(out _error))
            {
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }

            View.BringSubviewToFront(_idView);
        }

        /*
        This is the main delegate method Anyline uses to report its results
        */
        void IAnylineMRZModuleDelegate.DidFindResult(AnylineMRZModuleView anylineMRZModuleView, ALMRZResult scanResult)
        {
            if (_idView == null) return;

            // Because there is a lot of information to be passed along the module
            // uses ALIdentification.
            var identification = scanResult.Result as ALIdentification;
            _idView.UpdateIdentification(identification);
            
            // Present the information to the user
            AnimateFadeIn();
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            // We have to stop scanning before the view dissapears
            StopAnyline();
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            
            Dispose();
        }

        new void Dispose()
        {
            //un-register any event handlers here, if you have any
            
            //remove identification view
            _idView?.RemoveFromSuperview();
            _idView?.Dispose();
            _idView = null;

            //we have to erase the scan view so that there are no dependencies for the viewcontroller left.
            _anylineMrzView?.RemoveFromSuperview();
            _anylineMrzView?.Dispose();
            _anylineMrzView = null;
            
            base.Dispose();
        }
    }
}
