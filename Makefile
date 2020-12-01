## The recipes depend on the following Environment Variables: ##

RUNNING_ON_CICD = true

# ////// Release ////// #
# MAJOR_VERSION
# MINOR_VERSION
# BUILD_NUMBER
# ////// Release ////// #


# ////// iOS ////// #
# MAJOR_VERSION_IOS
# MINOR_VERSION_IOS
# BUILD_NUMBER_IOS
# BUNDLE_VERSION_IOS
# ////// iOS ////// #


# ////// ANDROID ////// #
# MAJOR_VERSION_ANDROID
# MINOR_VERSION_ANDROID
# BUILD_NUMBER_ANDROID
# VERSION_CODE_ANDROID - Used in the Android Examples App - Cannot be 0.
# KEYSTORE_PATH - Used to sign the final Examples APK
# KEYSTORE_RELEASE_PW - Used to sign the final Examples APK
# ////// ANDROID ////// #


# ////// WINDOWS MACHINES ////// #
# WINDOWS machines will also require setting the PWD env. variable: #
# PWD=%cd%
# ////// WINDOWS MACHINES ////// #


## TOOLS ##
# The following tools need to be available on the PATH: #
# make
# msbuild (or msbuid.exe on Windows)
# dotnet
# nuget
# jarsigner
# zipalign
# zip (on Mac OS)
# tar.exe (on Windows)
# md5 (on Mac OS)
# CertUtil (on Windows)
# sed
# gh (GitHub)
## TOOLS ## 

all: help
help: 
	@echo "You probably wanted to call:" 
	@echo make bundle-release

# BUILD

build-android-sdk:
	@nuget restore BindingSource/AnylineXamarinSDK.Droid/AnylineXamarinSDK.Droid.csproj
	
	# Build Android SDK
ifeq ($(OS),Windows_NT)
	@msbuild.exe /p:Configuration="Release" \
		/p:Platform="AnyCPU" \
		/v:minimal \
		/t:rebuild "BindingSource/AnylineXamarinSDK.Droid/AnylineXamarinSDK.Droid.csproj"
# Build once more to generate the Metadata
	@msbuild.exe /p:Configuration="Release" \
		/p:Platform="AnyCPU" \
		/v:minimal \
		/t:build "BindingSource/AnylineXamarinSDK.Droid/AnylineXamarinSDK.Droid.csproj"
else
	@msbuild /p:Configuration="Release" \
		/p:Platform="AnyCPU" \
		/v:minimal \
		/t:rebuild "BindingSource/AnylineXamarinSDK.Droid/AnylineXamarinSDK.Droid.csproj"
# Build once more to generate the Metadata
	@msbuild /p:Configuration="Release" \
		/p:Platform="AnyCPU" \
		/v:minimal \
		/t:build "BindingSource/AnylineXamarinSDK.Droid/AnylineXamarinSDK.Droid.csproj"
endif
	@rm -rf Nuget/Anyline.Xamarin.SDK.Droid.*.nupkg

	@nuget pack Nuget/Anyline.Xamarin.SDK.Droid.nuspec -OutputDirectory Nuget

build-android-examples:
	@nuget restore Examples/AnylineExamples.Droid/AnylineExamples.Droid.csproj

	# Build the examples .apk file 
ifeq ($(OS),Windows_NT)
	@msbuild.exe /p:Configuration="Release" \
		/p:MonoSymbolArchive=False \
		/v:minimal \
		/t:PackageForAndroid "Examples/AnylineExamples.Droid/AnylineExamples.Droid.csproj"
else
	@msbuild /p:Configuration="Release" \
		/p:MonoSymbolArchive=False \
		/v:minimal \
		/t:PackageForAndroid "Examples/AnylineExamples.Droid/AnylineExamples.Droid.csproj"
endif
	@echo Android Examples APK is built

	@jarsigner -sigalg MD5withRSA -digestalg SHA1 -keystore "$(KEYSTORE_PATH)" -storepass "$(KEYSTORE_RELEASE_PW)" -signedjar "Examples/AnylineExamples.Droid/bin/Release/com.anyline.xamarin.examples-Signed.apk" "Examples/AnylineExamples.Droid/bin/Release/com.anyline.xamarin.examples.apk" "Xamarin.App.Droid Sample App"
	@zipalign -f 4 "Examples/AnylineExamples.Droid/bin/Release/com.anyline.xamarin.examples-Signed.apk" "Examples/AnylineExamples.Droid/bin/Release/com.anyline.xamarin.examples.apk"
	
	@rm -rf *.apk
	@mv "Examples/AnylineExamples.Droid/bin/Release/com.anyline.xamarin.examples.apk" "com.anyline.xamarin.examples_$(MAJOR_VERSION_ANDROID).$(MINOR_VERSION_ANDROID).$(BUILD_NUMBER_ANDROID).apk"


build-ios-sdk:
# Needs to be run on a Mac
ifneq ($(OS),Windows_NT)
	# Build iOS SDK
	@msbuild /p:Configuration="Release" \
		/p:Platform="AnyCPU" \
		/p:BuildIpa=false \
		/v:minimal \
		/t:rebuild "BindingSource/AnylineXamarinSDK.iOS/AnylineXamarinSDK.iOS.csproj"
endif

	@rm -rf Nuget/Anyline.Xamarin.SDK.iOS.*.nupkg
	@nuget pack Nuget/Anyline.Xamarin.SDK.iOS.nuspec -OutputDirectory Nuget

build-ios-examples:
# Needs to be run on a Mac
ifneq ($(OS),Windows_NT)
	# Build iOS Examples App
	@nuget restore Examples/AnylineExamples.iOS/AnylineExamples.iOS.csproj
	@msbuild /p:Configuration="Release" \
		/p:Platform="iPhone" \
		/p:BuildIpa=false \
		/v:minimal \
		/t:rebuild "Examples/AnylineExamples.iOS/AnylineExamples.iOS.csproj"
endif

# Release

archive:
# -- Zips the release bundle, excluding Git files, bin, obj and vs folders --
	@rm -rf anyline-ocr-xamarin-module.zip
ifeq ($(OS),Windows_NT)
	tar.exe --exclude=*.nupkg --exclude=*.DS_Store -acf anyline-ocr-xamarin-module.zip BindingSource Examples Nuget com.anyline.xamarin.examples_* LICENSE.md README.md
	CertUtil -hashfile anyline-ocr-xamarin-module.zip MD5
else
	zip -rq anyline-ocr-xamarin-module.zip . -x "*.git*" -x "*.nupkg" -x "*.DS_Store"
	md5 anyline-ocr-xamarin-module.zip
endif

# Builds everything and archives the bundle for release
bundle-release: set-anyline-version build-android-sdk build-ios-sdk reference-nuget-packages build-android-examples build-ios-examples clean-build-folders archive

bundle-and-draft-new-github-release: bundle-release draft-github-release upload-release-bundle

#SETUP

set-anyline-version:
ifeq ($(OS),Windows_NT)
	# Change SDK version
	@sed -i "s/^\[assembly: AssemblyVersion.*/\[assembly: AssemblyVersion(\"$(MAJOR_VERSION_ANDROID).$(MINOR_VERSION_ANDROID).$(BUILD_NUMBER_ANDROID)\")\]/" BindingSource/AnylineXamarinSDK.Droid/Properties/AssemblyInfo.cs
	@sed -i "s/^\[assembly: AssemblyVersion.*/\[assembly: AssemblyVersion(\"$(MAJOR_VERSION_IOS).$(MINOR_VERSION_IOS).$(BUILD_NUMBER_IOS)\")\]/" BindingSource/AnylineXamarinSDK.iOS/Properties/AssemblyInfo.cs
	# Change NuGet package version
	@sed -i "s/<version>.*/<version>$(MAJOR_VERSION_ANDROID).$(MINOR_VERSION_ANDROID).$(BUILD_NUMBER_ANDROID)<\/version>/" Nuget/Anyline.Xamarin.SDK.Droid.nuspec
	@sed -i "s/<version>.*/<version>$(MAJOR_VERSION).$(MINOR_VERSION).$(BUILD_NUMBER)<\/version>/" Nuget/Anyline.Xamarin.SDK.iOS.nuspec
else
	# Change SDK version
	@sed -i '' "s/^\[assembly: AssemblyVersion.*/\[assembly: AssemblyVersion(\"$(MAJOR_VERSION_ANDROID).$(MINOR_VERSION_ANDROID).$(BUILD_NUMBER_ANDROID)\")\]/" BindingSource/AnylineXamarinSDK.Droid/Properties/AssemblyInfo.cs
	@sed -i '' "s/^\[assembly: AssemblyVersion.*/\[assembly: AssemblyVersion(\"$(MAJOR_VERSION_IOS).$(MINOR_VERSION_IOS).$(BUILD_NUMBER_IOS)\")\]/" BindingSource/AnylineXamarinSDK.iOS/Properties/AssemblyInfo.cs
	# Change NuGet package version
	@sed -i '' "s/<version>.*/<version>$(MAJOR_VERSION_ANDROID).$(MINOR_VERSION_ANDROID).$(BUILD_NUMBER_ANDROID)<\/version>/" Nuget/Anyline.Xamarin.SDK.Droid.nuspec
	@sed -i '' "s/<version>.*/<version>$(MAJOR_VERSION_IOS).$(MINOR_VERSION_IOS).$(BUILD_NUMBER_IOS)<\/version>/" Nuget/Anyline.Xamarin.SDK.iOS.nuspec
endif

create-local-nuget-source:
	@-dotnet nuget remove source LocalNuGet
	@dotnet nuget add source $(PWD)/Nuget -n LocalNuGet

reference-nuget-packages: create-local-nuget-source
	# Referece the generated NuGet packages
	@-dotnet remove Examples/AnylineExamples.Droid/AnylineExamples.Droid.csproj package Anyline.Xamarin.SDK.Droid
	@-dotnet remove Examples/Xamarin.Forms/Anyline/Anyline.Android/Anyline.Android.csproj package Anyline.Xamarin.SDK.Droid
	@dotnet add Examples/AnylineExamples.Droid/AnylineExamples.Droid.csproj package Anyline.Xamarin.SDK.Droid -v $(MAJOR_VERSION_ANDROID).$(MINOR_VERSION_ANDROID).$(BUILD_NUMBER_ANDROID)
	@dotnet add Examples/Xamarin.Forms/Anyline/Anyline.Android/Anyline.Android.csproj package Anyline.Xamarin.SDK.Droid -v $(MAJOR_VERSION_ANDROID).$(MINOR_VERSION_ANDROID).$(BUILD_NUMBER_ANDROID)

	@-dotnet remove Examples/AnylineExamples.iOS/AnylineExamples.iOS.csproj package Anyline.Xamarin.SDK.iOS
	@-dotnet remove Examples/Xamarin.Forms/Anyline/Anyline.iOS/Anyline.iOS.csproj package Anyline.Xamarin.SDK.iOS
	@dotnet add Examples/AnylineExamples.iOS/AnylineExamples.iOS.csproj package Anyline.Xamarin.SDK.iOS -v $(MAJOR_VERSION_IOS).$(MINOR_VERSION_IOS).$(BUILD_NUMBER_IOS)
	@dotnet add Examples/Xamarin.Forms/Anyline/Anyline.iOS/Anyline.iOS.csproj package Anyline.Xamarin.SDK.iOS -v $(MAJOR_VERSION_IOS).$(MINOR_VERSION_IOS).$(BUILD_NUMBER_IOS)


#GitHub

draft-github-release:
	gh release create v$(MAJOR_VERSION).$(MINOR_VERSION) -d -t "Anyline Xamarin SDK $(MAJOR_VERSION).$(MINOR_VERSION)" -n "https://documentation.anyline.com/toc/platforms/xamarin/release_guide/index.html" -R github.com/Anyline/anyline-ocr-xamarin-module 

upload-release-bundle:
	gh release upload v$(MAJOR_VERSION).$(MINOR_VERSION) anyline-ocr-xamarin-module.zip -R github.com/Anyline/anyline-ocr-xamarin-module

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