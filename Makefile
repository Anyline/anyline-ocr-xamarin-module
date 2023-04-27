## The recipes depend on the following Environment Variables: ##

# //////////////////////////////////////////////////////////// RELEASE //////////////////////////////////////////////////////////// #
# ANYLINE_XAMARIN_SDK_VERSION
# //////////////////////////////////////////////////////////// RELEASE //////////////////////////////////////////////////////////// #


# ////////////////////////////////////////////////////////////// iOS ////////////////////////////////////////////////////////////// #
# ANYLINE_IOS_SDK_VERSION
# BUNDLE_VERSION_IOS
# ////////////////////////////////////////////////////////////// iOS ////////////////////////////////////////////////////////////// #


# //////////////////////////////////////////////////////////// ANDROID //////////////////////////////////////////////////////////// #
# ANYLINE_ANDROID_SDK_VERSION
# VERSION_CODE_ANDROID	- Used in the Android Examples App - Cannot be 0.
# KEYSTORE_PATH			- Used to sign the final Examples APK
# KEYSTORE_RELEASE_PW	- Used to sign the final Examples APK
# ANDROID_SDK_URL		- Used in the replace-android-sdk recipe		| 	Both env. variables are required
# ANDROID_JAVADOC_URL	- Used in the replace-android-sdk recipe		| 	for the download-android-sdk recipe
# //////////////////////////////////////////////////////////// ANDROID //////////////////////////////////////////////////////////// #


# //////////////////////////////////////////////////////// WINDOWS MACHINES //////////////////////////////////////////////////////// #
# WINDOWS machines will also require setting the PWD env. variable: #
# PWD=%cd%
# //////////////////////////////////////////////////////// WINDOWS MACHINES //////////////////////////////////////////////////////// #

# ///////////////////////////////////////////////////////////// TOOLS ////////////////////////////////////////////////////////////// #
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
# curl
# gh (GitHub)
# ///////////////////////////////////////////////////////////// TOOLS ////////////////////////////////////////////////////////////// #

all: help
help: 
	@echo "You probably wanted to call:" 
	@echo make bundle-release

# NATIVE SDKs

replace-android-sdk:
# Download the SDK from the ANDROID_SDK_URL env. variable
	mkdir -p BindingSource/AnylineXamarinSDK.Droid/Jars
	curl $(ANDROID_SDK_URL) -o "BindingSource/AnylineXamarinSDK.Droid/Jars/anylinesdk.aar"
# Download the JAVADOC from the ANDROID_JAVADOC_URL env. variable
	curl $(ANDROID_JAVADOC_URL) -o "javadoc.jar"
# Clear old javadoc content, expand, and copy the new one
	@rm -rf javadoc_content
	@unzip -q javadoc.jar -d javadoc_content
	@rm -rf "BindingSource/AnylineXamarinSDK.Droid/Assets/tools/javadoc"
	@cp -r "javadoc_content" "BindingSource/AnylineXamarinSDK.Droid/Assets/tools/javadoc"
	@rm -rf "javadoc_content"
	@rm -rf "javadoc.jar"
	@echo "Android SDK and Javadoc replaced"

replace-ios-sdk:
	@-rm -rf BindingSource/AnylineXamarinSDK.iOS/Anyline.framework
	@-rm BindingSource/AnylineXamarinSDK.iOS/Anyline.a
	@-rm -rf Nuget/AnylineResources.bundle
	cp -r $(IOS_FRAMEWORK_PATH)/Anyline.framework BindingSource/AnylineXamarinSDK.iOS/Anyline.framework
	cp $(IOS_FRAMEWORK_PATH)/Anyline.framework/Anyline BindingSource/AnylineXamarinSDK.iOS/Anyline.a
	cp -r $(IOS_FRAMEWORK_PATH)/AnylineResources.bundle Nuget/
	@echo "iOS Framework replaced using PATH: ${IOS_FRAMEWORK_PATH}"
 
replace-ios-sdk-from-github-release:
	@-rm -rf BindingSource/AnylineXamarinSDK.iOS/Anyline.framework
	@-rm BindingSource/AnylineXamarinSDK.iOS/Anyline.a
	@-rm -rf Nuget/AnylineResources.bundle
# Download the SDK from the IOS_FRAMEWORK_URL env. variable
	curl -L \
	https://github.com/Anyline/anyline-ocr-examples-ios/releases/download/v${ANYLINE_IOS_SDK_VERSION}/AnylineSDK_iOS_${ANYLINE_IOS_SDK_VERSION}.zip \
	-o "anyline_ios_sdk.zip"
	unzip -q "anyline_ios_sdk.zip" -d "anyline_ios_sdk"
	cp -r anyline_ios_sdk/AnylineSDK_iOS_${ANYLINE_IOS_SDK_VERSION}/Framework/Anyline.framework BindingSource/AnylineXamarinSDK.iOS/Anyline.framework
	cp -r anyline_ios_sdk/AnylineSDK_iOS_${ANYLINE_IOS_SDK_VERSION}/Framework/Anyline.framework/Anyline BindingSource/AnylineXamarinSDK.iOS/Anyline.a
	cp -r anyline_ios_sdk/AnylineSDK_iOS_${ANYLINE_IOS_SDK_VERSION}/Framework/AnylineResources.bundle Nuget/
	@rm "anyline_ios_sdk.zip"
	@rm -rf "anyline_ios_sdk"
	@echo "iOS Framework replaced using GitHub release: ${ANYLINE_IOS_SDK_VERSION}"
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
	@mv "Examples/AnylineExamples.Droid/bin/Release/com.anyline.xamarin.examples.apk" "com.anyline.xamarin.examples_$(ANYLINE_ANDROID_SDK_VERSION).apk"


build-ios-sdk:
# Needs a MacOS to run
ifneq ($(OS),Windows_NT)
	# Build iOS SDK
	@msbuild /p:Configuration="Release" \
		/p:Platform="AnyCPU" \
		/p:BuildIpa=false \
		/v:minimal \
		/t:rebuild "BindingSource/AnylineXamarinSDK.iOS/AnylineXamarinSDK.iOS.csproj"
else
	@echo ""
	@echo "WARNING: This recipe must run on a MacOS to build the iOS SDK DLL."
	@echo ""
endif

	@rm -rf Nuget/Anyline.Xamarin.SDK.iOS.*.nupkg
	@nuget pack Nuget/Anyline.Xamarin.SDK.iOS.nuspec -OutputDirectory Nuget

build-ios-examples:
# Needs a MacOS to run
ifneq ($(OS),Windows_NT)
	# Build iOS Examples App
	@nuget restore Examples/AnylineExamples.iOS/AnylineExamples.iOS.csproj
	@msbuild /p:Configuration="Release" \
		/p:Platform="iPhone" \
		/p:BuildIpa=false \
		/v:minimal \
		/t:rebuild "Examples/AnylineExamples.iOS/AnylineExamples.iOS.csproj"
else
	@echo ""
	@echo "WARNING: This recipe must run on a MacOS to build the iOS Examples App."
	@echo ""
endif

build-ios-examples-ipa:
# Needs a MacOS to run
ifneq ($(OS),Windows_NT)
	# Build iOS Examples App
	@nuget restore Examples/AnylineExamples.iOS/AnylineExamples.iOS.csproj
	@msbuild /p:Configuration="Release" \
		/p:Platform="iPhone" \
		/p:IpaPackageDir="$(PWD)" \
		/p:BuildIpa=true \
		/v:minimal \
		/t:rebuild "Examples/AnylineExamples.iOS/AnylineExamples.iOS.csproj"
else
	@echo ""
	@echo "WARNING: This recipe must run on a MacOS to build the iOS .ipa file."
	@echo ""
endif

# Release

archive:
# -- Zips the release bundle, excluding Git files, bin, obj and vs folders --
ifeq ($(OS),Windows_NT)
	tar.exe --exclude=*.nupkg --exclude=*.DS_Store -acf anyline-ocr-xamarin-module.zip BindingSource Examples Nuget com.anyline.xamarin.examples_* LICENSE.md README.md $(SWID_TAG_NAME)
	CertUtil -hashfile anyline-ocr-xamarin-module.zip MD5
else
	zip -rq anyline-ocr-xamarin-module.zip . -x "*.git*" -x "*.nupkg" -x "*.DS_Store" -x "*.ipa"
	md5 anyline-ocr-xamarin-module.zip
endif

android-release: set-anyline-android-version build-android-sdk reference-android-nuget-package build-android-examples 

ios-release: set-anyline-ios-version build-ios-sdk reference-ios-nuget-package build-ios-examples-ipa

bundle-release: clean-nuget-anyline-cache android-release ios-release clean-build-files-and-folders create-corpus-swid-tag archive

bundle-and-draft-new-github-release: bundle-release draft-github-release upload-release-bundle

create-corpus-swid-tag:
ifneq ($(CORPUS_SWID_SCRIPT_PATH),)
	python $(CORPUS_SWID_SCRIPT_PATH) "Anyline Xamarin SDK" "com.anyline.xamarin" "$(ANYLINE_XAMARIN_SDK_VERSION)" "$(SWID_TAG_NAME)" "." "."
endif

#SETUP

set-anyline-android-version:
ifeq ($(OS),Windows_NT)
# Change SDK version
	@sed -i "s/^\[assembly: AssemblyVersion.*/\[assembly: AssemblyVersion(\"$(ANYLINE_ANDROID_SDK_VERSION)\")\]/" BindingSource/AnylineXamarinSDK.Droid/Properties/AssemblyInfo.cs
# Change NuGet package version
	@sed -i "s/<version>.*/<version>$(ANYLINE_ANDROID_SDK_VERSION)<\/version>/" Nuget/Anyline.Xamarin.SDK.Droid.nuspec
else
# Change SDK version
	@sed -i'' "s/^\[assembly: AssemblyVersion.*/\[assembly: AssemblyVersion(\"$(ANYLINE_ANDROID_SDK_VERSION)\")\]/" BindingSource/AnylineXamarinSDK.Droid/Properties/AssemblyInfo.cs
# Change NuGet package version
	@sed -i'' "s/<version>.*/<version>$(ANYLINE_ANDROID_SDK_VERSION)<\/version>/" Nuget/Anyline.Xamarin.SDK.Droid.nuspec
endif

set-anyline-ios-version:
ifeq ($(OS),Windows_NT)
# Change SDK version
	@sed -i "s/^\[assembly: AssemblyVersion.*/\[assembly: AssemblyVersion(\"$(ANYLINE_IOS_SDK_VERSION)\")\]/" BindingSource/AnylineXamarinSDK.iOS/Properties/AssemblyInfo.cs
# Change NuGet package version
	@sed -i "s/<version>.*/<version>$(ANYLINE_IOS_SDK_VERSION)<\/version>/" Nuget/Anyline.Xamarin.SDK.iOS.nuspec
else
# Change SDK version
	@sed -i'' "s/^\[assembly: AssemblyVersion.*/\[assembly: AssemblyVersion(\"$(ANYLINE_IOS_SDK_VERSION)\")\]/" BindingSource/AnylineXamarinSDK.iOS/Properties/AssemblyInfo.cs
# Change NuGet package version
	@sed -i'' "s/<version>.*/<version>$(ANYLINE_IOS_SDK_VERSION)<\/version>/" Nuget/Anyline.Xamarin.SDK.iOS.nuspec
endif

create-local-nuget-source: clean-nuget-anyline-cache
	@-dotnet nuget remove source LocalNuGet
	@dotnet nuget add source $(PWD)/Nuget -n LocalNuGet

reference-android-nuget-package: create-local-nuget-source
	# Referece the generated NuGet packages
	@-dotnet remove Examples/AnylineExamples.Droid/AnylineExamples.Droid.csproj package Anyline.Xamarin.SDK.Droid
	@-dotnet remove Examples/Xamarin.Forms/Anyline/Anyline.Android/Anyline.Android.csproj package Anyline.Xamarin.SDK.Droid
	@dotnet add Examples/AnylineExamples.Droid/AnylineExamples.Droid.csproj package Anyline.Xamarin.SDK.Droid -v $(ANYLINE_ANDROID_SDK_VERSION)
	@dotnet add Examples/Xamarin.Forms/Anyline/Anyline.Android/Anyline.Android.csproj package Anyline.Xamarin.SDK.Droid -v $(ANYLINE_ANDROID_SDK_VERSION)

reference-ios-nuget-package: create-local-nuget-source
	# Referece the generated NuGet packages
	@-dotnet remove Examples/AnylineExamples.iOS/AnylineExamples.iOS.csproj package Anyline.Xamarin.SDK.iOS
	@-dotnet remove Examples/Xamarin.Forms/Anyline/Anyline.iOS/Anyline.iOS.csproj package Anyline.Xamarin.SDK.iOS
	@dotnet add Examples/AnylineExamples.iOS/AnylineExamples.iOS.csproj package Anyline.Xamarin.SDK.iOS -v $(ANYLINE_IOS_SDK_VERSION)
	@dotnet add Examples/Xamarin.Forms/Anyline/Anyline.iOS/Anyline.iOS.csproj package Anyline.Xamarin.SDK.iOS -v $(ANYLINE_IOS_SDK_VERSION)

#GitHub

draft-github-release:
	gh release create v$(ANYLINE_XAMARIN_SDK_VERSION) -d -t "Anyline Xamarin SDK $(ANYLINE_XAMARIN_SDK_VERSION)" -n "https://documentation.anyline.com/toc/platforms/xamarin/release_guide/index.html" --target "$(BRANCH)" -R github.com/Anyline/anyline-ocr-xamarin-module 

upload-release-bundle:
	gh release upload v$(ANYLINE_XAMARIN_SDK_VERSION) anyline-ocr-xamarin-module.zip -R github.com/Anyline/anyline-ocr-xamarin-module

# CLEAN

clean-nuget-anyline-cache:
	@rm -rf $(shell nuget locals all -list | grep global-packages | sed 's/global-packages://' | sed 's/\\/\//g')/anyline.xamarin.sdk.*

clean-build-files-and-folders: 	

	@rm -rf anyline-ocr-xamarin-module.zip

	@rm -rf BindingSource/.vs
	@rm -rf Examples/.vs

	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline/.vs
	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline/bin
	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline/obj

	@rm -rf Examples/AnylineExamples.Droid/.vs
	@rm -rf Examples/AnylineExamples.Droid/bin
	@rm -rf Examples/AnylineExamples.Droid/obj

	@rm -rf Examples/AnylineExamples.iOS/.vs
	@rm -rf Examples/AnylineExamples.iOS/bin
	@rm -rf Examples/AnylineExamples.iOS/obj

	@rm -rf BindingSource/AnylineXamarinSDK.Droid/.vs
	@rm -rf BindingSource/AnylineXamarinSDK.Droid/bin
	@rm -rf BindingSource/AnylineXamarinSDK.Droid/obj

	@rm -rf BindingSource/AnylineXamarinSDK.iOS/.vs
	@rm -rf BindingSource/AnylineXamarinSDK.iOS/bin
	@rm -rf BindingSource/AnylineXamarinSDK.iOS/obj

	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline.Android/.vs
	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline.Android/bin
	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline.Android/obj

	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline.iOS/.vs
	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline.iOS/bin
	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline.iOS/obj

	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline.UWP/.vs
	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline.UWP/bin
	@rm -rf Examples/Xamarin.Forms/Anyline/Anyline.UWP/obj

	@rm -rf *.ipa