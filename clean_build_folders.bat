@echo on
IF EXIST Examples\AnylineExamples.Droid\obj (
rmdir Examples\AnylineExamples.Droid\obj /S /Q
)
IF EXIST Examples\AnylineExamples.Droid\bin (
rmdir Examples\AnylineExamples.Droid\bin /S /Q
)
IF EXIST Examples\AnylineExamples.iOS\obj (
rmdir Examples\AnylineExamples.iOS\obj /S /Q
)
IF EXIST Examples\AnylineExamples.iOS\bin (
rmdir Examples\AnylineExamples.iOS\bin /S /Q
)
IF EXIST BindingSource\AnylineXamarinSDK.Droid\bin (
rmdir BindingSource\AnylineXamarinSDK.Droid\bin /S /Q
)
IF EXIST BindingSource\AnylineXamarinSDK.Droid\obj (
rmdir BindingSource\AnylineXamarinSDK.Droid\obj /S /Q
)
IF EXIST BindingSource\AnylineXamarinSDK.iOS\bin (
rmdir BindingSource\AnylineXamarinSDK.iOS\bin /S /Q
)
IF EXIST BindingSource\AnylineXamarinSDK.iOS\obj (
rmdir BindingSource\AnylineXamarinSDK.iOS\obj /S /Q
)
IF EXIST Examples\Xamarin.Forms\Anyline\Anyline.Android\bin (
rmdir Examples\Xamarin.Forms\Anyline\Anyline.Android\bin /S /Q
)
IF EXIST Examples\Xamarin.Forms\Anyline\Anyline.Android\obj (
rmdir Examples\Xamarin.Forms\Anyline\Anyline.Android\obj /S /Q
)
IF EXIST Examples\Xamarin.Forms\Anyline\Anyline.iOS\bin (
rmdir Examples\Xamarin.Forms\Anyline\Anyline.iOS\bin /S /Q
)
IF EXIST Examples\Xamarin.Forms\Anyline\Anyline.iOS\obj (
rmdir Examples\Xamarin.Forms\Anyline\Anyline.iOS\obj /S /Q
)
IF EXIST Examples\Xamarin.Forms\Anyline\Anyline.UWP\bin (
rmdir EXIST Examples\Xamarin.Forms\Anyline\Anyline.UWP\bin /S /Q
)
IF EXIST Examples\Xamarin.Forms\Anyline\Anyline.UWP\obj (
rmdir Examples\Xamarin.Forms\Anyline\Anyline.UWP\obj /S /Q
)
echo off
pause