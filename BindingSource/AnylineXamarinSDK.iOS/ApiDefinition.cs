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

        // @property (copy, nonatomic) UIBezierPath * cutoutPath;
        [Export("cutoutPath", ArgumentSemantic.Copy)]
        UIBezierPath CutoutPath { get; set; }

        // @property (nonatomic, strong) UIColor * cutoutBackgroundColor;
        [Export("cutoutBackgroundColor", ArgumentSemantic.Strong)]
        UIColor CutoutBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * strokeColor;
        [Export("strokeColor", ArgumentSemantic.Strong)]
        UIColor StrokeColor { get; set; }

        // @property (nonatomic, strong) UIColor * feedbackStrokeColor;
        [Export("feedbackStrokeColor", ArgumentSemantic.Strong)]
        UIColor FeedbackStrokeColor { get; set; }

        // @property (nonatomic, strong) UIImage * overlayImage;
        [Export("overlayImage", ArgumentSemantic.Strong)]
        UIImage OverlayImage { get; set; }

        // -(instancetype)initWithFrame:(CGRect)frame cutoutWidthPercent:(CGFloat)cutoutWidthPercent cutoutMaxPercentWidth:(CGFloat)cutoutMaxPercentWidth cutoutMaxPercentHeight:(CGFloat)cutoutMaxPercentHeight cutoutOffset:(CGPoint)cutoutOffset cornerRadius:(NSInteger)cornerRadius strokeWidth:(NSInteger)strokeWidth cutoutAlignment:(ALCutoutAlignment)cutoutAlignment cutoutPath:(UIBezierPath *)cutoutPath cutoutBackgroundColor:(UIColor *)cutoutBackgroundColor strokeColor:(UIColor *)strokeColor feedbackStrokeColor:(UIColor *)feedbackStrokeColor overlayImage:(UIImage *)overlayImage;
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

        // @property (assign, nonatomic) ALFlashAlignment flashAlignment;
        [Export("flashAlignment", ArgumentSemantic.Assign)]
        ALFlashAlignment FlashAlignment { get; set; }

        // @property (assign, nonatomic) ALFlashMode flashMode;
        [Export("flashMode", ArgumentSemantic.Assign)]
        ALFlashMode FlashMode { get; set; }

        // @property (assign, nonatomic) CGPoint flashOffset;
        [Export("flashOffset", ArgumentSemantic.Assign)]
        CGPoint FlashOffset { get; set; }

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

        // -(instancetype)initWithFrame:(CGRect)frame flashImage:(UIImage *)flashImage alignment:(ALFlashAlignment)flashAlignment flashMode:(ALFlashMode)flashMode flashOffset:(CGPoint)flashOffset;
        [Export("initWithFrame:flashImage:alignment:flashMode:flashOffset:")]
        IntPtr Constructor(CGRect frame, UIImage flashImage, ALFlashAlignment flashAlignment, ALFlashMode flashMode, CGPoint flashOffset);
    }

    // @interface ALUIConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    interface ALUIConfiguration
    {
        // @property (nonatomic, strong) NSString * defaultCamera;
        [Export("defaultCamera", ArgumentSemantic.Strong)]
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

    // @interface ALImage : NSObject
    [BaseType(typeof(NSObject))]
    interface ALImage
    {
        // @property (nonatomic, strong) UIImage * uiImage;
        [Export("uiImage", ArgumentSemantic.Strong)]
        UIImage UiImage { get; set; }

        // -(UIImage *)uiImageWithSpecOverlay:(ALROISpec *)displaySpec;
        [Export("uiImageWithSpecOverlay:")]
        UIImage UiImageWithSpecOverlay(ALROISpec displaySpec);

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

        //// -(instancetype)initWithBGRAImageBuffer:(CVImageBufferRef)imageBuffer rotate:(CGFloat)degrees;
        //[Export("initWithBGRAImageBuffer:rotate:")]
        //unsafe IntPtr Constructor(NSObject* imageBuffer, nfloat degrees);

        //// -(instancetype)initWithBGRAImageBuffer:(CVImageBufferRef)imageBuffer rotate:(CGFloat)degrees cutout:(CGRect)cutout;
        //[Export("initWithBGRAImageBuffer:rotate:cutout:")]
        //unsafe IntPtr Constructor(NSObject* imageBuffer, nfloat degrees, CGRect cutout);

        // -(BOOL)isEmpy;
        [Export("isEmpy")]
        bool IsEmpty { get; }
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
        //[Export("initWithJSonFileName:")]
        //IntPtr Constructor(string filename);

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
    }

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
        [Export("specs", ArgumentSemantic.Strong)]
        ALROISpec Specs { get; set; }

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

        [Wrap("WeakDelegate")]
        ALCoreControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ALCoreControllerDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(instancetype)initWithLicenseKey:(NSString *)licenseKey;
        [Export("initWithLicenseKey:")]
        IntPtr Constructor(string licenseKey);

        // -(instancetype)initWithLicenseKey:(NSString *)licenseKey delegate:(id<ALCoreControllerDelegate>)delegate;
        [Export("initWithLicenseKey:delegate:")]
        IntPtr Constructor(string licenseKey, ALCoreControllerDelegate @delegate);

        // -(BOOL)loadScript:(NSString *)script bundlePath:(NSString *)bundlePath error:(NSError **)error;
        [Export("loadScript:bundlePath:error:")]
        bool LoadScript(string script, string bundlePath, out NSError error);

        // -(BOOL)loadScript:(NSString *)script scriptName:(NSString *)scriptName bundlePath:(NSString *)bundlePath error:(NSError **)error;
        [Export("loadScript:scriptName:bundlePath:error:")]
        bool LoadScript(string script, string scriptName, string bundlePath, out NSError error);

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

        // -(void)reportIncludeValues:(NSString *)values;
        [Export("reportIncludeValues:")]
        void ReportIncludeValues(string values);

        // -(NSArray *)runStatistics;
        [Export("runStatistics")]
        NSObject[] RunStatistics { get; }
    }

    // @protocol ALCoreControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALCoreControllerDelegate
    {
        // @required -(void)anylineCoreController:(ALCoreController *)coreController didFinishWithOutput:(id)object;
        [Abstract]
        [Export("anylineCoreController:didFinishWithOutput:")]
        void DidFinishWithOutput(ALCoreController coreController, NSObject @object);

        // @optional -(void)anylineCoreController:(ALCoreController *)coreController didAbortRun:(NSError *)reason;
        [Export("anylineCoreController:didAbortRun:")]
        void DidAbortRun(ALCoreController coreController, NSError reason);

        // @optional -(void)anylineCoreController:(ALCoreController *)coreController reportsVariable:(NSString *)variableName value:(id)value;
        [Export("anylineCoreController:reportsVariable:value:")]
        void ReportsVariable(ALCoreController coreController, string variableName, NSObject value);

        // @optional -(void)anylineCoreController:(ALCoreController *)coreController parserError:(NSError *)error;
        [Export("anylineCoreController:parserError:")]
        void ParserError(ALCoreController coreController, NSError error);
    }

    // @interface ALTorchManager : NSObject <ALFlashButtonStatusDelegate>
    [BaseType(typeof(NSObject))]
    interface ALTorchManager : ALFlashButtonStatusDelegate
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
    partial interface ALScanInfoConstants
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

    // @interface ALCaptureDeviceManager : NSObject <ALImageProvider>
    [BaseType(typeof(NSObject))]
    interface ALCaptureDeviceManager : ALImageProvider
    {
        // -(instancetype)initWithCaptureResolution:(ALCaptureViewResolution)captureResolution pictureResolution:(ALPictureResolution)pictureResolution cutoutScreen:(CGRect)cutoutScreen cutoutPadding:(CGSize)cutoutPadding cutoutOffset:(CGPoint)cutoutOffset defaultDevice:(NSString *)defaultDevice;
        [Export("initWithCaptureResolution:pictureResolution:cutoutScreen:cutoutPadding:cutoutOffset:defaultDevice:")]
        IntPtr Constructor(ALCaptureViewResolution captureResolution, ALPictureResolution pictureResolution, CGRect cutoutScreen, CGSize cutoutPadding, CGPoint cutoutOffset, string defaultDevice);

        [Wrap("WeakBarcodeDelegate")]
        NSObject BarcodeDelegate { get; set; }

        // @property (nonatomic, weak) id<AnylineNativeBarcodeDelegate> barcodeDelegate;
        [NullAllowed, Export("barcodeDelegate", ArgumentSemantic.Weak)]
        NSObject WeakBarcodeDelegate { get; set; }

        //[Wrap("WeakSampleBufferDelegate")]
        //AnylineVideoDataSampleBufferDelegate SampleBufferDelegate { get; set; }

        //// @property (nonatomic, weak) id<AnylineVideoDataSampleBufferDelegate> sampleBufferDelegate;
        //[NullAllowed, Export("sampleBufferDelegate", ArgumentSemantic.Weak)]
        //NSObject WeakSampleBufferDelegate { get; set; }

        // @property (assign, nonatomic) ALCaptureViewResolution captureResolution;
        [Export("captureResolution", ArgumentSemantic.Assign)]
        ALCaptureViewResolution CaptureResolution { get; set; }

        // @property (assign, nonatomic) ALPictureResolution pictureResolution;
        [Export("pictureResolution", ArgumentSemantic.Assign)]
        ALPictureResolution PictureResolution { get; set; }

        // @property (assign, nonatomic) CGSize videoResolution;
        [Export("videoResolution", ArgumentSemantic.Assign)]
        CGSize VideoResolution { get; set; }

        // @property (assign, nonatomic) CGRect cutoutFrame;
        [Export("cutoutFrame", ArgumentSemantic.Assign)]
        CGRect CutoutFrame { get; set; }

        // @property (assign, nonatomic) CGRect cutoutScreen;
        [Export("cutoutScreen", ArgumentSemantic.Assign)]
        CGRect CutoutScreen { get; set; }

        // @property (assign, nonatomic) CGSize cutoutPadding;
        [Export("cutoutPadding", ArgumentSemantic.Assign)]
        CGSize CutoutPadding { get; set; }

        // @property (assign, nonatomic) CGPoint cutoutOffset;
        [Export("cutoutOffset", ArgumentSemantic.Assign)]
        CGPoint CutoutOffset { get; set; }

        // @property (nonatomic, strong) AVCaptureVideoPreviewLayer * previewLayer;
        [Export("previewLayer", ArgumentSemantic.Strong)]
        AVCaptureVideoPreviewLayer PreviewLayer { get; set; }

        // -(void)addVideoLayerOnView:(UIView *)view;
        [Export("addVideoLayerOnView:")]
        void AddVideoLayerOnView(UIView view);

        // -(void)setFocusAndExposurePoint:(CGPoint)point;
        [Export("setFocusAndExposurePoint:")]
        void SetFocusAndExposurePoint(CGPoint point);

        // -(void)startSession;
        [Export("startSession")]
        void StartSession();

        // -(void)stopSession;
        [Export("stopSession")]
        void StopSession();

        // -(BOOL)isRunning;
        [Export("isRunning")]
        bool IsRunning { get; }

        // -(CGPoint)convertPoint:(CGPoint)inPoint;
        [Export("convertPoint:")]
        CGPoint ConvertPoint(CGPoint inPoint);

        // -(CGPoint)convertPoint:(CGPoint)inPoint imageWidth:(CGFloat)inWidth;
        [Export("convertPoint:imageWidth:")]
        CGPoint ConvertPoint(CGPoint inPoint, nfloat inWidth);

        // -(CGPoint)fullResolutionPointForPointInPreview:(CGPoint)inPoint;
        [Export("fullResolutionPointForPointInPreview:")]
        CGPoint FullResolutionPointForPointInPreview(CGPoint inPoint);

        // -(UIInterfaceOrientation)currentInterfaceOrientation;
        [Export("currentInterfaceOrientation")]
        UIInterfaceOrientation CurrentInterfaceOrientation { get; }
    }

    //// @protocol AnylineVideoDataSampleBufferDelegate <NSObject>
    //[Protocol, Model]
    //[BaseType(typeof(NSObject))]
    //interface AnylineVideoDataSampleBufferDelegate
    //{
    //    // @required -(void)anylineCaptureDeviceManager:(ALCaptureDeviceManager *)captureDeviceManager didOutputSampleBuffer:(CMSampleBufferRef)sampleBuffer;
    //    [Abstract]
    //    [Export("anylineCaptureDeviceManager:didOutputSampleBuffer:")]
    //    unsafe void DidOutputSampleBuffer(ALCaptureDeviceManager captureDeviceManager, NSObject* sampleBuffer);
    //}

    // @protocol AnylineNativeBarcodeDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineNativeBarcodeDelegate
    {
        // @required -(void)anylineCaptureDeviceManager:(ALCaptureDeviceManager *)captureDeviceManager didFindBarcodeResult:(NSString *)scanResult type:(NSString *)barcodeType;
        [Abstract]
        [Export("anylineCaptureDeviceManager:didFindBarcodeResult:type:")]
        void DidFindBarcodeResult(ALCaptureDeviceManager captureDeviceManager, string scanResult, string barcodeType);
    }

    // @interface ALCameraView : UIView
    [BaseType(typeof(UIView))]
    interface ALCameraView
    {
        // -(instancetype)initWithFrame:(CGRect)frame captureDeviceManager:(ALCaptureDeviceManager *)captureDeviceManger;
        [Export("initWithFrame:captureDeviceManager:")]
        IntPtr Constructor(CGRect frame, ALCaptureDeviceManager captureDeviceManger);
    }

    // @interface AnylineAbstractModuleView : UIView
    [BaseType(typeof(UIView))]
    interface AnylineAbstractModuleView
    {
        [Wrap("WeakDebugDelegate")]
        AnylineDebugDelegate DebugDelegate { get; set; }

        // @property (nonatomic, weak) id<AnylineDebugDelegate> debugDelegate;
        [NullAllowed, Export("debugDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDebugDelegate { get; set; }

        // @property (nonatomic, strong) ALCameraView * cameraView;
        [Export("cameraView", ArgumentSemantic.Strong)]
        ALCameraView CameraView { get; set; }

        // @property (nonatomic, strong) ALCaptureDeviceManager * captureDeviceManager;
        [Export("captureDeviceManager", ArgumentSemantic.Strong)]
        ALCaptureDeviceManager CaptureDeviceManager { get; set; }

        // @property (nonatomic, strong) ALCutoutView * cutoutView;
        [Export("cutoutView", ArgumentSemantic.Strong)]
        ALCutoutView CutoutView { get; set; }

        // @property (nonatomic, strong) ALFlashButton * flashButton;
        [Export("flashButton", ArgumentSemantic.Strong)]
        ALFlashButton FlashButton { get; set; }

        // @property (nonatomic, strong) ALTorchManager * torchManager;
        [Export("torchManager", ArgumentSemantic.Strong)]
        ALTorchManager TorchManager { get; set; }

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

        // -(void)stopListeningForMotion;
        [Export("stopListeningForMotion")]
        void StopListeningForMotion();
    }

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

    // @interface ALAbstractScanPlugin : NSObject <ALCoreControllerDelegate>
    [BaseType(typeof(NSObject))]
    interface ALAbstractScanPlugin : ALCoreControllerDelegate
    {
        // @property (readonly, nonatomic, strong) NSHashTable<ALInfoDelegate> * _Nullable infoDelegates;
        [NullAllowed, Export("infoDelegates", ArgumentSemantic.Strong)]
        ALInfoDelegate InfoDelegates { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable pluginID;
        [NullAllowed, Export("pluginID", ArgumentSemantic.Strong)]
        string PluginID { get; }

        // @property (readonly, assign, nonatomic) NSInteger confidence;
        [Export("confidence")]
        nint Confidence { get; }

        // @property (readonly, nonatomic, strong) ALImage * _Nullable scanImage;
        [NullAllowed, Export("scanImage", ArgumentSemantic.Strong)]
        ALImage ScanImage { get; }

        // @property (nonatomic, strong) ALCoreController * _Nullable coreController;
        [NullAllowed, Export("coreController", ArgumentSemantic.Strong)]
        ALCoreController CoreController { get; set; }

        // @property (assign, nonatomic) id<ALImageProvider> _Nullable imageProvider;
        [NullAllowed, Export("imageProvider", ArgumentSemantic.Assign)]
        ALImageProvider ImageProvider { get; set; }

        // -(instancetype _Nullable)initWithPluginID:(NSString * _Nullable)pluginID __attribute__((objc_designated_initializer));
        [Export("initWithPluginID:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string pluginID);

        // -(BOOL)start:(id<ALImageProvider> _Nonnull)imageProvider error:(NSError * _Nullable * _Nullable)error;
        [Export("start:error:")]
        bool Start(ALImageProvider imageProvider, [NullAllowed] out NSError error);

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
        void AddInfoDelegate(ALInfoDelegate infoDelegate);

        // -(void)removeInfoDelegate:(id<ALInfoDelegate> _Nonnull)infoDelegate;
        [Export("removeInfoDelegate:")]
        void RemoveInfoDelegate(ALInfoDelegate infoDelegate);
    }

    // @protocol ALInfoDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALInfoDelegate
    {
        // @optional -(void)anylineScanPlugin:(ALAbstractScanPlugin * _Nonnull)anylineScanPlugin reportInfo:(ALScanInfo * _Nonnull)info;
        [Export("anylineScanPlugin:reportInfo:")]
        void ReportInfo(ALAbstractScanPlugin anylineScanPlugin, ALScanInfo info);

        // @optional -(void)anylineScanPlugin:(ALAbstractScanPlugin * _Nonnull)anylineScanPlugin runSkipped:(ALRunSkippedReason * _Nonnull)runSkippedReason;
        [Export("anylineScanPlugin:runSkipped:")]
        void RunSkipped(ALAbstractScanPlugin anylineScanPlugin, ALRunSkippedReason runSkippedReason);
    }

    // @interface ALMeterScanPlugin : ALAbstractScanPlugin
    [BaseType(typeof(ALAbstractScanPlugin))]
    interface ALMeterScanPlugin
    {
        // @property (readonly, nonatomic, strong) NSHashTable<ALMeterScanPluginDelegate> * _Nullable delegates;
        [NullAllowed, Export("delegates", ArgumentSemantic.Strong)]
        ALMeterScanPluginDelegate Delegates { get; }

        // @property (readonly, assign, nonatomic) ALScanMode scanMode;
        [Export("scanMode", ArgumentSemantic.Assign)]
        ALScanMode ScanMode { get; }

        // -(BOOL)setScanMode:(ALScanMode)scanMode error:(NSError * _Nullable * _Nullable)error;
        [Export("setScanMode:error:")]
        bool SetScanMode(ALScanMode scanMode, [NullAllowed] out NSError error);

        // -(BOOL)setupWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<ALMeterScanPluginDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // -(void)addDelegate:(id<ALMeterScanPluginDelegate> _Nonnull)delegate;
        [Export("addDelegate:")]
        void AddDelegate(ALMeterScanPluginDelegate @delegate);

        // -(void)removeDelegate:(id<ALMeterScanPluginDelegate> _Nonnull)delegate;
        [Export("removeDelegate:")]
        void RemoveDelegate(ALMeterScanPluginDelegate @delegate);
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

    [Static]
    partial interface BarcodeConstants
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
    interface ALBarcodeScanPlugin
    {
        // @property (readonly, nonatomic, strong) NSHashTable<ALBarcodeScanPluginDelegate> * _Nullable delegates;
        [NullAllowed, Export("delegates", ArgumentSemantic.Strong)]
        ALBarcodeScanPluginDelegate Delegates { get; }

        // @property (assign, nonatomic) ALBarcodeFormatOptions barcodeFormatOptions;
        [Export("barcodeFormatOptions", ArgumentSemantic.Assign)]
        ALBarcodeFormat BarcodeFormatOptions { get; set; }

        // -(BOOL)setupWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<ALBarcodeScanPluginDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // -(ALBarcodeFormat)barcodeFormatForString:(NSString * _Nullable)barcodeFormatString;
        [Export("barcodeFormatForString:")]
        ALBarcodeFormat BarcodeFormatForString([NullAllowed] string barcodeFormatString);

        // -(void)addDelegate:(id<ALBarcodeScanPluginDelegate> _Nonnull)delegate;
        [Export("addDelegate:")]
        void AddDelegate(ALBarcodeScanPluginDelegate @delegate);

        // -(void)removeDelegate:(id<ALBarcodeScanPluginDelegate> _Nonnull)delegate;
        [Export("removeDelegate:")]
        void RemoveDelegate(ALBarcodeScanPluginDelegate @delegate);
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
        // @property (copy, nonatomic) ALPolygon * polygon;
        [Export("polygon", ArgumentSemantic.Copy)]
        ALPolygon Polygon { get; set; }

        // @property (copy, nonatomic) ALSquare * square;
        [Export("square", ArgumentSemantic.Copy)]
        ALSquare Square { get; set; }

        // @property (copy, nonatomic) NSArray * contours;
        [Export("contours", ArgumentSemantic.Copy)]
        NSObject[] Contours { get; set; }

        // @property (assign, nonatomic) NSInteger visualFeedbackCornerRadius;
        [Export("visualFeedbackCornerRadius")]
        nint VisualFeedbackCornerRadius { get; set; }

        // @property (assign, nonatomic) NSInteger cornerRadius;
        [Export("cornerRadius")]
        nint CornerRadius { get; set; }

        // @property (assign, nonatomic) NSInteger visualFeedbackRedrawTimeout;
        [Export("visualFeedbackRedrawTimeout")]
        nint VisualFeedbackRedrawTimeout { get; set; }

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

        // @property (assign, nonatomic) NSInteger visualFeedbackAnimationDuration;
        [Export("visualFeedbackAnimationDuration")]
        nint VisualFeedbackAnimationDuration { get; set; }

        // @property (copy, nonatomic) UIBezierPath * cutoutPath;
        [Export("cutoutPath", ArgumentSemantic.Copy)]
        UIBezierPath CutoutPath { get; set; }

        // @property (assign, nonatomic) NSInteger visualFeedbackStrokeWidth;
        [Export("visualFeedbackStrokeWidth")]
        nint VisualFeedbackStrokeWidth { get; set; }

        // -(instancetype)initWithFrame:(CGRect)frame visualFeedbackCornerRadius:(NSInteger)visualFeedbackCornerRadius cornerRadius:(NSInteger)cornerRadius visualFeedbackRedrawTimeout:(NSInteger)visualFeedbackRedrawTimeout feedbackStyle:(ALUIFeedbackStyle)feedbackStyle visualFeedbackAnimation:(ALUIVisualFeedbackAnimation)visualFeedbackAnimation visualFeedbackStrokeColor:(UIColor *)visualFeedbackStrokeColor visualFeedbackFillColor:(UIColor *)visualFeedbackFillColor visualFeedbackAnimationDuration:(NSInteger)visualFeedbackAnimationDuration cutoutPath:(UIBezierPath *)cutoutPath visualFeedbackStrokeWidth:(NSInteger)visualFeedbackStrokeWidth;
        [Export("initWithFrame:visualFeedbackCornerRadius:cornerRadius:visualFeedbackRedrawTimeout:feedbackStyle:visualFeedbackAnimation:visualFeedbackStrokeColor:visualFeedbackFillColor:visualFeedbackAnimationDuration:cutoutPath:visualFeedbackStrokeWidth:")]
        IntPtr Constructor(CGRect frame, nint visualFeedbackCornerRadius, nint cornerRadius, nint visualFeedbackRedrawTimeout, ALUIFeedbackStyle feedbackStyle, ALUIVisualFeedbackAnimation visualFeedbackAnimation, UIColor visualFeedbackStrokeColor, UIColor visualFeedbackFillColor, nint visualFeedbackAnimationDuration, UIBezierPath cutoutPath, nint visualFeedbackStrokeWidth);

        // -(void)cancelFeedback;
        [Export("cancelFeedback")]
        void CancelFeedback();
    }

    // @interface ALAbstractScanViewPlugin : UIView <ALInfoDelegate>
    [BaseType(typeof(UIView))]
    interface ALAbstractScanViewPlugin : ALInfoDelegate
    {
        // @property (nonatomic, strong) ALCameraView * cameraView;
        [Export("cameraView", ArgumentSemantic.Strong)]
        ALCameraView CameraView { get; set; }

        // @property (nonatomic, strong) ALCaptureDeviceManager * captureDeviceManager;
        [Export("captureDeviceManager", ArgumentSemantic.Strong)]
        ALCaptureDeviceManager CaptureDeviceManager { get; set; }

        // @property (nonatomic, strong) ALCutoutView * cutoutView;
        [Export("cutoutView", ArgumentSemantic.Strong)]
        ALCutoutView CutoutView { get; set; }

        // @property (nonatomic, strong) ALFlashButton * flashButton;
        [Export("flashButton", ArgumentSemantic.Strong)]
        ALFlashButton FlashButton { get; set; }

        // @property (nonatomic, strong) ALTorchManager * torchManager;
        [Export("torchManager", ArgumentSemantic.Strong)]
        ALTorchManager TorchManager { get; set; }

        // @property (nonatomic, strong) ALVisualFeedbackOverlay * visualFeedbackOverlay;
        [Export("visualFeedbackOverlay", ArgumentSemantic.Strong)]
        ALVisualFeedbackOverlay VisualFeedbackOverlay { get; set; }

        // @property (nonatomic, strong) ALSquare * outline;
        [Export("outline", ArgumentSemantic.Strong)]
        ALSquare Outline { get; set; }

        // @property (nonatomic, strong) ALImage * scanImage;
        [Export("scanImage", ArgumentSemantic.Strong)]
        ALImage ScanImage { get; set; }

        // @property (nonatomic, strong) ALUIConfiguration * currentConfiguration;
        [Export("currentConfiguration", ArgumentSemantic.Strong)]
        ALUIConfiguration CurrentConfiguration { get; set; }

        // @property (readonly, nonatomic) CGRect watermarkRect;
        [Export("watermarkRect")]
        CGRect WatermarkRect { get; }

        // @property (assign, nonatomic) CGFloat scale;
        [Export("scale")]
        nfloat Scale { get; set; }

        // @property (nonatomic, strong) NSArray * uiConfigs;
        [Export("uiConfigs", ArgumentSemantic.Strong)]
        NSObject[] UiConfigs { get; set; }

        // -(void)customInit;
        [Export("customInit")]
        void CustomInit();

        // -(BOOL)startAndReturnError:(NSError * _Nullable * _Nullable)error;
        [Export("startAndReturnError:")]
        bool StartAndReturnError([NullAllowed] out NSError error);

        // -(BOOL)stopAndReturnError:(NSError * _Nullable * _Nullable)error;
        [Export("stopAndReturnError:")]
        bool StopAndReturnError([NullAllowed] out NSError error);

        // -(void)stopListeningForMotion;
        [Export("stopListeningForMotion")]
        void StopListeningForMotion();

        // -(void)triggerScannedFeedback;
        [Export("triggerScannedFeedback")]
        void TriggerScannedFeedback();

        // -(NSArray *)convertContours:(NSValue *)contoursValue;
        [Export("convertContours:")]
        NSObject[] ConvertContours(NSValue contoursValue);

        // -(ALSquare *)convertCGRect:(NSValue *)concreteValue;
        [Export("convertCGRect:")]
        ALSquare ConvertCGRect(NSValue concreteValue);

        // -(void)updateDispatchTimer;
        [Export("updateDispatchTimer")]
        void UpdateDispatchTimer();
    }

    // @interface ALMeterScanViewPlugin : ALAbstractScanViewPlugin
    [BaseType(typeof(ALAbstractScanViewPlugin))]
    interface ALMeterScanViewPlugin
    {
        // @property (nonatomic, strong) ALMeterScanPlugin * _Nullable meterScanPlugin;
        [NullAllowed, Export("meterScanPlugin", ArgumentSemantic.Strong)]
        ALMeterScanPlugin MeterScanPlugin { get; set; }

        // -(instancetype _Nullable)initWithFrame:(CGRect)frame scanPlugin:(ALMeterScanPlugin * _Nonnull)meterScanPlugin;
        [Export("initWithFrame:scanPlugin:")]
        IntPtr Constructor(CGRect frame, ALMeterScanPlugin meterScanPlugin);

        // @property (readonly, assign, nonatomic) ALScanMode scanMode;
        [Export("scanMode", ArgumentSemantic.Assign)]
        ALScanMode ScanMode { get; }

        // -(BOOL)setScanMode:(ALScanMode)scanMode error:(NSError * _Nullable * _Nullable)error;
        [Export("setScanMode:error:")]
        bool SetScanMode(ALScanMode scanMode, [NullAllowed] out NSError error);
    }

    // @interface AnylineEnergyModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineEnergyModuleView
    {        
        // @property (nonatomic, strong) ALMeterScanViewPlugin * meterScanViewPlugin;
        [Export("meterScanViewPlugin", ArgumentSemantic.Strong)]
        ALMeterScanViewPlugin MeterScanViewPlugin { get; set; }

        // @property (nonatomic, strong) ALMeterScanPlugin * meterScanPlugin;
        [Export("meterScanPlugin", ArgumentSemantic.Strong)]
        ALMeterScanPlugin MeterScanPlugin { get; set; }

        // @property (nonatomic, strong) ALBarcodeScanPlugin * barcodeScanPlugin;
        [Export("barcodeScanPlugin", ArgumentSemantic.Strong)]
        ALBarcodeScanPlugin BarcodeScanPlugin { get; set; }

        // @property (readonly, assign, nonatomic) ALScanMode scanMode;
        [Export("scanMode", ArgumentSemantic.Assign)]
        ALScanMode ScanMode { get; }

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

        // -(instancetype _Nullable)initWithFrame:(CGRect)frame scanPlugin:(ALBarcodeScanPlugin * _Nonnull)barcodeScanPlugin;
        [Export("initWithFrame:scanPlugin:")]
        IntPtr Constructor(CGRect frame, ALBarcodeScanPlugin barcodeScanPlugin);

        // @property (assign, nonatomic) BOOL useOnlyNativeBarcodeScanning;
        [Export("useOnlyNativeBarcodeScanning")]
        bool UseOnlyNativeBarcodeScanning { get; set; }
    }

    // @interface AnylineBarcodeModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineBarcodeModuleView
    {
        // @property (nonatomic, strong) ALBarcodeScanPlugin * barcodeScanPlugin;
        [Export("barcodeScanPlugin", ArgumentSemantic.Strong)]
        ALBarcodeScanPlugin BarcodeScanPlugin { get; set; }

        // @property (nonatomic, strong) ALBarcodeScanViewPlugin * barcodeScanViewPlugin;
        [Export("barcodeScanViewPlugin", ArgumentSemantic.Strong)]
        ALBarcodeScanViewPlugin BarcodeScanViewPlugin { get; set; }

        // @property (assign, nonatomic) ALBarcodeFormatOptions barcodeFormatOptions;
        [Export("barcodeFormatOptions", ArgumentSemantic.Assign)]
        ALBarcodeFormat BarcodeFormatOptions { get; set; }

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
        // @required -(void)anylineBarcodeModuleView:(AnylineBarcodeModuleView *)anylineBarcodeModuleView didFindResult:(ALBarcodeResult *)scanResult;
        [Abstract]
        [Export("anylineBarcodeModuleView:didFindResult:")]
        void DidFindResult(AnylineBarcodeModuleView anylineBarcodeModuleView, ALBarcodeResult scanResult);
    }

    // @interface ALIdentification : NSObject
    [BaseType(typeof(NSObject))]
    interface ALIdentification
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

        // @property (readonly, nonatomic, strong) NSDate * _Nullable expirationDateObject;
        [NullAllowed, Export("expirationDateObject", ArgumentSemantic.Strong)]
        NSDate ExpirationDateObject { get; }

        // @property (readonly, nonatomic, strong) NSDate * _Nullable dayOfBirthDateObject;
        [NullAllowed, Export("dayOfBirthDateObject", ArgumentSemantic.Strong)]
        NSDate DayOfBirthDateObject { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull MRZString;
        [Export("MRZString", ArgumentSemantic.Strong)]
        string MRZString { get; }

        // -(instancetype _Nullable)initWithDocumentType:(NSString * _Nonnull)documentType issuingCountryCode:(NSString * _Nonnull)issuingCountryCode nationalityCountryCode:(NSString * _Nonnull)nationalityCountryCode surNames:(NSString * _Nonnull)surNames givenNames:(NSString * _Nonnull)givenNames documentNumber:(NSString * _Nonnull)documentNumber checkDigitNumber:(NSString * _Nonnull)checkDigitNumber dayOfBirth:(NSString * _Nonnull)dayOfBirth checkDigitDayOfBirth:(NSString * _Nonnull)checkDigitDayOfBirth sex:(NSString * _Nonnull)sex expirationDate:(NSString * _Nonnull)expirationDate checkDigitExpirationDate:(NSString * _Nonnull)checkdigitExpirationDate personalNumber:(NSString * _Nonnull)personalNumber checkDigitPersonalNumber:(NSString * _Nonnull)checkDigitPersonalNumber checkDigitFinal:(NSString * _Nonnull)checkDigitFinal personalNumber2:(NSString * _Nonnull)personalNumber2 MRZString:(NSString * _Nonnull)MRZString;
        [Export("initWithDocumentType:issuingCountryCode:nationalityCountryCode:surNames:givenNames:documentNumber:checkDigitNumber:dayOfBirth:checkDigitDayOfBirth:sex:expirationDate:checkDigitExpirationDate:personalNumber:checkDigitPersonalNumber:checkDigitFinal:personalNumber2:MRZString:")]
        IntPtr Constructor(string documentType, string issuingCountryCode, string nationalityCountryCode, string surNames, string givenNames, string documentNumber, string checkDigitNumber, string dayOfBirth, string checkDigitDayOfBirth, string sex, string expirationDate, string checkdigitExpirationDate, string personalNumber, string checkDigitPersonalNumber, string checkDigitFinal, string personalNumber2, string MRZString);
    }

    // @interface ALMRZResult : ALScanResult
    [BaseType(typeof(ALScanResult))]
    interface ALMRZResult
    {
        // @property (readonly, assign, nonatomic) BOOL allCheckDigitsValid;
        [Export("allCheckDigitsValid")]
        bool AllCheckDigitsValid { get; }

        // -(instancetype _Nullable)initWithResult:(ALIdentification * _Nonnull)result image:(UIImage * _Nonnull)image fullImage:(UIImage * _Nullable)fullImage confidence:(NSInteger)confidence pluginID:(NSString * _Nonnull)pluginID allCheckDigitsValid:(BOOL)allCheckDigitsValid;
        [Export("initWithResult:image:fullImage:confidence:pluginID:allCheckDigitsValid:")]
        IntPtr Constructor(ALIdentification result, UIImage image, [NullAllowed] UIImage fullImage, nint confidence, string pluginID, bool allCheckDigitsValid);
    }

    // @interface ALMRZScanPlugin : ALAbstractScanPlugin
    [BaseType(typeof(ALAbstractScanPlugin))]
    interface ALMRZScanPlugin
    {
        // @property (readonly, nonatomic, strong) NSHashTable<ALMRZScanPluginDelegate> * _Nullable delegates;
        [NullAllowed, Export("delegates", ArgumentSemantic.Strong)]
        ALMRZScanPluginDelegate Delegates { get; }

        // -(BOOL)setupWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<ALMRZScanPluginDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // -(void)addDelegate:(id<ALMRZScanPluginDelegate> _Nonnull)delegate;
        [Export("addDelegate:")]
        void AddDelegate(ALMRZScanPluginDelegate @delegate);

        // -(void)removeDelegate:(id<ALMRZScanPluginDelegate> _Nonnull)delegate;
        [Export("removeDelegate:")]
        void RemoveDelegate(ALMRZScanPluginDelegate @delegate);
    }

    // @protocol ALMRZScanPluginDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALMRZScanPluginDelegate
    {
        // @required -(void)anylineMRZScanPlugin:(ALMRZScanPlugin * _Nonnull)anylineMRZScanPlugin didFindResult:(ALMRZResult * _Nonnull)scanResult;
        [Abstract]
        [Export("anylineMRZScanPlugin:didFindResult:")]
        void DidFindResult(ALMRZScanPlugin anylineMRZScanPlugin, ALMRZResult scanResult);
    }

    // @interface ALMRZScanViewPlugin : ALAbstractScanViewPlugin
    [BaseType(typeof(ALAbstractScanViewPlugin))]
    interface ALMRZScanViewPlugin
    {
        // @property (nonatomic, strong) ALMRZScanPlugin * _Nullable mrzScanPlugin;
        [NullAllowed, Export("mrzScanPlugin", ArgumentSemantic.Strong)]
        ALMRZScanPlugin MrzScanPlugin { get; set; }

        // -(instancetype _Nullable)initWithFrame:(CGRect)frame scanPlugin:(ALMRZScanPlugin * _Nonnull)mrzScanPlugin;
        [Export("initWithFrame:scanPlugin:")]
        IntPtr Constructor(CGRect frame, ALMRZScanPlugin mrzScanPlugin);
    }

    // @interface AnylineMRZModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineMRZModuleView
    {
        // @property (nonatomic, strong) ALMRZScanViewPlugin * mrzScanViewPlugin;
        [Export("mrzScanViewPlugin", ArgumentSemantic.Strong)]
        ALMRZScanViewPlugin MrzScanViewPlugin { get; set; }

        // @property (nonatomic, strong) ALMRZScanPlugin * mrzScanPlugin;
        [Export("mrzScanPlugin", ArgumentSemantic.Strong)]
        ALMRZScanPlugin MrzScanPlugin { get; set; }

        // -(BOOL)setupWithLicenseKey:(NSString *)licenseKey delegate:(id<AnylineMRZModuleDelegate>)delegate error:(NSError **)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, out NSError error);
    }

    // @protocol AnylineMRZModuleDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineMRZModuleDelegate
    {
        // @optional -(void)anylineMRZModuleView:(AnylineMRZModuleView *)anylineMRZModuleView didFindScanResult:(ALIdentification *)scanResult allCheckDigitsValid:(BOOL)allCheckDigitsValid atImage:(UIImage *)image __attribute__((deprecated("Deprecated since 3.10. Use method anylineMRZModuleView:didFindScanResult: instead.")));
        [Export("anylineMRZModuleView:didFindScanResult:allCheckDigitsValid:atImage:")]
        void DidFindScanResult(AnylineMRZModuleView anylineMRZModuleView, ALIdentification scanResult, bool allCheckDigitsValid, UIImage image);

        // @required -(void)anylineMRZModuleView:(AnylineMRZModuleView *)anylineMRZModuleView didFindResult:(ALMRZResult *)scanResult;
        [Abstract]
        [Export("anylineMRZModuleView:didFindResult:")]
        void DidFindResult(AnylineMRZModuleView anylineMRZModuleView, ALMRZResult scanResult);
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

    [Static]
    partial interface ALOCRConstants
    {
        // extern NSString *const _Nonnull regexForEmail;
        [Field("regexForEmail", "__Internal")]
        NSString RegexForEmail { get; }

        // extern NSString *const _Nonnull regexForURL;
        [Field("regexForURL", "__Internal")]
        NSString RegexForURL { get; }

        // extern NSString *const _Nonnull regexForPriceTag;
        [Field("regexForPriceTag", "__Internal")]
        NSString RegexForPriceTag { get; }

        // extern NSString *const _Nonnull regexForISBN;
        [Field("regexForISBN", "__Internal")]
        NSString RegexForISBN { get; }

        // extern NSString *const _Nonnull regexForVIN;
        [Field("regexForVIN", "__Internal")]
        NSString RegexForVIN { get; }

        // extern NSString *const _Nonnull regexForIMEI;
        [Field("regexForIMEI", "__Internal")]
        NSString RegexForIMEI { get; }

        // extern NSString *const _Nonnull charWhiteListForEmail;
        [Field("charWhiteListForEmail", "__Internal")]
        NSString CharWhiteListForEmail { get; }

        // extern NSString *const _Nonnull charWhiteListForURL;
        [Field("charWhiteListForURL", "__Internal")]
        NSString CharWhiteListForURL { get; }

        // extern NSString *const _Nonnull charWhiteListForPriceTag;
        [Field("charWhiteListForPriceTag", "__Internal")]
        NSString CharWhiteListForPriceTag { get; }

        // extern NSString *const _Nonnull charWhiteListForISBN;
        [Field("charWhiteListForISBN", "__Internal")]
        NSString CharWhiteListForISBN { get; }

        // extern NSString *const _Nonnull charWhiteListForVIN;
        [Field("charWhiteListForVIN", "__Internal")]
        NSString CharWhiteListForVIN { get; }

        // extern NSString *const _Nonnull charWhiteListForIMEI;
        [Field("charWhiteListForIMEI", "__Internal")]
        NSString CharWhiteListForIMEI { get; }
    }

    // @interface ALOCRConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface ALOCRConfig
    {
        // -(instancetype _Nullable)initWithJsonDictionary:(NSDictionary * _Nonnull)configDict;
        [Export("initWithJsonDictionary:")]
        IntPtr Constructor(NSDictionary configDict);

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

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable tesseractLanguages;
        [NullAllowed, Export("tesseractLanguages", ArgumentSemantic.Strong)]
        string[] TesseractLanguages { get; set; }

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
    }

    // @interface ALOCRScanPlugin : ALAbstractScanPlugin
    [BaseType(typeof(ALAbstractScanPlugin))]
    interface ALOCRScanPlugin
    {
        // @property (readonly, nonatomic, strong) NSHashTable<ALOCRScanPluginDelegate> * _Nullable delegates;
        [NullAllowed, Export("delegates", ArgumentSemantic.Strong)]
        ALOCRScanPluginDelegate Delegates { get; }

        // @property (readonly, nonatomic, strong) ALOCRConfig * _Nullable ocrConfig;
        [NullAllowed, Export("ocrConfig", ArgumentSemantic.Strong)]
        ALOCRConfig OcrConfig { get; }

        // -(BOOL)setupWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<ALOCRScanPluginDelegate> _Nonnull)delegate ocrConfig:(ALOCRConfig * _Nonnull)ocrConfig error:(NSError * _Nullable * _Nullable)error;
        [Export("setupWithLicenseKey:delegate:ocrConfig:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, ALOCRConfig ocrConfig, [NullAllowed] out NSError error);

        // -(BOOL)setOCRConfig:(ALOCRConfig * _Nonnull)ocrConfig error:(NSError * _Nullable * _Nullable)error;
        [Export("setOCRConfig:error:")]
        bool SetOCRConfig(ALOCRConfig ocrConfig, [NullAllowed] out NSError error);

        // -(BOOL)copyTrainedData:(NSString * _Nonnull)trainedDataPath fileHash:(NSString * _Nullable)hash error:(NSError * _Nullable * _Nullable)error;
        [Export("copyTrainedData:fileHash:error:")]
        bool CopyTrainedData(string trainedDataPath, [NullAllowed] string hash, [NullAllowed] out NSError error);

        // -(void)addDelegate:(id<ALOCRScanPluginDelegate> _Nonnull)delegate;
        [Export("addDelegate:")]
        void AddDelegate(ALOCRScanPluginDelegate @delegate);

        // -(void)removeDelegate:(id<ALOCRScanPluginDelegate> _Nonnull)delegate;
        [Export("removeDelegate:")]
        void RemoveDelegate(ALOCRScanPluginDelegate @delegate);
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

        // -(instancetype _Nullable)initWithFrame:(CGRect)frame scanPlugin:(ALOCRScanPlugin * _Nonnull)ocrScanPlugin;
        [Export("initWithFrame:scanPlugin:")]
        IntPtr Constructor(CGRect frame, ALOCRScanPlugin ocrScanPlugin);
    }

    // @interface AnylineOCRModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineOCRModuleView
    {
        // @property (nonatomic, strong) ALOCRScanViewPlugin * ocrScanViewPlugin;
        [Export("ocrScanViewPlugin", ArgumentSemantic.Strong)]
        ALOCRScanViewPlugin OcrScanViewPlugin { get; set; }

        // @property (nonatomic, strong) ALOCRScanPlugin * ocrScanPlugin;
        [Export("ocrScanPlugin", ArgumentSemantic.Strong)]
        ALOCRScanPlugin OcrScanPlugin { get; set; }

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
        [Export("anylineOCRModuleView:didFindResult:")]
        [Abstract]
        void DidFindResult(AnylineOCRModuleView anylineOCRModuleView, ALOCRResult result);

        // @optional -(void)anylineOCRModuleView:(AnylineOCRModuleView *)anylineOCRModuleView reportsVariable:(NSString *)variableName value:(id)value __attribute__((deprecated("Deprecated since 3.10 Use AnylineDebugDelegate instead.")));
        [Export("anylineOCRModuleView:reportsVariable:value:")]
        [Abstract]
        void ReportsVariable(AnylineOCRModuleView anylineOCRModuleView, string variableName, NSObject value);

        // @optional -(void)anylineOCRModuleView:(AnylineOCRModuleView *)anylineOCRModuleView reportsRunFailure:(ALOCRError)error __attribute__((deprecated("Deprecated since 3.10 Use AnylineDebugDelegate instead.")));
        [Export("anylineOCRModuleView:reportsRunFailure:")]
        [Abstract]
        void ReportsRunFailure(AnylineOCRModuleView anylineOCRModuleView, ALOCRError error);

        // @optional -(BOOL)anylineOCRModuleView:(AnylineOCRModuleView *)anylineOCRModuleView textOutlineDetected:(ALSquare *)outline __attribute__((deprecated("Deprecated since 3.10 Use AnylineDebugDelegate instead.")));
        [Export("anylineOCRModuleView:textOutlineDetected:")]
        [Abstract]
        bool TextOutlineDetected(AnylineOCRModuleView anylineOCRModuleView, ALSquare outline);
    }

    [Static]
    partial interface ALDocumentConstants
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
    interface ALDocumentScanPlugin
    {
        // @property (readonly, nonatomic, strong) NSHashTable<ALDocumentScanPluginDelegate> * _Nullable delegates;
        [NullAllowed, Export("delegates", ArgumentSemantic.Strong)]
        ALDocumentScanPluginDelegate Delegates { get; }

        // @property (readonly, nonatomic, strong) NSHashTable<ALDocumentInfoDelegate> * _Nullable infoDelegates;
        [NullAllowed, Export("infoDelegates", ArgumentSemantic.Strong)]
        ALDocumentInfoDelegate InfoDelegates { get; }

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
        ALImageProvider ImageProvider { get; set; }

        // @property (assign, nonatomic) BOOL justDetectCornersIfPossible;
        [Export("justDetectCornersIfPossible")]
        bool JustDetectCornersIfPossible { get; set; }

        // -(instancetype _Nullable)initWithPluginID:(NSString * _Nullable)pluginID __attribute__((objc_designated_initializer));
        [Export("initWithPluginID:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string pluginID);

        // -(BOOL)start:(id<ALImageProvider> _Nonnull)imageProvider error:(NSError * _Nullable * _Nullable)error;
        [Export("start:error:")]
        bool Start(ALImageProvider imageProvider, [NullAllowed] out NSError error);

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

        // -(BOOL)setupWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<ALDocumentScanPluginDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // @property (nonatomic, strong) NSNumber * _Nonnull maxDocumentRatioDeviation;
        [Export("maxDocumentRatioDeviation", ArgumentSemantic.Strong)]
        NSNumber MaxDocumentRatioDeviation { get; set; }

        // @property (nonatomic, strong) NSArray<NSNumber *> * _Nullable documentRatios;
        [NullAllowed, Export("documentRatios", ArgumentSemantic.Strong)]
        NSNumber[] DocumentRatios { get; set; }

        // -(void)addDelegate:(id<ALDocumentScanPluginDelegate> _Nonnull)delegate;
        [Export("addDelegate:")]
        void AddDelegate(ALDocumentScanPluginDelegate @delegate);

        // -(void)removeDelegate:(id<ALDocumentScanPluginDelegate> _Nonnull)delegate;
        [Export("removeDelegate:")]
        void RemoveDelegate(ALDocumentScanPluginDelegate @delegate);

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

        // -(instancetype _Nullable)initWithFrame:(CGRect)frame scanPlugin:(ALDocumentScanPlugin * _Nonnull)documentScanPlugin;
        [Export("initWithFrame:scanPlugin:")]
        IntPtr Constructor(CGRect frame, ALDocumentScanPlugin documentScanPlugin);
    }

    // @interface AnylineDocumentModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineDocumentModuleView
    {
        // @property (nonatomic, strong) ALDocumentScanViewPlugin * documentScanViewPlugin;
        [Export("documentScanViewPlugin", ArgumentSemantic.Strong)]
        ALDocumentScanViewPlugin DocumentScanViewPlugin { get; set; }

        // @property (nonatomic, strong) ALDocumentScanPlugin * documentScanPlugin;
        [Export("documentScanPlugin", ArgumentSemantic.Strong)]
        ALDocumentScanPlugin DocumentScanPlugin { get; set; }

        // -(BOOL)setupWithLicenseKey:(NSString *)licenseKey delegate:(id<AnylineDocumentModuleDelegate>)delegate error:(NSError **)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, out NSError error);

        // @property (nonatomic, strong) NSNumber * maxDocumentRatioDeviation;
        [Export("maxDocumentRatioDeviation", ArgumentSemantic.Strong)]
        NSNumber MaxDocumentRatioDeviation { get; set; }

        // -(void)setDocumentRatios:(NSArray<NSNumber *> *)ratios;
        [Export("setDocumentRatios:")]
        void SetDocumentRatios(NSNumber[] ratios);

        // -(BOOL)triggerPictureCornerDetectionAndReturnError:(NSError **)error;
        [Export("triggerPictureCornerDetectionAndReturnError:")]
        bool TriggerPictureCornerDetectionAndReturnError(out NSError error);

        // -(BOOL)transformImageWithSquare:(ALSquare * _Nullable)square image:(UIImage * _Nullable)image error:(NSError * _Nullable * _Nullable)error;
        [Export("transformImageWithSquare:image:error:")]
        bool TransformImageWithSquare([NullAllowed] ALSquare square, [NullAllowed] UIImage image, [NullAllowed] out NSError error);

        // -(BOOL)transformALImageWithSquare:(ALSquare * _Nullable)square image:(ALImage * _Nullable)image error:(NSError * _Nullable * _Nullable)error;
        [Export("transformALImageWithSquare:image:error:")]
        bool TransformALImageWithSquare([NullAllowed] ALSquare square, [NullAllowed] ALImage image, [NullAllowed] out NSError error);

        // since 3.19: @property(nonatomic, assign) CGSize maxOutputResolution;
        [Export("maxOutputResolution:"), ArgumentSemantic.Assign]
        CGSize MaxOutputResolution { get; set; }
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
    interface ALLicensePlateScanPlugin
    {
        // -(BOOL)setupWithLicenseKey:(NSString * _Nonnull)licenseKey delegate:(id<ALLicensePlateScanPluginDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, [NullAllowed] out NSError error);

        // -(void)addDelegate:(id<ALLicensePlateScanPluginDelegate> _Nonnull)delegate;
        [Export("addDelegate:")]
        void AddDelegate(ALLicensePlateScanPluginDelegate @delegate);

        // -(void)removeDelegate:(id<ALLicensePlateScanPluginDelegate> _Nonnull)delegate;
        [Export("removeDelegate:")]
        void RemoveDelegate(ALLicensePlateScanPluginDelegate @delegate);
    }

    // @protocol ALLicensePlateScanPluginDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ALLicensePlateScanPluginDelegate
    {
        // @required -(void)anylineLicensePlateScanPlugin:(ALLicensePlateScanPlugin * _Nonnull)anylineLicensePlateScanPlugin didFindResult:(ALLicensePlateResult * _Nonnull)result;
        [Abstract]
        [Export("anylineLicensePlateScanPlugin:didFindResult:")]
        void DidFindResult(ALLicensePlateScanPlugin anylineLicensePlateScanPlugin, ALLicensePlateResult result);
    }

    // @interface ALLicensePlateScanViewPlugin : ALAbstractScanViewPlugin
    [BaseType(typeof(ALAbstractScanViewPlugin))]
    interface ALLicensePlateScanViewPlugin
    {
        // @property (nonatomic, strong) ALLicensePlateScanPlugin * _Nullable licensePlateScanPlugin;
        [NullAllowed, Export("licensePlateScanPlugin", ArgumentSemantic.Strong)]
        ALLicensePlateScanPlugin LicensePlateScanPlugin { get; set; }

        // -(instancetype _Nullable)initWithFrame:(CGRect)frame scanPlugin:(ALLicensePlateScanPlugin * _Nonnull)licensePlateScanPlugin;
        [Export("initWithFrame:scanPlugin:")]
        IntPtr Constructor(CGRect frame, ALLicensePlateScanPlugin licensePlateScanPlugin);
    }

    // @interface AnylineLicensePlateModuleView : AnylineAbstractModuleView
    [BaseType(typeof(AnylineAbstractModuleView))]
    interface AnylineLicensePlateModuleView
    {
        // @property (nonatomic, strong) ALLicensePlateScanPlugin * licensePlateScanPlugin;
        [Export("licensePlateScanPlugin", ArgumentSemantic.Strong)]
        ALLicensePlateScanPlugin LicensePlateScanPlugin { get; set; }

        // @property (nonatomic, strong) ALLicensePlateScanViewPlugin * licensePlateScanViewPlugin;
        [Export("licensePlateScanViewPlugin", ArgumentSemantic.Strong)]
        ALLicensePlateScanViewPlugin LicensePlateScanViewPlugin { get; set; }

        // -(BOOL)setupWithLicenseKey:(NSString *)licenseKey delegate:(id<AnylineLicensePlateModuleDelegate>)delegate error:(NSError **)error;
        [Export("setupWithLicenseKey:delegate:error:")]
        bool SetupWithLicenseKey(string licenseKey, NSObject @delegate, out NSError error);
    }

    // @protocol AnylineLicensePlateModuleDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AnylineLicensePlateModuleDelegate
    {
        // @required -(void)anylineLicensePlateModuleView:(AnylineLicensePlateModuleView *)anylineLicensePlateModuleView didFindResult:(ALLicensePlateResult *)scanResult;
        [Abstract]
        [Export("anylineLicensePlateModuleView:didFindResult:")]
        void DidFindResult(AnylineLicensePlateModuleView anylineLicensePlateModuleView, ALLicensePlateResult scanResult);
    }
}