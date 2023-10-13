using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using SceneKit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using UIKit;

namespace AnylineExamples.iOS
{
    public sealed class ScanViewController : UIViewController
    {
        string jsonPath;
        bool initialized = false;

        ALScanView _scanView;
        ScanResultDelegate _resultDelegate;
        string configPath = null;

        public ScanViewController(string name, string jsonPath)
        {
            Title = name;
            this.jsonPath = jsonPath;

            _resultDelegate = new ScanResultDelegate(this, name);
        }

        private void InitializeAnyline()
        {
            NSError error = null;

            if (initialized)
                return;

            try
            {
                // Use the JSON file name that you want to load here
                configPath = NSBundle.MainBundle.PathForResource(@"" + jsonPath.Replace(".json", ""), @"json");

                // This is the main intialization method that will create our use case depending on the JSON configuration.
                _scanView = ALScanViewFactory.WithConfigFilePath(configPath, _resultDelegate, out error);
                
                if (error != null)
                {
                    throw new Exception(error.LocalizedDescription);
                }

                View.AddSubview(_scanView);

                // Pin the leading edge of the scan view to the parent view

                _scanView.TranslatesAutoresizingMaskIntoConstraints = false;

                _scanView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
                _scanView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
                _scanView.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor).Active = true;
                _scanView.BottomAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.BottomAnchor).Active = true;

                _scanView.StartCamera();

                initialized = true;
            }
            catch (Exception e)
            {
                ShowAlert("Init Error", e.Message);
            }
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            // initialize anyline if not already initialized
            InitializeAnyline();

            if (!initialized) return;

            NSError error = null;

            BeginInvokeOnMainThread(() =>
            {
                var success = _scanView.ScanViewPlugin.StartWithError(out error);

                if (!success)
                {
                    if (error != null)
                    {
                        ShowAlert("Start Scanning Error", error.DebugDescription);
                    }
                    else
                    {
                        ShowAlert("Start Scanning Error", "error is null");
                    }
                }
            });
        }

        #region teardown
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            initialized = false;

            if (_scanView?.ScanViewPlugin == null)
                return;

            _scanView.ScanViewPlugin.Stop();
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            Dispose();
        }

        protected override void Dispose(bool disposing)
        {
            _scanView?.RemoveFromSuperview();
            _scanView?.Dispose();
            _scanView = null;
            base.Dispose(disposing);
        }
        #endregion

        private void ShowAlert(string title, string text)
        {
            new UIAlertView(title, text, (IUIAlertViewDelegate)null, "OK", null).Show();
        }
    }
}