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
    
    // @protocol ALJSONStringRepresentable <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface ALJSONStringRepresentable : INativeObject
    {
        // @required -(NSString * _Nullable)toJSONStringPretty:(BOOL)isPretty error:(NSError * _Nullable * _Nullable)error;
        [Abstract]
        [Export ("toJSONStringPretty:error:")]
        [return: NullAllowed]
        string ToJSONStringPretty (bool isPretty, [NullAllowed] out NSError error);

        // @required -(NSString * _Nullable)toJSONString:(NSError * _Nullable * _Nullable)error;
        [Abstract]
        [Export ("toJSONString:")]
        [return: NullAllowed]
        string ToJSONString ([NullAllowed] out NSError error);

        // @required -(NSString * _Nonnull)asJSONStringPretty:(BOOL)isPretty;
        [Abstract]
        [Export ("asJSONStringPretty:")]
        string AsJSONStringPretty (bool isPretty);

        // @required -(NSString * _Nonnull)asJSONString;
        [Abstract]
        [Export ("asJSONString")]
		string AsJSONString();
    }

    // @interface ALJSONExtras (NSData)
    [Category]
    [BaseType (typeof(NSData))]
    interface NSData_ALJSONExtras
    {
        // -(id _Nullable)toJSONObject:(NSError * _Nullable * _Nullable)error;
        [Export ("toJSONObject:")]
        [return: NullAllowed]
        NSObject ToJSONObject ([NullAllowed] out NSError error);

        // -(id _Nullable)asJSONObject;
        [Export ("asJSONObject")]
        NSObject AsJSONObject();
    }

    // @interface ALJSONExtras (NSString)
    [Category]
    [BaseType (typeof(NSString))]
    interface NSString_ALJSONExtras
    {
        // -(id _Nullable)toJSONObject:(NSError * _Nullable * _Nullable)error;
        [Export ("toJSONObject:")]
        [return: NullAllowed]
        NSObject ToJSONObject ([NullAllowed] out NSError error);

        // -(id _Nullable)asJSONObject;
        [Export ("asJSONObject")]
        NSObject AsJSONObject();
    }

    // @interface ALJSONExtras (NSDictionary) <ALJSONStringRepresentable>
    [Protocol, Model]
    [BaseType (typeof(NSDictionary))]
    interface NSDictionary_ALJSONExtras : ALJSONStringRepresentable
    {
    }

    // @interface ALJSONExtras (NSArray) <ALJSONStringRepresentable>
    [Protocol, Model]
    [BaseType (typeof(NSArray))]
    interface NSArray_ALJSONExtras : ALJSONStringRepresentable
    {
    }

    // @interface ALCameraConfig : NSObject <ALJSONStringRepresentable>
    [BaseType (typeof(NSObject))]
    interface ALCameraConfig : ALJSONStringRepresentable
    {
        // @property (readonly, nonatomic) NSString * _Nullable defaultCamera;
        [NullAllowed, Export ("defaultCamera")]
        string DefaultCamera { get; }

        // @property (readonly, nonatomic) ALCaptureViewResolution captureResolution;
        [Export ("captureResolution")]
        ALCaptureViewResolution CaptureResolution { get; }

        // @property (readonly, nonatomic) ALPictureResolution pictureResolution;
        [Export ("pictureResolution")]
        ALPictureResolution PictureResolution { get; }

        // @property (readonly, nonatomic) CGFloat zoomFactor;
        [Export ("zoomFactor")]
        nfloat ZoomFactor { get; }

        // @property (readonly, nonatomic) CGFloat maxZoomFactor;
        [Export ("maxZoomFactor")]
        nfloat MaxZoomFactor { get; }

        // @property (readonly, nonatomic) BOOL zoomGesture;
        [Export ("zoomGesture")]
        bool ZoomGesture { get; }

        // -(instancetype _Nullable)initWithJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONDictionary:error:")]
        IntPtr Constructor (NSDictionary JSONDictionary, [NullAllowed] out NSError error);

        // +(instancetype _Nullable)withJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary;
        [Static]
        [Export ("withJSONDictionary:")]
        [return: NullAllowed]
        ALCameraConfig WithJSONDictionary (NSDictionary JSONDictionary);

        // +(instancetype _Nonnull)defaultCameraConfig;
        [Static]
        [Export ("defaultCameraConfig")]
        ALCameraConfig DefaultCameraConfig ();

        // -(instancetype _Nonnull)initWithDefaultCamera:(NSString * _Nonnull)defaultCamera captureViewResolution:(ALCaptureViewResolution)captureResolution pictureResolution:(ALPictureResolution)pictureResolution zoomFactor:(CGFloat)zoomFactor maxZoomFactor:(CGFloat)maxZoomFactor zoomGesture:(BOOL)zoomGesture __attribute__((objc_designated_initializer));
        [Export ("initWithDefaultCamera:captureViewResolution:pictureResolution:zoomFactor:maxZoomFactor:zoomGesture:")]
        [DesignatedInitializer]
        IntPtr Constructor (string defaultCamera, ALCaptureViewResolution captureResolution, ALPictureResolution pictureResolution, nfloat zoomFactor, nfloat maxZoomFactor, bool zoomGesture);

        // +(ALCameraConfig * _Nonnull)withDefaultCamera:(NSString * _Nonnull)defaultCamera captureViewResolution:(ALCaptureViewResolution)captureResolution pictureResolution:(ALPictureResolution)pictureResolution zoomFactor:(CGFloat)zoomFactor maxZoomFactor:(CGFloat)maxZoomFactor zoomGesture:(BOOL)zoomGesture;
        [Static]
        [Export ("withDefaultCamera:captureViewResolution:pictureResolution:zoomFactor:maxZoomFactor:zoomGesture:")]
        ALCameraConfig WithDefaultCamera (string defaultCamera, ALCaptureViewResolution captureResolution, ALPictureResolution pictureResolution, nfloat zoomFactor, nfloat maxZoomFactor, bool zoomGesture);
    }

    // @interface ALFlashConfig : NSObject <ALJSONStringRepresentable>
    [BaseType (typeof(NSObject))]
    interface ALFlashConfig : ALJSONStringRepresentable
    {
        // @property (readonly, nonatomic) ALFlashMode flashMode;
        [Export ("flashMode")]
        ALFlashMode FlashMode { get; }

        // @property (readonly, nonatomic) ALFlashAlignment flashAlignment;
        [Export ("flashAlignment")]
        ALFlashAlignment FlashAlignment { get; }

        // @property (readonly, nonatomic) UIImage * _Nullable flashImage;
        [NullAllowed, Export ("flashImage")]
        UIImage FlashImage { get; }

        // @property (readonly, nonatomic) CGPoint flashOffset;
        [Export ("flashOffset")]
        CGPoint FlashOffset { get; }

        // -(instancetype _Nullable)initWithJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONDictionary:error:")]
        IntPtr Constructor (NSDictionary JSONDictionary, [NullAllowed] out NSError error);

        // +(instancetype _Nullable)withJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary;
        [Static]
        [Export ("withJSONDictionary:")]
        [return: NullAllowed]
        ALFlashConfig WithJSONDictionary (NSDictionary JSONDictionary);

        // +(instancetype _Nonnull)defaultFlashConfig;
        [Static]
        [Export ("defaultFlashConfig")]
        ALFlashConfig DefaultFlashConfig ();

        // -(instancetype _Nullable)initWithFlashMode:(ALFlashMode)flashMode flashAlignment:(ALFlashAlignment)flashAlignment flashImageName:(NSString * _Nullable)flashImageName flashOffset:(CGPoint)flashOffset __attribute__((objc_designated_initializer));
        [Export ("initWithFlashMode:flashAlignment:flashImageName:flashOffset:")]
        [DesignatedInitializer]
        IntPtr Constructor (ALFlashMode flashMode, ALFlashAlignment flashAlignment, [NullAllowed] string flashImageName, CGPoint flashOffset);

        // +(ALFlashConfig * _Nullable)withFlashMode:(ALFlashMode)flashMode flashAlignment:(ALFlashAlignment)flashAlignment flashImageName:(NSString * _Nullable)flashImageName flashOffset:(CGPoint)flashOffset;
        [Static]
        [Export ("withFlashMode:flashAlignment:flashImageName:flashOffset:")]
	    [return: NullAllowed]
        ALFlashConfig WithFlashMode (ALFlashMode flashMode, ALFlashAlignment flashAlignment, [NullAllowed] string flashImageName, CGPoint flashOffset);
    }

    // @interface ALBarcodeFormat : NSObject
    [BaseType (typeof(NSObject))]
    interface ALBarcodeFormat
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
        [Export ("value")]
        string Value { get; }

        // +(instancetype _Nullable)withValue:(NSString * _Nonnull)value;
        [Static]
        [Export ("withValue:")]
        [return: NullAllowed]
        ALBarcodeFormat WithValue (string value);

        // +(ALBarcodeFormat * _Nonnull)all;
        [Static]
        [Export ("all")]
        ALBarcodeFormat All { get; }

        // +(ALBarcodeFormat * _Nonnull)aztec;
        [Static]
        [Export ("aztec")]
        ALBarcodeFormat Aztec { get; }

        // +(ALBarcodeFormat * _Nonnull)aztecInverse;
        [Static]
        [Export ("aztecInverse")]
        ALBarcodeFormat AztecInverse { get; }

        // +(ALBarcodeFormat * _Nonnull)bookland;
        [Static]
        [Export ("bookland")]
        ALBarcodeFormat Bookland { get; }

        // +(ALBarcodeFormat * _Nonnull)codabar;
        [Static]
        [Export ("codabar")]
        ALBarcodeFormat Codabar { get; }

        // +(ALBarcodeFormat * _Nonnull)code11;
        [Static]
        [Export ("code11")]
        ALBarcodeFormat Code11 { get; }

        // +(ALBarcodeFormat * _Nonnull)code128;
        [Static]
        [Export ("code128")]
        ALBarcodeFormat Code128 { get; }

        // +(ALBarcodeFormat * _Nonnull)code32;
        [Static]
        [Export ("code32")]
        ALBarcodeFormat Code32 { get; }

        // +(ALBarcodeFormat * _Nonnull)code39;
        [Static]
        [Export ("code39")]
        ALBarcodeFormat Code39 { get; }

        // +(ALBarcodeFormat * _Nonnull)code93;
        [Static]
        [Export ("code93")]
        ALBarcodeFormat Code93 { get; }

        // +(ALBarcodeFormat * _Nonnull)coupon;
        [Static]
        [Export ("coupon")]
        ALBarcodeFormat Coupon { get; }

        // +(ALBarcodeFormat * _Nonnull)dataMatrix;
        [Static]
        [Export ("dataMatrix")]
        ALBarcodeFormat DataMatrix { get; }

        // +(ALBarcodeFormat * _Nonnull)databar;
        [Static]
        [Export ("databar")]
        ALBarcodeFormat Databar { get; }

        // +(ALBarcodeFormat * _Nonnull)discrete2_5;
        [Static]
        [Export ("discrete2_5")]
        ALBarcodeFormat Discrete2_5 { get; }

        // +(ALBarcodeFormat * _Nonnull)dotCode;
        [Static]
        [Export ("dotCode")]
        ALBarcodeFormat DotCode { get; }

        // +(ALBarcodeFormat * _Nonnull)ean13;
        [Static]
        [Export ("ean13")]
        ALBarcodeFormat Ean13 { get; }

        // +(ALBarcodeFormat * _Nonnull)ean8;
        [Static]
        [Export ("ean8")]
        ALBarcodeFormat Ean8 { get; }

        // +(ALBarcodeFormat * _Nonnull)gs1128;
        [Static]
        [Export ("gs1128")]
        ALBarcodeFormat Gs1128 { get; }

        // +(ALBarcodeFormat * _Nonnull)gs1QrCode;
        [Static]
        [Export ("gs1QrCode")]
        ALBarcodeFormat Gs1QrCode { get; }

        // +(ALBarcodeFormat * _Nonnull)isbt128;
        [Static]
        [Export ("isbt128")]
        ALBarcodeFormat Isbt128 { get; }

        // +(ALBarcodeFormat * _Nonnull)issnEan;
        [Static]
        [Export ("issnEan")]
        ALBarcodeFormat IssnEan { get; }

        // +(ALBarcodeFormat * _Nonnull)itf;
        [Static]
        [Export ("itf")]
        ALBarcodeFormat Itf { get; }

        // +(ALBarcodeFormat * _Nonnull)kix;
        [Static]
        [Export ("kix")]
        ALBarcodeFormat Kix { get; }

        // +(ALBarcodeFormat * _Nonnull)matrix2_5;
        [Static]
        [Export ("matrix2_5")]
        ALBarcodeFormat Matrix2_5 { get; }

        // +(ALBarcodeFormat * _Nonnull)maxicode;
        [Static]
        [Export ("maxicode")]
        ALBarcodeFormat Maxicode { get; }

        // +(ALBarcodeFormat * _Nonnull)microPDF;
        [Static]
        [Export ("microPDF")]
        ALBarcodeFormat MicroPDF { get; }

        // +(ALBarcodeFormat * _Nonnull)microQr;
        [Static]
        [Export ("microQr")]
        ALBarcodeFormat MicroQr { get; }

        // +(ALBarcodeFormat * _Nonnull)msi;
        [Static]
        [Export ("msi")]
        ALBarcodeFormat Msi { get; }

        // +(ALBarcodeFormat * _Nonnull)oneDInverse;
        [Static]
        [Export ("oneDInverse")]
        ALBarcodeFormat OneDInverse { get; }

        // +(ALBarcodeFormat * _Nonnull)pdf417;
        [Static]
        [Export ("pdf417")]
        ALBarcodeFormat Pdf417 { get; }

        // +(ALBarcodeFormat * _Nonnull)postUk;
        [Static]
        [Export ("postUk")]
        ALBarcodeFormat PostUk { get; }

        // +(ALBarcodeFormat * _Nonnull)qrCode;
        [Static]
        [Export ("qrCode")]
        ALBarcodeFormat QrCode { get; }

        // +(ALBarcodeFormat * _Nonnull)qrInverse;
        [Static]
        [Export ("qrInverse")]
        ALBarcodeFormat QrInverse { get; }

        // +(ALBarcodeFormat * _Nonnull)rss14;
        [Static]
        [Export ("rss14")]
        ALBarcodeFormat Rss14 { get; }

        // +(ALBarcodeFormat * _Nonnull)rssExpanded;
        [Static]
        [Export ("rssExpanded")]
        ALBarcodeFormat RssExpanded { get; }

        // +(ALBarcodeFormat * _Nonnull)trioptic;
        [Static]
        [Export ("trioptic")]
        ALBarcodeFormat Trioptic { get; }

        // +(ALBarcodeFormat * _Nonnull)upcA;
        [Static]
        [Export ("upcA")]
        ALBarcodeFormat UpcA { get; }

        // +(ALBarcodeFormat * _Nonnull)upcE;
        [Static]
        [Export ("upcE")]
        ALBarcodeFormat UpcE { get; }

        // +(ALBarcodeFormat * _Nonnull)upcEanExtension;
        [Static]
        [Export ("upcEanExtension")]
        ALBarcodeFormat UpcEanExtension { get; }

        // +(ALBarcodeFormat * _Nonnull)upuFics;
        [Static]
        [Export ("upuFics")]
        ALBarcodeFormat UpuFics { get; }

        // +(ALBarcodeFormat * _Nonnull)usPlanet;
        [Static]
        [Export ("usPlanet")]
        ALBarcodeFormat UsPlanet { get; }

        // +(ALBarcodeFormat * _Nonnull)usPostnet;
        [Static]
        [Export ("usPostnet")]
        ALBarcodeFormat UsPostnet { get; }

        // +(ALBarcodeFormat * _Nonnull)usps4Cb;
        [Static]
        [Export ("usps4Cb")]
        ALBarcodeFormat Usps4Cb { get; }
    }

    // @interface ALUpsideDownMode : NSObject
    [BaseType (typeof(NSObject))]
    interface ALUpsideDownMode
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
        [Export ("value")]
        string Value { get; }

        // +(instancetype _Nullable)withValue:(NSString * _Nonnull)value;
        [Static]
        [Export ("withValue:")]
        [return: NullAllowed]
        ALUpsideDownMode WithValue (string value);

        // +(ALUpsideDownMode * _Nonnull)disabled;
        [Static]
        [Export ("disabled")]
        ALUpsideDownMode Disabled { get; }

        // +(ALUpsideDownMode * _Nonnull)enabled;
        [Static]
        [Export ("enabled")]
        ALUpsideDownMode Enabled { get; }

        // +(ALUpsideDownMode * _Nonnull)upsideDownModeAUTO;
        [Static]
        [Export ("upsideDownModeAUTO")]
        ALUpsideDownMode UpsideDownModeAUTO { get; }
    }

    // @interface ALContainerConfigScanMode : NSObject
    [BaseType (typeof(NSObject))]
    interface ALContainerConfigScanMode
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
        [Export ("value")]
        string Value { get; }

        // +(instancetype _Nullable)withValue:(NSString * _Nonnull)value;
        [Static]
        [Export ("withValue:")]
        [return: NullAllowed]
        ALContainerConfigScanMode WithValue (string value);

        // +(ALContainerConfigScanMode * _Nonnull)horizontal;
        [Static]
        [Export ("horizontal")]
        ALContainerConfigScanMode Horizontal { get; }

        // +(ALContainerConfigScanMode * _Nonnull)vertical;
        [Static]
        [Export ("vertical")]
        ALContainerConfigScanMode Vertical { get; }
    }
        
    // @interface ALMrzScanOption : NSObject
    [BaseType (typeof(NSObject))]
    interface ALMrzScanOption
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
        [Export ("value")]
        string Value { get; }

        // +(instancetype _Nullable)withValue:(NSString * _Nonnull)value;
        [Static]
        [Export ("withValue:")]
        [return: NullAllowed]
        ALMrzScanOption WithValue (string value);

        // +(ALMrzScanOption * _Nonnull)disabled;
        [Static]
        [Export ("disabled")]
        ALMrzScanOption Disabled { get; }

        // +(ALMrzScanOption * _Nonnull)mandatory;
        [Static]
        [Export ("mandatory")]
        ALMrzScanOption Mandatory { get; }

        // +(ALMrzScanOption * _Nonnull)mrzScanOptionDefault;
        [Static]
        [Export ("mrzScanOptionDefault")]
        ALMrzScanOption MrzScanOptionDefault { get; }

        // +(ALMrzScanOption * _Nonnull)optional;
        [Static]
        [Export ("optional")]
        ALMrzScanOption Optional { get; }
    }

    // @interface ALLicensePlateConfigScanMode : NSObject
    [BaseType (typeof(NSObject))]
    interface ALLicensePlateConfigScanMode
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
        [Export ("value")]
        string Value { get; }

        // +(instancetype _Nullable)withValue:(NSString * _Nonnull)value;
        [Static]
        [Export ("withValue:")]
        [return: NullAllowed]
        ALLicensePlateConfigScanMode WithValue (string value);

        // +(ALLicensePlateConfigScanMode * _Nonnull)africa;
        [Static]
        [Export ("africa")]
        ALLicensePlateConfigScanMode Africa { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)albania;
        [Static]
        [Export ("albania")]
        ALLicensePlateConfigScanMode Albania { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)andorra;
        [Static]
        [Export ("andorra")]
        ALLicensePlateConfigScanMode Andorra { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)armenia;
        [Static]
        [Export ("armenia")]
        ALLicensePlateConfigScanMode Armenia { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)austria;
        [Static]
        [Export ("austria")]
        ALLicensePlateConfigScanMode Austria { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)azerbaijan;
        [Static]
        [Export ("azerbaijan")]
        ALLicensePlateConfigScanMode Azerbaijan { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)belarus;
        [Static]
        [Export ("belarus")]
        ALLicensePlateConfigScanMode Belarus { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)belgium;
        [Static]
        [Export ("belgium")]
        ALLicensePlateConfigScanMode Belgium { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)bosniaandherzegovina;
        [Static]
        [Export ("bosniaandherzegovina")]
        ALLicensePlateConfigScanMode Bosniaandherzegovina { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)bulgaria;
        [Static]
        [Export ("bulgaria")]
        ALLicensePlateConfigScanMode Bulgaria { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)croatia;
        [Static]
        [Export ("croatia")]
        ALLicensePlateConfigScanMode Croatia { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)cyprus;
        [Static]
        [Export ("cyprus")]
        ALLicensePlateConfigScanMode Cyprus { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)czech;
        [Static]
        [Export ("czech")]
        ALLicensePlateConfigScanMode Czech { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)denmark;
        [Static]
        [Export ("denmark")]
        ALLicensePlateConfigScanMode Denmark { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)estonia;
        [Static]
        [Export ("estonia")]
        ALLicensePlateConfigScanMode Estonia { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)finland;
        [Static]
        [Export ("finland")]
        ALLicensePlateConfigScanMode Finland { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)france;
        [Static]
        [Export ("france")]
        ALLicensePlateConfigScanMode France { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)georgia;
        [Static]
        [Export ("georgia")]
        ALLicensePlateConfigScanMode Georgia { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)germany;
        [Static]
        [Export ("germany")]
        ALLicensePlateConfigScanMode Germany { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)greece;
        [Static]
        [Export ("greece")]
        ALLicensePlateConfigScanMode Greece { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)hungary;
        [Static]
        [Export ("hungary")]
        ALLicensePlateConfigScanMode Hungary { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)iceland;
        [Static]
        [Export ("iceland")]
        ALLicensePlateConfigScanMode Iceland { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)ireland;
        [Static]
        [Export ("ireland")]
        ALLicensePlateConfigScanMode Ireland { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)italy;
        [Static]
        [Export ("italy")]
        ALLicensePlateConfigScanMode Italy { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)latvia;
        [Static]
        [Export ("latvia")]
        ALLicensePlateConfigScanMode Latvia { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)liechtenstein;
        [Static]
        [Export ("liechtenstein")]
        ALLicensePlateConfigScanMode Liechtenstein { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)lithuania;
        [Static]
        [Export ("lithuania")]
        ALLicensePlateConfigScanMode Lithuania { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)luxembourg;
        [Static]
        [Export ("luxembourg")]
        ALLicensePlateConfigScanMode Luxembourg { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)malta;
        [Static]
        [Export ("malta")]
        ALLicensePlateConfigScanMode Malta { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)moldova;
        [Static]
        [Export ("moldova")]
        ALLicensePlateConfigScanMode Moldova { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)monaco;
        [Static]
        [Export ("monaco")]
        ALLicensePlateConfigScanMode Monaco { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)montenegro;
        [Static]
        [Export ("montenegro")]
        ALLicensePlateConfigScanMode Montenegro { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)netherlands;
        [Static]
        [Export ("netherlands")]
        ALLicensePlateConfigScanMode Netherlands { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)northmacedonia;
        [Static]
        [Export ("northmacedonia")]
        ALLicensePlateConfigScanMode Northmacedonia { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)norway;
        [Static]
        [Export ("norway")]
        ALLicensePlateConfigScanMode Norway { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)norwayspecial;
        [Static]
        [Export ("norwayspecial")]
        ALLicensePlateConfigScanMode Norwayspecial { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)poland;
        [Static]
        [Export ("poland")]
        ALLicensePlateConfigScanMode Poland { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)portugal;
        [Static]
        [Export ("portugal")]
        ALLicensePlateConfigScanMode Portugal { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)romania;
        [Static]
        [Export ("romania")]
        ALLicensePlateConfigScanMode Romania { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)russia;
        [Static]
        [Export ("russia")]
        ALLicensePlateConfigScanMode Russia { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)scanModeAuto;
        [Static]
        [Export ("scanModeAuto")]
        ALLicensePlateConfigScanMode ScanModeAuto { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)serbia;
        [Static]
        [Export ("serbia")]
        ALLicensePlateConfigScanMode Serbia { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)slovakia;
        [Static]
        [Export ("slovakia")]
        ALLicensePlateConfigScanMode Slovakia { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)slovenia;
        [Static]
        [Export ("slovenia")]
        ALLicensePlateConfigScanMode Slovenia { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)spain;
        [Static]
        [Export ("spain")]
        ALLicensePlateConfigScanMode Spain { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)sweden;
        [Static]
        [Export ("sweden")]
        ALLicensePlateConfigScanMode Sweden { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)switzerland;
        [Static]
        [Export ("switzerland")]
        ALLicensePlateConfigScanMode Switzerland { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)turkey;
        [Static]
        [Export ("turkey")]
        ALLicensePlateConfigScanMode Turkey { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)ukraine;
        [Static]
        [Export ("ukraine")]
        ALLicensePlateConfigScanMode Ukraine { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)unitedkingdom;
        [Static]
        [Export ("unitedkingdom")]
        ALLicensePlateConfigScanMode Unitedkingdom { get; }

        // +(ALLicensePlateConfigScanMode * _Nonnull)unitedstates;
        [Static]
        [Export ("unitedstates")]
        ALLicensePlateConfigScanMode Unitedstates { get; }
    }

    // @interface ALMeterConfigScanMode : NSObject
    [BaseType (typeof(NSObject))]
    interface ALMeterConfigScanMode
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
        [Export ("value")]
        string Value { get; }

        // +(instancetype _Nullable)withValue:(NSString * _Nonnull)value;
        [Static]
        [Export ("withValue:")]
        [return: NullAllowed]
        ALMeterConfigScanMode WithValue (string value);

        // +(ALMeterConfigScanMode * _Nonnull)autoAnalogDigitalMeter;
        [Static]
        [Export ("autoAnalogDigitalMeter")]
        ALMeterConfigScanMode AutoAnalogDigitalMeter { get; }

        // +(ALMeterConfigScanMode * _Nonnull)dialMeter;
        [Static]
        [Export ("dialMeter")]
        ALMeterConfigScanMode DialMeter { get; }

        // +(ALMeterConfigScanMode * _Nonnull)digitalMeter2_Experimental;
        [Static]
        [Export ("digitalMeter2_Experimental")]
        ALMeterConfigScanMode DigitalMeter2_Experimental { get; }

        // +(ALMeterConfigScanMode * _Nonnull)multiFieldDigitalMeter;
        [Static]
        [Export ("multiFieldDigitalMeter")]
        ALMeterConfigScanMode MultiFieldDigitalMeter { get; }
    }

    // @interface ALOcrConfigScanMode : NSObject
    [BaseType (typeof(NSObject))]
    interface ALOcrConfigScanMode
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
        [Export ("value")]
        string Value { get; }

        // +(instancetype _Nullable)withValue:(NSString * _Nonnull)value;
        [Static]
        [Export ("withValue:")]
        [return: NullAllowed]
        ALOcrConfigScanMode WithValue (string value);

        // +(ALOcrConfigScanMode * _Nonnull)grid;
        [Static]
        [Export ("grid")]
        ALOcrConfigScanMode Grid { get; }

        // +(ALOcrConfigScanMode * _Nonnull)line;
        [Static]
        [Export ("line")]
        ALOcrConfigScanMode Line { get; }

        // +(ALOcrConfigScanMode * _Nonnull)scanModeAuto;
        [Static]
        [Export ("scanModeAuto")]
        ALOcrConfigScanMode ScanModeAuto { get; }
    }

    // @interface ALTinConfigScanMode : NSObject
    [BaseType (typeof(NSObject))]
    interface ALTinConfigScanMode
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
        [Export ("value")]
        string Value { get; }

        // +(instancetype _Nullable)withValue:(NSString * _Nonnull)value;
        [Static]
        [Export ("withValue:")]
        [return: NullAllowed]
        ALTinConfigScanMode WithValue (string value);

        // +(ALTinConfigScanMode * _Nonnull)dot;
        [Static]
        [Export ("dot")]
        ALTinConfigScanMode Dot { get; }

        // +(ALTinConfigScanMode * _Nonnull)universal;
        [Static]
        [Export ("universal")]
        ALTinConfigScanMode Universal { get; }
    }

    // @interface ALAlphabet : NSObject
    [BaseType (typeof(NSObject))]
    interface ALAlphabet
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
        [Export ("value")]
        string Value { get; }

        // +(instancetype _Nullable)withValue:(NSString * _Nonnull)value;
        [Static]
        [Export ("withValue:")]
        [return: NullAllowed]
        ALAlphabet WithValue (string value);

        // +(ALAlphabet * _Nonnull)arabic;
        [Static]
        [Export ("arabic")]
        ALAlphabet Arabic { get; }

        // +(ALAlphabet * _Nonnull)cyrillic;
        [Static]
        [Export ("cyrillic")]
        ALAlphabet Cyrillic { get; }

        // +(ALAlphabet * _Nonnull)latin;
        [Static]
        [Export ("latin")]
        ALAlphabet Latin { get; }
    }

    // @interface ALPluginConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALPluginConfig
    {
        // @property (nonatomic, strong) ALBarcodeConfig * _Nullable barcodeConfig;
        [NullAllowed, Export ("barcodeConfig", ArgumentSemantic.Strong)]
        ALBarcodeConfig BarcodeConfig { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable cancelOnResult;
        [NullAllowed, Export ("cancelOnResult", ArgumentSemantic.Strong)]
        NSNumber CancelOnResult { get; set; }

        // @property (nonatomic, strong) ALCommercialTireIDConfig * _Nullable commercialTireIDConfig;
        [NullAllowed, Export ("commercialTireIDConfig", ArgumentSemantic.Strong)]
        ALCommercialTireIDConfig CommercialTireIDConfig { get; set; }

        // @property (nonatomic, strong) ALContainerConfig * _Nullable containerConfig;
        [NullAllowed, Export ("containerConfig", ArgumentSemantic.Strong)]
        ALContainerConfig ContainerConfig { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull identifier;
        [Export ("identifier")]
        string Identifier { get; set; }

        // @property (nonatomic, strong) ALJapaneseLandingPermissionConfig * _Nullable japaneseLandingPermissionConfig;
        [NullAllowed, Export ("japaneseLandingPermissionConfig", ArgumentSemantic.Strong)]
        ALJapaneseLandingPermissionConfig JapaneseLandingPermissionConfig { get; set; }

        // @property (nonatomic, strong) ALLicensePlateConfig * _Nullable licensePlateConfig;
        [NullAllowed, Export ("licensePlateConfig", ArgumentSemantic.Strong)]
        ALLicensePlateConfig LicensePlateConfig { get; set; }

        // @property (nonatomic, strong) ALMeterConfig * _Nullable meterConfig;
        [NullAllowed, Export ("meterConfig", ArgumentSemantic.Strong)]
        ALMeterConfig MeterConfig { get; set; }

        // @property (nonatomic, strong) ALMrzConfig * _Nullable mrzConfig;
        [NullAllowed, Export ("mrzConfig", ArgumentSemantic.Strong)]
        ALMrzConfig MrzConfig { get; set; }

        // @property (nonatomic, strong) ALOcrConfig * _Nullable ocrConfig;
        [NullAllowed, Export ("ocrConfig", ArgumentSemantic.Strong)]
        ALOcrConfig OcrConfig { get; set; }

        // @property (nonatomic, strong) ALOdometerConfig * _Nullable odometerConfig;
        [NullAllowed, Export ("odometerConfig", ArgumentSemantic.Strong)]
        ALOdometerConfig OdometerConfig { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable startScanDelay;
        [NullAllowed, Export ("startScanDelay", ArgumentSemantic.Strong)]
        NSNumber StartScanDelay { get; set; }

        // @property (copy, nonatomic) NSArray<ALStartVariable *> * _Nullable startVariables;
        [NullAllowed, Export ("startVariables", ArgumentSemantic.Copy)]
        ALStartVariable[] StartVariables { get; set; }

        // @property (nonatomic, strong) ALTinConfig * _Nullable tinConfig;
        [NullAllowed, Export ("tinConfig", ArgumentSemantic.Strong)]
        ALTinConfig TinConfig { get; set; }

        // @property (nonatomic, strong) ALTireMakeConfig * _Nullable tireMakeConfig;
        [NullAllowed, Export ("tireMakeConfig", ArgumentSemantic.Strong)]
        ALTireMakeConfig TireMakeConfig { get; set; }

        // @property (nonatomic, strong) ALTireSizeConfig * _Nullable tireSizeConfig;
        [NullAllowed, Export ("tireSizeConfig", ArgumentSemantic.Strong)]
        ALTireSizeConfig TireSizeConfig { get; set; }

        // @property (nonatomic, strong) ALUniversalIDConfig * _Nullable universalIDConfig;
        [NullAllowed, Export ("universalIDConfig", ArgumentSemantic.Strong)]
        ALUniversalIDConfig UniversalIDConfig { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateConfig * _Nullable vehicleRegistrationCertificateConfig;
        [NullAllowed, Export ("vehicleRegistrationCertificateConfig", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateConfig VehicleRegistrationCertificateConfig { get; set; }

        // @property (nonatomic, strong) ALVinConfig * _Nullable vinConfig;
        [NullAllowed, Export ("vinConfig", ArgumentSemantic.Strong)]
        ALVinConfig VinConfig { get; set; }

        // +(instancetype _Nullable)fromJSON:(NSString * _Nonnull)json encoding:(NSStringEncoding)encoding error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export ("fromJSON:encoding:error:")]
        [return: NullAllowed]
        ALPluginConfig FromJSON (string json, nuint encoding, [NullAllowed] out NSError error);

        // +(instancetype _Nullable)fromData:(NSData * _Nonnull)data error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export ("fromData:error:")]
        [return: NullAllowed]
        ALPluginConfig FromData (NSData data, [NullAllowed] out NSError error);

        // -(NSString * _Nullable)toJSON:(NSStringEncoding)encoding error:(NSError * _Nullable * _Nullable)error;
        [Export ("toJSON:error:")]
        [return: NullAllowed]
        string ToJSON (nuint encoding, [NullAllowed] out NSError error);

        // -(NSData * _Nullable)toData:(NSError * _Nullable * _Nullable)error;
        [Export ("toData:")]
        [return: NullAllowed]
        NSData ToData ([NullAllowed] out NSError error);
    }

    // @interface ALBarcodeConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALBarcodeConfig
    {
        // @property (copy, nonatomic) NSArray<ALBarcodeFormat *> * _Nonnull barcodeFormats;
        [Export ("barcodeFormats", ArgumentSemantic.Copy)]
        ALBarcodeFormat[] BarcodeFormats { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable consecutiveEqualResults;
        [NullAllowed, Export ("consecutiveEqualResults", ArgumentSemantic.Strong)]
        NSNumber ConsecutiveEqualResults { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable multiBarcode;
        [NullAllowed, Export ("multiBarcode", ArgumentSemantic.Strong)]
        NSNumber MultiBarcode { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable parseAAMVA;
        [NullAllowed, Export ("parseAAMVA", ArgumentSemantic.Strong)]
        NSNumber ParseAAMVA { get; set; }
    }

    // @interface ALCommercialTireIDConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALCommercialTireIDConfig
    {
        // @property (nonatomic, strong) NSNumber * _Nullable minConfidence;
        [NullAllowed, Export ("minConfidence", ArgumentSemantic.Strong)]
        NSNumber MinConfidence { get; set; }

        // @property (assign, nonatomic) ALUpsideDownMode * _Nullable upsideDownMode;
        [NullAllowed, Export ("upsideDownMode", ArgumentSemantic.Assign)]
        ALUpsideDownMode UpsideDownMode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable validationRegex;
        [NullAllowed, Export ("validationRegex")]
        string ValidationRegex { get; set; }
    }

    // @interface ALContainerConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALContainerConfig
    {
        // @property (nonatomic, strong) NSNumber * _Nullable minConfidence;
        [NullAllowed, Export ("minConfidence", ArgumentSemantic.Strong)]
        NSNumber MinConfidence { get; set; }

        // @property (assign, nonatomic) ALContainerConfigScanMode * _Nullable scanMode;
        [NullAllowed, Export ("scanMode", ArgumentSemantic.Assign)]
        ALContainerConfigScanMode ScanMode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable validationRegex;
        [NullAllowed, Export ("validationRegex")]
        string ValidationRegex { get; set; }
    }

    // @interface ALJapaneseLandingPermissionConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALJapaneseLandingPermissionConfig
    {
        // @property (nonatomic, strong) ALJapaneseLandingPermissionConfigFieldOption * _Nullable airport;
        [NullAllowed, Export ("airport", ArgumentSemantic.Strong)]
        ALJapaneseLandingPermissionConfigFieldOption Airport { get; set; }

        // @property (nonatomic, strong) ALJapaneseLandingPermissionConfigFieldOption * _Nullable dateOfExpiry;
        [NullAllowed, Export ("dateOfExpiry", ArgumentSemantic.Strong)]
        ALJapaneseLandingPermissionConfigFieldOption DateOfExpiry { get; set; }

        // @property (nonatomic, strong) ALJapaneseLandingPermissionConfigFieldOption * _Nullable dateOfIssue;
        [NullAllowed, Export ("dateOfIssue", ArgumentSemantic.Strong)]
        ALJapaneseLandingPermissionConfigFieldOption DateOfIssue { get; set; }

        // @property (nonatomic, strong) ALJapaneseLandingPermissionConfigFieldOption * _Nullable duration;
        [NullAllowed, Export ("duration", ArgumentSemantic.Strong)]
        ALJapaneseLandingPermissionConfigFieldOption Duration { get; set; }

        // @property (nonatomic, strong) ALJapaneseLandingPermissionConfigFieldOption * _Nullable status;
        [NullAllowed, Export ("status", ArgumentSemantic.Strong)]
        ALJapaneseLandingPermissionConfigFieldOption Status { get; set; }
    }

    // @interface ALJapaneseLandingPermissionConfigFieldOption : NSObject
    [BaseType (typeof(NSObject))]
    interface ALJapaneseLandingPermissionConfigFieldOption
    {
        // @property (nonatomic, strong) NSNumber * _Nullable minConfidence;
        [NullAllowed, Export ("minConfidence", ArgumentSemantic.Strong)]
        NSNumber MinConfidence { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable scanOption;
        [NullAllowed, Export ("scanOption", ArgumentSemantic.Assign)]
        ALMrzScanOption ScanOption { get; set; }
    }

    // @interface ALLicensePlateConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALLicensePlateConfig
    {
        // @property (nonatomic, strong) NSNumber * _Nullable minConfidence;
        [NullAllowed, Export ("minConfidence", ArgumentSemantic.Strong)]
        NSNumber MinConfidence { get; set; }

        // @property (assign, nonatomic) ALLicensePlateConfigScanMode * _Nullable scanMode;
        [NullAllowed, Export ("scanMode", ArgumentSemantic.Assign)]
        ALLicensePlateConfigScanMode ScanMode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable validationRegex;
        [NullAllowed, Export ("validationRegex")]
        string ValidationRegex { get; set; }
    }

    // @interface ALMeterConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALMeterConfig
    {
        // @property (nonatomic, strong) NSNumber * _Nullable maxNumDecimalDigits;
        [NullAllowed, Export ("maxNumDecimalDigits", ArgumentSemantic.Strong)]
        NSNumber MaxNumDecimalDigits { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minConfidence;
        [NullAllowed, Export ("minConfidence", ArgumentSemantic.Strong)]
        NSNumber MinConfidence { get; set; }

        // @property (assign, nonatomic) ALMeterConfigScanMode * _Nonnull scanMode;
        [Export ("scanMode", ArgumentSemantic.Assign)]
        ALMeterConfigScanMode ScanMode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable validationRegex;
        [NullAllowed, Export ("validationRegex")]
        string ValidationRegex { get; set; }
    }

    // @interface ALMrzConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALMrzConfig
    {
        // @property (assign, nonatomic) BOOL isCropAndTransformID;
        [Export ("isCropAndTransformID")]
        bool IsCropAndTransformID { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable faceDetectionEnabled;
        [NullAllowed, Export ("faceDetectionEnabled", ArgumentSemantic.Strong)]
        NSNumber FaceDetectionEnabled { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minConfidence;
        [NullAllowed, Export ("minConfidence", ArgumentSemantic.Strong)]
        NSNumber MinConfidence { get; set; }

        // @property (nonatomic, strong) ALMrzFieldScanOptions * _Nullable mrzFieldScanOptions;
        [NullAllowed, Export ("mrzFieldScanOptions", ArgumentSemantic.Strong)]
        ALMrzFieldScanOptions MrzFieldScanOptions { get; set; }

        // @property (nonatomic, strong) ALMrzMinFieldConfidences * _Nullable mrzMinFieldConfidences;
        [NullAllowed, Export ("mrzMinFieldConfidences", ArgumentSemantic.Strong)]
        ALMrzMinFieldConfidences MrzMinFieldConfidences { get; set; }

        // @property (assign, nonatomic) BOOL isStrictMode;
        [Export ("isStrictMode")]
        bool IsStrictMode { get; set; }
    }

    // @interface ALMrzFieldScanOptions : NSObject
    [BaseType (typeof(NSObject))]
    interface ALMrzFieldScanOptions
    {
        // @property (assign, nonatomic) ALMrzScanOption * _Nullable checkDigitDateOfBirth;
        [NullAllowed, Export ("checkDigitDateOfBirth", ArgumentSemantic.Assign)]
        ALMrzScanOption CheckDigitDateOfBirth { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable checkDigitDateOfExpiry;
        [NullAllowed, Export ("checkDigitDateOfExpiry", ArgumentSemantic.Assign)]
        ALMrzScanOption CheckDigitDateOfExpiry { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable checkDigitDocumentNumber;
        [NullAllowed, Export ("checkDigitDocumentNumber", ArgumentSemantic.Assign)]
        ALMrzScanOption CheckDigitDocumentNumber { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable checkDigitFinal;
        [NullAllowed, Export ("checkDigitFinal", ArgumentSemantic.Assign)]
        ALMrzScanOption CheckDigitFinal { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable checkDigitPersonalNumber;
        [NullAllowed, Export ("checkDigitPersonalNumber", ArgumentSemantic.Assign)]
        ALMrzScanOption CheckDigitPersonalNumber { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth", ArgumentSemantic.Assign)]
        ALMrzScanOption DateOfBirth { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable dateOfExpiry;
        [NullAllowed, Export ("dateOfExpiry", ArgumentSemantic.Assign)]
        ALMrzScanOption DateOfExpiry { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable documentNumber;
        [NullAllowed, Export ("documentNumber", ArgumentSemantic.Assign)]
        ALMrzScanOption DocumentNumber { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable documentType;
        [NullAllowed, Export ("documentType", ArgumentSemantic.Assign)]
        ALMrzScanOption DocumentType { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable givenNames;
        [NullAllowed, Export ("givenNames", ArgumentSemantic.Assign)]
        ALMrzScanOption GivenNames { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable issuingCountryCode;
        [NullAllowed, Export ("issuingCountryCode", ArgumentSemantic.Assign)]
        ALMrzScanOption IssuingCountryCode { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable mrzString;
        [NullAllowed, Export ("mrzString", ArgumentSemantic.Assign)]
        ALMrzScanOption MrzString { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable nationalityCountryCode;
        [NullAllowed, Export ("nationalityCountryCode", ArgumentSemantic.Assign)]
        ALMrzScanOption NationalityCountryCode { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable optionalData;
        [NullAllowed, Export ("optionalData", ArgumentSemantic.Assign)]
        ALMrzScanOption OptionalData { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable personalNumber;
        [NullAllowed, Export ("personalNumber", ArgumentSemantic.Assign)]
        ALMrzScanOption PersonalNumber { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable sex;
        [NullAllowed, Export ("sex", ArgumentSemantic.Assign)]
        ALMrzScanOption Sex { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable surname;
        [NullAllowed, Export ("surname", ArgumentSemantic.Assign)]
        ALMrzScanOption Surname { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable vizAddress;
        [NullAllowed, Export ("vizAddress", ArgumentSemantic.Assign)]
        ALMrzScanOption VizAddress { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable vizDateOfBirth;
        [NullAllowed, Export ("vizDateOfBirth", ArgumentSemantic.Assign)]
        ALMrzScanOption VizDateOfBirth { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable vizDateOfExpiry;
        [NullAllowed, Export ("vizDateOfExpiry", ArgumentSemantic.Assign)]
        ALMrzScanOption VizDateOfExpiry { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable vizDateOfIssue;
        [NullAllowed, Export ("vizDateOfIssue", ArgumentSemantic.Assign)]
        ALMrzScanOption VizDateOfIssue { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable vizGivenNames;
        [NullAllowed, Export ("vizGivenNames", ArgumentSemantic.Assign)]
        ALMrzScanOption VizGivenNames { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable vizSurname;
        [NullAllowed, Export ("vizSurname", ArgumentSemantic.Assign)]
        ALMrzScanOption VizSurname { get; set; }
    }

    // @interface ALMrzMinFieldConfidences : NSObject
    [BaseType (typeof(NSObject))]
    interface ALMrzMinFieldConfidences
    {
        // @property (nonatomic, strong) NSNumber * _Nullable checkDigitDateOfBirth;
        [NullAllowed, Export ("checkDigitDateOfBirth", ArgumentSemantic.Strong)]
        NSNumber CheckDigitDateOfBirth { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable checkDigitDateOfExpiry;
        [NullAllowed, Export ("checkDigitDateOfExpiry", ArgumentSemantic.Strong)]
        NSNumber CheckDigitDateOfExpiry { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable checkDigitDocumentNumber;
        [NullAllowed, Export ("checkDigitDocumentNumber", ArgumentSemantic.Strong)]
        NSNumber CheckDigitDocumentNumber { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable checkDigitFinal;
        [NullAllowed, Export ("checkDigitFinal", ArgumentSemantic.Strong)]
        NSNumber CheckDigitFinal { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable checkDigitPersonalNumber;
        [NullAllowed, Export ("checkDigitPersonalNumber", ArgumentSemantic.Strong)]
        NSNumber CheckDigitPersonalNumber { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth", ArgumentSemantic.Strong)]
        NSNumber DateOfBirth { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable dateOfExpiry;
        [NullAllowed, Export ("dateOfExpiry", ArgumentSemantic.Strong)]
        NSNumber DateOfExpiry { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable documentNumber;
        [NullAllowed, Export ("documentNumber", ArgumentSemantic.Strong)]
        NSNumber DocumentNumber { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable documentType;
        [NullAllowed, Export ("documentType", ArgumentSemantic.Strong)]
        NSNumber DocumentType { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable givenNames;
        [NullAllowed, Export ("givenNames", ArgumentSemantic.Strong)]
        NSNumber GivenNames { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable issuingCountryCode;
        [NullAllowed, Export ("issuingCountryCode", ArgumentSemantic.Strong)]
        NSNumber IssuingCountryCode { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable mrzString;
        [NullAllowed, Export ("mrzString", ArgumentSemantic.Strong)]
        NSNumber MrzString { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable nationalityCountryCode;
        [NullAllowed, Export ("nationalityCountryCode", ArgumentSemantic.Strong)]
        NSNumber NationalityCountryCode { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable optionalData;
        [NullAllowed, Export ("optionalData", ArgumentSemantic.Strong)]
        NSNumber OptionalData { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable personalNumber;
        [NullAllowed, Export ("personalNumber", ArgumentSemantic.Strong)]
        NSNumber PersonalNumber { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable sex;
        [NullAllowed, Export ("sex", ArgumentSemantic.Strong)]
        NSNumber Sex { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable surname;
        [NullAllowed, Export ("surname", ArgumentSemantic.Strong)]
        NSNumber Surname { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable vizAddress;
        [NullAllowed, Export ("vizAddress", ArgumentSemantic.Strong)]
        NSNumber VizAddress { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable vizDateOfBirth;
        [NullAllowed, Export ("vizDateOfBirth", ArgumentSemantic.Strong)]
        NSNumber VizDateOfBirth { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable vizDateOfExpiry;
        [NullAllowed, Export ("vizDateOfExpiry", ArgumentSemantic.Strong)]
        NSNumber VizDateOfExpiry { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable vizDateOfIssue;
        [NullAllowed, Export ("vizDateOfIssue", ArgumentSemantic.Strong)]
        NSNumber VizDateOfIssue { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable vizGivenNames;
        [NullAllowed, Export ("vizGivenNames", ArgumentSemantic.Strong)]
        NSNumber VizGivenNames { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable vizSurname;
        [NullAllowed, Export ("vizSurname", ArgumentSemantic.Strong)]
        NSNumber VizSurname { get; set; }
    }

    // @interface ALOcrConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALOcrConfig
    {
        // @property (nonatomic, strong) NSNumber * _Nullable charCountX;
        [NullAllowed, Export ("charCountX", ArgumentSemantic.Strong)]
        NSNumber CharCountX { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable charCountY;
        [NullAllowed, Export ("charCountY", ArgumentSemantic.Strong)]
        NSNumber CharCountY { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable charPaddingXFactor;
        [NullAllowed, Export ("charPaddingXFactor", ArgumentSemantic.Strong)]
        NSNumber CharPaddingXFactor { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable charPaddingYFactor;
        [NullAllowed, Export ("charPaddingYFactor", ArgumentSemantic.Strong)]
        NSNumber CharPaddingYFactor { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable charWhitelist;
        [NullAllowed, Export ("charWhitelist")]
        string CharWhitelist { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable customCmdFile;
        [NullAllowed, Export ("customCmdFile")]
        string CustomCmdFile { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxCharHeight;
        [NullAllowed, Export ("maxCharHeight", ArgumentSemantic.Strong)]
        NSNumber MaxCharHeight { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minCharHeight;
        [NullAllowed, Export ("minCharHeight", ArgumentSemantic.Strong)]
        NSNumber MinCharHeight { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minConfidence;
        [NullAllowed, Export ("minConfidence", ArgumentSemantic.Strong)]
        NSNumber MinConfidence { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minSharpness;
        [NullAllowed, Export ("minSharpness", ArgumentSemantic.Strong)]
        NSNumber MinSharpness { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable models;
	    [NullAllowed, Export ("models", ArgumentSemantic.Copy)]
        string[] Models { get; set; }

        // @property (assign, nonatomic) ALOcrConfigScanMode * _Nullable scanMode;
        [NullAllowed, Export ("scanMode", ArgumentSemantic.Assign)]
        ALOcrConfigScanMode ScanMode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable validationRegex;
        [NullAllowed, Export ("validationRegex")]
        string ValidationRegex { get; set; }
    }

    // @interface ALOdometerConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALOdometerConfig
    {
        // @property (nonatomic, strong) NSNumber * _Nullable minConfidence;
        [NullAllowed, Export ("minConfidence", ArgumentSemantic.Strong)]
        NSNumber MinConfidence { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable validationRegex;
        [NullAllowed, Export ("validationRegex")]
        string ValidationRegex { get; set; }
    }

    // @interface ALStartVariable : NSObject
    [BaseType (typeof(NSObject))]
    interface ALStartVariable
    {
        // @property (copy, nonatomic) NSString * _Nonnull key;
        [Export ("key")]
        string Key { get; set; }

        // @property (copy, nonatomic) id _Nonnull value;
        [Export ("value", ArgumentSemantic.Copy)]
        NSObject Value { get; set; }
    }

    // @interface ALTinConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALTinConfig
    {
        // @property (nonatomic, strong) NSNumber * _Nullable minConfidence;
        [NullAllowed, Export ("minConfidence", ArgumentSemantic.Strong)]
        NSNumber MinConfidence { get; set; }

        // @property (assign, nonatomic) ALTinConfigScanMode * _Nullable scanMode;
        [NullAllowed, Export ("scanMode", ArgumentSemantic.Assign)]
        ALTinConfigScanMode ScanMode { get; set; }

        // @property (assign, nonatomic) ALUpsideDownMode * _Nullable upsideDownMode;
        [NullAllowed, Export ("upsideDownMode", ArgumentSemantic.Assign)]
        ALUpsideDownMode UpsideDownMode { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable validateProductionDate;
        [NullAllowed, Export ("validateProductionDate", ArgumentSemantic.Strong)]
        NSNumber ValidateProductionDate { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable validationRegex;
        [NullAllowed, Export ("validationRegex")]
        string ValidationRegex { get; set; }
    }

    // @interface ALTireMakeConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALTireMakeConfig
    {
        // @property (nonatomic, strong) NSNumber * _Nullable minConfidence;
        [NullAllowed, Export ("minConfidence", ArgumentSemantic.Strong)]
        NSNumber MinConfidence { get; set; }

        // @property (assign, nonatomic) ALUpsideDownMode * _Nullable upsideDownMode;
        [NullAllowed, Export ("upsideDownMode", ArgumentSemantic.Assign)]
        ALUpsideDownMode UpsideDownMode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable validationRegex;
        [NullAllowed, Export ("validationRegex")]
        string ValidationRegex { get; set; }
    }

    // @interface ALTireSizeConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALTireSizeConfig
    {
        // @property (nonatomic, strong) NSNumber * _Nullable minConfidence;
        [NullAllowed, Export ("minConfidence", ArgumentSemantic.Strong)]
        NSNumber MinConfidence { get; set; }

        // @property (assign, nonatomic) ALUpsideDownMode * _Nullable upsideDownMode;
        [NullAllowed, Export ("upsideDownMode", ArgumentSemantic.Assign)]
        ALUpsideDownMode UpsideDownMode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable validationRegex;
        [NullAllowed, Export ("validationRegex")]
        string ValidationRegex { get; set; }
    }

    // @interface ALUniversalIDConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALUniversalIDConfig
    {
        // @property (nonatomic, strong) ALAllowedLayouts * _Nullable allowedLayouts;
        [NullAllowed, Export ("allowedLayouts", ArgumentSemantic.Strong)]
        ALAllowedLayouts AllowedLayouts { get; set; }

        // @property (assign, nonatomic) ALAlphabet * _Nullable alphabet;
        [NullAllowed, Export ("alphabet", ArgumentSemantic.Assign)]
        ALAlphabet Alphabet { get; set; }

        // @property (nonatomic, strong) ALLayoutDrivingLicense * _Nullable drivingLicense;
        [NullAllowed, Export ("drivingLicense", ArgumentSemantic.Strong)]
        ALLayoutDrivingLicense DrivingLicense { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable faceDetectionEnabled;
        [NullAllowed, Export ("faceDetectionEnabled", ArgumentSemantic.Strong)]
        NSNumber FaceDetectionEnabled { get; set; }

        // @property (nonatomic, strong) ALLayoutIDFront * _Nullable theIDFront;
        [NullAllowed, Export ("theIDFront", ArgumentSemantic.Strong)]
        ALLayoutIDFront TheIDFront { get; set; }

        // @property (nonatomic, strong) ALLayoutInsuranceCard * _Nullable insuranceCard;
        [NullAllowed, Export ("insuranceCard", ArgumentSemantic.Strong)]
        ALLayoutInsuranceCard InsuranceCard { get; set; }

        // @property (nonatomic, strong) ALLayoutMrz * _Nullable mrz;
        [NullAllowed, Export ("mrz", ArgumentSemantic.Strong)]
        ALLayoutMrz Mrz { get; set; }
    }

    // @interface ALAllowedLayouts : NSObject
    [BaseType (typeof(NSObject))]
    interface ALAllowedLayouts
    {
        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable drivingLicense;
        [NullAllowed, Export ("drivingLicense", ArgumentSemantic.Copy)]
        string[] DrivingLicense { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable theIDFront;
        [NullAllowed, Export ("theIDFront", ArgumentSemantic.Copy)]
        string[] TheIDFront { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable insuranceCard;
        [NullAllowed, Export ("insuranceCard", ArgumentSemantic.Copy)]
        string[] InsuranceCard { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable mrz;
        [NullAllowed, Export ("mrz", ArgumentSemantic.Copy)]
        string[] Mrz { get; set; }
    }

    // @interface ALLayoutDrivingLicense : NSObject
    [BaseType (typeof(NSObject))]
    interface ALLayoutDrivingLicense
    {
        // @property (nonatomic, strong) ALUniversalIDField * _Nullable additionalInformation;
        [NullAllowed, Export ("additionalInformation", ArgumentSemantic.Strong)]
        ALUniversalIDField AdditionalInformation { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable additionalInformation1;
        [NullAllowed, Export ("additionalInformation1", ArgumentSemantic.Strong)]
        ALUniversalIDField AdditionalInformation1 { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable address;
        [NullAllowed, Export ("address", ArgumentSemantic.Strong)]
        ALUniversalIDField Address { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable audit;
        [NullAllowed, Export ("audit", ArgumentSemantic.Strong)]
        ALUniversalIDField Audit { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable authority;
        [NullAllowed, Export ("authority", ArgumentSemantic.Strong)]
        ALUniversalIDField Authority { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable cardNumber;
        [NullAllowed, Export ("cardNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField CardNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable categories;
        [NullAllowed, Export ("categories", ArgumentSemantic.Strong)]
        ALUniversalIDField Categories { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable conditions;
        [NullAllowed, Export ("conditions", ArgumentSemantic.Strong)]
        ALUniversalIDField Conditions { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth", ArgumentSemantic.Strong)]
        ALUniversalIDField DateOfBirth { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable dateOfExpiry;
        [NullAllowed, Export ("dateOfExpiry", ArgumentSemantic.Strong)]
        ALUniversalIDField DateOfExpiry { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable dateOfIssue;
        [NullAllowed, Export ("dateOfIssue", ArgumentSemantic.Strong)]
        ALUniversalIDField DateOfIssue { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable documentDiscriminator;
        [NullAllowed, Export ("documentDiscriminator", ArgumentSemantic.Strong)]
        ALUniversalIDField DocumentDiscriminator { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable documentNumber;
        [NullAllowed, Export ("documentNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField DocumentNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable duplicate;
        [NullAllowed, Export ("duplicate", ArgumentSemantic.Strong)]
        ALUniversalIDField Duplicate { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable duration;
        [NullAllowed, Export ("duration", ArgumentSemantic.Strong)]
        ALUniversalIDField Duration { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable endorsements;
        [NullAllowed, Export ("endorsements", ArgumentSemantic.Strong)]
        ALUniversalIDField Endorsements { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable eyes;
        [NullAllowed, Export ("eyes", ArgumentSemantic.Strong)]
        ALUniversalIDField Eyes { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable firstIssued;
        [NullAllowed, Export ("firstIssued", ArgumentSemantic.Strong)]
        ALUniversalIDField FirstIssued { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable firstName;
        [NullAllowed, Export ("firstName", ArgumentSemantic.Strong)]
        ALUniversalIDField FirstName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable fullName;
        [NullAllowed, Export ("fullName", ArgumentSemantic.Strong)]
        ALUniversalIDField FullName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable givenNames;
        [NullAllowed, Export ("givenNames", ArgumentSemantic.Strong)]
        ALUniversalIDField GivenNames { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable hair;
        [NullAllowed, Export ("hair", ArgumentSemantic.Strong)]
        ALUniversalIDField Hair { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable height;
        [NullAllowed, Export ("height", ArgumentSemantic.Strong)]
        ALUniversalIDField Height { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable lastName;
        [NullAllowed, Export ("lastName", ArgumentSemantic.Strong)]
        ALUniversalIDField LastName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable licenceNumber;
        [NullAllowed, Export ("licenceNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField LicenceNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable licenseClass;
        [NullAllowed, Export ("licenseClass", ArgumentSemantic.Strong)]
        ALUniversalIDField LicenseClass { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable licenseNumber;
        [NullAllowed, Export ("licenseNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField LicenseNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable name;
        [NullAllowed, Export ("name", ArgumentSemantic.Strong)]
        ALUniversalIDField Name { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable office;
        [NullAllowed, Export ("office", ArgumentSemantic.Strong)]
        ALUniversalIDField Office { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable parish;
        [NullAllowed, Export ("parish", ArgumentSemantic.Strong)]
        ALUniversalIDField Parish { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable personalNumber;
        [NullAllowed, Export ("personalNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField PersonalNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable placeOfBirth;
        [NullAllowed, Export ("placeOfBirth", ArgumentSemantic.Strong)]
        ALUniversalIDField PlaceOfBirth { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable previousType;
        [NullAllowed, Export ("previousType", ArgumentSemantic.Strong)]
        ALUniversalIDField PreviousType { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable restrictions;
        [NullAllowed, Export ("restrictions", ArgumentSemantic.Strong)]
        ALUniversalIDField Restrictions { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable revoked;
        [NullAllowed, Export ("revoked", ArgumentSemantic.Strong)]
        ALUniversalIDField Revoked { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable sex;
        [NullAllowed, Export ("sex", ArgumentSemantic.Strong)]
        ALUniversalIDField Sex { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable surname;
        [NullAllowed, Export ("surname", ArgumentSemantic.Strong)]
        ALUniversalIDField Surname { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable type;
        [NullAllowed, Export ("type", ArgumentSemantic.Strong)]
        ALUniversalIDField Type { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable version;
        [NullAllowed, Export ("version", ArgumentSemantic.Strong)]
        ALUniversalIDField Version { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable verticalNumber;
        [NullAllowed, Export ("verticalNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField VerticalNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable weight;
        [NullAllowed, Export ("weight", ArgumentSemantic.Strong)]
        ALUniversalIDField Weight { get; set; }
    }

    // @interface ALUniversalIDField : NSObject
    [BaseType (typeof(NSObject))]
    interface ALUniversalIDField
    {
        // @property (nonatomic, strong) NSNumber * _Nullable minConfidence;
        [NullAllowed, Export ("minConfidence", ArgumentSemantic.Strong)]
        NSNumber MinConfidence { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable scanOption;
        [NullAllowed, Export ("scanOption", ArgumentSemantic.Assign)]
        ALMrzScanOption ScanOption { get; set; }
    }

    // @interface ALLayoutInsuranceCard : NSObject
    [BaseType (typeof(NSObject))]
    interface ALLayoutInsuranceCard
    {
        // @property (nonatomic, strong) ALUniversalIDField * _Nullable authority;
        [NullAllowed, Export ("authority", ArgumentSemantic.Strong)]
        ALUniversalIDField Authority { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth", ArgumentSemantic.Strong)]
        ALUniversalIDField DateOfBirth { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable dateOfExpiry;
        [NullAllowed, Export ("dateOfExpiry", ArgumentSemantic.Strong)]
        ALUniversalIDField DateOfExpiry { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable documentNumber;
        [NullAllowed, Export ("documentNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField DocumentNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable firstName;
        [NullAllowed, Export ("firstName", ArgumentSemantic.Strong)]
        ALUniversalIDField FirstName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable lastName;
        [NullAllowed, Export ("lastName", ArgumentSemantic.Strong)]
        ALUniversalIDField LastName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable nationality;
        [NullAllowed, Export ("nationality", ArgumentSemantic.Strong)]
        ALUniversalIDField Nationality { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable personalNumber;
        [NullAllowed, Export ("personalNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField PersonalNumber { get; set; }
    }

    // @interface ALLayoutMrz : NSObject
    [BaseType (typeof(NSObject))]
    interface ALLayoutMrz
    {
        // @property (nonatomic, strong) ALUniversalIDField * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth", ArgumentSemantic.Strong)]
        ALUniversalIDField DateOfBirth { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable dateOfExpiry;
        [NullAllowed, Export ("dateOfExpiry", ArgumentSemantic.Strong)]
        ALUniversalIDField DateOfExpiry { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable vizAddress;
        [NullAllowed, Export ("vizAddress", ArgumentSemantic.Strong)]
        ALUniversalIDField VizAddress { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable vizDateOfBirth;
        [NullAllowed, Export ("vizDateOfBirth", ArgumentSemantic.Strong)]
        ALUniversalIDField VizDateOfBirth { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable vizDateOfExpiry;
        [NullAllowed, Export ("vizDateOfExpiry", ArgumentSemantic.Strong)]
        ALUniversalIDField VizDateOfExpiry { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable vizDateOfIssue;
        [NullAllowed, Export ("vizDateOfIssue", ArgumentSemantic.Strong)]
        ALUniversalIDField VizDateOfIssue { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable vizGivenNames;
        [NullAllowed, Export ("vizGivenNames", ArgumentSemantic.Strong)]
        ALUniversalIDField VizGivenNames { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable vizSurname;
        [NullAllowed, Export ("vizSurname", ArgumentSemantic.Strong)]
        ALUniversalIDField VizSurname { get; set; }
    }

    // @interface ALLayoutIDFront : NSObject
    [BaseType (typeof(NSObject))]
    interface ALLayoutIDFront
    {
        // @property (nonatomic, strong) ALUniversalIDField * _Nullable additionalInformation;
        [NullAllowed, Export ("additionalInformation", ArgumentSemantic.Strong)]
        ALUniversalIDField AdditionalInformation { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable additionalInformation1;
        [NullAllowed, Export ("additionalInformation1", ArgumentSemantic.Strong)]
        ALUniversalIDField AdditionalInformation1 { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable address;
        [NullAllowed, Export ("address", ArgumentSemantic.Strong)]
        ALUniversalIDField Address { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable age;
        [NullAllowed, Export ("age", ArgumentSemantic.Strong)]
        ALUniversalIDField Age { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable authority;
        [NullAllowed, Export ("authority", ArgumentSemantic.Strong)]
        ALUniversalIDField Authority { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable cardAccessNumber;
        [NullAllowed, Export ("cardAccessNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField CardAccessNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable citizenship;
        [NullAllowed, Export ("citizenship", ArgumentSemantic.Strong)]
        ALUniversalIDField Citizenship { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable cityNumber;
        [NullAllowed, Export ("cityNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField CityNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth", ArgumentSemantic.Strong)]
        ALUniversalIDField DateOfBirth { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable dateOfExpiry;
        [NullAllowed, Export ("dateOfExpiry", ArgumentSemantic.Strong)]
        ALUniversalIDField DateOfExpiry { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable dateOfIssue;
        [NullAllowed, Export ("dateOfIssue", ArgumentSemantic.Strong)]
        ALUniversalIDField DateOfIssue { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable dateOfRegistration;
        [NullAllowed, Export ("dateOfRegistration", ArgumentSemantic.Strong)]
        ALUniversalIDField DateOfRegistration { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable divisionNumber;
        [NullAllowed, Export ("divisionNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField DivisionNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable documentNumber;
        [NullAllowed, Export ("documentNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField DocumentNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable familyName;
        [NullAllowed, Export ("familyName", ArgumentSemantic.Strong)]
        ALUniversalIDField FamilyName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable fathersName;
        [NullAllowed, Export ("fathersName", ArgumentSemantic.Strong)]
        ALUniversalIDField FathersName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable firstName;
        [NullAllowed, Export ("firstName", ArgumentSemantic.Strong)]
        ALUniversalIDField FirstName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable folio;
        [NullAllowed, Export ("folio", ArgumentSemantic.Strong)]
        ALUniversalIDField Folio { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable fullName;
        [NullAllowed, Export ("fullName", ArgumentSemantic.Strong)]
        ALUniversalIDField FullName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable givenNames;
        [NullAllowed, Export ("givenNames", ArgumentSemantic.Strong)]
        ALUniversalIDField GivenNames { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable height;
        [NullAllowed, Export ("height", ArgumentSemantic.Strong)]
        ALUniversalIDField Height { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable lastName;
        [NullAllowed, Export ("lastName", ArgumentSemantic.Strong)]
        ALUniversalIDField LastName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable licenseClass;
        [NullAllowed, Export ("licenseClass", ArgumentSemantic.Strong)]
        ALUniversalIDField LicenseClass { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable licenseType;
        [NullAllowed, Export ("licenseType", ArgumentSemantic.Strong)]
        ALUniversalIDField LicenseType { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable municipalityNumber;
        [NullAllowed, Export ("municipalityNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField MunicipalityNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable nationalID;
        [NullAllowed, Export ("nationalID", ArgumentSemantic.Strong)]
        ALUniversalIDField NationalID { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable nationality;
        [NullAllowed, Export ("nationality", ArgumentSemantic.Strong)]
        ALUniversalIDField Nationality { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable parentsGivenName;
        [NullAllowed, Export ("parentsGivenName", ArgumentSemantic.Strong)]
        ALUniversalIDField ParentsGivenName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable personalNumber;
        [NullAllowed, Export ("personalNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField PersonalNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable placeAndDateOfBirth;
        [NullAllowed, Export ("placeAndDateOfBirth", ArgumentSemantic.Strong)]
        ALUniversalIDField PlaceAndDateOfBirth { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable placeOfBirth;
        [NullAllowed, Export ("placeOfBirth", ArgumentSemantic.Strong)]
        ALUniversalIDField PlaceOfBirth { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable sex;
        [NullAllowed, Export ("sex", ArgumentSemantic.Strong)]
        ALUniversalIDField Sex { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable stateNumber;
        [NullAllowed, Export ("stateNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField StateNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable supportNumber;
        [NullAllowed, Export ("supportNumber", ArgumentSemantic.Strong)]
        ALUniversalIDField SupportNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable surname;
        [NullAllowed, Export ("surname", ArgumentSemantic.Strong)]
        ALUniversalIDField Surname { get; set; }

        // @property (nonatomic, strong) ALUniversalIDField * _Nullable voterID;
        [NullAllowed, Export ("voterID", ArgumentSemantic.Strong)]
        ALUniversalIDField VoterID { get; set; }
    }

    // @interface ALVehicleRegistrationCertificateConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALVehicleRegistrationCertificateConfig
    {
        // @property (nonatomic, strong) ALLayoutVehicleRegistrationCertificate * _Nullable vehicleRegistrationCertificate;
        [NullAllowed, Export ("vehicleRegistrationCertificate", ArgumentSemantic.Strong)]
        ALLayoutVehicleRegistrationCertificate VehicleRegistrationCertificate { get; set; }
    }

    // @interface ALLayoutVehicleRegistrationCertificate : NSObject
    [BaseType (typeof(NSObject))]
    interface ALLayoutVehicleRegistrationCertificate
    {
        // @property (nonatomic, strong) ALVehicleRegistrationCertificateField * _Nullable address;
        [NullAllowed, Export ("address", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateField Address { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateField * _Nullable brand;
        [NullAllowed, Export ("brand", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateField Brand { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateField * _Nullable displacement;
        [NullAllowed, Export ("displacement", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateField Displacement { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateField * _Nullable documentNumber;
        [NullAllowed, Export ("documentNumber", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateField DocumentNumber { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateField * _Nullable firstIssued;
        [NullAllowed, Export ("firstIssued", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateField FirstIssued { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateField * _Nullable firstName;
        [NullAllowed, Export ("firstName", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateField FirstName { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateField * _Nullable lastName;
        [NullAllowed, Export ("lastName", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateField LastName { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateField * _Nullable licensePlate;
        [NullAllowed, Export ("licensePlate", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateField LicensePlate { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateField * _Nullable manufacturerCode;
        [NullAllowed, Export ("manufacturerCode", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateField ManufacturerCode { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateField * _Nullable tire;
        [NullAllowed, Export ("tire", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateField Tire { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateField * _Nullable vehicleIdentificationNumber;
        [NullAllowed, Export ("vehicleIdentificationNumber", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateField VehicleIdentificationNumber { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateField * _Nullable vehicleType;
        [NullAllowed, Export ("vehicleType", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateField VehicleType { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateField * _Nullable vehicleTypeCode;
        [NullAllowed, Export ("vehicleTypeCode", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateField VehicleTypeCode { get; set; }
    }

    // @interface ALVehicleRegistrationCertificateField : NSObject
    [BaseType (typeof(NSObject))]
    interface ALVehicleRegistrationCertificateField
    {
        // @property (nonatomic, strong) NSNumber * _Nullable minConfidence;
        [NullAllowed, Export ("minConfidence", ArgumentSemantic.Strong)]
        NSNumber MinConfidence { get; set; }

        // @property (assign, nonatomic) ALMrzScanOption * _Nullable scanOption;
        [NullAllowed, Export ("scanOption", ArgumentSemantic.Assign)]
        ALMrzScanOption ScanOption { get; set; }
    }

    // @interface ALVinConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALVinConfig
    {
        // @property (copy, nonatomic) NSString * _Nullable charWhitelist;
        [NullAllowed, Export ("charWhitelist")]
        string CharWhitelist { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable validationRegex;
        [NullAllowed, Export ("validationRegex")]
        string ValidationRegex { get; set; }
    }

    // @interface ALExtras (ALPluginConfig) <ALJSONStringRepresentable>
    [Protocol, Model]
    [BaseType (typeof(ALPluginConfig))]
    interface ALPluginConfig_ALExtras : ALJSONStringRepresentable
    {
        // +(ALPluginConfig * _Nullable)withJSONString:(NSString * _Nonnull)JSONString;
        [Static]
        [Export ("withJSONString:")]
        [return: NullAllowed]
        ALPluginConfig WithJSONString (string JSONString);

        // +(ALPluginConfig * _Nullable)withJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary;
        [Static]
        [Export ("withJSONDictionary:")]
        [return: NullAllowed]
        ALPluginConfig WithJSONDictionary (NSDictionary JSONDictionary);

        // -(instancetype _Nullable)initWithJSONString:(NSString * _Nonnull)JSONString error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONString:error:")]
        IntPtr Constructor (string JSONString, [NullAllowed] out NSError error);

        // -(instancetype _Nullable)initWithJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONDictionary:error:")]
        IntPtr Constructor (NSDictionary JSONDictionary, [NullAllowed] out NSError error);
    }

    // @interface ALArea : NSObject
    [BaseType (typeof(NSObject))]
    interface ALArea
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
        [Export ("value")]
        string Value { get; }

        // +(instancetype _Nullable)withValue:(NSString * _Nonnull)value;
        [Static]
        [Export ("withValue:")]
        [return: NullAllowed]
        ALArea WithValue (string value);

        // // +(ALArea * _Nonnull)alabama;
        // [Static]
        // [Export ("alabama")]
        // ALArea Alabama { get; }

        // // +(ALArea * _Nonnull)alaska;
        // [Static]
        // [Export ("alaska")]
        // ALArea Alaska { get; }

        // // +(ALArea * _Nonnull)americanSamoa;
        // [Static]
        // [Export ("americanSamoa")]
        // ALArea AmericanSamoa { get; }

        // // +(ALArea * _Nonnull)arizona;
        // [Static]
        // [Export ("arizona")]
        // ALArea Arizona { get; }

        // // +(ALArea * _Nonnull)arkansas;
        // [Static]
        // [Export ("arkansas")]
        // ALArea Arkansas { get; }

        // // +(ALArea * _Nonnull)california;
        // [Static]
        // [Export ("california")]
        // ALArea California { get; }

        // // +(ALArea * _Nonnull)colorado;
        // [Static]
        // [Export ("colorado")]
        // ALArea Colorado { get; }

        // // +(ALArea * _Nonnull)connecticut;
        // [Static]
        // [Export ("connecticut")]
        // ALArea Connecticut { get; }

        // // +(ALArea * _Nonnull)delaware;
        // [Static]
        // [Export ("delaware")]
        // ALArea Delaware { get; }

        // // +(ALArea * _Nonnull)districtOfColumbia;
        // [Static]
        // [Export ("districtOfColumbia")]
        // ALArea DistrictOfColumbia { get; }

        // // +(ALArea * _Nonnull)florida;
        // [Static]
        // [Export ("florida")]
        // ALArea Florida { get; }

        // // +(ALArea * _Nonnull)georgia;
        // [Static]
        // [Export ("georgia")]
        // ALArea Georgia { get; }

        // // +(ALArea * _Nonnull)guam;
        // [Static]
        // [Export ("guam")]
        // ALArea Guam { get; }

        // // +(ALArea * _Nonnull)hawaii;
        // [Static]
        // [Export ("hawaii")]
        // ALArea Hawaii { get; }

        // // +(ALArea * _Nonnull)idaho;
        // [Static]
        // [Export ("idaho")]
        // ALArea Idaho { get; }

        // // +(ALArea * _Nonnull)illinois;
        // [Static]
        // [Export ("illinois")]
        // ALArea Illinois { get; }

        // // +(ALArea * _Nonnull)indiana;
        // [Static]
        // [Export ("indiana")]
        // ALArea Indiana { get; }

        // // +(ALArea * _Nonnull)iowa;
        // [Static]
        // [Export ("iowa")]
        // ALArea Iowa { get; }

        // // +(ALArea * _Nonnull)kansas;
        // [Static]
        // [Export ("kansas")]
        // ALArea Kansas { get; }

        // // +(ALArea * _Nonnull)kentucky;
        // [Static]
        // [Export ("kentucky")]
        // ALArea Kentucky { get; }

        // // +(ALArea * _Nonnull)louisiana;
        // [Static]
        // [Export ("louisiana")]
        // ALArea Louisiana { get; }

        // // +(ALArea * _Nonnull)maine;
        // [Static]
        // [Export ("maine")]
        // ALArea Maine { get; }

        // // +(ALArea * _Nonnull)maryland;
        // [Static]
        // [Export ("maryland")]
        // ALArea Maryland { get; }

        // // +(ALArea * _Nonnull)massachusetts;
        // [Static]
        // [Export ("massachusetts")]
        // ALArea Massachusetts { get; }

        // // +(ALArea * _Nonnull)michigan;
        // [Static]
        // [Export ("michigan")]
        // ALArea Michigan { get; }

        // // +(ALArea * _Nonnull)minnesota;
        // [Static]
        // [Export ("minnesota")]
        // ALArea Minnesota { get; }

        // // +(ALArea * _Nonnull)mississippi;
        // [Static]
        // [Export ("mississippi")]
        // ALArea Mississippi { get; }

        // // +(ALArea * _Nonnull)missouri;
        // [Static]
        // [Export ("missouri")]
        // ALArea Missouri { get; }

        // // +(ALArea * _Nonnull)montana;
        // [Static]
        // [Export ("montana")]
        // ALArea Montana { get; }

        // // +(ALArea * _Nonnull)nebraska;
        // [Static]
        // [Export ("nebraska")]
        // ALArea Nebraska { get; }

        // // +(ALArea * _Nonnull)nevada;
        // [Static]
        // [Export ("nevada")]
        // ALArea Nevada { get; }

        // // +(ALArea * _Nonnull)newHampshire;
        // [Static]
        // [Export ("newHampshire")]
        // ALArea NewHampshire { get; }

        // // +(ALArea * _Nonnull)newJersey;
        // [Static]
        // [Export ("newJersey")]
        // ALArea NewJersey { get; }

        // // +(ALArea * _Nonnull)newMexico;
        // [Static]
        // [Export ("newMexico")]
        // ALArea NewMexico { get; }

        // // +(ALArea * _Nonnull)newYork;
        // [Static]
        // [Export ("newYork")]
        // ALArea NewYork { get; }

        // // +(ALArea * _Nonnull)northCarolina;
        // [Static]
        // [Export ("northCarolina")]
        // ALArea NorthCarolina { get; }

        // // +(ALArea * _Nonnull)northDakota;
        // [Static]
        // [Export ("northDakota")]
        // ALArea NorthDakota { get; }

        // // +(ALArea * _Nonnull)ohio;
        // [Static]
        // [Export ("ohio")]
        // ALArea Ohio { get; }

        // // +(ALArea * _Nonnull)oklahoma;
        // [Static]
        // [Export ("oklahoma")]
        // ALArea Oklahoma { get; }

        // // +(ALArea * _Nonnull)oregon;
        // [Static]
        // [Export ("oregon")]
        // ALArea Oregon { get; }

        // // +(ALArea * _Nonnull)pennsylvania;
        // [Static]
        // [Export ("pennsylvania")]
        // ALArea Pennsylvania { get; }

        // // +(ALArea * _Nonnull)puertoRico;
        // [Static]
        // [Export ("puertoRico")]
        // ALArea PuertoRico { get; }

        // // +(ALArea * _Nonnull)rhodeIsland;
        // [Static]
        // [Export ("rhodeIsland")]
        // ALArea RhodeIsland { get; }

        // // +(ALArea * _Nonnull)southCarolina;
        // [Static]
        // [Export ("southCarolina")]
        // ALArea SouthCarolina { get; }

        // // +(ALArea * _Nonnull)southDakota;
        // [Static]
        // [Export ("southDakota")]
        // ALArea SouthDakota { get; }

        // // +(ALArea * _Nonnull)tennessee;
        // [Static]
        // [Export ("tennessee")]
        // ALArea Tennessee { get; }

        // // +(ALArea * _Nonnull)texas;
        // [Static]
        // [Export ("texas")]
        // ALArea Texas { get; }

        // // +(ALArea * _Nonnull)utah;
        // [Static]
        // [Export ("utah")]
        // ALArea Utah { get; }

        // // +(ALArea * _Nonnull)vermont;
        // [Static]
        // [Export ("vermont")]
        // ALArea Vermont { get; }

        // // +(ALArea * _Nonnull)virginia;
        // [Static]
        // [Export ("virginia")]
        // ALArea Virginia { get; }

        // // +(ALArea * _Nonnull)washington;
        // [Static]
        // [Export ("washington")]
        // ALArea Washington { get; }

        // // +(ALArea * _Nonnull)westVirginia;
        // [Static]
        // [Export ("westVirginia")]
        // ALArea WestVirginia { get; }

        // // +(ALArea * _Nonnull)wisconsin;
        // [Static]
        // [Export ("wisconsin")]
        // ALArea Wisconsin { get; }

        // // +(ALArea * _Nonnull)wyoming;
        // [Static]
        // [Export ("wyoming")]
        // ALArea Wyoming { get; }
    }

    // @interface ALPluginResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALPluginResult
    {
        // @property (nonatomic, strong) ALBarcodeResult * _Nullable barcodeResult;
        [NullAllowed, Export ("barcodeResult", ArgumentSemantic.Strong)]
        ALBarcodeResult BarcodeResult { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable blobKey;
        [NullAllowed, Export ("blobKey")]
        string BlobKey { get; set; }

        // @property (nonatomic, strong) ALCommercialTireIDResult * _Nullable commercialTireIDResult;
        [NullAllowed, Export ("commercialTireIDResult", ArgumentSemantic.Strong)]
        ALCommercialTireIDResult CommercialTireIDResult { get; set; }

        // @property (assign, nonatomic) NSInteger confidence;
        [Export ("confidence")]
        nint Confidence { get; set; }

        // @property (nonatomic, strong) ALContainerResult * _Nullable containerResult;
        [NullAllowed, Export ("containerResult", ArgumentSemantic.Strong)]
        ALContainerResult ContainerResult { get; set; }

        // @property (nonatomic, strong) ALCropRect * _Nullable cropRect;
        [NullAllowed, Export ("cropRect", ArgumentSemantic.Strong)]
        ALCropRect CropRect { get; set; }

        // @property (nonatomic, strong) ALJapaneseLandingPermissionResult * _Nullable japaneseLandingPermissionResult;
        [NullAllowed, Export ("japaneseLandingPermissionResult", ArgumentSemantic.Strong)]
        ALJapaneseLandingPermissionResult JapaneseLandingPermissionResult { get; set; }

        // @property (nonatomic, strong) ALLicensePlateResult * _Nullable licensePlateResult;
        [NullAllowed, Export ("licensePlateResult", ArgumentSemantic.Strong)]
        ALLicensePlateResult LicensePlateResult { get; set; }

        // @property (nonatomic, strong) ALMeterResult * _Nullable meterResult;
        [NullAllowed, Export ("meterResult", ArgumentSemantic.Strong)]
        ALMeterResult MeterResult { get; set; }

        // @property (nonatomic, strong) ALMrzResult * _Nullable mrzResult;
        [NullAllowed, Export ("mrzResult", ArgumentSemantic.Strong)]
        ALMrzResult MrzResult { get; set; }

        // @property (nonatomic, strong) ALOcrResult * _Nullable ocrResult;
        [NullAllowed, Export ("ocrResult", ArgumentSemantic.Strong)]
        ALOcrResult OcrResult { get; set; }

        // @property (nonatomic, strong) ALOdometerResult * _Nullable odometerResult;
        [NullAllowed, Export ("odometerResult", ArgumentSemantic.Strong)]
        ALOdometerResult OdometerResult { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull pluginID;
        [Export ("pluginID")]
        string PluginID { get; set; }

        // @property (nonatomic, strong) ALTinResult * _Nullable tinResult;
        [NullAllowed, Export ("tinResult", ArgumentSemantic.Strong)]
        ALTinResult TinResult { get; set; }

        // @property (nonatomic, strong) ALTireMakeResult * _Nullable tireMakeResult;
        [NullAllowed, Export ("tireMakeResult", ArgumentSemantic.Strong)]
        ALTireMakeResult TireMakeResult { get; set; }

        // @property (nonatomic, strong) ALTireSizeResult * _Nullable tireSizeResult;
        [NullAllowed, Export ("tireSizeResult", ArgumentSemantic.Strong)]
        ALTireSizeResult TireSizeResult { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResult * _Nullable universalIDResult;
        [NullAllowed, Export ("universalIDResult", ArgumentSemantic.Strong)]
        ALUniversalIDResult UniversalIDResult { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResult * _Nullable vehicleRegistrationCertificateResult;
        [NullAllowed, Export ("vehicleRegistrationCertificateResult", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResult VehicleRegistrationCertificateResult { get; set; }

        // @property (nonatomic, strong) ALVinResult * _Nullable vinResult;
        [NullAllowed, Export ("vinResult", ArgumentSemantic.Strong)]
        ALVinResult VinResult { get; set; }

        // +(instancetype _Nullable)fromJSON:(NSString * _Nonnull)json encoding:(NSStringEncoding)encoding error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export ("fromJSON:encoding:error:")]
        [return: NullAllowed]
        ALPluginResult FromJSON (string json, nuint encoding, [NullAllowed] out NSError error);

        // +(instancetype _Nullable)fromData:(NSData * _Nonnull)data error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export ("fromData:error:")]
        [return: NullAllowed]
        ALPluginResult FromData (NSData data, [NullAllowed] out NSError error);

        // -(NSString * _Nullable)toJSON:(NSStringEncoding)encoding error:(NSError * _Nullable * _Nullable)error;
        [Export ("toJSON:error:")]
        [return: NullAllowed]
        string ToJSON (nuint encoding, [NullAllowed] out NSError error);

        // -(NSData * _Nullable)toData:(NSError * _Nullable * _Nullable)error;
        [Export ("toData:")]
        [return: NullAllowed]
        NSData ToData ([NullAllowed] out NSError error);
    }

    // @interface ALBarcodeResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALBarcodeResult
    {
        // @property (copy, nonatomic) NSArray<ALBarcode *> * _Nonnull barcodes;
        [Export ("barcodes", ArgumentSemantic.Copy)]
        ALBarcode[] Barcodes { get; set; }
    }

    // @interface ALBarcode : NSObject
    [BaseType (typeof(NSObject))]
    interface ALBarcode
    {
        // @property (nonatomic, strong) ALAamva * _Nullable aamva;
        [NullAllowed, Export ("aamva", ArgumentSemantic.Strong)]
        ALAamva Aamva { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable base64Value;
        [NullAllowed, Export ("base64Value")]
        string Base64Value { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable coordinates;
        [NullAllowed, Export ("coordinates", ArgumentSemantic.Copy)]
        NSNumber[] Coordinates { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull format;
        [Export ("format")]
        string Format { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull value;
        [Export ("value")]
        string Value { get; set; }
    }

    // @interface ALAamva : NSObject
    [BaseType (typeof(NSObject))]
    interface ALAamva
    {
        // @property (nonatomic, strong) NSNumber * _Nullable aamvaVersion;
        [NullAllowed, Export ("aamvaVersion", ArgumentSemantic.Strong)]
        NSNumber AamvaVersion { get; set; }

        // @property (nonatomic, strong) ALBodyPart * _Nullable bodyPart;
        [NullAllowed, Export ("bodyPart", ArgumentSemantic.Strong)]
        ALBodyPart BodyPart { get; set; }
    }

    // @interface ALBodyPart : NSObject
    [BaseType (typeof(NSObject))]
    interface ALBodyPart
    {
        // @property (copy, nonatomic) NSString * _Nullable auditInformation;
        [NullAllowed, Export ("auditInformation")]
        string AuditInformation { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable cardRevisionDate;
        [NullAllowed, Export ("cardRevisionDate")]
        string CardRevisionDate { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable city;
        [NullAllowed, Export ("city")]
        string City { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable complianceType;
        [NullAllowed, Export ("complianceType")]
        string ComplianceType { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable countryID;
        [NullAllowed, Export ("countryID")]
        string CountryID { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable customerIDNumber;
        [NullAllowed, Export ("customerIDNumber")]
        string CustomerIDNumber { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth")]
        string DateOfBirth { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable dateOfExpiry;
        [NullAllowed, Export ("dateOfExpiry")]
        string DateOfExpiry { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable dateOfIssue;
        [NullAllowed, Export ("dateOfIssue")]
        string DateOfIssue { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable documentDiscriminator;
        [NullAllowed, Export ("documentDiscriminator")]
        string DocumentDiscriminator { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable drivingPrivilege;
        [NullAllowed, Export ("drivingPrivilege")]
        string DrivingPrivilege { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable endorsementCode;
        [NullAllowed, Export ("endorsementCode")]
        string EndorsementCode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable eyes;
        [NullAllowed, Export ("eyes")]
        string Eyes { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export ("firstName")]
        string FirstName { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable firstNameTruncated;
        [NullAllowed, Export ("firstNameTruncated")]
        string FirstNameTruncated { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable hair;
        [NullAllowed, Export ("hair")]
        string Hair { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable height;
        [NullAllowed, Export ("height")]
        string Height { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable inventoryControlNumber;
        [NullAllowed, Export ("inventoryControlNumber")]
        string InventoryControlNumber { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable jurisdictionCode;
        [NullAllowed, Export ("jurisdictionCode")]
        string JurisdictionCode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export ("lastName")]
        string LastName { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable lastNameTruncated;
        [NullAllowed, Export ("lastNameTruncated")]
        string LastNameTruncated { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable licenseClass;
        [NullAllowed, Export ("licenseClass")]
        string LicenseClass { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable middleName;
        [NullAllowed, Export ("middleName")]
        string MiddleName { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable middleNameTruncated;
        [NullAllowed, Export ("middleNameTruncated")]
        string MiddleNameTruncated { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable postalCode;
        [NullAllowed, Export ("postalCode")]
        string PostalCode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export ("sex")]
        string Sex { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable street;
        [NullAllowed, Export ("street")]
        string Street { get; set; }
    }

    // @interface ALCommercialTireIDResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALCommercialTireIDResult
    {
        // @property (copy, nonatomic) NSString * _Nullable text;
        [NullAllowed, Export ("text")]
        string Text { get; set; }
    }

    // @interface ALContainerResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALContainerResult
    {
        // @property (copy, nonatomic) NSString * _Nullable text;
        [NullAllowed, Export ("text")]
        string Text { get; set; }
    }

    // @interface ALCropRect : NSObject
    [BaseType (typeof(NSObject))]
    interface ALCropRect
    {
        // @property (assign, nonatomic) NSInteger height;
        [Export ("height")]
        nint Height { get; set; }

        // @property (assign, nonatomic) NSInteger width;
        [Export ("width")]
        nint Width { get; set; }

        // @property (assign, nonatomic) NSInteger x;
        [Export ("x")]
        nint X { get; set; }

        // @property (assign, nonatomic) NSInteger y;
        [Export ("y")]
        nint Y { get; set; }
    }

    // @interface ALJapaneseLandingPermissionResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALJapaneseLandingPermissionResult
    {
        // @property (nonatomic, strong) ALJlpResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        ALJlpResult Result { get; set; }
    }

    // @interface ALJlpResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALJlpResult
    {
        // @property (nonatomic, strong) ALJapaneseLandingPermissionResultField * _Nullable airport;
        [NullAllowed, Export ("airport", ArgumentSemantic.Strong)]
        ALJapaneseLandingPermissionResultField Airport { get; set; }

        // @property (nonatomic, strong) ALJapaneseLandingPermissionResultField * _Nullable dateOfExpiry;
        [NullAllowed, Export ("dateOfExpiry", ArgumentSemantic.Strong)]
        ALJapaneseLandingPermissionResultField DateOfExpiry { get; set; }

        // @property (nonatomic, strong) ALJapaneseLandingPermissionResultField * _Nullable dateOfIssue;
        [NullAllowed, Export ("dateOfIssue", ArgumentSemantic.Strong)]
        ALJapaneseLandingPermissionResultField DateOfIssue { get; set; }

        // @property (nonatomic, strong) ALJapaneseLandingPermissionResultField * _Nullable duration;
        [NullAllowed, Export ("duration", ArgumentSemantic.Strong)]
        ALJapaneseLandingPermissionResultField Duration { get; set; }

        // @property (nonatomic, strong) ALJapaneseLandingPermissionResultField * _Nullable status;
        [NullAllowed, Export ("status", ArgumentSemantic.Strong)]
        ALJapaneseLandingPermissionResultField Status { get; set; }
    }

    // @interface ALJapaneseLandingPermissionResultField : NSObject
    [BaseType (typeof(NSObject))]
    interface ALJapaneseLandingPermissionResultField
    {
        // @property (assign, nonatomic) NSInteger confidence;
        [Export ("confidence")]
        nint Confidence { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull text;
        [Export ("text")]
        string Text { get; set; }
    }

    // @interface ALLicensePlateResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALLicensePlateResult
    {
        // @property (assign, nonatomic) ALArea * _Nullable area;
        [NullAllowed, Export ("area", ArgumentSemantic.Assign)]
        ALArea Area { get; set; }

	    // @property (copy, nonatomic) NSString * _Nonnull country;
        [Export ("country")]
        string Country { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull plateText;
        [Export ("plateText")]
        string PlateText { get; set; }
    }

    // @interface ALMeterResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALMeterResult
    {
        // @property (copy, nonatomic) NSString * _Nullable position;
        [NullAllowed, Export ("position")]
        string Position { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable unit;
        [NullAllowed, Export ("unit")]
        string Unit { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull value;
        [Export ("value")]
        string Value { get; set; }
    }

    // @interface ALMrzResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALMrzResult
    {
        // @property (assign, nonatomic) BOOL allCheckDigitsValid;
        [Export ("allCheckDigitsValid")]
        bool AllCheckDigitsValid { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull checkDigitDateOfBirth;
        [Export ("checkDigitDateOfBirth")]
        string CheckDigitDateOfBirth { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull checkDigitDateOfExpiry;
        [Export ("checkDigitDateOfExpiry")]
        string CheckDigitDateOfExpiry { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull checkDigitDocumentNumber;
        [Export ("checkDigitDocumentNumber")]
        string CheckDigitDocumentNumber { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull checkDigitFinal;
        [Export ("checkDigitFinal")]
        string CheckDigitFinal { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull checkDigitPersonalNumber;
        [Export ("checkDigitPersonalNumber")]
        string CheckDigitPersonalNumber { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        string DateOfBirth { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull dateOfBirthObject;
        [Export ("dateOfBirthObject")]
        string DateOfBirthObject { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull dateOfExpiry;
        [Export ("dateOfExpiry")]
        string DateOfExpiry { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull dateOfExpiryObject;
        [Export ("dateOfExpiryObject")]
        string DateOfExpiryObject { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull documentNumber;
        [Export ("documentNumber")]
        string DocumentNumber { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull documentType;
        [Export ("documentType")]
        string DocumentType { get; set; }

        // @property (nonatomic, strong) ALFieldConfidences * _Nullable fieldConfidences;
        [NullAllowed, Export ("fieldConfidences", ArgumentSemantic.Strong)]
        ALFieldConfidences FieldConfidences { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export ("firstName")]
        string FirstName { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable givenNames;
        [NullAllowed, Export ("givenNames")]
        string GivenNames { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull issuingCountryCode;
        [Export ("issuingCountryCode")]
        string IssuingCountryCode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export ("lastName")]
        string LastName { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull mrzString;
        [Export ("mrzString")]
        string MrzString { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull nationalityCountryCode;
        [Export ("nationalityCountryCode")]
        string NationalityCountryCode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable optionalData;
        [NullAllowed, Export ("optionalData")]
        string OptionalData { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull personalNumber;
        [Export ("personalNumber")]
        string PersonalNumber { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull sex;
        [Export ("sex")]
        string Sex { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable surname;
        [NullAllowed, Export ("surname")]
        string Surname { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable vizAddress;
        [NullAllowed, Export ("vizAddress")]
        string VizAddress { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable vizDateOfBirth;
        [NullAllowed, Export ("vizDateOfBirth")]
        string VizDateOfBirth { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable vizDateOfBirthObject;
        [NullAllowed, Export ("vizDateOfBirthObject")]
        string VizDateOfBirthObject { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable vizDateOfExpiry;
        [NullAllowed, Export ("vizDateOfExpiry")]
        string VizDateOfExpiry { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable vizDateOfExpiryObject;
        [NullAllowed, Export ("vizDateOfExpiryObject")]
        string VizDateOfExpiryObject { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable vizDateOfIssue;
        [NullAllowed, Export ("vizDateOfIssue")]
        string VizDateOfIssue { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable vizDateOfIssueObject;
        [NullAllowed, Export ("vizDateOfIssueObject")]
        string VizDateOfIssueObject { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable vizGivenNames;
        [NullAllowed, Export ("vizGivenNames")]
        string VizGivenNames { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable vizSurname;
        [NullAllowed, Export ("vizSurname")]
        string VizSurname { get; set; }
    }

    // @interface ALFieldConfidences : NSObject
    [BaseType (typeof(NSObject))]
    interface ALFieldConfidences
    {
        // @property (nonatomic, strong) NSNumber * _Nullable checkDigitDateOfBirth;
        [NullAllowed, Export ("checkDigitDateOfBirth", ArgumentSemantic.Strong)]
        NSNumber CheckDigitDateOfBirth { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable checkDigitDateOfExpiry;
        [NullAllowed, Export ("checkDigitDateOfExpiry", ArgumentSemantic.Strong)]
        NSNumber CheckDigitDateOfExpiry { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable checkDigitDocumentNumber;
        [NullAllowed, Export ("checkDigitDocumentNumber", ArgumentSemantic.Strong)]
        NSNumber CheckDigitDocumentNumber { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable checkDigitFinal;
        [NullAllowed, Export ("checkDigitFinal", ArgumentSemantic.Strong)]
        NSNumber CheckDigitFinal { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable checkDigitPersonalNumber;
        [NullAllowed, Export ("checkDigitPersonalNumber", ArgumentSemantic.Strong)]
        NSNumber CheckDigitPersonalNumber { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth", ArgumentSemantic.Strong)]
        NSNumber DateOfBirth { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable dateOfExpiry;
        [NullAllowed, Export ("dateOfExpiry", ArgumentSemantic.Strong)]
        NSNumber DateOfExpiry { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable documentNumber;
        [NullAllowed, Export ("documentNumber", ArgumentSemantic.Strong)]
        NSNumber DocumentNumber { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable documentType;
        [NullAllowed, Export ("documentType", ArgumentSemantic.Strong)]
        NSNumber DocumentType { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable givenNames;
        [NullAllowed, Export ("givenNames", ArgumentSemantic.Strong)]
        NSNumber GivenNames { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable issuingCountryCode;
        [NullAllowed, Export ("issuingCountryCode", ArgumentSemantic.Strong)]
        NSNumber IssuingCountryCode { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable mrzString;
        [NullAllowed, Export ("mrzString", ArgumentSemantic.Strong)]
        NSNumber MrzString { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable nationalityCountryCode;
        [NullAllowed, Export ("nationalityCountryCode", ArgumentSemantic.Strong)]
        NSNumber NationalityCountryCode { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable optionalData;
        [NullAllowed, Export ("optionalData", ArgumentSemantic.Strong)]
        NSNumber OptionalData { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable personalNumber;
        [NullAllowed, Export ("personalNumber", ArgumentSemantic.Strong)]
        NSNumber PersonalNumber { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable sex;
        [NullAllowed, Export ("sex", ArgumentSemantic.Strong)]
        NSNumber Sex { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable surname;
        [NullAllowed, Export ("surname", ArgumentSemantic.Strong)]
        NSNumber Surname { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable vizAddress;
        [NullAllowed, Export ("vizAddress", ArgumentSemantic.Strong)]
        NSNumber VizAddress { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable vizDateOfBirth;
        [NullAllowed, Export ("vizDateOfBirth", ArgumentSemantic.Strong)]
        NSNumber VizDateOfBirth { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable vizDateOfExpiry;
        [NullAllowed, Export ("vizDateOfExpiry", ArgumentSemantic.Strong)]
        NSNumber VizDateOfExpiry { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable vizDateOfIssue;
        [NullAllowed, Export ("vizDateOfIssue", ArgumentSemantic.Strong)]
        NSNumber VizDateOfIssue { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable vizGivenNames;
        [NullAllowed, Export ("vizGivenNames", ArgumentSemantic.Strong)]
        NSNumber VizGivenNames { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable vizSurname;
        [NullAllowed, Export ("vizSurname", ArgumentSemantic.Strong)]
        NSNumber VizSurname { get; set; }
    }

    // @interface ALOcrResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALOcrResult
    {
        // @property (copy, nonatomic) NSString * _Nullable text;
        [NullAllowed, Export ("text")]
        string Text { get; set; }
    }

    // @interface ALOdometerResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALOdometerResult
    {
        // @property (copy, nonatomic) NSString * _Nonnull value;
        [Export ("value")]
        string Value { get; set; }
    }

    // @interface ALTinResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALTinResult
    {
        // @property (copy, nonatomic) NSString * _Nullable productionDate;
        [NullAllowed, Export ("productionDate")]
        string ProductionDate { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable resultPrettified;
        [NullAllowed, Export ("resultPrettified")]
        string ResultPrettified { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull text;
        [Export ("text")]
        string Text { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable tireAgeInYearsRoundedDown;
        [NullAllowed, Export ("tireAgeInYearsRoundedDown")]
        string TireAgeInYearsRoundedDown { get; set; }
    }

    // @interface ALTireMakeResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALTireMakeResult
    {
        // @property (copy, nonatomic) NSString * _Nullable text;
        [NullAllowed, Export ("text")]
        string Text { get; set; }
    }

    // @interface ALTireSizeResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALTireSizeResult
    {
        // @property (nonatomic, strong) ALTireSizeResultField * _Nullable commercialTire;
        [NullAllowed, Export ("commercialTire", ArgumentSemantic.Strong)]
        ALTireSizeResultField CommercialTire { get; set; }

        // @property (nonatomic, strong) ALTireSizeResultField * _Nullable construction;
        [NullAllowed, Export ("construction", ArgumentSemantic.Strong)]
        ALTireSizeResultField Construction { get; set; }

        // @property (nonatomic, strong) ALTireSizeResultField * _Nullable diameter;
        [NullAllowed, Export ("diameter", ArgumentSemantic.Strong)]
        ALTireSizeResultField Diameter { get; set; }

        // @property (nonatomic, strong) ALTireSizeResultField * _Nullable extraLoad;
        [NullAllowed, Export ("extraLoad", ArgumentSemantic.Strong)]
        ALTireSizeResultField ExtraLoad { get; set; }

        // @property (nonatomic, strong) ALTireSizeResultField * _Nullable loadIndex;
        [NullAllowed, Export ("loadIndex", ArgumentSemantic.Strong)]
        ALTireSizeResultField LoadIndex { get; set; }

        // @property (nonatomic, strong) ALTireSizeResultField * _Nullable prettifiedString;
        [NullAllowed, Export ("prettifiedString", ArgumentSemantic.Strong)]
        ALTireSizeResultField PrettifiedString { get; set; }

        // @property (nonatomic, strong) ALTireSizeResultField * _Nullable prettifiedStringWithMeta;
        [NullAllowed, Export ("prettifiedStringWithMeta", ArgumentSemantic.Strong)]
        ALTireSizeResultField PrettifiedStringWithMeta { get; set; }

        // @property (nonatomic, strong) ALTireSizeResultField * _Nullable ratio;
        [NullAllowed, Export ("ratio", ArgumentSemantic.Strong)]
        ALTireSizeResultField Ratio { get; set; }

        // @property (nonatomic, strong) ALTireSizeResultField * _Nullable speedRating;
        [NullAllowed, Export ("speedRating", ArgumentSemantic.Strong)]
        ALTireSizeResultField SpeedRating { get; set; }

        // @property (nonatomic, strong) ALTireSizeResultField * _Nullable text;
        [NullAllowed, Export ("text", ArgumentSemantic.Strong)]
        ALTireSizeResultField Text { get; set; }

        // @property (nonatomic, strong) ALTireSizeResultField * _Nullable vehicleType;
        [NullAllowed, Export ("vehicleType", ArgumentSemantic.Strong)]
        ALTireSizeResultField VehicleType { get; set; }

        // @property (nonatomic, strong) ALTireSizeResultField * _Nullable width;
        [NullAllowed, Export ("width", ArgumentSemantic.Strong)]
        ALTireSizeResultField Width { get; set; }

        // @property (nonatomic, strong) ALTireSizeResultField * _Nullable winter;
        [NullAllowed, Export ("winter", ArgumentSemantic.Strong)]
        ALTireSizeResultField Winter { get; set; }
    }

    // @interface ALTireSizeResultField : NSObject
    [BaseType (typeof(NSObject))]
    interface ALTireSizeResultField
    {
        // @property (nonatomic, strong) NSNumber * _Nullable confidence;
        [NullAllowed, Export ("confidence", ArgumentSemantic.Strong)]
        NSNumber Confidence { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable text;
        [NullAllowed, Export ("text")]
        string Text { get; set; }
    }

    // @interface ALUniversalIDResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALUniversalIDResult
    {
        // @property (nonatomic, strong) ALIDResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        ALIDResult Result { get; set; }

        // @property (nonatomic, strong) ALVisualization * _Nullable visualization;
        [NullAllowed, Export ("visualization", ArgumentSemantic.Strong)]
        ALVisualization Visualization { get; set; }
    }

    // @interface ALIDResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALIDResult
    {
        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable additionalInformation;
        [NullAllowed, Export ("additionalInformation", ArgumentSemantic.Strong)]
        ALUniversalIDResultField AdditionalInformation { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable additionalInformation1;
        [NullAllowed, Export ("additionalInformation1", ArgumentSemantic.Strong)]
        ALUniversalIDResultField AdditionalInformation1 { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable additionalInformation2;
        [NullAllowed, Export ("additionalInformation2", ArgumentSemantic.Strong)]
        ALUniversalIDResultField AdditionalInformation2 { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable additionalInformation3;
        [NullAllowed, Export ("additionalInformation3", ArgumentSemantic.Strong)]
        ALUniversalIDResultField AdditionalInformation3 { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable address;
        [NullAllowed, Export ("address", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Address { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable age;
        [NullAllowed, Export ("age", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Age { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable airport;
        [NullAllowed, Export ("airport", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Airport { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable allCheckDigitsValid;
        [NullAllowed, Export ("allCheckDigitsValid", ArgumentSemantic.Strong)]
        ALUniversalIDResultField AllCheckDigitsValid { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable audit;
        [NullAllowed, Export ("audit", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Audit { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable authority;
        [NullAllowed, Export ("authority", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Authority { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable barcode;
        [NullAllowed, Export ("barcode", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Barcode { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable bloodType;
        [NullAllowed, Export ("bloodType", ArgumentSemantic.Strong)]
        ALUniversalIDResultField BloodType { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable cardAccessNumber;
        [NullAllowed, Export ("cardAccessNumber", ArgumentSemantic.Strong)]
        ALUniversalIDResultField CardAccessNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable checkDigitDateOfBirth;
        [NullAllowed, Export ("checkDigitDateOfBirth", ArgumentSemantic.Strong)]
        ALUniversalIDResultField CheckDigitDateOfBirth { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable checkDigitDateOfExpiry;
        [NullAllowed, Export ("checkDigitDateOfExpiry", ArgumentSemantic.Strong)]
        ALUniversalIDResultField CheckDigitDateOfExpiry { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable checkDigitDocumentNumber;
        [NullAllowed, Export ("checkDigitDocumentNumber", ArgumentSemantic.Strong)]
        ALUniversalIDResultField CheckDigitDocumentNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable checkDigitFinal;
        [NullAllowed, Export ("checkDigitFinal", ArgumentSemantic.Strong)]
        ALUniversalIDResultField CheckDigitFinal { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable checkDigitPersonalNumber;
        [NullAllowed, Export ("checkDigitPersonalNumber", ArgumentSemantic.Strong)]
        ALUniversalIDResultField CheckDigitPersonalNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable cityNumber;
        [NullAllowed, Export ("cityNumber", ArgumentSemantic.Strong)]
        ALUniversalIDResultField CityNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable conditions;
        [NullAllowed, Export ("conditions", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Conditions { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable country;
        [NullAllowed, Export ("country", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Country { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DateOfBirth { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable dateOfBirthObject;
        [NullAllowed, Export ("dateOfBirthObject", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DateOfBirthObject { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable dateOfExpiry;
        [NullAllowed, Export ("dateOfExpiry", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DateOfExpiry { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable dateOfExpiryObject;
        [NullAllowed, Export ("dateOfExpiryObject", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DateOfExpiryObject { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable dateOfIssue;
        [NullAllowed, Export ("dateOfIssue", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DateOfIssue { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable dateOfRegistration;
        [NullAllowed, Export ("dateOfRegistration", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DateOfRegistration { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable degreeOfDisability;
        [NullAllowed, Export ("degreeOfDisability", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DegreeOfDisability { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable divisionNumber;
        [NullAllowed, Export ("divisionNumber", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DivisionNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable documentCategoryDefinition;
        [NullAllowed, Export ("documentCategoryDefinition", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DocumentCategoryDefinition { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable documentDiscriminator;
        [NullAllowed, Export ("documentDiscriminator", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DocumentDiscriminator { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable documentNumber;
        [NullAllowed, Export ("documentNumber", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DocumentNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable documentRegionDefinition;
        [NullAllowed, Export ("documentRegionDefinition", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DocumentRegionDefinition { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable documentSideDefinition;
        [NullAllowed, Export ("documentSideDefinition", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DocumentSideDefinition { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable documentType;
        [NullAllowed, Export ("documentType", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DocumentType { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable documentTypeDefinition;
        [NullAllowed, Export ("documentTypeDefinition", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DocumentTypeDefinition { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable documentVersionsDefinition;
        [NullAllowed, Export ("documentVersionsDefinition", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DocumentVersionsDefinition { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable duplicate;
        [NullAllowed, Export ("duplicate", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Duplicate { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable duration;
        [NullAllowed, Export ("duration", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Duration { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable educationalInstitution;
        [NullAllowed, Export ("educationalInstitution", ArgumentSemantic.Strong)]
        ALUniversalIDResultField EducationalInstitution { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable employer;
        [NullAllowed, Export ("employer", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Employer { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable endorsements;
        [NullAllowed, Export ("endorsements", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Endorsements { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable eyes;
        [NullAllowed, Export ("eyes", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Eyes { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable face;
        [NullAllowed, Export ("face", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Face { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable familyNumber;
        [NullAllowed, Export ("familyNumber", ArgumentSemantic.Strong)]
        ALUniversalIDResultField FamilyNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable familyRelation;
        [NullAllowed, Export ("familyRelation", ArgumentSemantic.Strong)]
        ALUniversalIDResultField FamilyRelation { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable fathersName;
        [NullAllowed, Export ("fathersName", ArgumentSemantic.Strong)]
        ALUniversalIDResultField FathersName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable firstIssued;
        [NullAllowed, Export ("firstIssued", ArgumentSemantic.Strong)]
        ALUniversalIDResultField FirstIssued { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable firstName;
        [NullAllowed, Export ("firstName", ArgumentSemantic.Strong)]
        ALUniversalIDResultField FirstName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable folio;
        [NullAllowed, Export ("folio", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Folio { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable formattedDateOfBirth;
        [NullAllowed, Export ("formattedDateOfBirth", ArgumentSemantic.Strong)]
        ALUniversalIDResultField FormattedDateOfBirth { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable formattedDateOfExpiry;
        [NullAllowed, Export ("formattedDateOfExpiry", ArgumentSemantic.Strong)]
        ALUniversalIDResultField FormattedDateOfExpiry { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable formattedDateOfIssue;
        [NullAllowed, Export ("formattedDateOfIssue", ArgumentSemantic.Strong)]
        ALUniversalIDResultField FormattedDateOfIssue { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable fullName;
        [NullAllowed, Export ("fullName", ArgumentSemantic.Strong)]
        ALUniversalIDResultField FullName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable givenNames;
        [NullAllowed, Export ("givenNames", ArgumentSemantic.Strong)]
        ALUniversalIDResultField GivenNames { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable hair;
        [NullAllowed, Export ("hair", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Hair { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable headOfFamily;
        [NullAllowed, Export ("headOfFamily", ArgumentSemantic.Strong)]
        ALUniversalIDResultField HeadOfFamily { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable height;
        [NullAllowed, Export ("height", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Height { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable hologram;
        [NullAllowed, Export ("hologram", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Hologram { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable initials;
        [NullAllowed, Export ("initials", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Initials { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable initialsAndDateOfBirth;
        [NullAllowed, Export ("initialsAndDateOfBirth", ArgumentSemantic.Strong)]
        ALUniversalIDResultField InitialsAndDateOfBirth { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable issuingCountryCode;
        [NullAllowed, Export ("issuingCountryCode", ArgumentSemantic.Strong)]
        ALUniversalIDResultField IssuingCountryCode { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable lastName;
        [NullAllowed, Export ("lastName", ArgumentSemantic.Strong)]
        ALUniversalIDResultField LastName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable licenseClass;
        [NullAllowed, Export ("licenseClass", ArgumentSemantic.Strong)]
        ALUniversalIDResultField LicenseClass { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable licenseType;
        [NullAllowed, Export ("licenseType", ArgumentSemantic.Strong)]
        ALUniversalIDResultField LicenseType { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable maidenName;
        [NullAllowed, Export ("maidenName", ArgumentSemantic.Strong)]
        ALUniversalIDResultField MaidenName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable militaryRank;
        [NullAllowed, Export ("militaryRank", ArgumentSemantic.Strong)]
        ALUniversalIDResultField MilitaryRank { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable mirrorNumber;
        [NullAllowed, Export ("mirrorNumber", ArgumentSemantic.Strong)]
        ALUniversalIDResultField MirrorNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable mothersName;
        [NullAllowed, Export ("mothersName", ArgumentSemantic.Strong)]
        ALUniversalIDResultField MothersName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable mrz;
        [NullAllowed, Export ("mrz", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Mrz { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable mrzString;
        [NullAllowed, Export ("mrzString", ArgumentSemantic.Strong)]
        ALUniversalIDResultField MrzString { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable municipalityNumber;
        [NullAllowed, Export ("municipalityNumber", ArgumentSemantic.Strong)]
        ALUniversalIDResultField MunicipalityNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable nationality;
        [NullAllowed, Export ("nationality", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Nationality { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable nationalityCountryCode;
        [NullAllowed, Export ("nationalityCountryCode", ArgumentSemantic.Strong)]
        ALUniversalIDResultField NationalityCountryCode { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable occupation;
        [NullAllowed, Export ("occupation", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Occupation { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable office;
        [NullAllowed, Export ("office", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Office { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable optionalData;
        [NullAllowed, Export ("optionalData", ArgumentSemantic.Strong)]
        ALUniversalIDResultField OptionalData { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable parentsFirstName;
        [NullAllowed, Export ("parentsFirstName", ArgumentSemantic.Strong)]
        ALUniversalIDResultField ParentsFirstName { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable parish;
        [NullAllowed, Export ("parish", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Parish { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable personalNumber;
        [NullAllowed, Export ("personalNumber", ArgumentSemantic.Strong)]
        ALUniversalIDResultField PersonalNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable placeAndDateOfBirth;
        [NullAllowed, Export ("placeAndDateOfBirth", ArgumentSemantic.Strong)]
        ALUniversalIDResultField PlaceAndDateOfBirth { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable placeOfBirth;
        [NullAllowed, Export ("placeOfBirth", ArgumentSemantic.Strong)]
        ALUniversalIDResultField PlaceOfBirth { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable previousType;
        [NullAllowed, Export ("previousType", ArgumentSemantic.Strong)]
        ALUniversalIDResultField PreviousType { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable pseudonym;
        [NullAllowed, Export ("pseudonym", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Pseudonym { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable religion;
        [NullAllowed, Export ("religion", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Religion { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable restrictions;
        [NullAllowed, Export ("restrictions", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Restrictions { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable sex;
        [NullAllowed, Export ("sex", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Sex { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable signature;
        [NullAllowed, Export ("signature", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Signature { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable socialSecurityNumber;
        [NullAllowed, Export ("socialSecurityNumber", ArgumentSemantic.Strong)]
        ALUniversalIDResultField SocialSecurityNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable state;
        [NullAllowed, Export ("state", ArgumentSemantic.Strong)]
        ALUniversalIDResultField State { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable stateNumber;
        [NullAllowed, Export ("stateNumber", ArgumentSemantic.Strong)]
        ALUniversalIDResultField StateNumber { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable status;
        [NullAllowed, Export ("status", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Status { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable surname;
        [NullAllowed, Export ("surname", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Surname { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable vizAddress;
        [NullAllowed, Export ("vizAddress", ArgumentSemantic.Strong)]
        ALUniversalIDResultField VizAddress { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable vizDateOfBirth;
        [NullAllowed, Export ("vizDateOfBirth", ArgumentSemantic.Strong)]
        ALUniversalIDResultField VizDateOfBirth { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable vizDateOfBirthObject;
        [NullAllowed, Export ("vizDateOfBirthObject", ArgumentSemantic.Strong)]
        ALUniversalIDResultField VizDateOfBirthObject { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable vizDateOfExpiry;
        [NullAllowed, Export ("vizDateOfExpiry", ArgumentSemantic.Strong)]
        ALUniversalIDResultField VizDateOfExpiry { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable vizDateOfExpiryObject;
        [NullAllowed, Export ("vizDateOfExpiryObject", ArgumentSemantic.Strong)]
        ALUniversalIDResultField VizDateOfExpiryObject { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable vizDateOfIssue;
        [NullAllowed, Export ("vizDateOfIssue", ArgumentSemantic.Strong)]
        ALUniversalIDResultField VizDateOfIssue { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable vizDateOfIssueObject;
        [NullAllowed, Export ("vizDateOfIssueObject", ArgumentSemantic.Strong)]
        ALUniversalIDResultField VizDateOfIssueObject { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable vizGivenNames;
        [NullAllowed, Export ("vizGivenNames", ArgumentSemantic.Strong)]
        ALUniversalIDResultField VizGivenNames { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable vizSurname;
        [NullAllowed, Export ("vizSurname", ArgumentSemantic.Strong)]
        ALUniversalIDResultField VizSurname { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable voterID;
        [NullAllowed, Export ("voterID", ArgumentSemantic.Strong)]
        ALUniversalIDResultField VoterID { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable weight;
        [NullAllowed, Export ("weight", ArgumentSemantic.Strong)]
        ALUniversalIDResultField Weight { get; set; }

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable workPermitNumber;
        [NullAllowed, Export ("workPermitNumber", ArgumentSemantic.Strong)]
        ALUniversalIDResultField WorkPermitNumber { get; set; }
    }

    // @interface ALUniversalIDResultField : NSObject
    [BaseType (typeof(NSObject))]
    interface ALUniversalIDResultField
    {
        // @property (nonatomic, strong) ALDateValue * _Nullable dateValue;
        [NullAllowed, Export ("dateValue", ArgumentSemantic.Strong)]
        ALDateValue DateValue { get; set; }

        // @property (nonatomic, strong) ALTextValues * _Nonnull textValues;
        [Export ("textValues", ArgumentSemantic.Strong)]
        ALTextValues TextValues { get; set; }
    }

    // @interface ALDateValue : NSObject
    [BaseType (typeof(NSObject))]
    interface ALDateValue
    {
        // @property (assign, nonatomic) NSInteger confidence;
        [Export ("confidence")]
        nint Confidence { get; set; }

        // @property (assign, nonatomic) NSInteger day;
        [Export ("day")]
        nint Day { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull formattedText;
        [Export ("formattedText")]
        string FormattedText { get; set; }

        // @property (assign, nonatomic) NSInteger month;
        [Export ("month")]
        nint Month { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull text;
        [Export ("text")]
        string Text { get; set; }

        // @property (assign, nonatomic) NSInteger year;
        [Export ("year")]
        nint Year { get; set; }
    }

    // @interface ALTextValues : NSObject
    [BaseType (typeof(NSObject))]
    interface ALTextValues
    {
        // @property (nonatomic, strong) ALArabic * _Nullable arabic;
        [NullAllowed, Export ("arabic", ArgumentSemantic.Strong)]
        ALArabic Arabic { get; set; }

        // @property (nonatomic, strong) ALCyrillic * _Nullable cyrillic;
        [NullAllowed, Export ("cyrillic", ArgumentSemantic.Strong)]
        ALCyrillic Cyrillic { get; set; }

        // @property (nonatomic, strong) ALLatin * _Nullable latin;
        [NullAllowed, Export ("latin", ArgumentSemantic.Strong)]
        ALLatin Latin { get; set; }
    }

    // @interface ALArabic : NSObject
    [BaseType (typeof(NSObject))]
    interface ALArabic
    {
        // @property (assign, nonatomic) NSInteger confidence;
        [Export ("confidence")]
        nint Confidence { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull text;
        [Export ("text")]
        string Text { get; set; }
    }

    // @interface ALCyrillic : NSObject
    [BaseType (typeof(NSObject))]
    interface ALCyrillic
    {
        // @property (assign, nonatomic) NSInteger confidence;
        [Export ("confidence")]
        nint Confidence { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull text;
        [Export ("text")]
        string Text { get; set; }
    }

    // @interface ALLatin : NSObject
    [BaseType (typeof(NSObject))]
    interface ALLatin
    {
        // @property (assign, nonatomic) NSInteger confidence;
        [Export ("confidence")]
        nint Confidence { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull text;
        [Export ("text")]
        string Text { get; set; }
    }

    // @interface ALVisualization : NSObject
    [BaseType (typeof(NSObject))]
    interface ALVisualization
    {
        // @property (copy, nonatomic) NSArray<NSArray<NSArray<NSNumber *> *> *> * _Nullable contourPoints;
        [NullAllowed, Export ("contourPoints", ArgumentSemantic.Copy)]
        NSArray<NSArray<NSNumber>>[] ContourPoints { get; set; }

        // @property (copy, nonatomic) NSArray<NSArray<NSNumber *> *> * _Nonnull contours;
        [Export ("contours", ArgumentSemantic.Copy)]
        NSArray<NSNumber>[] Contours { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nonnull textRect;
        [Export ("textRect", ArgumentSemantic.Copy)]
        NSNumber[] TextRect { get; set; }
    }

    // @interface ALVehicleRegistrationCertificateResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALVehicleRegistrationCertificateResult
    {
        // @property (nonatomic, strong) ALVrcResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        ALVrcResult Result { get; set; }

        // @property (nonatomic, strong) ALVisualization * _Nonnull visualization;
        [Export ("visualization", ArgumentSemantic.Strong)]
        ALVisualization Visualization { get; set; }
    }

    // @interface ALVrcResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALVrcResult
    {
        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable address;
        [NullAllowed, Export ("address", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField Address { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable brand;
        [NullAllowed, Export ("brand", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField Brand { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable displacement;
        [NullAllowed, Export ("displacement", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField Displacement { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable documentCategoryDefinition;
        [NullAllowed, Export ("documentCategoryDefinition", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField DocumentCategoryDefinition { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable documentNumber;
        [NullAllowed, Export ("documentNumber", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField DocumentNumber { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable documentRegionDefinition;
        [NullAllowed, Export ("documentRegionDefinition", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField DocumentRegionDefinition { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable documentSideDefinition;
        [NullAllowed, Export ("documentSideDefinition", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField DocumentSideDefinition { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable documentTypeDefinition;
        [NullAllowed, Export ("documentTypeDefinition", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField DocumentTypeDefinition { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable documentVersionsDefinition;
        [NullAllowed, Export ("documentVersionsDefinition", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField DocumentVersionsDefinition { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable firstIssued;
        [NullAllowed, Export ("firstIssued", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField FirstIssued { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable firstName;
        [NullAllowed, Export ("firstName", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField FirstName { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable formattedFirstIssued;
        [NullAllowed, Export ("formattedFirstIssued", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField FormattedFirstIssued { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable lastName;
        [NullAllowed, Export ("lastName", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField LastName { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable licensePlate;
        [NullAllowed, Export ("licensePlate", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField LicensePlate { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable manufacturerCode;
        [NullAllowed, Export ("manufacturerCode", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField ManufacturerCode { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable tire;
        [NullAllowed, Export ("tire", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField Tire { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable vehicleIdentificationNumber;
        [NullAllowed, Export ("vehicleIdentificationNumber", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField VehicleIdentificationNumber { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable vehicleType;
        [NullAllowed, Export ("vehicleType", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField VehicleType { get; set; }

        // @property (nonatomic, strong) ALVehicleRegistrationCertificateResultField * _Nullable vehicleTypeCode;
        [NullAllowed, Export ("vehicleTypeCode", ArgumentSemantic.Strong)]
        ALVehicleRegistrationCertificateResultField VehicleTypeCode { get; set; }
    }

    // @interface ALVehicleRegistrationCertificateResultField : NSObject
    [BaseType (typeof(NSObject))]
    interface ALVehicleRegistrationCertificateResultField
    {
        // @property (assign, nonatomic) NSInteger confidence;
        [Export ("confidence")]
        nint Confidence { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull text;
        [Export ("text")]
        string Text { get; set; }
    }

    // @interface ALVinResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALVinResult
    {
        // @property (copy, nonatomic) NSString * _Nullable text;
        [NullAllowed, Export ("text")]
        string Text { get; set; }
    }

    // @interface ALExtras (ALPluginResult) <ALJSONStringRepresentable>
    [Protocol, Model]
    [BaseType (typeof(ALPluginResult))]
    interface ALPluginResult_ALExtras : ALJSONStringRepresentable
    {
        // +(ALPluginResult * _Nullable)withJSONString:(NSString * _Nonnull)JSONString;
        [Static]
        [Export ("withJSONString:")]
        [return: NullAllowed]
        ALPluginResult WithJSONString (string JSONString);

        // +(ALPluginResult * _Nullable)withJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary;
        [Static]
        [Export ("withJSONDictionary:")]
        [return: NullAllowed]
        ALPluginResult WithJSONDictionary (NSDictionary JSONDictionary);

        // -(instancetype _Nullable)initWithJSONString:(NSString * _Nonnull)JSONString error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONString:error:")]
        IntPtr Constructor (string JSONString, [NullAllowed] out NSError error);

        // -(instancetype _Nullable)initWithJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONDictionary:error:")]
        IntPtr Constructor (NSDictionary JSONDictionary, [NullAllowed] out NSError error);

        // // -(NSArray<NSDictionary<NSString *,NSString *> *> * _Nonnull)fieldList;
        // [Export ("fieldList")]
        // NSDictionary<NSString, NSString>[] FieldList { get; }
    }

    // @interface ALScanPlugin : NSObject
    [BaseType (typeof(NSObject))]
    interface ALScanPlugin
    {
        [Wrap ("WeakDelegate")]
        [NullAllowed]
        ALScanPluginDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ALScanPluginDelegate> _Nullable delegate;
        [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic, strong) ALAssetController * _Nonnull assetController;
        [Export ("assetController", ArgumentSemantic.Strong)]
        ALAssetController AssetController { get; set; }

        // @property (readonly, nonatomic, strong) ALPluginConfig * _Nonnull pluginConfig;
        [Export ("pluginConfig", ArgumentSemantic.Strong)]
        ALPluginConfig PluginConfig { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull pluginID;
        [Export ("pluginID")]
        string PluginID { get; }

        // @property (readonly, nonatomic) BOOL isStarted;
        [Export ("isStarted")]
        bool IsStarted { get; }

        // @property (readonly, nonatomic) BOOL isRunning;
        [Export ("isRunning")]
        bool IsRunning { get; }

        // @property (assign, nonatomic) CGRect ROI;
        [Export ("ROI", ArgumentSemantic.Assign)]
        CGRect ROI { get; set; }

    // -(id _Nullable)initWithConfig:(ALPluginConfig * _Nonnull)pluginConfig error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithConfig:error:")]
        IntPtr Constructor (ALPluginConfig pluginConfig, [NullAllowed] out NSError error);

        // -(id _Nullable)initWithJSONDictionary:(NSDictionary * _Nonnull)jsonConfig error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONDictionary:error:")]
        IntPtr Constructor (NSDictionary jsonConfig, [NullAllowed] out NSError error);

        // -(void)start;
        [Export ("start")]
        void Start ();

        // -(void)stop;
        [Export ("stop")]
        void Stop ();
    }

    // @protocol ALScanPluginDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface ALScanPluginDelegate
    {
        // @optional -(void)scanPlugin:(ALScanPlugin * _Nonnull)scanPlugin errorReceived:(ALEvent * _Nonnull)event;
        [Export ("scanPlugin:errorReceived:")]
        void ErrorReceived (ALScanPlugin scanPlugin, ALEvent @event);

        // @optional -(void)scanPlugin:(ALScanPlugin * _Nonnull)scanPlugin visualFeedbackReceived:(ALEvent * _Nonnull)event;
        [Export ("scanPlugin:visualFeedbackReceived:")]
        void VisualFeedbackReceived (ALScanPlugin scanPlugin, ALEvent @event);

        // @optional -(void)scanPlugin:(ALScanPlugin * _Nonnull)scanPlugin scanInfoReceived:(ALEvent * _Nonnull)event;
        [Export ("scanPlugin:scanInfoReceived:")]
        void ScanInfoReceived (ALScanPlugin scanPlugin, ALEvent @event);

        // @optional -(void)scanPlugin:(ALScanPlugin * _Nonnull)scanPlugin scanRunSkipped:(ALEvent * _Nonnull)event;
        [Export ("scanPlugin:scanRunSkipped:")]
        void ScanRunSkipped (ALScanPlugin scanPlugin, ALEvent @event);

        // @optional -(void)scanPlugin:(ALScanPlugin * _Nonnull)scanPlugin resultReceived:(ALScanResult * _Nonnull)scanResult;
        [Export ("scanPlugin:resultReceived:")]
        void ResultReceived (ALScanPlugin scanPlugin, ALScanResult scanResult);
    }

    // @interface ALScanResult : NSObject <ALJSONStringRepresentable>
    [BaseType (typeof(NSObject))]
    interface ALScanResult : ALJSONStringRepresentable
    {
        // @property (readonly, nonatomic) NSString * _Nonnull blobKey;
        [Export ("blobKey")]
        string BlobKey { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull pluginID;
        [Export ("pluginID")]
        string PluginID { get; }

        // @property (readonly, nonatomic) UIImage * _Nonnull fullSizeImage;
        [Export ("fullSizeImage")]
        UIImage FullSizeImage { get; }

        // @property (readonly, nonatomic) UIImage * _Nonnull croppedImage;
        [Export ("croppedImage")]
        UIImage CroppedImage { get; }

        // @property (readonly, nonatomic) UIImage * _Nullable faceImage;
        [NullAllowed, Export ("faceImage")]
        UIImage FaceImage { get; }

        // @property (readonly, nonatomic) ALPluginResult * _Nonnull pluginResult;
        [Export ("pluginResult")]
        ALPluginResult PluginResult { get; }

        // @property (readonly, nonatomic) NSDictionary * _Nonnull resultDictionary;
        [Export ("resultDictionary")]
        NSDictionary ResultDictionary { get; }

        // -(instancetype _Nullable)initWithJSONDictionary:(NSDictionary * _Nonnull)resultJSON image:(UIImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONDictionary:image:error:")]
        IntPtr Constructor (NSDictionary resultJSON, UIImage image, [NullAllowed] out NSError error);

        // -(instancetype _Nullable)initWithScanResultEvent:(ALEvent * _Nonnull)event;
	    [Export ("initWithScanResultEvent:")]
        IntPtr Constructor (ALEvent @event);

        // +(ALScanResult * _Nullable)withScanResultEvent:(ALEvent * _Nonnull)event;
	    [Static]
        [Export ("withScanResultEvent:")]
	    [return: NullAllowed]
        ALScanResult WithScanResultEvent (ALEvent @event);
    }

    // @interface ALScanViewConfig : NSObject <ALJSONStringRepresentable>
    [BaseType (typeof(NSObject))]
    interface ALScanViewConfig : ALJSONStringRepresentable
    {
        // @property (readonly, nonatomic) ALCameraConfig * _Nonnull cameraConfig;
        [Export ("cameraConfig")]
        ALCameraConfig CameraConfig { get; }

        // @property (readonly, nonatomic) ALFlashConfig * _Nonnull flashConfig;
        [Export ("flashConfig")]
        ALFlashConfig FlashConfig { get; }

        // -(instancetype _Nonnull)initWithCameraConfig:(ALCameraConfig * _Nullable)cameraConfig flashConfig:(ALFlashConfig * _Nullable)flashConfig __attribute__((objc_designated_initializer));
        [Export ("initWithCameraConfig:flashConfig:")]
        [DesignatedInitializer]
        IntPtr Constructor ([NullAllowed] ALCameraConfig cameraConfig, [NullAllowed] ALFlashConfig flashConfig);

        // -(instancetype _Nullable)initWithJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONDictionary:error:")]
        IntPtr Constructor (NSDictionary JSONDictionary, [NullAllowed] out NSError error);

        // +(ALScanViewConfig * _Nullable)withJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary;
        [Static]
        [Export ("withJSONDictionary:")]
        [return: NullAllowed]
        ALScanViewConfig WithJSONDictionary (NSDictionary JSONDictionary);

        // +(ALScanViewConfig * _Nonnull)defaultScanViewConfig;
        [Static]
        [Export ("defaultScanViewConfig")]
        ALScanViewConfig DefaultScanViewConfig { get; }

        // +(ALScanViewConfig * _Nonnull)withCameraConfig:(ALCameraConfig * _Nullable)cameraConfig flashConfig:(ALFlashConfig * _Nullable)flashConfig;
        [Static]
        [Export ("withCameraConfig:flashConfig:")]
        ALScanViewConfig WithCameraConfig ([NullAllowed] ALCameraConfig cameraConfig, [NullAllowed] ALFlashConfig flashConfig);
    }

    // @protocol ALScanViewPluginBase <NSObject>
    /*
    Check whether adding [Model] to this declaration is appropriate.
    [Model] is used to generate a C# class that implements this protocol,
    and might be useful for protocols that consumers are supposed to implement,
    since consumers can subclass the generated class instead of implementing
    the generated interface. If consumers are not supposed to implement this
    protocol, then [Model] is redundant and will generate code that will never
    be used.
    */
    [Protocol]
    [BaseType (typeof(NSObject))]
    interface ALScanViewPluginBase
    {
        // @required @property (readonly, nonatomic) NSString * _Nonnull pluginID;
        [Export ("pluginID")]
        string PluginID { get; }

        // @required @property (readonly, nonatomic) NSArray<id<ALScanViewPluginBase>> * _Nonnull children;
        [Export ("children")]
        ALScanViewPluginBase[] Children { get; }

        // @required @property (readonly, nonatomic) BOOL isStarted;
        [Export ("isStarted")]
        bool IsStarted { get; }

        // @required -(BOOL)startWithError:(NSError * _Nullable * _Nullable)error;
        [Export ("startWithError:")]
        bool StartWithError ([NullAllowed] out NSError error);

        // @required -(void)stop;
        [Export ("stop")]
        void Stop ();
    }
    
    // @interface ALCutoutConfig : NSObject <ALJSONStringRepresentable>
    [BaseType (typeof(NSObject))]
    interface ALCutoutConfig : ALJSONStringRepresentable
    {
        // @property (readonly, nonatomic) ALCutoutAlignment alignment;
        [Export ("alignment")]
        ALCutoutAlignment Alignment { get; }

        // @property (readonly, nonatomic) NSInteger width;
        [Export ("width")]
        nint Width { get; }

        // @property (readonly, nonatomic) NSInteger maxWidthPercent;
        [Export ("maxWidthPercent")]
        nint MaxWidthPercent { get; }

        // @property (readonly, nonatomic) NSInteger maxHeightPercent;
        [Export ("maxHeightPercent")]
        nint MaxHeightPercent { get; }

        // @property (readonly, nonatomic) CGSize ratioFromSize;
        [Export ("ratioFromSize")]
        CGSize RatioFromSize { get; }

        // @property (readonly, nonatomic) NSInteger strokeWidth;
        [Export ("strokeWidth")]
        nint StrokeWidth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull strokeColor;
        [Export ("strokeColor")]
        string StrokeColor { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull feedbackStrokeColor;
        [Export ("feedbackStrokeColor")]
        string FeedbackStrokeColor { get; }

        // @property (readonly, nonatomic) NSInteger cornerRadius;
        [Export ("cornerRadius")]
        nint CornerRadius { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull outerColor;
        [Export ("outerColor")]
        string OuterColor { get; }

        // @property (readonly, nonatomic) CGPoint offset;
        [Export ("offset")]
        CGPoint Offset { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull image;
        [Export ("image")]
        string Image { get; }

        // @property (readonly, nonatomic) ALCutoutAnimationStyle animation;
        [Export ("animation")]
        ALCutoutAnimationStyle Animation { get; }

        // @property (readonly, nonatomic) CGSize cropPadding;
        [Export ("cropPadding")]
        CGSize CropPadding { get; }

        // @property (readonly, nonatomic) CGPoint cropOffset;
        [Export ("cropOffset")]
        CGPoint CropOffset { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull alignmentString;
        [Export ("alignmentString")]
        string AlignmentString { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull animationString;
        [Export ("animationString")]
        string AnimationString { get; }

        // +(ALCutoutConfig * _Nonnull)defaultCutoutConfig;
        [Static]
        [Export ("defaultCutoutConfig")]
        ALCutoutConfig DefaultCutoutConfig { get; }

        // -(instancetype _Nullable)initWithJSONDictionary:(NSDictionary * _Nonnull)JSONDict error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONDictionary:error:")]
        IntPtr Constructor (NSDictionary JSONDict, [NullAllowed] out NSError error);

        // +(ALCutoutConfig * _Nullable)withJSONDictionary:(NSDictionary * _Nonnull)JSONDict;
        [Static]
        [Export ("withJSONDictionary:")]
        [return: NullAllowed]
        ALCutoutConfig WithJSONDictionary (NSDictionary JSONDict);

        // -(instancetype _Nullable)initWithAlignment:(ALCutoutAlignment)alignment animation:(ALCutoutAnimationStyle)animation ratioFromSize:(CGSize)ratioFromSize offset:(CGPoint)offset width:(NSInteger)width maxHeightPercent:(NSInteger)maxHeightPercent maxWidthPercent:(NSInteger)maxWidthPercent cornerRadius:(NSInteger)cornerRadius strokeWidth:(NSInteger)strokeWidth strokeColor:(NSString * _Nullable)strokeColor feedbackStrokeColor:(NSString * _Nullable)feedbackStrokeColor outerColor:(NSString * _Nullable)outerColor cropOffset:(CGPoint)cropOffset cropPadding:(CGSize)cropPadding image:(NSString * _Nullable)image __attribute__((objc_designated_initializer));
        [Export ("initWithAlignment:animation:ratioFromSize:offset:width:maxHeightPercent:maxWidthPercent:cornerRadius:strokeWidth:strokeColor:feedbackStrokeColor:outerColor:cropOffset:cropPadding:image:")]
        [DesignatedInitializer]
        IntPtr Constructor (ALCutoutAlignment alignment, ALCutoutAnimationStyle animation, CGSize ratioFromSize, CGPoint offset, nint width, nint maxHeightPercent, nint maxWidthPercent, nint cornerRadius, nint strokeWidth, [NullAllowed] string strokeColor, [NullAllowed] string feedbackStrokeColor, [NullAllowed] string outerColor, CGPoint cropOffset, CGSize cropPadding, [NullAllowed] string image);

        // +(ALCutoutConfig * _Nonnull)withAlignment:(ALCutoutAlignment)alignment animation:(ALCutoutAnimationStyle)animation ratioFromSize:(CGSize)ratioFromSize offset:(CGPoint)offset width:(NSInteger)width maxHeightPercent:(NSInteger)maxHeightPercent maxWidthPercent:(NSInteger)maxWidthPercent cornerRadius:(NSInteger)cornerRadius strokeWidth:(NSInteger)strokeWidth strokeColor:(NSString * _Nullable)strokeColor feedbackStrokeColor:(NSString * _Nullable)feedbackStrokeColor outerColor:(NSString * _Nullable)outerColor cropOffset:(CGPoint)cropOffset cropPadding:(CGSize)cropPadding image:(NSString * _Nullable)image;
        [Static]
        [Export ("withAlignment:animation:ratioFromSize:offset:width:maxHeightPercent:maxWidthPercent:cornerRadius:strokeWidth:strokeColor:feedbackStrokeColor:outerColor:cropOffset:cropPadding:image:")]
        ALCutoutConfig WithAlignment (ALCutoutAlignment alignment, ALCutoutAnimationStyle animation, CGSize ratioFromSize, CGPoint offset, nint width, nint maxHeightPercent, nint maxWidthPercent, nint cornerRadius, nint strokeWidth, [NullAllowed] string strokeColor, [NullAllowed] string feedbackStrokeColor, [NullAllowed] string outerColor, CGPoint cropOffset, CGSize cropPadding, [NullAllowed] string image);
    }

    // @interface ALScanFeedbackConfig : NSObject <ALJSONStringRepresentable>
    [BaseType (typeof(NSObject))]
    interface ALScanFeedbackConfig : ALJSONStringRepresentable
    {
        // @property (readonly, nonatomic) ALScanFeedbackStyle feedbackStyle;
        [Export ("feedbackStyle")]
        ALScanFeedbackStyle FeedbackStyle { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull strokeColor;
        [Export ("strokeColor")]
        string StrokeColor { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fillColor;
        [Export ("fillColor")]
        string FillColor { get; }

        // @property (readonly, nonatomic) NSInteger strokeWidth;
        [Export ("strokeWidth")]
        nint StrokeWidth { get; }

        // @property (readonly, nonatomic) NSInteger cornerRadius;
        [Export ("cornerRadius")]
        nint CornerRadius { get; }

        // @property (assign, nonatomic) NSInteger redrawTimeout;
        [Export ("redrawTimeout")]
        nint RedrawTimeout { get; set; }

        // @property (readonly, nonatomic) NSInteger animationDuration;
        [Export ("animationDuration")]
        nint AnimationDuration { get; }

        // @property (readonly, nonatomic) ALFeedbackAnimationStyle animationStyle;
        [Export ("animationStyle")]
        ALFeedbackAnimationStyle AnimationStyle { get; }

        // @property (readonly, nonatomic) BOOL blinkAnimationOnResult;
        [Export ("blinkAnimationOnResult")]
        bool BlinkAnimationOnResult { get; }

        // @property (readonly, nonatomic) BOOL beepOnResult;
        [Export ("beepOnResult")]
        bool BeepOnResult { get; }

        // @property (readonly, nonatomic) BOOL vibrateOnResult;
        [Export ("vibrateOnResult")]
        bool VibrateOnResult { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull feedbackStyleStr;
        [Export ("feedbackStyleStr")]
        string FeedbackStyleStr { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull animationStyleStr;
        [Export ("animationStyleStr")]
        string AnimationStyleStr { get; }

        // -(instancetype _Nullable)initWithJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONDictionary:error:")]
        IntPtr Constructor (NSDictionary JSONDictionary, [NullAllowed] out NSError error);

        // +(ALScanFeedbackConfig * _Nullable)withJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary;
        [Static]
        [Export ("withJSONDictionary:")]
        [return: NullAllowed]
        ALScanFeedbackConfig WithJSONDictionary (NSDictionary JSONDictionary);

        // +(ALScanFeedbackConfig * _Nonnull)defaultScanFeedbackConfig;
        [Static]
        [Export ("defaultScanFeedbackConfig")]
        ALScanFeedbackConfig DefaultScanFeedbackConfig { get; }

        // -(instancetype _Nonnull)initWithFeedbackStyle:(ALScanFeedbackStyle)feedbackStyle animationStyle:(ALFeedbackAnimationStyle)animationStyle animationDuration:(NSInteger)animationDuration strokeWidth:(NSInteger)strokeWidth strokeColor:(NSString * _Nullable)strokeColor fillColor:(NSString * _Nullable)fillColor cornerRadius:(NSInteger)cornerRadius redrawTimeout:(NSInteger)redrawTimeout beepOnResult:(BOOL)beepOnResult blinkAnimationOnResult:(BOOL)blinkAnimationOnResult vibrateOnResult:(BOOL)vibrateOnResult __attribute__((objc_designated_initializer));
        [Export ("initWithFeedbackStyle:animationStyle:animationDuration:strokeWidth:strokeColor:fillColor:cornerRadius:redrawTimeout:beepOnResult:blinkAnimationOnResult:vibrateOnResult:")]
        [DesignatedInitializer]
        IntPtr Constructor (ALScanFeedbackStyle feedbackStyle, ALFeedbackAnimationStyle animationStyle, nint animationDuration, nint strokeWidth, [NullAllowed] string strokeColor, [NullAllowed] string fillColor, nint cornerRadius, nint redrawTimeout, bool beepOnResult, bool blinkAnimationOnResult, bool vibrateOnResult);

        // +(ALScanFeedbackConfig * _Nonnull)withFeedbackStyle:(ALScanFeedbackStyle)feedbackStyle animationStyle:(ALFeedbackAnimationStyle)animationStyle animationDuration:(NSInteger)animationDuration strokeWidth:(NSInteger)strokeWidth strokeColor:(NSString * _Nullable)strokeColor fillColor:(NSString * _Nullable)fillColor cornerRadius:(NSInteger)cornerRadius redrawTimeout:(NSInteger)redrawTimeout beepOnResult:(BOOL)beepOnResult blinkAnimationOnResult:(BOOL)blinkAnimationOnResult vibrateOnResult:(BOOL)vibrateOnResult;
        [Static]
        [Export ("withFeedbackStyle:animationStyle:animationDuration:strokeWidth:strokeColor:fillColor:cornerRadius:redrawTimeout:beepOnResult:blinkAnimationOnResult:vibrateOnResult:")]
        ALScanFeedbackConfig WithFeedbackStyle (ALScanFeedbackStyle feedbackStyle, ALFeedbackAnimationStyle animationStyle, nint animationDuration, nint strokeWidth, [NullAllowed] string strokeColor, [NullAllowed] string fillColor, nint cornerRadius, nint redrawTimeout, bool beepOnResult, bool blinkAnimationOnResult, bool vibrateOnResult);
    }

    // @interface ALScanViewPluginConfig : NSObject <ALJSONStringRepresentable>
    [BaseType (typeof(NSObject))]
    interface ALScanViewPluginConfig : ALJSONStringRepresentable
    {
        // @property (readonly, nonatomic) ALCutoutConfig * _Nonnull cutoutConfig;
        [Export ("cutoutConfig")]
        ALCutoutConfig CutoutConfig { get; }

        // @property (readonly, nonatomic) ALScanFeedbackConfig * _Nonnull scanFeedbackConfig;
        [Export ("scanFeedbackConfig")]
        ALScanFeedbackConfig ScanFeedbackConfig { get; }

        // @property (readonly, nonatomic) ALPluginConfig * _Nonnull pluginConfig;
        [Export ("pluginConfig")]
        ALPluginConfig PluginConfig { get; }

        // -(instancetype _Nullable)initWithPluginConfig:(ALPluginConfig * _Nonnull)pluginConfig cutoutConfig:(ALCutoutConfig * _Nullable)cutoutConfig scanFeedbackConfig:(ALScanFeedbackConfig * _Nullable)scanFeedbackConfig error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
        [Export ("initWithPluginConfig:cutoutConfig:scanFeedbackConfig:error:")]
        [DesignatedInitializer]
	    IntPtr Constructor (ALPluginConfig pluginConfig, [NullAllowed] ALCutoutConfig cutoutConfig, [NullAllowed] ALScanFeedbackConfig scanFeedbackConfig, [NullAllowed] out NSError error);

        // -(instancetype _Nullable)initWithPluginConfig:(ALPluginConfig * _Nonnull)pluginConfig error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithPluginConfig:error:")]
        IntPtr Constructor (ALPluginConfig pluginConfig, [NullAllowed] out NSError error);

        // -(instancetype _Nullable)initWithJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONDictionary:error:")]
        IntPtr Constructor (NSDictionary JSONDictionary, [NullAllowed] out NSError error);

    	// +(ALScanViewPluginConfig * _Nullable)withPluginConfig:(ALPluginConfig * _Nonnull)pluginConfig cutoutConfig:(ALCutoutConfig * _Nullable)cutoutConfig scanFeedbackConfig:(ALScanFeedbackConfig * _Nullable)scanFeedbackConfig;
        [Static]
	    [Export ("withPluginConfig:cutoutConfig:scanFeedbackConfig:")]
        [return: NullAllowed]
	    ALScanViewPluginConfig WithPluginConfig (ALPluginConfig pluginConfig, [NullAllowed] ALCutoutConfig cutoutConfig, [NullAllowed] ALScanFeedbackConfig scanFeedbackConfig);

        // +(ALScanViewPluginConfig * _Nullable)withPluginConfig:(ALPluginConfig * _Nonnull)pluginConfig;
        [Static]
        [Export ("withPluginConfig:")]
        [return: NullAllowed]
        ALScanViewPluginConfig WithPluginConfig (ALPluginConfig pluginConfig);

        // +(instancetype _Nullable)withJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary;
        [Static]
        [Export ("withJSONDictionary:")]
        [return: NullAllowed]
        ALScanViewPluginConfig WithJSONDictionary (NSDictionary JSONDictionary);
    }

    // @interface ALScanViewPlugin : NSObject <ALScanViewPluginBase>
    [BaseType (typeof(ALScanViewPluginBase))]
    [DisableDefaultCtor]
    interface ALScanViewPlugin
    {
        // @property (readonly, nonatomic) ALScanPlugin * _Nonnull scanPlugin;
        [Export ("scanPlugin")]
        ALScanPlugin ScanPlugin { get; }

        [Wrap ("WeakDelegate")]
        [NullAllowed]
        ALScanViewPluginDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ALScanViewPluginDelegate> _Nullable delegate;
        [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (assign, nonatomic) CGRect regionOfInterest;
        [Export ("regionOfInterest", ArgumentSemantic.Assign)]
        CGRect RegionOfInterest { get; set; }

        // @property (readonly, nonatomic) BOOL isStarted;
        [Export ("isStarted")]
        bool IsStarted { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull pluginID;
        [Export ("pluginID")]
        string PluginID { get; }

        // -(BOOL)startWithError:(NSError * _Nullable * _Nullable)error;
        [Export ("startWithError:")]
        bool StartWithError ([NullAllowed] out NSError error);

        // -(void)stop;
        [Export ("stop")]
        void Stop ();
        
        // @property (readonly, nonatomic) NSArray<NSObject<ALScanViewPluginBase> *> * _Nonnull children;
        [Export ("children")]
        ALScanViewPluginBase[] Children { get; }

        // @property (readonly, nonatomic) ALScanViewPluginConfig * _Nonnull scanViewPluginConfig;
        [Export ("scanViewPluginConfig")]
        ALScanViewPluginConfig ScanViewPluginConfig { get; }

        // -(instancetype _Nullable)initWithConfig:(ALScanViewPluginConfig * _Nonnull)config error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithConfig:error:")]
        IntPtr Constructor (ALScanViewPluginConfig config, [NullAllowed] out NSError error);

        // -(instancetype _Nullable)initWithJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONDictionary:error:")]
        IntPtr Constructor (NSDictionary JSONDictionary, [NullAllowed] out NSError error);
    }

    // @protocol ALScanViewPluginDelegate <NSObject>
    [Protocol, Model (AutoGeneratedName = true)]
    [BaseType (typeof(NSObject))]
    interface ALScanViewPluginDelegate
    {
        // @optional -(void)scanViewPlugin:(ALScanViewPlugin * _Nonnull)scanViewPlugin visualFeedbackReceived:(ALEvent * _Nonnull)event;
        [Export ("scanViewPlugin:visualFeedbackReceived:")]
        void VisualFeedbackReceived (ALScanViewPlugin scanViewPlugin, ALEvent @event);

        // @optional -(void)scanViewPluginResultBeepTriggered:(ALScanViewPlugin * _Nonnull)scanViewPlugin;
        [Export ("scanViewPluginResultBeepTriggered:")]
        void ScanViewPluginResultBeepTriggered (ALScanViewPlugin scanViewPlugin);

        // @optional -(void)scanViewPluginResultBlinkTriggered:(ALScanViewPlugin * _Nonnull)scanViewPlugin;
        [Export ("scanViewPluginResultBlinkTriggered:")]
        void ScanViewPluginResultBlinkTriggered (ALScanViewPlugin scanViewPlugin);

        // @optional -(void)scanViewPluginResultVibrateTriggered:(ALScanViewPlugin * _Nonnull)scanViewPlugin;
        [Export ("scanViewPluginResultVibrateTriggered:")]
        void ScanViewPluginResultVibrateTriggered (ALScanViewPlugin scanViewPlugin);

        // @optional -(void)scanViewPlugin:(ALScanViewPlugin * _Nonnull)scanViewPlugin brightnessUpdated:(ALEvent * _Nonnull)event;
        [Export ("scanViewPlugin:brightnessUpdated:")]
        void BrightnessUpdated (ALScanViewPlugin scanViewPlugin, ALEvent @event);

        // @optional -(void)scanViewPlugin:(ALScanViewPlugin * _Nonnull)scanViewPlugin cutoutVisibilityChanged:(ALEvent * _Nonnull)event;
        [Export ("scanViewPlugin:cutoutVisibilityChanged:")]
        void CutoutVisibilityChanged (ALScanViewPlugin scanViewPlugin, ALEvent @event);
    }

    // @interface ALScanView : UIView
    [BaseType (typeof(UIView))]
    interface ALScanView
    {
	// -(instancetype _Nullable)initWithFrame:(CGRect)frame scanViewPlugin:(NSObject<ALScanViewPluginBase> * _Nonnull)scanViewPlugin scanViewConfig:(ALScanViewConfig * _Nullable)scanViewConfig error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithFrame:scanViewPlugin:scanViewConfig:error:")]
	    IntPtr Constructor (CGRect frame, ALScanViewPluginBase scanViewPlugin, [NullAllowed] ALScanViewConfig scanViewConfig, [NullAllowed] out NSError error);

    	// -(instancetype _Nullable)initWithFrame:(CGRect)frame scanViewPlugin:(NSObject<ALScanViewPluginBase> * _Nonnull)scanViewPlugin error:(NSError * _Nullable * _Nullable)error;
	    [Export ("initWithFrame:scanViewPlugin:error:")]
	    IntPtr Constructor (CGRect frame, ALScanViewPluginBase scanViewPlugin, [NullAllowed] out NSError error);

        // -(BOOL)setScanViewPlugin:(NSObject<ALScanViewPluginBase> * _Nonnull)scanViewPlugin error:(NSError * _Nullable * _Nullable)error;
	    [Export ("setScanViewPlugin:error:")]
        bool SetScanViewPlugin (ALScanViewPluginBase scanViewPlugin, [NullAllowed] out NSError error);

        [Wrap ("WeakDelegate")]
        [NullAllowed]
        ALScanViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ALScanViewDelegate> _Nullable delegate;
        [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic) NSObject<ALScanViewPluginBase> * _Nonnull scanViewPlugin;
	    [Export ("scanViewPlugin")]
        ALScanViewPluginBase ScanViewPlugin { get; }

        // @property (readonly, nonatomic) CGRect flashButtonFrame;
        [Export ("flashButtonFrame")]
        CGRect FlashButtonFrame { get; }

        // @property (readonly, nonatomic) ALScanViewConfig * _Nullable scanViewConfig;
        [NullAllowed, Export ("scanViewConfig")]
        ALScanViewConfig ScanViewConfig { get; }

        // @property (nonatomic, strong) NSArray<AVMetadataObjectType> * _Nullable supportedNativeBarcodeFormats;
        [NullAllowed, Export ("supportedNativeBarcodeFormats", ArgumentSemantic.Strong)]
        string[] SupportedNativeBarcodeFormats { get; set; }

        // -(void)startCamera;
        [Export ("startCamera")]
        void StartCamera ();

        // -(void)stopCamera;
        [Export ("stopCamera")]
        void StopCamera ();
    }

    // @protocol ALScanViewDelegate <NSObject>
    [Protocol, Model (AutoGeneratedName = true)]
    [BaseType (typeof(NSObject))]
    interface ALScanViewDelegate
    {
        // @optional -(void)scanViewMotionExceededThreshold:(ALScanView * _Nonnull)scanView;
        [Export ("scanViewMotionExceededThreshold:")]
        void ScanViewMotionExceededThreshold (ALScanView scanView);

        // @optional -(void)scanView:(ALScanView * _Nonnull)scanView didReceiveNativeBarcodeResult:(ALScanResult * _Nonnull)scanResult;
        [Export ("scanView:didReceiveNativeBarcodeResult:")]
        void ScanView (ALScanView scanView, ALScanResult scanResult);

        // @optional -(void)scanView:(ALScanView * _Nonnull)scanView updatedCutoutWithPluginID:(NSString * _Nonnull)pluginID frame:(CGRect)frame;
        [Export ("scanView:updatedCutoutWithPluginID:frame:")]
        void ScanView (ALScanView scanView, string pluginID, CGRect frame);

        // @optional -(void)scanView:(ALScanView * _Nonnull)scanView encounteredError:(NSError * _Nonnull)error;
        [Export ("scanView:encounteredError:")]
    	void ScanView (ALScanView scanView, NSError error);
    }

    // @interface ALScanViewPluginFactory : NSObject
    [BaseType (typeof(NSObject))]
    interface ALScanViewPluginFactory
    {
        // +(NSObject<ALScanViewPluginBase> * _Nullable)withJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary error:(NSError * _Nullable * _Nullable)error;
	    [Static]
        [Export ("withJSONDictionary:error:")]
    	[return: NullAllowed]
	    ALScanViewPluginBase WithJSONDictionary (NSDictionary JSONDictionary, [NullAllowed] out NSError error);
    }

    // @interface ALScanViewFactory : NSObject
    [BaseType (typeof(NSObject))]
    interface ALScanViewFactory
    {
        // +(ALScanView * _Nullable)withConfigFilePath:(NSString * _Nonnull)configFilePath delegate:(id _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export ("withConfigFilePath:delegate:error:")]
        [return: NullAllowed]
        ALScanView WithConfigFilePath (string configFilePath, NSObject @delegate, [NullAllowed] out NSError error);

        // +(ALScanView * _Nullable)withJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary delegate:(id _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
	    [Static]
        [Export ("withJSONDictionary:delegate:error:")]
        [return: NullAllowed]
    	ALScanView WithJSONDictionary (NSDictionary JSONDictionary, NSObject @delegate, [NullAllowed] out NSError error);
    }
    
    // @interface ALViewPluginComposite : NSObject <ALScanViewPluginBase>
    [BaseType (typeof(ALScanViewPluginBase))]
    interface ALViewPluginComposite
    {
        [Wrap ("WeakDelegate")]
        [NullAllowed]
        ALViewPluginCompositeDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ALViewPluginCompositeDelegate> _Nullable delegate;
        [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic) ALCompositeProcessingMode processingMode;
        [Export ("processingMode")]
        ALCompositeProcessingMode ProcessingMode { get; }

        // @property (readonly, nonatomic) BOOL isStarted;
        [Export ("isStarted")]
        bool IsStarted { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull pluginID;
        [Export ("pluginID")]
        string PluginID { get; }

        // @property (readonly, nonatomic) NSArray<NSObject<ALScanViewPluginBase> *> * _Nonnull children;
	    [Export ("children")]
        ALScanViewPluginBase[] Children { get; }

        // @property (readonly, nonatomic) ALScanViewPlugin * _Nullable activeChild;
        [NullAllowed, Export ("activeChild")]
        ALScanViewPlugin ActiveChild { get; }

        // @property (readonly, nonatomic) NSDictionary<NSString *,ALScanViewPluginConfig *> * _Nonnull pluginConfigs;
        [Export ("pluginConfigs")]
        NSDictionary<NSString, ALScanViewPluginConfig> PluginConfigs { get; }

        // @property (readonly, nonatomic) NSDictionary * _Nonnull JSONDictionary;
        [Export ("JSONDictionary")]
        NSDictionary JSONDictionary { get; }

        // -(instancetype _Nullable)initWithJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONDictionary:error:")]
        IntPtr Constructor (NSDictionary JSONDictionary, [NullAllowed] out NSError error);

        // -(instancetype _Nullable)initWithID:(NSString * _Nonnull)ID mode:(ALCompositeProcessingMode)mode children:(NSArray<NSObject<ALScanViewPluginBase> *> * _Nonnull)children error:(NSError * _Nullable * _Nullable)error;
	    [Export ("initWithID:mode:children:error:")]
        IntPtr Constructor (string ID, ALCompositeProcessingMode mode, ALScanViewPluginBase[] children, [NullAllowed] out NSError error);

        // -(NSObject<ALScanViewPluginBase> * _Nullable)pluginWithID:(NSString * _Nonnull)pluginID;
        [Export ("pluginWithID:")]
        [return: NullAllowed]
        ALScanViewPluginBase PluginWithID (string pluginID);

        // -(BOOL)startWithError:(NSError * _Nullable * _Nullable)error;
        [Export ("startWithError:")]
        bool StartWithError ([NullAllowed] out NSError error);

        // -(void)stop;
        [Export ("stop")]
        void Stop ();
    }

    // @protocol ALViewPluginCompositeDelegate <NSObject>
    [Protocol, Model (AutoGeneratedName = true)]
    [BaseType (typeof(NSObject))]
    interface ALViewPluginCompositeDelegate
    {
        // @optional -(void)viewPluginComposite:(ALViewPluginComposite * _Nonnull)viewPluginComposite allResultsReceived:(NSArray<ALScanResult *> * _Nonnull)scanResults;
        [Export ("viewPluginComposite:allResultsReceived:")]
        void AllResultsReceived (ALViewPluginComposite viewPluginComposite, ALScanResult[] scanResults);

        // @optional -(void)viewPluginComposite:(ALViewPluginComposite * _Nonnull)viewPluginComposite errorFound:(NSError * _Nonnull)error;
        [Export ("viewPluginComposite:errorFound:")]
        void ErrorFound (ALViewPluginComposite viewPluginComposite, NSError error);
    }
    
    // @interface ALEvent : NSObject
    [BaseType (typeof(NSObject))]
    interface ALEvent
    {
        // @property (readonly, nonatomic) ALImage * _Nullable image;
        [NullAllowed, Export ("image")]
        ALImage Image { get; }

        // @property (readonly, nonatomic) id _Nullable JSONObject;
        [NullAllowed, Export ("JSONObject")]
        NSObject JSONObject { get; }

        // @property (copy, nonatomic) NSString * _Nullable channel;
        [NullAllowed, Export ("channel")]
        string Channel { get; set; }

        // @property (readonly, nonatomic) NSDate * _Nonnull timestamp;
        [Export ("timestamp")]
        NSDate Timestamp { get; }

        // @property (readonly, nonatomic) NSString * _Nullable JSONStr;
        [NullAllowed, Export ("JSONStr")]
        string JSONStr { get; }

        // +(ALEvent * _Nullable)withJSONObject:(id _Nonnull)JSONObj image:(ALImage * _Nullable)image error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export ("withJSONObject:image:error:")]
        [return: NullAllowed]
        ALEvent WithJSONObject (NSObject JSONObj, [NullAllowed] ALImage image, [NullAllowed] out NSError error);

        // +(ALEvent * _Nullable)withJSONObject:(id _Nonnull)JSONObj image:(ALImage * _Nullable)image;
        [Static]
        [Export ("withJSONObject:image:")]
        [return: NullAllowed]
        ALEvent WithJSONObject (NSObject JSONObj, [NullAllowed] ALImage image);

        // +(ALEvent * _Nullable)withJSONObject:(id _Nonnull)JSONObj error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export ("withJSONObject:error:")]
        [return: NullAllowed]
        ALEvent WithJSONObject (NSObject JSONObj, [NullAllowed] out NSError error);

        // +(ALEvent * _Nullable)withJSONObject:(id _Nonnull)JSONObj;
        [Static]
        [Export ("withJSONObject:")]
        [return: NullAllowed]
        ALEvent WithJSONObject (NSObject JSONObj);

        // +(ALEvent * _Nullable)withJSONString:(NSString * _Nonnull)JSONString image:(ALImage * _Nullable)image error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export ("withJSONString:image:error:")]
        [return: NullAllowed]
        ALEvent WithJSONString (string JSONString, [NullAllowed] ALImage image, [NullAllowed] out NSError error);

        // +(ALEvent * _Nullable)withJSONString:(NSString * _Nonnull)JSONString error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export ("withJSONString:error:")]
        [return: NullAllowed]
        ALEvent WithJSONString (string JSONString, [NullAllowed] out NSError error);

        // +(ALEvent * _Nullable)withJSONString:(NSString * _Nonnull)JSONString image:(ALImage * _Nullable)image;
        [Static]
        [Export ("withJSONString:image:")]
        [return: NullAllowed]
        ALEvent WithJSONString (string JSONString, [NullAllowed] ALImage image);

        // +(ALEvent * _Nullable)withJSONString:(NSString * _Nonnull)JSONString;
        [Static]
        [Export ("withJSONString:")]
        [return: NullAllowed]
        ALEvent WithJSONString (string JSONString);
    }

    // @interface ALMultiImageEvent : ALEvent
    [BaseType (typeof(ALEvent))]
    interface ALMultiImageEvent
    {
        // @property (nonatomic, strong) NSArray<ALImage *> * _Nonnull images;
        [Export ("images", ArgumentSemantic.Strong)]
        ALImage[] Images { get; set; }

        // +(ALMultiImageEvent * _Nullable)withJSONObject:(id _Nonnull)JSONObj images:(NSArray<ALImage *> * _Nonnull)images error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export ("withJSONObject:images:error:")]
        [return: NullAllowed]
        ALMultiImageEvent WithJSONObject (NSObject JSONObj, ALImage[] images, [NullAllowed] out NSError error);
    }

    [Static]
    partial interface Constants
    {
        // extern NSString *const _Nonnull kCodeTypeAll;
        [Field ("kCodeTypeAll", "__Internal")]
        NSString kCodeTypeAll { get; }

        // extern NSString *const _Nonnull kCodeTypeUnknown;
        [Field ("kCodeTypeUnknown", "__Internal")]
        NSString kCodeTypeUnknown { get; }

        // extern NSString *const _Nonnull kCodeTypeAztec;
        [Field ("kCodeTypeAztec", "__Internal")]
        NSString kCodeTypeAztec { get; }

        // extern NSString *const _Nonnull kCodeTypeCodabar;
        [Field ("kCodeTypeCodabar", "__Internal")]
        NSString kCodeTypeCodabar { get; }

        // extern NSString *const _Nonnull kCodeTypeCode39;
        [Field ("kCodeTypeCode39", "__Internal")]
        NSString kCodeTypeCode39 { get; }

        // extern NSString *const _Nonnull kCodeTypeCode93;
        [Field ("kCodeTypeCode93", "__Internal")]
        NSString kCodeTypeCode93 { get; }

        // extern NSString *const _Nonnull kCodeTypeCode128;
        [Field ("kCodeTypeCode128", "__Internal")]
        NSString kCodeTypeCode128 { get; }

        // extern NSString *const _Nonnull kCodeTypeDataMatrix;
        [Field ("kCodeTypeDataMatrix", "__Internal")]
        NSString kCodeTypeDataMatrix { get; }

        // extern NSString *const _Nonnull kCodeTypeEAN8;
        [Field ("kCodeTypeEAN8", "__Internal")]
        NSString kCodeTypeEAN8 { get; }

        // extern NSString *const _Nonnull kCodeTypeEAN13;
        [Field ("kCodeTypeEAN13", "__Internal")]
        NSString kCodeTypeEAN13 { get; }

        // extern NSString *const _Nonnull kCodeTypeITF;
        [Field ("kCodeTypeITF", "__Internal")]
        NSString kCodeTypeITF { get; }

        // extern NSString *const _Nonnull kCodeTypePDF417;
        [Field ("kCodeTypePDF417", "__Internal")]
        NSString kCodeTypePDF417 { get; }

        // extern NSString *const _Nonnull kCodeTypeRSS14;
        [Field ("kCodeTypeRSS14", "__Internal")]
        NSString kCodeTypeRSS14 { get; }

        // extern NSString *const _Nonnull kCodeTypeRSSExpanded;
        [Field ("kCodeTypeRSSExpanded", "__Internal")]
        NSString kCodeTypeRSSExpanded { get; }

        // extern NSString *const _Nonnull kCodeTypeUPCA;
        [Field ("kCodeTypeUPCA", "__Internal")]
        NSString kCodeTypeUPCA { get; }

        // extern NSString *const _Nonnull kCodeTypeUPCE;
        [Field ("kCodeTypeUPCE", "__Internal")]
        NSString kCodeTypeUPCE { get; }

        // extern NSString *const _Nonnull kCodeTypeUPCEANExtension;
        [Field ("kCodeTypeUPCEANExtension", "__Internal")]
        NSString kCodeTypeUPCEANExtension { get; }

        // extern NSString *const _Nonnull kCodeTypeQR;
        [Field ("kCodeTypeQR", "__Internal")]
        NSString kCodeTypeQR { get; }

        // extern NSString *const _Nonnull kCodeTypeRSS_EXPANDED;
        [Field ("kCodeTypeRSS_EXPANDED", "__Internal")]
        NSString kCodeTypeRSS_EXPANDED { get; }

        // extern NSString *const _Nonnull kCodeTypeMATRIX_2_5;
        [Field ("kCodeTypeMATRIX_2_5", "__Internal")]
        NSString kCodeTypeMATRIX_2_5 { get; }

        // extern NSString *const _Nonnull kCodeTypeAZTEC_INVERSE;
        [Field ("kCodeTypeAZTEC_INVERSE", "__Internal")]
        NSString kCodeTypeAZTEC_INVERSE { get; }

        // extern NSString *const _Nonnull kCodeTypeDATAMATRIX_INVERSE;
        [Field ("kCodeTypeDATAMATRIX_INVERSE", "__Internal")]
        NSString kCodeTypeDATAMATRIX_INVERSE { get; }

        // extern NSString *const _Nonnull kCodeTypeQR_INVERSE;
        [Field ("kCodeTypeQR_INVERSE", "__Internal")]
        NSString kCodeTypeQR_INVERSE { get; }

        // extern NSString *const _Nonnull kCodeTypeDOT_CODE;
        [Field ("kCodeTypeDOT_CODE", "__Internal")]
        NSString kCodeTypeDOT_CODE { get; }

        // extern NSString *const _Nonnull kCodeTypeGS1_QR_CODE;
        [Field ("kCodeTypeGS1_QR_CODE", "__Internal")]
        NSString kCodeTypeGS1_QR_CODE { get; }

        // extern NSString *const _Nonnull kCodeTypeMICRO_QR;
        [Field ("kCodeTypeMICRO_QR", "__Internal")]
        NSString kCodeTypeMICRO_QR { get; }

        // extern NSString *const _Nonnull kCodeTypeISSN_EAN;
        [Field ("kCodeTypeISSN_EAN", "__Internal")]
        NSString kCodeTypeISSN_EAN { get; }

        // extern NSString *const _Nonnull kCodeTypeCOUPON;
        [Field ("kCodeTypeCOUPON", "__Internal")]
        NSString kCodeTypeCOUPON { get; }

        // extern NSString *const _Nonnull kCodeTypeTRIOPTIC;
        [Field ("kCodeTypeTRIOPTIC", "__Internal")]
        NSString kCodeTypeTRIOPTIC { get; }

        // extern NSString *const _Nonnull kCodeTypeDISCRETE_2_5;
        [Field ("kCodeTypeDISCRETE_2_5", "__Internal")]
        NSString kCodeTypeDISCRETE_2_5 { get; }

        // extern NSString *const _Nonnull kCodeTypeMSI;
        [Field ("kCodeTypeMSI", "__Internal")]
        NSString kCodeTypeMSI { get; }

        // extern NSString *const _Nonnull kCodeTypeONE_D_INVERSE;
        [Field ("kCodeTypeONE_D_INVERSE", "__Internal")]
        NSString kCodeTypeONE_D_INVERSE { get; }

        // extern NSString *const _Nonnull kCodeTypeUSPS_4CB;
        [Field ("kCodeTypeUSPS_4CB", "__Internal")]
        NSString kCodeTypeUSPS_4CB { get; }

        // extern NSString *const _Nonnull kCodeTypeUS_POSTNET;
        [Field ("kCodeTypeUS_POSTNET", "__Internal")]
        NSString kCodeTypeUS_POSTNET { get; }

        // extern NSString *const _Nonnull kCodeTypeUS_PLANET;
        [Field ("kCodeTypeUS_PLANET", "__Internal")]
        NSString kCodeTypeUS_PLANET { get; }

        // extern NSString *const _Nonnull kCodeTypeMICRO_PDF;
        [Field ("kCodeTypeMICRO_PDF", "__Internal")]
        NSString kCodeTypeMICRO_PDF { get; }

        // extern NSString *const _Nonnull kCodeTypeKIX;
        [Field ("kCodeTypeKIX", "__Internal")]
        NSString kCodeTypeKIX { get; }

        // extern NSString *const _Nonnull kCodeTypeUPU_FICS;
        [Field ("kCodeTypeUPU_FICS", "__Internal")]
        NSString kCodeTypeUPU_FICS { get; }

        // extern NSString *const _Nonnull kCodeTypePOST_UK;
        [Field ("kCodeTypePOST_UK", "__Internal")]
        NSString kCodeTypePOST_UK { get; }

        // extern NSString *const _Nonnull kCodeTypeGS1_128;
        [Field ("kCodeTypeGS1_128", "__Internal")]
        NSString kCodeTypeGS1_128 { get; }

        // extern NSString *const _Nonnull kCodeTypeBOOKLAND;
        [Field ("kCodeTypeBOOKLAND", "__Internal")]
        NSString kCodeTypeBOOKLAND { get; }

        // extern NSString *const _Nonnull kCodeTypeISBT_128;
        [Field ("kCodeTypeISBT_128", "__Internal")]
        NSString kCodeTypeISBT_128 { get; }

        // extern NSString *const _Nonnull kCodeTypeCODE_11;
        [Field ("kCodeTypeCODE_11", "__Internal")]
        NSString kCodeTypeCODE_11 { get; }

        // extern NSString *const _Nonnull kCodeTypeCODE_32;
        [Field ("kCodeTypeCODE_32", "__Internal")]
        NSString kCodeTypeCODE_32 { get; }

        // extern NSString *const _Nonnull kCodeTypeUPC_EAN_EXTENSION;
        [Field ("kCodeTypeUPC_EAN_EXTENSION", "__Internal")]
        NSString kCodeTypeUPC_EAN_EXTENSION { get; }

        // extern NSString *const _Nonnull kCodeTypeDATABAR;
        [Field ("kCodeTypeDATABAR", "__Internal")]
        NSString kCodeTypeDATABAR { get; }

        // extern NSString *const _Nonnull kCodeTypeMaxiCode;
        [Field ("kCodeTypeMaxiCode", "__Internal")]
        NSString kCodeTypeMaxiCode { get; }
    }
    
    // @interface ALImage : NSObject
    [BaseType (typeof(NSObject))]
    interface ALImage
    {
        // @property (assign, nonatomic) NSInteger width;
        [Export ("width")]
        nint Width { get; set; }

        // @property (assign, nonatomic) NSInteger height;
        [Export ("height")]
        nint Height { get; set; }

        // @property (assign, nonatomic) NSUInteger bytesPerRow;
        [Export ("bytesPerRow")]
        nuint BytesPerRow { get; set; }

        // @property (nonatomic, strong) NSData * _Nonnull data;
        [Export ("data", ArgumentSemantic.Strong)]
        NSData Data { get; set; }

        // @property (readonly, nonatomic) UIImage * _Nonnull uiImage;
        [Export ("uiImage")]
        UIImage UiImage { get; }

        // -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data width:(NSUInteger)width height:(NSUInteger)height bytesPerRow:(NSUInteger)bytesPerRow;
        [Export ("initWithData:width:height:bytesPerRow:")]
        IntPtr Constructor (NSData data, nuint width, nuint height, nuint bytesPerRow);
    }

    // @interface ALLicenseUtil : NSObject
    [BaseType (typeof(NSObject))]
    interface ALLicenseUtil
    {
        // @property (readonly, nonatomic) BOOL isLicenseValid;
        [Export ("isLicenseValid")]
        bool IsLicenseValid { get; }

        // @property (readonly, nonatomic) BOOL showWatermark;
        [Export ("showWatermark")]
        bool ShowWatermark { get; }

        // +(instancetype _Nonnull)sharedInstance;
        [Static]
        [Export ("sharedInstance")]
        ALLicenseUtil SharedInstance ();

        // -(BOOL)scopeEnabledFor:(NSString * _Nonnull)valueName;
        [Export ("scopeEnabledFor:")]
        bool ScopeEnabledFor (string valueName);

        // -(NSString * _Nonnull)licenseExpirationDate;
        [Export ("licenseExpirationDate")]
        string LicenseExpirationDate { get; }
    }

    // @protocol ALNFCDetectorDelegate <NSObject>
    [iOS (13,0)]
    [Protocol, Model (AutoGeneratedName = true)]
    [BaseType (typeof(NSObject))]
    interface ALNFCDetectorDelegate
    {
        // @required -(void)nfcSucceededWithResult:(ALNFCResult * _Nonnull)nfcResult;
        [Abstract]
        [Export ("nfcSucceededWithResult:")]
        void NfcSucceededWithResult (ALNFCResult nfcResult);

        // @required -(void)nfcFailedWithError:(NSError * _Nonnull)error;
        [Abstract]
        [Export ("nfcFailedWithError:")]
        void NfcFailedWithError (NSError error);

        // @optional -(void)nfcSucceededWithDataGroup1:(ALDataGroup1 * _Nonnull)dataGroup1 __attribute__((availability(ios, introduced=13.0)));
        [iOS (13,0)]
        [Export ("nfcSucceededWithDataGroup1:")]
        void NfcSucceededWithDataGroup1 (ALDataGroup1 dataGroup1);

        // @optional -(void)nfcSucceededWithDataGroup2:(ALDataGroup2 * _Nonnull)dataGroup2 __attribute__((availability(ios, introduced=13.0)));
        [iOS (13,0)]
        [Export ("nfcSucceededWithDataGroup2:")]
        void NfcSucceededWithDataGroup2 (ALDataGroup2 dataGroup2);

        // @optional -(void)nfcSucceededWithSOD:(ALSOD * _Nonnull)sod __attribute__((availability(ios, introduced=13.0)));
        [iOS (13,0)]
        [Export ("nfcSucceededWithSOD:")]
        void NfcSucceededWithSOD (ALSOD sod);
    }

    // @interface ALNFCDetector : NSObject
    [iOS (13,0)]
    [BaseType (typeof(NSObject))]
    interface ALNFCDetector
    {
        // +(BOOL)readingAvailable;
        [Static]
        [Export ("readingAvailable")]
        bool ReadingAvailable { get; }

        // -(instancetype _Nullable)initWithDelegate:(id<ALNFCDetectorDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithDelegate:error:")]
        IntPtr Constructor (NSObject @delegate, [NullAllowed] out NSError error);

        // -(void)startNfcDetectionWithPassportNumber:(NSString * _Nonnull)passportNumber dateOfBirth:(NSDate * _Nonnull)dateOfBirth expirationDate:(NSDate * _Nonnull)expirationDate;
        [Export ("startNfcDetectionWithPassportNumber:dateOfBirth:expirationDate:")]
        void StartNfcDetectionWithPassportNumber (string passportNumber, NSDate dateOfBirth, NSDate expirationDate);
    }

    // @interface ALNFCResult : NSObject
    [iOS (13,0)]
    [BaseType (typeof(NSObject))]
    interface ALNFCResult
    {
        // @property ALSOD * _Nonnull sod;
        [Export ("sod", ArgumentSemantic.Assign)]
        ALSOD Sod { get; set; }

        // @property ALDataGroup1 * _Nonnull dataGroup1;
        [Export ("dataGroup1", ArgumentSemantic.Assign)]
        ALDataGroup1 DataGroup1 { get; set; }

        // @property ALDataGroup2 * _Nonnull dataGroup2;
        [Export ("dataGroup2", ArgumentSemantic.Assign)]
        ALDataGroup2 DataGroup2 { get; set; }

        // -(instancetype _Nonnull)initWithDataGroup1:(ALDataGroup1 * _Nonnull)dataGroup1 dataGroup2:(ALDataGroup2 * _Nonnull)dataGroup2 sod:(ALSOD * _Nullable)sod;
	    [Export ("initWithDataGroup1:dataGroup2:sod:")]
        IntPtr Constructor (ALDataGroup1 dataGroup1, ALDataGroup2 dataGroup2, [NullAllowed] ALSOD sod);
    }

    // @interface ALDataGroup1 : NSObject
    [BaseType (typeof(NSObject))]
    interface ALDataGroup1
    {
        // @property (copy, nonatomic) NSString * _Nullable documentType;
        [NullAllowed, Export ("documentType")]
        string DocumentType { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable issuingStateCode;
        [NullAllowed, Export ("issuingStateCode")]
        string IssuingStateCode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable documentNumber;
        [NullAllowed, Export ("documentNumber")]
        string DocumentNumber { get; set; }

        // @property (nonatomic, strong) NSDate * _Nullable dateOfExpiry;
        [NullAllowed, Export ("dateOfExpiry", ArgumentSemantic.Strong)]
        NSDate DateOfExpiry { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable gender;
        [NullAllowed, Export ("gender")]
        string Gender { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable nationality;
        [NullAllowed, Export ("nationality")]
        string Nationality { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export ("lastName")]
        string LastName { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export ("firstName")]
        string FirstName { get; set; }

        // @property (nonatomic, strong) NSDate * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth", ArgumentSemantic.Strong)]
        NSDate DateOfBirth { get; set; }

        // -(instancetype _Nonnull)initWithDocumentType:(NSString * _Nullable)documentType issuingStateCode:(NSString * _Nullable)issuingStateCode documentNumber:(NSString * _Nullable)documentNumber dateOfExpiry:(NSDate * _Nullable)dateOfExpiry gender:(NSString * _Nullable)gender nationality:(NSString * _Nullable)nationality lastName:(NSString * _Nullable)lastName firstName:(NSString * _Nullable)firstName dateOfBirth:(NSDate * _Nullable)dateOfBirth;
        [Export ("initWithDocumentType:issuingStateCode:documentNumber:dateOfExpiry:gender:nationality:lastName:firstName:dateOfBirth:")]
        IntPtr Constructor ([NullAllowed] string documentType, [NullAllowed] string issuingStateCode, [NullAllowed] string documentNumber, [NullAllowed] NSDate dateOfExpiry, [NullAllowed] string gender, [NullAllowed] string nationality, [NullAllowed] string lastName, [NullAllowed] string firstName, [NullAllowed] NSDate dateOfBirth);

        // -(instancetype _Nonnull)initWithPassportDataElements:(NSDictionary<NSString *,NSString *> * _Nonnull)passportDataElements;
        [Export ("initWithPassportDataElements:")]
        IntPtr Constructor (NSDictionary<NSString, NSString> passportDataElements);
    }

    // @interface ALDataGroup2 : NSObject
    [BaseType (typeof(NSObject))]
    interface ALDataGroup2
    {
        // @property (nonatomic, strong) UIImage * _Nullable faceImage;
        [NullAllowed, Export ("faceImage", ArgumentSemantic.Strong)]
        UIImage FaceImage { get; set; }

        // -(instancetype _Nonnull)initWithFaceImage:(UIImage * _Nullable)faceImage;
        [Export ("initWithFaceImage:")]
        IntPtr Constructor ([NullAllowed] UIImage faceImage);
    }

    // @interface ALSOD : NSObject
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface ALSOD
    {
        // @property NSString * _Nonnull issuerCountry;
        [Export ("issuerCountry")]
        string IssuerCountry { get; set; }

        // @property NSString * _Nonnull issuerCertificationAuthority;
        [Export ("issuerCertificationAuthority")]
        string IssuerCertificationAuthority { get; set; }

        // @property NSString * _Nonnull issuerOrganization;
        [Export ("issuerOrganization")]
        string IssuerOrganization { get; set; }

        // @property NSString * _Nonnull issuerOrganizationalUnit;
        [Export ("issuerOrganizationalUnit")]
        string IssuerOrganizationalUnit { get; set; }

        // @property NSString * _Nonnull signatureAlgorithm;
        [Export ("signatureAlgorithm")]
        string SignatureAlgorithm { get; set; }

        // @property NSString * _Nonnull ldsHashAlgorithm;
        [Export ("ldsHashAlgorithm")]
        string LdsHashAlgorithm { get; set; }

        // @property NSString * _Nonnull validFromString;
        [Export ("validFromString")]
        string ValidFromString { get; set; }

        // @property NSString * _Nonnull validUntilString;
        [Export ("validUntilString")]
        string ValidUntilString { get; set; }
    }

    // @protocol ALAssetUpdateDelegate <NSObject>
    [Protocol, Model (AutoGeneratedName = true)]
    [BaseType (typeof(NSObject))]
    interface ALAssetUpdateDelegate
    {
        // @required -(void)assetUpdateTask:(ALAssetUpdateTask * _Nonnull)task updatesFound:(BOOL)updatesFound;
        [Abstract]
        [Export ("assetUpdateTask:updatesFound:")]
        void UpdatesFound (ALAssetUpdateTask task, bool updatesFound);

        // @required -(void)assetUpdateTask:(ALAssetUpdateTask * _Nonnull)task completedWithError:(NSError * _Nullable)error;
        [Abstract]
        [Export ("assetUpdateTask:completedWithError:")]
        void CompletedWithError (ALAssetUpdateTask task, [NullAllowed] NSError error);

        // @required -(void)assetUpdateTask:(ALAssetUpdateTask * _Nonnull)task downloadedFile:(NSString * _Nonnull)fileName progress:(CGFloat)progress;
        [Abstract]
        [Export ("assetUpdateTask:downloadedFile:progress:")]
        void DownloadedFile (ALAssetUpdateTask task, string fileName, nfloat progress);
    }

    // @interface ALAssetUpdateTaskFactory : NSObject
    [BaseType (typeof(NSObject))]
    interface ALAssetUpdateTaskFactory
    {
        // -(ALAssetUpdateTask * _Nonnull)makeAssetUpdateTaskWithAssetContext:(ALAssetContext * _Nonnull)assetContext assetUpdateDelegate:(id<ALAssetUpdateDelegate> _Nonnull)assetUpdateDelegate;
        [Export ("makeAssetUpdateTaskWithAssetContext:assetUpdateDelegate:")]
        ALAssetUpdateTask MakeAssetUpdateTaskWithAssetContext (ALAssetContext assetContext, ALAssetUpdateDelegate assetUpdateDelegate);
    }

    // @interface ALAssetUpdateTask : NSObject
    [BaseType (typeof(NSObject))]
    interface ALAssetUpdateTask
    {
        [Wrap ("WeakAssetUpdateDelegate")]
        [NullAllowed]
        ALAssetUpdateDelegate AssetUpdateDelegate { get; set; }

        // @property (nonatomic, weak) id<ALAssetUpdateDelegate> _Nullable assetUpdateDelegate;
        [NullAllowed, Export ("assetUpdateDelegate", ArgumentSemantic.Weak)]
        NSObject WeakAssetUpdateDelegate { get; set; }

        // @property (nonatomic, strong) ALAssetContext * _Nonnull assetContext;
        [Export ("assetContext", ArgumentSemantic.Strong)]
        ALAssetContext AssetContext { get; set; }

        // @property (readonly, nonatomic, strong) ALAssetController * _Nonnull assetController;
        [Export ("assetController", ArgumentSemantic.Strong)]
        ALAssetController AssetController { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull id;
        [Export ("id")]
        string Id { get; }

        // @property (nonatomic, strong) ALAssetControllerFactory * _Nullable assetControllerFactory;
        [NullAllowed, Export ("assetControllerFactory", ArgumentSemantic.Strong)]
        ALAssetControllerFactory AssetControllerFactory { get; set; }
    
        // -(id _Nonnull)initWithAssetContext:(ALAssetContext * _Nonnull)assetContext assetUpdateDelegate:(id<ALAssetUpdateDelegate> _Nonnull)assetUpdateDelegate assetControllerFactory:(ALAssetControllerFactory * _Nullable)assetControllerFactory;
        [Export ("initWithAssetContext:assetUpdateDelegate:assetControllerFactory:")]
        IntPtr Constructor (ALAssetContext assetContext, ALAssetUpdateDelegate assetUpdateDelegate, [NullAllowed] ALAssetControllerFactory assetControllerFactory);

        // -(id _Nonnull)initWithAssetContext:(ALAssetContext * _Nonnull)assetContext assetUpdateDelegate:(id<ALAssetUpdateDelegate> _Nonnull)assetUpdateDelegate;
        [Export ("initWithAssetContext:assetUpdateDelegate:")]
        IntPtr Constructor (ALAssetContext assetContext, ALAssetUpdateDelegate assetUpdateDelegate);

        // -(void)cancel;
        [Export ("cancel")]
        void Cancel ();

        // -(void)checkForUpdates:(BOOL)downloadIfOutdated;
        [Export ("checkForUpdates:")]
        void CheckForUpdates (bool downloadIfOutdated);

        // -(void)downloadAssets;
        [Export ("downloadAssets")]
        void DownloadAssets ();

        // -(void)removeDownloads;
        [Export ("removeDownloads")]
        void RemoveDownloads ();

        // -(BOOL)hasLocalAssets;
        [Export ("hasLocalAssets")]
        bool HasLocalAssets { get; }
    }

    // @interface ALAssetUpdateManager : NSObject
    [BaseType (typeof(NSObject))]
    interface ALAssetUpdateManager
    {
        // @property (readonly, nonatomic) NSInteger count;
        [Export ("count")]
        nint Count { get; }

        // @property (nonatomic, strong) ALAssetUpdateTaskFactory * _Nullable assetUpdateTaskFactory;
        [NullAllowed, Export ("assetUpdateTaskFactory", ArgumentSemantic.Strong)]
        ALAssetUpdateTaskFactory AssetUpdateTaskFactory { get; set; }

        // +(ALAssetUpdateManager * _Nonnull)sharedManager;
        [Static]
        [Export ("sharedManager")]
        ALAssetUpdateManager SharedManager { get; }

        // -(instancetype _Nonnull)initWithAssetUpdateTaskFactory:(ALAssetUpdateTaskFactory * _Nullable)assetUpdateTaskFactory;
        [Export ("initWithAssetUpdateTaskFactory:")]
        IntPtr Constructor ([NullAllowed] ALAssetUpdateTaskFactory assetUpdateTaskFactory);

        // -(void)addUpdateTask:(ALAssetContext * _Nonnull)assetContext delegate:(id<ALAssetUpdateDelegate> _Nonnull)delegate;
        [Export ("addUpdateTask:delegate:")]
        void AddUpdateTask (ALAssetContext assetContext, NSObject @delegate);

        // -(ALAssetUpdateTask * _Nullable)assetUpdateTaskWithID:(NSString * _Nonnull)id;
        [Export ("assetUpdateTaskWithID:")]
        [return: NullAllowed]
        ALAssetUpdateTask AssetUpdateTaskWithID (string id);

        // -(BOOL)localAssetsFound:(NSString * _Nonnull)id;
        [Export ("localAssetsFound:")]
        bool LocalAssetsFound (string id);

        // -(void)checkForUpdates:(NSString * _Nonnull)id downloadIfOutdated:(BOOL)downloadIfOutdated;
        [Export ("checkForUpdates:downloadIfOutdated:")]
        void CheckForUpdates (string id, bool downloadIfOutdated);

        // -(void)requestAssetDownload:(NSString * _Nonnull)id;
        [Export ("requestAssetDownload:")]
        void RequestAssetDownload (string id);

        // -(void)resetTask:(NSString * _Nonnull)id;
        [Export ("resetTask:")]
        void ResetTask (string id);

        // -(ALAssetUpdateTask * _Nullable)removeUpdateTask:(NSString * _Nonnull)id;
        [Export ("removeUpdateTask:")]
        [return: NullAllowed]
        ALAssetUpdateTask RemoveUpdateTask (string id);

        // -(void)removeAll;
        [Export ("removeAll")]
        void RemoveAll ();

        // -(ALAssetController * _Nullable)assetControllerForID:(NSString * _Nonnull)id;
        [Export ("assetControllerForID:")]
        [return: NullAllowed]
        ALAssetController AssetControllerForID (string id);
    }

    // @interface ALAssetContext : NSObject
    [BaseType (typeof(NSObject))]
    interface ALAssetContext
    {
        // @property NSString * _Nonnull apiKey;
        [Export ("apiKey")]
        string ApiKey { get; set; }

        // @property NSString * _Nonnull projectID;
        [Export ("projectID")]
        string ProjectID { get; set; }

        // @property NSString * _Nonnull stage;
        [Export ("stage")]
        string Stage { get; set; }

        // @property NSString * _Nonnull anylineVersion;
        [Export ("anylineVersion")]
        string AnylineVersion { get; set; }

        // @property NSString * _Nonnull training;
        [Export ("training")]
        string Training { get; set; }

        // @property NSString * _Nonnull assetID;
        [Export ("assetID")]
        string AssetID { get; set; }

        // @property NSString * _Nonnull assetVersion;
        [Export ("assetVersion")]
        string AssetVersion { get; set; }

        // -(NSString * _Nonnull)asJSONString;
        [Export ("asJSONString")]
        string AsJSONString { get; }

        // +(NSDictionary * _Nullable)getProjectConfigWithContext:(ALAssetContext * _Nonnull)context timeout:(NSTimeInterval)timeout error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export ("getProjectConfigWithContext:timeout:error:")]
        [return: NullAllowed]
        NSDictionary GetProjectConfigWithContext (ALAssetContext context, double timeout, [NullAllowed] out NSError error);

        // +(NSString * _Nullable)getAuthTokenWithContext:(ALAssetContext * _Nonnull)context timeout:(NSTimeInterval)timeout error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export ("getAuthTokenWithContext:timeout:error:")]
        [return: NullAllowed]
        string GetAuthTokenWithContext (ALAssetContext context, double timeout, [NullAllowed] out NSError error);
    }

    // @protocol ALAssetDelegate <NSObject>
    [Protocol, Model (AutoGeneratedName = true)]
    [BaseType (typeof(NSObject))]
    interface ALAssetDelegate
    {
        // @required -(void)assetUpdateAvailable:(BOOL)updateAvailable;
        [Abstract]
        [Export ("assetUpdateAvailable:")]
        void AssetUpdateAvailable (bool updateAvailable);

        // @required -(void)assetDownloadProgressWithAssetName:(NSString *)assetName progress:(float)progress;
        [Abstract]
        [Export ("assetDownloadProgressWithAssetName:progress:")]
        void AssetDownloadProgressWithAssetName (string assetName, float progress);

        // @required -(void)assetUpdateError:(NSString *)error;
        [Abstract]
        [Export ("assetUpdateError:")]
        void AssetUpdateError (string error);

        // @required -(void)assetUpdateFinished;
        [Abstract]
        [Export ("assetUpdateFinished")]
        void AssetUpdateFinished ();
    }

    // @interface ALAssetController : NSObject
    [BaseType (typeof(NSObject))]
    interface ALAssetController
    {
        // @property (nonatomic) ALAssetContext * _Nonnull assetContext;
        [Export ("assetContext", ArgumentSemantic.Assign)]
        ALAssetContext AssetContext { get; set; }

        // -(instancetype _Nonnull)initWithContext:(ALAssetContext * _Nonnull)context delegate:(NSObject<ALAssetDelegate> * _Nonnull)delegate;
        [Export ("initWithContext:delegate:")]
        IntPtr Constructor (ALAssetContext context, NSObject @delegate);

        // -(instancetype _Nonnull)initWithContext:(ALAssetContext * _Nonnull)context;
        [Export ("initWithContext:")]
        IntPtr Constructor (ALAssetContext context);

        // -(void)checkForUpdates;
        [Export ("checkForUpdates")]
        void CheckForUpdates ();

        // -(NSString * _Nullable)reportingValues;
        [NullAllowed, Export ("reportingValues")]
        string ReportingValues { get; }

        // -(NSString * _Nullable)assetID;
        [NullAllowed, Export ("assetID")]
        string AssetID { get; }

        // -(NSString * _Nullable)projectID;
        [NullAllowed, Export ("projectID")]
        string ProjectID { get; }

        // -(NSString * _Nonnull)path;
        [Export ("path")]
        string Path { get; }

        // -(void)updateAssets;
        [Export ("updateAssets")]
        void UpdateAssets ();

        // -(void)setupAssetUpdateWithContext:(ALAssetContext * _Nonnull)context delegate:(NSObject<ALAssetDelegate> * _Nullable)delegate;
        [Export ("setupAssetUpdateWithContext:delegate:")]
        void SetupAssetUpdateWithContext (ALAssetContext context, [NullAllowed] NSObject @delegate);

        // -(BOOL)isActive;
        [Export ("isActive")]
        bool IsActive { get; }

        // -(void)resetAssetUpdate;
        [Export ("resetAssetUpdate")]
        void ResetAssetUpdate ();

        // -(void)cancel;
        [Export ("cancel")]
        void Cancel ();

        // -(BOOL)isAssetUpdateCanceled;
        [Export ("isAssetUpdateCanceled")]
        bool IsAssetUpdateCanceled { get; }

        // -(BOOL)areLocalAssetsAvailable;
        [Export ("areLocalAssetsAvailable")]
        bool AreLocalAssetsAvailable { get; }

        // -(void)deleteLocalAssets;
        [Export ("deleteLocalAssets")]
        void DeleteLocalAssets ();

        // -(void)createBackup;
        [Export ("createBackup")]
        void CreateBackup ();

        // -(void)restoreFromBackup;
        [Export ("restoreFromBackup")]
        void RestoreFromBackup ();

        // -(void)deleteBackup;
        [Export ("deleteBackup")]
        void DeleteBackup ();
    }

    // @interface ALAssetControllerFactory : NSObject
    [BaseType (typeof(NSObject))]
    interface ALAssetControllerFactory
    {
        // -(ALAssetController * _Nonnull)makeControllerWithAssetContext:(ALAssetContext * _Nonnull)assetContext assetDelegate:(id<ALAssetDelegate> _Nonnull)assetDelegate;
        [Export ("makeControllerWithAssetContext:assetDelegate:")]
        ALAssetController MakeControllerWithAssetContext (ALAssetContext assetContext, ALAssetDelegate assetDelegate);
    }

    // @interface AnylineSDK : NSObject
    [BaseType (typeof(NSObject))]
    interface AnylineSDK
    {
        // +(BOOL)setupWithLicenseKey:(NSString * _Nonnull)licenseKey error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export ("setupWithLicenseKey:error:")]
        bool SetupWithLicenseKey (string licenseKey, [NullAllowed] out NSError error);

        // +(NSString * _Nonnull)licenseExpirationDate;
        [Static]
        [Export ("licenseExpirationDate")]
        string LicenseExpirationDate { get; }
        // +(NSString * _Nonnull)versionNumber;
        [Static]
        [Export ("versionNumber")]
        string VersionNumber { get; }

        // +(NSString * _Nonnull)buildNumber;
        [Static]
        [Export ("buildNumber")]
        string BuildNumber { get; }
    }
}
