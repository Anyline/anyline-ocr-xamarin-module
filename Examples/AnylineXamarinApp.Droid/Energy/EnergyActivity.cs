using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Gms.Vision.Barcodes;
using AT.Nineyards.Anyline.Modules.Energy;
using AT.Nineyards.Anyline.Modules.Barcode;
using AT.Nineyards.Anylinexamarin.Support.Modules.Energy;
using AT.Nineyards.Anyline.Camera;

namespace AnylineXamarinApp.Energy
{

    [Activity(Label = "", MainLauncher = false, Icon = "@drawable/ic_launcher", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, HardwareAccelerated = true)]
    public class EnergyActivity : Activity, IEnergyResultListener, IDialogInterfaceOnClickListener, IDialogInterfaceOnCancelListener
    {
        public static string TAG = typeof(EnergyActivity).Name;

        private EnergyScanView _scanView;
        private NativeBarcodeResultListener _nativeBarcodeResultListener;
        public TextView NativeBarcodeResultTextView { get; private set; }
        private Switch _toggleBarcodeSwitch;

        private string _energyUseCase; // analog, digital, heat meters
        private Dictionary<string, EnergyScanView.ScanMode> _scanList;

        protected override void OnCreate(Bundle bundle)
        {
            Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
            
            base.OnCreate(bundle);

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            
            SetContentView(Resource.Layout.EnergyActivity);

            _scanView = FindViewById<EnergyScanView>(Resource.Id.energy_scan_view);
            
            _energyUseCase = Intent.Extras.GetSerializable("OBJECT").ToString();
            _scanView.SetConfigFromAsset(_energyUseCase.Equals(Resources.GetString(Resource.String.scan_heat_meter))
                ? "EnergyConfigHeatMeter.json"
                : "EnergyConfigAll.json");

            _scanView.InitAnyline(MainActivity.LicenseKey, this);
                                    
            NativeBarcodeResultTextView = FindViewById<TextView>(Resource.Id.barcode_result_text);
            NativeBarcodeResultTextView.Text = "";

            _toggleBarcodeSwitch = FindViewById<Switch>(Resource.Id.toggle_barcode_switch);

            // we don't use the native barcode scan mode in heat meters in this example
            if (_energyUseCase.Equals(Resources.GetString(Resource.String.scan_heat_meter)))
            {                
                var toggleBarcodeLayout = FindViewById<RelativeLayout>(Resource.Id.toggle_barcode_layout);
                toggleBarcodeLayout.Visibility = ViewStates.Gone;
            }
            else
            {
                _toggleBarcodeSwitch.CheckedChange += (sender, args) =>
                {
                    if (((Switch)sender).Checked)
                    {
                    /*
                     * Enable simultaneous barcode scanning:
                     * 
                     * The following lines of code enable the simultaneous barcode scanning functionality.
                     * In order for this to work, some additional requires must be met in the project settings:
                     * 
                     * In AndroidManifest.xml, the following must be added:
                     * <meta-data android:name="com.google.android.gms.vision.DEPENDENCIES" android:value="barcode" />
                     * 
                     * Also, the Nuget Package "Xamarin.GooglePlayServices.Vision" must be installed for this application.
                     * For installation, the App must be targeted to Android 7.0, but then the SDK version can be reduced again.
                    */
                        try
                        {

                        // First, we check if the barcode detector works on the device
                        var detector = new BarcodeDetector.Builder(ApplicationContext).Build();
                            if (!detector.IsOperational)
                            {
                            // Native barcode scanning not supported on this device
                            Toast.MakeText(ApplicationContext, "Native Barcode scanning not supported on this device!", ToastLength.Long).Show();
                                _toggleBarcodeSwitch.Checked = false;
                            }
                            else
                            {
                                _nativeBarcodeResultListener?.Dispose(); // dispose of old barcodelistener first
                            _nativeBarcodeResultListener = new NativeBarcodeResultListener(this);
                                _scanView.EnableBarcodeDetection(true, _nativeBarcodeResultListener);
                            }
                        }
                        catch (Exception) { }
                    }
                    else
                    {
                        _scanView.DisableBarcodeDetection();
                        _nativeBarcodeResultListener?.Dispose();
                        NativeBarcodeResultTextView.Text = "";
                    }
                };
            }
            
            // In our main activity, we selected which type of meters we want to scan
            // Now we want to populate the RadioButton group accordingly:

            RadioGroup radioGroup = FindViewById<RadioGroup>(Resource.Id.radio_group);
            int defaultIndex = 0; //index for which radiobutton is checked at the beginning

            if (_energyUseCase.Equals(Resources.GetString(Resource.String.scan_analog_meter)))
            {
                SetTitle(Resource.String.scan_analog_meter);
                _scanView.SetScanMode(EnergyScanView.ScanMode.AnalogMeter);
            }
            else if (_energyUseCase.Equals(Resources.GetString(Resource.String.scan_digital_meter)))
            {
                SetTitle(Resource.String.scan_digital_meter);
                _scanView.SetScanMode(EnergyScanView.ScanMode.DigitalMeter);
            }
            else if (_energyUseCase.Equals(Resources.GetString(Resource.String.scan_heat_meter)))
            {
                SetTitle(Resource.String.scan_heat_meter);
                _scanList = new Dictionary<string, EnergyScanView.ScanMode>
                {
                    { Resources.GetString(Resource.String.heat_meter_4_3), EnergyScanView.ScanMode.HeatMeter4 },
                    { Resources.GetString(Resource.String.heat_meter_5_3), EnergyScanView.ScanMode.HeatMeter5 },
                    { Resources.GetString(Resource.String.heat_meter_6_3), EnergyScanView.ScanMode.HeatMeter6 }
                };

                _scanView.SetScanMode(_scanList.First().Value);

                // Adding an additional layout rule for this use case because of the radiobutton group size.
                var lp = NativeBarcodeResultTextView.LayoutParameters as RelativeLayout.LayoutParams;
                if (lp != null)
                {
                    lp.AddRule(LayoutRules.Above, radioGroup.Id);
                    NativeBarcodeResultTextView.LayoutParameters = lp;
                }
            }
            else if (_energyUseCase.Equals(Resources.GetString(Resource.String.scan_analog_digital_meter)))
            {
                SetTitle(Resource.String.scan_analog_digital_meter);
                _scanView.SetScanMode(EnergyScanView.ScanMode.AutoAnalogDigitalMeter);
            }
            else if (_energyUseCase.Equals(Resources.GetString(Resource.String.scan_serial_numbers)))
            {
                SetTitle(Resource.String.scan_serial_numbers);
                _scanView.SetScanMode(EnergyScanView.ScanMode.SerialNumber);

                // we can set the regex and character whitelist for this
                _scanView.SetSerialNumberCharWhitelist("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                _scanView.SetSerialNumberValidationRegex("^[0-9A-Z]{5,}$");
            }
            else if (_energyUseCase.Equals(Resources.GetString(Resource.String.scan_dial_meters)))
            {
                SetTitle(Resource.String.scan_dial_meters);
                _scanView.SetScanMode(EnergyScanView.ScanMode.DialMeter);
            }
            else if (_energyUseCase.Equals(Resources.GetString(Resource.String.scan_dot_matrix_meters)))
            {
                SetTitle(Resource.String.scan_dot_matrix_meters);
                _scanView.SetScanMode(EnergyScanView.ScanMode.DotMatrixMeter);
            }
            Util.PopulateRadioGroupWithList(this, radioGroup, _scanList, defaultIndex);

            // Switch the scan mode depending on user selection

            radioGroup.CheckedChange += (sender, args) =>
            {
                _scanView.CancelScanning();

                var rb = FindViewById<RadioButton>(args.CheckedId);
                var scanMode = _scanList.Single(x => x.Key.Equals(rb.Text)).Value;

                _scanView.SetScanMode(scanMode);
                _scanView.StartScanning();
            };

            _scanView.CameraOpened += (s, e) => { Log.Debug(TAG, "Camera opened successfully. Frame resolution " + e.Width + " x " + e.Height); };
            _scanView.CameraError += (s, e) => { Log.Error(TAG, "OnCameraError: " + e.Event.Message); };
            
            _scanView.SetCancelOnResult(false);
        }

        void IEnergyResultListener.OnResult(EnergyResult scanResult)        
        {
            _scanView.CancelScanning();

            // explicitly free memory
            GC.Collect(GC.MaxGeneration);

            string typeString = "Scan Result";

            // we just want to display the plain text
            var formattedResult = new SpannableString(scanResult.Result.ToString());

            ResultDialogBuilder rdb = (ResultDialogBuilder)new ResultDialogBuilder(this)
                .SetResultImage(scanResult.CutoutImage)
                .SetTextSize(ComplexUnitType.Dip, 26)
                .SetTextGravity(GravityFlags.Center)
                .SetText(formattedResult)
                .SetPositiveButton(Android.Resource.String.Ok, this)
                .SetTitle(typeString)
                .SetOnCancelListener(this);

            rdb.Show();
        }

        void IDialogInterfaceOnClickListener.OnClick(IDialogInterface dialog, int which) {

            _scanView.StartScanning();
            NativeBarcodeResultTextView.Text = "";
        }
        
        void IDialogInterfaceOnCancelListener.OnCancel(IDialogInterface dialog) { _scanView.StartScanning(); }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            _scanView.StartScanning();
        }

        protected override void OnPause()
        {
            base.OnPause();
            _scanView.CancelScanning();
            _scanView.ReleaseCameraInBackground();
        }
        
        public override void OnBackPressed()
        {
            base.OnBackPressed();
            Finish();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            // explicitly free memory
            GC.Collect(GC.MaxGeneration);
        }
    }

    /* 
    * If you don't need native barcode scanning or can't install the nuget package for your app, 
    * simply remove this class and remove the implementation above.
    */
    class NativeBarcodeResultListener : Java.Lang.Object, INativeBarcodeResultListener
    {
        EnergyActivity _activityReference;
        public NativeBarcodeResultListener(EnergyActivity activityReference)
        {
            _activityReference = activityReference;
        }

        public void OnBarcodesReceived(SparseArray barcodes)
        {
            for (var i = 0; i < barcodes.Size(); i++)
            {
                var barcode = barcodes.ValueAt(i) as Android.Gms.Vision.Barcodes.Barcode;
                var resultString = "Barcode Result: " + barcode.DisplayValue;                
                _activityReference.NativeBarcodeResultTextView.Text = resultString;
            }
        }
    }
}