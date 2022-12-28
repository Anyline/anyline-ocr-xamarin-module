using System;
using System.Runtime.InteropServices;
//using Anyline;
using ObjCRuntime;

namespace AnylineXamarinSDK.iOS
{
    [Native]
    public enum ALPictureResolution : ulong
    {
        None = 0,
        Highest = 1,
        ALPictureResolution1080 = 2,
        ALPictureResolution720 = 3,
        ALPictureResolution480 = 4
    }

    [Native]
    public enum ALCaptureViewResolution : ulong
    {
        ALCaptureViewResolution1080 = 0,
        ALCaptureViewResolution720 = 1,
        ALCaptureViewResolution480 = 2
    }

    [Native]
    public enum ALErrorCode : long
    {
        TypeError = 2002,
        ParameterInvalid = 2003,
        LicenseKeyInvalid = 3001,
        LicenseNotValidForFunction = 3002,
        WatermarkImageNotFound = 3003,
        WatermarkNotOnWindow = 3004,
        WatermarkNotCorrectInViewHierarchy = 3005,
        WatermarkHidden = 3006,
        WatermarkOutsideApplicationFrame = 3007,
        WatermarkNotNearCutout = 3008,
        WatermarkViewBoundsOutOfSnyc = 3009,
        WatermarkViewTooSmall = 3010,
        WatermarkViewNoSubviewsAllowed = 3011,
        WatermarkViewAlphaViolation = 3012,
        WatermarkViewCountViolation = 3013,
        WatermarkViewSubviewOnTopViolation = 3014,
        WatermarkImageModified = 3015,
        LicenseNotValidForFeature = 3018,
        CameraResolutionNotSupportedByDevice = 8001,
        CameraAccessDenied = 8002,
        FlashNotAvailable = 8003,
        CameraNativeBarcodeEnabledTooEarly = 8006,
        CameraNativeBarcodeUnsupportedFormat = 8007,
        NFCTagErrorResponseError = 10001,
        NFCTagErrorInvalidResponse = 10002,
        NFCTagErrorUnexpectedError = 10003,
        NFCTagErrorNFCNotSupported = 10004,
        NFCTagErrorNoConnectedTag = 10005,
        NFCTagErrorD087Malformed = 10006,
        NFCTagErrorInvalidResponseChecksum = 10007,
        NFCTagErrorMissingMandatoryFields = 10008,
        NFCTagErrorCannotDecodeASN1Length = 10009,
        NFCTagErrorInvalidASN1Value = 10010,
        NFCTagErrorUnableToProtectAPDU = 10011,
        NFCTagErrorUnableToUnprotectAPDU = 10012,
        NFCTagErrorUnsupportedDataGroup = 10013,
        NFCTagErrorDataGroupNotRead = 10014,
        NFCTagErrorUnknownTag = 10015,
        NFCTagErrorUnknownImageFormat = 10016,
        NFCTagErrorNotImplemented = 10017,
        TimeoutError = 11001,
        JSONError = 12001
    }

    [Native]
    public enum ALFlashMode : ulong
    {
        Manual = 0,
        None = 1,
        Auto = 2,
        ManualOff = 3,
        ManualOn = 4
    }

    [Native]
    public enum ALFlashAlignment : ulong
    {
        Top = 0,
        TopLeft = 1,
        TopRight = 2,
        Bottom = 3,
        BottomLeft = 4,
        BottomRight = 5
    }

    [Native]
    public enum ALCutoutAlignment : ulong
    {
        Top = 0,
        TopHalf,
        Center,
        BottomHalf,
        Bottom
    }

    [Native]
    public enum ALCutoutAnimationStyle : ulong
    {
        None = 0,
        Fade,
        Zoom
    }

    [Native]
    public enum ALScanFeedbackStyle : ulong
    {
        Rect = 0,
        ContourRect,
        ContourUnderline,
        ContourPoint,
        AnimatedRect,
        None
    }

    [Native]
    public enum ALFeedbackAnimationStyle : ulong
    {
        TraverseSingle = 0,
        TraverseMulti,
        Kitt,
        Blink,
        Resize,
        Pulse,
        PulseRandom,
        None
    }

    [Native]
    public enum ALCompositeProcessingMode : ulong
    {
        Sequential,
        Parallel
    }


    // [Native]
    // public enum ALCutoutAlignment : ulong
    // {
    //     Top = 0,
    //     TopHalf = 1,
    //     Middle = 2,
    //     BottomHalf = 3,
    //     Bottom = 4
    // }

    // [Native]
    // public enum ALCutoutAnimation : ulong
    // {
    //     None = 0,
    //     Zoom = 1,
    //     Fade = 2
    // }

    // [Native]
    // public enum ALPictureResolution : ulong
    // {
    //     None = 0,
    //     Highest = 1,
    //     ALPictureResolution1080 = 2,
    //     ALPictureResolution720 = 3,
    //     ALPictureResolution480 = 4
    // }

    // [Native]
    // public enum ALCaptureViewResolution : ulong
    // {
    //     ALCaptureViewResolution1080 = 0,
    //     ALCaptureViewResolution720 = 1,
    //     ALCaptureViewResolution480 = 2
    // }

    // [Native]
    // public enum ALCaptureViewMode : ulong
    // {
    //     Bgra = 0,
    //     Yuv = 1
    // }

    // [Native]
    // public enum ALFlashMode : ulong
    // {
    //     Manual = 0,
    //     None = 1,
    //     Auto = 2
    // }

    // [Native]
    // public enum ALFlashAlignment : ulong
    // {
    //     Top = 0,
    //     TopLeft = 1,
    //     TopRight = 2,
    //     Bottom = 3,
    //     BottomLeft = 4,
    //     BottomRight = 5
    // }

    // [Native]
    // public enum ALUIFeedbackStyle : long
    // {
    //     Rect = 0,
    //     ContourRect = 1,
    //     ContourUnderline = 2,
    //     ContourPolong = 3,
    //     None = 4
    // }

    // [Native]
    // public enum ALUIVisualFeedbackAnimation : long
    // {
    //     TraverseSingle = 0,
    //     TraverseMulti = 1,
    //     Kitt = 2,
    //     Blink = 3,
    //     Resize = 4,
    //     Pulse = 5,
    //     PulseRandom = 6,
    //     None = 7
    // }

    // [Native]
    // public enum ALFlashStatus : long
    // {
    //     On,
    //     Off,
    //     Auto
    // }

    // [Native]
    // public enum ALReportingMode : long
    // {
    //     Enabled,
    //     Disabled,
    //     NotSet
    // }

    // [Native]
    // public enum ALErrorCode : long
    // {
    //     OperationNotFound = 1001,
    //     SyntaxError = 2001,
    //     TypeError = 2002,
    //     ParameterInvalid = 2003,
    //     LicenseKeyInvalid = 3001,
    //     LicenseNotValidForFunction = 3002,
    //     LicenseNotValidForFeature = 3003,
    //     WatermarkImageNotFound = 3003,
    //     WatermarkNotOnWindow = 3004,
    //     WatermarkNotCorrectInViewHierarchy = 3005,
    //     WatermarkHidden = 3006,
    //     WatermarkOutsideApplicationFrame = 3007,
    //     WatermarkNotNearCutout = 3008,
    //     WatermarkViewBoundsOutOfSnyc = 3009,
    //     WatermarkViewTooSmall = 3010,
    //     WatermarkViewNoSubviewsAllowed = 3011,
    //     WatermarkViewAlphaViolation = 3012,
    //     WatermarkViewCountViolation = 3013,
    //     WatermarkViewSubviewOnTopViolation = 3014,
    //     WatermarkImageModified = 3015,
    //     WatermarkUnknownError = 3016,
    //     ArgumentIsNull = 4001,
    //     ArgumentIsEmpty = 4002,
    //     ArgumentNotValid = 4003,
    //     longerpreterNotLoaded = 4004,
    //     NotEnoughContoursFound = 5001,
    //     StackDidNotFoundResult = 5002,
    //     DigitFirstDistanceExceeded = 5003,
    //     DistanceBetweenDigitsExceeded = 5004,
    //     DistanceViolationsNotResolved = 5005,
    //     ResultNotValid = 5006,
    //     InvalidDataPolongIdentifier = 5007,
    //     RegionOflongerestOutsideImageBounds = 5008,
    //     NotEnoughPolongsFound = 5009,
    //     AnglesOutsideOfTolerance = 5010,
    //     ImageNotSharp = 5011,
    //     TooDark = 5012,
    //     TooMuchReflections = 5013,
    //     ConfidenceNotReached = 5014,
    //     StringPatternNotMatching = 5015,
    //     longAssertionFailed = 5016,
    //     DocumentRatioOutsideOfTolerance = 5019,
    //     DocumentBoundsOutsideOfTolerance = 5020,
    //     PolongsOutOfCutout = 5021,
    //     OtherConditionNotMet = 5555,
    //     NoInformationFound = 6001,
    //     ImageColorConvertionProblem = 6002,
    //     ImageProviderIsNil = 7001,
    //     RunStopError = 7002,
    //     SingleImageRunError = 7003,
    //     CameraResolutionNotSupportedByDevice = 8001,
    //     CameraAccessDenied = 8002,
    //     FlashNotAvailable = 8003,
    //     CameraConnectionError = 8004,
    //     ModuleSimpleOCRConfigIsNil = 9001,
    //     ModuleSimpleOCRConfigTesseractConfigIsNil = 9002,
    //     ModuleSimpleOCRConfigTextHeightNotSet = 9003,
    //     BarcodeModuleNativeDelegateWrong = 9004,
    //     EnergyScanPluginBarcodeNotSupported = 9005,
    //     ModuleSimpleOCRConfigLanguagesConfigIsNil = 9006,
    //     InvalidConfigSet = 9007,
    //     NFCTagErrorResponseError = 10001,
    //     NFCTagErrorInvalidResponse = 10002,
    //     NFCTagErrorUnexpectedError = 10003,
    //     NFCTagErrorNFCNotSupported = 10004,
    //     NFCTagErrorNoConnectedTag = 10005,
    //     NFCTagErrorD087Malformed = 10006,
    //     NFCTagErrorInvalidResponseChecksum = 10007,
    //     NFCTagErrorMissingMandatoryFields = 10008,
    //     NFCTagErrorCannotDecodeASN1Length = 10009,
    //     NFCTagErrorInvalidASN1Value = 10010,
    //     NFCTagErrorUnableToProtectAPDU = 10011,
    //     NFCTagErrorUnableToUnprotectAPDU = 10012,
    //     NFCTagErrorUnsupportedDataGroup = 10013,
    //     NFCTagErrorDataGroupNotRead = 10014,
    //     NFCTagErrorUnknownTag = 10015,
    //     NFCTagErrorUnknownImageFormat = 10016,
    //     NFCTagErrorNotImplemented = 10017
    // }

    // [StructLayout(LayoutKind.Sequential)]
    // public struct ALCharacterRange
    // {
    //     public long minCharacterCount;
    //     public long maxCharacterCount;
    // }

    // [Native]
    // public enum ALScanResultState : long
    // {
    //     UserDidAbortState = 0,
    //     ScanSuccessfulState = 1,
    //     ScanErrorWrongResultState = 2,
    //     UserDidEnterManuallyState = 4,
    //     ScanErrorResultAlreadyUsedState = 5,
    //     ScanErrorResultAlreadyExpiredState = 6,
    //     StateUserAccountInactive = 10,
    //     StateUserAccountLocked = 11,
    //     StateUserReachedScanLimit = 12,
    //     StateNetworkTimeout = 13,
    //     StateModuleSuccess = 21,
    //     StateModuleAbort = 22,
    //     StateUnknownError = 99
    // }

    // [Native]
    // public enum ALRunFailure : long
    // {
    //     Unknown = -1,
    //     Unkown = Unknown,
    //     NoLinesFound = -2,
    //     NoTextFound = -3,
    //     ConfidenceNotReached = -4,
    //     ResultNotValid = -5,
    //     SharpnessNotReached = -6,
    //     PolongsOutOfCutout = -7,
    //     IDTypeNotSupported = -8
    // }

    // [Native]
    // public enum ALScanMode : long
    // {
    //     AnalogMeter,
    //     SerialNumber,
    //     DigitalMeter,
    //     HeatMeter4,
    //     HeatMeter5,
    //     HeatMeter6,
    //     AutoAnalogDigitalMeter,
    //     DialMeter,
    //     DotMatrixMeter,
    //     Barcode
    // }

    // // added in 11
    // [Native]
    // public enum ALLicensePlateScanMode : long
    // {
    //     Auto = 0,
    //     Norway = 1,
    //     NorwaySpecial = 2,
    //     Austria = 3,
    //     Germany = 4,
    //     Czech = 5,
    //     Finland = 6,
    //     Ireland = 7,
    //     Croatia = 8,
    //     Poland = 9,
    //     Slovakia = 10,
    //     Slovenia = 11,
    //     UnitedKingdom = 12,
    //     France = 13,
    //     Albania = 14,
    //     Armenia = 15,
    //     Azerbaijan = 16,
    //     Belarus = 17,
    //     Belgium = 18,
    //     BosniaAndHerzegovina = 19,
    //     Bulgaria = 20,
    //     Cyprus = 21,
    //     Denmark = 22,
    //     Estonia = 23,
    //     Georgia = 24,
    //     Greece = 25,
    //     Hungary = 26,
    //     Iceland = 27,
    //     Italy = 28,
    //     Latvia = 29,
    //     Liechtenstein = 30,
    //     Lithuania = 31,
    //     Luxembourg = 32,
    //     Malta = 33,
    //     Moldova = 34,
    //     Monaco = 35,
    //     Montenegro = 36,
    //     Netherlands = 37,
    //     NorthMacedonia = 38,
    //     Portugal = 39,
    //     Romania = 40,
    //     Russia = 41,
    //     Serbia = 42,
    //     Spain = 43,
    //     Sweden = 44,
    //     Turkey = 45,
    //     Ukraine = 46,
    //     Switzerland = 47,
    //     Andorra = 48
    // }

    // [Native]
    // public enum ALDocumentError : long
    // {
    //     Unknown = -1,
    //     Unkown = Unknown,
    //     OutlineNotFound = -2,
    //     SkewTooHigh = -3,
    //     GlareDetected = -4,
    //     ImageTooDark = -5,
    //     NotSharp = -6,
    //     ShakeDetected = -7,
    //     RatioOutsideOfTolerance = -8,
    //     BoundsOutsideOfTolerance = -9,
    //     DontMove = -10
    // }
    
    // [StructLayout(LayoutKind.Sequential)]
    // public struct ALRange
    // {
    //     public ulong min;
    //     public ulong max;
    // }
    
    // [Native]
    // public enum ALOCRScanMode : long
    // {
    //     Line,
    //     Grid,
    //     Auto
    // }

    // [Native]
    // public enum ALContainerScanMode : long
    // {
    //     Horizontal,
    //     Vertical
    // }

    // [Native]
    // public enum ALTINScanMode : long
    // {
    //     DotStrict,
    //     Dot,
    //     Universal
    // }

    // [Native]
    // public enum ALTINUpsideDownMode : long
    // {
    //     Disabled = 0,
    //     Enabled = 1,
    //     Auto = 2
    // }

    // [Native]
    // public enum ALFieldScanOption : long
    // {
    //     Mandatory = 0,
    //     Optional = 1,
    //     Disabled = 2,
    //     Default = 3
    // }

    // [Native]
    // public enum ALUniversalIDLayoutType : long
    // {
    //     DrivingLicense = 0,
    //     Mrz = 1,
    //     IDFront = 2
    // }
}