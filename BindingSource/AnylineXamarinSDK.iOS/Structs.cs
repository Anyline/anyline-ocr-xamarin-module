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
        LicenseNotYetInitialized = 3019,
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
        JSONError = 12001,
        FileSystemError = 13001,
        CacheErrorNoLogsFound = 14001,
        CacheErrorZipCreationFailed = 14002
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
        ContourUnderline = ContourRect,
        ContourPoint = ContourRect,
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
        Parallel,
        ParallelFirstScan
    }
}