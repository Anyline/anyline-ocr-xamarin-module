@echo off
IF EXIST Examples\AnylineXamarinApp.Droid\obj (
rmdir Examples\AnylineXamarinApp.Droid\obj /S /Q
)
IF EXIST Examples\AnylineXamarinApp.Droid\bin (
rmdir Examples\AnylineXamarinApp.Droid\bin /S /Q
)
IF EXIST Examples\AnylineXamarinApp.iOS\obj (
rmdir Examples\AnylineXamarinApp.iOS\obj /S /Q
)
IF EXIST Examples\AnylineXamarinApp.iOS\bin (
rmdir Examples\AnylineXamarinApp.iOS\bin /S /Q
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

echo off
pause