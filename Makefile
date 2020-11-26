# BUILD

build-android-sdk:
	nuget restore BindingSource/AnylineXamarinSDK.Droid/AnylineXamarinSDK.Droid.csproj
ifeq ($(OS),Windows_NT)
    #Build Android DLL
	@msbuild.exe /p:Configuration="Release" \
		/p:Platform="AnyCPU" \
		/v:minimal \
		/t:rebuild "BindingSource/AnylineXamarinSDK.Droid/AnylineXamarinSDK.Droid.csproj"
    # Build once more to generate the Metadata
	@msbuild.exe /p:Configuration="Release" \
		/p:Platform="AnyCPU" \
		/v:minimal \
		/t:rebuild "BindingSource/AnylineXamarinSDK.Droid/AnylineXamarinSDK.Droid.csproj"
else
    #Build Android DLL
	@msbuild /p:Configuration="Release" \
		/p:Platform="AnyCPU" \
		/v:minimal \
		/t:rebuild "BindingSource/AnylineXamarinSDK.Droid/AnylineXamarinSDK.Droid.csproj"
    # Build once more to generate the Metadata
	@msbuild /p:Configuration="Release" \
		/p:Platform="AnyCPU" \
		/v:minimal \
		/t:rebuild "BindingSource/AnylineXamarinSDK.Droid/AnylineXamarinSDK.Droid.csproj"
endif
	nuget pack Nuget/Anyline.Xamarin.SDK.Droid.nuspec -OutputDirectory Nuget
	@echo Android NuGet package created

build-android-examples:
	nuget restore Examples/AnylineExamples.Droid/AnylineExamples.Droid.csproj
ifeq ($(OS),Windows_NT)
	# Build the examples .apk file 
	@msbuild.exe /p:Configuration="Release" \
		/p:MonoSymbolArchive=False \
		/v:minimal \
		/t:PackageForAndroid "Examples/AnylineExamples.Droid/AnylineExamples.Droid.csproj"
else
	# Build the examples .apk file 
	@msbuild /p:Configuration="Release" \
		/p:MonoSymbolArchive=False \
		/v:minimal \
		/t:PackageForAndroid "Examples/AnylineExamples.Droid/AnylineExamples.Droid.csproj"
endif
	@echo Android Examples APK is built



build-ios-sdk:
	# Needs to be run on a Mac
	@msbuild /p:Configuration="Release" \
		/p:Platform="AnyCPU" \
		/p:BuildIpa=false \
		/v:minimal \
		/t:rebuild "BindingSource/AnylineXamarinSDK.iOS/AnylineXamarinSDK.iOS.csproj"
	nuget pack Nuget/Anyline.Xamarin.SDK.iOS.nuspec -OutputDirectory Nuget
	@echo iOS NuGet package created

build-ios-examples:
	# Needs to be run on a Mac
	@msbuild /p:Configuration="Release" \
		/p:Platform="iPhone" \
		/p:BuildIpa=false \
		/v:minimal \
		/t:rebuild "Examples/AnylineExamples.iOS/AnylineExamples.iOS.csproj"
    
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