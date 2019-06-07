using System;
using System.Runtime.InteropServices;
//using Anyline;
using ObjCRuntime;

namespace AnylineXamarinSDK.iOS
{
    [Native]
    public enum ALCutoutAlignment : long
    {
        Top = 0,
        TopHalf = 1,
        Middle = 2,
        BottomHalf = 3,
        Bottom = 4
    }

    [Native]
    public enum ALPictureResolution : long
    {
        None = 0,
        Highest = 1,
        ALPictureResolution1080 = 2,
        ALPictureResolution720 = 3,
        ALPictureResolution480 = 4
    }

    [Native]
    public enum ALCaptureViewResolution : long
    {
        ALCaptureViewResolution1080 = 0,
        ALCaptureViewResolution720 = 1,
        ALCaptureViewResolution480 = 2
    }

    [Native]
    public enum ALCaptureViewMode : long
    {
        Bgra = 0,
        Yuv = 1
    }

    [Native]
    public enum ALFlashMode : long
    {
        Manual = 0,
        None = 1,
        Auto = 2
    }

    [Native]
    public enum ALFlashAlignment : long
    {
        Top = 0,
        TopLeft = 1,
        TopRight = 2,
        Bottom = 3,
        BottomLeft = 4,
        BottomRight = 5
    }

    [Native]
    public enum ALUIFeedbackStyle : long
    {
        Rect = 0,
        ContourRect = 1,
        ContourUnderline = 2,
        ContourPoint = 3,
        None = 4
    }

    [Native]
    public enum ALUIVisualFeedbackAnimation : long
    {
        TraverseSingle = 0,
        TraverseMulti = 1,
        Kitt = 2,
        Blink = 3,
        Resize = 4,
        Pulse = 5,
        PulseRandom = 6,
        None = 7
    }

    [Native]
    public enum ALFlashStatus : long
    {
        On,
        Off,
        Auto
    }

    [Native]
    public enum ALReportingMode : long
    {
        Enabled,
        Disabled,
        NotSet
    }

    [Native]
    public enum ALErrorCode : long
    {
        OperationNotFound = 1001,
        SyntaxError = 2001,
        TypeError = 2002,
        ParameterInvalid = 2003,
        LicenseKeyInvalid = 3001,
        LicenseNotValidForFunction = 3002,
        LicenseNotValidForFeature = 3003,
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
        WatermarkUnknownError = 3016,
        ArgumentIsNull = 4001,
        ArgumentIsEmpty = 4002,
        ArgumentNotValid = 4003,
        InterpreterNotLoaded = 4004,
        NotEnoughContoursFound = 5001,
        StackDidNotFoundResult = 5002,
        DigitFirstDistanceExceeded = 5003,
        DistanceBetweenDigitsExceeded = 5004,
        DistanceViolationsNotResolved = 5005,
        ResultNotValid = 5006,
        InvalidDataPointIdentifier = 5007,
        RegionOfInterestOutsideImageBounds = 5008,
        NotEnoughPointsFound = 5009,
        AnglesOutsideOfTolerance = 5010,
        ImageNotSharp = 5011,
        TooDark = 5012,
        TooMuchReflections = 5013,
        ConfidenceNotReached = 5014,
        StringPatternNotMatching = 5015,
        IntAssertionFailed = 5016,
        DocumentRatioOutsideOfTolerance = 5019,
        DocumentBoundsOutsideOfTolerance = 5020,
        PointsOutOfCutout = 5021,
        OtherConditionNotMet = 5555,
        NoInformationFound = 6001,
        ImageColorConvertionProblem = 6002,
        ImageProviderIsNil = 7001,
        RunStopError = 7002,
        SingleImageRunError = 7003,
        CameraResolutionNotSupportedByDevice = 8001,
        CameraAccessDenied = 8002,
        FlashNotAvailable = 8003,
        CameraConnectionError = 8004,
        ModuleSimpleOCRConfigIsNil = 9001,
        ModuleSimpleOCRConfigTesseractConfigIsNil = 9002,
        ModuleSimpleOCRConfigTextHeightNotSet = 9003,
        BarcodeModuleNativeDelegateWrong = 9004,
        EnergyScanPluginBarcodeNotSupported = 9005,
        ModuleSimpleOCRConfigLanguagesConfigIsNil = 9006
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ALCharacterRange
    {
        public int minCharacterCount;
        public int maxCharacterCount;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct ALRange
    {
        public nuint min;
        public nuint max;
    }

    [Native]
    public enum ALScanResultState : long
    {
        UserDidAbortState = 0,
        ScanSuccessfulState = 1,
        ScanErrorWrongResultState = 2,
        UserDidEnterManuallyState = 4,
        ScanErrorResultAlreadyUsedState = 5,
        ScanErrorResultAlreadyExpiredState = 6,
        StateUserAccountInactive = 10,
        StateUserAccountLocked = 11,
        StateUserReachedScanLimit = 12,
        StateNetworkTimeout = 13,
        StateModuleSuccess = 21,
        StateModuleAbort = 22,
        StateUnknownError = 99
    }

    [Native]
    public enum ALRunFailure : long
    {
        Unkown = -1,
        NoLinesFound = -2,
        NoTextFound = -3,
        ConfidenceNotReached = -4,
        ResultNotValid = -5,
        SharpnessNotReached = -6,
        PointsOutOfCutout = -7
    }

    [Native]
    public enum ALScanMode : long
    {
        AnalogMeter,
        SerialNumber,
        DigitalMeter,
        HeatMeter4,
        HeatMeter5,
        HeatMeter6,
        AutoAnalogDigitalMeter,
        DialMeter,
        DotMatrixMeter,
        Barcode
    }

    [Native]
    public enum ALBarcodeFormat : long
    {
        Aztec = 1 << 0,
        Codabar = 1 << 1,
        Code39 = 1 << 2,
        Code93 = 1 << 3,
        Code128 = 1 << 4,
        DataMatrix = 1 << 5,
        Ean8 = 1 << 6,
        Ean13 = 1 << 7,
        Itf = 1 << 8,
        Pdf417 = 1 << 9,
        Qr = 1 << 10,
        Rss14 = 1 << 11,
        RSSExpanded = 1 << 12,
        Upca = 1 << 13,
        Upce = 1 << 14,
        UPCEANExtension = 1 << 15,
        Unknown = 0,
        All = (Aztec | Codabar | Code39 | Code93 | Code128 | DataMatrix | Ean8 | Ean13 | Itf | Pdf417 | Qr | Rss14 | RSSExpanded | Upca | Upce | UPCEANExtension)
    }

    [Native]
    public enum ALFieldScanOption : long
    {
        Mandatory = 0,
        Optional = 1,
        Disabled = 2,
        Default = 3
    }

    [Native]
    public enum ALDrivingLicenseScanMode : long
    {
        At,
        De,
        Auto
    }

    [Native]
    public enum ALOCRScanMode : long
    {
        Line,
        Grid,
        Auto
    }

    [Native]
    public enum ALContainerScanMode : long
    {
        Horizontal,
        Vertical
    }

    [Native]
    public enum ALOCRError : long
    {
        Unkown = -1,
        NoLinesFound = -2,
        NoTextFound = -3,
        ConfidenceNotReached = -4,
        ResultNotValid = -5,
        SharpnessNotReached = -6
    }

    [Native]
    public enum ALDocumentError : long
    {
        Unkown = -1,
        OutlineNotFound = -2,
        SkewTooHigh = -3,
        GlareDetected = -4,
        ImageTooDark = -5,
        NotSharp = -6,
        ShakeDetected = -7,
        RatioOutsideOfTolerance = -8,
        BoundsOutsideOfTolerance = -9
    }
}