using System;
using AVFoundation;
//using Anyline;
using CoreGraphics;
using CoreMedia;
using CoreVideo;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace AnylineXamarinSDK.iOS
{
    // @interface ALCutoutView : UIView
    [BaseType(typeof(UIView))]
    interface ALCutoutView
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

        // @property (assign, nonatomic) CGPoint cutoutOffset;
        [Export("cutoutOffset", ArgumentSemantic.Assign)]
        CGPoint CutoutOffset { get; set; }

        // @property (assign, nonatomic) NSInteger cornerRadius;
        [Export("cornerRadius")]
        nint CornerRadius { get; set; }

        // @property (assign, nonatomic) NSInteger strokeWidth;
        [Export("strokeWidth")]
        nint StrokeWidth { get; set; }

        // @property (assign, nonatomic) ALCutoutAlignment cutoutAlignment;
        [Export("cutoutAlignment", ArgumentSemantic.Assign)]
        ALCutoutAlignment CutoutAlignment { get; set; }

        // @property (copy, nonatomic) UIBezierPath * _Nullable cutoutPath;
        [NullAllowed, Export("cutoutPath", ArgumentSemantic.Copy)]
        UIBezierPath CutoutPath { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable cutoutBackgroundColor;
        [NullAllowed, Export("cutoutBackgroundColor", ArgumentSemantic.Strong)]
        UIColor CutoutBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable strokeColor;
        [NullAllowed, Export("strokeColor", ArgumentSemantic.Strong)]
        UIColor StrokeColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable feedbackStrokeColor;
        [NullAllowed, Export("feedbackStrokeColor", ArgumentSemantic.Strong)]
        UIColor FeedbackStrokeColor { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable overlayImage;
        [NullAllowed, Export("overlayImage", ArgumentSemantic.Strong)]
        UIImage OverlayImage { get; set; }

        // -(instancetype _Nullable)initWithFrame:(CGRect)frame cutoutWidthPercent:(CGFloat)cutoutWidthPercent cutoutMaxPercentWidth:(CGFloat)cutoutMaxPercentWidth cutoutMaxPercentHeight:(CGFloat)cutoutMaxPercentHeight cutoutOffset:(CGPoint)cutoutOffset cornerRadius:(NSInteger)cornerRadius strokeWidth:(NSInteger)strokeWidth cutoutAlignment:(ALCutoutAlignment)cutoutAlignment cutoutPath:(UIBezierPath * _Nonnull)cutoutPath cutoutBackgroundColor:(UIColor * _Nonnull)cutoutBackgroundColor strokeColor:(UIColor * _Nonnull)strokeColor feedbackStrokeColor:(UIColor * _Nonnull)feedbackStrokeColor overlayImage:(UIImage * _Nonnull)overlayImage;
        [Export("initWithFrame:cutoutWidthPercent:cutoutMaxPercentWidth:cutoutMaxPercentHeight:cutoutOffset:cornerRadius:strokeWidth:cutoutAlignment:cutoutPath:cutoutBackgroundColor:strokeColor:feedbackStrokeColor:overlayImage:")]
        IntPtr Constructor(CGRect frame, nfloat cutoutWidthPercent, nfloat cutoutMaxPercentWidth, nfloat cutoutMaxPercentHeight, CGPoint cutoutOffset, nint cornerRadius, nint strokeWidth, ALCutoutAlignment cutoutAlignment, UIBezierPath cutoutPath, UIColor cutoutBackgroundColor, UIColor strokeColor, UIColor feedbackStrokeColor, UIImage overlayImage);

        // -(CGRect)cutoutRectScreen;
        [Export("cutoutRectScreen")]
        CGRect CutoutRectScreen { get; }

        // -(void)drawCutout:(BOOL)feedbackMode;
        [Export("drawCutout:")]
        void DrawCutout(bool feedbackMode);

        // -(void)calculateAndDrawCutout;
        [Export("calculateAndDrawCutout")]
        void CalculateAndDrawCutout();
    }

    // @interface ALFlashButtonConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface ALFlashButtonConfig
    {
        // @property (assign, nonatomic) ALFlashMode flashMode;
        [Export("flashMode", ArgumentSemantic.Assign)]
        ALFlashMode FlashMode { get; set; }

        // @property (assign, nonatomic) ALFlashAlignment flashAlignment;
        [Export("flashAlignment", ArgumentSemantic.Assign)]
        ALFlashAlignment FlashAlignment { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable flashImage;
        [NullAllowed, Export("flashImage", ArgumentSemantic.Strong)]
        UIImage FlashImage { get; set; }

        // @property (assign, nonatomic) CGPoint flashOffset;
        [Export("flashOffset", ArgumentSemantic.Assign)]
        CGPoint FlashOffset { get; set; }

        // +(instancetype _Nullable)configurationFromJsonFilePath:(NSString * _Nonnull)jsonFile;
        [Static]
        [Export("configurationFromJsonFilePath:")]
        [return: NullAllowed]
        ALFlashButtonConfig ConfigurationFromJsonFilePath(string jsonFile);

        // -(instancetype _Nullable)initWithJsonFilePath:(NSString * _Nonnull)jsonFile;
        [Export("initWithJsonFilePath:")]
        IntPtr Constructor(string jsonFile);

        // -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)configDict;
        [Export("initWithDictionary:")]
        IntPtr Constructor(NSDictionary configDict);

        // -(instancetype _Nullable)initWithFlashMode:(ALFlashMode)flashMode flashAlignment:(ALFlashAlignment)flashAlignment flashOffset:(CGPoint)flashOffset;
        [Export("initWithFlashMode:flashAlignment:flashOffset:")]
        IntPtr Constructor(ALFlashMode flashMode, ALFlashAlignment flashAlignment, CGPoint flashOffset);

        // +(instancetype _Nonnull)defaultFlashConfig;
        [Static]
        [Export("defaultFlashConfig")]
        ALFlashButtonConfig DefaultFlashConfig();
    }

    // @protocol ALFlashButtonStatusDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IALFlashButtonStatusDelegate
    {
        // @required -(void)flashButton:(ALFlashButton * _Nonnull)flashButton statusChanged:(ALFlashStatus)flashStatus;
        [Abstract]
        [Export("flashButton:statusChanged:")]
        void StatusChanged(ALFlashButton flashButton, ALFlashStatus flashStatus);
    }

    // @protocol ALFlashButtonAnimationDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALFlashButtonAnimationDelegate
    {
        // @optional -(void)flashButton:(ALFlashButton * _Nonnull)flashButton expanded:(BOOL)expanded;
        [Export("flashButton:expanded:")]
        void Expanded(ALFlashButton flashButton, bool expanded);
    }

    // @interface ALFlashButton : UIControl
    [BaseType(typeof(UIControl))]
    interface ALFlashButton
    {
        // @property (readonly, assign, nonatomic) BOOL expanded;
        [Export("expanded")]
        bool Expanded { get; }

        // @property (readonly, assign, nonatomic) BOOL expandLeft;
        [Export("expandLeft")]
        bool ExpandLeft { get; }

        // @property (readonly, nonatomic, strong) UIImageView * _Nullable flashImage;
        [NullAllowed, Export("flashImage", ArgumentSemantic.Strong)]
        UIImageView FlashImage { get; }

        // @property (assign, nonatomic) ALFlashStatus flashStatus;
        [Export("flashStatus", ArgumentSemantic.Assign)]
        ALFlashStatus FlashStatus { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        IALFlashButtonStatusDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ALFlashButtonStatusDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        [Wrap("WeakAnimationDelegate")]
        [NullAllowed]
        ALFlashButtonAnimationDelegate AnimationDelegate { get; set; }

        // @property (nonatomic, weak) id<ALFlashButtonAnimationDelegate> _Nullable animationDelegate;
        [NullAllowed, Export("animationDelegate", ArgumentSemantic.Weak)]
        NSObject WeakAnimationDelegate { get; set; }

        // -(void)setExpanded:(BOOL)expanded animated:(BOOL)animated;
        [Export("setExpanded:animated:")]
        void SetExpanded(bool expanded, bool animated);

        // -(instancetype _Nullable)initWithFrame:(CGRect)frame flashButtonConfig:(ALFlashButtonConfig * _Nonnull)flashButtonConfig;
        [Export("initWithFrame:flashButtonConfig:")]
        IntPtr Constructor(CGRect frame, ALFlashButtonConfig flashButtonConfig);
    }

    // @interface ALCameraConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface ALCameraConfig
    {
        // @property (nonatomic, strong) NSString * _Nullable defaultCamera;
        [NullAllowed, Export("defaultCamera", ArgumentSemantic.Strong)]
        string DefaultCamera { get; set; }

        // @property (assign, nonatomic) ALCaptureViewResolution captureResolution;
        [Export("captureResolution", ArgumentSemantic.Assign)]
        ALCaptureViewResolution CaptureResolution { get; set; }

        // @property (assign, nonatomic) ALPictureResolution pictureResolution;
        [Export("pictureResolution", ArgumentSemantic.Assign)]
        ALPictureResolution PictureResolution { get; set; }

        // +(instancetype _Nullable)configurationFromJsonFilePath:(NSString * _Nonnull)jsonFile;
        [Static]
        [Export("configurationFromJsonFilePath:")]
        [return: NullAllowed]
        ALCameraConfig ConfigurationFromJsonFilePath(string jsonFile);

        // -(instancetype _Nullable)initWithJsonFilePath:(NSString * _Nonnull)jsonFile;
        [Export("initWithJsonFilePath:")]
        IntPtr Constructor(string jsonFile);

        // -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)configDict;
        [Export("initWithDictionary:")]
        IntPtr Constructor(NSDictionary configDict);

        // -(instancetype _Nullable)initWithDefaultCamera:(NSString * _Nonnull)defaultCamera captureResolution:(ALCaptureViewResolution)captureResolution pictureResolution:(ALPictureResolution)pictureResolution;
        [Export("initWithDefaultCamera:captureResolution:pictureResolution:")]
        IntPtr Constructor(string defaultCamera, ALCaptureViewResolution captureResolution, ALPictureResolution pictureResolution);

        // +(instancetype _Nullable)defaultCameraConfig;
        [Static]
        [Export("defaultCameraConfig")]
        [return: NullAllowed]
        ALCameraConfig DefaultCameraConfig();

        // +(instancetype _Nullable)defaultDocumentCameraConfig;
        [Static]
        [Export("defaultDocumentCameraConfig")]
        [return: NullAllowed]
        ALCameraConfig DefaultDocumentCameraConfig();
    }

    // @interface ALScanFeedbackConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface ALScanFeedbackConfig
    {
        // @property (assign, nonatomic) ALUIFeedbackStyle style;
        [Export("style", ArgumentSemantic.Assign)]
        ALUIFeedbackStyle Style { get; set; }

        // @property (assign, nonatomic) ALUIVisualFeedbackAnimation animation;
        [Export("animation", ArgumentSemantic.Assign)]
        ALUIVisualFeedbackAnimation Animation { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable strokeColor;
        [NullAllowed, Export("strokeColor", ArgumentSemantic.Strong)]
        UIColor StrokeColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable fillColor;
        [NullAllowed, Export("fillColor", ArgumentSemantic.Strong)]
        UIColor FillColor { get; set; }

        // @property (assign, nonatomic) NSInteger strokeWidth;
        [Export("strokeWidth")]
        nint StrokeWidth { get; set; }

        // @property (assign, nonatomic) NSInteger cornerRadius;
        [Export("cornerRadius")]
        nint CornerRadius { get; set; }

        // @property (assign, nonatomic) NSInteger animationDuration;
        [Export("animationDuration")]
        nint AnimationDuration { get; set; }

        // @property (assign, nonatomic) NSInteger redrawTimeout;
        [Export("redrawTimeout")]
        nint RedrawTimeout { get; set; }

        // @property (assign, nonatomic) BOOL beepOnResult;
        [Export("beepOnResult")]
        bool BeepOnResult { get; set; }

        // @property (assign, nonatomic) BOOL vibrateOnResult;
        [Export("vibrateOnResult")]
        bool VibrateOnResult { get; set; }

        // @property (assign, nonatomic) BOOL blinkAnimationOnResult;
        [Export("blinkAnimationOnResult")]
        bool BlinkAnimationOnResult { get; set; }

        // -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)configDict;
        [Export("initWithDictionary:")]
        IntPtr Constructor(NSDictionary configDict);

        // -(instancetype _Nullable)initWithStyle:(ALUIFeedbackStyle)style animation:(ALUIVisualFeedbackAnimation)animation strokeColor:(UIColor * _Nonnull)strokeColor fillColor:(UIColor * _Nonnull)fillColor strokeWidth:(NSInteger)strokeWidth cornerRadius:(NSInteger)cornerRadius animationDuration:(NSInteger)animationDuration redrawTimeout:(NSInteger)redrawTimeout beepOnResult:(BOOL)beepOnResult vibrateOnResult:(BOOL)vibrateOnResult blinkAnimationOnResult:(BOOL)blinkAnimationOnResult;
        [Export("initWithStyle:animation:strokeColor:fillColor:strokeWidth:cornerRadius:animationDuration:redrawTimeout:beepOnResult:vibrateOnResult:blinkAnimationOnResult:")]
        IntPtr Constructor(ALUIFeedbackStyle style, ALUIVisualFeedbackAnimation animation, UIColor strokeColor, UIColor fillColor, nint strokeWidth, nint cornerRadius, nint animationDuration, nint redrawTimeout, bool beepOnResult, bool vibrateOnResult, bool blinkAnimationOnResult);

        // +(instancetype _Nonnull)defaultScanFeedbackConfig;
        [Static]
        [Export("defaultScanFeedbackConfig")]
        ALScanFeedbackConfig DefaultScanFeedbackConfig();
    }

    // @interface ALCutoutConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface ALCutoutConfig
    {
        // @property (assign, nonatomic) CGFloat widthPercent;
        [Export("widthPercent")]
        nfloat WidthPercent { get; set; }

        // @property (assign, nonatomic) CGFloat maxPercentWidth;
        [Export("maxPercentWidth")]
        nfloat MaxPercentWidth { get; set; }

        // @property (assign, nonatomic) CGFloat maxPercentHeight;
        [Export("maxPercentHeight")]
        nfloat MaxPercentHeight { get; set; }

        // @property (assign, nonatomic) ALCutoutAlignment alignment;
        [Export("alignment", ArgumentSemantic.Assign)]
        ALCutoutAlignment Alignment { get; set; }

        // @property (assign, nonatomic) CGPoint offset;
        [Export("offset", ArgumentSemantic.Assign)]
        CGPoint Offset { get; set; }

        // @property (copy, nonatomic) UIBezierPath * _Nullable path;
        [NullAllowed, Export("path", ArgumentSemantic.Copy)]
        UIBezierPath Path { get; set; }

        // @property (assign, nonatomic) CGSize cropPadding;
        [Export("cropPadding", ArgumentSemantic.Assign)]
        CGSize CropPadding { get; set; }

        // @property (assign, nonatomic) CGPoint cropOffset;
        [Export("cropOffset", ArgumentSemantic.Assign)]
        CGPoint CropOffset { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable backgroundColor;
        [NullAllowed, Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable strokeColor;
        [NullAllowed, Export("strokeColor", ArgumentSemantic.Strong)]
        UIColor StrokeColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable feedbackStrokeColor;
        [NullAllowed, Export("feedbackStrokeColor", ArgumentSemantic.Strong)]
        UIColor FeedbackStrokeColor { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable overlayImage;
        [NullAllowed, Export("overlayImage", ArgumentSemantic.Strong)]
        UIImage OverlayImage { get; set; }

        // @property (assign, nonatomic) NSInteger strokeWidth;
        [Export("strokeWidth")]
        nint StrokeWidth { get; set; }

        // @property (assign, nonatomic) NSInteger cornerRadius;
        [Export("cornerRadius")]
        nint CornerRadius { get; set; }

        // -(void)setCutoutPathForWidth:(CGFloat)width height:(CGFloat)height;
        [Export("setCutoutPathForWidth:height:")]
        void SetCutoutPathForWidth(nfloat width, nfloat height);

        // -(void)updateCutoutWidth:(CGFloat)width;
        [Export("updateCutoutWidth:")]
        void UpdateCutoutWidth(nfloat width);

        // +(instancetype _Nonnull)defaultCutoutConfig;
        [Static]
        [Export("defaultCutoutConfig")]
        ALCutoutConfig DefaultCutoutConfig();

        // -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)configDict;
        [Export("initWithDictionary:")]
        IntPtr Constructor(NSDictionary configDict);

        // -(instancetype _Nullable)initWithWidthPercent:(CGFloat)widthPercent maxPercentWidth:(CGFloat)maxPercentWidth maxPercentHeight:(CGFloat)maxPercentHeight alignment:(ALCutoutAlignment)alignment offset:(CGPoint)offset path:(UIBezierPath * _Nonnull)path cropPadding:(CGSize)cropPadding cropOffset:(CGPoint)cropOffset backgroundColor:(UIColor * _Nonnull)backgroundColor strokeColor:(UIColor * _Nonnull)strokeColor feedbackStrokeColor:(UIColor * _Nonnull)feedbackStrokeColor overlayImage:(UIImage * _Nullable)overlayImage strokeWidth:(NSInteger)strokeWidth cornerRadius:(NSInteger)cornerRadius;
        [Export("initWithWidthPercent:maxPercentWidth:maxPercentHeight:alignment:offset:path:cropPadding:cropOffset:backgroundColor:strokeColor:feedbackStrokeColor:overlayImage:strokeWidth:cornerRadius:")]
        IntPtr Constructor(nfloat widthPercent, nfloat maxPercentWidth, nfloat maxPercentHeight, ALCutoutAlignment alignment, CGPoint offset, UIBezierPath path, CGSize cropPadding, CGPoint cropOffset, UIColor backgroundColor, UIColor strokeColor, UIColor feedbackStrokeColor, [NullAllowed] UIImage overlayImage, nint strokeWidth, nint cornerRadius);
    }

    // @interface ALScanViewPluginConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface ALScanViewPluginConfig
    {
        // @property (nonatomic, strong) ALScanFeedbackConfig * _Nonnull scanFeedbackConfig;
        [Export("scanFeedbackConfig", ArgumentSemantic.Strong)]
        ALScanFeedbackConfig ScanFeedbackConfig { get; set; }

        // @property (nonatomic, strong) ALCutoutConfig * _Nonnull cutoutConfig;
        [Export("cutoutConfig", ArgumentSemantic.Strong)]
        ALCutoutConfig CutoutConfig { get; set; }

        // @property (assign, nonatomic) BOOL cancelOnResult;
        [Export("cancelOnResult")]
        bool CancelOnResult { get; set; }

        // -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)configDict;
        [Export("initWithDictionary:")]
        IntPtr Constructor(NSDictionary configDict);

        // +(instancetype _Nullable)configurationFromJsonFilePath:(NSString * _Nonnull)jsonFile;
        [Static]
        [Export("configurationFromJsonFilePath:")]
        [return: NullAllowed]
        ALScanViewPluginConfig ConfigurationFromJsonFilePath(string jsonFile);

        // -(instancetype _Nullable)initWithJsonFilePath:(NSString * _Nonnull)jsonFile;
        [Export("initWithJsonFilePath:")]
        IntPtr Constructor(string jsonFile);

        // -(instancetype _Nullable)initWithScanFeedbackConfig:(ALScanFeedbackConfig * _Nonnull)scanFeedbackConfig cutoutConfig:(ALCutoutConfig * _Nonnull)cutoutConfig cancelOnResult:(BOOL)cancelOnResult;
        [Export("initWithScanFeedbackConfig:cutoutConfig:cancelOnResult:")]
        IntPtr Constructor(ALScanFeedbackConfig scanFeedbackConfig, ALCutoutConfig cutoutConfig, bool cancelOnResult);

        // +(instancetype _Nonnull)defaultScanViewPluginConfig;
        [Static]
        [Export("defaultScanViewPluginConfig")]
        ALScanViewPluginConfig DefaultScanViewPluginConfig();

        // +(instancetype _Nonnull)defaultDocumentScannerConfig;
        [Static]
        [Export("defaultDocumentScannerConfig")]
        ALScanViewPluginConfig DefaultDocumentScannerConfig();

        // +(instancetype _Nonnull)defaultBarcodeConfig;
        [Static]
        [Export("defaultBarcodeConfig")]
        ALScanViewPluginConfig DefaultBarcodeConfig();

        // +(instancetype _Nonnull)defaultLicensePlateConfig;
        [Static]
        [Export("defaultLicensePlateConfig")]
        ALScanViewPluginConfig DefaultLicensePlateConfig();

        // +(instancetype _Nonnull)defaultOCRConfig;
        [Static]
        [Export("defaultOCRConfig")]
        ALScanViewPluginConfig DefaultOCRConfig();

        // +(instancetype _Nonnull)defaultMRZConfig;
        [Static]
        [Export("defaultMRZConfig")]
        ALScanViewPluginConfig DefaultMRZConfig();

        // +(instancetype _Nonnull)defaultDrivingLicenseConfig;
        [Static]
        [Export("defaultDrivingLicenseConfig")]
        ALScanViewPluginConfig DefaultDrivingLicenseConfig();

        // +(instancetype _Nonnull)defaultGermanIDFrontConfig;
        [Static]
        [Export("defaultGermanIDFrontConfig")]
        ALScanViewPluginConfig DefaultGermanIDFrontConfig();

        // +(instancetype _Nonnull)defaultMeterConfig;
        [Static]
        [Export("defaultMeterConfig")]
        ALScanViewPluginConfig DefaultMeterConfig();
    }

    // @interface ALBasicConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface ALBasicConfig
    {
        // @property (nonatomic, strong) ALCameraConfig * _Nonnull cameraConfig;
        [Export("cameraConfig", ArgumentSemantic.Strong)]
        ALCameraConfig CameraConfig { get; set; }

        // @property (nonatomic, strong) ALFlashButtonConfig * _Nonnull flashButtonConfig;
        [Export("flashButtonConfig", ArgumentSemantic.Strong)]
        ALFlashButtonConfig FlashButtonConfig { get; set; }

        // @property (nonatomic, strong) ALScanViewPluginConfig * _Nonnull scanViewPluginConfig;
        [Export("scanViewPluginConfig", ArgumentSemantic.Strong)]
        ALScanViewPluginConfig ScanViewPluginConfig { get; set; }

        // +(instancetype _Nullable)cutoutConfigurationFromJsonFile:(NSString * _Nonnull)jsonFile;
        [Static]
        [Export("cutoutConfigurationFromJsonFile:")]
        [return: NullAllowed]
        ALBasicConfig CutoutConfigurationFromJsonFile(string jsonFile);

        // -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)dictionary;
        [Export("initWithDictionary:")]
        IntPtr Constructor(NSDictionary dictionary);

        // -(instancetype _Nullable)initWithJsonFile:(NSString * _Nonnull)jsonFile;
        [Export("initWithJsonFile:")]
        IntPtr Constructor(string jsonFile);

        // -(instancetype _Nullable)initWithCameraConfig:(ALCameraConfig * _Nonnull)cameraConfig flashButtonConfig:(ALFlashButtonConfig * _Nonnull)flashButtonConfig scanViewPluginConfig:(ALScanViewPluginConfig * _Nonnull)scanViewPluginConfig;
        [Export("initWithCameraConfig:flashButtonConfig:scanViewPluginConfig:")]
        IntPtr Constructor(ALCameraConfig cameraConfig, ALFlashButtonConfig flashButtonConfig, ALScanViewPluginConfig scanViewPluginConfig);
    }

    // @interface ALUIConfiguration : ALBasicConfig
    [BaseType(typeof(ALBasicConfig))]
    interface ALUIConfiguration
    {
        // @property (nonatomic, strong) NSString * _Nullable defaultCamera;
        [NullAllowed, Export("defaultCamera", ArgumentSemantic.Strong)]
        string DefaultCamera { get; set; }

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

        // @property (copy, nonatomic) UIBezierPath * _Nullable cutoutPath;
        [NullAllowed, Export("cutoutPath", ArgumentSemantic.Copy)]
        UIBezierPath CutoutPath { get; set; }

        // @property (assign, nonatomic) CGSize cutoutCropPadding;
        [Export("cutoutCropPadding", ArgumentSemantic.Assign)]
        CGSize CutoutCropPadding { get; set; }

        // @property (assign, nonatomic) CGPoint cutoutCropOffset;
        [Export("cutoutCropOffset", ArgumentSemantic.Assign)]
        CGPoint CutoutCropOffset { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable cutoutBackgroundColor;
        [NullAllowed, Export("cutoutBackgroundColor", ArgumentSemantic.Strong)]
        UIColor CutoutBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable overlayImage;
        [NullAllowed, Export("overlayImage", ArgumentSemantic.Strong)]
        UIImage OverlayImage { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable strokeColor;
        [NullAllowed, Export("strokeColor", ArgumentSemantic.Strong)]
        UIColor StrokeColor { get; set; }

        // @property (assign, nonatomic) NSInteger strokeWidth;
        [Export("strokeWidth")]
        nint StrokeWidth { get; set; }

        // @property (assign, nonatomic) NSInteger cornerRadius;
        [Export("cornerRadius")]
        nint CornerRadius { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable feedbackStrokeColor;
        [NullAllowed, Export("feedbackStrokeColor", ArgumentSemantic.Strong)]
        UIColor FeedbackStrokeColor { get; set; }

        // @property (assign, nonatomic) ALUIFeedbackStyle feedbackStyle;
        [Export("feedbackStyle", ArgumentSemantic.Assign)]
        ALUIFeedbackStyle FeedbackStyle { get; set; }

        // @property (assign, nonatomic) ALUIVisualFeedbackAnimation visualFeedbackAnimation;
        [Export("visualFeedbackAnimation", ArgumentSemantic.Assign)]
        ALUIVisualFeedbackAnimation VisualFeedbackAnimation { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable visualFeedbackStrokeColor;
        [NullAllowed, Export("visualFeedbackStrokeColor", ArgumentSemantic.Strong)]
        UIColor VisualFeedbackStrokeColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable visualFeedbackFillColor;
        [NullAllowed, Export("visualFeedbackFillColor", ArgumentSemantic.Strong)]
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

        // @property (nonatomic, strong) UIColor * _Nullable backgroundColorWithoutAlpha;
        [NullAllowed, Export("backgroundColorWithoutAlpha", ArgumentSemantic.Strong)]
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

        // @property (nonatomic, strong) UIImage * _Nullable flashImage;
        [NullAllowed, Export("flashImage", ArgumentSemantic.Strong)]
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

        // -(void)setCutoutPathForWidth:(CGFloat)width height:(CGFloat)height;
        [Export("setCutoutPathForWidth:height:")]
        void SetCutoutPathForWidth(nfloat width, nfloat height);

        // -(void)updateCutoutWidth:(CGFloat)width;
        [Export("updateCutoutWidth:")]
        void UpdateCutoutWidth(nfloat width);

        // +(instancetype)cutoutConfigurationFromJsonFile:(NSString *)jsonFile;
        [Static]
        [Export("cutoutConfigurationFromJsonFile:")]
        ALUIConfiguration CutoutConfigurationFromJsonFile(string jsonFile);
    }

    // @interface Paths (ALUIConfiguration)
    [Category]
    [BaseType(typeof(ALUIConfiguration))]
    interface ALUIConfiguration_Paths
    {
        // +(UIBezierPath * _Nullable)AL_lugPath;
        [Static]
        [NullAllowed, Export("AL_lugPath")]
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

    // @interface ALImage : NSObject
    [BaseType(typeof(NSObject))]
    interface ALImage
    {
        // @property (nonatomic, strong) UIImage * uiImage;
        [Export("uiImage", ArgumentSemantic.Strong)]
        UIImage UiImage { get; set; }

        // -(UIImage *)uiImageWithSpecOverlay:(ALROISpec *)displaySpec;
        //[Export("uiImageWithSpecOverlay:")]
        //UIImage UiImageWithSpecOverlay(ALROISpec displaySpec);

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

        // -(instancetype)initWithBGRAImageBuffer:(CVImageBufferRef)imageBuffer rotate:(CGFloat)degrees;
        //[Export("initWithBGRAImageBuffer:rotate:")]
        //unsafe IntPtr Constructor(CVImageBufferRef* imageBuffer, nfloat degrees);

        // -(instancetype)initWithBGRAImageBuffer:(CVImageBufferRef)imageBuffer rotate:(CGFloat)degrees cutout:(CGRect)cutout;
        //[Export("initWithBGRAImageBuffer:rotate:cutout:")]
        //unsafe IntPtr Constructor(CVImageBufferRef* imageBuffer, nfloat degrees, CGRect cutout);

        // -(BOOL)isEmpy;
        [Export("isEmpy")]
        bool IsEmpy { get; }
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

    /*
    // @interface ALROISpec : NSObject
    [BaseType(typeof(NSObject))]
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

        IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier, nint italicOffset, NSObject[] segments, NSObject[] qualitySegments, NSDictionary segmentResultPattern);

        // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier italicOffset:(NSInteger)italicOffset segmentResultPattern:(NSDictionary *)segmentResultPattern;
        [Export("initWithArea:indexPath:identifier:italicOffset:segmentResultPattern:")]
        IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier, nint italicOffset, NSDictionary segmentResultPattern);

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

        IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier, NSObject[] languages, NSDictionary tesseractParameter);

        // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier languages:(NSArray *)languages tesseractParameter:(NSDictionary *)tesseractParameter characterRange:(ALCharacterRange)characterRange;
        [Export("initWithArea:indexPath:identifier:languages:tesseractParameter:characterRange:")]

        IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier, NSObject[] languages, NSDictionary tesseractParameter, ALCharacterRange characterRange);
    }

    // @interface ALResult : NSObject
    [BaseType(typeof(NSObject))]
    interface ALResult
    {
        // @property (nonatomic, strong) ALROISpec * specs;
        //[Export("specs", ArgumentSemantic.Strong)]
        //ALROISpec Specs { get; set; }

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

    // @protocol ALImageProvider <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IALImageProvider
    {
        // @required -(void)provideNewImageWithCompletionBlock:(ALImageProviderBlock)completionHandler;
        [Abstract]
        [Export("provideNewImageWithCompletionBlock:")]
        void ProvideNewImageWithCompletionBlock(ALImageProviderBlock completionHandler);

        // @required -(void)provideNewFullResolutionImageWithCompletionBlock:(ALImageProviderBlock)completionHandler;
        [Abstract]
        [Export("provideNewFullResolutionImageWithCompletionBlock:")]
        void ProvideNewFullResolutionImageWithCompletionBlock(ALImageProviderBlock completionHandler);

        // @required -(void)provideNewStillImageWithCompletionBlock:(ALImageProviderBlock)completionHandler;
        [Abstract]
        [Export("provideNewStillImageWithCompletionBlock:")]
        void ProvideNewStillImageWithCompletionBlock(ALImageProviderBlock completionHandler);
    }

    // typedef void (^ALImageProviderBlock)(ALImage *, NSError *);
    delegate void ALImageProviderBlock(ALImage arg0, NSError arg1);

    // @interface ALCoreController : NSObject
    [BaseType(typeof(NSObject))]
    interface ALCoreController
    {
        // @property (assign, nonatomic) BOOL asyncSDK;
        [Export("asyncSDK")]
        bool AsyncSDK { get; set; }

        // @property (getter = isRunning, assign, nonatomic) BOOL running;
        [Export("running")]
        bool Running { [Bind("isRunning")] get; set; }

        // @property (getter = isSingleRun, assign, nonatomic) BOOL singleRun;
        [Export("singleRun")]
        bool SingleRun { [Bind("isSingleRun")] get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        IALCoreControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ALCoreControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(instancetype _Nullable)initWithLicenseKey:(NSString * _Nonnull)licenseKey;
        [Export("initWithLicenseKey:")]
        IntPtr Constructor(string licenseKey);

        // -(instancetype _Nullable)initWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<ALCoreControllerDelegate> _Nullable)delegate;
        [Export("initWithLicenseKey:delegate:")]
        IntPtr Constructor(string licenseKey, [NullAllowed] NSObject @delegate);

        // -(BOOL)loadScript:(NSString * _Nonnull)script bundlePath:(NSString * _Nonnull)bundlePath error:(NSError * _Nullable * _Nullable)error;
        [Export("loadScript:bundlePath:error:")]
        bool LoadScript(string script, string bundlePath, [NullAllowed] out NSError error);

        // -(BOOL)loadScript:(NSString * _Nonnull)script scriptName:(NSString * _Nonnull)scriptName bundlePath:(NSString * _Nonnull)bundlePath error:(NSError * _Nullable * _Nullable)error;
        [Export("loadScript:scriptName:bundlePath:error:")]
        bool LoadScript(string script, string scriptName, string bundlePath, [NullAllowed] out NSError error);

        // -(BOOL)loadCmdFile:(NSString * _Nonnull)cmdFileName bundlePath:(NSString * _Nonnull)bundlePath error:(NSError * _Nullable * _Nullable)error;
        [Export("loadCmdFile:bundlePath:error:")]
        bool LoadCmdFile(string cmdFileName, string bundlePath, [NullAllowed] out NSError error);

        // -(BOOL)startWithImageProvider:(id<ALImageProvider> _Nonnull)imageProvider error:(NSError * _Nullable * _Nullable)error;
        [Export("startWithImageProvider:error:")]
        bool StartWithImageProvider(IALImageProvider imageProvider, [NullAllowed] out NSError error);

        // -(BOOL)startWithImageProvider:(id<ALImageProvider> _Nonnull)imageProvider startVariables:(NSDictionary * _Nullable)variables error:(NSError * _Nullable * _Nullable)error;
        [Export("startWithImageProvider:startVariables:error:")]
        bool StartWithImageProvider(IALImageProvider imageProvider, [NullAllowed] NSDictionary variables, [NullAllowed] out NSError error);

        // -(BOOL)stopAndReturnError:(NSError * _Nullable * _Nullable)error;
        [Export("stopAndReturnError:")]
        bool StopAndReturnError([NullAllowed] out NSError error);

        // -(BOOL)processImage:(UIImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error;
        [Export("processImage:error:")]
        bool ProcessImage(UIImage image, [NullAllowed] out NSError error);

        // -(BOOL)processImage:(UIImage * _Nonnull)image startVariables:(NSDictionary * _Nullable)variables error:(NSError * _Nullable * _Nullable)error;
        [Export("processImage:startVariables:error:")]
        bool ProcessImage(UIImage image, [NullAllowed] NSDictionary variables, [NullAllowed] out NSError error);

        // -(BOOL)processALImage:(ALImage * _Nonnull)alImage error:(NSError * _Nullable * _Nullable)error;
        [Export("processALImage:error:")]
        bool ProcessALImage(ALImage alImage, [NullAllowed] out NSError error);

        // -(BOOL)processALImage:(ALImage * _Nonnull)alImage startVariables:(NSDictionary * _Nullable)variables error:(NSError * _Nullable * _Nullable)error;
        [Export("processALImage:startVariables:error:")]
        bool ProcessALImage(ALImage alImage, [NullAllowed] NSDictionary variables, [NullAllowed] out NSError error);

        // -(void)setParameter:(id _Nonnull)parameter forKey:(NSString * _Nonnull)key;
        [Export("setParameter:forKey:")]
        void SetParameter(NSObject parameter, string key);

        // +(NSString * _Nonnull)versionNumber;
        [Static]
        [Export("versionNumber")]

        string VersionNumber { get; }

        // +(NSString * _Nonnull)buildNumber;
        [Static]
        [Export("buildNumber")]

        string BuildNumber { get; }

        // +(NSString * _Nullable)licenseExpirationDateForLicense:(NSString * _Nullable)licenseKey error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("licenseExpirationDateForLicense:error:")]
        [return: NullAllowed]
        string LicenseExpirationDateForLicense([NullAllowed] string licenseKey, [NullAllowed] out NSError error);

        // +(NSBundle * _Nonnull)frameworkBundle;
        [Static]
        [Export("frameworkBundle")]

        NSBundle FrameworkBundle { get; }

        // -(void)enableReporting:(BOOL)enable;
        [Export("enableReporting:")]
        void EnableReporting(bool enable);

        // -(void)reportIncludeValues:(NSString * _Nonnull)values;
        [Export("reportIncludeValues:")]
        void ReportIncludeValues(string values);

        // -(NSArray * _Nonnull)runStatistics;
        [Export("runStatistics")]
        NSObject[] RunStatistics { get; }
    }

    // @protocol ALCoreControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IALCoreControllerDelegate
    {
        // @required -(void)anylineCoreController:(ALCoreController * _Nonnull)coreController didFinishWithOutput:(id _Nonnull)object;
        [Abstract]
        [Export("anylineCoreController:didFinishWithOutput:")]
        void DidFinishWithOutput(ALCoreController coreController, NSObject @object);

        // @optional -(void)anylineCoreController:(ALCoreController * _Nonnull)coreController didAbortRun:(NSError * _Nonnull)reason;
        [Export("anylineCoreController:didAbortRun:")]
        void DidAbortRun(ALCoreController coreController, NSError reason);

        // @optional -(void)anylineCoreController:(ALCoreController * _Nonnull)coreController reportsVariable:(NSString * _Nonnull)variableName value:(id _Nonnull)value;
        [Export("anylineCoreController:reportsVariable:value:")]
        void ReportsVariable(ALCoreController coreController, string variableName, NSObject value);

        // @optional -(void)anylineCoreController:(ALCoreController * _Nonnull)coreController parserError:(NSError * _Nonnull)error;
        [Export("anylineCoreController:parserError:")]
        void ParserError(ALCoreController coreController, NSError error);
    }

    // @interface ALTorchManager : NSObject <ALFlashButtonStatusDelegate>
    [BaseType(typeof(NSObject))]
    interface ALTorchManager : IALFlashButtonStatusDelegate
    {
        // @property (nonatomic, weak) AVCaptureDevice * _Nullable captureDevice;
        [NullAllowed, Export("captureDevice", ArgumentSemantic.Weak)]
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

        // -(BOOL)setTorchModeOnWithLevel:(float)torchLevel error:(NSError * _Nullable * _Nullable)error;
        [Export("setTorchModeOnWithLevel:error:")]
        bool SetTorchModeOnWithLevel(float torchLevel, [NullAllowed] out NSError error);

        // -(instancetype _Nullable)initWithCaptureDevice:(AVCaptureDevice * _Nullable)captureDevice;
        [Export("initWithCaptureDevice:")]
        IntPtr Constructor([NullAllowed] AVCaptureDevice captureDevice);
    }

    // @protocol ALMotionDetectorDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALMotionDetectorDelegate
    {
        // @required -(void)motionDetectorAboveThreshold;
        [Abstract]
        [Export("motionDetectorAboveThreshold")]
        void MotionDetectorAboveThreshold();
    }

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
    }

    // audit-objc-generics: @interface ALScanResult<__covariant ObjectType> : NSObject
    [BaseType(typeof(NSObject))]
    interface ALScanResult
    {
        // @property (readonly, nonatomic, strong) NSString * _Nonnull pluginID;
        [Export("pluginID", ArgumentSemantic.Strong)]
        string PluginID { get; }

        // @property (readonly, nonatomic, strong) ObjectType _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        NSObject Result { get; }

        // @property (readonly, nonatomic, strong) UIImage * _Nonnull image;
        [Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; }

        // @property (nonatomic, strong) UIImage * _Nullable fullImage;
        [NullAllowed, Export("fullImage", ArgumentSemantic.Strong)]
        UIImage FullImage { get; set; }

        // @property (readonly, assign, nonatomic) NSInteger confidence;
        [Export("confidence")]
        nint Confidence { get; }

        // @property (nonatomic, strong) ALSquare * _Nullable outline __attribute__((deprecated("Deprecated since 3.18.0 You can get the outline as a property from the ScanViewPlugin.")));
        [NullAllowed, Export("outline", ArgumentSemantic.Strong)]
        ALSquare Outline { get; set; }

        // -(instancetype _Nullable)initWithResult:(ObjectType _Nonnull)result image:(UIImage * _Nonnull)image fullImage:(UIImage * _Nullable)fullImage confidence:(NSInteger)confidence pluginID:(NSString * _Nonnull)pluginID;
        [Export("initWithResult:image:fullImage:confidence:pluginID:")]
        IntPtr Constructor(NSObject result, UIImage image, [NullAllowed] UIImage fullImage, nint confidence, string pluginID);
    }

    [Static]
    partial interface Constants
    {
        // extern NSString *const _Nonnull kBrightnessVariableName;
        [Field("kBrightnessVariableName", "__Internal")]
        NSString kBrightnessVariableName { get; }

        // extern NSString *const _Nonnull kOutlineVariableName;
        [Field("kOutlineVariableName", "__Internal")]
        NSString kOutlineVariableName { get; }

        // extern NSString *const _Nonnull kDeviceAccelerationVariableName;
        [Field("kDeviceAccelerationVariableName", "__Internal")]
        NSString kDeviceAccelerationVariableName { get; }

        // extern NSString *const _Nonnull kThresholdedImageVariableName;
        [Field("kThresholdedImageVariableName", "__Internal")]
        NSString kThresholdedImageVariableName { get; }

        // extern NSString *const _Nonnull kContoursVariableName;
        [Field("kContoursVariableName", "__Internal")]
        NSString kContoursVariableName { get; }

        // extern NSString *const _Nonnull kSquareVariableName;
        [Field("kSquareVariableName", "__Internal")]
        NSString kSquareVariableName { get; }

        // extern NSString *const _Nonnull kPolygonVariableName;
        [Field("kPolygonVariableName", "__Internal")]
        NSString kPolygonVariableName { get; }

        // extern NSString *const _Nonnull kSharpnessVariableName;
        [Field("kSharpnessVariableName", "__Internal")]
        NSString kSharpnessVariableName { get; }

        // extern NSString *const _Nonnull kShakeDetectionWarningVariableName;
        [Field("kShakeDetectionWarningVariableName", "__Internal")]
        NSString kShakeDetectionWarningVariableName { get; }
    }

    // @interface ALScanInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface ALScanInfo
    {
        // @property (readonly, nonatomic, strong) NSString * _Nonnull pluginID;
        [Export("pluginID", ArgumentSemantic.Strong)]
        string PluginID { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull variableName;
        [Export("variableName", ArgumentSemantic.Strong)]
        string VariableName { get; }

        // @property (readonly, nonatomic, strong) id _Nonnull value;
        [Export("value", ArgumentSemantic.Strong)]
        NSObject Value { get; }

        // -(instancetype _Nullable)initWithVariableName:(NSString * _Nonnull)variableName value:(id _Nonnull)value pluginID:(NSString * _Nonnull)pluginID;
        [Export("initWithVariableName:value:pluginID:")]
        IntPtr Constructor(string variableName, NSObject value, string pluginID);
    }

    // @interface ALRunSkippedReason : NSObject
    [BaseType(typeof(NSObject))]
    interface ALRunSkippedReason
    {
        // @property (readonly, nonatomic, strong) NSString * _Nonnull pluginID;
        [Export("pluginID", ArgumentSemantic.Strong)]
        string PluginID { get; }

        // @property (assign, nonatomic) ALRunFailure reason;
        [Export("reason", ArgumentSemantic.Assign)]
        ALRunFailure Reason { get; set; }

        // -(instancetype _Nullable)initWithRunFailure:(ALRunFailure)reason pluginID:(NSString * _Nonnull)pluginID;
        [Export("initWithRunFailure:pluginID:")]
        IntPtr Constructor(ALRunFailure reason, string pluginID);
    }

    // @interface ALCaptureDeviceManager : NSObject
    [BaseType(typeof(NSObject))]
    interface ALCaptureDeviceManager
    {
        // -(instancetype _Nullable)initWithCameraConfig:(ALCameraConfig * _Nonnull)cameraConfig;
        [Export("initWithCameraConfig:")]
        IntPtr Constructor(ALCameraConfig cameraConfig);

        // @property (readonly, nonatomic, strong) NSHashTable<AnylineNativeBarcodeDelegate> * _Nullable barcodeDelegates;
        [NullAllowed, Export("barcodeDelegates", ArgumentSemantic.Strong)]
        NSSet BarcodeDelegates { get; }

        // @property (readonly, nonatomic, strong) NSHashTable<AnylineVideoDataSampleBufferDelegate> * _Nullable sampleBufferDelegates;
        [NullAllowed, Export("sampleBufferDelegates", ArgumentSemantic.Strong)]
        NSSet SampleBufferDelegates { get; }

        // @property (nonatomic, strong) ALCameraConfig * _Nullable cameraConfig;
        [NullAllowed, Export("cameraConfig", ArgumentSemantic.Strong)]
        ALCameraConfig CameraConfig { get; set; }

        // @property (nonatomic, strong) AVCaptureVideoPreviewLayer * _Nullable previewLayer;
        [NullAllowed, Export("previewLayer", ArgumentSemantic.Strong)]
        AVCaptureVideoPreviewLayer PreviewLayer { get; set; }

        // @property (nonatomic, strong) AVCaptureDevice * _Nullable captureDevice;
        [NullAllowed, Export("captureDevice", ArgumentSemantic.Strong)]
        AVCaptureDevice CaptureDevice { get; set; }

        // @property (nonatomic, strong) AVCaptureSession * _Nullable session;
        [NullAllowed, Export("session", ArgumentSemantic.Strong)]
        AVCaptureSession Session { get; set; }

        // @property (assign, nonatomic) CGSize videoResolution;
        [Export("videoResolution", ArgumentSemantic.Assign)]
        CGSize VideoResolution { get; set; }

        // -(void)addBarcodeDelegate:(id<AnylineNativeBarcodeDelegate> _Nonnull)delegate __attribute__((deprecated("Deprecated since 4. Use method addBarcodeDelegate:error: instead.")));
        [Export("addBarcodeDelegate:")]
        void AddBarcodeDelegate(NSObject @delegate);

        // -(BOOL)addBarcodeDelegate:(id<AnylineNativeBarcodeDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Export("addBarcodeDelegate:error:")]
        bool AddBarcodeDelegate(NSObject @delegate, [NullAllowed] out NSError error);

        // -(void)removeBarcodeDelegate:(id<AnylineNativeBarcodeDelegate> _Nonnull)delegate;
        [Export("removeBarcodeDelegate:")]
        void RemoveBarcodeDelegate(NSObject @delegate);

        // -(void)addSampleBufferDelegate:(id<AnylineVideoDataSampleBufferDelegate> _Nonnull)delegate;
        [Export("addSampleBufferDelegate:")]
        void AddSampleBufferDelegate(NSObject @delegate);

        // -(void)removeSampleBufferDelegate:(id<AnylineVideoDataSampleBufferDelegate> _Nonnull)delegate;
        [Export("removeSampleBufferDelegate:")]
        void RemoveSampleBufferDelegate(NSObject @delegate);

        // -(void)addVideoLayerOnView:(UIView * _Nonnull)view;
        [Export("addVideoLayerOnView:")]
        void AddVideoLayerOnView(UIView view);

        // -(void)updateVideoLayer:(UIView * _Nonnull)view;
        [Export("updateVideoLayer:")]
        void UpdateVideoLayer(UIView view);

        // -(void)setFocusAndExposurePoint:(CGPoint)point;
        [Export("setFocusAndExposurePoint:")]
        void SetFocusAndExposurePoint(CGPoint point);

        // -(void)setZoomLevel:(CGFloat)zoomFactor;
        [Export("setZoomLevel:")]
        void SetZoomLevel(nfloat zoomFactor);

        // -(void)startSession;
        [Export("startSession")]
        void StartSession();

        // -(void)stopSession;
        [Export("stopSession")]
        void StopSession();

        // -(BOOL)isRunning;
        [Export("isRunning")]

        bool IsRunning { get; }

        // -(CGPoint)fullResolutionPointForPointInPreview:(CGPoint)inPoint;
        [Export("fullResolutionPointForPointInPreview:")]
        CGPoint FullResolutionPointForPointInPreview(CGPoint inPoint);

        // -(UIInterfaceOrientation)currentInterfaceOrientation;
        [Export("currentInterfaceOrientation")]

        UIInterfaceOrientation CurrentInterfaceOrientation { get; }

        // -(AVCaptureConnection * _Nullable)getOrientationAdaptedCaptureConnection;
        [NullAllowed, Export("getOrientationAdaptedCaptureConnection")]

        AVCaptureConnection OrientationAdaptedCaptureConnection { get; }

        // +(AVAuthorizationStatus)cameraPermissionStatus;
        [Static]
        [Export("cameraPermissionStatus")]

        AVAuthorizationStatus CameraPermissionStatus { get; }

        // +(void)requestCameraPermission:(void (^ _Nonnull)(BOOL))handler;
        [Static]
        [Export("requestCameraPermission:")]
        void RequestCameraPermission(Action<bool> handler);

        // -(void)captureStillImageAsynchronouslyWithCompletionHandler:(void (^ _Nonnull)(CMSampleBufferRef _Nullable, NSError * _Nullable))handler;
        //[Export("captureStillImageAsynchronouslyWithCompletionHandler:")]
        //unsafe void CaptureStillImageAsynchronouslyWithCompletionHandler(Action<CoreMedia.CMSampleBufferRef*, NSError> handler);
    }

    // @protocol AnylineVideoDataSampleBufferDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IAnylineVideoDataSampleBufferDelegate
    {
        // @required -(void)anylineCaptureDeviceManager:(ALCaptureDeviceManager * _Nonnull)captureDeviceManager didOutputSampleBuffer:(CMSampleBufferRef _Nonnull)sampleBuffer;
        //[Abstract]
        //[Export("anylineCaptureDeviceManager:didOutputSampleBuffer:")]
        //unsafe void DidOutputSampleBuffer(ALCaptureDeviceManager captureDeviceManager, CMSampleBufferRef* sampleBuffer);
    }

    // @protocol AnylineNativeBarcodeDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineNativeBarcodeDelegate
    {
        // @required -(void)anylineCaptureDeviceManager:(ALCaptureDeviceManager * _Nonnull)captureDeviceManager didFindBarcodeResult:(NSString * _Nonnull)scanResult type:(NSString * _Nonnull)barcodeType;
        [Abstract]
        [Export("anylineCaptureDeviceManager:didFindBarcodeResult:type:")]
        void DidFindBarcodeResult(ALCaptureDeviceManager captureDeviceManager, string scanResult, string barcodeType);
    }

    // @interface ALAbstractScanPlugin : NSObject <ALCoreControllerDelegate>
    [BaseType(typeof(NSObject))]
    interface ALAbstractScanPlugin : IALCoreControllerDelegate
    {
        // @property (readonly, nonatomic, strong) NSHashTable<ALInfoDelegate> * _Nullable infoDelegates;
        [NullAllowed, Export("infoDelegates", ArgumentSemantic.Strong)]
        NSSet InfoDelegates { get; }

        // @property (nonatomic, strong) NSString * _Nullable pluginID;
        [NullAllowed, Export("pluginID", ArgumentSemantic.Strong)]
        string PluginID { get; set; }

        // @property (assign, nonatomic) id<ALImageProvider> _Nullable imageProvider;
        [NullAllowed, Export("imageProvider", ArgumentSemantic.Assign)]
        IALImageProvider ImageProvider { get; set; }

        // -(BOOL)start:(id<ALImageProvider> _Nonnull)imageProvider error:(NSError * _Nullable * _Nullable)error;
        [Export("start:error:")]
        bool Start(IALImageProvider imageProvider, [NullAllowed] out NSError error);

        // -(BOOL)stopAndReturnError:(NSError * _Nullable * _Nullable)error;
        [Export("stopAndReturnError:")]
        bool StopAndReturnError([NullAllowed] out NSError error);

        // -(void)enableReporting:(BOOL)enable;
        [Export("enableReporting:")]
        void EnableReporting(bool enable);

        // -(BOOL)isRunning;
        [Export("isRunning")]

        bool IsRunning { get; }

        // -(void)addInfoDelegate:(id<ALInfoDelegate> _Nonnull)infoDelegate;
        [Export("addInfoDelegate:")]
        void AddInfoDelegate(IALInfoDelegate infoDelegate);

        // -(void)removeInfoDelegate:(id<ALInfoDelegate> _Nonnull)infoDelegate;
        [Export("removeInfoDelegate:")]
        void RemoveInfoDelegate(IALInfoDelegate infoDelegate);

        // @property (assign, nonatomic) NSInteger confidence;
        [Export("confidence")]
        nint Confidence { get; set; }

        // @property (readonly, nonatomic, strong) ALImage * _Nullable scanImage;
        [NullAllowed, Export("scanImage", ArgumentSemantic.Strong)]
        ALImage ScanImage { get; }

        // @property (nonatomic, strong) ALCoreController * _Nullable coreController;
        [NullAllowed, Export("coreController", ArgumentSemantic.Strong)]
        ALCoreController CoreController { get; set; }
    }

    // @protocol ALInfoDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IALInfoDelegate
    {
        // @optional -(void)anylineScanPlugin:(ALAbstractScanPlugin * _Nonnull)anylineScanPlugin reportInfo:(ALScanInfo * _Nonnull)info;
        [Export("anylineScanPlugin:reportInfo:")]
        void ReportInfo(ALAbstractScanPlugin anylineScanPlugin, ALScanInfo info);

        // @optional -(void)anylineScanPlugin:(ALAbstractScanPlugin * _Nonnull)anylineScanPlugin runSkipped:(ALRunSkippedReason * _Nonnull)runSkippedReason;
        [Export("anylineScanPlugin:runSkipped:")]
        void RunSkipped(ALAbstractScanPlugin anylineScanPlugin, ALRunSkippedReason runSkippedReason);
    }

    // @interface ALSampleBufferImageProvider : NSObject <ALImageProvider, AnylineVideoDataSampleBufferDelegate>
    [BaseType(typeof(NSObject))]
    interface ALSampleBufferImageProvider : IALImageProvider, IAnylineVideoDataSampleBufferDelegate
    {
        // @property (assign, atomic) CGRect cutoutFrame;
        [Export("cutoutFrame", ArgumentSemantic.Assign)]
        CGRect CutoutFrame { get; set; }

        // @property (assign, nonatomic) CGSize cameraFrame;
        [Export("cameraFrame", ArgumentSemantic.Assign)]
        CGSize CameraFrame { get; set; }

        // @property (assign, nonatomic) CGRect cutoutScreen;
        [Export("cutoutScreen", ArgumentSemantic.Assign)]
        CGRect CutoutScreen { get; set; }

        // @property (assign, nonatomic) CGSize cutoutPadding;
        [Export("cutoutPadding", ArgumentSemantic.Assign)]
        CGSize CutoutPadding { get; set; }

        // @property (assign, nonatomic) CGPoint cutoutOffset;
        [Export("cutoutOffset", ArgumentSemantic.Assign)]
        CGPoint CutoutOffset { get; set; }

        // -(instancetype _Nullable)initWithCutoutScreen:(CGRect)cutoutScreen cutoutPadding:(CGSize)cutoutPadding cutoutOffset:(CGPoint)cutoutOffset;
        [Export("initWithCutoutScreen:cutoutPadding:cutoutOffset:")]
        IntPtr Constructor(CGRect cutoutScreen, CGSize cutoutPadding, CGPoint cutoutOffset);

        // -(CGPoint)convertPoint:(CGPoint)inPoint previewLayer:(AVCaptureVideoPreviewLayer * _Nonnull)previewLayer;
        [Export("convertPoint:previewLayer:")]
        CGPoint ConvertPoint(CGPoint inPoint, AVCaptureVideoPreviewLayer previewLayer);

        // -(CGPoint)convertPoint:(CGPoint)inPoint previewLayer:(AVCaptureVideoPreviewLayer * _Nonnull)previewLayer imageWidth:(CGFloat)inWidth;
        [Export("convertPoint:previewLayer:imageWidth:")]
        CGPoint ConvertPoint(CGPoint inPoint, AVCaptureVideoPreviewLayer previewLayer, nfloat inWidth);

        // -(void)updateCutoutScreen:(CGRect)rect;
        [Export("updateCutoutScreen:")]
        void UpdateCutoutScreen(CGRect rect);
    }

    // @interface ALAbstractScanViewPlugin : UIView <ALInfoDelegate>
    [BaseType(typeof(UIView))]
    interface ALAbstractScanViewPlugin : IALInfoDelegate
    {
        // @property (nonatomic, strong) ALSampleBufferImageProvider * _Nullable sampleBufferImageProvider;
        [NullAllowed, Export("sampleBufferImageProvider", ArgumentSemantic.Strong)]
        ALSampleBufferImageProvider SampleBufferImageProvider { get; set; }

        // @property (nonatomic, weak) ALScanView * _Nullable scanView;
        [NullAllowed, Export("scanView", ArgumentSemantic.Weak)]
        ALScanView ScanView { get; set; }

        // @property (assign, nonatomic) CGRect cutoutRect;
        [Export("cutoutRect", ArgumentSemantic.Assign)]
        CGRect CutoutRect { get; set; }

        // @property (copy, nonatomic) ALScanViewPluginConfig * _Nullable scanViewPluginConfig;
        [NullAllowed, Export("scanViewPluginConfig", ArgumentSemantic.Copy)]
        ALScanViewPluginConfig ScanViewPluginConfig { get; set; }

        // +(instancetype _Nullable)scanViewPluginForConfigDict:(NSDictionary * _Nonnull)configDict licenseKey:(NSString * _Nonnull)licenseKey delegate:(id _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("scanViewPluginForConfigDict:licenseKey:delegate:error:")]
        [return: NullAllowed]
        ALAbstractScanViewPlugin ScanViewPluginForConfigDict(NSDictionary configDict, string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // -(BOOL)startAndReturnError:(NSError * _Nullable * _Nullable)error;
        [Export("startAndReturnError:")]
        bool StartAndReturnError([NullAllowed] out NSError error);

        // -(BOOL)stopAndReturnError:(NSError * _Nullable * _Nullable)error;
        [Export("stopAndReturnError:")]
        bool StopAndReturnError([NullAllowed] out NSError error);

        // @property (nonatomic, strong) ALSquare * _Nullable outline;
        [NullAllowed, Export("outline", ArgumentSemantic.Strong)]
        ALSquare Outline { get; set; }

        // @property (nonatomic, strong) ALImage * _Nullable scanImage;
        [NullAllowed, Export("scanImage", ArgumentSemantic.Strong)]
        ALImage ScanImage { get; set; }

        // @property (assign, nonatomic) CGFloat scale;
        [Export("scale")]
        nfloat Scale { get; set; }

        // -(void)customInit;
        [Export("customInit")]
        void CustomInit();

        // -(void)stopListeningForMotion;
        [Export("stopListeningForMotion")]
        void StopListeningForMotion();

        // -(void)triggerScannedFeedback;
        [Export("triggerScannedFeedback")]
        void TriggerScannedFeedback();

        // -(NSArray * _Nonnull)convertContours:(ALContours * _Nonnull)contoursValue;
        [Export("convertContours:")]

        NSObject[] ConvertContours(ALContours contoursValue);

        // -(ALSquare * _Nonnull)convertCGRect:(NSValue * _Nonnull)concreteValue;
        [Export("convertCGRect:")]
        ALSquare ConvertCGRect(NSValue concreteValue);

        // -(void)updateCutoutRect:(CGRect)rect;
        [Export("updateCutoutRect:")]
        void UpdateCutoutRect(CGRect rect);
    }

    // @interface ALPolygon : NSObject
    [BaseType(typeof(NSObject))]
    interface ALPolygon
    {
        // @property (readonly, nonatomic, strong) NSArray * points;
        [Export("points", ArgumentSemantic.Strong)]

        NSObject[] Points { get; }

        // -(instancetype)initWithPoints:(NSArray *)points;
        [Export("initWithPoints:")]

        IntPtr Constructor(NSObject[] points);

        // -(ALPolygon *)polygonWithScale:(CGFloat)scale;
        [Export("polygonWithScale:")]
        ALPolygon PolygonWithScale(nfloat scale);
    }

    // @interface ALVisualFeedbackOverlay : UIView
    [BaseType(typeof(UIView))]
    interface ALVisualFeedbackOverlay
    {
        // @property (copy, nonatomic) ALPolygon * _Nullable polygon;
        [NullAllowed, Export("polygon", ArgumentSemantic.Copy)]
        ALPolygon Polygon { get; set; }

        // @property (copy, nonatomic) ALSquare * _Nullable square;
        [NullAllowed, Export("square", ArgumentSemantic.Copy)]
        ALSquare Square { get; set; }

        // @property (copy, nonatomic) NSArray * _Nullable contours;
        [NullAllowed, Export("contours", ArgumentSemantic.Copy)]

        NSObject[] Contours { get; set; }

        // @property (assign, nonatomic) NSInteger visualFeedbackCornerRadius;
        [Export("visualFeedbackCornerRadius")]
        nint VisualFeedbackCornerRadius { get; set; }

        // @property (assign, nonatomic) NSInteger visualFeedbackRedrawTimeout;
        [Export("visualFeedbackRedrawTimeout")]
        nint VisualFeedbackRedrawTimeout { get; set; }

        // @property (assign, nonatomic) ALUIFeedbackStyle feedbackStyle;
        [Export("feedbackStyle", ArgumentSemantic.Assign)]
        ALUIFeedbackStyle FeedbackStyle { get; set; }

        // @property (assign, nonatomic) ALUIVisualFeedbackAnimation visualFeedbackAnimation;
        [Export("visualFeedbackAnimation", ArgumentSemantic.Assign)]
        ALUIVisualFeedbackAnimation VisualFeedbackAnimation { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable visualFeedbackStrokeColor;
        [NullAllowed, Export("visualFeedbackStrokeColor", ArgumentSemantic.Strong)]
        UIColor VisualFeedbackStrokeColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable visualFeedbackFillColor;
        [NullAllowed, Export("visualFeedbackFillColor", ArgumentSemantic.Strong)]
        UIColor VisualFeedbackFillColor { get; set; }

        // @property (assign, nonatomic) NSInteger visualFeedbackAnimationDuration;
        [Export("visualFeedbackAnimationDuration")]
        nint VisualFeedbackAnimationDuration { get; set; }

        // @property (copy, nonatomic) UIBezierPath * _Nullable cutoutPath;
        [NullAllowed, Export("cutoutPath", ArgumentSemantic.Copy)]
        UIBezierPath CutoutPath { get; set; }

        // @property (assign, nonatomic) NSInteger visualFeedbackStrokeWidth;
        [Export("visualFeedbackStrokeWidth")]
        nint VisualFeedbackStrokeWidth { get; set; }

        // -(instancetype _Nullable)initWithFrame:(CGRect)frame visualFeedbackCornerRadius:(NSInteger)visualFeedbackCornerRadius visualFeedbackRedrawTimeout:(NSInteger)visualFeedbackRedrawTimeout feedbackStyle:(ALUIFeedbackStyle)feedbackStyle visualFeedbackAnimation:(ALUIVisualFeedbackAnimation)visualFeedbackAnimation visualFeedbackStrokeColor:(UIColor * _Nonnull)visualFeedbackStrokeColor visualFeedbackFillColor:(UIColor * _Nonnull)visualFeedbackFillColor visualFeedbackAnimationDuration:(NSInteger)visualFeedbackAnimationDuration cutoutPath:(UIBezierPath * _Nonnull)cutoutPath visualFeedbackStrokeWidth:(NSInteger)visualFeedbackStrokeWidth;
        [Export("initWithFrame:visualFeedbackCornerRadius:visualFeedbackRedrawTimeout:feedbackStyle:visualFeedbackAnimation:visualFeedbackStrokeColor:visualFeedbackFillColor:visualFeedbackAnimationDuration:cutoutPath:visualFeedbackStrokeWidth:")]
        IntPtr Constructor(CGRect frame, nint visualFeedbackCornerRadius, nint visualFeedbackRedrawTimeout, ALUIFeedbackStyle feedbackStyle, ALUIVisualFeedbackAnimation visualFeedbackAnimation, UIColor visualFeedbackStrokeColor, UIColor visualFeedbackFillColor, nint visualFeedbackAnimationDuration, UIBezierPath cutoutPath, nint visualFeedbackStrokeWidth);

        // -(void)cancelFeedback;
        [Export("cancelFeedback")]
        void CancelFeedback();
    }

    // @interface ALUIFeedback : UIView
    [BaseType(typeof(UIView))]
    interface ALUIFeedback
    {
        // @property (nonatomic, strong) ALSquare * _Nonnull square;
        [Export("square", ArgumentSemantic.Strong)]
        ALSquare Square { get; set; }

        // @property (nonatomic, strong) ALPolygon * _Nonnull polygon;
        [Export("polygon", ArgumentSemantic.Strong)]
        ALPolygon Polygon { get; set; }

        // @property (nonatomic, strong) NSArray * _Nonnull contours;
        [Export("contours", ArgumentSemantic.Strong)]

        NSObject[] Contours { get; set; }

        // @property (readonly, nonatomic, strong) NSHashTable<ALCutoutDelegate> * _Nullable cutoutDelegates;
        [NullAllowed, Export("cutoutDelegates", ArgumentSemantic.Strong)]
        NSSet CutoutDelegates { get; }

        // -(instancetype _Nullable)initWithFrame:(CGRect)frame pluginConfig:(ALScanViewPluginConfig * _Nonnull)pluginConfig;
        [Export("initWithFrame:pluginConfig:")]
        IntPtr Constructor(CGRect frame, ALScanViewPluginConfig pluginConfig);

        // -(void)cancelFeedback;
        [Export("cancelFeedback")]
        void CancelFeedback();

        // -(void)changeVisualFeedbackStrokeColor:(UIColor * _Nonnull)color;
        [Export("changeVisualFeedbackStrokeColor:")]
        void ChangeVisualFeedbackStrokeColor(UIColor color);

        // -(void)updateConfiguration:(ALScanViewPluginConfig * _Nonnull)pluginConfig;
        [Export("updateConfiguration:")]
        void UpdateConfiguration(ALScanViewPluginConfig pluginConfig);

        // -(void)setVisualFeedbackStrokeColor:(UIColor * _Nonnull)color;
        [Export("setVisualFeedbackStrokeColor:")]
        void SetVisualFeedbackStrokeColor(UIColor color);

        // -(CGRect)cutout;
        [Export("cutout")]

        CGRect Cutout { get; }

        // -(void)addCutoutDelegate:(id<ALCutoutDelegate> _Nonnull)infoDelegate;
        [Export("addCutoutDelegate:")]
        void AddCutoutDelegate(ALCutoutDelegate infoDelegate);

        // -(void)removeCutoutDelegate:(id<ALCutoutDelegate> _Nonnull)infoDelegate;
        [Export("removeCutoutDelegate:")]
        void RemoveCutoutDelegate(ALCutoutDelegate infoDelegate);
    }

    // @protocol ALCutoutDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALCutoutDelegate
    {
        // @required -(void)alUIFeedback:(ALUIFeedback * _Nonnull)alUIFeedback updatedCutout:(CGRect)cutoutRect;
        [Abstract]
        [Export("alUIFeedback:updatedCutout:")]
        void UpdatedCutout(ALUIFeedback alUIFeedback, CGRect cutoutRect);
    }

    // @interface ALScanView : UIView
    [BaseType(typeof(UIView))]
    interface ALScanView
    {
        // @property (nonatomic, strong) ALUIFeedback * _Nullable uiOverlayView;
        [NullAllowed, Export("uiOverlayView", ArgumentSemantic.Strong)]
        ALUIFeedback UiOverlayView { get; set; }

        // @property (nonatomic, strong) ALCameraConfig * _Nullable cameraConfig;
        [NullAllowed, Export("cameraConfig", ArgumentSemantic.Strong)]
        ALCameraConfig CameraConfig { get; set; }

        // @property (nonatomic, strong) ALFlashButtonConfig * _Nullable flashButtonConfig;
        [NullAllowed, Export("flashButtonConfig", ArgumentSemantic.Strong)]
        ALFlashButtonConfig FlashButtonConfig { get; set; }

        // @property (nonatomic, strong) ALFlashButton * _Nullable flashButton;
        [NullAllowed, Export("flashButton", ArgumentSemantic.Strong)]
        ALFlashButton FlashButton { get; set; }

        // @property (nonatomic, strong) ALTorchManager * _Nullable torchManager;
        [NullAllowed, Export("torchManager", ArgumentSemantic.Strong)]
        ALTorchManager TorchManager { get; set; }

        // @property (nonatomic, strong) ALCaptureDeviceManager * _Nullable captureDeviceManager;
        [NullAllowed, Export("captureDeviceManager", ArgumentSemantic.Strong)]
        ALCaptureDeviceManager CaptureDeviceManager { get; set; }

        // setter private because not supported natively yet.

        // @property (nonatomic, strong) ALAbstractScanViewPlugin * _Nullable scanViewPlugin;
        [NullAllowed, Export("scanViewPlugin", ArgumentSemantic.Strong)]
        ALAbstractScanViewPlugin ScanViewPlugin { get; }

        // @property (readonly, nonatomic) CGRect watermarkRect;
        [Export("watermarkRect")]
        CGRect WatermarkRect { get; }

        // -(instancetype _Nullable)initWithFrame:(CGRect)frame scanViewPlugin:(ALAbstractScanViewPlugin * _Nullable)scanViewPlugin;
        [Export("initWithFrame:scanViewPlugin:")]
        IntPtr Constructor(CGRect frame, [NullAllowed] ALAbstractScanViewPlugin scanViewPlugin);

        // -(instancetype _Nullable)initWithFrame:(CGRect)frame scanViewPlugin:(ALAbstractScanViewPlugin * _Nullable)scanViewPlugin cameraConfig:(ALCameraConfig * _Nonnull)cameraConfig flashButtonConfig:(ALFlashButtonConfig * _Nonnull)flashButtonConfig;
        [Export("initWithFrame:scanViewPlugin:cameraConfig:flashButtonConfig:")]
        IntPtr Constructor(CGRect frame, [NullAllowed] ALAbstractScanViewPlugin scanViewPlugin, ALCameraConfig cameraConfig, ALFlashButtonConfig flashButtonConfig);

        // +(instancetype _Nullable)scanViewForFrame:(CGRect)frame configPath:(NSString * _Nonnull)configPath licenseKey:(NSString * _Nonnull)licenseKey delegate:(id _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("scanViewForFrame:configPath:licenseKey:delegate:error:")]
        [return: NullAllowed]
        ALScanView ScanViewForFrame(CGRect frame, string configPath, string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // +(instancetype _Nullable)scanViewForFrame:(CGRect)frame configDict:(NSDictionary * _Nonnull)configDict licenseKey:(NSString * _Nonnull)licenseKey delegate:(id _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("scanViewForFrame:configDict:licenseKey:delegate:error:")]
        [return: NullAllowed]
        ALScanView ScanViewForFrame(CGRect frame, NSDictionary configDict, string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // -(void)startCamera;
        [Export("startCamera")]
        void StartCamera();

        // -(void)stopCamera;
        [Export("stopCamera")]
        void StopCamera();

        // -(void)updateDispatchTimer;
        [Export("updateDispatchTimer")]
        void UpdateDispatchTimer();

        // -(void)updateTextRect:(ALSquare * _Nonnull)square;
        [Export("updateTextRect:")]
        void UpdateTextRect(ALSquare square);

        // -(void)updateCutoutView:(ALCutoutConfig * _Nonnull)cutoutConfig;
        [Export("updateCutoutView:")]
        void UpdateCutoutView(ALCutoutConfig cutoutConfig);

        // -(void)updateVisualFeedbackView:(ALScanFeedbackConfig * _Nonnull)scanFeedbackConfig;
        [Export("updateVisualFeedbackView:")]
        void UpdateVisualFeedbackView(ALScanFeedbackConfig scanFeedbackConfig);

        // -(void)updateWebView:(ALScanViewPluginConfig * _Nonnull)config;
        [Export("updateWebView:")]
        void UpdateWebView(ALScanViewPluginConfig config);
    }

    // @interface AnylineAbstractModuleView : UIView
    [BaseType(typeof(UIView))]
    interface AnylineAbstractModuleView
    {
        [Wrap("WeakDebugDelegate")]
        [NullAllowed]
        AnylineDebugDelegate DebugDelegate { get; set; }

        // @property (nonatomic, weak) id<AnylineDebugDelegate> _Nullable debugDelegate;
        [NullAllowed, Export("debugDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDebugDelegate { get; set; }

        // @property (nonatomic, strong) ALScanView * _Nullable cameraView;
        [NullAllowed, Export("cameraView", ArgumentSemantic.Strong)]
        ALScanView CameraView { get; set; }

        // @property (readonly, nonatomic, strong) ALCaptureDeviceManager * _Nullable captureDeviceManager;
        [NullAllowed, Export("captureDeviceManager", ArgumentSemantic.Strong)]
        ALCaptureDeviceManager CaptureDeviceManager { get; }

        // @property (nonatomic, strong) ALCutoutView * _Nullable cutoutView;
        [NullAllowed, Export("cutoutView", ArgumentSemantic.Strong)]
        ALCutoutView CutoutView { get; set; }

        // @property (nonatomic, strong) ALFlashButton * _Nullable flashButton;
        [NullAllowed, Export("flashButton", ArgumentSemantic.Strong)]
        ALFlashButton FlashButton { get; set; }

        // @property (nonatomic, strong) ALTorchManager * _Nullable torchManager;
        [NullAllowed, Export("torchManager", ArgumentSemantic.Strong)]
        ALTorchManager TorchManager { get; set; }

        // @property (copy, nonatomic) ALUIConfiguration * _Nullable currentConfiguration;
        [NullAllowed, Export("currentConfiguration", ArgumentSemantic.Copy)]
        ALUIConfiguration CurrentConfiguration { get; set; }

        // @property (nonatomic) NSInteger strokeWidth;
        [Export("strokeWidth")]
        nint StrokeWidth { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable strokeColor;
        [NullAllowed, Export("strokeColor", ArgumentSemantic.Strong)]
        UIColor StrokeColor { get; set; }

        // @property (nonatomic) NSInteger cornerRadius;
        [Export("cornerRadius")]
        nint CornerRadius { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable outerColor;
        [NullAllowed, Export("outerColor", ArgumentSemantic.Strong)]
        UIColor OuterColor { get; set; }

        // @property (nonatomic) CGFloat outerAlpha;
        [Export("outerAlpha")]
        nfloat OuterAlpha { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable flashImage;
        [NullAllowed, Export("flashImage", ArgumentSemantic.Strong)]
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

        // -(BOOL)startScanningAndReturnError:(NSError * _Nullable * _Nullable)error;
        [Export("startScanningAndReturnError:")]
        bool StartScanningAndReturnError([NullAllowed] out NSError error);

        // -(BOOL)cancelScanningAndReturnError:(NSError * _Nullable * _Nullable)error;
        [Export("cancelScanningAndReturnError:")]
        bool CancelScanningAndReturnError([NullAllowed] out NSError error);

        // -(void)enableReporting:(BOOL)enable;
        [Export("enableReporting:")]
        void EnableReporting(bool enable);

        // -(BOOL)isRunning;
        [Export("isRunning")]

        bool IsRunning { get; }

        // -(void)stopListeningForMotion;
        [Export("stopListeningForMotion")]
        void StopListeningForMotion();
    }

    // @protocol AnylineDebugDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineDebugDelegate
    {
        // @optional -(void)anylineModuleView:(AnylineAbstractModuleView * _Nonnull)anylineModuleView reportDebugVariable:(NSString * _Nonnull)variableName value:(id _Nonnull)value;
        [Export("anylineModuleView:reportDebugVariable:value:")]
        void ReportDebugVariable(AnylineAbstractModuleView anylineModuleView, string variableName, NSObject value);

        // @optional -(void)anylineModuleView:(AnylineAbstractModuleView * _Nonnull)anylineModuleView runSkipped:(ALRunFailure)runFailure;
        [Export("anylineModuleView:runSkipped:")]
        void RunSkipped(AnylineAbstractModuleView anylineModuleView, ALRunFailure runFailure);
    }

    // @interface ALMeterResult : ALScanResult
    [BaseType(typeof(ALScanResult))]
    interface ALMeterResult
    {
        // @property (readonly, assign, nonatomic) ALScanMode scanMode;
        [Export("scanMode", ArgumentSemantic.Assign)]
        ALScanMode ScanMode { get; }

        // -(instancetype _Nullable)initWithResult:(NSString * _Nonnull)result image:(UIImage * _Nonnull)image fullImage:(UIImage * _Nonnull)fullImage confidence:(NSInteger)confidence pluginID:(NSString * _Nonnull)pluginID scanMode:(ALScanMode)scanMode;
        [Export("initWithResult:image:fullImage:confidence:pluginID:scanMode:")]
        IntPtr Constructor(string result, UIImage image, UIImage fullImage, nint confidence, string pluginID, ALScanMode scanMode);
    }

    // @interface ALEnergyResult : ALMeterResult
    [BaseType(typeof(ALMeterResult))]
    interface ALEnergyResult
    {
    }

    // @interface ALMeterScanPlugin : ALAbstractScanPlugin
    [BaseType(typeof(ALAbstractScanPlugin))]
    [DisableDefaultCtor]
    interface ALMeterScanPlugin
    {
        // -(instancetype _Nullable)initWithPluginID:(NSString * _Nullable)pluginID licenseKey:(NSString * _Nonnull)licenseKey delegate:(id<ALMeterScanPluginDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Export("initWithPluginID:licenseKey:delegate:error:")]
        IntPtr Constructor([NullAllowed] string pluginID, string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // @property (readonly, nonatomic, strong) NSHashTable<ALMeterScanPluginDelegate> * _Nullable delegates;
        [NullAllowed, Export("delegates", ArgumentSemantic.Strong)]
        NSSet Delegates { get; }

        // @property (readonly, assign, nonatomic) ALScanMode scanMode;
        [Export("scanMode", ArgumentSemantic.Assign)]
        ALScanMode ScanMode { get; }

        // @property (nonatomic, strong) NSString * _Nullable serialNumberValidationRegex;
        [NullAllowed, Export("serialNumberValidationRegex", ArgumentSemantic.Strong)]
        string SerialNumberValidationRegex { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable serialNumberCharWhitelist;
        [NullAllowed, Export("serialNumberCharWhitelist", ArgumentSemantic.Strong)]
        string SerialNumberCharWhitelist { get; set; }

        // -(BOOL)setScanMode:(ALScanMode)scanMode error:(NSError * _Nullable * _Nullable)error;
        [Export("setScanMode:error:")]
        bool SetScanMode(ALScanMode scanMode, [NullAllowed] out NSError error);

        // -(void)addDelegate:(id<ALMeterScanPluginDelegate> _Nonnull)delegate;
        [Export("addDelegate:")]
        void AddDelegate(NSObject @delegate);

        // -(void)removeDelegate:(id<ALMeterScanPluginDelegate> _Nonnull)delegate;
        [Export("removeDelegate:")]
        void RemoveDelegate(NSObject @delegate);

        // -(ALScanMode)parseScanModeString:(NSString * _Nonnull)scanMode;
        [Export("parseScanModeString:")]
        ALScanMode ParseScanModeString(string scanMode);
    }

    // @protocol ALMeterScanPluginDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALMeterScanPluginDelegate
    {
        // @required -(void)anylineMeterScanPlugin:(ALMeterScanPlugin * _Nonnull)anylineMeterScanPlugin didFindResult:(ALMeterResult * _Nonnull)scanResult;
        [Abstract]
        [Export("anylineMeterScanPlugin:didFindResult:")]
        void DidFindResult(ALMeterScanPlugin anylineMeterScanPlugin, ALMeterResult scanResult);
    }

    partial interface Constants
    {
        // extern NSString *const _Nonnull kCodeTypeAztec;
        [Field("kCodeTypeAztec", "__Internal")]
        NSString kCodeTypeAztec { get; }

        // extern NSString *const _Nonnull kCodeTypeCodabar;
        [Field("kCodeTypeCodabar", "__Internal")]
        NSString kCodeTypeCodabar { get; }

        // extern NSString *const _Nonnull kCodeTypeCode39;
        [Field("kCodeTypeCode39", "__Internal")]
        NSString kCodeTypeCode39 { get; }

        // extern NSString *const _Nonnull kCodeTypeCode93;
        [Field("kCodeTypeCode93", "__Internal")]
        NSString kCodeTypeCode93 { get; }

        // extern NSString *const _Nonnull kCodeTypeCode128;
        [Field("kCodeTypeCode128", "__Internal")]
        NSString kCodeTypeCode128 { get; }

        // extern NSString *const _Nonnull kCodeTypeDataMatrix;
        [Field("kCodeTypeDataMatrix", "__Internal")]
        NSString kCodeTypeDataMatrix { get; }

        // extern NSString *const _Nonnull kCodeTypeEAN8;
        [Field("kCodeTypeEAN8", "__Internal")]
        NSString kCodeTypeEAN8 { get; }

        // extern NSString *const _Nonnull kCodeTypeEAN13;
        [Field("kCodeTypeEAN13", "__Internal")]
        NSString kCodeTypeEAN13 { get; }

        // extern NSString *const _Nonnull kCodeTypeITF;
        [Field("kCodeTypeITF", "__Internal")]
        NSString kCodeTypeITF { get; }

        // extern NSString *const _Nonnull kCodeTypePDF417;
        [Field("kCodeTypePDF417", "__Internal")]
        NSString kCodeTypePDF417 { get; }

        // extern NSString *const _Nonnull kCodeTypeQR;
        [Field("kCodeTypeQR", "__Internal")]
        NSString kCodeTypeQR { get; }

        // extern NSString *const _Nonnull kCodeTypeRSS14;
        [Field("kCodeTypeRSS14", "__Internal")]
        NSString kCodeTypeRSS14 { get; }

        // extern NSString *const _Nonnull kCodeTypeRSSExpanded;
        [Field("kCodeTypeRSSExpanded", "__Internal")]
        NSString kCodeTypeRSSExpanded { get; }

        // extern NSString *const _Nonnull kCodeTypeUPCA;
        [Field("kCodeTypeUPCA", "__Internal")]
        NSString kCodeTypeUPCA { get; }

        // extern NSString *const _Nonnull kCodeTypeUPCE;
        [Field("kCodeTypeUPCE", "__Internal")]
        NSString kCodeTypeUPCE { get; }

        // extern NSString *const _Nonnull kCodeTypeUPCEANExtension;
        [Field("kCodeTypeUPCEANExtension", "__Internal")]
        NSString kCodeTypeUPCEANExtension { get; }
    }

    // @interface ALBarcodeResult : ALScanResult
    [BaseType(typeof(ALScanResult))]
    interface ALBarcodeResult
    {
        // @property (readonly, assign, nonatomic) ALBarcodeFormat barcodeFormat;
        [Export("barcodeFormat", ArgumentSemantic.Assign)]
        ALBarcodeFormat BarcodeFormat { get; }

        // -(instancetype _Nullable)initWithResult:(NSString * _Nonnull)result image:(UIImage * _Nonnull)image fullImage:(UIImage * _Nullable)fullImage confidence:(NSInteger)confidence pluginID:(NSString * _Nonnull)pluginID barcodeFormat:(ALBarcodeFormat)barcodeFormat;
        [Export("initWithResult:image:fullImage:confidence:pluginID:barcodeFormat:")]
        IntPtr Constructor(string result, UIImage image, [NullAllowed] UIImage fullImage, nint confidence, string pluginID, ALBarcodeFormat barcodeFormat);
    }

    // @interface ALBarcodeScanPlugin : ALAbstractScanPlugin
    [BaseType(typeof(ALAbstractScanPlugin))]
    [DisableDefaultCtor]
    interface ALBarcodeScanPlugin
    {
        // -(instancetype _Nullable)initWithPluginID:(NSString * _Nullable)pluginID licenseKey:(NSString * _Nonnull)licenseKey delegate:(id<ALBarcodeScanPluginDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Export("initWithPluginID:licenseKey:delegate:error:")]
        IntPtr Constructor([NullAllowed] string pluginID, string licenseKey, ALBarcodeScanPluginDelegate @delegate, [NullAllowed] out NSError error);

        // @property (readonly, nonatomic, strong) NSHashTable<ALBarcodeScanPluginDelegate> * _Nullable delegates;
        [NullAllowed, Export("delegates", ArgumentSemantic.Strong)]
        NSSet Delegates { get; }

        // @property (assign, nonatomic) ALBarcodeFormatOptions barcodeFormatOptions;
        [Export("barcodeFormatOptions", ArgumentSemantic.Assign)]
        ALBarcodeFormat BarcodeFormatOptions { get; set; }

        // -(ALBarcodeFormat)barcodeFormatForString:(NSString * _Nullable)barcodeFormatString;
        [Export("barcodeFormatForString:")]
        ALBarcodeFormat BarcodeFormatForString([NullAllowed] string barcodeFormatString);

        // -(void)addDelegate:(id<ALBarcodeScanPluginDelegate> _Nonnull)delegate;
        [Export("addDelegate:")]
        void AddDelegate(NSObject @delegate);

        // -(void)removeDelegate:(id<ALBarcodeScanPluginDelegate> _Nonnull)delegate;
        [Export("removeDelegate:")]
        void RemoveDelegate(NSObject @delegate);
    }

    // @protocol ALBarcodeScanPluginDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALBarcodeScanPluginDelegate
    {
        // @required -(void)anylineBarcodeScanPlugin:(ALBarcodeScanPlugin * _Nonnull)anylineBarcodeScanPlugin didFindResult:(ALBarcodeResult * _Nonnull)scanResult;
        [Abstract]
        [Export("anylineBarcodeScanPlugin:didFindResult:")]
        void DidFindResult(ALBarcodeScanPlugin anylineBarcodeScanPlugin, ALBarcodeResult scanResult);
    }

    // @interface ALMeterScanViewPlugin : ALAbstractScanViewPlugin
    [BaseType(typeof(ALAbstractScanViewPlugin))]
    interface ALMeterScanViewPlugin
    {
        // @property (nonatomic, strong) ALMeterScanPlugin * _Nullable meterScanPlugin;
        [NullAllowed, Export("meterScanPlugin", ArgumentSemantic.Strong)]
        ALMeterScanPlugin MeterScanPlugin { get; set; }

        // -(instancetype _Nullable)initWithScanPlugin:(ALMeterScanPlugin * _Nonnull)meterScanPlugin;
        [Export("initWithScanPlugin:")]
        IntPtr Constructor(ALMeterScanPlugin meterScanPlugin);

        // -(instancetype _Nullable)initWithScanPlugin:(ALMeterScanPlugin * _Nonnull)meterScanPlugin scanViewPluginConfig:(ALScanViewPluginConfig * _Nonnull)scanViewPluginConfig;
        [Export("initWithScanPlugin:scanViewPluginConfig:")]
        IntPtr Constructor(ALMeterScanPlugin meterScanPlugin, ALScanViewPluginConfig scanViewPluginConfig);
    }

    // @interface AnylineEnergyModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineEnergyModuleView
    {
        // @property (nonatomic, strong) ALMeterScanViewPlugin * _Nullable meterScanViewPlugin;
        [NullAllowed, Export("meterScanViewPlugin", ArgumentSemantic.Strong)]
        ALMeterScanViewPlugin MeterScanViewPlugin { get; set; }

        // @property (nonatomic, strong) ALMeterScanPlugin * _Nullable meterScanPlugin;
        [NullAllowed, Export("meterScanPlugin", ArgumentSemantic.Strong)]
        ALMeterScanPlugin MeterScanPlugin { get; set; }

        // @property (nonatomic, strong) ALBarcodeScanPlugin * _Nullable barcodeScanPlugin;
        [NullAllowed, Export("barcodeScanPlugin", ArgumentSemantic.Strong)]
        ALBarcodeScanPlugin BarcodeScanPlugin { get; set; }

        // @property (readonly, assign, nonatomic) ALScanMode scanMode;
        [Export("scanMode", ArgumentSemantic.Assign)]
        ALScanMode ScanMode { get; }

        // @property (nonatomic, strong) NSString * _Nullable serialNumberValidationRegex;
        [NullAllowed, Export("serialNumberValidationRegex", ArgumentSemantic.Strong)]
        string SerialNumberValidationRegex { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable serialNumberCharWhitelist;
        [NullAllowed, Export("serialNumberCharWhitelist", ArgumentSemantic.Strong)]
        string SerialNumberCharWhitelist { get; set; }

        // -(BOOL)setScanMode:(ALScanMode)scanMode error:(NSError * _Nullable * _Nullable)error;
        [Export("setScanMode:error:")]
        bool SetScanMode(ALScanMode scanMode, [NullAllowed] out NSError error);

        // -(BOOL)setupWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<AnylineEnergyModuleDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // -(void)setupAsyncWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<AnylineEnergyModuleDelegate> _Nonnull)delegate finished:(void (^ _Nonnull)(BOOL, NSError * _Nullable))finished;
        [Export("setupAsyncWithLicenseKey:delegate:finished:")]
        void SetupAsyncWithLicenseKey(string licenseKey, NSObject @delegate, Action<bool, NSError> finished);
    }

    // @protocol AnylineEnergyModuleDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineEnergyModuleDelegate
    {
        // @required -(void)anylineEnergyModuleView:(AnylineEnergyModuleView * _Nonnull)anylineEnergyModuleView didFindResult:(ALEnergyResult * _Nonnull)scanResult;
        [Abstract]
        [Export("anylineEnergyModuleView:didFindResult:")]
        void DidFindResult(AnylineEnergyModuleView anylineEnergyModuleView, ALEnergyResult scanResult);

        // @optional -(void)anylineEnergyModuleView:(AnylineEnergyModuleView * _Nonnull)anylineEnergyModuleView didFindScanResult:(NSString * _Nonnull)scanResult cropImage:(UIImage * _Nonnull)image fullImage:(UIImage * _Nonnull)fullImage inMode:(ALScanMode)scanMode __attribute__((deprecated("Deprecated since 3.10 Use AnylineDebugDelegate instead.")));
        [Export("anylineEnergyModuleView:didFindScanResult:cropImage:fullImage:inMode:")]
        void DidFindScanResult(AnylineEnergyModuleView anylineEnergyModuleView, string scanResult, UIImage image, UIImage fullImage, ALScanMode scanMode);
    }

    // @interface ALBarcodeScanViewPlugin : ALAbstractScanViewPlugin
    [BaseType(typeof(ALAbstractScanViewPlugin))]
    interface ALBarcodeScanViewPlugin
    {
        // @property (nonatomic, strong) ALBarcodeScanPlugin * _Nullable barcodeScanPlugin;
        [NullAllowed, Export("barcodeScanPlugin", ArgumentSemantic.Strong)]
        ALBarcodeScanPlugin BarcodeScanPlugin { get; set; }

        // -(instancetype _Nullable)initWithScanPlugin:(ALBarcodeScanPlugin * _Nonnull)barcodeScanPlugin;
        [Export("initWithScanPlugin:")]
        IntPtr Constructor(ALBarcodeScanPlugin barcodeScanPlugin);

        // -(instancetype _Nullable)initWithScanPlugin:(ALBarcodeScanPlugin * _Nonnull)barcodeScanPlugin scanViewPluginConfig:(ALScanViewPluginConfig * _Nonnull)scanViewPluginConfig;
        [Export("initWithScanPlugin:scanViewPluginConfig:")]
        IntPtr Constructor(ALBarcodeScanPlugin barcodeScanPlugin, ALScanViewPluginConfig scanViewPluginConfig);

        // @property (assign, nonatomic) BOOL useOnlyNativeBarcodeScanning;
        [Export("useOnlyNativeBarcodeScanning")]
        bool UseOnlyNativeBarcodeScanning { get; set; }
    }

    // @interface AnylineBarcodeModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineBarcodeModuleView
    {
        // @property (nonatomic, strong) ALBarcodeScanPlugin * _Nullable barcodeScanPlugin;
        [NullAllowed, Export("barcodeScanPlugin", ArgumentSemantic.Strong)]
        ALBarcodeScanPlugin BarcodeScanPlugin { get; set; }

        // @property (nonatomic, strong) ALBarcodeScanViewPlugin * _Nullable barcodeScanViewPlugin;
        [NullAllowed, Export("barcodeScanViewPlugin", ArgumentSemantic.Strong)]
        ALBarcodeScanViewPlugin BarcodeScanViewPlugin { get; set; }

        // @property (assign, nonatomic) ALBarcodeFormatOptions barcodeFormatOptions;
        [Export("barcodeFormatOptions", ArgumentSemantic.Assign)]
        ALBarcodeFormat BarcodeFormatOptions { get; set; }

        // @property (assign, nonatomic) BOOL useOnlyNativeBarcodeScanning;
        [Export("useOnlyNativeBarcodeScanning")]
        bool UseOnlyNativeBarcodeScanning { get; set; }

        // -(BOOL)setupWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<AnylineBarcodeModuleDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // -(void)setupAsyncWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<AnylineBarcodeModuleDelegate> _Nonnull)delegate finished:(void (^ _Nonnull)(BOOL, NSError * _Nullable))finished;
        [Export("setupAsyncWithLicenseKey:delegate:finished:")]
        void SetupAsyncWithLicenseKey(string licenseKey, NSObject @delegate, Action<bool, NSError> finished);
    }

    // @protocol AnylineBarcodeModuleDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineBarcodeModuleDelegate
    {
        // @required -(void)anylineBarcodeModuleView:(AnylineBarcodeModuleView * _Nonnull)anylineBarcodeModuleView didFindResult:(ALBarcodeResult * _Nonnull)scanResult;
        [Abstract]
        [Export("anylineBarcodeModuleView:didFindResult:")]
        void DidFindResult(AnylineBarcodeModuleView anylineBarcodeModuleView, ALBarcodeResult scanResult);
    }

    // @interface ALDrivingLicenseIdentification : NSObject
    [BaseType(typeof(NSObject))]
    interface ALDrivingLicenseIdentification
    {
        // @property (readonly, nonatomic, strong) NSString * _Nonnull documentNumber;
        [Export("documentNumber", ArgumentSemantic.Strong)]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull surNames;
        [Export("surNames", ArgumentSemantic.Strong)]
        string SurNames { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull givenNames;
        [Export("givenNames", ArgumentSemantic.Strong)]
        string GivenNames { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull dayOfBirth;
        [Export("dayOfBirth", ArgumentSemantic.Strong)]
        string DayOfBirth { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull placeOfBirth;
        [Export("placeOfBirth", ArgumentSemantic.Strong)]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull issuingDate;
        [Export("issuingDate", ArgumentSemantic.Strong)]
        string IssuingDate { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull expirationDate;
        [Export("expirationDate", ArgumentSemantic.Strong)]
        string ExpirationDate { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull authority;
        [Export("authority", ArgumentSemantic.Strong)]
        string Authority { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull categories;
        [Export("categories", ArgumentSemantic.Strong)]
        string Categories { get; }

        // @property (readonly, nonatomic, strong) NSDate * _Nullable dayOfBirthDateObject;
        [NullAllowed, Export("dayOfBirthDateObject", ArgumentSemantic.Strong)]
        NSDate DayOfBirthDateObject { get; }

        // @property (readonly, nonatomic, strong) NSDate * _Nullable issuingDateObject;
        [NullAllowed, Export("issuingDateObject", ArgumentSemantic.Strong)]
        NSDate IssuingDateObject { get; }

        // @property (readonly, nonatomic, strong) NSDate * _Nullable expirationDateObject;
        [NullAllowed, Export("expirationDateObject", ArgumentSemantic.Strong)]
        NSDate ExpirationDateObject { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull drivingLicenseString;
        [Export("drivingLicenseString", ArgumentSemantic.Strong)]
        string DrivingLicenseString { get; }

        // @property (nonatomic, strong) UIImage * _Nullable faceImage;
        [NullAllowed, Export("faceImage", ArgumentSemantic.Strong)]
        UIImage FaceImage { get; set; }

        // -(instancetype _Nullable)initWithDocumentNumber:(NSString * _Nonnull)documentNumber surNames:(NSString * _Nonnull)surNames givenNames:(NSString * _Nonnull)givenNames dayOfBirth:(NSString * _Nonnull)dayOfBirth placeOfBirth:(NSString * _Nonnull)placeOfBirth issuingDate:(NSString * _Nonnull)issuingDate expirationDate:(NSString * _Nonnull)expirationDate authority:(NSString * _Nonnull)authority categories:(NSString * _Nonnull)categories drivingLicenseString:(NSString * _Nonnull)drivingLicenseString;
        [Export("initWithDocumentNumber:surNames:givenNames:dayOfBirth:placeOfBirth:issuingDate:expirationDate:authority:categories:drivingLicenseString:")]
        IntPtr Constructor(string documentNumber, string surNames, string givenNames, string dayOfBirth, string placeOfBirth, string issuingDate, string expirationDate, string authority, string categories, string drivingLicenseString);

        // -(instancetype _Nullable)initWithDrivingLicenseString:(NSString * _Nonnull)drivingLicenseString;
        [Export("initWithDrivingLicenseString:")]
        IntPtr Constructor(string drivingLicenseString);
    }

    // @interface ALMRZIdentification : NSObject
    [BaseType(typeof(NSObject))]
    interface ALMRZIdentification
    {
        // @property (readonly, nonatomic, strong) NSString * _Nonnull documentType;
        [Export("documentType", ArgumentSemantic.Strong)]
        string DocumentType { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull documentNumber;
        [Export("documentNumber", ArgumentSemantic.Strong)]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull surNames;
        [Export("surNames", ArgumentSemantic.Strong)]
        string SurNames { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull givenNames;
        [Export("givenNames", ArgumentSemantic.Strong)]
        string GivenNames { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull issuingCountryCode;
        [Export("issuingCountryCode", ArgumentSemantic.Strong)]
        string IssuingCountryCode { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull nationalityCountryCode;
        [Export("nationalityCountryCode", ArgumentSemantic.Strong)]
        string NationalityCountryCode { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull dayOfBirth;
        [Export("dayOfBirth", ArgumentSemantic.Strong)]
        string DayOfBirth { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull expirationDate;
        [Export("expirationDate", ArgumentSemantic.Strong)]
        string ExpirationDate { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull sex;
        [Export("sex", ArgumentSemantic.Strong)]
        string Sex { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull checkdigitNumber;
        [Export("checkdigitNumber", ArgumentSemantic.Strong)]
        string CheckdigitNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull checkdigitExpirationDate;
        [Export("checkdigitExpirationDate", ArgumentSemantic.Strong)]
        string CheckdigitExpirationDate { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull checkdigitDayOfBirth;
        [Export("checkdigitDayOfBirth", ArgumentSemantic.Strong)]
        string CheckdigitDayOfBirth { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull checkdigitFinal;
        [Export("checkdigitFinal", ArgumentSemantic.Strong)]
        string CheckdigitFinal { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull personalNumber;
        [Export("personalNumber", ArgumentSemantic.Strong)]
        string PersonalNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull checkDigitPersonalNumber;
        [Export("checkDigitPersonalNumber", ArgumentSemantic.Strong)]
        string CheckDigitPersonalNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull personalNumber2;
        [Export("personalNumber2", ArgumentSemantic.Strong)]
        string PersonalNumber2 { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable address;
        [NullAllowed, Export("address", ArgumentSemantic.Strong)]
        string Address { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable issuingDate;
        [NullAllowed, Export("issuingDate", ArgumentSemantic.Strong)]
        string IssuingDate { get; }

        // @property (readonly, nonatomic, strong) NSDate * _Nullable issuingDateObject;
        [NullAllowed, Export("issuingDateObject", ArgumentSemantic.Strong)]
        NSDate IssuingDateObject { get; }

        // @property (readonly, nonatomic, strong) NSDate * _Nullable expirationDateObject;
        [NullAllowed, Export("expirationDateObject", ArgumentSemantic.Strong)]
        NSDate ExpirationDateObject { get; }

        // @property (readonly, nonatomic, strong) NSDate * _Nullable dayOfBirthDateObject;
        [NullAllowed, Export("dayOfBirthDateObject", ArgumentSemantic.Strong)]
        NSDate DayOfBirthDateObject { get; }
        
        // changed MRZ to Mrz in 6.0 because of a customer request

        // @property (readonly, nonatomic, strong) NSString * _Nonnull MRZString;
        [Export("MRZString", ArgumentSemantic.Strong)]
        string MrzString { get; }

        // @property (nonatomic, strong) UIImage * _Nullable faceImage;
        [NullAllowed, Export("faceImage", ArgumentSemantic.Strong)]
        UIImage FaceImage { get; set; }

        // -(instancetype _Nullable)initWithDocumentType:(NSString * _Nonnull)documentType issuingCountryCode:(NSString * _Nonnull)issuingCountryCode nationalityCountryCode:(NSString * _Nonnull)nationalityCountryCode surNames:(NSString * _Nonnull)surNames givenNames:(NSString * _Nonnull)givenNames documentNumber:(NSString * _Nonnull)documentNumber checkDigitNumber:(NSString * _Nonnull)checkDigitNumber dayOfBirth:(NSString * _Nonnull)dayOfBirth checkDigitDayOfBirth:(NSString * _Nonnull)checkDigitDayOfBirth sex:(NSString * _Nonnull)sex expirationDate:(NSString * _Nonnull)expirationDate checkDigitExpirationDate:(NSString * _Nonnull)checkdigitExpirationDate personalNumber:(NSString * _Nonnull)personalNumber checkDigitPersonalNumber:(NSString * _Nonnull)checkDigitPersonalNumber checkDigitFinal:(NSString * _Nonnull)checkDigitFinal personalNumber2:(NSString * _Nonnull)personalNumber2 address:(NSString * _Nullable)address issuingDate:(NSString * _Nullable)issuingDate MRZString:(NSString * _Nonnull)MRZString;
        [Export("initWithDocumentType:issuingCountryCode:nationalityCountryCode:surNames:givenNames:documentNumber:checkDigitNumber:dayOfBirth:checkDigitDayOfBirth:sex:expirationDate:checkDigitExpirationDate:personalNumber:checkDigitPersonalNumber:checkDigitFinal:personalNumber2:address:issuingDate:MRZString:")]
        IntPtr Constructor(string documentType, string issuingCountryCode, string nationalityCountryCode, string surNames, string givenNames, string documentNumber, string checkDigitNumber, string dayOfBirth, string checkDigitDayOfBirth, string sex, string expirationDate, string checkdigitExpirationDate, string personalNumber, string checkDigitPersonalNumber, string checkDigitFinal, string personalNumber2, [NullAllowed] string address, [NullAllowed] string issuingDate, string MRZString);
    }

    // @interface ALGermanIDFrontIdentification : NSObject
    [BaseType(typeof(NSObject))]
    interface ALGermanIDFrontIdentification
    {
        // @property (readonly, nonatomic, strong) NSString * _Nonnull documentNumber;
        [Export("documentNumber", ArgumentSemantic.Strong)]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull surNames;
        [Export("surNames", ArgumentSemantic.Strong)]
        string SurNames { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull givenNames;
        [Export("givenNames", ArgumentSemantic.Strong)]
        string GivenNames { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull dayOfBirth;
        [Export("dayOfBirth", ArgumentSemantic.Strong)]
        string DayOfBirth { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull placeOfBirth;
        [Export("placeOfBirth", ArgumentSemantic.Strong)]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull nationality;
        [Export("nationality", ArgumentSemantic.Strong)]
        string Nationality { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull cardAccessNumber;
        [Export("cardAccessNumber", ArgumentSemantic.Strong)]
        string CardAccessNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull expirationDate;
        [Export("expirationDate", ArgumentSemantic.Strong)]
        string ExpirationDate { get; }

        // @property (readonly, nonatomic, strong) NSDate * _Nullable dayOfBirthDateObject;
        [NullAllowed, Export("dayOfBirthDateObject", ArgumentSemantic.Strong)]
        NSDate DayOfBirthDateObject { get; }

        // @property (readonly, nonatomic, strong) NSDate * _Nullable expirationDateObject;
        [NullAllowed, Export("expirationDateObject", ArgumentSemantic.Strong)]
        NSDate ExpirationDateObject { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull germanIdFrontString;
        [Export("germanIdFrontString", ArgumentSemantic.Strong)]
        string GermanIdFrontString { get; }

        // @property (nonatomic, strong) UIImage * _Nullable faceImage;
        [NullAllowed, Export("faceImage", ArgumentSemantic.Strong)]
        UIImage FaceImage { get; set; }

        // -(instancetype _Nullable)initWithDocumentNumber:(NSString * _Nonnull)documentNumber surNames:(NSString * _Nonnull)surNames givenNames:(NSString * _Nonnull)givenNames dayOfBirth:(NSString * _Nonnull)dayOfBirth placeOfBirth:(NSString * _Nonnull)placeOfBirth nationality:(NSString * _Nonnull)nationality cardAccessNumber:(NSString * _Nonnull)cardAccessNumber expirationDate:(NSString * _Nonnull)expirationDate germanIdFrontString:(NSString * _Nonnull)germanIdFrontString;
        [Export("initWithDocumentNumber:surNames:givenNames:dayOfBirth:placeOfBirth:nationality:cardAccessNumber:expirationDate:germanIdFrontString:")]
        IntPtr Constructor(string documentNumber, string surNames, string givenNames, string dayOfBirth, string placeOfBirth, string nationality, string cardAccessNumber, string expirationDate, string germanIdFrontString);
    }

    // audit-objc-generics: @interface ALIDResult<__covariant ObjectType> : ALScanResult
    [BaseType(typeof(ALScanResult))]
    interface ALIDResult
    {
        // @property (readonly, assign, nonatomic) BOOL allCheckDigitsValid;
        [Export("allCheckDigitsValid")]
        bool AllCheckDigitsValid { get; }

        // -(instancetype _Nullable)initWithResult:(ObjectType _Nonnull)result image:(UIImage * _Nonnull)image fullImage:(UIImage * _Nullable)fullImage confidence:(NSInteger)confidence pluginID:(NSString * _Nonnull)pluginID allCheckDigitsValid:(BOOL)allCheckDigitsValid;
        [Export("initWithResult:image:fullImage:confidence:pluginID:allCheckDigitsValid:")]
        IntPtr Constructor(NSObject result, UIImage image, [NullAllowed] UIImage fullImage, nint confidence, string pluginID, bool allCheckDigitsValid);
    }

    // @interface ALIDConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface ALIDConfig
    {
        // -(instancetype _Nullable)initWithJsonDictionary:(NSDictionary * _Nonnull)configDict;
        [Export("initWithJsonDictionary:")]
        IntPtr Constructor(NSDictionary configDict);
    }

    // @interface ALMRZConfig : ALIDConfig
    [BaseType(typeof(ALIDConfig))]
    interface ALMRZConfig
    {
        // @property (nonatomic) BOOL strictMode;
        [Export("strictMode")]
        bool StrictMode { get; set; }

        // @property (nonatomic) BOOL cropAndTransformID;
        [Export("cropAndTransformID")]
        bool CropAndTransformID { get; set; }
    }

    // @interface ALDrivingLicenseConfig : ALIDConfig
    [BaseType(typeof(ALIDConfig))]
    interface ALDrivingLicenseConfig
    {
        // @property (assign, nonatomic) ALDrivingLicenseScanMode scanMode;
        [Export("scanMode", ArgumentSemantic.Assign)]
        ALDrivingLicenseScanMode ScanMode { get; set; }
    }

    // @interface ALGermanIDFrontConfig : ALIDConfig
    [BaseType(typeof(ALIDConfig))]
    interface ALGermanIDFrontConfig
    {
    }

    // @interface ALIDScanPlugin : ALAbstractScanPlugin
    [BaseType(typeof(ALAbstractScanPlugin))]
    [DisableDefaultCtor]
    interface ALIDScanPlugin
    {
        // -(instancetype _Nullable)initWithPluginID:(NSString * _Nullable)pluginID licenseKey:(NSString * _Nonnull)licenseKey delegate:(id<ALIDPluginDelegate> _Nonnull)delegate idConfig:(ALIDConfig * _Nonnull)config error:(NSError * _Nullable * _Nullable)error;
        [Export("initWithPluginID:licenseKey:delegate:idConfig:error:")]
        IntPtr Constructor([NullAllowed] string pluginID, string licenseKey, NSObject @delegate, ALIDConfig config, [NullAllowed] out NSError error);

        // @property (readonly, nonatomic, strong) NSHashTable<ALIDPluginDelegate> * _Nullable delegates;
        [NullAllowed, Export("delegates", ArgumentSemantic.Strong)]
        NSSet Delegates { get; }

        // -(void)addDelegate:(id<ALIDPluginDelegate> _Nonnull)delegate;
        [Export("addDelegate:")]
        void AddDelegate(NSObject @delegate);

        // -(void)removeDelegate:(id<ALIDPluginDelegate> _Nonnull)delegate;
        [Export("removeDelegate:")]
        void RemoveDelegate(NSObject @delegate);

        // @property (readonly, nonatomic, strong) ALIDConfig * _Nullable idConfig;
        [NullAllowed, Export("idConfig", ArgumentSemantic.Strong)]
        ALIDConfig IdConfig { get; }

        // -(BOOL)setIDConfig:(ALIDConfig * _Nonnull)idConfig error:(NSError * _Nullable * _Nullable)error;
        [Export("setIDConfig:error:")]
        bool SetIDConfig(ALIDConfig idConfig, [NullAllowed] out NSError error);
    }

    // @protocol ALIDPluginDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALIDPluginDelegate
    {
        // @required -(void)anylineIDScanPlugin:(ALIDScanPlugin * _Nonnull)anylineIDScanPlugin didFindResult:(ALIDResult * _Nonnull)scanResult;
        [Abstract]
        [Export("anylineIDScanPlugin:didFindResult:")]
        void DidFindResult(ALIDScanPlugin anylineIDScanPlugin, ALIDResult scanResult);
    }

    // @interface ALIDScanViewPlugin : ALAbstractScanViewPlugin
    [BaseType(typeof(ALAbstractScanViewPlugin))]
    interface ALIDScanViewPlugin
    {
        // @property (nonatomic, strong) ALIDScanPlugin * _Nullable idScanPlugin;
        [NullAllowed, Export("idScanPlugin", ArgumentSemantic.Strong)]
        ALIDScanPlugin IdScanPlugin { get; set; }

        // -(instancetype _Nullable)initWithScanPlugin:(ALIDScanPlugin * _Nonnull)idScanPlugin;
        [Export("initWithScanPlugin:")]
        IntPtr Constructor(ALIDScanPlugin idScanPlugin);

        // -(instancetype _Nullable)initWithScanPlugin:(ALIDScanPlugin * _Nonnull)idScanPlugin scanViewPluginConfig:(ALScanViewPluginConfig * _Nonnull)scanViewPluginConfig;
        [Export("initWithScanPlugin:scanViewPluginConfig:")]
        IntPtr Constructor(ALIDScanPlugin idScanPlugin, ALScanViewPluginConfig scanViewPluginConfig);
    }

    // @interface AnylineMRZModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineMRZModuleView
    {
        // @property (nonatomic, strong) ALIDScanViewPlugin * _Nullable mrzScanViewPlugin;
        [NullAllowed, Export("mrzScanViewPlugin", ArgumentSemantic.Strong)]
        ALIDScanViewPlugin MrzScanViewPlugin { get; set; }

        // @property (nonatomic, strong) ALIDScanPlugin * _Nullable mrzScanPlugin;
        [NullAllowed, Export("mrzScanPlugin", ArgumentSemantic.Strong)]
        ALIDScanPlugin MrzScanPlugin { get; set; }

        // @property (nonatomic) BOOL strictMode;
        [Export("strictMode")]
        bool StrictMode { get; set; }

        // @property (nonatomic) BOOL cropAndTransformID;
        [Export("cropAndTransformID")]
        bool CropAndTransformID { get; set; }

        // -(BOOL)setupWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<AnylineMRZModuleDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // -(void)setupAsyncWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<AnylineMRZModuleDelegate> _Nonnull)delegate finished:(void (^ _Nonnull)(BOOL, NSError * _Nullable))finished;
        [Export("setupAsyncWithLicenseKey:delegate:finished:")]
        void SetupAsyncWithLicenseKey(string licenseKey, NSObject @delegate, Action<bool, NSError> finished);
    }

    // @protocol AnylineMRZModuleDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineMRZModuleDelegate
    {
        // @optional -(void)anylineMRZModuleView:(AnylineMRZModuleView * _Nonnull)anylineMRZModuleView didFindScanResult:(ALIdentification * _Nonnull)scanResult allCheckDigitsValid:(BOOL)allCheckDigitsValid atImage:(UIImage * _Nonnull)image __attribute__((deprecated("Deprecated since 3.10. Use method anylineMRZModuleView:didFindScanResult: instead.")));
        [Export("anylineMRZModuleView:didFindScanResult:allCheckDigitsValid:atImage:")]
        void DidFindScanResult(AnylineMRZModuleView anylineMRZModuleView, ALMRZIdentification scanResult, bool allCheckDigitsValid, UIImage image);

        // @required -(void)anylineMRZModuleView:(AnylineMRZModuleView * _Nonnull)anylineMRZModuleView didFindResult:(ALMRZResult * _Nonnull)scanResult;
        [Abstract]
        [Export("anylineMRZModuleView:didFindResult:")]
        void DidFindResult(AnylineMRZModuleView anylineMRZModuleView, ALIDResult scanResult);
    }

    // @interface ALOCRResult : ALScanResult
    [BaseType(typeof(ALScanResult))]
    interface ALOCRResult
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable text __attribute__((deprecated("Deprecated since 3.10 Use result property instead.")));
        [NullAllowed, Export("text", ArgumentSemantic.Strong)]
        string Text { get; }

        // @property (readonly, nonatomic, strong) UIImage * _Nullable thresholdedImage;
        [NullAllowed, Export("thresholdedImage", ArgumentSemantic.Strong)]
        UIImage ThresholdedImage { get; }

        // -(instancetype _Nullable)initWithText:(NSString * _Nonnull)text image:(UIImage * _Nonnull)image thresholdedImage:(UIImage * _Nullable)thresholdedImage __attribute__((deprecated("Deprecated since 3.10 Use initWithResult:image:fullImage:confidence instead.")));
        [Export("initWithText:image:thresholdedImage:")]
        IntPtr Constructor(string text, UIImage image, [NullAllowed] UIImage thresholdedImage);

        // -(instancetype _Nullable)initWithResult:(NSString * _Nonnull)result image:(UIImage * _Nonnull)image fullImage:(UIImage * _Nullable)fullImage confidence:(NSInteger)confidence pluginID:(NSString * _Nonnull)pluginID thresholdedImage:(UIImage * _Nullable)thresholdedImage;
        [Export("initWithResult:image:fullImage:confidence:pluginID:thresholdedImage:")]
        IntPtr Constructor(string result, UIImage image, [NullAllowed] UIImage fullImage, nint confidence, string pluginID, [NullAllowed] UIImage thresholdedImage);
    }

    partial interface Constants
    {
        // extern NSString *const _Nonnull regexForEmail;
        [Field("regexForEmail", "__Internal")]
        NSString regexForEmail { get; }

        // extern NSString *const _Nonnull regexForURL;
        [Field("regexForURL", "__Internal")]
        NSString regexForURL { get; }

        // extern NSString *const _Nonnull regexForPriceTag;
        [Field("regexForPriceTag", "__Internal")]
        NSString regexForPriceTag { get; }

        // extern NSString *const _Nonnull regexForISBN;
        [Field("regexForISBN", "__Internal")]
        NSString regexForISBN { get; }

        // extern NSString *const _Nonnull regexForVIN;
        [Field("regexForVIN", "__Internal")]
        NSString regexForVIN { get; }

        // extern NSString *const _Nonnull regexForIMEI;
        [Field("regexForIMEI", "__Internal")]
        NSString regexForIMEI { get; }

        // extern NSString *const _Nonnull charWhiteListForEmail;
        [Field("charWhiteListForEmail", "__Internal")]
        NSString charWhiteListForEmail { get; }

        // extern NSString *const _Nonnull charWhiteListForURL;
        [Field("charWhiteListForURL", "__Internal")]
        NSString charWhiteListForURL { get; }

        // extern NSString *const _Nonnull charWhiteListForPriceTag;
        [Field("charWhiteListForPriceTag", "__Internal")]
        NSString charWhiteListForPriceTag { get; }

        // extern NSString *const _Nonnull charWhiteListForISBN;
        [Field("charWhiteListForISBN", "__Internal")]
        NSString charWhiteListForISBN { get; }

        // extern NSString *const _Nonnull charWhiteListForVIN;
        [Field("charWhiteListForVIN", "__Internal")]
        NSString charWhiteListForVIN { get; }

        // extern NSString *const _Nonnull charWhiteListForIMEI;
        [Field("charWhiteListForIMEI", "__Internal")]
        NSString charWhiteListForIMEI { get; }
    }

    // @interface ALOCRLanguage : NSObject
    [BaseType(typeof(NSObject))]
    interface ALOCRLanguage
    {
        // @property (nonatomic, strong) NSString * _Nullable path;
        [NullAllowed, Export("path", ArgumentSemantic.Strong)]
        string Path { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable md5;
        [NullAllowed, Export("md5", ArgumentSemantic.Strong)]
        string Md5 { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable filename;
        [NullAllowed, Export("filename", ArgumentSemantic.Strong)]
        string Filename { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable fileExtension;
        [NullAllowed, Export("fileExtension", ArgumentSemantic.Strong)]
        string FileExtension { get; set; }

        // -(instancetype _Nullable)initWithPath:(NSString * _Nonnull)path error:(NSError * _Nullable * _Nullable)error;
        [Export("initWithPath:error:")]
        IntPtr Constructor(string path, [NullAllowed] out NSError error);

        // +(BOOL)copyLanguage:(NSString * _Nonnull)path toPath:(NSString * _Nonnull)toPath fileHash:(NSString * _Nullable)hash error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("copyLanguage:toPath:fileHash:error:")]
        bool CopyLanguage(string path, string toPath, [NullAllowed] string hash, [NullAllowed] out NSError error);
    }

    // @interface ALOCRConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface ALOCRConfig
    {
        // -(instancetype _Nullable)initWithJsonDictionary:(NSDictionary * _Nonnull)configDict;
        [Export("initWithJsonDictionary:")]
        IntPtr Constructor(NSDictionary configDict);

        // -(instancetype _Nullable)initWithJsonDictionary:(NSDictionary * _Nonnull)configDict error:(NSError * _Nullable * _Nullable)error;
        [Export("initWithJsonDictionary:error:")]
        IntPtr Constructor(NSDictionary configDict, [NullAllowed] out NSError error);

        // @property (assign, nonatomic) ALOCRScanMode scanMode;
        [Export("scanMode", ArgumentSemantic.Assign)]
        ALOCRScanMode ScanMode { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable customCmdFilePath;
        [NullAllowed, Export("customCmdFilePath", ArgumentSemantic.Strong)]
        string CustomCmdFilePath { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable customCmdFileString;
        [NullAllowed, Export("customCmdFileString", ArgumentSemantic.Strong)]
        string CustomCmdFileString { get; set; }

        // @property (assign, nonatomic) ALRange charHeight;
        [Export("charHeight", ArgumentSemantic.Assign)]
        ALRange CharHeight { get; set; }

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable tesseractLanguages __attribute__((deprecated("Deprecated since 3.20. Use languages instead! This method still requires a copy of the traineddata.")));
        [NullAllowed, Export("tesseractLanguages", ArgumentSemantic.Strong)]
        string[] TesseractLanguages { get; set; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable languages;
        [NullAllowed, Export("languages", ArgumentSemantic.Copy)]
        string[] Languages { get; }

        // -(void)setLanguages:(NSArray<NSString *> * _Nonnull)languages __attribute__((deprecated("Deprecated since 4. Use languages - (BOOL)setLanguages:(NSArray<NSString *> *)languages error:(NSError *)error")));
        [Export("setLanguages:")]
        void SetLanguages(string[] languages);

        // -(BOOL)setLanguages:(NSArray<NSString *> * _Nonnull)languages error:(NSError * _Nullable * _Nullable)error;
        [Export("setLanguages:error:")]
        bool SetLanguages(string[] languages, [NullAllowed] out NSError error);

        // @property (nonatomic, strong) NSString * _Nullable charWhiteList;
        [NullAllowed, Export("charWhiteList", ArgumentSemantic.Strong)]
        string CharWhiteList { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable validationRegex;
        [NullAllowed, Export("validationRegex", ArgumentSemantic.Strong)]
        string ValidationRegex { get; set; }

        // @property (assign, nonatomic) NSUInteger minConfidence;
        [Export("minConfidence")]
        nuint MinConfidence { get; set; }

        // @property (assign, nonatomic) BOOL removeSmallContours;
        [Export("removeSmallContours")]
        bool RemoveSmallContours { get; set; }

        // @property (assign, nonatomic) BOOL removeWhitespaces;
        [Export("removeWhitespaces")]
        bool RemoveWhitespaces { get; set; }

        // @property (assign, nonatomic) NSUInteger minSharpness;
        [Export("minSharpness")]
        nuint MinSharpness { get; set; }

        // @property (assign, nonatomic) NSUInteger charCountX;
        [Export("charCountX")]
        nuint CharCountX { get; set; }

        // @property (assign, nonatomic) NSUInteger charCountY;
        [Export("charCountY")]
        nuint CharCountY { get; set; }

        // @property (assign, nonatomic) double charPaddingXFactor;
        [Export("charPaddingXFactor")]
        double CharPaddingXFactor { get; set; }

        // @property (assign, nonatomic) double charPaddingYFactor;
        [Export("charPaddingYFactor")]
        double CharPaddingYFactor { get; set; }

        // @property (assign, nonatomic) BOOL isBrightTextOnDark;
        [Export("isBrightTextOnDark")]
        bool IsBrightTextOnDark { get; set; }

        // -(NSDictionary * _Nullable)startVariablesOrError:(NSError * _Nullable * _Nullable)error;
        [Export("startVariablesOrError:")]
        [return: NullAllowed]
        NSDictionary StartVariablesOrError([NullAllowed] out NSError error);

        // -(NSString * _Nullable)toJsonString;
        [NullAllowed, Export("toJsonString")]

        string ToJsonString { get; }

        // -(BOOL)allLanguagesAnyFiles;
        [Export("allLanguagesAnyFiles")]

        bool AllLanguagesAnyFiles { get; }
    }

    // @interface ALOCRScanPlugin : ALAbstractScanPlugin
    [BaseType(typeof(ALAbstractScanPlugin))]
    [DisableDefaultCtor]
    interface ALOCRScanPlugin
    {
        // -(instancetype _Nullable)initWithPluginID:(NSString * _Nullable)pluginID licenseKey:(NSString * _Nonnull)licenseKey delegate:(id<ALOCRScanPluginDelegate> _Nonnull)delegate ocrConfig:(ALOCRConfig * _Nonnull)ocrConfig error:(NSError * _Nullable * _Nullable)error;
        [Export("initWithPluginID:licenseKey:delegate:ocrConfig:error:")]
        IntPtr Constructor([NullAllowed] string pluginID, string licenseKey, ALOCRScanPluginDelegate @delegate, ALOCRConfig ocrConfig, [NullAllowed] out NSError error);

        // @property (readonly, nonatomic, strong) NSHashTable<ALOCRScanPluginDelegate> * _Nullable delegates;
        [NullAllowed, Export("delegates", ArgumentSemantic.Strong)]
        NSSet Delegates { get; }

        // @property (readonly, nonatomic, strong) ALOCRConfig * _Nullable ocrConfig;
        [NullAllowed, Export("ocrConfig", ArgumentSemantic.Strong)]
        ALOCRConfig OcrConfig { get; }

        // -(BOOL)setOCRConfig:(ALOCRConfig * _Nonnull)ocrConfig error:(NSError * _Nullable * _Nullable)error;
        [Export("setOCRConfig:error:")]
        bool SetOCRConfig(ALOCRConfig ocrConfig, [NullAllowed] out NSError error);

        // -(BOOL)copyTrainedData:(NSString * _Nonnull)trainedDataPath fileHash:(NSString * _Nullable)hash error:(NSError * _Nullable * _Nullable)error __attribute__((deprecated("Deprecated since 3.20. Copy of traineddata's is not needed anymore with new languages property.")));
        [Export("copyTrainedData:fileHash:error:")]
        bool CopyTrainedData(string trainedDataPath, [NullAllowed] string hash, [NullAllowed] out NSError error);

        // -(void)addDelegate:(id<ALOCRScanPluginDelegate> _Nonnull)delegate;
        [Export("addDelegate:")]
        void AddDelegate(NSObject @delegate);

        // -(void)removeDelegate:(id<ALOCRScanPluginDelegate> _Nonnull)delegate;
        [Export("removeDelegate:")]
        void RemoveDelegate(NSObject @delegate);
    }

    // @protocol ALOCRScanPluginDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALOCRScanPluginDelegate
    {
        // @required -(void)anylineOCRScanPlugin:(ALOCRScanPlugin * _Nonnull)anylineOCRScanPlugin didFindResult:(ALOCRResult * _Nonnull)result;
        [Abstract]
        [Export("anylineOCRScanPlugin:didFindResult:")]
        void DidFindResult(ALOCRScanPlugin anylineOCRScanPlugin, ALOCRResult result);
    }

    // @interface ALOCRScanViewPlugin : ALAbstractScanViewPlugin
    [BaseType(typeof(ALAbstractScanViewPlugin))]
    interface ALOCRScanViewPlugin
    {
        // @property (nonatomic, strong) ALOCRScanPlugin * _Nullable ocrScanPlugin;
        [NullAllowed, Export("ocrScanPlugin", ArgumentSemantic.Strong)]
        ALOCRScanPlugin OcrScanPlugin { get; set; }

        // -(instancetype _Nullable)initWithScanPlugin:(ALOCRScanPlugin * _Nonnull)ocrScanPlugin;
        [Export("initWithScanPlugin:")]
        IntPtr Constructor(ALOCRScanPlugin ocrScanPlugin);

        // -(instancetype _Nullable)initWithScanPlugin:(ALOCRScanPlugin * _Nonnull)ocrScanPlugin scanViewPluginConfig:(ALScanViewPluginConfig * _Nonnull)scanViewPluginConfig;
        [Export("initWithScanPlugin:scanViewPluginConfig:")]
        IntPtr Constructor(ALOCRScanPlugin ocrScanPlugin, ALScanViewPluginConfig scanViewPluginConfig);
    }

    // @interface AnylineOCRModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineOCRModuleView
    {
        // @property (nonatomic, strong) ALOCRScanViewPlugin * _Nullable ocrScanViewPlugin;
        [NullAllowed, Export("ocrScanViewPlugin", ArgumentSemantic.Strong)]
        ALOCRScanViewPlugin OcrScanViewPlugin { get; set; }

        // @property (nonatomic, strong) ALOCRScanPlugin * _Nullable ocrScanPlugin;
        [NullAllowed, Export("ocrScanPlugin", ArgumentSemantic.Strong)]
        ALOCRScanPlugin OcrScanPlugin { get; set; }

        // @property (readonly, nonatomic, strong) ALOCRConfig * _Nullable ocrConfig;
        [NullAllowed, Export("ocrConfig", ArgumentSemantic.Strong)]
        ALOCRConfig OcrConfig { get; }

        // -(BOOL)setupWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<AnylineOCRModuleDelegate> _Nonnull)delegate ocrConfig:(ALOCRConfig * _Nonnull)ocrConfig error:(NSError * _Nullable * _Nullable)error;
        [Export("setupWithLicenseKey:delegate:ocrConfig:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, ALOCRConfig ocrConfig, [NullAllowed] out NSError error);

        // -(void)setupAsyncWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<AnylineOCRModuleDelegate> _Nonnull)delegate ocrConfig:(ALOCRConfig * _Nonnull)ocrConfig finished:(void (^ _Nonnull)(BOOL, NSError * _Nullable))finished;
        [Export("setupAsyncWithLicenseKey:delegate:ocrConfig:finished:")]
        void SetupAsyncWithLicenseKey(string licenseKey, NSObject @delegate, ALOCRConfig ocrConfig, Action<bool, NSError> finished);

        // -(BOOL)setOCRConfig:(ALOCRConfig * _Nonnull)ocrConfig error:(NSError * _Nullable * _Nullable)error;
        [Export("setOCRConfig:error:")]
        bool SetOCRConfig(ALOCRConfig ocrConfig, [NullAllowed] out NSError error);

        // -(BOOL)copyTrainedData:(NSString * _Nonnull)trainedDataPath fileHash:(NSString * _Nonnull)hash error:(NSError * _Nullable * _Nullable)error;
        [Export("copyTrainedData:fileHash:error:")]
        bool CopyTrainedData(string trainedDataPath, string hash, [NullAllowed] out NSError error);
    }

    // @protocol AnylineOCRModuleDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineOCRModuleDelegate
    {
        // @required -(void)anylineOCRModuleView:(AnylineOCRModuleView * _Nonnull)anylineOCRModuleView didFindResult:(ALOCRResult * _Nonnull)result;
        [Abstract]
        [Export("anylineOCRModuleView:didFindResult:")]
        void DidFindResult(AnylineOCRModuleView anylineOCRModuleView, ALOCRResult result);

        // @optional -(void)anylineOCRModuleView:(AnylineOCRModuleView * _Nonnull)anylineOCRModuleView reportsVariable:(NSString * _Nonnull)variableName value:(id _Nonnull)value __attribute__((deprecated("Deprecated since 3.10 Use AnylineDebugDelegate instead.")));
        [Export("anylineOCRModuleView:reportsVariable:value:")]
        [Abstract]
        void ReportsVariable(AnylineOCRModuleView anylineOCRModuleView, string variableName, NSObject value);

        // @optional -(void)anylineOCRModuleView:(AnylineOCRModuleView * _Nonnull)anylineOCRModuleView reportsRunFailure:(ALOCRError)error __attribute__((deprecated("Deprecated since 3.10 Use AnylineDebugDelegate instead.")));
        [Export("anylineOCRModuleView:reportsRunFailure:")]
        [Abstract]
        void ReportsRunFailure(AnylineOCRModuleView anylineOCRModuleView, ALOCRError error);

        // @optional -(BOOL)anylineOCRModuleView:(AnylineOCRModuleView * _Nonnull)anylineOCRModuleView textOutlineDetected:(ALSquare * _Nonnull)outline __attribute__((deprecated("Deprecated since 3.10 Use AnylineDebugDelegate instead.")));
        [Export("anylineOCRModuleView:textOutlineDetected:")]
        [Abstract]
        bool TextOutlineDetected(AnylineOCRModuleView anylineOCRModuleView, ALSquare outline);
    }

    partial interface Constants
    {
        // extern const CGFloat ALDocumentRatioDINAXLandscape;
        [Field("ALDocumentRatioDINAXLandscape", "__Internal")]
        nfloat ALDocumentRatioDINAXLandscape { get; }

        // extern const CGFloat ALDocumentRatioDINAXPortrait;
        [Field("ALDocumentRatioDINAXPortrait", "__Internal")]
        nfloat ALDocumentRatioDINAXPortrait { get; }

        // extern const CGFloat ALDocumentRatioCompimentsSlipLandscape;
        [Field("ALDocumentRatioCompimentsSlipLandscape", "__Internal")]
        nfloat ALDocumentRatioCompimentsSlipLandscape { get; }

        // extern const CGFloat ALDocumentRatioCompimentsSlipPortrait;
        [Field("ALDocumentRatioCompimentsSlipPortrait", "__Internal")]
        nfloat ALDocumentRatioCompimentsSlipPortrait { get; }

        // extern const CGFloat ALDocumentRatioBusinessCardLandscape;
        [Field("ALDocumentRatioBusinessCardLandscape", "__Internal")]
        nfloat ALDocumentRatioBusinessCardLandscape { get; }

        // extern const CGFloat ALDocumentRatioBusinessCardPortrait;
        [Field("ALDocumentRatioBusinessCardPortrait", "__Internal")]
        nfloat ALDocumentRatioBusinessCardPortrait { get; }

        // extern const CGFloat ALDocumentRatioLetterLandscape;
        [Field("ALDocumentRatioLetterLandscape", "__Internal")]
        nfloat ALDocumentRatioLetterLandscape { get; }

        // extern const CGFloat ALDocumentRatioLetterPortrait;
        [Field("ALDocumentRatioLetterPortrait", "__Internal")]
        nfloat ALDocumentRatioLetterPortrait { get; }
    }

    // @interface ALDocumentScanPlugin : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ALDocumentScanPlugin
    {
        // @property (readonly, nonatomic, strong) NSHashTable<ALDocumentScanPluginDelegate> * _Nullable delegates;
        [NullAllowed, Export("delegates", ArgumentSemantic.Strong)]
        NSSet Delegates { get; }

        // @property (readonly, nonatomic, strong) NSHashTable<ALDocumentInfoDelegate> * _Nullable infoDelegates;
        [NullAllowed, Export("infoDelegates", ArgumentSemantic.Strong)]
        NSSet InfoDelegates { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable pluginID;
        [NullAllowed, Export("pluginID", ArgumentSemantic.Strong)]
        string PluginID { get; }

        // @property (readonly, nonatomic, strong) ALImage * _Nullable scanImage;
        [NullAllowed, Export("scanImage", ArgumentSemantic.Strong)]
        ALImage ScanImage { get; }

        // @property (nonatomic, strong) ALCoreController * _Nullable coreController;
        [NullAllowed, Export("coreController", ArgumentSemantic.Strong)]
        ALCoreController CoreController { get; set; }

        // @property (assign, nonatomic) id<ALImageProvider> _Nullable imageProvider;
        [NullAllowed, Export("imageProvider", ArgumentSemantic.Assign)]
        IALImageProvider ImageProvider { get; set; }

        // @property (assign, atomic) BOOL justDetectCornersIfPossible;
        [Export("justDetectCornersIfPossible")]
        bool JustDetectCornersIfPossible { get; set; }

        // -(instancetype _Nullable)initWithPluginID:(NSString * _Nullable)pluginID licenseKey:(NSString * _Nonnull)licenseKey delegate:(id<ALDocumentScanPluginDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
        [Export("initWithPluginID:licenseKey:delegate:error:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string pluginID, string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // -(BOOL)start:(id<ALImageProvider> _Nonnull)imageProvider error:(NSError * _Nullable * _Nullable)error;
        [Export("start:error:")]
        bool Start(IALImageProvider imageProvider, [NullAllowed] out NSError error);

        // -(BOOL)stopAndReturnError:(NSError * _Nullable * _Nullable)error;
        [Export("stopAndReturnError:")]
        bool StopAndReturnError([NullAllowed] out NSError error);

        // -(void)enableReporting:(BOOL)enable;
        [Export("enableReporting:")]
        void EnableReporting(bool enable);

        // -(BOOL)isRunning;
        [Export("isRunning")]

        bool IsRunning { get; }

        // -(BOOL)triggerPictureCornerDetectionAndReturnError:(NSError * _Nullable * _Nullable)error;
        [Export("triggerPictureCornerDetectionAndReturnError:")]
        bool TriggerPictureCornerDetectionAndReturnError([NullAllowed] out NSError error);

        // -(BOOL)transformImageWithSquare:(ALSquare * _Nullable)square image:(UIImage * _Nullable)image error:(NSError * _Nullable * _Nullable)error;
        [Export("transformImageWithSquare:image:error:")]
        bool TransformImageWithSquare([NullAllowed] ALSquare square, [NullAllowed] UIImage image, [NullAllowed] out NSError error);

        // -(BOOL)transformALImageWithSquare:(ALSquare * _Nullable)square image:(ALImage * _Nullable)image error:(NSError * _Nullable * _Nullable)error;
        [Export("transformALImageWithSquare:image:error:")]
        bool TransformALImageWithSquare([NullAllowed] ALSquare square, [NullAllowed] ALImage image, [NullAllowed] out NSError error);

        // @property (nonatomic, strong) NSNumber * _Nonnull maxDocumentRatioDeviation;
        [Export("maxDocumentRatioDeviation", ArgumentSemantic.Strong)]
        NSNumber MaxDocumentRatioDeviation { get; set; }

        // @property (assign, nonatomic) CGSize maxOutputResolution;
        [Export("maxOutputResolution", ArgumentSemantic.Assign)]
        CGSize MaxOutputResolution { get; set; }

        // @property (nonatomic, strong) NSArray<NSNumber *> * _Nullable documentRatios;
        [NullAllowed, Export("documentRatios", ArgumentSemantic.Strong)]
        NSNumber[] DocumentRatios { get; set; }

        // @property (assign, nonatomic) BOOL postProcessingEnabled;
        [Export("postProcessingEnabled")]
        bool PostProcessingEnabled { get; set; }

        // -(void)addDelegate:(id<ALDocumentScanPluginDelegate> _Nonnull)delegate;
        [Export("addDelegate:")]
        void AddDelegate(NSObject @delegate);

        // -(void)removeDelegate:(id<ALDocumentScanPluginDelegate> _Nonnull)delegate;
        [Export("removeDelegate:")]
        void RemoveDelegate(NSObject @delegate);

        // -(void)addInfoDelegate:(id<ALDocumentInfoDelegate> _Nonnull)infoDelegate;
        [Export("addInfoDelegate:")]
        void AddInfoDelegate(ALDocumentInfoDelegate infoDelegate);

        // -(void)removeInfoDelegate:(id<ALDocumentInfoDelegate> _Nonnull)infoDelegate;
        [Export("removeInfoDelegate:")]
        void RemoveInfoDelegate(ALDocumentInfoDelegate infoDelegate);
    }

    // @protocol ALDocumentScanPluginDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALDocumentScanPluginDelegate
    {
        // @required -(void)anylineDocumentScanPlugin:(ALDocumentScanPlugin * _Nonnull)anylineDocumentScanPlugin hasResult:(UIImage * _Nonnull)transformedImage fullImage:(UIImage * _Nonnull)fullFrame documentCorners:(ALSquare * _Nonnull)corners;
        [Abstract]
        [Export("anylineDocumentScanPlugin:hasResult:fullImage:documentCorners:")]
        void HasResult(ALDocumentScanPlugin anylineDocumentScanPlugin, UIImage transformedImage, UIImage fullFrame, ALSquare corners);
    }

    // @protocol ALDocumentInfoDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALDocumentInfoDelegate
    {
        // @optional -(void)anylineDocumentScanPlugin:(ALDocumentScanPlugin * _Nonnull)anylineDocumentScanPlugin detectedPictureCorners:(ALSquare * _Nonnull)corners inImage:(UIImage * _Nonnull)image;
        [Export("anylineDocumentScanPlugin:detectedPictureCorners:inImage:")]
        void DetectedPictureCorners(ALDocumentScanPlugin anylineDocumentScanPlugin, ALSquare corners, UIImage image);

        // @optional -(void)anylineDocumentScanPlugin:(ALDocumentScanPlugin * _Nonnull)anylineDocumentScanPlugin reportsPreviewResult:(UIImage * _Nonnull)image;
        [Export("anylineDocumentScanPlugin:reportsPreviewResult:")]
        void ReportsPreviewResult(ALDocumentScanPlugin anylineDocumentScanPlugin, UIImage image);

        // @optional -(void)anylineDocumentScanPlugin:(ALDocumentScanPlugin * _Nonnull)anylineDocumentScanPlugin reportsPreviewProcessingFailure:(ALDocumentError)error;
        [Export("anylineDocumentScanPlugin:reportsPreviewProcessingFailure:")]
        void ReportsPreviewProcessingFailure(ALDocumentScanPlugin anylineDocumentScanPlugin, ALDocumentError error);

        // @optional -(void)anylineDocumentScanPlugin:(ALDocumentScanPlugin * _Nonnull)anylineDocumentScanPlugin reportsPictureProcessingFailure:(ALDocumentError)error;
        [Export("anylineDocumentScanPlugin:reportsPictureProcessingFailure:")]
        void ReportsPictureProcessingFailure(ALDocumentScanPlugin anylineDocumentScanPlugin, ALDocumentError error);

        // @optional -(void)anylineDocumentScanPlugin:(ALDocumentScanPlugin * _Nonnull)anylineDocumentScanPlugin reportInfo:(ALScanInfo * _Nonnull)scanInfo;
        [Export("anylineDocumentScanPlugin:reportInfo:")]
        void ReportInfo(ALDocumentScanPlugin anylineDocumentScanPlugin, ALScanInfo scanInfo);
    }

    // @interface ALDocumentScanViewPlugin : ALAbstractScanViewPlugin
    [BaseType(typeof(ALAbstractScanViewPlugin))]
    interface ALDocumentScanViewPlugin
    {
        // @property (nonatomic, strong) ALDocumentScanPlugin * _Nullable documentScanPlugin;
        [NullAllowed, Export("documentScanPlugin", ArgumentSemantic.Strong)]
        ALDocumentScanPlugin DocumentScanPlugin { get; set; }

        // -(instancetype _Nullable)initWithScanPlugin:(ALDocumentScanPlugin * _Nonnull)documentScanPlugin;
        [Export("initWithScanPlugin:")]
        IntPtr Constructor(ALDocumentScanPlugin documentScanPlugin);

        // -(instancetype _Nullable)initWithScanPlugin:(ALDocumentScanPlugin * _Nonnull)documentScanPlugin scanViewPluginConfig:(ALScanViewPluginConfig * _Nonnull)scanViewPluginConfig;
        [Export("initWithScanPlugin:scanViewPluginConfig:")]
        IntPtr Constructor(ALDocumentScanPlugin documentScanPlugin, ALScanViewPluginConfig scanViewPluginConfig);
    }

    // @interface AnylineDocumentModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineDocumentModuleView
    {
        // @property (nonatomic, strong) ALDocumentScanViewPlugin * _Nullable documentScanViewPlugin;
        [NullAllowed, Export("documentScanViewPlugin", ArgumentSemantic.Strong)]
        ALDocumentScanViewPlugin DocumentScanViewPlugin { get; set; }

        // @property (nonatomic, strong) ALDocumentScanPlugin * _Nullable documentScanPlugin;
        [NullAllowed, Export("documentScanPlugin", ArgumentSemantic.Strong)]
        ALDocumentScanPlugin DocumentScanPlugin { get; set; }

        // -(BOOL)setupWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<AnylineDocumentModuleDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // -(void)setupAsyncWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<AnylineDocumentModuleDelegate> _Nonnull)delegate finished:(void (^ _Nonnull)(BOOL, NSError * _Nullable))finished;
        [Export("setupAsyncWithLicenseKey:delegate:finished:")]
        void SetupAsyncWithLicenseKey(string licenseKey, NSObject @delegate, Action<bool, NSError> finished);

        // @property (nonatomic, strong) NSNumber * _Nullable maxDocumentRatioDeviation;
        [NullAllowed, Export("maxDocumentRatioDeviation", ArgumentSemantic.Strong)]
        NSNumber MaxDocumentRatioDeviation { get; set; }

        // @property (assign, nonatomic) CGSize maxOutputResolution;
        [Export("maxOutputResolution", ArgumentSemantic.Assign)]
        CGSize MaxOutputResolution { get; set; }

        // @property (assign, nonatomic) BOOL postProcessingEnabled;
        [Export("postProcessingEnabled")]
        bool PostProcessingEnabled { get; set; }

        // -(void)setDocumentRatios:(NSArray<NSNumber *> * _Nonnull)ratios;
        [Export("setDocumentRatios:")]
        void SetDocumentRatios(NSNumber[] ratios);

        // -(BOOL)triggerPictureCornerDetectionAndReturnError:(NSError * _Nullable * _Nullable)error;
        [Export("triggerPictureCornerDetectionAndReturnError:")]
        bool TriggerPictureCornerDetectionAndReturnError([NullAllowed] out NSError error);

        // -(BOOL)transformImageWithSquare:(ALSquare * _Nullable)square image:(UIImage * _Nullable)image error:(NSError * _Nullable * _Nullable)error;
        [Export("transformImageWithSquare:image:error:")]
        bool TransformImageWithSquare([NullAllowed] ALSquare square, [NullAllowed] UIImage image, [NullAllowed] out NSError error);

        // -(BOOL)transformALImageWithSquare:(ALSquare * _Nullable)square image:(ALImage * _Nullable)image error:(NSError * _Nullable * _Nullable)error;
        [Export("transformALImageWithSquare:image:error:")]
        bool TransformALImageWithSquare([NullAllowed] ALSquare square, [NullAllowed] ALImage image, [NullAllowed] out NSError error);
    }

    // @protocol AnylineDocumentModuleDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineDocumentModuleDelegate
    {
        // @required -(void)anylineDocumentModuleView:(AnylineDocumentModuleView *)anylineDocumentModuleView hasResult:(UIImage *)transformedImage fullImage:(UIImage *)fullFrame documentCorners:(ALSquare *)corners;
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

    // @interface ALLicensePlateResult : ALScanResult
    [BaseType(typeof(ALScanResult))]
    interface ALLicensePlateResult
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable country;
        [NullAllowed, Export("country", ArgumentSemantic.Strong)]
        string Country { get; }

        // -(instancetype _Nullable)initWithResult:(NSString * _Nonnull)result image:(UIImage * _Nonnull)image fullImage:(UIImage * _Nullable)fullImage confidence:(NSInteger)confidence pluginID:(NSString * _Nonnull)pluginID country:(NSString * _Nullable)country;
        [Export("initWithResult:image:fullImage:confidence:pluginID:country:")]
        IntPtr Constructor(string result, UIImage image, [NullAllowed] UIImage fullImage, nint confidence, string pluginID, [NullAllowed] string country);
    }

    // @interface ALLicensePlateScanPlugin : ALAbstractScanPlugin
    [BaseType(typeof(ALAbstractScanPlugin))]
    [DisableDefaultCtor]
    interface ALLicensePlateScanPlugin
    {
        // -(instancetype _Nullable)initWithPluginID:(NSString * _Nullable)pluginID licenseKey:(NSString * _Nonnull)licenseKey delegate:(id<ALLicensePlateScanPluginDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
        [Export("initWithPluginID:licenseKey:delegate:error:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string pluginID, string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // -(void)addDelegate:(id<ALLicensePlateScanPluginDelegate> _Nonnull)delegate;
        [Export("addDelegate:")]
        void AddDelegate(NSObject @delegate);

        // -(void)removeDelegate:(id<ALLicensePlateScanPluginDelegate> _Nonnull)delegate;
        [Export("removeDelegate:")]
        void RemoveDelegate(NSObject @delegate);
    }

    // @protocol ALLicensePlateScanPluginDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALLicensePlateScanPluginDelegate
    {
        // @required -(void)anylineLicensePlateScanPlugin:(ALLicensePlateScanPlugin * _Nonnull)anylineLicensePlateScanPlugin didFindResult:(ALLicensePlateResult * _Nonnull)scanResult;
        [Abstract]
        [Export("anylineLicensePlateScanPlugin:didFindResult:")]
        void DidFindResult(ALLicensePlateScanPlugin anylineLicensePlateScanPlugin, ALLicensePlateResult scanResult);
    }

    // @interface ALLicensePlateScanViewPlugin : ALAbstractScanViewPlugin
    [BaseType(typeof(ALAbstractScanViewPlugin))]
    interface ALLicensePlateScanViewPlugin
    {
        // @property (nonatomic, strong) ALLicensePlateScanPlugin * _Nullable licensePlateScanPlugin;
        [NullAllowed, Export("licensePlateScanPlugin", ArgumentSemantic.Strong)]
        ALLicensePlateScanPlugin LicensePlateScanPlugin { get; set; }

        // -(instancetype _Nullable)initWithScanPlugin:(ALLicensePlateScanPlugin * _Nonnull)licensePlateScanPlugin;
        [Export("initWithScanPlugin:")]
        IntPtr Constructor(ALLicensePlateScanPlugin licensePlateScanPlugin);

        // -(instancetype _Nullable)initWithScanPlugin:(ALLicensePlateScanPlugin * _Nonnull)licensePlateScanPlugin scanViewPluginConfig:(ALScanViewPluginConfig * _Nonnull)scanViewPluginConfig;
        [Export("initWithScanPlugin:scanViewPluginConfig:")]
        IntPtr Constructor(ALLicensePlateScanPlugin licensePlateScanPlugin, ALScanViewPluginConfig scanViewPluginConfig);
    }

    // @interface AnylineLicensePlateModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineLicensePlateModuleView
    {
        // @property (nonatomic, strong) ALLicensePlateScanPlugin * _Nullable licensePlateScanPlugin;
        [NullAllowed, Export("licensePlateScanPlugin", ArgumentSemantic.Strong)]
        ALLicensePlateScanPlugin LicensePlateScanPlugin { get; set; }

        // @property (nonatomic, strong) ALLicensePlateScanViewPlugin * _Nullable licensePlateScanViewPlugin;
        [NullAllowed, Export("licensePlateScanViewPlugin", ArgumentSemantic.Strong)]
        ALLicensePlateScanViewPlugin LicensePlateScanViewPlugin { get; set; }

        // -(BOOL)setupWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<AnylineLicensePlateModuleDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // -(void)setupAsyncWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<AnylineLicensePlateModuleDelegate> _Nonnull)delegate finished:(void (^ _Nonnull)(BOOL, NSError * _Nullable))finished;
        [Export("setupAsyncWithLicenseKey:delegate:finished:")]
        void SetupAsyncWithLicenseKey(string licenseKey, NSObject @delegate, Action<bool, NSError> finished);
    }

    // @protocol AnylineLicensePlateModuleDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineLicensePlateModuleDelegate
    {
        // @required -(void)anylineLicensePlateModuleView:(AnylineLicensePlateModuleView * _Nonnull)anylineLicensePlateModuleView didFindResult:(ALLicensePlateResult * _Nonnull)scanResult;
        [Abstract]
        [Export("anylineLicensePlateModuleView:didFindResult:")]
        void DidFindResult(AnylineLicensePlateModuleView anylineLicensePlateModuleView, ALLicensePlateResult scanResult);
    }
}