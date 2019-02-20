# Xamarin Setup Guide #

The Anyline SDK is available for both Xamarin.Android and Xamarin.iOS. Each mobile platform has their own Anyline Xamarin SDK and and can be used very similar to the regular Anyline bundles for Android and iOS. Please refer to our API Reference for platform-specific documentation.

## Xamarin.Android ##

The Anyline Xamarin SDK provides the functionality of our Android SDK in C# to make Android integration in Xamarin as easy as possible. This section helps you to setup your Xamarin.Android project and start scanning right away!

### Requirements ###

To use the Anyline SDK for Xamarin.Android, you'll need:

- Xamarin account (If you work with Visual Studio, you need at least a Xamarin business account. Check out the <a href="https://xamarin.com/">Xamarin website</a> for detailed information.)
- Android device with SDK >= 15
- decent camera functionality (recommended: 720p and adequate auto focus)
- Xamarin Studio or Visual Studio
- an Anyline license which you can generate <a href="http://portal.anyline.io/">here</a> after purchasing our SDK in the <a href="https://www.anyline.io/store/">store</a>.

The Android bundle contains the following parts:

- **AnylineXamarinSDK.Droid.dll:** contains the Anyline SDK Library
- **AnylineXamarinApp.Droid** contains a simple app where an example for each module is implemented - it can be installed right away
- **LICENSE:** third party license agreements
- **README:** contains a quick start - setup and module description

### Quick Start - Setup ###

Follow <a href="https://developer.xamarin.com/guides/android/getting_started/hello,android/hello,android_quickstart/">this</a> guide to develop an understanding of the fundamentals of Android application development with Xamarin.

#### 1. Generate license key

Obtaining a license key is already described [here](#obtaining-an-anyline-sdk-license-key). To generate a license key for your application, refer to the `package name` of your Xamarin.Android project. 

- Visual Studio

![XamarinAndroidPackageVS](images/xamarinAndroidPackageVS.png)

- Xamarin Studio

![XamarinAndroidPackageXS](images/xamarinAndroidPackageXS.png)

#### 2. Add AnylineXamarinSDK.Droid as reference

To access the functionality of our SDK, simply add the `AnylineXamarinSDK.Droid.dll` file as a reference. 

Visual Studio:

- right-click the References node in your project tree
- click "Add reference..."
- click "Browse..." and locate the AnylineXamarinSDK.Droid.dll file

Xamarin Studio:

- right-click the References node in your project tree
- click "Edit references..."
- navigate to the ".Net Assembly" tab
- click "Browse..." to locate the AnylineXamarinSDK.Droid.dll file

The SDK should now be visible as a reference and your project tree should somewhat look like this:

![XamarinAndroidReference](images/xamarinAndroidReference.png)

#### 3. Set minimum Android target

In the `Application` settings of your project, set the minimum version of your Android target to `API level 17`.

![XamarinAndroidTarget](images/xamarinAndroidTarget.png)

#### 4. Add necessary permissions and features

The scanning activity needs the following permissions and features
- Permissions
	- CAMERA
	- VIBRATE
	- WRITE_EXTERNAL_STORAGE
	- READ_EXTERNAL_STORAGE
- Features
	- android.hardware.camera
	- android.hardware.camera.flash
	- android.hardware.camera.autofocus

So let's add them in our AndroidManifest.xml in our Properties node.

> in AndroidManifest.xml

```xml
<?xml version="1.0" encoding="utf-8"?>
<manifest xmlns:android="http://schemas.android.com/apk/res/android"
  package="AT.Nineyards.AnylineXamarinExample"
  android:versionCode="1" android:versionName="1.0">
	<uses-sdk />
	<application android:label="AnylineExampleAndroid" android:icon="@drawable/Icon"></application>
  <uses-permission android:name="android.permission.CAMERA" />
  <uses-permission android:name="android.permission.VIBRATE" />
  <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" android:maxSdkVersion="18" />
  <uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" android:maxSdkVersion="18" />
  <uses-feature android:name="android.hardware.camera" android:required="false" />
  <uses-feature android:name="android.hardware.camera.flash" />
  <uses-feature android:name="android.hardware.camera.autofocus" android:required="false" />
</manifest>
```
###### &NewLine;

#### 5. Add a Scan View

- Open the Main.axml file in your Resources/Layout node.
- Switch from the `Design` tab to the `Source` tab.
- Edit the XML Code as shown in the code example

> The XML code should look somewhat like this

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical"
    android:layout_width="fill_parent"
    android:layout_height="fill_parent">
    <Button
        android:id="@+id/MyButton"
        android:layout_width="fill_parent"
        android:layout_height="wrap_content"
        android:text="@string/Hello" />
</LinearLayout>
```
###### &NewLine;

> We don't need the Button, instead, let's add a scan view. Edit the XML code as follows

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical"
    android:layout_width="fill_parent"
    android:layout_height="fill_parent">
    <at.nineyards.anyline.modules.barcode.BarcodeScanView
        android:id="@+id/AnylineScanView"
        android:layout_width="match_parent"
        android:layout_height="match_parent" />
</LinearLayout>
```
###### &NewLine;

If you switch back from to the `Design` tab, the user interface should look like this:
![XamarinAndroidDesign](images/xamarinAndroidDesign.png)

We now have added a Barcode scan view to our activity. However, depending on which scanning type you want to implement, choose one of these module-specific views:

- Barcode scanning
	- at.nineyards.anyline.modules.barcode.BarcodeScanView
- Energy meter scanning
	- at.nineyards.anyline.modules.energy.EnergyScanView
- MRZ and passport scanning
	- at.nineyards.anyline.modules.mrz.MrzScanView

Because we named the element "AnylineScanview" (`android:id="@+id/AnylineScanView"` in the XML code), this element is added automatically to the Resource.Designer.cs class when the project is built. 

#### 6. Provide a configuration to the scan view

You can adapt your scan view easily by either adding a .json file or using XML-attributes in the layout file (e.g. Main.axml).
In this example, let's create a .json file and fill it with properties:

Visual Studio:
- In your Assets treenode, right-click on the folder and select `Add` > `New Item..`
- Choose `Visual C#` > `Text File` and name it "scanConfig.json"

Xamarin Studio:
- In your Assets treenode, right-click on the folder and select `Add` > `New File...`
- Choose `Misc` > `Empty Text File` and name it "scanConfig.json"

Make sure that the build action for this file is `AndroidAsset`.

Now open the file and paste the code from the following example

```json
{
  "captureResolution":"720p",

  "cutout": {
    "style": "rect",
    "maxWidthPercent": "80%",
    "alignment": "top_half",
    "ratioFromSize": {
      "width": 100,
      "height": 80
    },
    "strokeWidth": 4,
    "cornerRadius": 10,
    "strokeColor": "00AFFE",
    "outerColor": "000000",
    "outerAlpha": 0.3
  },
  "flash": {
    "mode": "manual",
    "alignment": "bottom_right"
  },
  "beepOnResult": false,
  "vibrateOnResult": true,
  "blinkAnimationOnResult": true,
  "cancelOnResult": false
}
```
###### &NewLine;

Follow [this](#anyline-config) guide for detailed information about the configuration.

#### 7. Implement the scan view

Now we are ready to implement the scan view in our activity. Let's add a `using` statement for our module-specific scan view in our `MainActivity.cs`.

```csharp
// for barcode scanning
using AT.Nineyards.Anyline.Modules.Barcode;

// for energy meter scanning
using AT.Nineyards.Anyline.Modules.Energy;

// for MRZ scanning
using AT.Nineyards.Anyline.Modules.MRZ;
```
###### &NewLine;

Let's have a look at the code outline of our activity in the following code example:

> Activity outline

```csharp
namespace AnylineExampleAndroid
{
    [Activity(Label = "AnylineExampleAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
		// A member variable that is our scan view
        BarcodeScanView scanView;
		
		// Setup our scan view here
        protected override void OnCreate(Bundle bundle) { ... }
        		
		// If the application state passes from "Resumed" to "Paused", this method is invoked
		// scanView.CancelScanning(); and scanView.ReleaseCameraInBackground(); should be called here
        protected override void OnPause() { ... }
		
		// This method is invoked if the application state changes from "Paused" or "Started" to "Resumed"
		// scanView.StartScanning(); should be called here
        protected override void OnResume() { ... }
		
		// If the back-button is pressed, invoke this method
		// To close your application, call the Finish(); method here
        public override void OnBackPressed() { ... }
    }
}
```
###### &NewLine;

The following methods have to be implemented in order to use the scan view:

- in `OnCreate` we'll set up our scan view, load a configuration, initialize it with the license key that we generated earlier and finally start scanning

> OnCreate

```csharp
// Setup our scan view here
protected override void OnCreate(Bundle bundle)
{
	base.OnCreate(bundle);

	// Set our view from the "main" layout resource
	SetContentView(Resource.Layout.Main);
				
	// allocate the element we defined earlier in our Main.axml
	scanView = FindViewById<BarcodeScanView>(Resource.Id.AnylineScanView);

	// Load config from the .json file
	// We don't need this, if we define our configuration in the XML code
	scanView.SetConfigFromAsset("scanConfig.json");

	// Initialize with our license key and our result listener
	scanView.InitAnyline("INSERT YOUR LICENSE KEY HERE", this);
	
	// Don't stop scanning when a result is found
	scanView.SetCancelOnResult(false);

	// Register event that shows if the camera is initialized
	scanView.CameraOpened += (s, e) => { 
		Log.Debug("Camera", "Camera opened successfully. Frame resolution " + e.Width + " x " + e.Height);
	};
	
	// Register event that shows if the camera returns an error
	scanView.CameraError += (s, e) => {
		Log.Error("Camera", "OnCameraError: " + e.Event.Message);
	};

	// After everything is set up, start the scanning thread
	scanView.StartScanning();
}
```

<aside class="notice">
<b>InitAnyline</b> takes the license key and a module-specific result listener as arguments. A convenient way is to store the license key in a <b>const String</b> and let the activity implement the interface of the result listener, then passing <b>this</b> as second argument.
</aside>

###### &NewLine;

#### 8. Handle Results

Each of the anyline modules uses a module-specific scan view that uses the camera of your mobile device and provides real-time scan results via a module-specific listener.

The easiest way to make use of that listener is to implement the interface of the listener in your scan activity like this:

> Implement a Result Listener depending on the module (IBarcodeResultListener, IEnergyResultListener or IMrzResultListener)

```csharp
[Activity(Label = "AnylineExampleAndroid", MainLauncher = true, Icon = "@drawable/icon")]
public class MainActivity : Activity, IBarcodeResultListener // or any other module-specific listener, depending on your scan module
{
	...
}
```
###### &NewLine;

The interface can be implemented by right-clicking on the ResultListener Interface and selecting `Implement Interface`. A method will be generated that is called each time our scan view is scanning and reporting a result.

> OnResult of the Barcode ResultListener

```csharp
// Each time, a result is found, this method is invoked
public void OnResult(string result, AT.Nineyards.Anyline.Models.AnylineImage resultImage)
{
	// Show a short Toast message if a result is found
	Toast.MakeText(this, result, ToastLength.Short).Show();
}
```
###### &NewLine;

#### 9. Test your app on an Android device

Build your project and deploy your application on your Android device. For module-specific documentation, please check [this section](#modules) for more information. Enjoy scanning and have fun :)

## Xamarin.iOS

Documentation will follow.

## Xamarin.WinPhone

Anyline will be available Windows Phone by Q4 2015.