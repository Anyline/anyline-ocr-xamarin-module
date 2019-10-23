using System;
using ObjCRuntime;

[assembly: LinkWith ("Anyline.a",    
    LinkTarget = LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64,
    Frameworks = "ImageIO AssetsLibrary AVFoundation CoreMedia CoreVideo AudioToolbox QuartzCore Accelerate Security CoreMotion CoreImage WebKit CoreNFC",
    LinkerFlags = "-lz -lc++ -liconv -all_load -ObjC -v "

    // redefine all extern const symbols, see https://forums.xamarin.com/discussion/8572/how-do-you-bind-extern-nsstring-const

    // _r -> _R
    + " -Xlinker -alias -Xlinker _regexForEmail -Xlinker _RegexForEmail"
    + " -Xlinker -alias -Xlinker _regexForURL -Xlinker _RegexForURL"
    + " -Xlinker -alias -Xlinker _regexForPriceTag -Xlinker _RegexForPriceTag"
    + " -Xlinker -alias -Xlinker _regexForISBN -Xlinker _RegexForISBN"
    + " -Xlinker -alias -Xlinker _regexForVIN -Xlinker _RegexForVIN"
    + " -Xlinker -alias -Xlinker _regexForIMEI -Xlinker _RegexForIMEI"

    // _c -> _C
    + " -Xlinker -alias -Xlinker _charWhiteListForEmail -Xlinker _CharWhiteListForEmail"
    + " -Xlinker -alias -Xlinker _charWhiteListForURL -Xlinker _CharWhiteListForURL"
    + " -Xlinker -alias -Xlinker _charWhiteListForPriceTag -Xlinker _CharWhiteListForPriceTag"
    + " -Xlinker -alias -Xlinker _charWhiteListForISBN -Xlinker _CharWhiteListForISBN"
    + " -Xlinker -alias -Xlinker _charWhiteListForVIN -Xlinker _CharWhiteListForVIN"
    + " -Xlinker -alias -Xlinker _charWhiteListForIMEI -Xlinker _CharWhiteListForIMEI"

    // _AL -> _
    + " -Xlinker -alias -Xlinker _ALDocumentRatioDINAXLandscape -Xlinker _DocumentRatioDINAXLandscape"
    + " -Xlinker -alias -Xlinker _ALDocumentRatioDINAXPortrait -Xlinker _DocumentRatioDINAXPortrait"
    + " -Xlinker -alias -Xlinker _ALDocumentRatioCompimentsSlipLandscape -Xlinker _DocumentRatioCompimentsSlipLandscape"
    + " -Xlinker -alias -Xlinker _ALDocumentRatioCompimentsSlipPortrait -Xlinker _DocumentRatioCompimentsSlipPortrait"
    + " -Xlinker -alias -Xlinker _ALDocumentRatioBusinessCardLandscape -Xlinker _DocumentRatioBusinessCardLandscape"
    + " -Xlinker -alias -Xlinker _ALDocumentRatioBusinessCardPortrait -Xlinker _DocumentRatioBusinessCardPortrait"
    + " -Xlinker -alias -Xlinker _ALDocumentRatioLetterLandscape -Xlinker _DocumentRatioLetterLandscape"
    + " -Xlinker -alias -Xlinker _ALDocumentRatioLetterPortrait -Xlinker _DocumentRatioLetterPortrait",
    
    ForceLoad = true,
    SmartLink = true,
    IsCxx = false)]

