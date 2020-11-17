# ARCHIVE

bundle-release: clean-build-folders
	# -- Zips the release bundle, excluding Git files, bin, obj and vs folders --
	@rm -rf anyline-ocr-xamarin-module.zip
ifeq ($(OS),Windows_NT)
	tar.exe --exclude=*.nupkg --exclude=*.DS_Store -acf anyline-ocr-xamarin-module.zip BindingSource Examples Nuget com.anyline.xamarin.examples_* LICENSE.md README.md
	CertUtil -hashfile anyline-ocr-xamarin-module.zip MD5
else
	zip -rq anyline-ocr-xamarin-module.zip . -x "*.git*" -x "*.nupkg" -x "*.DS_Store"
	md5 anyline-ocr-xamarin-module.zip
endif


# CLEAN

clean-build-folders: 
	@rm -rf BindingSource/.vs
	@rm -rf Examples/.vs

	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline/bin
	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline/obj

	@rm -rf Examples/AnylineExamples.Droid/bin
	@rm -rf Examples/AnylineExamples.Droid/obj

	@rm -rf Examples/AnylineExamples.iOS/bin
	@rm -rf Examples/AnylineExamples.iOS/obj

	@rm -rf BindingSource/AnylineXamarinSDK.Droid/bin
	@rm -rf BindingSource/AnylineXamarinSDK.Droid/obj

	@rm -rf BindingSource/AnylineXamarinSDK.iOS/bin
	@rm -rf BindingSource/AnylineXamarinSDK.iOS/obj

	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline.Android/bin
	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline.Android/obj

	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline.iOS/bin
	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline.iOS/obj

	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline.UWP/bin
	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline.UWP/obj

	@echo Build folders are clean