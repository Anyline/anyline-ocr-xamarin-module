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

        UIView _toggleStrictModeView;
        UILabel _toggleStrictModeLabel;
        UISwitch _toggleStrictModeSwitch;

        UIView _toggleCropAndTransformIDView;
        UILabel _toggleCropAndTransformIDLabel;
        UISwitch _toggleCropAndTransformIDSwitch;

        CGRect _frame;
        
        UIImageView _mrzResultImageView;

        public AnylineMrzScanViewController (string name)
        {
            Title = name;
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Initializing the MRZ module.
            _frame = UIScreen.MainScreen.ApplicationFrame;
            _frame = new CGRect(_frame.X,
                _frame.Y + NavigationController.NavigationBar.Frame.Size.Height,
                _frame.Width,
                _frame.Height - NavigationController.NavigationBar.Frame.Size.Height);

            _anylineMrzView = new AnylineMRZModuleView(_frame);
            
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
            
            /*
             ALIdentificationView will present the scanned values. Here we start listening for taps
             to later dismiss the view.
             */
            _idView = new AnylineIdentificationView(new CGRect(0, 0, 300, 300/1.4f));
            _idView.AddGestureRecognizer(new UITapGestureRecognizer(this, new ObjCRuntime.Selector("ViewTapSelector:")));
            
            _idView.Center = View.Center;
            _idView.Alpha = 0;
            
            View.AddSubview(_idView);

            // Create a subview for toggling strict mode

            _toggleStrictModeView = new UIView(new CGRect(0, 0, 150, 50));
            _toggleStrictModeLabel = new UILabel(new CGRect(0, 0, 100, 30));
            _toggleStrictModeLabel.Text = "Strict Mode";
            _toggleStrictModeLabel.TextColor = UIColor.White;
            _toggleStrictModeLabel.SizeToFit();

            _toggleStrictModeSwitch = new UISwitch();
            _toggleStrictModeSwitch.On = false;
            _toggleStrictModeSwitch.TintColor = UIColor.White;
            _toggleStrictModeSwitch.OnTintColor = new UIColor(0, 153 / 255, 1, 1);
            _toggleStrictModeSwitch.ValueChanged += OnStrictModeValueChanged;

            _toggleStrictModeView.AddSubview(_toggleStrictModeLabel);
            _toggleStrictModeView.AddSubview(_toggleStrictModeSwitch);

            View.AddSubview(_toggleStrictModeView);

            // Create a subview for toggling crop and transform ID

            _toggleCropAndTransformIDView = new UIView(new CGRect(0, 0, 150, 50));
            _toggleCropAndTransformIDLabel = new UILabel(new CGRect(0, 0, 100, 30));
            _toggleCropAndTransformIDLabel.Text = "Crop And Transform ID";
            _toggleCropAndTransformIDLabel.TextColor = UIColor.White;
            _toggleCropAndTransformIDLabel.SizeToFit();

            _toggleCropAndTransformIDSwitch = new UISwitch();
            _toggleCropAndTransformIDSwitch.On = false;
            _toggleCropAndTransformIDSwitch.TintColor = UIColor.White;
            _toggleCropAndTransformIDSwitch.OnTintColor = new UIColor(0, 153 / 255, 1, 1);
            _toggleCropAndTransformIDSwitch.ValueChanged += OnCropAndTransformIDValueChanged;

            _toggleCropAndTransformIDView.AddSubview(_toggleCropAndTransformIDLabel);
            _toggleCropAndTransformIDView.AddSubview(_toggleCropAndTransformIDSwitch);

            View.AddSubview(_toggleCropAndTransformIDView);

            // Create view for the result image

            _mrzResultImageView = new UIImageView(new CGRect(0, 0, 125, 85));
            
            View.AddSubview(_mrzResultImageView);
            
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            double width = 0;

            _toggleStrictModeLabel.Center = new CGPoint(_toggleStrictModeLabel.Frame.Size.Width / 2, _toggleStrictModeView.Frame.Size.Height / 2);
            _toggleStrictModeSwitch.Center = new CGPoint(_toggleStrictModeLabel.Frame.Size.Width + _toggleStrictModeSwitch.Frame.Size.Width / 2 + 7, _toggleStrictModeView.Frame.Size.Height / 2);

            width = _toggleStrictModeSwitch.Frame.Size.Width + 7 + _toggleStrictModeLabel.Frame.Size.Width;
            _toggleStrictModeView.Frame = new CGRect(_frame.Size.Width - width - 15, _frame.Size.Height - 50, width, 50);
            
            _toggleCropAndTransformIDLabel.Center = new CGPoint(_toggleCropAndTransformIDLabel.Frame.Size.Width / 2, _toggleCropAndTransformIDView.Frame.Size.Height / 2);
            _toggleCropAndTransformIDSwitch.Center = new CGPoint(_toggleCropAndTransformIDLabel.Frame.Size.Width + _toggleCropAndTransformIDSwitch.Frame.Size.Width / 2 + 7, _toggleCropAndTransformIDView.Frame.Size.Height / 2);

            width = _toggleCropAndTransformIDSwitch.Frame.Size.Width + 7 + _toggleCropAndTransformIDLabel.Frame.Size.Width;
            _toggleCropAndTransformIDView.Frame = new CGRect(_frame.Size.Width - width - 15, _frame.Size.Height - 0, width, 50);

            _mrzResultImageView.Frame = new CGRect(_frame.Size.Width - 125, _frame.Y, 125, 85);
        }

        private void OnStrictModeValueChanged(object sender, EventArgs e)
        {
            // Make sure that it isn't scanning when setting this property
            StopAnyline();
            _anylineMrzView.StrictMode = ((UISwitch)sender).On;
            StartAnyline();
        }

        private void OnCropAndTransformIDValueChanged(object sender, EventArgs e)
        {
            // Make sure that it isn't scanning when setting this property
            StopAnyline();
            _anylineMrzView.CropAndTransformID = ((UISwitch)sender).On;
            StartAnyline();
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

            _mrzResultImageView.Image = null;

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

            _mrzResultImageView.Image = scanResult.Image;

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

            _toggleCropAndTransformIDLabel.RemoveFromSuperview();
            _toggleCropAndTransformIDLabel?.Dispose();

            _toggleCropAndTransformIDSwitch.ValueChanged -= OnCropAndTransformIDValueChanged;
            _toggleCropAndTransformIDSwitch.RemoveFromSuperview();
            _toggleCropAndTransformIDSwitch?.Dispose();

            _toggleCropAndTransformIDView.RemoveFromSuperview();
            _toggleCropAndTransformIDView?.Dispose();

            _toggleStrictModeLabel.RemoveFromSuperview();
            _toggleStrictModeLabel?.Dispose();

            _toggleStrictModeSwitch.ValueChanged -= OnStrictModeValueChanged;
            _toggleStrictModeSwitch.RemoveFromSuperview();
            _toggleStrictModeSwitch?.Dispose();

            _toggleStrictModeView.RemoveFromSuperview();
            _toggleStrictModeView?.Dispose();
            
            _mrzResultImageView.RemoveFromSuperview();
            _mrzResultImageView?.Dispose();

            base.Dispose();
        }
    }
}
