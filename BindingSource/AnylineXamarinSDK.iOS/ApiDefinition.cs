using System;
using AVFoundation;
using CoreGraphics;
using CoreMedia;
using CoreVideo;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Drawing;

/*
    OBJECTIVE SHARPIE COMMAND:    
    sharpie bind -sdk iphoneos10.2 Anyline.framework/Headers/Anyline.h -o Bindings -scope Anyline.framework/Headers -c -F Anyline.framework
*/

namespace AnylineXamarinSDK.iOS
{

    // @interface ALImage : NSObject
    [BaseType(typeof(NSObject))]
    interface ALImage
    {
        // @property (nonatomic, strong) UIImage * uiImage;
        [Export("uiImage", ArgumentSemantic.Strong)]
        UIImage UiImage { get; set; }

        // @property (assign, nonatomic) CVImageBufferRef imageBuffer;
        /*[Export("imageBuffer", ArgumentSemantic.Assign)]
        unsafe CVImageBufferRef* ImageBuffer { get; set; }*/

        // -(UIImage *)uiImageWithSpecOverlay:(ALROISpec *)displaySpec;
        /*[Export("uiImageWithSpecOverlay:")]
        UIImage UiImageWithSpecOverlay(ALROISpec displaySpec);*/

        // -(UIImage *)uiImageWithDisplayResults:(ALDisplayResult *)displayResult;
        [Export("uiImageWithDisplayResults:")]
        UIImage UiImageWithDisplayResults(ALDisplayResult displayResult);

        // -(UIImage *)uiImageWithDigitOverlay:(ALDataPoint *)digitSpec;
        [Export("uiImageWithDigitOverlay:")]
        UIImage UiImageWithDigitOverlay(ALDataPoint digitSpec);

        // -(UIImage *)uiImageWithRectOverlay:(CGRect)rectToDraw;
        [Export("uiImageWithRectOverlay:")]
        UIImage UiImageWithRectOverlay(CGRect rectToDraw);

        // -(UIImage *)uiImageWithSquareOverlay:(ALSquare *)square;
        [Export("uiImageWithSquareOverlay:")]
        UIImage UiImageWithSquareOverlay(ALSquare square);

        // -(UIImage *)uiImageWithHorizontalLines:(NSArray *)lines;
        [Export("uiImageWithHorizontalLines:")]
        UIImage UiImageWithHorizontalLines(NSObject[] lines);

        // -(UIImage *)uiImageWithVerticalLines:(NSArray *)lines;
        [Export("uiImageWithVerticalLines:")]
        UIImage UiImageWithVerticalLines(NSObject[] lines);

        // -(UIImage *)uiImageWithContours:(ALContours *)contours;
        [Export("uiImageWithContours:")]
        UIImage UiImageWithContours(ALContours contours);

        // -(instancetype)initWithUIImage:(UIImage *)uiImage;
        [Export("initWithUIImage:")]
        IntPtr Constructor(UIImage uiImage);

        // -(instancetype)initWithImageBuffer:(CVImageBufferRef)imageBuffer;
        /*[Export("initWithImageBuffer:")]
        unsafe IntPtr Constructor(CVImageBufferRef* imageBuffer);*/

        // -(BOOL)isEmpy;
        [Export("isEmpy")]
        bool IsEmpty { get; }
    }

    // @protocol ALImageProvider <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALImageProvider
    {
        // @required -(void)provideNewImageWithCompletionBlock:(ALImageProviderBlock)completionHandler;
        [Abstract]
        [Export("provideNewImageWithCompletionBlock:")]
        void ProvideNewImageWithCompletionBlock(ALImageProviderBlock completionHandler);

        // @required -(void)provideNewFullResolutionImageWithCompletionBlock:(ALImageProviderBlock)completionHandler;
        [Abstract]
        [Export("provideNewFullResolutionImageWithCompletionBlock:")]
        void ProvideNewFullResolutionImageWithCompletionBlock(ALImageProviderBlock completionHandler);

        // @optional -(void)provideStillImageWithCompletionBlock:(ALImageProviderBlock)completionHandler;
        [Export("provideStillImageWithCompletionBlock:")]
        void ProvideStillImageWithCompletionBlock(ALImageProviderBlock completionHandler);
    }

    // typedef void (^ALImageProviderBlock)(ALImage *, NSError *);
    delegate void ALImageProviderBlock(ALImage arg0, NSError arg1);

    // @protocol ALFlashButtonStatusDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALFlashButtonStatusDelegate
    {
        // @required -(void)flashButton:(ALFlashButton *)flashButton statusChanged:(ALFlashStatus)flashStatus;
        [Abstract]
        [Export("flashButton:statusChanged:")]
        void StatusChanged(ALFlashButton flashButton, ALFlashStatus flashStatus);
    }

    // @protocol ALFlashButtonAnimationDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALFlashButtonAnimationDelegate
    {
        // @optional -(void)flashButton:(ALFlashButton *)flashButton expanded:(BOOL)expanded;
        [Export("flashButton:expanded:")]
        void Expanded(ALFlashButton flashButton, bool expanded);
    }

    // @interface ALFlashButton : UIControl
    [BaseType(typeof(UIControl))]
    interface ALFlashButton
    {
        // @property (assign, nonatomic) BOOL expanded;
        [Export("expanded")]
        bool Expanded { get; set; }

        // @property (assign, nonatomic) BOOL expandLeft;
        [Export("expandLeft")]
        bool ExpandLeft { get; set; }

        // @property (nonatomic, strong) UIImageView * flashImage;
        [Export("flashImage", ArgumentSemantic.Strong)]
        UIImageView FlashImage { get; set; }

        // @property (assign, nonatomic) ALFlashStatus flashStatus;
        [Export("flashStatus", ArgumentSemantic.Assign)]
        ALFlashStatus FlashStatus { get; set; }

        [Wrap("WeakDelegate")]
        ALFlashButtonStatusDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ALFlashButtonStatusDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        [Wrap("WeakAnimationDelegate")]
        ALFlashButtonAnimationDelegate AnimationDelegate { get; set; }

        // @property (nonatomic, weak) id<ALFlashButtonAnimationDelegate> animationDelegate;
        [NullAllowed, Export("animationDelegate", ArgumentSemantic.Weak)]
        NSObject WeakAnimationDelegate { get; set; }

        // -(void)setExpanded:(BOOL)expanded animated:(BOOL)animated;
        [Export("setExpanded:animated:")]
        void SetExpanded(bool expanded, bool animated);

        // -(id)initWithFrame:(CGRect)frame flashImage:(UIImage *)flashImage;
        [Export("initWithFrame:flashImage:")]
        IntPtr Constructor(CGRect frame, UIImage flashImage);
    }

    // @protocol ALFlashButtonStatusDelegate <NSObject>
    /*[Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALFlashButtonStatusDelegate
    {
        // @required -(void)flashButton:(ALFlashButton *)flashButton statusChanged:(ALFlashStatus)flashStatus;
        [Abstract]
        [Export("flashButton:statusChanged:")]
        void StatusChanged(AnylineXamarinSDK.iOS.ALFlashButton flashButton, AnylineXamarinSDK.iOS.ALFlashStatus flashStatus);
    }*/

    // @interface ALTorchManager : NSObject <ALFlashButtonStatusDelegate>
    [BaseType(typeof(NSObject))]
    interface ALTorchManager
    {
        // @property (nonatomic, weak) AVCaptureDevice * captureDevice;
        [Export("captureDevice", ArgumentSemantic.Weak)]
        AVCaptureDevice CaptureDevice { get; set; }

        // @property (assign, nonatomic) ALFlashStatus flashStatus;
        [Export("flashStatus", ArgumentSemantic.Assign)]
        ALFlashStatus FlashStatus { get; set; }

        // -(void)setLevelForAutoFlash:(int)brightness;
        [Export("setLevelForAutoFlash:")]
        void SetLevelForAutoFlash(int brightness);

        // -(void)setCountForAutoFlash:(int)brightnessCount;
        [Export("setCountForAutoFlash:")]
        void SetCountForAutoFlash(int brightnessCount);

        // -(void)resetLightLevelCounter;
        [Export("resetLightLevelCounter")]
        void ResetLightLevelCounter();

        // -(void)calculateBrightnessCount:(float)brightness;
        [Export("calculateBrightnessCount:")]
        void CalculateBrightnessCount(float brightness);

        // -(void)setTorch:(BOOL)onOff;
        [Export("setTorch:")]
        void SetTorch(bool onOff);

        // -(BOOL)torchAvailable;
        [Export("torchAvailable")]
        bool TorchAvailable { get; }
    }
    
    // @interface AnylineVideoView : UIView <ALImageProvider>
    [BaseType(typeof(UIView))]
    interface AnylineVideoView  : ALImageProvider
    {
        // @property (readonly, nonatomic, strong) ALFlashButton * flashButton;
        [Export("flashButton", ArgumentSemantic.Strong)]
        ALFlashButton FlashButton { get; }

        // @property (readonly, nonatomic, strong) ALCutoutView * cutoutView;
        [Export("cutoutView", ArgumentSemantic.Strong)]
        ALCutoutView CutoutView { get; }

        // @property (readonly, nonatomic) CGRect watermarkRect;
        [Export("watermarkRect")]
        CGRect WatermarkRect { get; }

        // @property (nonatomic, strong) ALTorchManager * torchManager;
        [Export("torchManager", ArgumentSemantic.Strong)]
        ALTorchManager TorchManager { get; set; }

        [Wrap("WeakBarcodeDelegate")]
        NSObject BarcodeDelegate { get; set; }

        // @property (nonatomic, weak) id<AnylineNativeBarcodeDelegate> barcodeDelegate;
        [NullAllowed, Export("barcodeDelegate", ArgumentSemantic.Weak)]
        NSObject WeakBarcodeDelegate { get; set; }

        [Wrap("WeakSampleBufferDelegate")]
        AnylineVideoDataSampleBufferDelegate SampleBufferDelegate { get; set; }

        // @property (nonatomic, weak) id<AnylineVideoDataSampleBufferDelegate> sampleBufferDelegate;
        [NullAllowed, Export("sampleBufferDelegate", ArgumentSemantic.Weak)]
        NSObject WeakSampleBufferDelegate { get; set; }

        // -(instancetype)initWithFrame:(CGRect)frame configuration:(ALUIConfiguration *)configuration;
        [Export("initWithFrame:configuration:")]
        IntPtr Constructor(CGRect frame, ALUIConfiguration configuration);

        // -(instancetype)initWithFrame:(CGRect)frame;
        [Export("initWithFrame:")]
        IntPtr Constructor(CGRect frame);

        // -(instancetype)initWithCoder:(NSCoder *)aDecoder configuration:(ALUIConfiguration *)configuration;
        //[Export("initWithCoder:configuration:")]
        //IntPtr Constructor(NSCoder aDecoder, ALUIConfiguration configuration);
        
        //--> compiler generated
        // -(instancetype)initWithCoder:(NSCoder *)aDecoder;
        //[Export("initWithCoder:")]
        //IntPtr Constructor(NSCoder aDecoder);

        // -(BOOL)startVideoAndReturnError:(NSError **)error;
        [Export("startVideoAndReturnError:")]
        bool StartVideoAndReturnError(out NSError error);

        // -(void)stopVideo;
        [Export("stopVideo")]
        void StopVideo();

        // -(void)setFocusAndExposurePoint:(CGPoint)point;
        [Export("setFocusAndExposurePoint:")]
        void SetFocusAndExposurePoint(CGPoint point);

        // -(void)captureStillImageAndStopWithCompletionBlock:(ALImageProviderBlock)completionHandler;
        [Export("captureStillImageAndStopWithCompletionBlock:")]
        void CaptureStillImageAndStopWithCompletionBlock(ALImageProviderBlock completionHandler);

        // -(ALSquare *)resizeSquareToFullImageSquare:(ALSquare *)square withImageSize:(CGSize)imageSize resizeWidth:(CGFloat)resizeWidth;
        [Export("resizeSquareToFullImageSquare:withImageSize:resizeWidth:")]
        ALSquare ResizeSquareToFullImageSquare(ALSquare square, CGSize imageSize, nfloat resizeWidth);
    }

    // @protocol AnylineVideoDataSampleBufferDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineVideoDataSampleBufferDelegate
    {
        // @required -(void)anylineVideoView:(AnylineVideoView *)videoView didOutputSampleBuffer:(CMSampleBufferRef)sampleBuffer;
        [Abstract]
        [Export("anylineVideoView:didOutputSampleBuffer:")]
        void DidOutputSampleBuffer(AnylineVideoView videoView, ref NSObject sampleBuffer);
    }

    // @protocol AnylineNativeBarcodeDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineNativeBarcodeDelegate
    {
        // @required -(void)anylineVideoView:(AnylineVideoView *)videoView didFindBarcodeResult:(NSString *)scanResult type:(NSString *)barcodeType;
        [Abstract]
        [Export("anylineVideoView:didFindBarcodeResult:type:")]
        void DidFindBarcodeResult(AnylineVideoView videoView, string scanResult, string barcodeType);
    }

    // @interface ALCutoutView : UIView
    [BaseType(typeof(UIView))]
    interface ALCutoutView
    {
        // -(instancetype)initWithFrame:(CGRect)frame configuration:(ALUIConfiguration *)config;
        [Export("initWithFrame:configuration:")]
        IntPtr Constructor(CGRect frame, ALUIConfiguration config);

        // -(CGRect)cutoutRectScreen;
        [Export("cutoutRectScreen")]
        CGRect CutoutRectScreen { get; }

        // -(void)drawCutout:(BOOL)feedbackMode;
        [Export("drawCutout:")]
        void DrawCutout(bool feedbackMode);
    }

    // @interface ALUIConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    interface ALUIConfiguration
    {
        // @property (assign, nonatomic) CGFloat cutoutWidthPercent;
        [Export("cutoutWidthPercent")]
        nfloat CutoutWidthPercent { get; set; }

        // @property (assign, nonatomic) CGFloat cutoutMaxPercentWidth;
        [Export("cutoutMaxPercentWidth")]
        nfloat CutoutMaxPercentWidth { get; set; }

        // @property (assign, nonatomic) CGFloat cutoutMaxPercentHeight;
        [Export("cutoutMaxPercentHeight")]
        nfloat CutoutMaxPercentHeight { get; set; }

        // @property (assign, nonatomic) ALCutoutAlignment cutoutAlignment;
        [Export("cutoutAlignment", ArgumentSemantic.Assign)]
        ALCutoutAlignment CutoutAlignment { get; set; }

        // @property (assign, nonatomic) ALCaptureViewResolution captureResolution;
        [Export("captureResolution", ArgumentSemantic.Assign)]
        ALCaptureViewResolution CaptureResolution { get; set; }

        // @property (assign, nonatomic) ALPictureResolution pictureResolution;
        [Export("pictureResolution", ArgumentSemantic.Assign)]
        ALPictureResolution PictureResolution { get; set; }

        // @property (assign, nonatomic) ALCaptureViewMode captureMode;
        [Export("captureMode", ArgumentSemantic.Assign)]
        ALCaptureViewMode CaptureMode { get; set; }

        // @property (assign, nonatomic) CGPoint cutoutOffset;
        [Export("cutoutOffset", ArgumentSemantic.Assign)]
        CGPoint CutoutOffset { get; set; }

        // @property (copy, nonatomic) UIBezierPath * cutoutPath;
        [Export("cutoutPath", ArgumentSemantic.Copy)]
        UIBezierPath CutoutPath { get; set; }

        // @property (assign, nonatomic) CGSize cutoutCropPadding;
        [Export("cutoutCropPadding", ArgumentSemantic.Assign)]
        CGSize CutoutCropPadding { get; set; }

        // @property (assign, nonatomic) CGPoint cutoutCropOffset;
        [Export("cutoutCropOffset", ArgumentSemantic.Assign)]
        CGPoint CutoutCropOffset { get; set; }

        // @property (nonatomic, strong) UIColor * cutoutBackgroundColor;
        [Export("cutoutBackgroundColor", ArgumentSemantic.Strong)]
        UIColor CutoutBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIImage * overlayImage;
        [Export("overlayImage", ArgumentSemantic.Strong)]
        UIImage OverlayImage { get; set; }

        // @property (nonatomic, strong) UIColor * strokeColor;
        [Export("strokeColor", ArgumentSemantic.Strong)]
        UIColor StrokeColor { get; set; }

        // @property (assign, nonatomic) NSInteger strokeWidth;
        [Export("strokeWidth")]
        nint StrokeWidth { get; set; }

        // @property (assign, nonatomic) NSInteger cornerRadius;
        [Export("cornerRadius")]
        nint CornerRadius { get; set; }

        // @property (nonatomic, strong) UIColor * feedbackStrokeColor;
        [Export("feedbackStrokeColor", ArgumentSemantic.Strong)]
        UIColor FeedbackStrokeColor { get; set; }

        // @property (assign, nonatomic) ALUIFeedbackStyle feedbackStyle;
        [Export("feedbackStyle", ArgumentSemantic.Assign)]
        ALUIFeedbackStyle FeedbackStyle { get; set; }

        // @property (assign, nonatomic) ALUIVisualFeedbackAnimation visualFeedbackAnimation;
        [Export("visualFeedbackAnimation", ArgumentSemantic.Assign)]
        ALUIVisualFeedbackAnimation VisualFeedbackAnimation { get; set; }

        // @property (nonatomic, strong) UIColor * visualFeedbackStrokeColor;
        [Export("visualFeedbackStrokeColor", ArgumentSemantic.Strong)]
        UIColor VisualFeedbackStrokeColor { get; set; }

        // @property (nonatomic, strong) UIColor * visualFeedbackFillColor;
        [Export("visualFeedbackFillColor", ArgumentSemantic.Strong)]
        UIColor VisualFeedbackFillColor { get; set; }

        // @property (assign, nonatomic) NSInteger visualFeedbackStrokeWidth;
        [Export("visualFeedbackStrokeWidth")]
        nint VisualFeedbackStrokeWidth { get; set; }

        // @property (assign, nonatomic) NSInteger visualFeedbackCornerRadius;
        [Export("visualFeedbackCornerRadius")]
        nint VisualFeedbackCornerRadius { get; set; }

        // @property (assign, nonatomic) NSInteger visualFeedbackAnimationDuration;
        [Export("visualFeedbackAnimationDuration")]
        nint VisualFeedbackAnimationDuration { get; set; }

        // @property (assign, nonatomic) NSInteger visualFeedbackRedrawTimeout;
        [Export("visualFeedbackRedrawTimeout")]
        nint VisualFeedbackRedrawTimeout { get; set; }

        // @property (nonatomic, strong) UIColor * backgroundColorWithoutAlpha;
        [Export("backgroundColorWithoutAlpha", ArgumentSemantic.Strong)]
        UIColor BackgroundColorWithoutAlpha { get; set; }

        // @property (assign, nonatomic) CGFloat backgroundAlpha;
        [Export("backgroundAlpha")]
        nfloat BackgroundAlpha { get; set; }

        // @property (assign, nonatomic) ALFlashMode flashMode;
        [Export("flashMode", ArgumentSemantic.Assign)]
        ALFlashMode FlashMode { get; set; }

        // @property (assign, nonatomic) ALFlashAlignment flashAlignment;
        [Export("flashAlignment", ArgumentSemantic.Assign)]
        ALFlashAlignment FlashAlignment { get; set; }

        // @property (nonatomic, strong) UIImage * flashImage;
        [Export("flashImage", ArgumentSemantic.Strong)]
        UIImage FlashImage { get; set; }

        // @property (assign, nonatomic) CGPoint flashOffset;
        [Export("flashOffset", ArgumentSemantic.Assign)]
        CGPoint FlashOffset { get; set; }

        // @property (assign, nonatomic) BOOL beepOnResult;
        [Export("beepOnResult")]
        bool BeepOnResult { get; set; }

        // @property (assign, nonatomic) BOOL vibrateOnResult;
        [Export("vibrateOnResult")]
        bool VibrateOnResult { get; set; }

        // @property (assign, nonatomic) BOOL blinkAnimationOnResult;
        [Export("blinkAnimationOnResult")]
        bool BlinkAnimationOnResult { get; set; }

        // @property (assign, nonatomic) BOOL cancelOnResult;
        [Export("cancelOnResult")]
        bool CancelOnResult { get; set; }

        // @property (assign, nonatomic) ALReportingMode reportingEnabled;
        [Export("reportingEnabled", ArgumentSemantic.Assign)]
        ALReportingMode ReportingEnabled { get; set; }

        // +(instancetype)cutoutConfigurationFromJsonFile:(NSString *)jsonFile;
        [Static]
        [Export("cutoutConfigurationFromJsonFile:")]
        ALUIConfiguration CutoutConfigurationFromJsonFile(string jsonFile);

        // -(instancetype)initWithDictionary:(NSDictionary *)dictionary bundlePath:(NSString *)bundlePath;
        [Export("initWithDictionary:bundlePath:")]
        IntPtr Constructor(NSDictionary dictionary, string bundlePath);

        // -(void)setCutoutPathForWidth:(CGFloat)width height:(CGFloat)height;
        [Export("setCutoutPathForWidth:height:")]
        void SetCutoutPathForWidth(nfloat width, nfloat height);

        // -(void)updateCutoutWidth:(CGFloat)width;
        [Export("updateCutoutWidth:")]
        void UpdateCutoutWidth(nfloat width);
    }

// @interface Paths (ALUIConfiguration)
    [Category]
    [BaseType(typeof(ALUIConfiguration))]
    interface ALUIConfiguration_Paths
    {
        // +(UIBezierPath *)AL_lugPath;
        [Static]
        [Export("AL_lugPath")]
        UIBezierPath AL_lugPath { get; }
    }

// @interface ALIndexPath : NSObject
    [BaseType(typeof(NSObject))]
    interface ALIndexPath
    {
        // @property (nonatomic) NSInteger line;
        [Export("line")]
        nint Line { get; set; }

        // @property (nonatomic) NSInteger positionInLine;
        [Export("positionInLine")]
        nint PositionInLine { get; set; }

        // -(instancetype)initWithPosition:(NSInteger)position inLine:(NSInteger)line;
        [Export("initWithPosition:inLine:")]
        IntPtr Constructor(nint position, nint line);

        // -(NSComparisonResult)compare:(id)object;
        [Export("compare:")]
        NSComparisonResult Compare(NSObject @object);
    }

    // @interface ALContours : NSObject
    [BaseType(typeof(NSObject))]
    interface ALContours
    {
    }

    // @interface ALSquare : NSObject
    [BaseType(typeof(NSObject))]
    interface ALSquare
    {
        // @property (assign, nonatomic) CGPoint upLeft;
        [Export("upLeft", ArgumentSemantic.Assign)]
        CGPoint UpLeft { get; set; }

        // @property (assign, nonatomic) CGPoint upRight;
        [Export("upRight", ArgumentSemantic.Assign)]
        CGPoint UpRight { get; set; }

        // @property (assign, nonatomic) CGPoint downLeft;
        [Export("downLeft", ArgumentSemantic.Assign)]
        CGPoint DownLeft { get; set; }

        // @property (assign, nonatomic) CGPoint downRight;
        [Export("downRight", ArgumentSemantic.Assign)]
        CGPoint DownRight { get; set; }

        // -(instancetype)initWithUpLeft:(CGPoint)upLeft upRight:(CGPoint)upRight downLeft:(CGPoint)downLeft downRight:(CGPoint)downRight;
        [Export("initWithUpLeft:upRight:downLeft:downRight:")]
        IntPtr Constructor(CGPoint upLeft, CGPoint upRight, CGPoint downLeft, CGPoint downRight);

        // -(instancetype)initWithCGRect:(CGRect)rect;
        [Export("initWithCGRect:")]
        IntPtr Constructor(CGRect rect);

        // -(CGFloat)boundingX;
        [Export("boundingX")]
        nfloat BoundingX { get; }

        // -(CGFloat)boundingY;
        [Export("boundingY")]
        nfloat BoundingY { get; }

        // -(CGFloat)boundingWidth;
        [Export("boundingWidth")]
        nfloat BoundingWidth { get; }

        // -(CGFloat)boundingHeight;
        [Export("boundingHeight")]
        nfloat BoundingHeight { get; }

        // -(ALSquare *)squareWithPointOffset:(CGPoint)offset;
        [Export("squareWithPointOffset:")]
        ALSquare SquareWithPointOffset(CGPoint offset);

        // -(ALSquare *)squareWithScale:(CGFloat)scale;
        [Export("squareWithScale:")]
        ALSquare SquareWithScale(nfloat scale);

        // -(CGFloat)area;
        [Export("area")]
        nfloat Area { get; }

        // -(CGFloat)area2;
        [Export("area2")]
        nfloat Area2 { get; }

        // -(float)ratio;
        [Export("ratio")]
        float Ratio { get; }

        // -(CGRect)boxRect;
        [Export("boxRect")]
        CGRect BoxRect { get; }
    }

    // @interface ALROISpec : NSObject
    /*[BaseType(typeof(NSObject))]
        interface ALROISpec
        {
            // @property (assign, nonatomic) CGSize size;
            [Export("size", ArgumentSemantic.Assign)]
            CGSize Size { get; set; }
        
            // @property (nonatomic, strong) NSArray * dataPoints;
            [Export("dataPoints", ArgumentSemantic.Strong)]
            NSObject[] DataPoints { get; set; }
        
            // -(instancetype)initWithDataPoints:(NSArray *)dataPoints size:(CGSize)size;
            [Export("initWithDataPoints:size:")]
            IntPtr Constructor(NSObject[] dataPoints, CGSize size);
        
            // -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
            [Export("initWithDictionary:")]
            IntPtr Constructor(NSDictionary dictionary);
        
            // -(instancetype)initWithJSonFileName:(NSString *)filename;
            [Export("initWithJSonFileName:")]
            IntPtr Constructor(string filename);
        
            // -(instancetype)initWithJSonString:(NSString *)jsonString;
            [Export("initWithJSonString:")]
            IntPtr Constructor(string jsonString);
        
            // -(instancetype)initWithJSonData:(NSData *)jsonData;
            [Export("initWithJSonData:")]
            IntPtr Constructor(NSData jsonData);
        
            // -(NSArray *)dataPointsForLine:(NSInteger)line;
            [Export("dataPointsForLine:")]
            NSObject[] DataPointsForLine(nint line);
        
            // -(NSArray *)lineNumbers;
            [Export("lineNumbers")]
            NSObject[] LineNumbers { get; }
        }*/

    // @interface ALSegmentSpec : NSObject
    [BaseType(typeof(NSObject))]
    interface ALSegmentSpec
    {
        // @property (assign, nonatomic) CGRect bounds;
        [Export("bounds", ArgumentSemantic.Assign)]
        CGRect Bounds { get; set; }

        // -(instancetype)initWithBounds:(CGRect)bounds;
        [Export("initWithBounds:")]
        IntPtr Constructor(CGRect bounds);

        // -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
        [Export("initWithDictionary:")]
        IntPtr Constructor(NSDictionary dictionary);
    }

    // @interface ALDataPoint : NSObject
    [BaseType(typeof(NSObject))]
    interface ALDataPoint
    {
        // @property (assign, nonatomic) CGRect area;
        [Export("area", ArgumentSemantic.Assign)]
        CGRect Area { get; set; }

        // @property (readonly, nonatomic, strong) ALIndexPath * indexPath;
        [Export("indexPath", ArgumentSemantic.Strong)]
        ALIndexPath IndexPath { get; }

        // @property (readonly, nonatomic, strong) NSString * identifier;
        [Export("identifier", ArgumentSemantic.Strong)]
        string Identifier { get; }

        // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier;
        [Export("initWithArea:indexPath:identifier:")]
        IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier);

        // -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
        [Export("initWithDictionary:")]
        IntPtr Constructor(NSDictionary dictionary);

        // +(ALDataPoint *)dataPointForDictionary:(NSDictionary *)dictionary;
        [Static]
        [Export("dataPointForDictionary:")]
        ALDataPoint DataPointForDictionary(NSDictionary dictionary);
    }

    // @interface ALDigitDataPoint : ALDataPoint
    [BaseType(typeof(ALDataPoint))]
    interface ALDigitDataPoint
    {
        // @property (readonly, nonatomic, strong) NSArray * segments;
        [Export("segments", ArgumentSemantic.Strong)]
        NSObject[] Segments { get; }

        // @property (readonly, nonatomic, strong) NSArray * qualitySegments;
        [Export("qualitySegments", ArgumentSemantic.Strong)]
        NSObject[] QualitySegments { get; }

        // @property (readonly, nonatomic, strong) NSDictionary * segmentResultPattern;
        [Export("segmentResultPattern", ArgumentSemantic.Strong)]
        NSDictionary SegmentResultPattern { get; }

        // @property (readonly, nonatomic) NSInteger italicOffset;
        [Export("italicOffset")]
        nint ItalicOffset { get; }

        // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier italicOffset:(NSInteger)italicOffset segments:(NSArray *)segments qualitySegments:(NSArray *)qualitySegments segmentResultPattern:(NSDictionary *)segmentResultPattern;
        [Export("initWithArea:indexPath:identifier:italicOffset:segments:qualitySegments:segmentResultPattern:")]
        IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier, nint italicOffset, NSObject[] segments,
            NSObject[] qualitySegments, NSDictionary segmentResultPattern);

        // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier italicOffset:(NSInteger)italicOffset segmentResultPattern:(NSDictionary *)segmentResultPattern;
        [Export("initWithArea:indexPath:identifier:italicOffset:segmentResultPattern:")]
        IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier, nint italicOffset,
            NSDictionary segmentResultPattern);

        // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier italicOffset:(NSInteger)italicOffset;
        [Export("initWithArea:indexPath:identifier:italicOffset:")]
        IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier, nint italicOffset);

        // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier;
        [Export("initWithArea:indexPath:identifier:")]
        IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier);

        // -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
        [Export("initWithDictionary:")]
        IntPtr Constructor(NSDictionary dictionary);
    }

    // @interface ALTextDataPoint : ALDataPoint
    [BaseType(typeof(ALDataPoint))]
    interface ALTextDataPoint
    {
        // @property (readonly, nonatomic, strong) NSDictionary * tesseractParameter;
        [Export("tesseractParameter", ArgumentSemantic.Strong)]
        NSDictionary TesseractParameter { get; }

        // @property (readonly, nonatomic, strong) NSArray * languages;
        [Export("languages", ArgumentSemantic.Strong)]
        NSObject[] Languages { get; }

        // @property (nonatomic) ALCharacterRange characterCount;
        [Export("characterCount", ArgumentSemantic.Assign)]
        ALCharacterRange CharacterCount { get; set; }

        // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier languages:(NSArray *)languages tesseractParameter:(NSDictionary *)tesseractParameter;
        [Export("initWithArea:indexPath:identifier:languages:tesseractParameter:")]
        IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier, NSObject[] languages,
            NSDictionary tesseractParameter);

        // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier languages:(NSArray *)languages tesseractParameter:(NSDictionary *)tesseractParameter characterRange:(ALCharacterRange)characterRange;
        [Export("initWithArea:indexPath:identifier:languages:tesseractParameter:characterRange:")]
        IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier, NSObject[] languages,
            NSDictionary tesseractParameter, ALCharacterRange characterRange);
    }

    // @interface ALResult : NSObject
    [BaseType(typeof(NSObject))]
    interface ALResult
    {
        // @property (nonatomic, strong) ALROISpec * specs;
        [Export("specs", ArgumentSemantic.Strong)]
        NSObject Specs { get; set; }

        // @property (nonatomic) BOOL valid;
        [Export("valid")]
        bool Valid { get; set; }

        // -(NSArray *)identifiers;
        [Export("identifiers")]
        NSObject[] Identifiers { get; }

        // -(id)resultForIdentifier:(NSString *)identifier;
        [Export("resultForIdentifier:")]
        NSObject ResultForIdentifier(string identifier);
    }

    // @interface ALSegmentResult : NSObject
    [BaseType(typeof(NSObject))]
    interface ALSegmentResult
    {
        // @property (readonly, nonatomic) float ratioBlackPixel;
        [Export("ratioBlackPixel")]
        float RatioBlackPixel { get; }

        // @property (assign, nonatomic) CGRect frame;
        [Export("frame", ArgumentSemantic.Assign)]
        CGRect Frame { get; set; }

        // @property (assign, nonatomic) BOOL active;
        [Export("active")]
        bool Active { get; set; }

        // -(instancetype)initWithRatioBlackPixel:(float)ratioBlackPixel frame:(CGRect)frame;
        [Export("initWithRatioBlackPixel:frame:")]
        IntPtr Constructor(float ratioBlackPixel, CGRect frame);
    }

// @interface ALDigitResult : NSObject
    [BaseType(typeof(NSObject))]
    interface ALDigitResult
    {
        // @property (readonly, nonatomic, strong) id value;
        [Export("value", ArgumentSemantic.Strong)]
        NSObject Value { get; }

        // @property (readonly, nonatomic, strong) NSArray * segments;
        [Export("segments", ArgumentSemantic.Strong)]
        NSObject[] Segments { get; }

        // @property (readonly, nonatomic, strong) NSArray * qualitySegments;
        [Export("qualitySegments", ArgumentSemantic.Strong)]
        NSObject[] QualitySegments { get; }

        // @property (readonly, nonatomic, strong) ALIndexPath * indexPath;
        [Export("indexPath", ArgumentSemantic.Strong)]
        ALIndexPath IndexPath { get; }

        // @property (readonly, nonatomic, strong) NSString * identifier;
        [Export("identifier", ArgumentSemantic.Strong)]
        string Identifier { get; }

        // @property (readonly, nonatomic, strong) NSDictionary * patternResultDictionary;
        [Export("patternResultDictionary", ArgumentSemantic.Strong)]
        NSDictionary PatternResultDictionary { get; }

        // -(float)quality;
        [Export("quality")]
        float Quality { get; }
    }

// @interface ALDisplayResult : ALResult <NSCopying>
    [BaseType(typeof(ALResult))]
    interface ALDisplayResult : INSCopying
    {
        // -(int)numberOfDigits;
        [Export("numberOfDigits")]
        int NumberOfDigits { get; }

        // -(NSArray *)digitsForIdentifier:(NSString *)identifier;
        [Export("digitsForIdentifier:")]
        NSObject[] DigitsForIdentifier(string identifier);

        // -(NSString *)stringRepresentationOfDigitsForIdentifier:(NSString *)identifier;
        [Export("stringRepresentationOfDigitsForIdentifier:")]
        string StringRepresentationOfDigitsForIdentifier(string identifier);

        // -(float)quality;
        [Export("quality")]
        float Quality { get; }

        // -(NSArray *)digitIdentifiers;
        [Export("digitIdentifiers")]
        NSObject[] DigitIdentifiers { get; }
    }

// @interface ALValuesStack : NSObject
    [BaseType(typeof(NSObject))]
    interface ALValuesStack
    {
        // @property (nonatomic) NSInteger size;
        [Export("size")]
        nint Size { get; set; }

        // @property (nonatomic) NSInteger minEqualResults;
        [Export("minEqualResults")]
        nint MinEqualResults { get; set; }

        // @property (nonatomic, strong) id lastCommitedResult;
        [Export("lastCommitedResult", ArgumentSemantic.Strong)]
        NSObject LastCommitedResult { get; set; }

        // @property (nonatomic) BOOL hasNewResult;
        [Export("hasNewResult")]
        bool HasNewResult { get; set; }

        // @property (nonatomic) BOOL consecutivelyValue;
        [Export("consecutivelyValue")]
        bool ConsecutivelyValue { get; set; }

        // @property (nonatomic) NSInteger currentEqualCount;
        [Export("currentEqualCount")]
        nint CurrentEqualCount { get; set; }

        // @property (nonatomic) NSInteger currentEqualCountWithoutEmpty;
        [Export("currentEqualCountWithoutEmpty")]
        nint CurrentEqualCountWithoutEmpty { get; set; }

        // -(instancetype)initWithSize:(NSInteger)size minimalEqualResults:(NSInteger)minEqualResults allowSameValueConsecutively:(BOOL)consecutivelyValue;
        [Export("initWithSize:minimalEqualResults:allowSameValueConsecutively:")]
        IntPtr Constructor(nint size, nint minEqualResults, bool consecutivelyValue);

        // -(void)addResult:(id)result;
        [Export("addResult:")]
        void AddResult(NSObject result);

        // -(id)newResult;
        [Export("newResult")]
        NSObject NewResult { get; }
    }

// @interface ALValuesStackFlipping : ALValuesStack
    [BaseType(typeof(ALValuesStack))]
    interface ALValuesStackFlipping
    {
        // -(instancetype)initWithSize:(NSInteger)size minimalEqualResults:(NSInteger)minEqualResults allowSameValueConsecutively:(BOOL)consecutivelyValue acceptPartialResultSize:(NSInteger)partialResultSize;
        [Export("initWithSize:minimalEqualResults:allowSameValueConsecutively:acceptPartialResultSize:")]
        IntPtr Constructor(nint size, nint minEqualResults, bool consecutivelyValue, nint partialResultSize);

        // -(instancetype)initWithSize:(NSInteger)size minimalEqualResults:(NSInteger)minEqualResults allowSameValueConsecutively:(BOOL)consecutivelyValue;
        [Export("initWithSize:minimalEqualResults:allowSameValueConsecutively:")]
        IntPtr Constructor(nint size, nint minEqualResults, bool consecutivelyValue);
    }

// @interface AnylineController : NSObject
    [BaseType(typeof(NSObject))]
    interface AnylineController
    {
        // @property (assign, nonatomic) BOOL asyncSDK;
        [Export("asyncSDK")]
        bool AsyncSDK { get; set; }

        // @property (getter = isRunning, assign, nonatomic) BOOL running;
        [Export("running")]
        bool Running { [Bind("isRunning")] get; set; }

        [Wrap("WeakDelegate")]
        AnylineControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<AnylineControllerDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(instancetype)initWithLicenseKey:(NSString *)licenseKey;
        [Export("initWithLicenseKey:")]
        IntPtr Constructor(string licenseKey);

        // -(instancetype)initWithLicenseKey:(NSString *)licenseKey delegate:(id<AnylineControllerDelegate>)delegate;
        [Export("initWithLicenseKey:delegate:")]
        IntPtr Constructor(string licenseKey, AnylineControllerDelegate @delegate);

        // -(BOOL)loadScript:(NSString *)script bundlePath:(NSString *)bundlePath error:(NSError **)error;
        [Export("loadScript:bundlePath:error:")]
        bool LoadScript(string script, string bundlePath, out NSError error);

        // -(BOOL)loadCmdFile:(NSString *)cmdFileName bundlePath:(NSString *)bundlePath error:(NSError **)error;
        [Export("loadCmdFile:bundlePath:error:")]
        bool LoadCmdFile(string cmdFileName, string bundlePath, out NSError error);

        // -(BOOL)startWithImageProvider:(id<ALImageProvider>)imageProvider error:(NSError **)error;
        [Export("startWithImageProvider:error:")]
        bool StartWithImageProvider(ALImageProvider imageProvider, out NSError error);

        // -(BOOL)startWithImageProvider:(id<ALImageProvider>)imageProvider startVariables:(NSDictionary *)variables error:(NSError **)error;
        [Export("startWithImageProvider:startVariables:error:")]
        bool StartWithImageProvider(ALImageProvider imageProvider, NSDictionary variables, out NSError error);

        // -(BOOL)stopAndReturnError:(NSError **)error;
        [Export("stopAndReturnError:")]
        bool StopAndReturnError(out NSError error);

        // -(BOOL)processImage:(UIImage *)image error:(NSError **)error;
        [Export("processImage:error:")]
        bool ProcessImage(UIImage image, out NSError error);

        // -(BOOL)processImage:(UIImage *)image startVariables:(NSDictionary *)variables error:(NSError **)error;
        [Export("processImage:startVariables:error:")]
        bool ProcessImage(UIImage image, NSDictionary variables, out NSError error);

        // -(BOOL)processALImage:(ALImage *)alImage error:(NSError **)error;
        [Export("processALImage:error:")]
        bool ProcessALImage(ALImage alImage, out NSError error);

        // -(BOOL)processALImage:(ALImage *)alImage startVariables:(NSDictionary *)variables error:(NSError **)error;
        [Export("processALImage:startVariables:error:")]
        bool ProcessALImage(ALImage alImage, NSDictionary variables, out NSError error);

        // -(void)setParameter:(id)parameter forKey:(NSString *)key;
        [Export("setParameter:forKey:")]
        void SetParameter(NSObject parameter, string key);

        // +(NSString *)versionNumber;
        [Static]
        [Export("versionNumber")]
        string VersionNumber { get; }

        // +(NSString *)buildNumber;
        [Static]
        [Export("buildNumber")]
        string BuildNumber { get; }

        // +(NSBundle *)frameworkBundle;
        [Static]
        [Export("frameworkBundle")]
        NSBundle FrameworkBundle { get; }

        // -(void)enableReporting:(BOOL)enable;
        [Export("enableReporting:")]
        void EnableReporting(bool enable);

        // -(void)notifyScanningHasBeenCanceled;
        [Export("notifyScanningHasBeenCanceled")]
        void NotifyScanningHasBeenCanceled();

        // -(NSArray *)runStatistics;
        [Export("runStatistics")]
        NSObject[] RunStatistics { get; }
    }

// @protocol AnylineControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineControllerDelegate
    {
        // @required -(void)anylineController:(AnylineController *)anylineController didFinishWithOutput:(id)object;
        [Abstract]
        [Export("anylineController:didFinishWithOutput:")]
        void DidFinishWithOutput(AnylineController anylineController, NSObject @object);

        // @optional -(void)anylineController:(AnylineController *)anylineController didAbortRun:(NSError *)reason;
        [Export("anylineController:didAbortRun:")]
        void DidAbortRun(AnylineController anylineController, NSError reason);

        // @optional -(void)anylineController:(AnylineController *)anylineController reportsVariable:(NSString *)variableName value:(id)value;
        [Export("anylineController:reportsVariable:value:")]
        void ReportsVariable(AnylineController anylineController, string variableName, NSObject value);

        // @optional -(void)anylineController:(AnylineController *)anylineController parserError:(NSError *)error;
        [Export("anylineController:parserError:")]
        void ParserError(AnylineController anylineController, NSError error);
    }

    /*
    // @protocol ALMotionDetectorDelegate <NSObject>    
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALMotionDetectorDelegate
    {
        // @required -(void)motionDetectorAboveThreshold;
        [Abstract]
        [Export("motionDetectorAboveThreshold")]
        void MotionDetectorAboveThreshold();
    }*/

    /*
    // @interface ALMotionDetector : NSObject
    [BaseType(typeof(NSObject))]
    interface ALMotionDetector
    {
        [Wrap("WeakDelegate")]
        ALMotionDetectorDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<ALMotionDetectorDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // -(void)startListeningForMotion;
        [Export("startListeningForMotion")]
        void StartListeningForMotion();

        // -(void)stopListeningForMotion;
        [Export("stopListeningForMotion")]
        void StopListeningForMotion();

        // -(instancetype)initWithThreshold:(CGFloat)threshold delegate:(id)delegate;
        [Export("initWithThreshold:delegate:")]
        IntPtr Constructor(nfloat threshold, NSObject @delegate);
    }*/
    
    // @interface AnylineAbstractModuleView : UIView
    [BaseType(typeof(UIView))]
    interface AnylineAbstractModuleView
    {
        //ADDED
        // -(instancetype)initWithFrame:(CGRect)frame;
        [Export("initWithFrame:")]
        IntPtr Constructor(CGRect frame);

        // @property (nonatomic, strong) AnylineVideoView * videoView;
        [Export("videoView", ArgumentSemantic.Strong)]
        AnylineVideoView VideoView { get; set; }

        // @property (nonatomic, strong) ALUIConfiguration * currentConfiguration;
        [Export("currentConfiguration", ArgumentSemantic.Strong)]
        ALUIConfiguration CurrentConfiguration { get; set; }

        // @property (nonatomic) NSInteger strokeWidth;
        [Export("strokeWidth")]
        nint StrokeWidth { get; set; }

        // @property (nonatomic, strong) UIColor * strokeColor;
        [Export("strokeColor", ArgumentSemantic.Strong)]
        UIColor StrokeColor { get; set; }

        // @property (nonatomic) NSInteger cornerRadius;
        [Export("cornerRadius")]
        nint CornerRadius { get; set; }

        // @property (nonatomic, strong) UIColor * outerColor;
        [Export("outerColor", ArgumentSemantic.Strong)]
        UIColor OuterColor { get; set; }

        // @property (nonatomic) CGFloat outerAlpha;
        [Export("outerAlpha")]
        nfloat OuterAlpha { get; set; }

        // @property (nonatomic, strong) UIImage * flashImage;
        [Export("flashImage", ArgumentSemantic.Strong)]
        UIImage FlashImage { get; set; }

        // @property (nonatomic) ALFlashAlignment flashButtonAlignment;
        [Export("flashButtonAlignment", ArgumentSemantic.Assign)]
        ALFlashAlignment FlashButtonAlignment { get; set; }

        // @property (nonatomic) CGPoint flashButtonOffset;
        [Export("flashButtonOffset", ArgumentSemantic.Assign)]
        CGPoint FlashButtonOffset { get; set; }

        // @property (nonatomic) ALFlashStatus flashStatus;
        [Export("flashStatus", ArgumentSemantic.Assign)]
        ALFlashStatus FlashStatus { get; set; }

        // @property (nonatomic) BOOL cancelOnResult;
        [Export("cancelOnResult")]
        bool CancelOnResult { get; set; }

        // @property (nonatomic) BOOL beepOnResult;
        [Export("beepOnResult")]
        bool BeepOnResult { get; set; }

        // @property (nonatomic) BOOL blinkOnResult;
        [Export("blinkOnResult")]
        bool BlinkOnResult { get; set; }

        // @property (nonatomic) BOOL vibrateOnResult;
        [Export("vibrateOnResult")]
        bool VibrateOnResult { get; set; }

        // @property (readonly, nonatomic) CGRect cutoutRect;
        [Export("cutoutRect")]
        CGRect CutoutRect { get; }

        // @property (readonly, nonatomic) CGRect watermarkRect;
        [Export("watermarkRect")]
        CGRect WatermarkRect { get; }

        // -(BOOL)startScanningAndReturnError:(NSError **)error;
        [Export("startScanningAndReturnError:")]
        bool StartScanningAndReturnError(out NSError error);

        // -(BOOL)cancelScanningAndReturnError:(NSError **)error;
        [Export("cancelScanningAndReturnError:")]
        bool CancelScanningAndReturnError(out NSError error);

        // -(void)enableReporting:(BOOL)enable;
        [Export("enableReporting:")]
        void EnableReporting(bool enable);

        // -(BOOL)isRunning;
        [Export("isRunning")]
        bool IsRunning { get; }

        // -(void)startListeningForMotionWithThreshold:(CGFloat)threshold delegate:(id)delegate;
        [Export("startListeningForMotionWithThreshold:delegate:")]
        void StartListeningForMotionWithThreshold(nfloat threshold, NSObject @delegate);

        // -(void)stopListeningForMotion;
        [Export("stopListeningForMotion")]
        void StopListeningForMotion();
    }

    // @interface AnylineEnergyModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineEnergyModuleView
    {
        //ADDED
        // -(instancetype)initWithFrame:(CGRect)frame;
        [Export("initWithFrame:")]
        IntPtr Constructor(CGRect frame);

        // @property (readonly, assign, nonatomic) ALScanMode scanMode;
        [Export("scanMode", ArgumentSemantic.Assign)]
        ALScanMode ScanMode { get; }

        // -(void)setScanMode:(ALScanMode)scanMode __attribute__((deprecated("Deprecated since 3.4. Use method setScanMode:error: instead.")));
        [Obsolete("Deprecated since 3.4 Use SetScanMode(scanMode, error) instead.")]
        [Export("setScanMode:")]
        void SetScanMode(ALScanMode scanMode);

        // -(BOOL)setScanMode:(ALScanMode)scanMode error:(NSError **)error;
        [Export("setScanMode:error:")]
        bool SetScanMode(ALScanMode scanMode, out NSError error);

        // -(BOOL)setupWithLicenseKey:(NSString *)licenseKey delegate:(id<AnylineEnergyModuleDelegate>)delegate error:(NSError **)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, out NSError error);
    }

    // @protocol AnylineEnergyModuleDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineEnergyModuleDelegate
    {
        // @required -(void)anylineEnergyModuleView:(AnylineEnergyModuleView *)anylineEnergyModuleView didFindResult:(ALEnergyResult *)scanResult;
        [Abstract]
        [Export("anylineEnergyModuleView:didFindResult:")]
        void DidFindResult(AnylineEnergyModuleView anylineEnergyModuleView, ALEnergyResult scanResult);

        // @optional -(void)anylineEnergyModuleView:(AnylineEnergyModuleView *)anylineEnergyModuleView didFindScanResult:(NSString *)scanResult cropImage:(UIImage *)image fullImage:(UIImage *)fullImage inMode:(ALScanMode)scanMode __attribute__((deprecated("Deprecated since 3.10 Use AnylineDebugDelegate instead.")));
        //[Export("anylineEnergyModuleView:didFindScanResult:cropImage:fullImage:inMode:")]
        //void DidFindScanResult(AnylineEnergyModuleView anylineEnergyModuleView, string scanResult, UIImage image, UIImage fullImage, ALScanMode scanMode);
    }

    [Static]
    partial interface Constants
    {
        // extern NSString *const kCodeTypeAztec __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypeAztec", "__Internal")]
        NSString kCodeTypeAztec { get; }

        // extern NSString *const kCodeTypeCodabar __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypeCodabar", "__Internal")]
        NSString kCodeTypeCodabar { get; }

        // extern NSString *const kCodeTypeCode39 __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypeCode39", "__Internal")]
        NSString kCodeTypeCode39 { get; }

        // extern NSString *const kCodeTypeCode93 __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypeCode93", "__Internal")]
        NSString kCodeTypeCode93 { get; }

        // extern NSString *const kCodeTypeCode128 __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypeCode128", "__Internal")]
        NSString kCodeTypeCode128 { get; }

        // extern NSString *const kCodeTypeDataMatrix __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypeDataMatrix", "__Internal")]
        NSString kCodeTypeDataMatrix { get; }

        // extern NSString *const kCodeTypeEAN8 __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypeEAN8", "__Internal")]
        NSString kCodeTypeEAN8 { get; }

        // extern NSString *const kCodeTypeEAN13 __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypeEAN13", "__Internal")]
        NSString kCodeTypeEAN13 { get; }

        // extern NSString *const kCodeTypeITF __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypeITF", "__Internal")]
        NSString kCodeTypeITF { get; }

        // extern NSString *const kCodeTypePDF417 __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypePDF417", "__Internal")]
        NSString kCodeTypePDF417 { get; }

        // extern NSString *const kCodeTypeQR __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypeQR", "__Internal")]
        NSString kCodeTypeQR { get; }

        // extern NSString *const kCodeTypeRSS14 __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypeRSS14", "__Internal")]
        NSString kCodeTypeRSS14 { get; }

        // extern NSString *const kCodeTypeRSSExpanded __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypeRSSExpanded", "__Internal")]
        NSString kCodeTypeRSSExpanded { get; }

        // extern NSString *const kCodeTypeUPCA __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypeUPCA", "__Internal")]
        NSString kCodeTypeUPCA { get; }

        // extern NSString *const kCodeTypeUPCE __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypeUPCE", "__Internal")]
        NSString kCodeTypeUPCE { get; }

        // extern NSString *const kCodeTypeUPCEANExtension __attribute__((deprecated("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")));
        [Obsolete("Deprecated since 3.4 Use enum ALBarcodeFormatOptions instead.")]
        [Field("kCodeTypeUPCEANExtension", "__Internal")]
        NSString kCodeTypeUPCEANExtension { get; }

        // MANUALLY MOVED HERE:

        // extern const CGFloat ALDocumentRatioDINAXLandscape;
        [Field("ALDocumentRatioDINAXLandscape", "__Internal")]
        float ALDocumentRatioDINAXLandscape { get; }

        // extern const CGFloat ALDocumentRatioDINAXPortrait;
        [Field("ALDocumentRatioDINAXPortrait", "__Internal")]
        float ALDocumentRatioDINAXPortrait { get; }

        // extern const CGFloat ALDocumentRatioCompimentsSlipLandscape;
        [Field("ALDocumentRatioCompimentsSlipLandscape", "__Internal")]
        float ALDocumentRatioCompimentsSlipLandscape { get; }

        // extern const CGFloat ALDocumentRatioCompimentsSlipPortrait;
        [Field("ALDocumentRatioCompimentsSlipPortrait", "__Internal")]
        float ALDocumentRatioCompimentsSlipPortrait { get; }

        // extern const CGFloat ALDocumentRatioBusinessCardLandscape;
        [Field("ALDocumentRatioBusinessCardLandscape", "__Internal")]
        float ALDocumentRatioBusinessCardLandscape { get; }

        // extern const CGFloat ALDocumentRatioBusinessCardPortrait;
        [Field("ALDocumentRatioBusinessCardPortrait", "__Internal")]
        float ALDocumentRatioBusinessCardPortrait { get; }

        // extern const CGFloat ALDocumentRatioLetterLandscape;
        [Field("ALDocumentRatioLetterLandscape", "__Internal")]
        float ALDocumentRatioLetterLandscape { get; }

        // extern const CGFloat ALDocumentRatioLetterPortrait;
        [Field("ALDocumentRatioLetterPortrait", "__Internal")]
        float ALDocumentRatioLetterPortrait { get; }
    }

    // @interface AnylineBarcodeModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineBarcodeModuleView
    {
        //ADDED
        // -(instancetype)initWithFrame:(CGRect)frame;
        [Export("initWithFrame:")]
        IntPtr Constructor(CGRect frame);

        // @property (nonatomic, strong) NSArray * barcodeFormats __attribute__((deprecated("Deprecated since 3.4 Use setBarcodeFormats:error: instead.")));
        [Export("barcodeFormats", ArgumentSemantic.Strong)]        
        [Obsolete("Deprecated since 3.4 Use BarcodeFormatOptions instead.")]
        NSObject[] BarcodeFormats { get; set; }

        // @property (assign, nonatomic) ALBarcodeFormatOptions barcodeFormatOptions;
        [Export("barcodeFormatOptions", ArgumentSemantic.Assign)]
        ALBarcodeFormat BarcodeFormatOptions { get; set; } //MANUALLY CHANGED FROM ALBarcodeFormatOptions

        // @property (assign, nonatomic) BOOL useOnlyNativeBarcodeScanning;
        [Export("useOnlyNativeBarcodeScanning")]
        bool UseOnlyNativeBarcodeScanning { get; set; }

        // -(BOOL)setupWithLicenseKey:(NSString *)licenseKey delegate:(id<AnylineBarcodeModuleDelegate>)delegate error:(NSError **)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, out NSError error);
    }

    // @protocol AnylineBarcodeModuleDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineBarcodeModuleDelegate
    {
        // @optional -(void)anylineBarcodeModuleView:(AnylineBarcodeModuleView *)anylineBarcodeModuleView didFindScanResult:(NSString *)scanResult barcodeFormat:(NSString *)barcodeFormat atImage:(UIImage *)image __attribute__((deprecated("Deprecated since 3.4 Use method anylineBarcodeModuleView:didFindScanResult:withBarcodeFormat:atImage: instead.")));
        //[Export("anylineBarcodeModuleView:didFindScanResult:barcodeFormat:atImage:")]
        //void DidFindScanResult(AnylineBarcodeModuleView anylineBarcodeModuleView, string scanResult, string barcodeFormat, UIImage image);

        // @optional -(void)anylineBarcodeModuleView:(AnylineBarcodeModuleView *)anylineBarcodeModuleView didFindScanResult:(NSString *)scanResult withBarcodeFormat:(ALBarcodeFormat)barcodeFormat atImage:(UIImage *)image __attribute__((deprecated("Deprecated since 3.10 Use method anylineBarcodeModuleView:didFindScanResult:withBarcodeFormat:atImage: instead.")));
        //[Export("anylineBarcodeModuleView:didFindScanResult:withBarcodeFormat:atImage:")]
        //void DidFindScanResult(AnylineBarcodeModuleView anylineBarcodeModuleView, string scanResult, ALBarcodeFormat barcodeFormat, UIImage image);

        // @required -(void)anylineBarcodeModuleView:(AnylineBarcodeModuleView *)anylineBarcodeModuleView didFindResult:(ALBarcodeResult *)scanResult;
        [Abstract]
        [Export("anylineBarcodeModuleView:didFindResult:")]
        void DidFindResult(AnylineBarcodeModuleView anylineBarcodeModuleView, ALBarcodeResult scanResult);
    }

    // @interface ALIdentification : NSObject
    [BaseType(typeof(NSObject))]
    interface ALIdentification
    {
        // @property (nonatomic, strong) NSString * documentType;
        [Export("documentType", ArgumentSemantic.Strong)]
        string DocumentType { get; set; }

        // @property (nonatomic, strong) NSString * documentNumber;
        [Export("documentNumber", ArgumentSemantic.Strong)]
        string DocumentNumber { get; set; }

        // @property (nonatomic, strong) NSString * surNames;
        [Export("surNames", ArgumentSemantic.Strong)]
        string SurNames { get; set; }

        // @property (nonatomic, strong) NSString * givenNames;
        [Export("givenNames", ArgumentSemantic.Strong)]
        string GivenNames { get; set; }

        // @property (nonatomic, strong) NSString * countryCode __attribute__((deprecated("Deprecated since 3.2.1. Use issuingCountryCode and nationalityCountryCode instead.")));
        [Obsolete("Deprecated since 3.2.1. Use IssuingCountryCode and NationalityCountryCode instead.")]
        [Export("countryCode", ArgumentSemantic.Strong)]
        string CountryCode { get; set; }

        // @property (nonatomic, strong) NSString * issuingCountryCode;
        [Export("issuingCountryCode", ArgumentSemantic.Strong)]
        string IssuingCountryCode { get; set; }

        // @property (nonatomic, strong) NSString * nationalityCountryCode;
        [Export("nationalityCountryCode", ArgumentSemantic.Strong)]
        string NationalityCountryCode { get; set; }

        // @property (nonatomic, strong) NSString * dayOfBirth;
        [Export("dayOfBirth", ArgumentSemantic.Strong)]
        string DayOfBirth { get; set; }

        // @property (nonatomic, strong) NSString * expirationDate;
        [Export("expirationDate", ArgumentSemantic.Strong)]
        string ExpirationDate { get; set; }

        // @property (nonatomic, strong) NSString * sex;
        [Export("sex", ArgumentSemantic.Strong)]
        string Sex { get; set; }

        // @property (nonatomic, strong) NSString * checkdigitNumber;
        [Export("checkdigitNumber", ArgumentSemantic.Strong)]
        string CheckdigitNumber { get; set; }

        // @property (nonatomic, strong) NSString * checkdigitExpirationDate;
        [Export("checkdigitExpirationDate", ArgumentSemantic.Strong)]
        string CheckdigitExpirationDate { get; set; }

        // @property (nonatomic, strong) NSString * checkdigitDayOfBirth;
        [Export("checkdigitDayOfBirth", ArgumentSemantic.Strong)]
        string CheckdigitDayOfBirth { get; set; }

        // @property (nonatomic, strong) NSString * checkdigitFinal;
        [Export("checkdigitFinal", ArgumentSemantic.Strong)]
        string CheckdigitFinal { get; set; }

        // @property (nonatomic, strong) NSString * personalNumber;
        [Export("personalNumber", ArgumentSemantic.Strong)]
        string PersonalNumber { get; set; }

        // @property (nonatomic, strong) NSString * checkDigitPersonalNumber;
        [Export("checkDigitPersonalNumber", ArgumentSemantic.Strong)]
        string CheckDigitPersonalNumber { get; set; }

        // @property (nonatomic, strong) NSString * personalNumber2;
        [Export("personalNumber2", ArgumentSemantic.Strong)]
        string PersonalNumber2 { get; set; }

        // -(instancetype)initWithDocumentType:(NSString *)documentType countryCode:(NSString *)countryCode issuingCountryCode:(NSString *)issuingCountryCode nationalityCountryCode:(NSString *)nationalityCountryCode surNames:(NSString *)surNames givenNames:(NSString *)givenNames documentNumber:(NSString *)documentNumber checkDigitNumber:(NSString *)checkDigitNumber dayOfBirth:(NSString *)dayOfBirth checkDigitDayOfBirth:(NSString *)checkDigitDayOfBirth sex:(NSString *)sex expirationDate:(NSString *)expirationDate checkDigitExpirationDate:(NSString *)checkdigitExpirationDate personalNumber:(NSString *)personalNumber checkDigitPersonalNumber:(NSString *)checkDigitPersonalNumber checkDigitFinal:(NSString *)checkDigitFinal personalNumber2:(NSString *)personalNumber2;
        [Export("initWithDocumentType:countryCode:issuingCountryCode:nationalityCountryCode:surNames:givenNames:documentNumber:checkDigitNumber:dayOfBirth:checkDigitDayOfBirth:sex:expirationDate:checkDigitExpirationDate:personalNumber:checkDigitPersonalNumber:checkDigitFinal:personalNumber2:")]
        IntPtr Constructor(string documentType, string countryCode, string issuingCountryCode, string nationalityCountryCode, string surNames, string givenNames, string documentNumber, string checkDigitNumber, string dayOfBirth, string checkDigitDayOfBirth, string sex, string expirationDate, string checkdigitExpirationDate, string personalNumber, string checkDigitPersonalNumber, string checkDigitFinal, string personalNumber2);
    }

// @interface AnylineMRZModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineMRZModuleView
    {
        //ADDED
        // -(instancetype)initWithFrame:(CGRect)frame;
        [Export("initWithFrame:")]
        IntPtr Constructor(CGRect frame);

        // -(BOOL)setupWithLicenseKey:(NSString *)licenseKey delegate:(id<AnylineMRZModuleDelegate>)delegate error:(NSError **)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, out NSError error);
    }

    // @protocol AnylineMRZModuleDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineMRZModuleDelegate
    {
        // @optional -(void)anylineMRZModuleView:(AnylineMRZModuleView *)anylineMRZModuleView didFindScanResult:(ALIdentification *)scanResult allCheckDigitsValid:(BOOL)allCheckDigitsValid atImage:(UIImage *)image __attribute__((deprecated("Deprecated since 3.10. Use method anylineMRZModuleView:didFindScanResult:allCheckDigitsValid:atImage: instead.")));
        //[Export("anylineMRZModuleView:didFindScanResult:allCheckDigitsValid:atImage:")]
        //void DidFindScanResult(AnylineMRZModuleView anylineMRZModuleView, ALIdentification scanResult, bool allCheckDigitsValid, UIImage image);

        // @required -(void)anylineMRZModuleView:(AnylineMRZModuleView *)anylineMRZModuleView didFindResult:(ALMRZResult *)scanResult;
        [Abstract]
        [Export("anylineMRZModuleView:didFindResult:")]
        void DidFindResult(AnylineMRZModuleView anylineMRZModuleView, ALMRZResult scanResult);
    }

    // @interface ALOCRConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface ALOCRConfig
    {
        // -(instancetype)initWithJsonDictionary:(NSDictionary *)configDict;
        [Export("initWithJsonDictionary:")]
        IntPtr Constructor(NSDictionary configDict);

        // @property (assign, nonatomic) ALOCRScanMode scanMode;
        [Export("scanMode", ArgumentSemantic.Assign)]
        ALOCRScanMode ScanMode { get; set; }

        // @property (nonatomic, strong) NSString * customCmdFilePath;
        [Export("customCmdFilePath", ArgumentSemantic.Strong)]
        string CustomCmdFilePath { get; set; }

        // @property (nonatomic, strong) NSString * customCmdFileString;
        [Export("customCmdFileString", ArgumentSemantic.Strong)]
        string CustomCmdFileString { get; set; }

        // @property (assign, nonatomic) ALRange charHeight;
        [Export("charHeight", ArgumentSemantic.Copy)]
        ALRange CharHeight { get; set; }

        // @property (nonatomic, strong) NSArray<NSString *> * tesseractLanguages;
        [Export("tesseractLanguages", ArgumentSemantic.Strong)]
        string[] TesseractLanguages { get; set; }

        // @property (nonatomic, strong) NSString * charWhiteList;
        [Export("charWhiteList", ArgumentSemantic.Strong)]
        string CharWhiteList { get; set; }

        // @property (nonatomic, strong) NSString * validationRegex;
        [Export("validationRegex", ArgumentSemantic.Strong)]
        string ValidationRegex { get; set; }

        // @property (assign, nonatomic) NSUInteger minConfidence;
        [Export("minConfidence")]
        uint MinConfidence { get; set; }

        // @property (assign, nonatomic) BOOL removeSmallContours;
        [Export("removeSmallContours")]
        bool RemoveSmallContours { get; set; }

        // @property (assign, nonatomic) BOOL removeWhitespaces;
        [Export("removeWhitespaces")]
        bool RemoveWhitespaces { get; set; }

        // @property (assign, nonatomic) NSUInteger minSharpness;
        [Export("minSharpness")]
        uint MinSharpness { get; set; }

        // @property (assign, nonatomic) NSUInteger charCountX;
        [Export("charCountX")]
        uint CharCountX { get; set; }

        // @property (assign, nonatomic) NSUInteger charCountY;
        [Export("charCountY")]
        uint CharCountY { get; set; }

        // @property (assign, nonatomic) double charPaddingXFactor;
        [Export("charPaddingXFactor")]
        double CharPaddingXFactor { get; set; }

        // @property (assign, nonatomic) double charPaddingYFactor;
        [Export("charPaddingYFactor")]
        double CharPaddingYFactor { get; set; }

        // @property (assign, nonatomic) BOOL isBrightTextOnDark;
        [Export("isBrightTextOnDark")]
        bool IsBrightTextOnDark { get; set; }
    }

    // @interface ALOCRResult : ALScanResult
    [BaseType(typeof(ALScanResult))]
    interface ALOCRResult
    {
        // @property (readonly, nonatomic, strong) NSString * text __attribute__((deprecated("Deprecated since 3.10 Use result property instead.")));
        [Export("text", ArgumentSemantic.Strong)]
        string Text { get; }

        // @property (readonly, nonatomic, strong) UIImage * thresholdedImage;
        [Export("thresholdedImage", ArgumentSemantic.Strong)]
        UIImage ThresholdedImage { get; }

        // -(instancetype)initWithText:(NSString *)text image:(UIImage *)image thresholdedImage:(UIImage *)thresholdedImage __attribute__((deprecated("Deprecated since 3.10 Use initWithResult:image:fullImage:confidence instead.")));
        [Export("initWithText:image:thresholdedImage:")]
        IntPtr Constructor(string text, UIImage image, UIImage thresholdedImage);

        // -(instancetype)initWithResult:(NSString *)result image:(UIImage *)image fullImage:(UIImage *)fullImage confidence:(NSInteger)confidence outline:(ALSquare *)outline thresholdedImage:(UIImage *)thresholdedImage;
        [Export("initWithResult:image:fullImage:confidence:outline:thresholdedImage:")]
        IntPtr Constructor(string result, UIImage image, UIImage fullImage, nint confidence, ALSquare outline, UIImage thresholdedImage);
    }

    // @interface AnylineOCRModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineOCRModuleView
    {
        //ADDED
        // -(instancetype)initWithFrame:(CGRect)frame;
        [Export("initWithFrame:")]
        IntPtr Constructor(CGRect frame);

        // @property (readonly, nonatomic, strong) ALOCRConfig * ocrConfig;
        [Export("ocrConfig", ArgumentSemantic.Strong)]
        ALOCRConfig OcrConfig { get; }

        // -(BOOL)setupWithLicenseKey:(NSString *)licenseKey delegate:(id<AnylineOCRModuleDelegate>)delegate ocrConfig:(ALOCRConfig *)ocrConfig error:(NSError **)error;
        [Export("setupWithLicenseKey:delegate:ocrConfig:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, ALOCRConfig ocrConfig, out NSError error);

        // -(BOOL)setOCRConfig:(ALOCRConfig *)ocrConfig error:(NSError **)error;
        [Export("setOCRConfig:error:")]
        bool SetOCRConfig(ALOCRConfig ocrConfig, out NSError error);

        // -(BOOL)copyTrainedData:(NSString *)trainedDataPath fileHash:(NSString *)hash error:(NSError **)error;
        [Export("copyTrainedData:fileHash:error:")]
        bool CopyTrainedData(string trainedDataPath, string hash, out NSError error);
    }

    // @protocol AnylineOCRModuleDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineOCRModuleDelegate
    {
        // @required -(void)anylineOCRModuleView:(AnylineOCRModuleView *)anylineOCRModuleView didFindResult:(ALOCRResult *)result;
        [Abstract]
        [Export("anylineOCRModuleView:didFindResult:")]
        void DidFindResult(AnylineOCRModuleView anylineOCRModuleView, ALOCRResult result);

        // @optional -(void)anylineOCRModuleView:(AnylineOCRModuleView *)anylineOCRModuleView reportsVariable:(NSString *)variableName value:(id)value;
        [Export("anylineOCRModuleView:reportsVariable:value:")]
        [Abstract]
        void ReportsVariable(AnylineOCRModuleView anylineOCRModuleView, string variableName, NSObject value);

        // @optional -(void)anylineOCRModuleView:(AnylineOCRModuleView *)anylineOCRModuleView reportsRunFailure:(ALOCRError)error;
        [Export("anylineOCRModuleView:reportsRunFailure:")]
        [Abstract]
        void ReportsRunFailure(AnylineOCRModuleView anylineOCRModuleView, ALOCRError error);

        // @optional -(BOOL)anylineOCRModuleView:(AnylineOCRModuleView *)anylineOCRModuleView textOutlineDetected:(ALSquare *)outline;
        [Export("anylineOCRModuleView:textOutlineDetected:")]
        [Abstract]
        bool TextOutlineDetected(AnylineOCRModuleView anylineOCRModuleView, ALSquare outline);
    }

    // @interface AnylineDocumentModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineDocumentModuleView
    {
        //ADDED
        // -(instancetype)initWithFrame:(CGRect)frame;
        [Export("initWithFrame:")]
        IntPtr Constructor(CGRect frame);

        // -(BOOL)setupWithLicenseKey:(NSString *)licenseKey delegate:(id<AnylineDocumentModuleDelegate>)delegate error:(NSError **)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, out NSError error);

        // @property (nonatomic, strong) NSNumber * maxDocumentRatioDeviation;
        [Export("maxDocumentRatioDeviation", ArgumentSemantic.Strong)]
        NSNumber MaxDocumentRatioDeviation { get; set; }

        // -(void)setDocumentRatios:(NSArray<NSNumber *> *)ratios;
        [Export("setDocumentRatios:")]
        void SetDocumentRatios(NSNumber[] ratios);
    }

    // @protocol AnylineDocumentModuleDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineDocumentModuleDelegate
    {
        // @required -(void)anylineDocumentModuleView:(AnylineDocumentModuleView *)anylineDocumentModuleView hasResult:(UIImage *)transformedImage fullImage:(UIImage *)fullFrame documentCorners:(ALSquare *)corners;
        [Abstract]
        [Export("anylineDocumentModuleView:hasResult:fullImage:documentCorners:")]
        [Abstract]
        void HasResult(AnylineDocumentModuleView anylineDocumentModuleView, UIImage transformedImage, UIImage fullFrame, ALSquare corners);

        // @optional -(void)anylineDocumentModuleView:(AnylineDocumentModuleView *)anylineDocumentModuleView hasResult:(UIImage *)transformedImage fullImage:(UIImage *)fullFrame __attribute__((deprecated("Deprecated since 3.6.1 Use method anylineDocumentModuleView:hasResult:fullImage:documentCorners: instead.")));
        //[Export("anylineDocumentModuleView:hasResult:fullImage:")]
        //[Abstract]
        //void HasResult(AnylineDocumentModuleView anylineDocumentModuleView, UIImage transformedImage, UIImage fullFrame);

        // @optional -(void)anylineDocumentModuleView:(AnylineDocumentModuleView *)anylineDocumentModuleView detectedPictureCorners:(ALSquare *)corners inImage:(UIImage *)image;
        [Export("anylineDocumentModuleView:detectedPictureCorners:inImage:")]
        [Abstract]
        void DetectedPictureCorners(AnylineDocumentModuleView anylineDocumentModuleView, ALSquare corners, UIImage image);

        // @optional -(void)anylineDocumentModuleView:(AnylineDocumentModuleView *)anylineDocumentModuleView reportsPreviewResult:(UIImage *)image;
        [Export("anylineDocumentModuleView:reportsPreviewResult:")]
        [Abstract]
        void ReportsPreviewResult(AnylineDocumentModuleView anylineDocumentModuleView, UIImage image);

        // @optional -(void)anylineDocumentModuleView:(AnylineDocumentModuleView *)anylineDocumentModuleView reportsPreviewProcessingFailure:(ALDocumentError)error;
        [Export("anylineDocumentModuleView:reportsPreviewProcessingFailure:")]
        [Abstract]
        void ReportsPreviewProcessingFailure(AnylineDocumentModuleView anylineDocumentModuleView, ALDocumentError error);

        // @optional -(void)anylineDocumentModuleView:(AnylineDocumentModuleView *)anylineDocumentModuleView reportsPictureProcessingFailure:(ALDocumentError)error;
        [Export("anylineDocumentModuleView:reportsPictureProcessingFailure:")]
        [Abstract]
        void ReportsPictureProcessingFailure(AnylineDocumentModuleView anylineDocumentModuleView, ALDocumentError error);

        // @optional -(BOOL)anylineDocumentModuleView:(AnylineDocumentModuleView *)anylineDocumentModuleView documentOutlineDetected:(NSArray *)outline anglesValid:(BOOL)anglesValid;
        [Export("anylineDocumentModuleView:documentOutlineDetected:anglesValid:")]
        [Abstract]
        bool DocumentOutlineDetected(AnylineDocumentModuleView anylineDocumentModuleView, NSObject[] outline, bool anglesValid);

        // @optional -(void)anylineDocumentModuleViewTakePictureSuccess:(AnylineDocumentModuleView *)anylineDocumentModuleView;
        [Export("anylineDocumentModuleViewTakePictureSuccess:")]
        [Abstract]
        void TakePictureSuccess(AnylineDocumentModuleView anylineDocumentModuleView);

        // @optional -(void)anylineDocumentModuleView:(AnylineDocumentModuleView *)anylineDocumentModuleView takePictureError:(NSError *)error;
        [Export("anylineDocumentModuleView:takePictureError:")]
        [Abstract]
        void TakePictureError(AnylineDocumentModuleView anylineDocumentModuleView, NSError error);
    }

    // Added since 3.10

    // @protocol AnylineDebugDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineDebugDelegate
    {
        // @optional -(void)anylineModuleView:(AnylineAbstractModuleView *)anylineModuleView reportDebugVariable:(NSString *)variableName value:(id)value;
        [Export("anylineModuleView:reportDebugVariable:value:")]
        void ReportDebugVariable(AnylineAbstractModuleView anylineModuleView, string variableName, NSObject value);

        // @optional -(void)anylineModuleView:(AnylineAbstractModuleView *)anylineModuleView runSkipped:(ALRunFailure)runFailure;
        [Export("anylineModuleView:runSkipped:")]
        void RunSkipped(AnylineAbstractModuleView anylineModuleView, NSObject runFailure);
    }

    // audit-objc-generics: @interface ALScanResult<__covariant ObjectType> : NSObject
    [BaseType(typeof(NSObject))]
    interface ALScanResult
    {
        // @property (readonly, nonatomic, strong) ObjectType result;
        [Export("result", ArgumentSemantic.Strong)]
        NSObject Result { get; }

        // @property (readonly, nonatomic, strong) UIImage * image;
        [Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; }

        // @property (readonly, nonatomic, strong) UIImage * fullImage;
        [Export("fullImage", ArgumentSemantic.Strong)]
        UIImage FullImage { get; }

        // @property (readonly, assign, nonatomic) NSInteger confidence;
        [Export("confidence")]
        nint Confidence { get; }

        // @property (readonly, nonatomic, strong) ALSquare * outline;
        [Export("outline", ArgumentSemantic.Strong)]
        ALSquare Outline { get; }

        // -(instancetype)initWithResult:(ObjectType)result image:(UIImage *)image fullImage:(UIImage *)fullImage confidence:(NSInteger)confidence outline:(ALSquare *)outline;
        [Export("initWithResult:image:fullImage:confidence:outline:")]
        IntPtr Constructor(NSObject result, UIImage image, UIImage fullImage, nint confidence, ALSquare outline);
    }

    // @interface ALEnergyResult : ALScanResult
    [BaseType(typeof(ALScanResult))]
    interface ALEnergyResult
    {
        // @property (readonly, assign, nonatomic) ALScanMode scanMode;
        [Export("scanMode", ArgumentSemantic.Assign)]
        ALScanMode ScanMode { get; }

        // -(instancetype)initWithResult:(NSString *)result image:(UIImage *)image fullImage:(UIImage *)fullImage confidence:(NSInteger)confidence outline:(ALSquare *)outline scanMode:(ALScanMode)scanMode;
        [Export("initWithResult:image:fullImage:confidence:outline:scanMode:")]
        IntPtr Constructor(string result, UIImage image, UIImage fullImage, nint confidence, ALSquare outline, ALScanMode scanMode);
    }

    // @interface ALBarcodeResult : ALScanResult
    [BaseType(typeof(ALScanResult))]
    interface ALBarcodeResult
    {
        // @property (readonly, assign, nonatomic) ALBarcodeFormat barcodeFormat;
        [Export("barcodeFormat", ArgumentSemantic.Assign)]
        ALBarcodeFormat BarcodeFormat { get; }

        // -(instancetype)initWithResult:(NSString *)result image:(UIImage *)image fullImage:(UIImage *)fullImage confidence:(NSInteger)confidence outline:(ALSquare *)outline barcodeFormat:(ALBarcodeFormat)barcodeFormat;
        [Export("initWithResult:image:fullImage:confidence:outline:barcodeFormat:")]
        IntPtr Constructor(string result, UIImage image, UIImage fullImage, nint confidence, ALSquare outline, ALBarcodeFormat barcodeFormat);
    }

    // @interface ALMRZResult : ALScanResult
    [BaseType(typeof(ALScanResult))]
    interface ALMRZResult
    {
        // @property (readonly, assign, nonatomic) BOOL allCheckDigitsValid;
        [Export("allCheckDigitsValid")]
        bool AllCheckDigitsValid { get; }

        // -(instancetype)initWithResult:(ALIdentification *)result image:(UIImage *)image fullImage:(UIImage *)fullImage confidence:(NSInteger)confidence outline:(ALSquare *)outline allCheckDigitsValid:(BOOL)allCheckDigitsValid;
        [Export("initWithResult:image:fullImage:confidence:outline:allCheckDigitsValid:")]
        IntPtr Constructor(ALIdentification result, UIImage image, UIImage fullImage, nint confidence, ALSquare outline, bool allCheckDigitsValid);
    }    
}