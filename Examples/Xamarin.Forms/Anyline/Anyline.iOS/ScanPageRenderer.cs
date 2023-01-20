using Anyline;
using Anyline.iOS;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ScanExamplePage), typeof(ScanPageRenderer))]
namespace Anyline.iOS
{
    public class ScanPageRenderer : PageRenderer
    {
        private CGRect frame;
        private bool initialized;

        private ALScanView _scanView;
        ScanResultDelegate _resultDelegate;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            InitializeAnyline();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (!initialized) return;

            StartAnyline();
        }

        private void InitializeAnyline()
        {
            NSError error = null;

            if (initialized)
                return;

            try
            {
                string configurationFile = (Element as ScanExamplePage).ConfigurationFile.Replace(".json", "");

                // Use the JSON file name that you want to load here
                var configPath = NSBundle.MainBundle.PathForResource(configurationFile, @"json");
                // This is the main intialization method that will create our use case depending on the JSON configuration.
                _resultDelegate = new ScanResultDelegate((Element as ScanExamplePage).ShowResultsAction);
               
                NSString jsonConfig = new NSString(@"{
                                                    ""cameraConfig"": {
                                                    ""captureResolution"": ""1080p""
                                                    },
                                                    ""flashConfig"": {
                                                    ""mode"": ""manual"",
                                                    ""alignment"": ""top_right"",
                                                    ""offset"": { ""x"": 0, ""y"": 0 }
                                                    },
                                                    ""viewPluginConfig"": {
                                                    ""pluginConfig"": {
                                                        ""id"": ""com.anyline.configs.plugin.id_mrz_dl"",
                                                        ""universalIdConfig"": {
                                                        ""allowedLayouts"": {
                                                            ""mrz"": [],
                                                            ""drivingLicense"": [],
                                                            ""idFront"": []
                                                        },
                                                        ""alphabet"": ""latin"",
                                                        ""drivingLicense"": {
                                                            ""surname"": {""scanOption"": 0, ""minConfidence"": 40},
                                                            ""givenNames"": {""scanOption"": 0, ""minConfidence"": 40},
                                                            ""dateOfBirth"": {""scanOption"": 0, ""minConfidence"": 50},
                                                            ""placeOfBirth"": {""scanOption"": 1, ""minConfidence"": 50},
                                                            ""dateOfIssue"": {""scanOption"": 0, ""minConfidence"": 50},
                                                            ""dateOfExpiry"": {""scanOption"": 1, ""minConfidence"": 50},
                                                            ""authority"": {""scanOption"": 1, ""minConfidence"": 30},
                                                            ""documentNumber"": {""scanOption"": 0, ""minConfidence"": 40},
                                                            ""categories"": {""scanOption"": 1, ""minConfidence"": 30},
                                                            ""address"": {""scanOption"": 1}
                                                        },
                                                        ""idFront"": {
                                                            ""surname"": {""scanOption"": 0, ""minConfidence"": 60},
                                                            ""givenNames"": {""scanOption"": 0, ""minConfidence"": 60},
                                                            ""dateOfBirth"": {""scanOption"": 0, ""minConfidence"": 60},
                                                            ""placeOfBirth"": {""scanOption"": 1, ""minConfidence"": 60},
                                                            ""dateOfExpiry"": {""scanOption"": 1, ""minConfidence"": 60},
                                                            ""cardAccessNumber"": {""scanOption"": 1, ""minConfidence"": 60},
                                                            ""documentNumber"": {""scanOption"": 0, ""minConfidence"": 60},
                                                            ""nationality"": {""scanOption"": 1, ""minConfidence"": 60}
                                                        }
                                                        },
                                                        ""cancelOnResult"": true
                                                    },
                                                    ""cutoutConfig"": {
                                                        ""animation"": ""fade"",
                                                        ""maxWidthPercent"": ""90%"",
                                                        ""maxHeightPercent"": ""90%"",
                                                        ""width"": 0,
                                                        ""alignment"": ""center"",
                                                        ""ratioFromSize"": { ""width"": 86, ""height"": 54 },
                                                        ""offset"": { ""x"": 0, ""y"": 60 },
                                                        ""cropOffset"": { ""x"": 0, ""y"": 0 },
                                                        ""cropPadding"": { ""x"": 0, ""y"": 0 },
                                                        ""cornerRadius"": 8,
                                                        ""strokeColor"": ""#8BE9FD"",
                                                        ""strokeWidth"": 2,
                                                        ""feedbackStrokeColor"": ""#0099FF"",
                                                        ""outerColor"": ""#000000"",
                                                        ""outerAlpha"": 0.3
                                                    },
                                                    ""scanFeedbackConfig"": {
                                                        ""style"": ""animated_rect"",
                                                        ""strokeWidth"": 0,
                                                        ""strokeColor"": ""#8be9fd"",
                                                        ""fillColor"": ""#908be9fd"",
                                                        ""cornerRadius"": 2,
                                                        ""beepOnResult"": true,
                                                        ""vibrateOnResult"": false,
                                                        ""blinkAnimationOnResult"": false
                                                    }
                                                    }
                                                }");

                NSDictionary configJSONDictionary = (NSDictionary) jsonConfig.AsJSONObject();
                if (configJSONDictionary == null)
                {
                    ShowAlert("Init failed", "JSON parsing invalid");
                }

                _scanView = ALScanViewFactory.WithConfigFilePath(configPath, _resultDelegate, out error);
                //_scanView = ALScanViewFactory.WithJSONDictionary(configJSONDictionary, _resultDelegate, out error);

                ALScanViewPluginBase scanViewPluginBase = _scanView.ScanViewPlugin;
                ALScanViewPlugin scanViewPlugin = (ALScanViewPlugin) scanViewPluginBase;
                scanViewPluginBase = (ALScanViewPluginBase) scanViewPlugin;

                scanViewPlugin.ScanPlugin.Delegate = _resultDelegate;

                if (error != null)
                {
                    throw new Exception(error.LocalizedDescription);
                }

                /// testing testing

                //NSData jsondata = new NSData();
                //var j = jsondata.ToJSONObject(out error);
                //jsonConfig.ToJSONObject(out error);

                //NSArray myArray = new NSArray();

                //ALCameraConfig cameraConfig = new ALCameraConfig();
                //string jsonCameraConfig = cameraConfig.ToJSONString(out error);

                //ALScanViewPlugin svp = new ALScanViewPlugin(configJSONDictionary, out error);
                //ALViewPluginComposite vpc = new ALViewPluginComposite();
                ///

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

        private void StartAnyline()
        {
            NSError error = null;
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
        }

        private void ShowAlert(string title, string text)
        {
            new UIAlertView(title, text, (IUIAlertViewDelegate)null, "OK", null).Show();
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

        new void Dispose()
        {
            _scanView?.RemoveFromSuperview();
            _scanView?.Dispose();
            _scanView = null;
            base.Dispose();
        }
        #endregion
    }
}