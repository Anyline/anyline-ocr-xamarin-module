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
    /*
    Check whether adding [Model] to this declaration is appropriate.
    [Model] is used to generate a C# class that implements this protocol,
    and might be useful for protocols that consumers are supposed to implement,
    since consumers can subclass the generated class instead of implementing
    the generated interface. If consumers are not supposed to implement this
    protocol, then [Model] is redundant and will generate code that will never
    be used.
    */
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

    // @interface ALExtras (NSData)
    [Category]
    [BaseType (typeof(NSData))]
    interface NSData_ALExtras
    {
        // -(id _Nullable)toJSONObject:(NSError * _Nullable * _Nullable)error;
        [Export ("toJSONObject:")]
        [return: NullAllowed]
        NSObject ToJSONObject ([NullAllowed] out NSError error);

        // -(id _Nullable)asJSONObject;
	    [Export ("asJSONObject")]
		NSObject AsJSONObject();
    }

    // @interface ALExtras (NSString)
    [Category]
    [BaseType (typeof(NSString))]
    interface NSString_ALExtras
    {
        // -(id _Nullable)toJSONObject:(NSError * _Nullable * _Nullable)error;
        [Export ("toJSONObject:")]
        [return: NullAllowed]
        NSObject ToJSONObject ([NullAllowed] out NSError error);

        // -(id _Nullable)asJSONObject;
	    [Export ("asJSONObject")]
		NSObject AsJSONObject();
    }

    // @interface ALExtras (NSDictionary) <ALJSONStringRepresentable>
    [Protocol, Model]
    [BaseType (typeof(NSDictionary))]
    interface NSDictionary_ALExtras : ALJSONStringRepresentable
    {
    }

    // @interface ALExtras (NSArray) <ALJSONStringRepresentable>
    [Protocol, Model]
    [BaseType (typeof(NSArray))]
    interface NSArray_ALExtras : ALJSONStringRepresentable
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

        // +(instancetype _Nullable)defaultCameraConfig;
        [Static]
        [Export ("defaultCameraConfig")]
        [return: NullAllowed]
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

        // +(ALFlashConfig * _Nonnull)withFlashMode:(ALFlashMode)flashMode flashAlignment:(ALFlashAlignment)flashAlignment flashImageName:(NSString * _Nullable)flashImageName flashOffset:(CGPoint)flashOffset;
        [Static]
        [Export ("withFlashMode:flashAlignment:flashImageName:flashOffset:")]
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

        // +(ALTinConfigScanMode * _Nonnull)dotStrict;
        [Static]
        [Export ("dotStrict")]
        ALTinConfigScanMode DotStrict { get; }

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

        // @property (nonatomic, strong) NSNumber * _Nullable startScanDelay;
        [NullAllowed, Export ("startScanDelay", ArgumentSemantic.Strong)]
        NSNumber StartScanDelay { get; set; }

        // @property (copy, nonatomic) NSArray<ALStartVariable *> * _Nullable startVariables;
        [NullAllowed, Export ("startVariables", ArgumentSemantic.Copy)]
        ALStartVariable[] StartVariables { get; set; }

        // @property (nonatomic, strong) ALTinConfig * _Nullable tinConfig;
        [NullAllowed, Export ("tinConfig", ArgumentSemantic.Strong)]
        ALTinConfig TinConfig { get; set; }

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

        // @property (nonatomic, strong) NSNumber * _Nullable scanOption;
        [NullAllowed, Export ("scanOption", ArgumentSemantic.Strong)]
        NSNumber ScanOption { get; set; }
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
        // @property (nonatomic, strong) NSNumber * _Nullable minConfidence;
        [NullAllowed, Export ("minConfidence", ArgumentSemantic.Strong)]
        NSNumber MinConfidence { get; set; }

        // @property (assign, nonatomic) ALMeterConfigScanMode * _Nonnull scanMode;
        [Export ("scanMode", ArgumentSemantic.Assign)]
        ALMeterConfigScanMode ScanMode { get; set; }
    }

    // @interface ALMrzConfig : NSObject
    [BaseType (typeof(NSObject))]
    interface ALMrzConfig
    {
        // @property (assign, nonatomic) BOOL isCropAndTransformID;
        [Export ("isCropAndTransformID")]
        bool IsCropAndTransformID { get; set; }

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

        // @property (copy, nonatomic) NSString * _Nullable model;
        [NullAllowed, Export ("model")]
        string Model { get; set; }

        // @property (assign, nonatomic) ALOcrConfigScanMode * _Nullable scanMode;
        [NullAllowed, Export ("scanMode", ArgumentSemantic.Assign)]
        ALOcrConfigScanMode ScanMode { get; set; }

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

        // @property (nonatomic, strong) NSNumber * _Nullable scanOption;
        [NullAllowed, Export ("scanOption", ArgumentSemantic.Strong)]
        NSNumber ScanOption { get; set; }
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

        // @property (nonatomic, strong) NSNumber * _Nullable scanOption;
        [NullAllowed, Export ("scanOption", ArgumentSemantic.Strong)]
        NSNumber ScanOption { get; set; }
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

    // @interface ALCountry : NSObject
    [BaseType (typeof(NSObject))]
    interface ALCountry
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
        [Export ("value")]
        string Value { get; }

        // +(instancetype _Nullable)withValue:(NSString * _Nonnull)value;
        [Static]
        [Export ("withValue:")]
        [return: NullAllowed]
        ALCountry WithValue (string value);

        // // +(ALCountry * _Nonnull)a;
        // [Static]
        // [Export ("a")]
        // ALCountry A { get; }

        // // +(ALCountry * _Nonnull)af;
        // [Static]
        // [Export ("af")]
        // ALCountry Af { get; }

        // // +(ALCountry * _Nonnull)al;
        // [Static]
        // [Export ("al")]
        // ALCountry Al { get; }

        // // +(ALCountry * _Nonnull)am;
        // [Static]
        // [Export ("am")]
        // ALCountry Am { get; }

        // // +(ALCountry * _Nonnull)and;
        // [Static]
        // [Export ("and")]
        // ALCountry And { get; }

        // // +(ALCountry * _Nonnull)az;
        // [Static]
        // [Export ("az")]
        // ALCountry Az { get; }

        // // +(ALCountry * _Nonnull)b;
        // [Static]
        // [Export ("b")]
        // ALCountry B { get; }

        // // +(ALCountry * _Nonnull)bg;
        // [Static]
        // [Export ("bg")]
        // ALCountry Bg { get; }

        // // +(ALCountry * _Nonnull)bih;
        // [Static]
        // [Export ("bih")]
        // ALCountry Bih { get; }

        // // +(ALCountry * _Nonnull)by;
        // [Static]
        // [Export ("by")]
        // ALCountry By { get; }

        // // +(ALCountry * _Nonnull)ch;
        // [Static]
        // [Export ("ch")]
        // ALCountry Ch { get; }

        // // +(ALCountry * _Nonnull)cy;
        // [Static]
        // [Export ("cy")]
        // ALCountry Cy { get; }

        // // +(ALCountry * _Nonnull)cz;
        // [Static]
        // [Export ("cz")]
        // ALCountry Cz { get; }

        // // +(ALCountry * _Nonnull)d;
        // [Static]
        // [Export ("d")]
        // ALCountry D { get; }

        // // +(ALCountry * _Nonnull)dk;
        // [Static]
        // [Export ("dk")]
        // ALCountry Dk { get; }

        // // +(ALCountry * _Nonnull)e;
        // [Static]
        // [Export ("e")]
        // ALCountry E { get; }

        // // +(ALCountry * _Nonnull)empty;
        // [Static]
        // [Export ("empty")]
        // ALCountry Empty { get; }

        // // +(ALCountry * _Nonnull)est;
        // [Static]
        // [Export ("est")]
        // ALCountry Est { get; }

        // // +(ALCountry * _Nonnull)f;
        // [Static]
        // [Export ("f")]
        // ALCountry F { get; }

        // // +(ALCountry * _Nonnull)fin;
        // [Static]
        // [Export ("fin")]
        // ALCountry Fin { get; }

        // // +(ALCountry * _Nonnull)fl;
        // [Static]
        // [Export ("fl")]
        // ALCountry Fl { get; }

        // // +(ALCountry * _Nonnull)gb;
        // [Static]
        // [Export ("gb")]
        // ALCountry Gb { get; }

        // // +(ALCountry * _Nonnull)ge;
        // [Static]
        // [Export ("ge")]
        // ALCountry Ge { get; }

        // // +(ALCountry * _Nonnull)gr;
        // [Static]
        // [Export ("gr")]
        // ALCountry Gr { get; }

        // // +(ALCountry * _Nonnull)h;
        // [Static]
        // [Export ("h")]
        // ALCountry H { get; }

        // // +(ALCountry * _Nonnull)hr;
        // [Static]
        // [Export ("hr")]
        // ALCountry Hr { get; }

        // // +(ALCountry * _Nonnull)i;
        // [Static]
        // [Export ("i")]
        // ALCountry I { get; }

        // // +(ALCountry * _Nonnull)ire;
        // [Static]
        // [Export ("ire")]
        // ALCountry Ire { get; }

        // // +(ALCountry * _Nonnull)is;
        // [Static]
        // [Export ("is")]
        // ALCountry Is { get; }

        // // +(ALCountry * _Nonnull)l;
        // [Static]
        // [Export ("l")]
        // ALCountry L { get; }

        // // +(ALCountry * _Nonnull)lt;
        // [Static]
        // [Export ("lt")]
        // ALCountry Lt { get; }

        // // +(ALCountry * _Nonnull)lv;
        // [Static]
        // [Export ("lv")]
        // ALCountry Lv { get; }

        // // +(ALCountry * _Nonnull)m;
        // [Static]
        // [Export ("m")]
        // ALCountry M { get; }

        // // +(ALCountry * _Nonnull)mc;
        // [Static]
        // [Export ("mc")]
        // ALCountry Mc { get; }

        // // +(ALCountry * _Nonnull)mne;
        // [Static]
        // [Export ("mne")]
        // ALCountry Mne { get; }

        // // +(ALCountry * _Nonnull)mo;
        // [Static]
        // [Export ("mo")]
        // ALCountry Mo { get; }

        // // +(ALCountry * _Nonnull)n;
        // [Static]
        // [Export ("n")]
        // ALCountry N { get; }

        // // +(ALCountry * _Nonnull)nSpecial;
        // [Static]
        // [Export ("nSpecial")]
        // ALCountry NSpecial { get; }

        // // +(ALCountry * _Nonnull)nl;
        // [Static]
        // [Export ("nl")]
        // ALCountry Nl { get; }

        // // +(ALCountry * _Nonnull)nmk;
        // [Static]
        // [Export ("nmk")]
        // ALCountry Nmk { get; }

        // // +(ALCountry * _Nonnull)p;
        // [Static]
        // [Export ("p")]
        // ALCountry P { get; }

        // // +(ALCountry * _Nonnull)pl;
        // [Static]
        // [Export ("pl")]
        // ALCountry Pl { get; }

        // // +(ALCountry * _Nonnull)ro;
        // [Static]
        // [Export ("ro")]
        // ALCountry Ro { get; }

        // // +(ALCountry * _Nonnull)rus;
        // [Static]
        // [Export ("rus")]
        // ALCountry Rus { get; }

        // // +(ALCountry * _Nonnull)s;
        // [Static]
        // [Export ("s")]
        // ALCountry S { get; }

        // // +(ALCountry * _Nonnull)sk;
        // [Static]
        // [Export ("sk")]
        // ALCountry Sk { get; }

        // // +(ALCountry * _Nonnull)slo;
        // [Static]
        // [Export ("slo")]
        // ALCountry Slo { get; }

        // // +(ALCountry * _Nonnull)srb;
        // [Static]
        // [Export ("srb")]
        // ALCountry Srb { get; }

        // // +(ALCountry * _Nonnull)tr;
        // [Static]
        // [Export ("tr")]
        // ALCountry Tr { get; }

        // // +(ALCountry * _Nonnull)ua;
        // [Static]
        // [Export ("ua")]
        // ALCountry Ua { get; }

        // // +(ALCountry * _Nonnull)us;
        // [Static]
        // [Export ("us")]
        // ALCountry Us { get; }
    }

    // @interface ALType : NSObject
    [BaseType (typeof(NSObject))]
    interface ALType
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
        [Export ("value")]
        string Value { get; }

        // +(instancetype _Nullable)withValue:(NSString * _Nonnull)value;
        [Static]
        [Export ("withValue:")]
        [return: NullAllowed]
        ALType WithValue (string value);

        // // +(ALType * _Nonnull)drivingLicense;
        // [Static]
        // [Export ("drivingLicense")]
        // ALType DrivingLicense { get; }

        // // +(ALType * _Nonnull)insuranceCard;
        // [Static]
        // [Export ("insuranceCard")]
        // ALType InsuranceCard { get; }

        // // +(ALType * _Nonnull)mrz;
        // [Static]
        // [Export ("mrz")]
        // ALType Mrz { get; }

        // // +(ALType * _Nonnull)theIDFront;
        // [Static]
        // [Export ("theIDFront")]
        // ALType TheIDFront { get; }
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

        // @property (copy, nonatomic) NSString * _Nonnull pluginID;
        [Export ("pluginID")]
        string PluginID { get; set; }

        // @property (nonatomic, strong) ALTinResult * _Nullable tinResult;
        [NullAllowed, Export ("tinResult", ArgumentSemantic.Strong)]
        ALTinResult TinResult { get; set; }

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

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable coordinates;
        [NullAllowed, Export ("coordinates", ArgumentSemantic.Copy)]
        NSNumber[] Coordinates { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull format;
        [Export ("format")]
        string Format { get; set; }

        // @property (assign, nonatomic) BOOL isBase64;
        [Export ("isBase64")]
        bool IsBase64 { get; set; }

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

        // @property (assign, nonatomic) ALCountry * _Nonnull country;
        [Export ("country", ArgumentSemantic.Assign)]
        ALCountry Country { get; set; }

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

    // @interface ALTinResult : NSObject
    [BaseType (typeof(NSObject))]
    interface ALTinResult
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
        // @property (nonatomic, strong) ALLayoutDefinition * _Nonnull layoutDefinition;
        [Export ("layoutDefinition", ArgumentSemantic.Strong)]
        ALLayoutDefinition LayoutDefinition { get; set; }

        // @property (nonatomic, strong) ALIDResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        ALIDResult Result { get; set; }

        // @property (nonatomic, strong) ALVisualization * _Nullable visualization;
        [NullAllowed, Export ("visualization", ArgumentSemantic.Strong)]
        ALVisualization Visualization { get; set; }
    }

    // @interface ALLayoutDefinition : NSObject
    [BaseType (typeof(NSObject))]
    interface ALLayoutDefinition
    {
        // @property (copy, nonatomic) NSString * _Nonnull country;
        [Export ("country")]
        string Country { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull layout;
        [Export ("layout")]
        string Layout { get; set; }

        // @property (assign, nonatomic) ALType * _Nonnull type;
        [Export ("type", ArgumentSemantic.Assign)]
        ALType Type { get; set; }
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

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable drivingLicenseString;
        [NullAllowed, Export ("drivingLicenseString", ArgumentSemantic.Strong)]
        ALUniversalIDResultField DrivingLicenseString { get; set; }

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

        // @property (nonatomic, strong) ALUniversalIDResultField * _Nullable theIDFrontString;
        [NullAllowed, Export ("theIDFrontString", ArgumentSemantic.Strong)]
        ALUniversalIDResultField TheIDFrontString { get; set; }

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
    }

    // @interface ALScanPluginConfig : NSObject <ALJSONStringRepresentable>
    [BaseType (typeof(NSObject))]
    interface ALScanPluginConfig : ALJSONStringRepresentable
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull pluginID;
        [Export ("pluginID")]
        string PluginID { get; }

        // @property (readonly, nonatomic) NSInteger startScanDelay;
        [Export ("startScanDelay")]
        nint StartScanDelay { get; }

        // @property (readonly, nonatomic) BOOL cancelOnResult;
        [Export ("cancelOnResult")]
        bool CancelOnResult { get; }

        // @property (readonly, nonatomic) ALPluginConfig * _Nonnull pluginConfig;
        [Export ("pluginConfig")]
        ALPluginConfig PluginConfig { get; }

        // -(id _Nonnull)initWithPluginConfig:(ALPluginConfig * _Nonnull)pluginConfig;
        [Export ("initWithPluginConfig:")]
        IntPtr Constructor (ALPluginConfig pluginConfig);

        // -(id _Nullable)initWithJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONDictionary:error:")]
        IntPtr Constructor (NSDictionary JSONDictionary, [NullAllowed] out NSError error);

        // +(ALScanPluginConfig * _Nonnull)withPluginConfig:(ALPluginConfig * _Nonnull)pluginConfig;
        [Static]
        [Export ("withPluginConfig:")]
        ALScanPluginConfig WithPluginConfig (ALPluginConfig pluginConfig);

        // +(ALScanPluginConfig * _Nullable)withJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary;
        [Static]
        [Export ("withJSONDictionary:")]
        [return: NullAllowed]
        ALScanPluginConfig WithJSONDictionary (NSDictionary JSONDictionary);
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

        // @property (readonly, nonatomic, strong) ALScanPluginConfig * _Nonnull scanPluginConfig;
        [Export ("scanPluginConfig", ArgumentSemantic.Strong)]
        ALScanPluginConfig ScanPluginConfig { get; }

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

        // -(id _Nullable)initWithConfig:(ALScanPluginConfig * _Nonnull)scanPluginConfig error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithConfig:error:")]
        IntPtr Constructor (ALScanPluginConfig scanPluginConfig, [NullAllowed] out NSError error);

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

        // -(instancetype _Nonnull)initWithScanResultEvent:(ALEvent * _Nonnull)event;
        [Export ("initWithScanResultEvent:")]
        IntPtr Constructor (ALEvent @event);

        // +(ALScanResult * _Nonnull)withScanResultEvent:(ALEvent * _Nonnull)event;
        [Static]
        [Export ("withScanResultEvent:")]
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

        // @property (readonly, nonatomic) ALScanPluginConfig * _Nonnull scanPluginConfig;
        [Export ("scanPluginConfig")]
        ALScanPluginConfig ScanPluginConfig { get; }

        // -(instancetype _Nullable)initWithScanPluginConfig:(ALScanPluginConfig * _Nonnull)scanPluginConfig cutoutConfig:(ALCutoutConfig * _Nullable)cutoutConfig scanFeedbackConfig:(ALScanFeedbackConfig * _Nullable)scanFeedbackConfig error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
        [Export ("initWithScanPluginConfig:cutoutConfig:scanFeedbackConfig:error:")]
        [DesignatedInitializer]
        IntPtr Constructor (ALScanPluginConfig scanPluginConfig, [NullAllowed] ALCutoutConfig cutoutConfig, [NullAllowed] ALScanFeedbackConfig scanFeedbackConfig, [NullAllowed] out NSError error);

        // -(instancetype _Nullable)initWithScanPluginConfig:(ALScanPluginConfig * _Nonnull)scanPluginConfig error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithScanPluginConfig:error:")]
        IntPtr Constructor (ALScanPluginConfig scanPluginConfig, [NullAllowed] out NSError error);

        // -(instancetype _Nullable)initWithJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithJSONDictionary:error:")]
        IntPtr Constructor (NSDictionary JSONDictionary, [NullAllowed] out NSError error);

        // +(ALScanViewPluginConfig * _Nullable)withScanPluginConfig:(ALScanPluginConfig * _Nonnull)scanPluginConfig cutoutConfig:(ALCutoutConfig * _Nullable)cutoutConfig scanFeedbackConfig:(ALScanFeedbackConfig * _Nullable)scanFeedbackConfig;
        [Static]
        [Export ("withScanPluginConfig:cutoutConfig:scanFeedbackConfig:")]
        [return: NullAllowed]
        ALScanViewPluginConfig WithScanPluginConfig (ALScanPluginConfig scanPluginConfig, [NullAllowed] ALCutoutConfig cutoutConfig, [NullAllowed] ALScanFeedbackConfig scanFeedbackConfig);

        // +(ALScanViewPluginConfig * _Nullable)withScanPluginConfig:(ALScanPluginConfig * _Nonnull)scanPluginConfig;
        [Static]
        [Export ("withScanPluginConfig:")]
        [return: NullAllowed]
        ALScanViewPluginConfig WithScanPluginConfig (ALScanPluginConfig scanPluginConfig);

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

        // @property (readonly, nonatomic) NSArray<id<ALScanViewPluginBase>> * _Nonnull children;
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
        // -(instancetype _Nullable)initWithFrame:(CGRect)frame scanViewPlugin:(id<ALScanViewPluginBase> _Nonnull)scanViewPlugin scanViewConfig:(ALScanViewConfig * _Nullable)scanViewConfig error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithFrame:scanViewPlugin:scanViewConfig:error:")]
        IntPtr Constructor (CGRect frame, ALScanViewPluginBase scanViewPlugin, [NullAllowed] ALScanViewConfig scanViewConfig, [NullAllowed] out NSError error);

        // -(instancetype _Nullable)initWithFrame:(CGRect)frame scanViewPlugin:(id<ALScanViewPluginBase> _Nonnull)scanViewPlugin error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithFrame:scanViewPlugin:error:")]
        IntPtr Constructor (CGRect frame, ALScanViewPluginBase scanViewPlugin, [NullAllowed] out NSError error);

        // -(BOOL)setScanViewPlugin:(id<ALScanViewPluginBase> _Nonnull)scanViewPlugin error:(NSError * _Nullable * _Nullable)error;
        [Export ("setScanViewPlugin:error:")]
        bool SetScanViewPlugin (ALScanViewPluginBase scanViewPlugin, [NullAllowed] out NSError error);

        [Wrap ("WeakDelegate")]
        [NullAllowed]
        ALScanViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ALScanViewDelegate> _Nullable delegate;
        [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic) id<ALScanViewPluginBase> _Nonnull scanViewPlugin;
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
    }

    // @interface ALScanViewPluginFactory : NSObject
    [BaseType (typeof(NSObject))]
    interface ALScanViewPluginFactory
    {
        // +(id<ALScanViewPluginBase> _Nullable)withJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary;
        [Static]
        [Export ("withJSONDictionary:")]
        [return: NullAllowed]
        ALScanViewPluginBase WithJSONDictionary (NSDictionary JSONDictionary);
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

        // +(ALScanView * _Nullable)withJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary delegate:(id<ALScanPluginDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export ("withJSONDictionary:delegate:error:")]
        [return: NullAllowed]
        ALScanView WithJSONDictionary (NSDictionary JSONDictionary, ALScanPluginDelegate @delegate, [NullAllowed] out NSError error);

        // +(ALScanView * _Nullable)withConfigFilePath:(NSString * _Nonnull)configFilePath delegate:(id _Nonnull)delegate;
        [Static]
        [Export ("withConfigFilePath:delegate:")]
        [return: NullAllowed]
        ALScanView WithConfigFilePath (string configFilePath, NSObject @delegate);

        // +(ALScanView * _Nullable)withJSONDictionary:(NSDictionary * _Nonnull)JSONDictionary delegate:(id<ALScanPluginDelegate> _Nonnull)delegate;
        [Static]
        [Export ("withJSONDictionary:delegate:")]
        [return: NullAllowed]
        ALScanView WithJSONDictionary (NSDictionary JSONDictionary, ALScanPluginDelegate @delegate);
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

        // @property (readonly, nonatomic) NSArray<id<ALScanViewPluginBase>> * _Nonnull children;
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

        // -(instancetype _Nullable)initWithID:(NSString * _Nonnull)ID mode:(ALCompositeProcessingMode)mode children:(NSArray<id<ALScanViewPluginBase>> * _Nonnull)children error:(NSError * _Nullable * _Nullable)error;
        [Export ("initWithID:mode:children:error:")]
        IntPtr Constructor (string ID, ALCompositeProcessingMode mode, ALScanViewPluginBase[] children, [NullAllowed] out NSError error);

        // -(id<ALScanViewPluginBase> _Nullable)pluginWithID:(NSString * _Nonnull)pluginID;
        [Export ("pluginWithID:")]
        [return: NullAllowed]
        ALScanViewPluginBase PluginWithID (string pluginID);
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
        // +(instancetype _Nonnull)sharedInstance;
        [Static]
        [Export ("sharedInstance")]
        ALLicenseUtil SharedInstance ();

        // -(BOOL)wasLicenseChecked;
        [Export ("wasLicenseChecked")]
        bool WasLicenseChecked { get; }

        // -(BOOL)scopeEnabledFor:(NSString * _Nonnull)valueName;
        [Export ("scopeEnabledFor:")]
        bool ScopeEnabledFor (string valueName);

        // -(NSString * _Nonnull)licenseExpirationDateForKey:(NSString * _Nonnull)licenseKey;
        [Export ("licenseExpirationDateForKey:")]
        string LicenseExpirationDateForKey (string licenseKey);
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

        // -(instancetype _Nullable)initWithDelegate:(id<ALNFCDetectorDelegate> _Nonnull)delegate licenseUtil:(ALLicenseUtil * _Nonnull)licenseUtil;
        [Export ("initWithDelegate:licenseUtil:")]
        IntPtr Constructor (ALNFCDetectorDelegate @delegate, ALLicenseUtil licenseUtil);

        // -(instancetype _Nullable)initWithDelegate:(id<ALNFCDetectorDelegate> _Nonnull)delegate;
        [Export ("initWithDelegate:")]
        IntPtr Constructor (ALNFCDetectorDelegate @delegate);

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

        // -(instancetype _Nonnull)initWithDataGroup1:(ALDataGroup1 * _Nonnull)dataGroup1 dataGroup2:(ALDataGroup2 * _Nonnull)dataGroup2 sod:(ALSOD * _Nonnull)sod;
        [Export ("initWithDataGroup1:dataGroup2:sod:")]
        IntPtr Constructor (ALDataGroup1 dataGroup1, ALDataGroup2 dataGroup2, ALSOD sod);
    }

    // @interface ALDataGroup1 : NSObject
    [BaseType (typeof(NSObject))]
    interface ALDataGroup1
    {
        // @property NSString * _Nonnull documentType;
        [Export ("documentType")]
        string DocumentType { get; set; }

        // @property NSString * _Nonnull issuingStateCode;
        [Export ("issuingStateCode")]
        string IssuingStateCode { get; set; }

        // @property NSString * _Nonnull documentNumber;
        [Export ("documentNumber")]
        string DocumentNumber { get; set; }

        // @property NSDate * _Nonnull dateOfExpiry;
        [Export ("dateOfExpiry", ArgumentSemantic.Assign)]
        NSDate DateOfExpiry { get; set; }

        // @property NSString * _Nonnull gender;
        [Export ("gender")]
        string Gender { get; set; }

        // @property NSString * _Nonnull nationality;
        [Export ("nationality")]
        string Nationality { get; set; }

        // @property NSString * _Nonnull lastName;
        [Export ("lastName")]
        string LastName { get; set; }

        // @property NSString * _Nonnull firstName;
        [Export ("firstName")]
        string FirstName { get; set; }

        // @property NSDate * _Nonnull dateOfBirth;
        [Export ("dateOfBirth", ArgumentSemantic.Assign)]
        NSDate DateOfBirth { get; set; }

        // -(instancetype _Nonnull)initWithDocumentType:(NSString * _Nonnull)documentType issuingStateCode:(NSString * _Nonnull)issuingStateCode documentNumber:(NSString * _Nonnull)documentNumber dateOfExpiry:(NSDate * _Nonnull)dateOfExpiry gender:(NSString * _Nonnull)gender nationality:(NSString * _Nonnull)nationality lastName:(NSString * _Nonnull)lastName firstName:(NSString * _Nonnull)firstName dateOfBirth:(NSDate * _Nonnull)dateOfBirth;
        [Export ("initWithDocumentType:issuingStateCode:documentNumber:dateOfExpiry:gender:nationality:lastName:firstName:dateOfBirth:")]
        IntPtr Constructor (string documentType, string issuingStateCode, string documentNumber, NSDate dateOfExpiry, string gender, string nationality, string lastName, string firstName, NSDate dateOfBirth);

        // -(instancetype _Nonnull)initWithPassportDataElements:(NSDictionary<NSString *,NSString *> * _Nonnull)passportDataElements;
        [Export ("initWithPassportDataElements:")]
        IntPtr Constructor (NSDictionary<NSString, NSString> passportDataElements);
    }

    // @interface ALDataGroup2 : NSObject
    [BaseType (typeof(NSObject))]
    interface ALDataGroup2
    {
        // @property UIImage * _Nonnull faceImage;
        [Export ("faceImage", ArgumentSemantic.Assign)]
        UIImage FaceImage { get; set; }

        // -(instancetype _Nonnull)initWithFaceImage:(UIImage * _Nonnull)faceImage;
        [Export ("initWithFaceImage:")]
        IntPtr Constructor (UIImage faceImage);
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

        // @property (nonatomic, strong) ALAssetControllerFactory * _Nonnull assetControllerFactory;
        [Export ("assetControllerFactory", ArgumentSemantic.Strong)]
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

        // @property (nonatomic, strong) ALAssetUpdateTaskFactory * _Nonnull assetUpdateTaskFactory;
        [Export ("assetUpdateTaskFactory", ArgumentSemantic.Strong)]
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
        void AddUpdateTask (ALAssetContext assetContext, ALAssetUpdateDelegate @delegate);

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

        // -(ALAssetUpdateTask * _Nonnull)removeUpdateTask:(NSString * _Nonnull)id;
        [Export ("removeUpdateTask:")]
        ALAssetUpdateTask RemoveUpdateTask (string id);

        // -(void)removeAll;
        [Export ("removeAll")]
        void RemoveAll ();

        // -(ALAssetController * _Nonnull)assetControllerForID:(NSString * _Nonnull)id;
        [Export ("assetControllerForID:")]
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
        IntPtr Constructor (ALAssetContext context, ALAssetDelegate @delegate);

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
        void SetupAssetUpdateWithContext (ALAssetContext context, [NullAllowed] ALAssetDelegate @delegate);

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

        // +(NSString * _Nonnull)licenseExpirationDateForLicense:(NSString * _Nonnull)licenseKey;
        [Static]
        [Export ("licenseExpirationDateForLicense:")]
        string LicenseExpirationDateForLicense (string licenseKey);

        // +(NSString * _Nonnull)versionNumber;
        [Static]
        [Export ("versionNumber")]
        string VersionNumber { get; }

        // +(NSString * _Nonnull)buildNumber;
        [Static]
        [Export ("buildNumber")]
        string BuildNumber { get; }
    }




    // // @interface ALCutoutView : UIView
    // [BaseType(typeof(UIView))]
    // interface ALCutoutView
    // {
    //     // @property (assign, nonatomic) CGFloat cutoutWidthPercent;
    //     [Export("cutoutWidthPercent")]
    //     nfloat CutoutWidthPercent { get; set; }

    //     // @property (assign, nonatomic) CGFloat cutoutMaxPercentWidth;
    //     [Export("cutoutMaxPercentWidth")]
    //     nfloat CutoutMaxPercentWidth { get; set; }

    //     // @property (assign, nonatomic) CGFloat cutoutMaxPercentHeight;
    //     [Export("cutoutMaxPercentHeight")]
    //     nfloat CutoutMaxPercentHeight { get; set; }

    //     // @property (assign, nonatomic) CGPoint cutoutOffset;
    //     [Export("cutoutOffset", ArgumentSemantic.Assign)]
    //     CGPoint CutoutOffset { get; set; }

    //     // @property (assign, nonatomic) NSInteger cornerRadius;
    //     [Export("cornerRadius")]
    //     nint CornerRadius { get; set; }

    //     // @property (assign, nonatomic) NSInteger strokeWidth;
    //     [Export("strokeWidth")]
    //     nint StrokeWidth { get; set; }

    //     // @property (assign, nonatomic) ALCutoutAlignment cutoutAlignment;
    //     [Export("cutoutAlignment", ArgumentSemantic.Assign)]
    //     ALCutoutAlignment CutoutAlignment { get; set; }

    //     // @property (copy, nonatomic) UIBezierPath * _Nullable cutoutPath;
    //     [NullAllowed, Export("cutoutPath", ArgumentSemantic.Copy)]
    //     UIBezierPath CutoutPath { get; set; }

    //     // @property (nonatomic, strong) UIColor * _Nullable cutoutBackgroundColor;
    //     [NullAllowed, Export("cutoutBackgroundColor", ArgumentSemantic.Strong)]
    //     UIColor CutoutBackgroundColor { get; set; }

    //     // @property (nonatomic, strong) UIColor * _Nullable strokeColor;
    //     [NullAllowed, Export("strokeColor", ArgumentSemantic.Strong)]
    //     UIColor StrokeColor { get; set; }

    //     // @property (nonatomic, strong) UIColor * _Nullable feedbackStrokeColor;
    //     [NullAllowed, Export("feedbackStrokeColor", ArgumentSemantic.Strong)]
    //     UIColor FeedbackStrokeColor { get; set; }

    //     // @property (nonatomic, strong) UIImage * _Nullable overlayImage;
    //     [NullAllowed, Export("overlayImage", ArgumentSemantic.Strong)]
    //     UIImage OverlayImage { get; set; }

    //     // -(instancetype _Nullable)initWithFrame:(CGRect)frame cutoutWidthPercent:(CGFloat)cutoutWidthPercent cutoutMaxPercentWidth:(CGFloat)cutoutMaxPercentWidth cutoutMaxPercentHeight:(CGFloat)cutoutMaxPercentHeight cutoutOffset:(CGPoint)cutoutOffset cornerRadius:(NSInteger)cornerRadius strokeWidth:(NSInteger)strokeWidth cutoutAlignment:(ALCutoutAlignment)cutoutAlignment cutoutPath:(UIBezierPath * _Nonnull)cutoutPath cutoutBackgroundColor:(UIColor * _Nonnull)cutoutBackgroundColor strokeColor:(UIColor * _Nonnull)strokeColor feedbackStrokeColor:(UIColor * _Nonnull)feedbackStrokeColor overlayImage:(UIImage * _Nonnull)overlayImage;
    //     [Export("initWithFrame:cutoutWidthPercent:cutoutMaxPercentWidth:cutoutMaxPercentHeight:cutoutOffset:cornerRadius:strokeWidth:cutoutAlignment:cutoutPath:cutoutBackgroundColor:strokeColor:feedbackStrokeColor:overlayImage:")]
    //     IntPtr Constructor(CGRect frame, nfloat cutoutWidthPercent, nfloat cutoutMaxPercentWidth, nfloat cutoutMaxPercentHeight, CGPoint cutoutOffset, nint cornerRadius, nint strokeWidth, ALCutoutAlignment cutoutAlignment, UIBezierPath cutoutPath, UIColor cutoutBackgroundColor, UIColor strokeColor, UIColor feedbackStrokeColor, UIImage overlayImage);

    //     // -(CGRect)cutoutRectScreen;
    //     [Export("cutoutRectScreen")]
    //     CGRect CutoutRectScreen { get; }

    //     // -(void)drawCutout:(BOOL)feedbackMode;
    //     [Export("drawCutout:")]
    //     void DrawCutout(bool feedbackMode);

    //     // -(void)calculateAndDrawCutout;
    //     [Export("calculateAndDrawCutout")]
    //     void CalculateAndDrawCutout();
    // }

    // // @interface ALFlashButtonConfig : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALFlashButtonConfig
    // {
    //     // @property (assign, nonatomic) ALFlashMode flashMode;
    //     [Export("flashMode", ArgumentSemantic.Assign)]
    //     ALFlashMode FlashMode { get; set; }

    //     // @property (assign, nonatomic) ALFlashAlignment flashAlignment;
    //     [Export("flashAlignment", ArgumentSemantic.Assign)]
    //     ALFlashAlignment FlashAlignment { get; set; }

    //     // @property (nonatomic, strong) UIImage * _Nullable flashImage;
    //     [NullAllowed, Export("flashImage", ArgumentSemantic.Strong)]
    //     UIImage FlashImage { get; set; }

    //     // @property (assign, nonatomic) CGPoint flashOffset;
    //     [Export("flashOffset", ArgumentSemantic.Assign)]
    //     CGPoint FlashOffset { get; set; }

    //     // +(instancetype _Nullable)configurationFromJsonFilePath:(NSString * _Nonnull)jsonFile;
    //     [Static]
    //     [Export("configurationFromJsonFilePath:")]
    //     [return: NullAllowed]
    //     ALFlashButtonConfig ConfigurationFromJsonFilePath(string jsonFile);

    //     // -(instancetype _Nullable)initWithJsonFilePath:(NSString * _Nonnull)jsonFile;
    //     [Export("initWithJsonFilePath:")]
    //     IntPtr Constructor(string jsonFile);

    //     // -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)configDict;
    //     [Export("initWithDictionary:")]
    //     IntPtr Constructor(NSDictionary configDict);

    //     // -(instancetype _Nullable)initWithFlashMode:(ALFlashMode)flashMode flashAlignment:(ALFlashAlignment)flashAlignment flashOffset:(CGPoint)flashOffset;
    //     [Export("initWithFlashMode:flashAlignment:flashOffset:")]
    //     IntPtr Constructor(ALFlashMode flashMode, ALFlashAlignment flashAlignment, CGPoint flashOffset);

    //     // +(instancetype _Nonnull)defaultFlashConfig;
    //     [Static]
    //     [Export("defaultFlashConfig")]
    //     ALFlashButtonConfig DefaultFlashConfig();
    // }

    // // @protocol ALFlashButtonStatusDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface IALFlashButtonStatusDelegate
    // {
    //     // @required -(void)flashButton:(ALFlashButton * _Nonnull)flashButton statusChanged:(ALFlashStatus)flashStatus;
    //     [Abstract]
    //     [Export("flashButton:statusChanged:")]
    //     void StatusChanged(ALFlashButton flashButton, ALFlashStatus flashStatus);
    // }

    // // @protocol ALFlashButtonAnimationDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface ALFlashButtonAnimationDelegate
    // {
    //     // @optional -(void)flashButton:(ALFlashButton * _Nonnull)flashButton expanded:(BOOL)expanded;
    //     [Export("flashButton:expanded:")]
    //     void Expanded(ALFlashButton flashButton, bool expanded);
    // }

    // // @interface ALFlashButton : UIControl
    // [BaseType(typeof(UIControl))]
    // interface ALFlashButton
    // {
    //     // @property (readonly, assign, nonatomic) BOOL expanded;
    //     [Export("expanded")]
    //     bool Expanded { get; }

    //     // @property (readonly, assign, nonatomic) BOOL expandLeft;
    //     [Export("expandLeft")]
    //     bool ExpandLeft { get; }

    //     // @property (readonly, nonatomic, strong) UIImageView * _Nullable flashImage;
    //     [NullAllowed, Export("flashImage", ArgumentSemantic.Strong)]
    //     UIImageView FlashImage { get; }

    //     // @property (assign, nonatomic) ALFlashStatus flashStatus;
    //     [Export("flashStatus", ArgumentSemantic.Assign)]
    //     ALFlashStatus FlashStatus { get; set; }

    //     [Wrap("WeakDelegate")]
    //     [NullAllowed]
    //     IALFlashButtonStatusDelegate Delegate { get; set; }

    //     // @property (nonatomic, weak) id<ALFlashButtonStatusDelegate> _Nullable delegate;
    //     [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
    //     NSObject WeakDelegate { get; set; }

    //     [Wrap("WeakAnimationDelegate")]
    //     [NullAllowed]
    //     ALFlashButtonAnimationDelegate AnimationDelegate { get; set; }

    //     // @property (nonatomic, weak) id<ALFlashButtonAnimationDelegate> _Nullable animationDelegate;
    //     [NullAllowed, Export("animationDelegate", ArgumentSemantic.Weak)]
    //     NSObject WeakAnimationDelegate { get; set; }

    //     // -(void)setExpanded:(BOOL)expanded animated:(BOOL)animated;
    //     [Export("setExpanded:animated:")]
    //     void SetExpanded(bool expanded, bool animated);

    //     // -(instancetype _Nullable)initWithFrame:(CGRect)frame flashButtonConfig:(ALFlashButtonConfig * _Nonnull)flashButtonConfig;
    //     [Export("initWithFrame:flashButtonConfig:")]
    //     IntPtr Constructor(CGRect frame, ALFlashButtonConfig flashButtonConfig);
    // }

    // // @interface ALIndexPath : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALIndexPath
    // {
    //     // @property (nonatomic) NSInteger line;
    //     [Export("line")]
    //     nint Line { get; set; }

    //     // @property (nonatomic) NSInteger positionInLine;
    //     [Export("positionInLine")]
    //     nint PositionInLine { get; set; }

    //     // -(instancetype)initWithPosition:(NSInteger)position inLine:(NSInteger)line;
    //     [Export("initWithPosition:inLine:")]
    //     IntPtr Constructor(nint position, nint line);

    //     // -(NSComparisonResult)compare:(id)object;
    //     [Export("compare:")]
    //     NSComparisonResult Compare(NSObject @object);
    // }

    // // @interface ALImage : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALImage
    // {
    //     // @property (nonatomic, strong) UIImage * uiImage;
    //     [Export("uiImage", ArgumentSemantic.Strong)]
    //     UIImage UiImage { get; set; }

    //     // -(UIImage *)uiImageWithSpecOverlay:(ALROISpec *)displaySpec;
    //     //[Export("uiImageWithSpecOverlay:")]
    //     //UIImage UiImageWithSpecOverlay(ALROISpec displaySpec);

    //     // -(UIImage *)uiImageWithDisplayResults:(ALDisplayResult *)displayResult;
    //     [Export("uiImageWithDisplayResults:")]
    //     UIImage UiImageWithDisplayResults(ALDisplayResult displayResult);

    //     // -(UIImage *)uiImageWithDigitOverlay:(ALDataPoint *)digitSpec;
    //     [Export("uiImageWithDigitOverlay:")]
    //     UIImage UiImageWithDigitOverlay(ALDataPoint digitSpec);

    //     // -(UIImage *)uiImageWithRectOverlay:(CGRect)rectToDraw;
    //     [Export("uiImageWithRectOverlay:")]
    //     UIImage UiImageWithRectOverlay(CGRect rectToDraw);

    //     // -(UIImage *)uiImageWithSquareOverlay:(ALSquare *)square;
    //     [Export("uiImageWithSquareOverlay:")]
    //     UIImage UiImageWithSquareOverlay(ALSquare square);

    //     // -(UIImage *)uiImageWithHorizontalLines:(NSArray *)lines;
    //     [Export("uiImageWithHorizontalLines:")]
    //     UIImage UiImageWithHorizontalLines(NSObject[] lines);

    //     // -(UIImage *)uiImageWithVerticalLines:(NSArray *)lines;
    //     [Export("uiImageWithVerticalLines:")]
    //     UIImage UiImageWithVerticalLines(NSObject[] lines);

    //     // -(UIImage *)uiImageWithContours:(ALContours *)contours;
    //     [Export("uiImageWithContours:")]
    //     UIImage UiImageWithContours(ALContours contours);

    //     // -(instancetype)initWithUIImage:(UIImage *)uiImage;
    //     [Export("initWithUIImage:")]
    //     IntPtr Constructor(UIImage uiImage);

    //     // -(instancetype)initWithBGRAImageBuffer:(CVImageBufferRef)imageBuffer rotate:(CGFloat)degrees;
    //     //[Export("initWithBGRAImageBuffer:rotate:")]
    //     //unsafe IntPtr Constructor(CVImageBufferRef* imageBuffer, nfloat degrees);

    //     // -(instancetype)initWithBGRAImageBuffer:(CVImageBufferRef)imageBuffer rotate:(CGFloat)degrees cutout:(CGRect)cutout;
    //     //[Export("initWithBGRAImageBuffer:rotate:cutout:")]
    //     //unsafe IntPtr Constructor(CVImageBufferRef* imageBuffer, nfloat degrees, CGRect cutout);

    //     // -(BOOL)isEmpy;
    //     [Export("isEmpy")]
    //     bool IsEmpy { get; }
    // }

    // // @interface ALCameraConfig : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALCameraConfig
    // {
    //     // @property (nonatomic, strong) NSString * _Nullable defaultCamera;
    //     [NullAllowed, Export("defaultCamera", ArgumentSemantic.Strong)]
    //     string DefaultCamera { get; set; }

    //     // @property (assign, nonatomic) ALCaptureViewResolution captureResolution;
    //     [Export("captureResolution", ArgumentSemantic.Assign)]
    //     ALCaptureViewResolution CaptureResolution { get; set; }

    //     // @property (assign, nonatomic) ALPictureResolution pictureResolution;
    //     [Export("pictureResolution", ArgumentSemantic.Assign)]
    //     ALPictureResolution PictureResolution { get; set; }

    //     // @property (assign, nonatomic) BOOL zoomGesture;
    //     [Export("zoomGesture")]
    //     bool ZoomGesture { get; set; }

    //     // +(instancetype _Nullable)configurationFromJsonFilePath:(NSString * _Nonnull)jsonFile;
    //     [Static]
    //     [Export("configurationFromJsonFilePath:")]
    //     [return: NullAllowed]
    //     ALCameraConfig ConfigurationFromJsonFilePath(string jsonFile);

    //     // -(instancetype _Nullable)initWithJsonFilePath:(NSString * _Nonnull)jsonFile;
    //     [Export("initWithJsonFilePath:")]
    //     IntPtr Constructor(string jsonFile);

    //     // -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)configDict;
    //     [Export("initWithDictionary:")]
    //     IntPtr Constructor(NSDictionary configDict);

    //     /*
    //     // -(instancetype _Nullable)initWithDefaultCamera:(NSString * _Nonnull)defaultCamera captureResolution:(ALCaptureViewResolution)captureResolution pictureResolution:(ALPictureResolution)pictureResolution;
    //     [Export("initWithDefaultCamera:captureResolution:pictureResolution:")]
    //     IntPtr Constructor(string defaultCamera, ALCaptureViewResolution captureResolution, ALPictureResolution pictureResolution);

    //     // -(instancetype _Nullable)initWithDefaultCamera:(NSString * _Nonnull)defaultCamera captureResolution:(ALCaptureViewResolution)captureResolution pictureResolution:(ALPictureResolution)pictureResolution zoomGesture:(BOOL)zoomGesture zoomRatio:(CGFloat)zoomRatio maxZoomRatio:(CGFloat)maxZoomRatio;
    //     [Export("initWithDefaultCamera:captureResolution:pictureResolution:zoomGesture:zoomRatio:maxZoomRatio:")]
    //     IntPtr Constructor(string defaultCamera, ALCaptureViewResolution captureResolution, ALPictureResolution pictureResolution, bool zoomGesture, nfloat zoomRatio, nfloat maxZoomRatio);

    //     // -(instancetype _Nullable)initWithDefaultCamera:(NSString * _Nonnull)defaultCamera captureResolution:(ALCaptureViewResolution)captureResolution pictureResolution:(ALPictureResolution)pictureResolution zoomGesture:(BOOL)zoomGesture focalLength:(CGFloat)focalLength maxFocalLength:(CGFloat)maxFocalLength;
    //     [Export("initWithDefaultCamera:captureResolution:pictureResolution:zoomGesture:focalLength:maxFocalLength:")]
    //     IntPtr Constructor(string defaultCamera, ALCaptureViewResolution captureResolution, ALPictureResolution pictureResolution, bool zoomGesture, nfloat focalLength, nfloat maxFocalLength);
    //     */

    //     // +(instancetype _Nullable)defaultCameraConfig;
    //     [Static]
    //     [Export("defaultCameraConfig")]
    //     [return: NullAllowed]
    //     ALCameraConfig DefaultCameraConfig();

    //     // +(instancetype _Nullable)defaultDocumentCameraConfig;
    //     [Static]
    //     [Export("defaultDocumentCameraConfig")]
    //     [return: NullAllowed]
    //     ALCameraConfig DefaultDocumentCameraConfig();

    //     // -(void)setFocalLength:(CGFloat)focalLength;
    //     [Export("setFocalLength:")]
    //     void SetFocalLength(nfloat focalLength);

    //     // -(void)setZoomRatio:(CGFloat)ratio;
    //     [Export("setZoomRatio:")]
    //     void SetZoomRatio(nfloat ratio);

    //     // -(void)setMaxZoomRatio:(CGFloat)maxZoomRatio;
    //     [Export("setMaxZoomRatio:")]
    //     void SetMaxZoomRatio(nfloat maxZoomRatio);

    //     // -(void)setMaxFocalLength:(CGFloat)maxFocalLength;
    //     [Export("setMaxFocalLength:")]
    //     void SetMaxFocalLength(nfloat maxFocalLength);

    //     // -(CGFloat)maxZoomFactor;
    //     [Export("maxZoomFactor")]
    //     nfloat MaxZoomFactor { get; }

    //     // -(CGFloat)zoomFactor;
    //     [Export("zoomFactor")]
    //     nfloat ZoomFactor { get; }
    // }

    // // @interface ALScanFeedbackConfig : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALScanFeedbackConfig
    // {
    //     // @property (assign, nonatomic) ALUIFeedbackStyle style;
    //     [Export("style", ArgumentSemantic.Assign)]
    //     ALUIFeedbackStyle Style { get; set; }

    //     // @property (assign, nonatomic) ALUIVisualFeedbackAnimation animation;
    //     [Export("animation", ArgumentSemantic.Assign)]
    //     ALUIVisualFeedbackAnimation Animation { get; set; }

    //     // @property (nonatomic, strong) UIColor * _Nullable strokeColor;
    //     [NullAllowed, Export("strokeColor", ArgumentSemantic.Strong)]
    //     UIColor StrokeColor { get; set; }

    //     // @property (nonatomic, strong) UIColor * _Nullable fillColor;
    //     [NullAllowed, Export("fillColor", ArgumentSemantic.Strong)]
    //     UIColor FillColor { get; set; }

    //     // @property (assign, nonatomic) NSInteger strokeWidth;
    //     [Export("strokeWidth")]
    //     nint StrokeWidth { get; set; }

    //     // @property (assign, nonatomic) NSInteger cornerRadius;
    //     [Export("cornerRadius")]
    //     nint CornerRadius { get; set; }

    //     // @property (assign, nonatomic) NSInteger animationDuration;
    //     [Export("animationDuration")]
    //     nint AnimationDuration { get; set; }

    //     // @property (assign, nonatomic) NSInteger redrawTimeout;
    //     [Export("redrawTimeout")]
    //     nint RedrawTimeout { get; set; }

    //     // @property (assign, nonatomic) BOOL beepOnResult;
    //     [Export("beepOnResult")]
    //     bool BeepOnResult { get; set; }

    //     // @property (assign, nonatomic) BOOL vibrateOnResult;
    //     [Export("vibrateOnResult")]
    //     bool VibrateOnResult { get; set; }

    //     // @property (assign, nonatomic) BOOL blinkAnimationOnResult;
    //     [Export("blinkAnimationOnResult")]
    //     bool BlinkAnimationOnResult { get; set; }

    //     // -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)configDict;
    //     [Export("initWithDictionary:")]
    //     IntPtr Constructor(NSDictionary configDict);

    //     // -(instancetype _Nullable)initWithStyle:(ALUIFeedbackStyle)style animation:(ALUIVisualFeedbackAnimation)animation strokeColor:(UIColor * _Nonnull)strokeColor fillColor:(UIColor * _Nonnull)fillColor strokeWidth:(NSInteger)strokeWidth cornerRadius:(NSInteger)cornerRadius animationDuration:(NSInteger)animationDuration redrawTimeout:(NSInteger)redrawTimeout beepOnResult:(BOOL)beepOnResult vibrateOnResult:(BOOL)vibrateOnResult blinkAnimationOnResult:(BOOL)blinkAnimationOnResult;
    //     [Export("initWithStyle:animation:strokeColor:fillColor:strokeWidth:cornerRadius:animationDuration:redrawTimeout:beepOnResult:vibrateOnResult:blinkAnimationOnResult:")]
    //     IntPtr Constructor(ALUIFeedbackStyle style, ALUIVisualFeedbackAnimation animation, UIColor strokeColor, UIColor fillColor, nint strokeWidth, nint cornerRadius, nint animationDuration, nint redrawTimeout, bool beepOnResult, bool vibrateOnResult, bool blinkAnimationOnResult);

    //     // +(instancetype _Nonnull)defaultScanFeedbackConfig;
    //     [Static]
    //     [Export("defaultScanFeedbackConfig")]
    //     ALScanFeedbackConfig DefaultScanFeedbackConfig();
    // }

    // // @interface ALCutoutConfig : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALCutoutConfig
    // {
    //     // @property (assign, nonatomic) CGFloat widthPercent;
    //     [Export("widthPercent")]
    //     nfloat WidthPercent { get; set; }

    //     // @property (assign, nonatomic) CGFloat maxPercentWidth;
    //     [Export("maxPercentWidth")]
    //     nfloat MaxPercentWidth { get; set; }

    //     // @property (assign, nonatomic) CGFloat maxPercentHeight;
    //     [Export("maxPercentHeight")]
    //     nfloat MaxPercentHeight { get; set; }

    //     // @property (assign, nonatomic) ALCutoutAlignment alignment;
    //     [Export("alignment", ArgumentSemantic.Assign)]
    //     ALCutoutAlignment Alignment { get; set; }

    //     // @property (assign, nonatomic) CGPoint offset;
    //     [Export("offset", ArgumentSemantic.Assign)]
    //     CGPoint Offset { get; set; }

    //     // @property (copy, nonatomic) UIBezierPath * _Nullable path;
    //     [NullAllowed, Export("path", ArgumentSemantic.Copy)]
    //     UIBezierPath Path { get; set; }

    //     // @property (assign, nonatomic) CGSize cropPadding;
    //     [Export("cropPadding", ArgumentSemantic.Assign)]
    //     CGSize CropPadding { get; set; }

    //     // @property (assign, nonatomic) CGPoint cropOffset;
    //     [Export("cropOffset", ArgumentSemantic.Assign)]
    //     CGPoint CropOffset { get; set; }

    //     // @property (nonatomic, strong) UIColor * _Nullable backgroundColor;
    //     [NullAllowed, Export("backgroundColor", ArgumentSemantic.Strong)]
    //     UIColor BackgroundColor { get; set; }

    //     // @property (nonatomic, strong) UIColor * _Nullable strokeColor;
    //     [NullAllowed, Export("strokeColor", ArgumentSemantic.Strong)]
    //     UIColor StrokeColor { get; set; }

    //     // @property (nonatomic, strong) UIColor * _Nullable feedbackStrokeColor;
    //     [NullAllowed, Export("feedbackStrokeColor", ArgumentSemantic.Strong)]
    //     UIColor FeedbackStrokeColor { get; set; }

    //     // @property (nonatomic, strong) UIImage * _Nullable overlayImage;
    //     [NullAllowed, Export("overlayImage", ArgumentSemantic.Strong)]
    //     UIImage OverlayImage { get; set; }

    //     // @property (assign, nonatomic) NSInteger strokeWidth;
    //     [Export("strokeWidth")]
    //     nint StrokeWidth { get; set; }

    //     // @property (assign, nonatomic) NSInteger cornerRadius;
    //     [Export("cornerRadius")]
    //     nint CornerRadius { get; set; }

    //     // -(void)setCutoutPathForWidth:(CGFloat)width height:(CGFloat)height;
    //     [Export("setCutoutPathForWidth:height:")]
    //     void SetCutoutPathForWidth(nfloat width, nfloat height);

    //     // -(void)updateCutoutWidth:(CGFloat)width;
    //     [Export("updateCutoutWidth:")]
    //     void UpdateCutoutWidth(nfloat width);

    //     // +(instancetype _Nonnull)defaultCutoutConfig;
    //     [Static]
    //     [Export("defaultCutoutConfig")]
    //     ALCutoutConfig DefaultCutoutConfig();

    //     // -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)configDict;
    //     [Export("initWithDictionary:")]
    //     IntPtr Constructor(NSDictionary configDict);

    //     // -(instancetype _Nullable)initWithWidthPercent:(CGFloat)widthPercent maxPercentWidth:(CGFloat)maxPercentWidth maxPercentHeight:(CGFloat)maxPercentHeight alignment:(ALCutoutAlignment)alignment offset:(CGPoint)offset path:(UIBezierPath * _Nonnull)path cropPadding:(CGSize)cropPadding cropOffset:(CGPoint)cropOffset backgroundColor:(UIColor * _Nonnull)backgroundColor strokeColor:(UIColor * _Nonnull)strokeColor feedbackStrokeColor:(UIColor * _Nonnull)feedbackStrokeColor overlayImage:(UIImage * _Nullable)overlayImage strokeWidth:(NSInteger)strokeWidth cornerRadius:(NSInteger)cornerRadius;
    //     [Export("initWithWidthPercent:maxPercentWidth:maxPercentHeight:alignment:offset:path:cropPadding:cropOffset:backgroundColor:strokeColor:feedbackStrokeColor:overlayImage:strokeWidth:cornerRadius:")]
    //     IntPtr Constructor(nfloat widthPercent, nfloat maxPercentWidth, nfloat maxPercentHeight, ALCutoutAlignment alignment, CGPoint offset, UIBezierPath path, CGSize cropPadding, CGPoint cropOffset, UIColor backgroundColor, UIColor strokeColor, UIColor feedbackStrokeColor, [NullAllowed] UIImage overlayImage, nint strokeWidth, nint cornerRadius);
    // }

    // // @interface ALScanViewPluginConfig : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALScanViewPluginConfig
    // {
    //     // @property (nonatomic, strong) ALScanFeedbackConfig * _Nonnull scanFeedbackConfig;
    //     [Export("scanFeedbackConfig", ArgumentSemantic.Strong)]
    //     ALScanFeedbackConfig ScanFeedbackConfig { get; set; }

    //     // @property (nonatomic, strong) ALCutoutConfig * _Nonnull cutoutConfig;
    //     [Export("cutoutConfig", ArgumentSemantic.Strong)]
    //     ALCutoutConfig CutoutConfig { get; set; }

    //     // @property (assign, nonatomic) BOOL cancelOnResult;
    //     [Export("cancelOnResult")]
    //     bool CancelOnResult { get; set; }

    //     // @property (assign, nonatomic) int delayStartScanTime;
    //     [Export("delayStartScanTime")]
    //     int DelayStartScanTime { get; set; }

    //     // -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)configDict;
    //     [Export("initWithDictionary:")]
    //     IntPtr Constructor(NSDictionary configDict);

    //     // +(instancetype _Nullable)configurationFromJsonFilePath:(NSString * _Nonnull)jsonFile;
    //     [Static]
    //     [Export("configurationFromJsonFilePath:")]
    //     [return: NullAllowed]
    //     ALScanViewPluginConfig ConfigurationFromJsonFilePath(string jsonFile);

    //     // -(instancetype _Nullable)initWithJsonFilePath:(NSString * _Nonnull)jsonFile;
    //     [Export("initWithJsonFilePath:")]
    //     IntPtr Constructor(string jsonFile);

    //     // -(instancetype _Nullable)initWithScanFeedbackConfig:(ALScanFeedbackConfig * _Nonnull)scanFeedbackConfig cutoutConfig:(ALCutoutConfig * _Nonnull)cutoutConfig cancelOnResult:(BOOL)cancelOnResult delayStartScanTime:(int)delayStartScanTime;
    //     [Export("initWithScanFeedbackConfig:cutoutConfig:cancelOnResult:delayStartScanTime:")]
    //     IntPtr Constructor(ALScanFeedbackConfig scanFeedbackConfig, ALCutoutConfig cutoutConfig, bool cancelOnResult, int delayStartScanTime);

    //     // -(instancetype _Nullable)initWithScanFeedbackConfig:(ALScanFeedbackConfig * _Nonnull)scanFeedbackConfig cutoutConfig:(ALCutoutConfig * _Nonnull)cutoutConfig cancelOnResult:(BOOL)cancelOnResult;
    //     [Export("initWithScanFeedbackConfig:cutoutConfig:cancelOnResult:")]
    //     IntPtr Constructor(ALScanFeedbackConfig scanFeedbackConfig, ALCutoutConfig cutoutConfig, bool cancelOnResult);

    //     // +(instancetype _Nonnull)defaultScanViewPluginConfig;
    //     [Static]
    //     [Export("defaultScanViewPluginConfig")]
    //     ALScanViewPluginConfig DefaultScanViewPluginConfig();

    //     // +(instancetype _Nonnull)defaultDocumentScannerConfig;
    //     [Static]
    //     [Export("defaultDocumentScannerConfig")]
    //     ALScanViewPluginConfig DefaultDocumentScannerConfig();

    //     // +(instancetype _Nonnull)defaultBarcodeConfig;
    //     [Static]
    //     [Export("defaultBarcodeConfig")]
    //     ALScanViewPluginConfig DefaultBarcodeConfig();

    //     // +(instancetype _Nonnull)defaultLicensePlateConfig;
    //     [Static]
    //     [Export("defaultLicensePlateConfig")]
    //     ALScanViewPluginConfig DefaultLicensePlateConfig();

    //     // +(instancetype _Nonnull)defaultOCRConfig;
    //     [Static]
    //     [Export("defaultOCRConfig")]
    //     ALScanViewPluginConfig DefaultOCRConfig();

    //     // +(instancetype _Nonnull)defaultVINConfig;
    //     [Static]
    //     [Export("defaultVINConfig")]
    //     ALScanViewPluginConfig DefaultVINConfig();

    //     // added in 13:

    //     // +(instancetype _Nonnull)defaultTINConfig;
    //     [Static]
    //     [Export("defaultTINConfig")]
    //     ALScanViewPluginConfig DefaultTINConfig();

    //     // +(instancetype _Nonnull)defaultContainerConfig;
    //     [Static]
    //     [Export("defaultContainerConfig")]
    //     ALScanViewPluginConfig DefaultContainerConfig();

    //     // +(instancetype _Nonnull)defaultCattleTagConfig;
    //     [Static]
    //     [Export("defaultCattleTagConfig")]
    //     ALScanViewPluginConfig DefaultCattleTagConfig();

    //     // +(instancetype _Nonnull)defaultMRZConfig;
    //     [Static]
    //     [Export("defaultMRZConfig")]
    //     ALScanViewPluginConfig DefaultMRZConfig();

    //     // +(instancetype _Nonnull)defaultMeterConfig;
    //     [Static]
    //     [Export("defaultMeterConfig")]
    //     ALScanViewPluginConfig DefaultMeterConfig();
    // }

    // // @interface ALBasicConfig : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALBasicConfig
    // {
    //     // @property (nonatomic, strong) ALCameraConfig * _Nonnull cameraConfig;
    //     [Export("cameraConfig", ArgumentSemantic.Strong)]
    //     ALCameraConfig CameraConfig { get; set; }

    //     // @property (nonatomic, strong) ALFlashButtonConfig * _Nonnull flashButtonConfig;
    //     [Export("flashButtonConfig", ArgumentSemantic.Strong)]
    //     ALFlashButtonConfig FlashButtonConfig { get; set; }

    //     // @property (nonatomic, strong) ALScanViewPluginConfig * _Nonnull scanViewPluginConfig;
    //     [Export("scanViewPluginConfig", ArgumentSemantic.Strong)]
    //     ALScanViewPluginConfig ScanViewPluginConfig { get; set; }

    //     // +(instancetype _Nullable)cutoutConfigurationFromJsonFile:(NSString * _Nonnull)jsonFile;
    //     [Static]
    //     [Export("cutoutConfigurationFromJsonFile:")]
    //     [return: NullAllowed]
    //     ALBasicConfig CutoutConfigurationFromJsonFile(string jsonFile);

    //     // -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)dictionary;
    //     [Export("initWithDictionary:")]
    //     IntPtr Constructor(NSDictionary dictionary);

    //     // -(instancetype _Nullable)initWithJsonFile:(NSString * _Nonnull)jsonFile;
    //     [Export("initWithJsonFile:")]
    //     IntPtr Constructor(string jsonFile);

    //     // -(instancetype _Nullable)initWithCameraConfig:(ALCameraConfig * _Nonnull)cameraConfig flashButtonConfig:(ALFlashButtonConfig * _Nonnull)flashButtonConfig scanViewPluginConfig:(ALScanViewPluginConfig * _Nonnull)scanViewPluginConfig;
    //     [Export("initWithCameraConfig:flashButtonConfig:scanViewPluginConfig:")]
    //     IntPtr Constructor(ALCameraConfig cameraConfig, ALFlashButtonConfig flashButtonConfig, ALScanViewPluginConfig scanViewPluginConfig);
    // }

    // // @interface ALContours : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALContours
    // {
    // }

    // // @interface ALSquare : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALSquare
    // {
    //     // @property (assign, nonatomic) CGPoint upLeft;
    //     [Export("upLeft", ArgumentSemantic.Assign)]
    //     CGPoint UpLeft { get; set; }

    //     // @property (assign, nonatomic) CGPoint upRight;
    //     [Export("upRight", ArgumentSemantic.Assign)]
    //     CGPoint UpRight { get; set; }

    //     // @property (assign, nonatomic) CGPoint downLeft;
    //     [Export("downLeft", ArgumentSemantic.Assign)]
    //     CGPoint DownLeft { get; set; }

    //     // @property (assign, nonatomic) CGPoint downRight;
    //     [Export("downRight", ArgumentSemantic.Assign)]
    //     CGPoint DownRight { get; set; }

    //     // -(instancetype)initWithUpLeft:(CGPoint)upLeft upRight:(CGPoint)upRight downLeft:(CGPoint)downLeft downRight:(CGPoint)downRight;
    //     [Export("initWithUpLeft:upRight:downLeft:downRight:")]
    //     IntPtr Constructor(CGPoint upLeft, CGPoint upRight, CGPoint downLeft, CGPoint downRight);

    //     // -(instancetype)initWithCGRect:(CGRect)rect;
    //     [Export("initWithCGRect:")]
    //     IntPtr Constructor(CGRect rect);

    //     // -(CGFloat)boundingX;
    //     [Export("boundingX")]

    //     nfloat BoundingX { get; }

    //     // -(CGFloat)boundingY;
    //     [Export("boundingY")]

    //     nfloat BoundingY { get; }

    //     // -(CGFloat)boundingWidth;
    //     [Export("boundingWidth")]

    //     nfloat BoundingWidth { get; }

    //     // -(CGFloat)boundingHeight;
    //     [Export("boundingHeight")]

    //     nfloat BoundingHeight { get; }

    //     // -(ALSquare *)squareWithPointOffset:(CGPoint)offset;
    //     [Export("squareWithPointOffset:")]
    //     ALSquare SquareWithPointOffset(CGPoint offset);

    //     // -(ALSquare *)squareWithScale:(CGFloat)scale;
    //     [Export("squareWithScale:")]
    //     ALSquare SquareWithScale(nfloat scale);

    //     // -(CGFloat)area;
    //     [Export("area")]

    //     nfloat Area { get; }

    //     // -(CGFloat)area2;
    //     [Export("area2")]

    //     nfloat Area2 { get; }

    //     // -(float)ratio;
    //     [Export("ratio")]

    //     float Ratio { get; }

    //     // -(CGRect)boxRect;
    //     [Export("boxRect")]

    //     CGRect BoxRect { get; }
    // }

    // /*
    // // @interface ALROISpec : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALROISpec
    // {
    //     // @property (assign, nonatomic) CGSize size;
    //     [Export("size", ArgumentSemantic.Assign)]
    //     CGSize Size { get; set; }

    //     // @property (nonatomic, strong) NSArray * dataPoints;
    //     [Export("dataPoints", ArgumentSemantic.Strong)]

    //     NSObject[] DataPoints { get; set; }

    //     // -(instancetype)initWithDataPoints:(NSArray *)dataPoints size:(CGSize)size;
    //     [Export("initWithDataPoints:size:")]

    //     IntPtr Constructor(NSObject[] dataPoints, CGSize size);

    //     // -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
    //     [Export("initWithDictionary:")]
    //     IntPtr Constructor(NSDictionary dictionary);

    //     // -(instancetype)initWithJSonFileName:(NSString *)filename;
    //     [Export("initWithJSonFileName:")]
    //     IntPtr Constructor(string filename);

    //     // -(instancetype)initWithJSonString:(NSString *)jsonString;
    //     [Export("initWithJSonString:")]
    //     IntPtr Constructor(string jsonString);

    //     // -(instancetype)initWithJSonData:(NSData *)jsonData;
    //     [Export("initWithJSonData:")]
    //     IntPtr Constructor(NSData jsonData);

    //     // -(NSArray *)dataPointsForLine:(NSInteger)line;
    //     [Export("dataPointsForLine:")]

    //     NSObject[] DataPointsForLine(nint line);

    //     // -(NSArray *)lineNumbers;
    //     [Export("lineNumbers")]
    //     NSObject[] LineNumbers { get; }
    // }*/

    // // @interface ALSegmentSpec : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALSegmentSpec
    // {
    //     // @property (assign, nonatomic) CGRect bounds;
    //     [Export("bounds", ArgumentSemantic.Assign)]
    //     CGRect Bounds { get; set; }

    //     // -(instancetype)initWithBounds:(CGRect)bounds;
    //     [Export("initWithBounds:")]
    //     IntPtr Constructor(CGRect bounds);

    //     // -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
    //     [Export("initWithDictionary:")]
    //     IntPtr Constructor(NSDictionary dictionary);
    // }

    // // @interface ALDataPoint : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALDataPoint
    // {
    //     // @property (assign, nonatomic) CGRect area;
    //     [Export("area", ArgumentSemantic.Assign)]
    //     CGRect Area { get; set; }

    //     // @property (readonly, nonatomic, strong) ALIndexPath * indexPath;
    //     [Export("indexPath", ArgumentSemantic.Strong)]
    //     ALIndexPath IndexPath { get; }

    //     // @property (readonly, nonatomic, strong) NSString * identifier;
    //     [Export("identifier", ArgumentSemantic.Strong)]
    //     string Identifier { get; }

    //     // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier;
    //     [Export("initWithArea:indexPath:identifier:")]
    //     IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier);

    //     // -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
    //     [Export("initWithDictionary:")]
    //     IntPtr Constructor(NSDictionary dictionary);

    //     // +(ALDataPoint *)dataPointForDictionary:(NSDictionary *)dictionary;
    //     [Static]
    //     [Export("dataPointForDictionary:")]
    //     ALDataPoint DataPointForDictionary(NSDictionary dictionary);
    // }

    // // @interface ALDigitDataPoint : ALDataPoint
    // [BaseType(typeof(ALDataPoint))]
    // interface ALDigitDataPoint
    // {
    //     // @property (readonly, nonatomic, strong) NSArray * segments;
    //     [Export("segments", ArgumentSemantic.Strong)]

    //     NSObject[] Segments { get; }

    //     // @property (readonly, nonatomic, strong) NSArray * qualitySegments;
    //     [Export("qualitySegments", ArgumentSemantic.Strong)]

    //     NSObject[] QualitySegments { get; }

    //     // @property (readonly, nonatomic, strong) NSDictionary * segmentResultPattern;
    //     [Export("segmentResultPattern", ArgumentSemantic.Strong)]
    //     NSDictionary SegmentResultPattern { get; }

    //     // @property (readonly, nonatomic) NSInteger italicOffset;
    //     [Export("italicOffset")]
    //     nint ItalicOffset { get; }

    //     // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier italicOffset:(NSInteger)italicOffset segments:(NSArray *)segments qualitySegments:(NSArray *)qualitySegments segmentResultPattern:(NSDictionary *)segmentResultPattern;
    //     [Export("initWithArea:indexPath:identifier:italicOffset:segments:qualitySegments:segmentResultPattern:")]

    //     IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier, nint italicOffset, NSObject[] segments, NSObject[] qualitySegments, NSDictionary segmentResultPattern);

    //     // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier italicOffset:(NSInteger)italicOffset segmentResultPattern:(NSDictionary *)segmentResultPattern;
    //     [Export("initWithArea:indexPath:identifier:italicOffset:segmentResultPattern:")]
    //     IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier, nint italicOffset, NSDictionary segmentResultPattern);

    //     // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier italicOffset:(NSInteger)italicOffset;
    //     [Export("initWithArea:indexPath:identifier:italicOffset:")]
    //     IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier, nint italicOffset);

    //     // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier;
    //     [Export("initWithArea:indexPath:identifier:")]
    //     IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier);

    //     // -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
    //     [Export("initWithDictionary:")]
    //     IntPtr Constructor(NSDictionary dictionary);
    // }

    // // @interface ALTextDataPoint : ALDataPoint
    // [BaseType(typeof(ALDataPoint))]
    // interface ALTextDataPoint
    // {
    //     // @property (readonly, nonatomic, strong) NSDictionary * tesseractParameter;
    //     [Export("tesseractParameter", ArgumentSemantic.Strong)]
    //     NSDictionary TesseractParameter { get; }

    //     // @property (readonly, nonatomic, strong) NSArray * languages;
    //     [Export("languages", ArgumentSemantic.Strong)]

    //     NSObject[] Languages { get; }

    //     // @property (nonatomic) ALCharacterRange characterCount;
    //     [Export("characterCount", ArgumentSemantic.Assign)]
    //     ALCharacterRange CharacterCount { get; set; }

    //     // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier languages:(NSArray *)languages tesseractParameter:(NSDictionary *)tesseractParameter;
    //     [Export("initWithArea:indexPath:identifier:languages:tesseractParameter:")]

    //     IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier, NSObject[] languages, NSDictionary tesseractParameter);

    //     // -(instancetype)initWithArea:(CGRect)area indexPath:(ALIndexPath *)indexPath identifier:(NSString *)identifier languages:(NSArray *)languages tesseractParameter:(NSDictionary *)tesseractParameter characterRange:(ALCharacterRange)characterRange;
    //     [Export("initWithArea:indexPath:identifier:languages:tesseractParameter:characterRange:")]

    //     IntPtr Constructor(CGRect area, ALIndexPath indexPath, string identifier, NSObject[] languages, NSDictionary tesseractParameter, ALCharacterRange characterRange);
    // }

    // // @interface ALResult : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALResult
    // {
    //     // @property (nonatomic, strong) ALROISpec * specs;
    //     //[Export("specs", ArgumentSemantic.Strong)]
    //     //ALROISpec Specs { get; set; }

    //     // @property (nonatomic) BOOL valid;
    //     [Export("valid")]
    //     bool Valid { get; set; }

    //     // -(NSArray *)identifiers;
    //     [Export("identifiers")]
    //     NSObject[] Identifiers { get; }

    //     // -(id)resultForIdentifier:(NSString *)identifier;
    //     [Export("resultForIdentifier:")]
    //     NSObject ResultForIdentifier(string identifier);

    //     // -(ALFieldConfidence)confidenceForIdentifier:(NSString *)identifier;
    //     [Export("confidenceForIdentifier:")]
    //     int ConfidenceForIdentifier(string identifier);
    // }

    // // @interface ALSegmentResult : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALSegmentResult
    // {
    //     // @property (readonly, nonatomic) float ratioBlackPixel;
    //     [Export("ratioBlackPixel")]
    //     float RatioBlackPixel { get; }

    //     // @property (assign, nonatomic) CGRect frame;
    //     [Export("frame", ArgumentSemantic.Assign)]
    //     CGRect Frame { get; set; }

    //     // @property (assign, nonatomic) BOOL active;
    //     [Export("active")]
    //     bool Active { get; set; }

    //     // -(instancetype)initWithRatioBlackPixel:(float)ratioBlackPixel frame:(CGRect)frame;
    //     [Export("initWithRatioBlackPixel:frame:")]
    //     IntPtr Constructor(float ratioBlackPixel, CGRect frame);
    // }

    // // @interface ALDigitResult : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALDigitResult
    // {
    //     // @property (readonly, nonatomic, strong) id value;
    //     [Export("value", ArgumentSemantic.Strong)]
    //     NSObject Value { get; }

    //     // @property (readonly, nonatomic, strong) NSArray * segments;
    //     [Export("segments", ArgumentSemantic.Strong)]

    //     NSObject[] Segments { get; }

    //     // @property (readonly, nonatomic, strong) NSArray * qualitySegments;
    //     [Export("qualitySegments", ArgumentSemantic.Strong)]

    //     NSObject[] QualitySegments { get; }

    //     // @property (readonly, nonatomic, strong) ALIndexPath * indexPath;
    //     [Export("indexPath", ArgumentSemantic.Strong)]
    //     ALIndexPath IndexPath { get; }

    //     // @property (readonly, nonatomic, strong) NSString * identifier;
    //     [Export("identifier", ArgumentSemantic.Strong)]
    //     string Identifier { get; }

    //     // @property (readonly, nonatomic, strong) NSDictionary * patternResultDictionary;
    //     [Export("patternResultDictionary", ArgumentSemantic.Strong)]
    //     NSDictionary PatternResultDictionary { get; }

    //     // -(float)quality;
    //     [Export("quality")]

    //     float Quality { get; }
    // }

    // // @interface ALDisplayResult : ALResult <NSCopying>
    // [BaseType(typeof(ALResult))]
    // interface ALDisplayResult : INSCopying
    // {
    //     // -(int)numberOfDigits;
    //     [Export("numberOfDigits")]

    //     int NumberOfDigits { get; }

    //     // -(NSArray *)digitsForIdentifier:(NSString *)identifier;
    //     [Export("digitsForIdentifier:")]

    //     NSObject[] DigitsForIdentifier(string identifier);

    //     // -(NSString *)stringRepresentationOfDigitsForIdentifier:(NSString *)identifier;
    //     [Export("stringRepresentationOfDigitsForIdentifier:")]
    //     string StringRepresentationOfDigitsForIdentifier(string identifier);

    //     // -(float)quality;
    //     [Export("quality")]

    //     float Quality { get; }

    //     // -(NSArray *)digitIdentifiers;
    //     [Export("digitIdentifiers")]
    //     NSObject[] DigitIdentifiers { get; }
    // }

    // // @interface ALValuesStack : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALValuesStack
    // {
    //     // @property (nonatomic) NSInteger size;
    //     [Export("size")]
    //     nint Size { get; set; }

    //     // @property (nonatomic) NSInteger minEqualResults;
    //     [Export("minEqualResults")]
    //     nint MinEqualResults { get; set; }

    //     // @property (nonatomic, strong) id lastCommitedResult;
    //     [Export("lastCommitedResult", ArgumentSemantic.Strong)]
    //     NSObject LastCommitedResult { get; set; }

    //     // @property (nonatomic) BOOL hasNewResult;
    //     [Export("hasNewResult")]
    //     bool HasNewResult { get; set; }

    //     // @property (nonatomic) BOOL consecutivelyValue;
    //     [Export("consecutivelyValue")]
    //     bool ConsecutivelyValue { get; set; }

    //     // @property (nonatomic) NSInteger currentEqualCount;
    //     [Export("currentEqualCount")]
    //     nint CurrentEqualCount { get; set; }

    //     // @property (nonatomic) NSInteger currentEqualCountWithoutEmpty;
    //     [Export("currentEqualCountWithoutEmpty")]
    //     nint CurrentEqualCountWithoutEmpty { get; set; }

    //     // -(instancetype)initWithSize:(NSInteger)size minimalEqualResults:(NSInteger)minEqualResults allowSameValueConsecutively:(BOOL)consecutivelyValue;
    //     [Export("initWithSize:minimalEqualResults:allowSameValueConsecutively:")]
    //     IntPtr Constructor(nint size, nint minEqualResults, bool consecutivelyValue);

    //     // -(void)addResult:(id)result;
    //     [Export("addResult:")]
    //     void AddResult(NSObject result);

    //     // -(id)newResult;
    //     [Export("newResult")]

    //     NSObject NewResult { get; }
    // }

    // // @interface ALValuesStackFlipping : ALValuesStack
    // [BaseType(typeof(ALValuesStack))]
    // interface ALValuesStackFlipping
    // {
    //     // -(instancetype)initWithSize:(NSInteger)size minimalEqualResults:(NSInteger)minEqualResults allowSameValueConsecutively:(BOOL)consecutivelyValue acceptPartialResultSize:(NSInteger)partialResultSize;
    //     [Export("initWithSize:minimalEqualResults:allowSameValueConsecutively:acceptPartialResultSize:")]
    //     IntPtr Constructor(nint size, nint minEqualResults, bool consecutivelyValue, nint partialResultSize);

    //     // -(instancetype)initWithSize:(NSInteger)size minimalEqualResults:(NSInteger)minEqualResults allowSameValueConsecutively:(BOOL)consecutivelyValue;
    //     [Export("initWithSize:minimalEqualResults:allowSameValueConsecutively:")]
    //     IntPtr Constructor(nint size, nint minEqualResults, bool consecutivelyValue);
    // }

    // // @protocol ALImageProvider <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface IALImageProvider
    // {
    //     // @required -(void)provideNewImageWithCompletionBlock:(ALImageProviderBlock)completionHandler;
    //     [Abstract]
    //     [Export("provideNewImageWithCompletionBlock:")]
    //     void ProvideNewImageWithCompletionBlock(ALImageProviderBlock completionHandler);

    //     // @required -(void)provideNewFullResolutionImageWithCompletionBlock:(ALImageProviderBlock)completionHandler;
    //     [Abstract]
    //     [Export("provideNewFullResolutionImageWithCompletionBlock:")]
    //     void ProvideNewFullResolutionImageWithCompletionBlock(ALImageProviderBlock completionHandler);

    //     // @required -(void)provideNewStillImageWithCompletionBlock:(ALImageProviderBlock)completionHandler;
    //     [Abstract]
    //     [Export("provideNewStillImageWithCompletionBlock:")]
    //     void ProvideNewStillImageWithCompletionBlock(ALImageProviderBlock completionHandler);
    // }

    // // typedef void (^ALImageProviderBlock)(ALImage *, NSError *);
    // delegate void ALImageProviderBlock(ALImage arg0, NSError arg1);

    // // @interface ALCoreController : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALCoreController
    // {
    //     // @property (assign, nonatomic) BOOL asyncSDK;
    //     [Export("asyncSDK")]
    //     bool AsyncSDK { get; set; }

    //     // @property (getter = isRunning, assign, nonatomic) BOOL running;
    //     [Export("running")]
    //     bool Running { [Bind("isRunning")] get; set; }

    //     // @property (getter = isSingleRun, assign, nonatomic) BOOL singleRun;
    //     [Export("singleRun")]
    //     bool SingleRun { [Bind("isSingleRun")] get; set; }

    //     [Wrap("WeakDelegate")]
    //     [NullAllowed]
    //     IALCoreControllerDelegate Delegate { get; set; }

    //     // @property (nonatomic, weak) id<ALCoreControllerDelegate> _Nullable delegate;
    //     [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
    //     NSObject WeakDelegate { get; set; }

    //     // -(instancetype _Nullable)initWithDelegate:(id<ALCoreControllerDelegate> _Nullable)delegate error:(NSError * _Nullable * _Nullable)error;
    //     [Export ("initWithDelegate:error:")]
    //     IntPtr Constructor ([NullAllowed] NSObject @delegate, [NullAllowed] out NSError error);

    //     // -(BOOL)loadScript:(NSString * _Nonnull)script bundlePath:(NSString * _Nonnull)bundlePath error:(NSError * _Nullable * _Nullable)error;
    //     [Export("loadScript:bundlePath:error:")]
    //     bool LoadScript(string script, string bundlePath, [NullAllowed] out NSError error);

    //     // -(BOOL)loadScript:(NSString * _Nonnull)script scriptName:(NSString * _Nonnull)scriptName bundlePath:(NSString * _Nonnull)bundlePath error:(NSError * _Nullable * _Nullable)error;
    //     [Export("loadScript:scriptName:bundlePath:error:")]
    //     bool LoadScript(string script, string scriptName, string bundlePath, [NullAllowed] out NSError error);

    //     // -(BOOL)loadCmdFile:(NSString * _Nonnull)cmdFileName bundlePath:(NSString * _Nonnull)bundlePath error:(NSError * _Nullable * _Nullable)error;
    //     [Export("loadCmdFile:bundlePath:error:")]
    //     bool LoadCmdFile(string cmdFileName, string bundlePath, [NullAllowed] out NSError error);

    //     // -(BOOL)startWithImageProvider:(id<ALImageProvider> _Nonnull)imageProvider error:(NSError * _Nullable * _Nullable)error;
    //     [Export("startWithImageProvider:error:")]
    //     bool StartWithImageProvider(IALImageProvider imageProvider, [NullAllowed] out NSError error);

    //     // -(BOOL)startWithImageProvider:(id<ALImageProvider> _Nonnull)imageProvider startVariables:(NSDictionary * _Nullable)variables error:(NSError * _Nullable * _Nullable)error;
    //     [Export("startWithImageProvider:startVariables:error:")]
    //     bool StartWithImageProvider(IALImageProvider imageProvider, [NullAllowed] NSDictionary variables, [NullAllowed] out NSError error);

    //     // -(BOOL)stopAndReturnError:(NSError * _Nullable * _Nullable)error;
    //     [Export("stopAndReturnError:")]
    //     bool StopAndReturnError([NullAllowed] out NSError error);

    //     // -(BOOL)processImage:(UIImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error;
    //     [Export("processImage:error:")]
    //     bool ProcessImage(UIImage image, [NullAllowed] out NSError error);

    //     // -(BOOL)processImage:(UIImage * _Nonnull)image startVariables:(NSDictionary * _Nullable)variables error:(NSError * _Nullable * _Nullable)error;
    //     [Export("processImage:startVariables:error:")]
    //     bool ProcessImage(UIImage image, [NullAllowed] NSDictionary variables, [NullAllowed] out NSError error);

    //     // -(BOOL)processALImage:(ALImage * _Nonnull)alImage error:(NSError * _Nullable * _Nullable)error;
    //     [Export("processALImage:error:")]
    //     bool ProcessALImage(ALImage alImage, [NullAllowed] out NSError error);

    //     // -(BOOL)processALImage:(ALImage * _Nonnull)alImage startVariables:(NSDictionary * _Nullable)variables error:(NSError * _Nullable * _Nullable)error;
    //     [Export("processALImage:startVariables:error:")]
    //     bool ProcessALImage(ALImage alImage, [NullAllowed] NSDictionary variables, [NullAllowed] out NSError error);

    //     // -(void)setParameter:(id _Nonnull)parameter forKey:(NSString * _Nonnull)key;
    //     [Export("setParameter:forKey:")]
    //     void SetParameter(NSObject parameter, string key);

    //     // +(NSString * _Nonnull)versionNumber;
    //     [Static]
    //     [Export("versionNumber")]

    //     string VersionNumber { get; }

    //     // +(NSString * _Nonnull)buildNumber;
    //     [Static]
    //     [Export("buildNumber")]

    //     string BuildNumber { get; }

    //     // +(NSString * _Nullable)licenseExpirationDateForLicense:(NSString * _Nonnull)licenseKey;
    //     [Static]
    //     [Export ("licenseExpirationDateForLicense:")]
    //     [return: NullAllowed]
    //     string LicenseExpirationDateForLicense (string licenseKey);

    //     // +(NSBundle * _Nonnull)frameworkBundle;
    //     [Static]
    //     [Export("frameworkBundle")]

    //     NSBundle FrameworkBundle { get; }

    //     // -(void)enableReporting:(BOOL)enable;
    //     [Export("enableReporting:")]
    //     void EnableReporting(bool enable);

    //     // -(void)reportIncludeValues:(NSString * _Nonnull)values;
    //     [Export("reportIncludeValues:")]
    //     void ReportIncludeValues(string values);

    //     // -(NSArray * _Nonnull)runStatistics;
    //     [Export("runStatistics")]
    //     NSObject[] RunStatistics { get; }
    // }

    // // @protocol ALCoreControllerDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface IALCoreControllerDelegate
    // {
    //     // @required -(void)anylineCoreController:(ALCoreController * _Nonnull)coreController didFinishWithOutput:(id _Nonnull)object;
    //     [Abstract]
    //     [Export("anylineCoreController:didFinishWithOutput:")]
    //     void DidFinishWithOutput(ALCoreController coreController, NSObject @object);

    //     // @optional -(void)anylineCoreController:(ALCoreController * _Nonnull)coreController didAbortRun:(NSError * _Nonnull)reason;
    //     [Export("anylineCoreController:didAbortRun:")]
    //     void DidAbortRun(ALCoreController coreController, NSError reason);

    //     // @optional -(void)anylineCoreController:(ALCoreController * _Nonnull)coreController reportsVariable:(NSString * _Nonnull)variableName value:(id _Nonnull)value;
    //     [Export("anylineCoreController:reportsVariable:value:")]
    //     void ReportsVariable(ALCoreController coreController, string variableName, NSObject value);

    //     // @optional -(void)anylineCoreController:(ALCoreController * _Nonnull)coreController parserError:(NSError * _Nonnull)error;
    //     [Export("anylineCoreController:parserError:")]
    //     void ParserError(ALCoreController coreController, NSError error);
    // }

    // // @interface ALTorchManager : NSObject <ALFlashButtonStatusDelegate>
    // [BaseType(typeof(NSObject))]
    // interface ALTorchManager : IALFlashButtonStatusDelegate
    // {
    //     // @property (nonatomic, weak) AVCaptureDevice * _Nullable captureDevice;
    //     [NullAllowed, Export("captureDevice", ArgumentSemantic.Weak)]
    //     AVCaptureDevice CaptureDevice { get; set; }

    //     // @property (assign, nonatomic) ALFlashStatus flashStatus;
    //     [Export("flashStatus", ArgumentSemantic.Assign)]
    //     ALFlashStatus FlashStatus { get; set; }

    //     // -(void)setLevelForAutoFlash:(int)brightness;
    //     [Export("setLevelForAutoFlash:")]
    //     void SetLevelForAutoFlash(int brightness);

    //     // -(void)setCountForAutoFlash:(int)brightnessCount;
    //     [Export("setCountForAutoFlash:")]
    //     void SetCountForAutoFlash(int brightnessCount);

    //     // -(void)resetLightLevelCounter;
    //     [Export("resetLightLevelCounter")]
    //     void ResetLightLevelCounter();

    //     // -(void)calculateBrightnessCount:(float)brightness;
    //     [Export("calculateBrightnessCount:")]
    //     void CalculateBrightnessCount(float brightness);

    //     // -(void)setTorch:(BOOL)onOff;
    //     [Export("setTorch:")]
    //     void SetTorch(bool onOff);

    //     // -(BOOL)torchAvailable;
    //     [Export("torchAvailable")]

    //     bool TorchAvailable { get; }

    //     // -(BOOL)setTorchModeOnWithLevel:(float)torchLevel error:(NSError * _Nullable * _Nullable)error;
    //     [Export("setTorchModeOnWithLevel:error:")]
    //     bool SetTorchModeOnWithLevel(float torchLevel, [NullAllowed] out NSError error);

    //     // -(instancetype _Nullable)initWithCaptureDevice:(AVCaptureDevice * _Nullable)captureDevice;
    //     [Export("initWithCaptureDevice:")]
    //     IntPtr Constructor([NullAllowed] AVCaptureDevice captureDevice);
    // }

    // // @protocol ALMotionDetectorDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface ALMotionDetectorDelegate
    // {
    //     // @required -(void)motionDetectorAboveThreshold;
    //     [Abstract]
    //     [Export("motionDetectorAboveThreshold")]
    //     void MotionDetectorAboveThreshold();
    // }

    // // @interface ALMotionDetector : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALMotionDetector
    // {
    //     [Wrap("WeakDelegate")]
    //     ALMotionDetectorDelegate Delegate { get; set; }

    //     // @property (assign, nonatomic) id<ALMotionDetectorDelegate> delegate;
    //     [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
    //     NSObject WeakDelegate { get; set; }

    //     // -(void)startListeningForMotion;
    //     [Export("startListeningForMotion")]
    //     void StartListeningForMotion();

    //     // -(void)stopListeningForMotion;
    //     [Export("stopListeningForMotion")]
    //     void StopListeningForMotion();

    //     // -(instancetype)initWithThreshold:(CGFloat)threshold delegate:(id)delegate;
    //     [Export("initWithThreshold:delegate:")]
    //     IntPtr Constructor(nfloat threshold, NSObject @delegate);
    // }

    // // audit-objc-generics: @interface ALScanResult<__covariant ObjectType> : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALScanResult
    // {
    //     // @property (readonly, nonatomic, strong) NSString * _Nonnull pluginID;
    //     [Export("pluginID", ArgumentSemantic.Strong)]
    //     string PluginID { get; }

    //     // @property (readonly, nonatomic, strong) ObjectType _Nonnull result;
    //     [Export("result", ArgumentSemantic.Strong)]
    //     NSObject Result { get; }

    //     // @property (readonly, nonatomic, strong) UIImage * _Nonnull image;
    //     [Export("image", ArgumentSemantic.Strong)]
    //     UIImage Image { get; }

    //     // @property (nonatomic, strong) UIImage * _Nullable fullImage;
    //     [NullAllowed, Export("fullImage", ArgumentSemantic.Strong)]
    //     UIImage FullImage { get; set; }

    //     // @property (readonly, assign, nonatomic) NSInteger confidence;
    //     [Export("confidence")]
    //     nint Confidence { get; }

    //     // @property (nonatomic, strong) ALSquare * _Nullable outline __attribute__((deprecated("Deprecated since 3.18.0 You can get the outline as a property from the ScanViewPlugin.")));
    //     [Obsolete("Deprecated since 3.18.0 You can get the outline as a property from the ScanViewPlugin.")]
    //     [NullAllowed, Export("outline", ArgumentSemantic.Strong)]
    //     ALSquare Outline { get; set; }

    //     // -(instancetype _Nullable)initWithResult:(ObjectType _Nonnull)result image:(UIImage * _Nonnull)image fullImage:(UIImage * _Nullable)fullImage confidence:(NSInteger)confidence pluginID:(NSString * _Nonnull)pluginID;
    //     [Export("initWithResult:image:fullImage:confidence:pluginID:")]
    //     IntPtr Constructor(NSObject result, UIImage image, [NullAllowed] UIImage fullImage, nint confidence, string pluginID);
    // }

    // [Static]
    // partial interface Constants
    // {
    //     // extern NSString *const _Nonnull kBrightnessVariableName;
    //     [Field("kBrightnessVariableName", "__Internal")]
    //     NSString kBrightnessVariableName { get; }

    //     // extern NSString *const _Nonnull kOutlineVariableName;
    //     [Field("kOutlineVariableName", "__Internal")]
    //     NSString kOutlineVariableName { get; }

    //     // extern NSString *const _Nonnull kDeviceAccelerationVariableName;
    //     [Field("kDeviceAccelerationVariableName", "__Internal")]
    //     NSString kDeviceAccelerationVariableName { get; }

    //     // extern NSString *const _Nonnull kThresholdedImageVariableName;
    //     [Field("kThresholdedImageVariableName", "__Internal")]
    //     NSString kThresholdedImageVariableName { get; }

    //     // extern NSString *const _Nonnull kContoursVariableName;
    //     [Field("kContoursVariableName", "__Internal")]
    //     NSString kContoursVariableName { get; }

    //     // extern NSString *const _Nonnull kSquareVariableName;
    //     [Field("kSquareVariableName", "__Internal")]
    //     NSString kSquareVariableName { get; }

    //     // extern NSString *const _Nonnull kPolygonVariableName;
    //     [Field("kPolygonVariableName", "__Internal")]
    //     NSString kPolygonVariableName { get; }

    //     // extern NSString *const _Nonnull kSharpnessVariableName;
    //     [Field("kSharpnessVariableName", "__Internal")]
    //     NSString kSharpnessVariableName { get; }

    //     // extern NSString *const _Nonnull kShakeDetectionWarningVariableName;
    //     [Field("kShakeDetectionWarningVariableName", "__Internal")]
    //     NSString kShakeDetectionWarningVariableName { get; }
    // }

    // // @interface ALScanInfo : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALScanInfo
    // {
    //     // @property (readonly, nonatomic, strong) NSString * _Nonnull pluginID;
    //     [Export("pluginID", ArgumentSemantic.Strong)]
    //     string PluginID { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nonnull variableName;
    //     [Export("variableName", ArgumentSemantic.Strong)]
    //     string VariableName { get; }

    //     // @property (readonly, nonatomic, strong) id _Nonnull value;
    //     [Export("value", ArgumentSemantic.Strong)]
    //     NSObject Value { get; }

    //     // -(instancetype _Nullable)initWithVariableName:(NSString * _Nonnull)variableName value:(id _Nonnull)value pluginID:(NSString * _Nonnull)pluginID;
    //     [Export("initWithVariableName:value:pluginID:")]
    //     IntPtr Constructor(string variableName, NSObject value, string pluginID);
    // }

    // // @interface ALRunSkippedReason : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALRunSkippedReason
    // {
    //     // @property (readonly, nonatomic, strong) NSString * _Nonnull pluginID;
    //     [Export("pluginID", ArgumentSemantic.Strong)]
    //     string PluginID { get; }

    //     // @property (assign, nonatomic) ALRunFailure reason;
    //     [Export("reason", ArgumentSemantic.Assign)]
    //     ALRunFailure Reason { get; set; }

    //     // -(instancetype _Nullable)initWithRunFailure:(ALRunFailure)reason pluginID:(NSString * _Nonnull)pluginID;
    //     [Export("initWithRunFailure:pluginID:")]
    //     IntPtr Constructor(ALRunFailure reason, string pluginID);
    // }

    // // @interface ALCaptureDeviceManager : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALCaptureDeviceManager
    // {
    //     // -(instancetype _Nullable)initWithCameraConfig:(ALCameraConfig * _Nonnull)cameraConfig;
    //     [Export("initWithCameraConfig:")]
    //     IntPtr Constructor(ALCameraConfig cameraConfig);

    //     // @property (readonly, nonatomic, strong) NSHashTable<AnylineNativeBarcodeDelegate> * _Nullable barcodeDelegates;
    //     [NullAllowed, Export("barcodeDelegates", ArgumentSemantic.Strong)]
    //     NSSet BarcodeDelegates { get; }

    //     // @property (readonly, nonatomic, strong) NSHashTable<AnylineVideoDataSampleBufferDelegate> * _Nullable sampleBufferDelegates;
    //     [NullAllowed, Export("sampleBufferDelegates", ArgumentSemantic.Strong)]
    //     NSSet SampleBufferDelegates { get; }

    //     // @property (nonatomic, strong) ALCameraConfig * _Nullable cameraConfig;
    //     [NullAllowed, Export("cameraConfig", ArgumentSemantic.Strong)]
    //     ALCameraConfig CameraConfig { get; set; }

    //     // @property (nonatomic, strong) AVCaptureVideoPreviewLayer * _Nullable previewLayer;
    //     [NullAllowed, Export("previewLayer", ArgumentSemantic.Strong)]
    //     AVCaptureVideoPreviewLayer PreviewLayer { get; set; }

    //     // @property (nonatomic, strong) AVCaptureDevice * _Nullable captureDevice;
    //     [NullAllowed, Export("captureDevice", ArgumentSemantic.Strong)]
    //     AVCaptureDevice CaptureDevice { get; set; }

    //     // @property (nonatomic, strong) AVCaptureSession * _Nullable session;
    //     [NullAllowed, Export("session", ArgumentSemantic.Strong)]
    //     AVCaptureSession Session { get; set; }

    //     // @property (assign, nonatomic) CGSize videoResolution;
    //     [Export("videoResolution", ArgumentSemantic.Assign)]
    //     CGSize VideoResolution { get; set; }

    //     // -(BOOL)addBarcodeDelegate:(id<AnylineNativeBarcodeDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
    //     [Export("addBarcodeDelegate:error:")]
    //     bool AddBarcodeDelegate(NSObject @delegate, [NullAllowed] out NSError error);

    //     // -(void)removeBarcodeDelegate:(id<AnylineNativeBarcodeDelegate> _Nonnull)delegate;
    //     [Export("removeBarcodeDelegate:")]
    //     void RemoveBarcodeDelegate(NSObject @delegate);

    //     // -(void)addSampleBufferDelegate:(id<AnylineVideoDataSampleBufferDelegate> _Nonnull)delegate;
    //     [Export("addSampleBufferDelegate:")]
    //     void AddSampleBufferDelegate(NSObject @delegate);

    //     // -(void)removeSampleBufferDelegate:(id<AnylineVideoDataSampleBufferDelegate> _Nonnull)delegate;
    //     [Export("removeSampleBufferDelegate:")]
    //     void RemoveSampleBufferDelegate(NSObject @delegate);

    //     // -(void)addVideoLayerOnView:(UIView * _Nonnull)view;
    //     [Export("addVideoLayerOnView:")]
    //     void AddVideoLayerOnView(UIView view);

    //     // -(void)updateVideoLayer:(UIView * _Nonnull)view;
    //     [Export("updateVideoLayer:")]
    //     void UpdateVideoLayer(UIView view);

    //     // -(void)setFocusAndExposurePoint:(CGPoint)point;
    //     [Export("setFocusAndExposurePoint:")]
    //     void SetFocusAndExposurePoint(CGPoint point);

    //     // -(void)setZoomLevel:(CGFloat)zoomFactor;
    //     [Export("setZoomLevel:")]
    //     void SetZoomLevel(nfloat zoomFactor);

    //     // -(void)startSession;
    //     [Export("startSession")]
    //     void StartSession();

    //     // -(void)stopSession;
    //     [Export("stopSession")]
    //     void StopSession();

    //     // -(BOOL)isRunning;
    //     [Export("isRunning")]

    //     bool IsRunning { get; }

    //     // -(CGPoint)fullResolutionPointForPointInPreview:(CGPoint)inPoint;
    //     [Export("fullResolutionPointForPointInPreview:")]
    //     CGPoint FullResolutionPointForPointInPreview(CGPoint inPoint);

    //     // -(UIInterfaceOrientation)currentInterfaceOrientation;
    //     [Export("currentInterfaceOrientation")]

    //     UIInterfaceOrientation CurrentInterfaceOrientation { get; }

    //     // -(AVCaptureConnection * _Nullable)getOrientationAdaptedCaptureConnection;
    //     [NullAllowed, Export("getOrientationAdaptedCaptureConnection")]

    //     AVCaptureConnection OrientationAdaptedCaptureConnection { get; }

    //     // +(AVAuthorizationStatus)cameraPermissionStatus;
    //     [Static]
    //     [Export("cameraPermissionStatus")]

    //     AVAuthorizationStatus CameraPermissionStatus { get; }

    //     // +(void)requestCameraPermission:(void (^ _Nonnull)(BOOL))handler;
    //     [Static]
    //     [Export("requestCameraPermission:")]
    //     void RequestCameraPermission(Action<bool> handler);

    //     // -(void)captureStillImageAsynchronouslyWithCompletionHandler:(void (^ _Nonnull)(CMSampleBufferRef _Nullable, NSError * _Nullable))handler;
    //     //[Export("captureStillImageAsynchronouslyWithCompletionHandler:")]
    //     //unsafe void CaptureStillImageAsynchronouslyWithCompletionHandler(Action<CoreMedia.CMSampleBufferRef*, NSError> handler);
    // }

    // // @protocol AnylineVideoDataSampleBufferDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface IAnylineVideoDataSampleBufferDelegate
    // {
    //     // @required -(void)anylineCaptureDeviceManager:(ALCaptureDeviceManager * _Nonnull)captureDeviceManager didOutputSampleBuffer:(CMSampleBufferRef _Nonnull)sampleBuffer;
    //     //[Abstract]
    //     //[Export("anylineCaptureDeviceManager:didOutputSampleBuffer:")]
    //     //unsafe void DidOutputSampleBuffer(ALCaptureDeviceManager captureDeviceManager, CMSampleBufferRef* sampleBuffer);
    // }

    // // @protocol AnylineNativeBarcodeDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface AnylineNativeBarcodeDelegate
    // {
    //     // @required -(void)anylineCaptureDeviceManager:(ALCaptureDeviceManager * _Nonnull)captureDeviceManager didFindBarcodeResult:(NSString * _Nonnull)scanResult type:(NSString * _Nonnull)barcodeType;
    //     [Abstract]
    //     [Export("anylineCaptureDeviceManager:didFindBarcodeResult:type:")]
    //     void DidFindBarcodeResult(ALCaptureDeviceManager captureDeviceManager, string scanResult, string barcodeType);
    // }

    // // @interface ALAbstractScanPlugin : NSObject <ALCoreControllerDelegate>
    // [BaseType(typeof(NSObject))]
    // interface ALAbstractScanPlugin : IALCoreControllerDelegate
    // {
    //     // @property (readonly, nonatomic, strong) NSHashTable<ALInfoDelegate> * _Nullable infoDelegates;
    //     [NullAllowed, Export("infoDelegates", ArgumentSemantic.Strong)]
    //     NSSet InfoDelegates { get; }

    //     // @property (nonatomic, strong) NSString * _Nullable pluginID;
    //     [NullAllowed, Export("pluginID", ArgumentSemantic.Strong)]
    //     string PluginID { get; set; }

    //     // @property (assign, nonatomic) id<ALImageProvider> _Nullable imageProvider;
    //     [NullAllowed, Export("imageProvider", ArgumentSemantic.Assign)]
    //     IALImageProvider ImageProvider { get; set; }

    //     // -(BOOL)start:(id<ALImageProvider> _Nonnull)imageProvider error:(NSError * _Nullable * _Nullable)error;
    //     [Export("start:error:")]
    //     bool Start(NSObject imageProvider, [NullAllowed] out NSError error);

    //     // -(BOOL)stopAndReturnError:(NSError * _Nullable * _Nullable)error;
    //     [Export("stopAndReturnError:")]
    //     bool StopAndReturnError([NullAllowed] out NSError error);

    //     // -(void)enableReporting:(BOOL)enable;
    //     [Export("enableReporting:")]
    //     void EnableReporting(bool enable);

    //     // -(BOOL)isRunning;
    //     [Export("isRunning")]
    //     bool IsRunning { get; }

    //     // -(void)addInfoDelegate:(id<ALInfoDelegate> _Nonnull)infoDelegate;
    //     [Export("addInfoDelegate:")]
    //     void AddInfoDelegate(IALInfoDelegate infoDelegate);

    //     // -(void)removeInfoDelegate:(id<ALInfoDelegate> _Nonnull)infoDelegate;
    //     [Export("removeInfoDelegate:")]
    //     void RemoveInfoDelegate(IALInfoDelegate infoDelegate);

    //     // @property (nonatomic) int delayStartScanTime;
    //     [Export("delayStartScanTime")]
    //     int DelayStartScanTime { get; set; }

    //     // -(BOOL)delayedScanTimeFulfilled;
    //     [Export("delayedScanTimeFulfilled")]
    //     bool DelayedScanTimeFulfilled { get; }

    //     // -(void)setCurrentScanStartTime;
    //     [Export("setCurrentScanStartTime")]
    //     void SetCurrentScanStartTime();

    //     // @property (assign, nonatomic) NSInteger confidence;
    //     [Export("confidence")]
    //     nint Confidence { get; set; }

    //     // @property (readonly, nonatomic, strong) ALImage * _Nullable scanImage;
    //     [NullAllowed, Export("scanImage", ArgumentSemantic.Strong)]
    //     ALImage ScanImage { get; }

    //     // @property (nonatomic, strong) ALCoreController * _Nullable coreController;
    //     [NullAllowed, Export("coreController", ArgumentSemantic.Strong)]
    //     ALCoreController CoreController { get; set; }
    // }

    // // @protocol ALInfoDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface IALInfoDelegate
    // {
    //     // @optional -(void)anylineScanPlugin:(ALAbstractScanPlugin * _Nonnull)anylineScanPlugin reportInfo:(ALScanInfo * _Nonnull)info;
    //     [Export("anylineScanPlugin:reportInfo:")]
    //     void ReportInfo(ALAbstractScanPlugin anylineScanPlugin, ALScanInfo info);

    //     // @optional -(void)anylineScanPlugin:(ALAbstractScanPlugin * _Nonnull)anylineScanPlugin runSkipped:(ALRunSkippedReason * _Nonnull)runSkippedReason;
    //     [Export("anylineScanPlugin:runSkipped:")]
    //     void RunSkipped(ALAbstractScanPlugin anylineScanPlugin, ALRunSkippedReason runSkippedReason);
    // }

    // // @interface ALSampleBufferImageProvider : NSObject <ALImageProvider, AnylineVideoDataSampleBufferDelegate>
    // [BaseType(typeof(NSObject))]
    // interface ALSampleBufferImageProvider : IALImageProvider, IAnylineVideoDataSampleBufferDelegate
    // {
    //     // @property (assign, atomic) CGRect cutoutFrame;
    //     [Export("cutoutFrame", ArgumentSemantic.Assign)]
    //     CGRect CutoutFrame { get; set; }

    //     // @property (assign, nonatomic) CGSize cameraFrame;
    //     [Export("cameraFrame", ArgumentSemantic.Assign)]
    //     CGSize CameraFrame { get; set; }

    //     // @property (assign, nonatomic) CGRect cutoutScreen;
    //     [Export("cutoutScreen", ArgumentSemantic.Assign)]
    //     CGRect CutoutScreen { get; set; }

    //     // @property (assign, nonatomic) CGSize cutoutPadding;
    //     [Export("cutoutPadding", ArgumentSemantic.Assign)]
    //     CGSize CutoutPadding { get; set; }

    //     // @property (assign, nonatomic) CGPoint cutoutOffset;
    //     [Export("cutoutOffset", ArgumentSemantic.Assign)]
    //     CGPoint CutoutOffset { get; set; }

    //     // -(instancetype _Nullable)initWithCutoutScreen:(CGRect)cutoutScreen cutoutPadding:(CGSize)cutoutPadding cutoutOffset:(CGPoint)cutoutOffset;
    //     [Export("initWithCutoutScreen:cutoutPadding:cutoutOffset:")]
    //     IntPtr Constructor(CGRect cutoutScreen, CGSize cutoutPadding, CGPoint cutoutOffset);

    //     // -(CGPoint)convertPoint:(CGPoint)inPoint previewLayer:(AVCaptureVideoPreviewLayer * _Nonnull)previewLayer;
    //     [Export("convertPoint:previewLayer:")]
    //     CGPoint ConvertPoint(CGPoint inPoint, AVCaptureVideoPreviewLayer previewLayer);

    //     // -(CGPoint)convertPoint:(CGPoint)inPoint previewLayer:(AVCaptureVideoPreviewLayer * _Nonnull)previewLayer imageWidth:(CGFloat)inWidth;
    //     [Export("convertPoint:previewLayer:imageWidth:")]
    //     CGPoint ConvertPoint(CGPoint inPoint, AVCaptureVideoPreviewLayer previewLayer, nfloat inWidth);

    //     // -(void)updateCutoutScreen:(CGRect)rect;
    //     [Export("updateCutoutScreen:")]
    //     void UpdateCutoutScreen(CGRect rect);
    // }

    // // @interface ALAbstractScanViewPlugin : UIView <ALInfoDelegate>
    // [BaseType(typeof(UIView))]
    // interface ALAbstractScanViewPlugin : IALInfoDelegate, INativeObject
    // {
    //     // @property (nonatomic, strong) ALSampleBufferImageProvider * _Nullable sampleBufferImageProvider;
    //     [NullAllowed, Export("sampleBufferImageProvider", ArgumentSemantic.Strong)]
    //     ALSampleBufferImageProvider SampleBufferImageProvider { get; set; }

    //     // @property (nonatomic, weak) ALScanView * _Nullable scanView;
    //     [NullAllowed, Export("scanView", ArgumentSemantic.Weak)]
    //     ALScanView ScanView { get; set; }

    //     // @property (assign, nonatomic) CGRect cutoutRect;
    //     [Export("cutoutRect", ArgumentSemantic.Assign)]
    //     CGRect CutoutRect { get; set; }

    //     // @property (copy, nonatomic) ALScanViewPluginConfig * _Nullable scanViewPluginConfig;
    //     [NullAllowed, Export("scanViewPluginConfig", ArgumentSemantic.Copy)]
    //     ALScanViewPluginConfig ScanViewPluginConfig { get; set; }

    //     // +(instancetype _Nullable)scanViewPluginForConfigDict:(NSDictionary * _Nonnull)configDict delegate:(id _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
    //     [Static]
    //     [Export ("scanViewPluginForConfigDict:delegate:error:")]
    //     [return: NullAllowed]
    //     ALAbstractScanViewPlugin ScanViewPluginForConfigDict (NSDictionary configDict, NSObject @delegate, [NullAllowed] out NSError error);

    //     // -(BOOL)startAndReturnError:(NSError * _Nullable * _Nullable)error;
    //     [Export("startAndReturnError:")]
    //     bool StartAndReturnError([NullAllowed] out NSError error);

    //     // -(BOOL)stopAndReturnError:(NSError * _Nullable * _Nullable)error;
    //     [Export("stopAndReturnError:")]
    //     bool StopAndReturnError([NullAllowed] out NSError error);

    //     // @property (nonatomic, strong) ALSquare * _Nullable outline;
    //     [NullAllowed, Export("outline", ArgumentSemantic.Strong)]
    //     ALSquare Outline { get; set; }

    //     // @property (nonatomic, strong) ALImage * _Nullable scanImage;
    //     [NullAllowed, Export("scanImage", ArgumentSemantic.Strong)]
    //     ALImage ScanImage { get; set; }

    //     // @property (assign, nonatomic) CGFloat scale;
    //     [Export("scale")]
    //     nfloat Scale { get; set; }

    //     // -(void)customInit;
    //     [Export("customInit")]
    //     void CustomInit();

    //     // -(void)stopListeningForMotion;
    //     [Export("stopListeningForMotion")]
    //     void StopListeningForMotion();

    //     // -(void)triggerScannedFeedback;
    //     [Export("triggerScannedFeedback")]
    //     void TriggerScannedFeedback();

    //     // -(NSArray * _Nonnull)convertContours:(ALContours * _Nonnull)contoursValue;
    //     [Export("convertContours:")]

    //     NSObject[] ConvertContours(ALContours contoursValue);

    //     // -(ALSquare * _Nonnull)convertCGRect:(NSValue * _Nonnull)concreteValue;
    //     [Export("convertCGRect:")]
    //     ALSquare ConvertCGRect(NSValue concreteValue);

    //     // -(void)updateCutoutRect:(CGRect)rect;
    //     [Export("updateCutoutRect:")]
    //     void UpdateCutoutRect(CGRect rect);

    //     // -(void)addScanViewPluginDelegate:(id<ALScanViewPluginDelegate> _Nonnull)scanViewPluginDelegate;
    //     [Export("addScanViewPluginDelegate:")]
    //     void AddScanViewPluginDelegate(ALScanViewPluginDelegate scanViewPluginDelegate);

    //     // -(void)removeScanViewPluginDelegate:(id<ALScanViewPluginDelegate> _Nonnull)scanViewPluginDelegate;
    //     [Export("removeScanViewPluginDelegate:")]
    //     void RemoveScanViewPluginDelegate(ALScanViewPluginDelegate scanViewPluginDelegate);
    // }

    // // @protocol ALScanViewPluginDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface ALScanViewPluginDelegate
    // {
    //     // @optional -(void)anylineScanViewPlugin:(ALAbstractScanViewPlugin * _Nonnull)anylineScanViewPlugin updatedCutout:(CGRect)cutoutRect;
    //     [Export("anylineScanViewPlugin:updatedCutout:")]
    //     void UpdatedCutout(ALAbstractScanViewPlugin anylineScanViewPlugin, CGRect cutoutRect);
    // }

    // // @interface ALPolygon : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALPolygon
    // {
    //     // @property (readonly, nonatomic, strong) NSArray * points;
    //     [Export("points", ArgumentSemantic.Strong)]

    //     NSObject[] Points { get; }

    //     // -(instancetype)initWithPoints:(NSArray *)points;
    //     [Export("initWithPoints:")]

    //     IntPtr Constructor(NSObject[] points);

    //     // -(ALPolygon *)polygonWithScale:(CGFloat)scale;
    //     [Export("polygonWithScale:")]
    //     ALPolygon PolygonWithScale(nfloat scale);
    // }

    // // @interface ALUIFeedback : UIView
    // [BaseType(typeof(UIView))]
    // interface ALUIFeedback
    // {
    //     // @property (nonatomic, strong) ALSquare * _Nonnull square;
    //     [Export("square", ArgumentSemantic.Strong)]
    //     ALSquare Square { get; set; }

    //     // @property (nonatomic, strong) ALPolygon * _Nonnull polygon;
    //     [Export("polygon", ArgumentSemantic.Strong)]
    //     ALPolygon Polygon { get; set; }

    //     // @property (nonatomic, strong) NSArray * _Nonnull contours;
    //     [Export("contours", ArgumentSemantic.Strong)]

    //     NSObject[] Contours { get; set; }

    //     // @property (readonly, nonatomic, strong) NSHashTable<ALCutoutDelegate> * _Nullable cutoutDelegates;
    //     [NullAllowed, Export("cutoutDelegates", ArgumentSemantic.Strong)]
    //     NSSet CutoutDelegates { get; }

    //     // -(instancetype _Nullable)initWithFrame:(CGRect)frame pluginConfig:(ALScanViewPluginConfig * _Nonnull)pluginConfig;
    //     [Export("initWithFrame:pluginConfig:")]
    //     IntPtr Constructor(CGRect frame, ALScanViewPluginConfig pluginConfig);

    //     // -(void)cancelFeedback;
    //     [Export("cancelFeedback")]
    //     void CancelFeedback();

    //     // -(void)changeVisualFeedbackStrokeColor:(UIColor * _Nonnull)color;
    //     [Export("changeVisualFeedbackStrokeColor:")]
    //     void ChangeVisualFeedbackStrokeColor(UIColor color);

    //     // -(void)updateConfiguration:(ALScanViewPluginConfig * _Nonnull)pluginConfig;
    //     [Export("updateConfiguration:")]
    //     void UpdateConfiguration(ALScanViewPluginConfig pluginConfig);

    //     // -(void)setVisualFeedbackStrokeColor:(UIColor * _Nonnull)color;
    //     [Export("setVisualFeedbackStrokeColor:")]
    //     void SetVisualFeedbackStrokeColor(UIColor color);

    //     // -(CGRect)cutout;
    //     [Export("cutout")]

    //     CGRect Cutout { get; }

    //     // -(void)addCutoutDelegate:(id<ALCutoutDelegate> _Nonnull)infoDelegate;
    //     [Export("addCutoutDelegate:")]
    //     void AddCutoutDelegate(ALCutoutDelegate infoDelegate);

    //     // -(void)removeCutoutDelegate:(id<ALCutoutDelegate> _Nonnull)infoDelegate;
    //     [Export("removeCutoutDelegate:")]
    //     void RemoveCutoutDelegate(ALCutoutDelegate infoDelegate);
    // }

    // // @protocol ALCutoutDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface ALCutoutDelegate
    // {
    //     // @required -(void)alUIFeedback:(ALUIFeedback * _Nonnull)alUIFeedback updatedCutout:(CGRect)cutoutRect;
    //     [Abstract]
    //     [Export("alUIFeedback:updatedCutout:")]
    //     void UpdatedCutout(ALUIFeedback alUIFeedback, CGRect cutoutRect);
    // }

    // // @interface ALScanView : UIView
    // [BaseType(typeof(UIView))]
    // interface ALScanView
    // {
    //     // @property (nonatomic, strong) ALUIFeedback * _Nullable uiOverlayView;
    //     [NullAllowed, Export("uiOverlayView", ArgumentSemantic.Strong)]
    //     ALUIFeedback UiOverlayView { get; set; }

    //     // @property (nonatomic, strong) ALCameraConfig * _Nullable cameraConfig;
    //     [NullAllowed, Export("cameraConfig", ArgumentSemantic.Strong)]
    //     ALCameraConfig CameraConfig { get; set; }

    //     // @property (nonatomic, strong) ALFlashButtonConfig * _Nullable flashButtonConfig;
    //     [NullAllowed, Export("flashButtonConfig", ArgumentSemantic.Strong)]
    //     ALFlashButtonConfig FlashButtonConfig { get; set; }

    //     // @property (nonatomic, strong) ALFlashButton * _Nullable flashButton;
    //     [NullAllowed, Export("flashButton", ArgumentSemantic.Strong)]
    //     ALFlashButton FlashButton { get; set; }

    //     // @property (nonatomic, strong) ALTorchManager * _Nullable torchManager;
    //     [NullAllowed, Export("torchManager", ArgumentSemantic.Strong)]
    //     ALTorchManager TorchManager { get; set; }

    //     // @property (nonatomic, strong) ALCaptureDeviceManager * _Nullable captureDeviceManager;
    //     [NullAllowed, Export("captureDeviceManager", ArgumentSemantic.Strong)]
    //     ALCaptureDeviceManager CaptureDeviceManager { get; set; }

    //     // setter private because not supported natively yet.

    //     // @property (nonatomic, strong) ALAbstractScanViewPlugin * _Nullable scanViewPlugin;
    //     [NullAllowed, Export("scanViewPlugin", ArgumentSemantic.Strong)]
    //     ALAbstractScanViewPlugin ScanViewPlugin { get; }

    //     // @property (readonly, nonatomic) CGRect watermarkRect;
    //     [Export("watermarkRect")]
    //     CGRect WatermarkRect { get; }

    //     // -(instancetype _Nullable)initWithFrame:(CGRect)frame scanViewPlugin:(ALAbstractScanViewPlugin * _Nullable)scanViewPlugin;
    //     [Export("initWithFrame:scanViewPlugin:")]
    //     IntPtr Constructor(CGRect frame, [NullAllowed] ALAbstractScanViewPlugin scanViewPlugin);

    //     // -(instancetype _Nullable)initWithFrame:(CGRect)frame scanViewPlugin:(ALAbstractScanViewPlugin * _Nullable)scanViewPlugin cameraConfig:(ALCameraConfig * _Nonnull)cameraConfig flashButtonConfig:(ALFlashButtonConfig * _Nonnull)flashButtonConfig;
    //     [Export("initWithFrame:scanViewPlugin:cameraConfig:flashButtonConfig:")]
    //     IntPtr Constructor(CGRect frame, [NullAllowed] ALAbstractScanViewPlugin scanViewPlugin, ALCameraConfig cameraConfig, ALFlashButtonConfig flashButtonConfig);

    //     // +(instancetype _Nullable)scanViewForFrame:(CGRect)frame configPath:(NSString * _Nonnull)configPath delegate:(id _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
    //     [Static]
    //     [Export ("scanViewForFrame:configPath:delegate:error:")]
    //     [return: NullAllowed]
    //     ALScanView ScanViewForFrame (CGRect frame, string configPath, NSObject @delegate, [NullAllowed] out NSError error);

    //     // +(instancetype _Nullable)scanViewForFrame:(CGRect)frame configDict:(NSDictionary * _Nonnull)configDict delegate:(id _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
    //     [Static]
    //     [Export ("scanViewForFrame:configDict:delegate:error:")]
    //     [return: NullAllowed]
    //     ALScanView ScanViewForFrame (CGRect frame, NSDictionary configDict, NSObject @delegate, [NullAllowed] out NSError error);

    //     // -(void)startCamera;
    //     [Export("startCamera")]
    //     void StartCamera();

    //     // -(void)stopCamera;
    //     [Export("stopCamera")]
    //     void StopCamera();

    //     // -(void)updateTextRect:(ALSquare * _Nonnull)square;
    //     [Export("updateTextRect:")]
    //     void UpdateTextRect(ALSquare square);

    //     // -(void)updateCutoutView:(ALCutoutConfig * _Nonnull)cutoutConfig;
    //     [Export("updateCutoutView:")]
    //     void UpdateCutoutView(ALCutoutConfig cutoutConfig);

    //     // -(void)updateVisualFeedbackView:(ALScanFeedbackConfig * _Nonnull)scanFeedbackConfig;
    //     [Export("updateVisualFeedbackView:")]
    //     void UpdateVisualFeedbackView(ALScanFeedbackConfig scanFeedbackConfig);

    //     // -(void)updateWebView:(ALScanViewPluginConfig * _Nonnull)config;
    //     [Export("updateWebView:")]
    //     void UpdateWebView(ALScanViewPluginConfig config);

    //     // -(void)enableZoomPinchGesture:(BOOL)enabled;
    //     [Export("enableZoomPinchGesture:")]
    //     void EnableZoomPinchGesture(bool enabled);
    // }

    // // @interface ALMeterResult : ALScanResult
    // [BaseType(typeof(ALScanResult))]
    // interface ALMeterResult
    // {
    //     // @property (readonly, assign, nonatomic) ALScanMode scanMode;
    //     [Export("scanMode", ArgumentSemantic.Assign)]
    //     ALScanMode ScanMode { get; }

    //     // -(instancetype _Nullable)initWithResult:(NSString * _Nonnull)result image:(UIImage * _Nonnull)image fullImage:(UIImage * _Nonnull)fullImage confidence:(NSInteger)confidence pluginID:(NSString * _Nonnull)pluginID scanMode:(ALScanMode)scanMode;
    //     [Export("initWithResult:image:fullImage:confidence:pluginID:scanMode:")]
    //     IntPtr Constructor(string result, UIImage image, UIImage fullImage, nint confidence, string pluginID, ALScanMode scanMode);
    // }

    // // @interface ALEnergyResult : ALMeterResult
    // [BaseType(typeof(ALMeterResult))]
    // interface ALEnergyResult
    // {
    // }

    // // @interface ALMeterScanPlugin : ALAbstractScanPlugin
    // [BaseType(typeof(ALAbstractScanPlugin))]
    // [DisableDefaultCtor]
    // interface ALMeterScanPlugin
    // {
    //     // -(instancetype _Nullable)initWithPluginID:(NSString * _Nullable)pluginID delegate:(id<ALMeterScanPluginDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
    //     [Export ("initWithPluginID:delegate:error:")]
    //     IntPtr Constructor ([NullAllowed] string pluginID, NSObject @delegate, [NullAllowed] out NSError error);

    //     // @property (readonly, nonatomic, strong) NSHashTable<ALMeterScanPluginDelegate> * _Nullable delegates;
    //     [NullAllowed, Export("delegates", ArgumentSemantic.Strong)]
    //     NSSet Delegates { get; }

    //     // @property (readonly, assign, nonatomic) ALScanMode scanMode;
    //     [Export("scanMode", ArgumentSemantic.Assign)]
    //     ALScanMode ScanMode { get; }

    //     // @property (nonatomic, strong) NSString * _Nullable serialNumberValidationRegex;
    //     [NullAllowed, Export("serialNumberValidationRegex", ArgumentSemantic.Strong)]
    //     string SerialNumberValidationRegex { get; set; }

    //     // @property (nonatomic, strong) NSString * _Nullable serialNumberCharWhitelist;
    //     [NullAllowed, Export("serialNumberCharWhitelist", ArgumentSemantic.Strong)]
    //     string SerialNumberCharWhitelist { get; set; }

    //     // -(BOOL)setScanMode:(ALScanMode)scanMode error:(NSError * _Nullable * _Nullable)error;
    //     [Export("setScanMode:error:")]
    //     bool SetScanMode(ALScanMode scanMode, [NullAllowed] out NSError error);

    //     // -(void)addDelegate:(id<ALMeterScanPluginDelegate> _Nonnull)delegate;
    //     [Export("addDelegate:")]
    //     void AddDelegate(NSObject @delegate);

    //     // -(void)removeDelegate:(id<ALMeterScanPluginDelegate> _Nonnull)delegate;
    //     [Export("removeDelegate:")]
    //     void RemoveDelegate(NSObject @delegate);

    //     // -(ALScanMode)parseScanModeString:(NSString * _Nonnull)scanMode;
    //     [Export("parseScanModeString:")]
    //     ALScanMode ParseScanModeString(string scanMode);
    // }

    // // @protocol ALMeterScanPluginDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface ALMeterScanPluginDelegate
    // {
    //     // @required -(void)anylineMeterScanPlugin:(ALMeterScanPlugin * _Nonnull)anylineMeterScanPlugin didFindResult:(ALMeterResult * _Nonnull)scanResult;
    //     [Abstract]
    //     [Export("anylineMeterScanPlugin:didFindResult:")]
    //     void DidFindResult(ALMeterScanPlugin anylineMeterScanPlugin, ALMeterResult scanResult);
    // }

    // partial interface Constants
    // {
    //     // extern NSString *const _Nonnull kCodeTypeAztec;
    //     [Field("kCodeTypeAztec", "__Internal")]
    //     NSString kCodeTypeAztec { get; }

    //     // extern NSString *const _Nonnull kCodeTypeCodabar;
    //     [Field("kCodeTypeCodabar", "__Internal")]
    //     NSString kCodeTypeCodabar { get; }

    //     // extern NSString *const _Nonnull kCodeTypeCode39;
    //     [Field("kCodeTypeCode39", "__Internal")]
    //     NSString kCodeTypeCode39 { get; }

    //     // extern NSString *const _Nonnull kCodeTypeCode93;
    //     [Field("kCodeTypeCode93", "__Internal")]
    //     NSString kCodeTypeCode93 { get; }

    //     // extern NSString *const _Nonnull kCodeTypeCode128;
    //     [Field("kCodeTypeCode128", "__Internal")]
    //     NSString kCodeTypeCode128 { get; }

    //     // extern NSString *const _Nonnull kCodeTypeDataMatrix;
    //     [Field("kCodeTypeDataMatrix", "__Internal")]
    //     NSString kCodeTypeDataMatrix { get; }

    //     // extern NSString *const _Nonnull kCodeTypeEAN8;
    //     [Field("kCodeTypeEAN8", "__Internal")]
    //     NSString kCodeTypeEAN8 { get; }

    //     // extern NSString *const _Nonnull kCodeTypeEAN13;
    //     [Field("kCodeTypeEAN13", "__Internal")]
    //     NSString kCodeTypeEAN13 { get; }

    //     // extern NSString *const _Nonnull kCodeTypeITF;
    //     [Field("kCodeTypeITF", "__Internal")]
    //     NSString kCodeTypeITF { get; }

    //     // extern NSString *const _Nonnull kCodeTypePDF417;
    //     [Field("kCodeTypePDF417", "__Internal")]
    //     NSString kCodeTypePDF417 { get; }

    //     // extern NSString *const _Nonnull kCodeTypeQR;
    //     [Field("kCodeTypeQR", "__Internal")]
    //     NSString kCodeTypeQR { get; }

    //     // extern NSString *const _Nonnull kCodeTypeRSS14;
    //     [Field("kCodeTypeRSS14", "__Internal")]
    //     NSString kCodeTypeRSS14 { get; }

    //     // extern NSString *const _Nonnull kCodeTypeRSSExpanded;
    //     [Field("kCodeTypeRSSExpanded", "__Internal")]
    //     NSString kCodeTypeRSSExpanded { get; }

    //     // extern NSString *const _Nonnull kCodeTypeUPCA;
    //     [Field("kCodeTypeUPCA", "__Internal")]
    //     NSString kCodeTypeUPCA { get; }

    //     // extern NSString *const _Nonnull kCodeTypeUPCE;
    //     [Field("kCodeTypeUPCE", "__Internal")]
    //     NSString kCodeTypeUPCE { get; }

    //     // extern NSString *const _Nonnull kCodeTypeUPCEANExtension;
    //     [Field("kCodeTypeUPCEANExtension", "__Internal")]
    //     NSString kCodeTypeUPCEANExtension { get; }
    // }

    // // @interface ALBarcodeResult : ALScanResult
    // [BaseType(typeof(ALScanResult))]
    // interface ALBarcodeResult
    // {
    //     // -(instancetype _Nullable)initWithResult:(NSArray<ALBarcode *> * _Nonnull)result image:(UIImage * _Nullable)image fullImage:(UIImage * _Nullable)fullImage confidence:(NSInteger)confidence pluginID:(NSString * _Nonnull)pluginID;
    //     [Export("initWithResult:image:fullImage:confidence:pluginID:")]
    //     IntPtr Constructor(ALBarcode[] result, [NullAllowed] UIImage image, [NullAllowed] UIImage fullImage, nint confidence, string pluginID);
        
    //     // @property (nonatomic, strong) NSArray<ALBarcode *> * _Nonnull barcodes;
    //     [Export ("barcodes", ArgumentSemantic.Strong)]
    //     ALBarcode[] Barcodes { get; set; }

    //     // @property (nonatomic, strong) NSArray<ALBarcode *> * _Nonnull result;
    //     [Export ("result", ArgumentSemantic.Strong)]
    //     ALBarcode[] Result { get; set; }
    // }

    // // @interface ALBarcode : NSObject
    // [BaseType (typeof(NSObject))]
    // interface ALBarcode
    // {
    //     // @property (readonly, nonatomic, strong) NSString * _Nonnull barcodeFormat;
    //     [Export ("barcodeFormat", ArgumentSemantic.Strong)]
    //     string BarcodeFormat { get; }

    //     // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
    //     [Export ("value")]
    //     string Value { get; }

    //     // @property (readonly, copy, nonatomic) NSString * _Nonnull base64;
    //     [Export ("base64")]
    //     string Base64 { get; }

    //     // @property (readonly, copy, nonatomic) ALSquare * _Nullable coordinates;
    //     [NullAllowed, Export ("coordinates", ArgumentSemantic.Copy)]
    //     ALSquare Coordinates { get; }

    //     // @property (readonly, copy, nonatomic) NSDictionary * _Nonnull parsedPDF417;
    //     [Export ("parsedPDF417", ArgumentSemantic.Copy)]
    //     NSDictionary ParsedPDF417 { get; }

    //     // -(instancetype _Nonnull)initWithValue:(NSString * _Nonnull)value format:(NSString * _Nonnull)barcodeFormat;
    //     [Export ("initWithValue:format:")]
    //     IntPtr Constructor (string value, string barcodeFormat);

    //     // -(instancetype _Nonnull)initWithValue:(NSString * _Nonnull)value format:(NSString * _Nonnull)barcodeFormat coordinates:(NSString * _Nullable)coordinates base64:(NSString * _Nullable)base64 parsedPDF417:(NSString * _Nullable)parsedPDF417;
    //     [Export ("initWithValue:format:coordinates:base64:parsedPDF417:")]
    //     IntPtr Constructor (string value, string barcodeFormat, [NullAllowed] string coordinates, [NullAllowed] string base64, [NullAllowed] string parsedPDF417);

    //     /*
    //     // -(NSString * _Nonnull)toJSONString;
    //     [Export ("toJSONString")]
    //     string ToJSONString { get; }
        
    //     // +(NSArray<NSString *> * _Nullable)allBarcodeFormats;
    //     [Static]
    //     [NullAllowed, Export ("allBarcodeFormats")]
    //     NSObject AllBarcodeFormats { get; }

    //     // +(NSArray<NSString *> * _Nullable)basicBarcodeFormats;
    //     [Static]
    //     [NullAllowed, Export ("basicBarcodeFormats")]
    //     NSObject BasicBarcodeFormats { get; }

    //     // +(NSArray<NSString *> * _Nullable)advancedBarcodeFormats;
    //     [Static]
    //     [NullAllowed, Export ("advancedBarcodeFormats")]
    //     NSObject AdvancedBarcodeFormats { get; }
    //     */
    // }

    // // @interface ALBarcodeScanPlugin : ALAbstractScanPlugin
    // [BaseType(typeof(ALAbstractScanPlugin))]
    // [DisableDefaultCtor]
    // interface ALBarcodeScanPlugin
    // {
    //     // -(instancetype _Nullable)initWithPluginID:(NSString * _Nullable)pluginID delegate:(id<ALBarcodeScanPluginDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
    //     [Export ("initWithPluginID:delegate:error:")]
	//     IntPtr Constructor ([NullAllowed] string pluginID, NSObject @delegate, [NullAllowed] out NSError error);

    //     // @property (readonly, nonatomic, strong) NSHashTable<ALBarcodeScanPluginDelegate> * _Nullable delegates;
    //     [NullAllowed, Export ("delegates", ArgumentSemantic.Strong)]
    //     ALBarcodeScanPluginDelegate Delegates { get; }

    //     // @property (nonatomic, strong) NSArray<NSString *> * _Nonnull barcodeFormatOptions;
    //     [Export ("barcodeFormatOptions", ArgumentSemantic.Strong)]
    //     string[] BarcodeFormatOptions { get; set; }

    //     // @property (assign, nonatomic) BOOL multiBarcode;
    //     [Export ("multiBarcode")]
    //     bool MultiBarcode { get; set; }

    //     // @property (assign, nonatomic) BOOL parsePDF417;
    //     [Export ("parsePDF417")]
    //     bool ParsePDF417 { get; set; }

    //     // -(void)addDelegate:(id<ALBarcodeScanPluginDelegate> _Nonnull)delegate;
    //     [Export("addDelegate:")]
    //     void AddDelegate(NSObject @delegate);

    //     // -(void)removeDelegate:(id<ALBarcodeScanPluginDelegate> _Nonnull)delegate;
    //     [Export("removeDelegate:")]
    //     void RemoveDelegate(NSObject @delegate);
    // }

    // // @protocol ALBarcodeScanPluginDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface ALBarcodeScanPluginDelegate
    // {
    //     // @required -(void)anylineBarcodeScanPlugin:(ALBarcodeScanPlugin *)anylineBarcodeScanPlugin didFindResult:(ALBarcodeResult *)scanResult
    //     [Abstract]
    //     [Export("anylineBarcodeScanPlugin:didFindResult:")]
    //     void DidFindResult (ALBarcodeScanPlugin anylineBarcodeScanPlugin, ALBarcodeResult scanResult);

    //     // @optional -(void)anylineBarcodeScanPlugin:(ALBarcodeScanPlugin * _Nonnull)anylineBarcodeScanPlugin scannedBarcodes:(ALBarcodeResult * _Nonnull)scanResult;
    //     [Export ("anylineBarcodeScanPlugin:scannedBarcodes:")]
    //     void ScannedBarcodes (ALBarcodeScanPlugin anylineBarcodeScanPlugin, ALBarcodeResult scanResult);

    //     // @optional -(void)anylineBarcodeScanPlugin:(ALBarcodeScanPlugin * _Nonnull)anylineBarcodeScanPlugin updatedBarcodeFormats:(NSArray<NSString *> * _Nonnull)barcodeFormats;
    //     [Export ("anylineBarcodeScanPlugin:updatedBarcodeFormats:")]
    //     void UpdatedBarcodeFormats (ALBarcodeScanPlugin anylineBarcodeScanPlugin, string[] barcodeFormats);
    // }

    // // @interface ALMeterScanViewPlugin : ALAbstractScanViewPlugin
    // [BaseType(typeof(ALAbstractScanViewPlugin))]
    // interface ALMeterScanViewPlugin
    // {
    //     // @property (nonatomic, strong) ALMeterScanPlugin * _Nullable meterScanPlugin;
    //     [NullAllowed, Export("meterScanPlugin", ArgumentSemantic.Strong)]
    //     ALMeterScanPlugin MeterScanPlugin { get; set; }

    //     // -(instancetype _Nullable)initWithScanPlugin:(ALMeterScanPlugin * _Nonnull)meterScanPlugin;
    //     [Export("initWithScanPlugin:")]
    //     IntPtr Constructor(ALMeterScanPlugin meterScanPlugin);

    //     // -(instancetype _Nullable)initWithScanPlugin:(ALMeterScanPlugin * _Nonnull)meterScanPlugin scanViewPluginConfig:(ALScanViewPluginConfig * _Nonnull)scanViewPluginConfig;
    //     [Export("initWithScanPlugin:scanViewPluginConfig:")]
    //     IntPtr Constructor(ALMeterScanPlugin meterScanPlugin, ALScanViewPluginConfig scanViewPluginConfig);
    // }

    // // @interface ALBarcodeScanViewPlugin : ALAbstractScanViewPlugin
    // [BaseType(typeof(ALAbstractScanViewPlugin))]
    // interface ALBarcodeScanViewPlugin
    // {
    //     // @property (nonatomic, strong) ALBarcodeScanPlugin * _Nullable barcodeScanPlugin;
    //     [NullAllowed, Export("barcodeScanPlugin", ArgumentSemantic.Strong)]
    //     ALBarcodeScanPlugin BarcodeScanPlugin { get; set; }

    //     // -(instancetype _Nullable)initWithScanPlugin:(ALBarcodeScanPlugin * _Nonnull)barcodeScanPlugin;
    //     [Export("initWithScanPlugin:")]
    //     IntPtr Constructor(ALBarcodeScanPlugin barcodeScanPlugin);

    //     // -(instancetype _Nullable)initWithScanPlugin:(ALBarcodeScanPlugin * _Nonnull)barcodeScanPlugin scanViewPluginConfig:(ALScanViewPluginConfig * _Nonnull)scanViewPluginConfig;
    //     [Export("initWithScanPlugin:scanViewPluginConfig:")]
    //     IntPtr Constructor(ALBarcodeScanPlugin barcodeScanPlugin, ALScanViewPluginConfig scanViewPluginConfig);

    //     // @property (assign, nonatomic) BOOL useOnlyNativeBarcodeScanning;
    //     [Export("useOnlyNativeBarcodeScanning")]
    //     bool UseOnlyNativeBarcodeScanning { get; set; }
    // }

    // // @interface ALMRZIdentification : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALMRZIdentification
    // {
    //     // @property (readonly, nonatomic, strong) NSString * _Nullable surname;
    //     [NullAllowed, Export("surname", ArgumentSemantic.Strong)]
    //     string Surname { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable givenNames;
    //     [NullAllowed, Export("givenNames", ArgumentSemantic.Strong)]
    //     string GivenNames { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable dateOfBirth;
    //     [NullAllowed, Export("dateOfBirth", ArgumentSemantic.Strong)]
    //     string DateOfBirth { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable dateOfExpiry;
    //     [NullAllowed, Export("dateOfExpiry", ArgumentSemantic.Strong)]
    //     string DateOfExpiry { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable documentNumber;
    //     [NullAllowed, Export("documentNumber", ArgumentSemantic.Strong)]
    //     string DocumentNumber { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable documentType;
    //     [NullAllowed, Export("documentType", ArgumentSemantic.Strong)]
    //     string DocumentType { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable issuingCountryCode;
    //     [NullAllowed, Export("issuingCountryCode", ArgumentSemantic.Strong)]
    //     string IssuingCountryCode { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable nationalityCountryCode;
    //     [NullAllowed, Export("nationalityCountryCode", ArgumentSemantic.Strong)]
    //     string NationalityCountryCode { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable sex;
    //     [NullAllowed, Export("sex", ArgumentSemantic.Strong)]
    //     string Sex { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable personalNumber;
    //     [NullAllowed, Export("personalNumber", ArgumentSemantic.Strong)]
    //     string PersonalNumber { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable optionalData;
    //     [NullAllowed, Export("optionalData", ArgumentSemantic.Strong)]
    //     string OptionalData { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable mrzString;
    //     [NullAllowed, Export("mrzString", ArgumentSemantic.Strong)]
    //     string MrzString { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable vizAddress;
    //     [NullAllowed, Export("vizAddress", ArgumentSemantic.Strong)]
    //     string VizAddress { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable vizDateOfIssue;
    //     [NullAllowed, Export("vizDateOfIssue", ArgumentSemantic.Strong)]
    //     string VizDateOfIssue { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable vizSurname;
    //     [NullAllowed, Export("vizSurname", ArgumentSemantic.Strong)]
    //     string VizSurname { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable vizGivenNames;
    //     [NullAllowed, Export("vizGivenNames", ArgumentSemantic.Strong)]
    //     string VizGivenNames { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable vizDateOfBirth;
    //     [NullAllowed, Export("vizDateOfBirth", ArgumentSemantic.Strong)]
    //     string VizDateOfBirth { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable vizDateOfExpiry;
    //     [NullAllowed, Export("vizDateOfExpiry", ArgumentSemantic.Strong)]
    //     string VizDateOfExpiry { get; }

    //     // @property (nonatomic, strong) UIImage * _Nullable faceImage;
    //     [NullAllowed, Export("faceImage", ArgumentSemantic.Strong)]
    //     UIImage FaceImage { get; set; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable checkDigitDateOfExpiry;
    //     [NullAllowed, Export("checkDigitDateOfExpiry", ArgumentSemantic.Strong)]
    //     string CheckDigitDateOfExpiry { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable checkDigitDocumentNumber;
    //     [NullAllowed, Export("checkDigitDocumentNumber", ArgumentSemantic.Strong)]
    //     string CheckDigitDocumentNumber { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable checkDigitDateOfBirth;
    //     [NullAllowed, Export("checkDigitDateOfBirth", ArgumentSemantic.Strong)]
    //     string CheckDigitDateOfBirth { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable checkDigitFinal;
    //     [NullAllowed, Export("checkDigitFinal", ArgumentSemantic.Strong)]
    //     string CheckDigitFinal { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable checkDigitPersonalNumber;
    //     [NullAllowed, Export("checkDigitPersonalNumber", ArgumentSemantic.Strong)]
    //     string CheckDigitPersonalNumber { get; }

    //     // @property (readonly, nonatomic) BOOL allCheckDigitsValid;
    //     [Export("allCheckDigitsValid")]
    //     bool AllCheckDigitsValid { get; }

    //     // @property (readonly, nonatomic, strong) NSDate * _Nullable dateOfBirthObject;
    //     [NullAllowed, Export("dateOfBirthObject", ArgumentSemantic.Strong)]
    //     NSDate DateOfBirthObject { get; }

    //     // @property (readonly, nonatomic, strong) NSDate * _Nullable dateOfExpiryObject;
    //     [NullAllowed, Export("dateOfExpiryObject", ArgumentSemantic.Strong)]
    //     NSDate DateOfExpiryObject { get; }

    //     // @property (readonly, nonatomic, strong) NSDate * _Nullable vizDateOfIssueObject;
    //     [NullAllowed, Export("vizDateOfIssueObject", ArgumentSemantic.Strong)]
    //     NSDate VizDateOfIssueObject { get; }

    //     // @property (readonly, nonatomic, strong) NSDate * _Nullable vizDateOfBirthObject;
    //     [NullAllowed, Export("vizDateOfBirthObject", ArgumentSemantic.Strong)]
    //     NSDate VizDateOfBirthObject { get; }

    //     // @property (readonly, nonatomic, strong) NSDate * _Nullable vizDateOfExpiryObject;
    //     [NullAllowed, Export("vizDateOfExpiryObject", ArgumentSemantic.Strong)]
    //     NSDate VizDateOfExpiryObject { get; }

    //     // @property (nonatomic, strong) ALMRZFieldConfidences * _Nullable fieldConfidences;
    //     [NullAllowed, Export("fieldConfidences", ArgumentSemantic.Strong)]
    //     ALMRZFieldConfidences FieldConfidences { get; set; }

    //     /*
    //     // @property (readonly, nonatomic, strong) NSString * _Nullable surNames __attribute__((deprecated("Deprecated since Version 10. Please use the property "surname" instead.")));
    //     [NullAllowed, Export("surNames", ArgumentSemantic.Strong)]
    //     string SurNames { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable dayOfBirth __attribute__((deprecated("Deprecated since Version 10. Please use the property "dateOfBirth" instead.")));
    //     [NullAllowed, Export("dayOfBirth", ArgumentSemantic.Strong)]
    //     string DayOfBirth { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable expirationDate __attribute__((deprecated("Deprecated since Version 10. Please use the property "dateOfExpiry" instead.")));
    //     [NullAllowed, Export("expirationDate", ArgumentSemantic.Strong)]
    //     string ExpirationDate { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable checkdigitNumber __attribute__((deprecated("Deprecated since Version 10. Please use the property "checkDigitDocumentNumber" instead.")));
    //     [NullAllowed, Export("checkdigitNumber", ArgumentSemantic.Strong)]
    //     string CheckdigitNumber { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable checkdigitExpirationDate __attribute__((deprecated("Deprecated since Version 10. Please use the property "checkDigitDateOfExpiry" instead.")));
    //     [NullAllowed, Export("checkdigitExpirationDate", ArgumentSemantic.Strong)]
    //     string CheckdigitExpirationDate { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable checkdigitDayOfBirth __attribute__((deprecated("Deprecated since Version 10. Please use the property "checkDigitDateOfBirth" instead.")));
    //     [NullAllowed, Export("checkdigitDayOfBirth", ArgumentSemantic.Strong)]
    //     string CheckdigitDayOfBirth { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable checkdigitFinal __attribute__((deprecated("Deprecated since Version 10. Please use the property "checkDigitFinal" instead.")));
    //     [NullAllowed, Export("checkdigitFinal", ArgumentSemantic.Strong)]
    //     string CheckdigitFinal { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable issuingDate __attribute__((deprecated("Deprecated since Version 10. Please use the property "dateOfIssue" instead.")));
    //     [NullAllowed, Export("issuingDate", ArgumentSemantic.Strong)]
    //     string IssuingDate { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable personalNumber2 __attribute__((deprecated("Deprecated since Version 10. Please use the property "optionalData" instead.")));
    //     [NullAllowed, Export("personalNumber2", ArgumentSemantic.Strong)]
    //     string PersonalNumber2 { get; }

    //     // @property (readonly, nonatomic, strong) NSDate * _Nullable expirationDateObject __attribute__((deprecated("Deprecated since Version 10. Please use the property "dateOfExpiryObject" instead.")));
    //     [NullAllowed, Export("expirationDateObject", ArgumentSemantic.Strong)]
    //     NSDate ExpirationDateObject { get; }

    //     // @property (readonly, nonatomic, strong) NSDate * _Nullable dayOfBirthDateObject __attribute__((deprecated("Deprecated since Version 10. Please use the property "dateOfBirthObject" instead.")));
    //     //[NullAllowed, Export("dayOfBirthDateObject", ArgumentSemantic.Strong)]
    //     //NSDate DayOfBirthDateObject { get; }

    //     // @property (readonly, nonatomic, strong) NSDate * _Nullable issuingDateObject __attribute__((deprecated("Deprecated since Version 10. Please use the property "dateOfIssueObject" instead.")));
    //     //[NullAllowed, Export("issuingDateObject", ArgumentSemantic.Strong)]
    //     //NSDate IssuingDateObject { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable MRZString __attribute__((deprecated("Deprecated since Version 10. Please use the property "mrzString" instead.")));
    //     [NullAllowed, Export("MRZString", ArgumentSemantic.Strong)]
    //     string MRZString { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable dateOfIssue __attribute__((deprecated("Deprecated since Version 10.1. Please use the property "vizDateOfIssue" instead.")));
    //     //[NullAllowed, Export("dateOfIssue", ArgumentSemantic.Strong)]
    //     //string DateOfIssue { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable address __attribute__((deprecated("Deprecated since Version 10.1. Please use the property "vizAddress" instead.")));
    //     //[NullAllowed, Export("address", ArgumentSemantic.Strong)]
    //     //string Address { get; }

    //     // @property (readonly, nonatomic, strong) NSDate * _Nullable dateOfIssueObject __attribute__((deprecated("Deprecated since Version 10.1. Please use the property "vizDateOfIssueObject" instead.")));
    //     //[NullAllowed, Export("dateOfIssueObject", ArgumentSemantic.Strong)]
    //     //NSDate DateOfIssueObject { get; }
    //     */

    //     // -(instancetype _Nullable)initWithSurname:(NSString * _Nullable)surname givenNames:(NSString * _Nullable)givenNames dateOfBirth:(NSString * _Nullable)dateOfBirth dateOfExpiry:(NSString * _Nullable)dateOfExpiry documentNumber:(NSString * _Nullable)documentNumber documentType:(NSString * _Nullable)documentType issuingCountryCode:(NSString * _Nullable)issuingCountryCode nationalityCountryCode:(NSString * _Nullable)nationalityCountryCode sex:(NSString * _Nullable)sex personalNumber:(NSString * _Nullable)personalNumber optionalData:(NSString * _Nullable)optionalData checkDigitDateOfExpiry:(NSString * _Nullable)checkDigitDateOfExpiry checkDigitDocumentNumber:(NSString * _Nullable)checkDigitDocumentNumber checkDigitDateOfBirth:(NSString * _Nullable)checkDigitDateOfBirth checkDigitFinal:(NSString * _Nullable)checkDigitFinal checkDigitPersonalNumber:(NSString * _Nullable)checkDigitPersonalNumber allCheckDigitsValid:(BOOL)allCheckDigitsValid vizAddress:(NSString * _Nullable)vizAddress vizDateOfIssue:(NSString * _Nullable)vizDateOfIssue vizSurname:(NSString * _Nullable)vizSurname vizGivenNames:(NSString * _Nullable)vizGivenNames vizDateOfBirth:(NSString * _Nullable)vizDateOfBirth vizDateOfExpiry:(NSString * _Nullable)vizDateOfExpiry mrzString:(NSString * _Nullable)mrzString formattedDateOfExpiry:(NSString * _Nullable)formattedDateOfExpiry formattedDateOfBirth:(NSString * _Nullable)formattedDateOfBirth formattedVizDateOfIssue:(NSString * _Nullable)formattedVizDateOfIssue formattedVizDateOfBirth:(NSString * _Nullable)formattedVizDateOfBirth formattedVizDateOfExpiry:(NSString * _Nullable)formattedVizDateOfExpiry;
    //     [Export("initWithSurname:givenNames:dateOfBirth:dateOfExpiry:documentNumber:documentType:issuingCountryCode:nationalityCountryCode:sex:personalNumber:optionalData:checkDigitDateOfExpiry:checkDigitDocumentNumber:checkDigitDateOfBirth:checkDigitFinal:checkDigitPersonalNumber:allCheckDigitsValid:vizAddress:vizDateOfIssue:vizSurname:vizGivenNames:vizDateOfBirth:vizDateOfExpiry:mrzString:formattedDateOfExpiry:formattedDateOfBirth:formattedVizDateOfIssue:formattedVizDateOfBirth:formattedVizDateOfExpiry:")]
    //     IntPtr Constructor([NullAllowed] string surname, [NullAllowed] string givenNames, [NullAllowed] string dateOfBirth, [NullAllowed] string dateOfExpiry, [NullAllowed] string documentNumber, [NullAllowed] string documentType, [NullAllowed] string issuingCountryCode, [NullAllowed] string nationalityCountryCode, [NullAllowed] string sex, [NullAllowed] string personalNumber, [NullAllowed] string optionalData, [NullAllowed] string checkDigitDateOfExpiry, [NullAllowed] string checkDigitDocumentNumber, [NullAllowed] string checkDigitDateOfBirth, [NullAllowed] string checkDigitFinal, [NullAllowed] string checkDigitPersonalNumber, bool allCheckDigitsValid, [NullAllowed] string vizAddress, [NullAllowed] string vizDateOfIssue, [NullAllowed] string vizSurname, [NullAllowed] string vizGivenNames, [NullAllowed] string vizDateOfBirth, [NullAllowed] string vizDateOfExpiry, [NullAllowed] string mrzString, [NullAllowed] string formattedDateOfExpiry, [NullAllowed] string formattedDateOfBirth, [NullAllowed] string formattedVizDateOfIssue, [NullAllowed] string formattedVizDateOfBirth, [NullAllowed] string formattedVizDateOfExpiry);
    // }

    // // @interface ALLayoutDefinition : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALLayoutDefinition
    // {
    //     // @property NSString * _Nonnull country;
    //     [Export("country")]
    //     string Country { get; set; }

    //     // @property NSString * _Nonnull layout;
    //     [Export("layout")]
    //     string Layout { get; set; }

    //     // @property NSString * _Nonnull type;
    //     [Export("type")]
    //     string Type { get; set; }

    //     // -(instancetype _Nonnull)initWithDictionary:(NSDictionary<NSString *,NSString *> * _Nonnull)dictionary;
    //     [Export("initWithDictionary:")]
    //     IntPtr Constructor(NSDictionary<NSString, NSString> dictionary);
    // }

    // // @interface ALUniversalIDIdentification : NSObject
    // [BaseType (typeof(NSObject))]
    // interface ALUniversalIDIdentification
    // {
    // 	// @property (nonatomic, strong) ALUniversalIDFieldConfidences * _Nullable fieldConfidences;
    // 	[NullAllowed, Export ("fieldConfidences", ArgumentSemantic.Strong)]
    // 	ALUniversalIDFieldConfidences FieldConfidences { get; set; }

    // 	// @property (nonatomic, strong) ALLayoutDefinition * _Nullable layoutDefinition;
    // 	[NullAllowed, Export ("layoutDefinition", ArgumentSemantic.Strong)]
    // 	ALLayoutDefinition LayoutDefinition { get; set; }

    //     // @property (nonatomic, strong) UIImage * _Nullable faceImage;
    //     [NullAllowed, Export ("faceImage", ArgumentSemantic.Strong)]
    //     UIImage FaceImage { get; set; }

    //     // @property (assign, nonatomic) CGRect faceImageBounds;
    //     [Export ("faceImageBounds", ArgumentSemantic.Assign)]
    //     CGRect FaceImageBounds { get; set; }

    //     // @property (readonly, nonatomic) NSDictionary<NSString *,NSString *> * _Nonnull resultData;
    //     [Export ("resultData")]
    //     NSDictionary<NSString, NSString> ResultData { get; }

    // 	// -(void)addField:(NSString * _Nonnull)fieldName value:(NSString * _Nonnull)value;
    // 	[Export ("addField:value:")]
    // 	void AddField (string fieldName, string value);

    // 	// -(NSArray<NSString *> * _Nonnull)fieldNames;
    // 	[Export ("fieldNames")]
    // 	string[] FieldNames { get; }

    // 	// -(NSString * _Nonnull)valueForField:(NSString * _Nonnull)fieldName;
    // 	[Export ("valueForField:")]
    // 	string ValueForField (string fieldName);

    // 	// -(BOOL)hasField:(NSString * _Nonnull)fieldName;
    // 	[Export ("hasField:")]
    // 	bool HasField (string fieldName);

    // 	// -(void)removeField:(NSString * _Nonnull)fieldName;
    // 	[Export ("removeField:")]
    // 	void RemoveField (string fieldName);
    // }

    // // @interface ALIDConfig : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALIDConfig
    // {
    //     // -(instancetype _Nullable)initWithJsonDictionary:(NSDictionary * _Nonnull)configDict;
    //     [Export("initWithJsonDictionary:")]
    //     IntPtr Constructor(NSDictionary configDict);

    //     // @property (nonatomic, strong) ALIDFieldScanOptions * _Nullable idFieldScanOptions;
    //     [NullAllowed, Export("idFieldScanOptions", ArgumentSemantic.Strong)]
    //     ALIDFieldScanOptions IdFieldScanOptions { get; set; }

    //     // @property (nonatomic, strong) ALIDFieldConfidences * _Nullable idFieldConfidences;
    //     [NullAllowed, Export("idFieldConfidences", ArgumentSemantic.Strong)]
    //     ALIDFieldConfidences IdFieldConfidences { get; set; }

    //     // @property (nonatomic) int minConfidence;
    //     [Export("minConfidence")]
    //     int MinConfidence { get; set; }
    // }

    // // @interface ALIDFieldScanOptions : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALIDFieldScanOptions
    // {
    //     // -(instancetype _Nullable)initWithJsonDictionary:(NSDictionary * _Nonnull)configDict;
    //     [Export("initWithJsonDictionary:")]
    //     IntPtr Constructor(NSDictionary configDict);
    // }

    // // @interface ALIDFieldConfidences : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALIDFieldConfidences
    // {
    //     // -(instancetype _Nullable)initWithJsonDictionary:(NSDictionary * _Nonnull)configDict;
    //     [Export("initWithJsonDictionary:")]
    //     IntPtr Constructor(NSDictionary configDict);
    // }

    // // @interface ALMRZConfig : ALIDConfig
    // [BaseType(typeof(ALIDConfig))]
    // interface ALMRZConfig
    // {
    //     // @property (nonatomic) BOOL strictMode;
    //     [Export("strictMode")]
    //     bool StrictMode { get; set; }

    //     // @property (nonatomic) BOOL cropAndTransformID;
    //     [Export("cropAndTransformID")]
    //     bool CropAndTransformID { get; set; }
    // }

    // // @interface ALMRZFieldScanOptions : ALIDFieldScanOptions
    // [BaseType(typeof(ALIDFieldScanOptions))]
    // interface ALMRZFieldScanOptions
    // {
    //     // @property (nonatomic) ALFieldScanOption vizDateOfIssue;
    //     [Export("vizDateOfIssue", ArgumentSemantic.Assign)]
    //     ALFieldScanOption VizDateOfIssue { get; set; }

    //     // @property (nonatomic) ALFieldScanOption vizAddress;
    //     [Export("vizAddress", ArgumentSemantic.Assign)]
    //     ALFieldScanOption VizAddress { get; set; }

    //     // @property (nonatomic) ALFieldScanOption vizSurname;
    //     [Export("vizSurname", ArgumentSemantic.Assign)]
    //     ALFieldScanOption VizSurname { get; set; }

    //     // @property (nonatomic) ALFieldScanOption vizGivenNames;
    //     [Export("vizGivenNames", ArgumentSemantic.Assign)]
    //     ALFieldScanOption VizGivenNames { get; set; }

    //     // @property (nonatomic) ALFieldScanOption vizDateOfBirth;
    //     [Export("vizDateOfBirth", ArgumentSemantic.Assign)]
    //     ALFieldScanOption VizDateOfBirth { get; set; }

    //     // @property (nonatomic) ALFieldScanOption vizDateOfExpiry;
    //     [Export("vizDateOfExpiry", ArgumentSemantic.Assign)]
    //     ALFieldScanOption VizDateOfExpiry { get; set; }

    //     // @property (nonatomic) ALFieldScanOption dateOfIssue __attribute__((deprecated("Deprecated since Version 10.1. Please use vizDateOfIssue instead")));
    //     //[Export("dateOfIssue", ArgumentSemantic.Assign)]
    //     //ALFieldScanOption DateOfIssue { get; set; }

    //     // @property (nonatomic) ALFieldScanOption address __attribute__((deprecated("Deprecated since Version 10.1. Please use vizAddress instead")));
    //     //[Export("address", ArgumentSemantic.Assign)]
    //     //ALFieldScanOption Address { get; set; }
    // }

    // // @interface ALMRZFieldConfidences : ALIDFieldConfidences
    // [BaseType(typeof(ALIDFieldConfidences))]
    // interface ALMRZFieldConfidences
    // {
    //     // @property (nonatomic) ALFieldConfidence vizDateOfIssue;
    //     [Export("vizDateOfIssue")]
    //     int VizDateOfIssue { get; set; }

    //     // @property (nonatomic) ALFieldConfidence vizAddress;
    //     [Export("vizAddress")]
    //     int VizAddress { get; set; }

    //     // @property (nonatomic) ALFieldConfidence vizSurname;
    //     [Export("vizSurname")]
    //     int VizSurname { get; set; }

    //     // @property (nonatomic) ALFieldConfidence vizGivenNames;
    //     [Export("vizGivenNames")]
    //     int VizGivenNames { get; set; }

    //     // @property (nonatomic) ALFieldConfidence vizDateOfBirth;
    //     [Export("vizDateOfBirth")]
    //     int VizDateOfBirth { get; set; }

    //     // @property (nonatomic) ALFieldConfidence vizDateOfExpiry;
    //     [Export("vizDateOfExpiry")]
    //     int VizDateOfExpiry { get; set; }

    //     // @property (nonatomic) ALFieldConfidence surname;
    //     [Export("surname")]
    //     int Surname { get; set; }

    //     // @property (nonatomic) ALFieldConfidence givenNames;
    //     [Export("givenNames")]
    //     int GivenNames { get; set; }

    //     // @property (nonatomic) ALFieldConfidence dateOfBirth;
    //     [Export("dateOfBirth")]
    //     int DateOfBirth { get; set; }

    //     // @property (nonatomic) ALFieldConfidence dateOfExpiry;
    //     [Export("dateOfExpiry")]
    //     int DateOfExpiry { get; set; }

    //     // @property (nonatomic) ALFieldConfidence documentNumber;
    //     [Export("documentNumber")]
    //     int DocumentNumber { get; set; }

    //     // @property (nonatomic) ALFieldConfidence documentType;
    //     [Export("documentType")]
    //     int DocumentType { get; set; }

    //     // @property (nonatomic) ALFieldConfidence issuingCountryCode;
    //     [Export("issuingCountryCode")]
    //     int IssuingCountryCode { get; set; }

    //     // @property (nonatomic) ALFieldConfidence nationalityCountryCode;
    //     [Export("nationalityCountryCode")]
    //     int NationalityCountryCode { get; set; }

    //     // @property (nonatomic) ALFieldConfidence sex;
    //     [Export("sex")]
    //     int Sex { get; set; }

    //     // @property (nonatomic) ALFieldConfidence personalNumber;
    //     [Export("personalNumber")]
    //     int PersonalNumber { get; set; }

    //     // @property (nonatomic) ALFieldConfidence optionalData;
    //     [Export("optionalData")]
    //     int OptionalData { get; set; }

    //     // @property (nonatomic) ALFieldConfidence mrzString;
    //     [Export("mrzString")]
    //     int MrzString { get; set; }

    //     // @property (nonatomic) ALFieldConfidence checkDigitDateOfExpiry;
    //     [Export("checkDigitDateOfExpiry")]
    //     int CheckDigitDateOfExpiry { get; set; }

    //     // @property (nonatomic) ALFieldConfidence checkDigitDocumentNumber;
    //     [Export("checkDigitDocumentNumber")]
    //     int CheckDigitDocumentNumber { get; set; }

    //     // @property (nonatomic) ALFieldConfidence checkDigitDateOfBirth;
    //     [Export("checkDigitDateOfBirth")]
    //     int CheckDigitDateOfBirth { get; set; }

    //     // @property (nonatomic) ALFieldConfidence checkDigitFinal;
    //     [Export("checkDigitFinal")]
    //     int CheckDigitFinal { get; set; }

    //     // @property (nonatomic) ALFieldConfidence checkDigitPersonalNumber;
    //     [Export("checkDigitPersonalNumber")]
    //     int CheckDigitPersonalNumber { get; set; }

    //     // -(instancetype _Nullable)initWithSurname:(ALFieldConfidence)surname givenNames:(ALFieldConfidence)givenNames dateOfBirth:(ALFieldConfidence)dateOfBirth dateOfExpiry:(ALFieldConfidence)dateOfExpiry documentNumber:(ALFieldConfidence)documentNumber documentType:(ALFieldConfidence)documentType issuingCountryCode:(ALFieldConfidence)issuingCountryCode nationalityCountryCode:(ALFieldConfidence)nationalityCountryCode sex:(ALFieldConfidence)sex personalNumber:(ALFieldConfidence)personalNumber optionalData:(ALFieldConfidence)optionalData checkDigitDateOfExpiry:(ALFieldConfidence)checkDigitDateOfExpiry checkDigitDocumentNumber:(ALFieldConfidence)checkDigitDocumentNumber checkDigitDateOfBirth:(ALFieldConfidence)checkDigitDateOfBirth checkDigitFinal:(ALFieldConfidence)checkDigitFinal checkDigitPersonalNumber:(ALFieldConfidence)checkDigitPersonalNumber vizAddress:(ALFieldConfidence)vizAddress vizDateOfIssue:(ALFieldConfidence)vizDateOfIssue vizSurname:(ALFieldConfidence)vizSurname vizGivenNames:(ALFieldConfidence)vizGivenNames vizDateOfBirth:(ALFieldConfidence)vizDateOfBirth vizDateOfExpiry:(ALFieldConfidence)vizDateOfExpiry mrzString:(ALFieldConfidence)mrzString;
    //     [Export("initWithSurname:givenNames:dateOfBirth:dateOfExpiry:documentNumber:documentType:issuingCountryCode:nationalityCountryCode:sex:personalNumber:optionalData:checkDigitDateOfExpiry:checkDigitDocumentNumber:checkDigitDateOfBirth:checkDigitFinal:checkDigitPersonalNumber:vizAddress:vizDateOfIssue:vizSurname:vizGivenNames:vizDateOfBirth:vizDateOfExpiry:mrzString:")]
    //     IntPtr Constructor(int surname, int givenNames, int dateOfBirth, int dateOfExpiry, int documentNumber, int documentType, int issuingCountryCode, int nationalityCountryCode, int sex, int personalNumber, int optionalData, int checkDigitDateOfExpiry, int checkDigitDocumentNumber, int checkDigitDateOfBirth, int checkDigitFinal, int checkDigitPersonalNumber, int vizAddress, int vizDateOfIssue, int vizSurname, int vizGivenNames, int vizDateOfBirth, int vizDateOfExpiry, int mrzString);
    // }

    // // @interface ALUniversalIDFieldScanOptions : ALIDFieldScanOptions
    // [BaseType (typeof(ALIDFieldScanOptions))]
    // interface ALUniversalIDFieldScanOptions
    // {
    // 	// -(instancetype _Nullable)initWithJsonDictionary:(NSDictionary * _Nonnull)configDict;
    // 	[Export ("initWithJsonDictionary:")]
    // 	IntPtr Constructor (NSDictionary configDict);

    // 	// -(BOOL)hasField:(NSString * _Nonnull)fieldName;
    // 	[Export ("hasField:")]
    // 	bool HasField (string fieldName);

    // 	// -(void)addField:(NSString * _Nonnull)fieldName value:(ALFieldScanOption)scanOption;
    // 	[Export ("addField:value:")]
    // 	void AddField (string fieldName, ALFieldScanOption scanOption);

    // 	// -(void)removeField:(NSString * _Nonnull)fieldName;
    // 	[Export ("removeField:")]
    // 	void RemoveField (string fieldName);

    // 	// -(NSArray<NSString *> * _Nonnull)fieldNames;
    // 	[Export ("fieldNames")]
    // 	string[] FieldNames { get; }

    // 	// -(ALFieldScanOption)valueForField:(NSString * _Nonnull)fieldName;
    // 	[Export ("valueForField:")]
    // 	ALFieldScanOption ValueForField (string fieldName);
    // }

    // // @interface ALUniversalIDFieldConfidences : ALIDFieldConfidences
    // [BaseType (typeof(ALIDFieldConfidences))]
    // interface ALUniversalIDFieldConfidences
    // {
    // 	// -(instancetype _Nullable)initWithJsonDictionary:(NSDictionary * _Nonnull)configDict;
    // 	[Export ("initWithJsonDictionary:")]
    // 	IntPtr Constructor (NSDictionary configDict);

    // 	// -(BOOL)hasField:(NSString * _Nonnull)fieldName;
    // 	[Export ("hasField:")]
    // 	bool HasField (string fieldName);

    // 	// -(void)addField:(NSString * _Nonnull)fieldName value:(ALFieldConfidence)confidence;
    // 	[Export ("addField:value:")]
    // 	void AddField (string fieldName, int confidence);

    // 	// -(void)removeField:(NSString * _Nonnull)fieldName;
    // 	[Export ("removeField:")]
    // 	void RemoveField (string fieldName);

    // 	// -(ALFieldConfidence)valueForField:(NSString * _Nonnull)fieldName;
    // 	[Export ("valueForField:")]
    // 	int ValueForField (string fieldName);

    // 	// -(NSArray<NSString *> * _Nonnull)fieldNames;
    // 	[Export ("fieldNames")]
    // 	string[] FieldNames { get; }
    // }

    // // @interface ALUniversalIDConfig : ALIDConfig
    // [BaseType (typeof(ALIDConfig))]
    // interface ALUniversalIDConfig
    // {
    // 	// -(NSDictionary * _Nonnull)toStartVariableJsonDictionary;
    // 	[Export ("toStartVariableJsonDictionary")]
    // 	NSDictionary ToStartVariableJsonDictionary { get; }

    //     // -(void)setAllowedLayouts:(NSArray<NSString *> * _Nullable)allowedLayouts forLayoutType:(ALUniversalIDLayoutType)layoutType;
    //     [Export ("setAllowedLayouts:forLayoutType:")]
    //     void SetAllowedLayouts ([NullAllowed] string[] allowedLayouts, ALUniversalIDLayoutType layoutType);

    //     // -(NSArray<NSString *> * _Nullable)getAllowedLayoutsForLayoutType:(ALUniversalIDLayoutType)layoutType;
    //     [Export ("getAllowedLayoutsForLayoutType:")]
    //     [return: NullAllowed]
    //     string[] GetAllowedLayoutsForLayoutType (ALUniversalIDLayoutType layoutType);

    //     // -(NSDictionary<NSString *,NSArray<NSString *> *> * _Nullable)allowedLayoutsDictionary;
    //     [NullAllowed, Export ("allowedLayoutsDictionary")]
    //     NSDictionary<NSString, NSArray<NSString>> AllowedLayoutsDictionary { get; }
    // }

    // // audit-objc-generics: @interface ALIDResult<__covariant ObjectType> : ALScanResult
    // [BaseType (typeof(ALScanResult))]
    // interface ALIDResult
    // {
    // 	// -(instancetype _Nullable)initWithResult:(ObjectType _Nonnull)result image:(UIImage * _Nullable)image fullImage:(UIImage * _Nullable)fullImage confidence:(NSInteger)confidence pluginID:(NSString * _Nonnull)pluginID;
    // 	[Export ("initWithResult:image:fullImage:confidence:pluginID:")]
    // 	IntPtr Constructor (NSObject result, [NullAllowed] UIImage image, [NullAllowed] UIImage fullImage, nint confidence, string pluginID);

    // 	// -(instancetype _Nullable)initWithResult:(ObjectType _Nonnull)result image:(UIImage * _Nonnull)image fullImage:(UIImage * _Nullable)fullImage confidence:(NSInteger)confidence pluginID:(NSString * _Nonnull)pluginID allCheckDigitsValid:(BOOL)allCheckDigitsValid __attribute__((deprecated("Deprecated since Version 10. Please use "initWithResult:image:fullImage:confidence:pluginID" instead")));
    // 	[Export ("initWithResult:image:fullImage:confidence:pluginID:allCheckDigitsValid:")]
    // 	IntPtr Constructor (NSObject result, UIImage image, [NullAllowed] UIImage fullImage, nint confidence, string pluginID, bool allCheckDigitsValid);
    // }
    
    // // @interface ALIDScanPlugin : ALAbstractScanPlugin
    // [BaseType(typeof(ALAbstractScanPlugin))]
    // [DisableDefaultCtor]
    // interface ALIDScanPlugin
    // {
    //     // -(instancetype _Nullable)initWithPluginID:(NSString * _Nullable)pluginID delegate:(id<ALIDPluginDelegate> _Nonnull)delegate idConfig:(ALIDConfig * _Nonnull)config error:(NSError * _Nullable * _Nullable)error;
    //     [Export("initWithPluginID:delegate:idConfig:error:")]
    //     IntPtr Constructor([NullAllowed] string pluginID, NSObject @delegate, ALIDConfig config, [NullAllowed] out NSError error);

    //     // @property (readonly, nonatomic, strong) NSHashTable<ALIDPluginDelegate> * _Nullable delegates;
    //     [NullAllowed, Export("delegates", ArgumentSemantic.Strong)]
    //     NSSet Delegates { get; }

    //     // -(void)addDelegate:(id<ALIDPluginDelegate> _Nonnull)delegate;
    //     [Export("addDelegate:")]
    //     void AddDelegate(NSObject @delegate);

    //     // -(void)removeDelegate:(id<ALIDPluginDelegate> _Nonnull)delegate;
    //     [Export("removeDelegate:")]
    //     void RemoveDelegate(NSObject @delegate);

    //     // @property (readonly, nonatomic, strong) ALIDConfig * _Nullable idConfig;
    //     [NullAllowed, Export("idConfig", ArgumentSemantic.Strong)]
    //     ALIDConfig IdConfig { get; }

    //     // -(BOOL)setIDConfig:(ALIDConfig * _Nonnull)idConfig error:(NSError * _Nullable * _Nullable)error;
    //     [Export("setIDConfig:error:")]
    //     bool SetIDConfig(ALIDConfig idConfig, [NullAllowed] out NSError error);
    // }

    // // @protocol ALIDPluginDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface ALIDPluginDelegate
    // {
    //     // @required -(void)anylineIDScanPlugin:(ALIDScanPlugin * _Nonnull)anylineIDScanPlugin didFindResult:(ALIDResult * _Nonnull)scanResult;
    //     [Abstract]
    //     [Export("anylineIDScanPlugin:didFindResult:")]
    //     void DidFindResult(ALIDScanPlugin anylineIDScanPlugin, ALIDResult scanResult);
    // }

    // // @interface ALIDScanViewPlugin : ALAbstractScanViewPlugin
    // [BaseType(typeof(ALAbstractScanViewPlugin))]
    // interface ALIDScanViewPlugin
    // {
    //     // @property (nonatomic, strong) ALIDScanPlugin * _Nullable idScanPlugin;
    //     [NullAllowed, Export("idScanPlugin", ArgumentSemantic.Strong)]
    //     ALIDScanPlugin IdScanPlugin { get; set; }

    //     // -(instancetype _Nullable)initWithScanPlugin:(ALIDScanPlugin * _Nonnull)idScanPlugin;
    //     [Export("initWithScanPlugin:")]
    //     IntPtr Constructor(ALIDScanPlugin idScanPlugin);

    //     // -(instancetype _Nullable)initWithScanPlugin:(ALIDScanPlugin * _Nonnull)idScanPlugin scanViewPluginConfig:(ALScanViewPluginConfig * _Nonnull)scanViewPluginConfig;
    //     [Export("initWithScanPlugin:scanViewPluginConfig:")]
    //     IntPtr Constructor(ALIDScanPlugin idScanPlugin, ALScanViewPluginConfig scanViewPluginConfig);
    // }

    // // @interface ALOCRResult : ALScanResult
    // [BaseType(typeof(ALScanResult))]
    // interface ALOCRResult
    // {
    //     // @property (readonly, nonatomic, strong) NSString * _Nullable text __attribute__((deprecated("Deprecated since 3.10 Use result property instead.")));
    //     //[Obsolete("", false)]
    //     //[NullAllowed, Export("text", ArgumentSemantic.Strong)]
    //     //string Text { get; }

    //     // @property (readonly, nonatomic, strong) UIImage * _Nullable thresholdedImage;
    //     [NullAllowed, Export("thresholdedImage", ArgumentSemantic.Strong)]
    //     UIImage ThresholdedImage { get; }

    //     // -(instancetype _Nullable)initWithText:(NSString * _Nonnull)text image:(UIImage * _Nonnull)image thresholdedImage:(UIImage * _Nullable)thresholdedImage __attribute__((deprecated("Deprecated since 3.10 Use initWithResult:image:fullImage:confidence instead.")));
    //     [Export("initWithText:image:thresholdedImage:")]
    //     IntPtr Constructor(string text, UIImage image, [NullAllowed] UIImage thresholdedImage);

    //     // -(instancetype _Nullable)initWithResult:(NSString * _Nonnull)result image:(UIImage * _Nonnull)image fullImage:(UIImage * _Nullable)fullImage confidence:(NSInteger)confidence pluginID:(NSString * _Nonnull)pluginID thresholdedImage:(UIImage * _Nullable)thresholdedImage;
    //     [Export("initWithResult:image:fullImage:confidence:pluginID:thresholdedImage:")]
    //     IntPtr Constructor(string result, UIImage image, [NullAllowed] UIImage fullImage, nint confidence, string pluginID, [NullAllowed] UIImage thresholdedImage);
    // }

    // // @interface ALBaseOCRConfig : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALBaseOCRConfig
    // {
    //     // -(instancetype _Nullable)initWithJsonDictionary:(NSDictionary * _Nonnull)configDict;
    //     [Export("initWithJsonDictionary:")]
    //     IntPtr Constructor(NSDictionary configDict);
    // }

    // partial interface Constants
    // {
    //     // extern NSString *const _Nonnull regexForEmail;
    //     [Field("regexForEmail", "__Internal")]
    //     NSString regexForEmail { get; }

    //     // extern NSString *const _Nonnull regexForURL;
    //     [Field("regexForURL", "__Internal")]
    //     NSString regexForURL { get; }

    //     // extern NSString *const _Nonnull regexForPriceTag;
    //     [Field("regexForPriceTag", "__Internal")]
    //     NSString regexForPriceTag { get; }

    //     // extern NSString *const _Nonnull regexForISBN;
    //     [Field("regexForISBN", "__Internal")]
    //     NSString regexForISBN { get; }

    //     // extern NSString *const _Nonnull regexForVIN;
    //     [Field("regexForVIN", "__Internal")]
    //     NSString regexForVIN { get; }

    //     // extern NSString *const _Nonnull regexForIMEI;
    //     [Field("regexForIMEI", "__Internal")]
    //     NSString regexForIMEI { get; }

    //     // extern NSString *const _Nonnull charWhiteListForEmail;
    //     [Field("charWhiteListForEmail", "__Internal")]
    //     NSString charWhiteListForEmail { get; }

    //     // extern NSString *const _Nonnull charWhiteListForURL;
    //     [Field("charWhiteListForURL", "__Internal")]
    //     NSString charWhiteListForURL { get; }

    //     // extern NSString *const _Nonnull charWhiteListForPriceTag;
    //     [Field("charWhiteListForPriceTag", "__Internal")]
    //     NSString charWhiteListForPriceTag { get; }

    //     // extern NSString *const _Nonnull charWhiteListForISBN;
    //     [Field("charWhiteListForISBN", "__Internal")]
    //     NSString charWhiteListForISBN { get; }

    //     // extern NSString *const _Nonnull charWhiteListForVIN;
    //     [Field("charWhiteListForVIN", "__Internal")]
    //     NSString charWhiteListForVIN { get; }

    //     // extern NSString *const _Nonnull charWhiteListForIMEI;
    //     [Field("charWhiteListForIMEI", "__Internal")]
    //     NSString charWhiteListForIMEI { get; }
    // }

    // // @interface ALOCRConfig : ALBaseOCRConfig
    // [BaseType(typeof(ALBaseOCRConfig))]
    // interface ALOCRConfig
    // {
    //     // -(instancetype _Nullable)initWithJsonDictionary:(NSDictionary * _Nonnull)configDict;
    //     [Export("initWithJsonDictionary:")]
    //     IntPtr Constructor(NSDictionary configDict);

    //     // -(instancetype _Nullable)initWithJsonDictionary:(NSDictionary * _Nonnull)configDict error:(NSError * _Nullable * _Nullable)error;
    //     [Export("initWithJsonDictionary:error:")]
    //     IntPtr Constructor(NSDictionary configDict, [NullAllowed] out NSError error);

    //     // @property (assign, nonatomic) ALOCRScanMode scanMode;
    //     [Export("scanMode", ArgumentSemantic.Assign)]
    //     ALOCRScanMode ScanMode { get; set; }

    //     // @property (nonatomic, strong) NSString * _Nullable customCmdFilePath;
    //     [NullAllowed, Export("customCmdFilePath", ArgumentSemantic.Strong)]
    //     string CustomCmdFilePath { get; set; }

    //     // @property (nonatomic, strong) NSString * _Nullable customCmdFileString;
    //     [NullAllowed, Export("customCmdFileString", ArgumentSemantic.Strong)]
    //     string CustomCmdFileString { get; set; }

    //     // @property (assign, nonatomic) ALRange charHeight;
    //     [Export("charHeight", ArgumentSemantic.Assign)]
    //     ALRange CharHeight { get; set; }

    //     // @property (nonatomic, strong) NSArray<NSString *> * _Nullable tesseractLanguages __attribute__((deprecated("Deprecated since 3.20. Use languages instead! This method still requires a copy of the traineddata.")));
    //     //[Obsolete("", false)]
    //     //[NullAllowed, Export("tesseractLanguages", ArgumentSemantic.Strong)]
    //     //string[] TesseractLanguages { get; set; }

    //     // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable languages;
    //     [NullAllowed, Export("languages", ArgumentSemantic.Copy)]
    //     string[] Languages { get; }

    //     // -(void)setLanguages:(NSArray<NSString *> * _Nonnull)languages __attribute__((deprecated("Deprecated since 4. Use languages - (BOOL)setLanguages:(NSArray<NSString *> *)languages error:(NSError *)error")));
    //     //[Obsolete("", false)]
    //     //[Export("setLanguages:")]
    //     //void SetLanguages(string[] languages);

    //     // -(BOOL)setLanguages:(NSArray<NSString *> * _Nonnull)languages error:(NSError * _Nullable * _Nullable)error;
    //     [Export("setLanguages:error:")]
    //     bool SetLanguages(string[] languages, [NullAllowed] out NSError error);

    //     // @property (nonatomic, strong) NSString * _Nullable charWhiteList;
    //     [NullAllowed, Export("charWhiteList", ArgumentSemantic.Strong)]
    //     string CharWhiteList { get; set; }

    //     // @property (nonatomic, strong) NSString * _Nullable validationRegex;
    //     [NullAllowed, Export("validationRegex", ArgumentSemantic.Strong)]
    //     string ValidationRegex { get; set; }

    //     // @property (assign, nonatomic) NSUInteger minConfidence;
    //     [Export("minConfidence")]
    //     nuint MinConfidence { get; set; }

    //     // @property (assign, nonatomic) BOOL removeSmallContours;
    //     [Export("removeSmallContours")]
    //     bool RemoveSmallContours { get; set; }

    //     // @property (assign, nonatomic) BOOL removeWhitespaces;
    //     [Export("removeWhitespaces")]
    //     bool RemoveWhitespaces { get; set; }

    //     // @property (assign, nonatomic) NSUInteger minSharpness;
    //     [Export("minSharpness")]
    //     nuint MinSharpness { get; set; }

    //     // @property (assign, nonatomic) NSUInteger charCountX;
    //     [Export("charCountX")]
    //     nuint CharCountX { get; set; }

    //     // @property (assign, nonatomic) NSUInteger charCountY;
    //     [Export("charCountY")]
    //     nuint CharCountY { get; set; }

    //     // @property (assign, nonatomic) double charPaddingXFactor;
    //     [Export("charPaddingXFactor")]
    //     double CharPaddingXFactor { get; set; }

    //     // @property (assign, nonatomic) double charPaddingYFactor;
    //     [Export("charPaddingYFactor")]
    //     double CharPaddingYFactor { get; set; }

    //     // @property (assign, nonatomic) BOOL isBrightTextOnDark;
    //     [Export("isBrightTextOnDark")]
    //     bool IsBrightTextOnDark { get; set; }

    //     // -(NSDictionary * _Nullable)startVariablesOrError:(NSError * _Nullable * _Nullable)error;
    //     [Export("startVariablesOrError:")]
    //     [return: NullAllowed]
    //     NSDictionary StartVariablesOrError([NullAllowed] out NSError error);

    //     // -(NSString * _Nullable)toJsonString;
    //     [NullAllowed, Export("toJsonString")]

    //     string ToJsonString { get; }

    //     // -(BOOL)allLanguagesAnyFiles;
    //     [Export("allLanguagesAnyFiles")]

    //     bool AllLanguagesAnyFiles { get; }
    // }

    // // @interface ALVINConfig : ALBaseOCRConfig
    // [BaseType(typeof(ALBaseOCRConfig))]
    // interface ALVINConfig
    // {
    //     // @property (assign, nonatomic) NSString * _Nullable validationRegex;
    //     [NullAllowed, Export("validationRegex")]
    //     string ValidationRegex { get; set; }

    //     // @property (assign, nonatomic) NSString * _Nullable characterWhitelist;
    //     [NullAllowed, Export("characterWhitelist")]
    //     string CharacterWhitelist { get; set; }
    // }

    // // @interface ALContainerConfig : ALBaseOCRConfig
    // [BaseType(typeof(ALBaseOCRConfig))]
    // interface ALContainerConfig
    // {
    //     // @property (assign, nonatomic) ALContainerScanMode scanMode;
    //     [Export("scanMode", ArgumentSemantic.Assign)]
    //     ALContainerScanMode ScanMode { get; set; }

    //     // @property (assign, nonatomic) NSString * _Nullable validationRegex;
    //     [NullAllowed, Export("validationRegex")]
    //     string ValidationRegex { get; set; }

    //     // @property (assign, nonatomic) NSString * _Nullable characterWhitelist;
    //     [NullAllowed, Export("characterWhitelist")]
    //     string CharacterWhitelist { get; set; }
    // }

    // // @interface ALCattleTagConfig : ALBaseOCRConfig
    // [BaseType(typeof(ALBaseOCRConfig))]
    // interface ALCattleTagConfig
    // {
    // }

    // // @interface ALBaseTireConfig : ALBaseOCRConfig
    // [BaseType (typeof(ALBaseOCRConfig))]
    // interface ALBaseTireConfig
    // {
    //     // -(instancetype _Nullable)initWithJsonDictionary:(NSDictionary * _Nonnull)configDict;
    //     [Export ("initWithJsonDictionary:")]
    //     IntPtr Constructor (NSDictionary configDict);
    // }

    // // @interface ALTINConfig : ALBaseTireConfig
    // [BaseType (typeof(ALBaseTireConfig))]
    // interface ALTINConfig
    // {
    //     // @property (assign, nonatomic) ALTINScanMode scanMode;
    //     [Export ("scanMode", ArgumentSemantic.Assign)]
    //     ALTINScanMode ScanMode { get; set; }

    //     // @property (assign, nonatomic) ALTINUpsideDownMode upsideDownMode;
    //     [Export ("upsideDownMode", ArgumentSemantic.Assign)]
    //     ALTINUpsideDownMode UpsideDownMode { get; set; }

    //     // @property (assign, nonatomic) NSUInteger minConfidence;
    //     [Export ("minConfidence")]
    //     nuint MinConfidence { get; set; }
    // }

    // // @interface ALOCRScanPlugin : ALAbstractScanPlugin
    // [BaseType(typeof(ALAbstractScanPlugin))]
    // [DisableDefaultCtor]
    // interface ALOCRScanPlugin
    // {
    //     // -(instancetype _Nullable)initWithPluginID:(NSString * _Nullable)pluginID delegate:(id<ALOCRScanPluginDelegate> _Nonnull)delegate ocrConfig:(ALBaseOCRConfig * _Nonnull)ocrConfig error:(NSError * _Nullable * _Nullable)error;
    //     [Export ("initWithPluginID:delegate:ocrConfig:error:")]
    //     IntPtr Constructor ([NullAllowed] string pluginID, NSObject @delegate, ALBaseOCRConfig ocrConfig, [NullAllowed] out NSError error);

    //     // @property (readonly, nonatomic, strong) NSHashTable<ALOCRScanPluginDelegate> * _Nullable delegates;
    //     [NullAllowed, Export("delegates", ArgumentSemantic.Strong)]
    //     NSSet Delegates { get; }

    //     // @property (readonly, nonatomic, strong) ALOCRConfig * _Nullable ocrConfig;
    //     [NullAllowed, Export("ocrConfig", ArgumentSemantic.Strong)]
    //     ALOCRConfig OcrConfig { get; }

    //     // -(BOOL)setOCRConfig:(ALOCRConfig * _Nonnull)ocrConfig error:(NSError * _Nullable * _Nullable)error;
    //     [Export("setOCRConfig:error:")]
    //     bool SetOCRConfig(ALOCRConfig ocrConfig, [NullAllowed] out NSError error);

    //     // -(void)addDelegate:(id<ALOCRScanPluginDelegate> _Nonnull)delegate;
    //     [Export("addDelegate:")]
    //     void AddDelegate(NSObject @delegate);

    //     // -(void)removeDelegate:(id<ALOCRScanPluginDelegate> _Nonnull)delegate;
    //     [Export("removeDelegate:")]
    //     void RemoveDelegate(NSObject @delegate);
    // }

    // // @protocol ALOCRScanPluginDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface ALOCRScanPluginDelegate
    // {
    //     // @required -(void)anylineOCRScanPlugin:(ALOCRScanPlugin * _Nonnull)anylineOCRScanPlugin didFindResult:(ALOCRResult * _Nonnull)result;
    //     [Abstract]
    //     [Export("anylineOCRScanPlugin:didFindResult:")]
    //     void DidFindResult(ALOCRScanPlugin anylineOCRScanPlugin, ALOCRResult result);
    // }

    // // @interface ALTireResult : ALScanResult
    // [BaseType (typeof(ALScanResult))]
    // interface ALTireResult
    // {
    //     // @property (readonly, nonatomic, strong) UIImage * _Nullable thresholdedImage;
    //     [NullAllowed, Export ("thresholdedImage", ArgumentSemantic.Strong)]
    //     UIImage ThresholdedImage { get; }

    //     // -(instancetype _Nullable)initWithResult:(NSString * _Nonnull)result image:(UIImage * _Nonnull)image fullImage:(UIImage * _Nullable)fullImage confidence:(NSInteger)confidence pluginID:(NSString * _Nonnull)pluginID thresholdedImage:(UIImage * _Nullable)thresholdedImage;
    //     [Export ("initWithResult:image:fullImage:confidence:pluginID:thresholdedImage:")]
    //     IntPtr Constructor (string result, UIImage image, [NullAllowed] UIImage fullImage, nint confidence, string pluginID, [NullAllowed] UIImage thresholdedImage);
    // }

    // // @interface ALTireConfig : ALBaseTireConfig
    // [BaseType (typeof(ALBaseTireConfig))]
    // interface ALTireConfig
    // {
    //     // -(instancetype _Nullable)initWithJsonDictionary:(NSDictionary * _Nonnull)configDict error:(NSError * _Nullable * _Nullable)error;
    //     [Export ("initWithJsonDictionary:error:")]
    //     IntPtr Constructor (NSDictionary configDict, [NullAllowed] out NSError error);

    //     // @property (nonatomic, strong) NSString * _Nullable customCmdFilePath;
    //     [NullAllowed, Export ("customCmdFilePath", ArgumentSemantic.Strong)]
    //     string CustomCmdFilePath { get; set; }

    //     // @property (nonatomic, strong) NSString * _Nullable customCmdFileString;
    //     [NullAllowed, Export ("customCmdFileString", ArgumentSemantic.Strong)]
    //     string CustomCmdFileString { get; set; }

    //     // @property (assign, nonatomic) NSUInteger minConfidence;
    //     [Export ("minConfidence")]
    //     nuint MinConfidence { get; set; }

    //     // -(NSDictionary * _Nullable)startVariablesOrError:(NSError * _Nullable * _Nullable)error assetPath:(NSString * _Nullable)assetPath;
    //     [Export ("startVariablesOrError:assetPath:")]
    //     [return: NullAllowed]
    //     NSDictionary StartVariablesOrError ([NullAllowed] out NSError error, [NullAllowed] string assetPath);

    //     // -(NSString * _Nullable)toJsonString;
    //     [NullAllowed, Export ("toJsonString")]
    //     string ToJsonString { get; }
    // }

    // // @interface ALTireSizeConfig : ALBaseTireConfig
    // [BaseType (typeof(ALBaseTireConfig))]
    // interface ALTireSizeConfig
    // {
    //     // @property (assign, nonatomic) ALTINUpsideDownMode upsideDownMode;
    //     [Export ("upsideDownMode", ArgumentSemantic.Assign)]
    //     ALTINUpsideDownMode UpsideDownMode { get; set; }

    //     // @property (assign, nonatomic) NSUInteger minConfidence;
    //     [Export ("minConfidence")]
    //     nuint MinConfidence { get; set; }
    // }

    // // @interface ALCommercialTireIdConfig : ALBaseTireConfig
    // [BaseType (typeof(ALBaseTireConfig))]
    // interface ALCommercialTireIdConfig
    // {
    //     // @property (assign, nonatomic) NSUInteger minConfidence;
    //     [Export ("minConfidence")]
    //     nuint MinConfidence { get; set; }
    // }

    // // @interface ALTireScanPlugin : ALAbstractScanPlugin
    // [BaseType (typeof(ALAbstractScanPlugin))]
    // [DisableDefaultCtor]
    // interface ALTireScanPlugin
    // {
    //     // -(instancetype _Nullable)initWithPluginID:(NSString * _Nullable)pluginID delegate:(id<ALTireScanPluginDelegate> _Nonnull)delegate tireConfig:(ALBaseTireConfig * _Nonnull)tireConfig error:(NSError * _Nullable * _Nullable)error;
    //     [Export ("initWithPluginID:delegate:tireConfig:error:")]
    //     IntPtr Constructor ([NullAllowed] string pluginID, ALTireScanPluginDelegate @delegate, ALBaseTireConfig tireConfig, [NullAllowed] out NSError error);

    //     // @property (readonly, nonatomic, strong) NSPointerArray<ALTireScanPluginDelegate> * _Nullable delegates;
    //     [NullAllowed, Export ("delegates", ArgumentSemantic.Strong)]
    //     ALTireScanPluginDelegate Delegates { get; }

    //     // @property (readonly, nonatomic, strong) ALBaseTireConfig * _Nullable tireConfig;
    //     [NullAllowed, Export ("tireConfig", ArgumentSemantic.Strong)]
    //     ALBaseTireConfig TireConfig { get; }

    //     // -(BOOL)setTireConfig:(ALBaseTireConfig * _Nonnull)tireConfig error:(NSError * _Nullable * _Nullable)error;
    //     [Export ("setTireConfig:error:")]
    //     bool SetTireConfig (ALBaseTireConfig tireConfig, [NullAllowed] out NSError error);

    //     // -(void)addDelegate:(id<ALTireScanPluginDelegate> _Nonnull)delegate;
    //     [Export ("addDelegate:")]
    //     void AddDelegate (ALTireScanPluginDelegate @delegate);

    //     // -(void)removeDelegate:(id<ALTireScanPluginDelegate> _Nonnull)delegate;
    //     [Export ("removeDelegate:")]
    //     void RemoveDelegate (ALTireScanPluginDelegate @delegate);
    // }

    // // @protocol ALTireScanPluginDelegate <NSObject>
    // [Protocol, Model (AutoGeneratedName = true)]
    // [BaseType (typeof(NSObject))]
    // interface ALTireScanPluginDelegate
    // {
    //     // @required -(void)anylineTireScanPlugin:(ALTireScanPlugin * _Nonnull)anylineTireScanPlugin didFindResult:(ALTireResult * _Nonnull)result;
    //     [Abstract]
    //     [Export ("anylineTireScanPlugin:didFindResult:")]
    //     void DidFindResult (ALTireScanPlugin anylineTireScanPlugin, ALTireResult result);

    //     // @optional -(void)anylineTireScanPlugin:(ALTireScanPlugin * _Nonnull)anylineTireScanPlugin tireConfigUpdated:(ALBaseTireConfig * _Nullable)tireConfig;
    //     [Export ("anylineTireScanPlugin:tireConfigUpdated:")]
    //     void TireConfigUpdated (ALTireScanPlugin anylineTireScanPlugin, [NullAllowed] ALBaseTireConfig tireConfig);
    // }

    // // @interface ALOCRScanViewPlugin : ALAbstractScanViewPlugin
    // [BaseType(typeof(ALAbstractScanViewPlugin))]
    // interface ALOCRScanViewPlugin
    // {
    //     // @property (nonatomic, strong) ALOCRScanPlugin * _Nullable ocrScanPlugin;
    //     [NullAllowed, Export("ocrScanPlugin", ArgumentSemantic.Strong)]
    //     ALOCRScanPlugin OcrScanPlugin { get; set; }

    //     // -(instancetype _Nullable)initWithScanPlugin:(ALOCRScanPlugin * _Nonnull)ocrScanPlugin;
    //     [Export("initWithScanPlugin:")]
    //     IntPtr Constructor(ALOCRScanPlugin ocrScanPlugin);

    //     // -(instancetype _Nullable)initWithScanPlugin:(ALOCRScanPlugin * _Nonnull)ocrScanPlugin scanViewPluginConfig:(ALScanViewPluginConfig * _Nonnull)scanViewPluginConfig;
    //     [Export("initWithScanPlugin:scanViewPluginConfig:")]
    //     IntPtr Constructor(ALOCRScanPlugin ocrScanPlugin, ALScanViewPluginConfig scanViewPluginConfig);
    // }

    // // @interface ALTireScanViewPlugin : ALAbstractScanViewPlugin
    // [BaseType (typeof(ALAbstractScanViewPlugin))]
    // interface ALTireScanViewPlugin
    // {
    //     // @property (nonatomic, strong) ALTireScanPlugin * _Nullable tireScanPlugin;
    //     [NullAllowed, Export ("tireScanPlugin", ArgumentSemantic.Strong)]
    //     ALTireScanPlugin TireScanPlugin { get; set; }

    //     // -(instancetype _Nullable)initWithScanPlugin:(ALTireScanPlugin * _Nonnull)tireScanPlugin;
    //     [Export ("initWithScanPlugin:")]
    //     IntPtr Constructor (ALTireScanPlugin tireScanPlugin);

    //     // -(instancetype _Nullable)initWithScanPlugin:(ALTireScanPlugin * _Nonnull)tireScanPlugin scanViewPluginConfig:(ALScanViewPluginConfig * _Nonnull)scanViewPluginConfig;
    //     [Export ("initWithScanPlugin:scanViewPluginConfig:")]
    //     IntPtr Constructor (ALTireScanPlugin tireScanPlugin, ALScanViewPluginConfig scanViewPluginConfig);
    // }

    // partial interface Constants
    // {
    //     // extern const CGFloat ALDocumentRatioDINAXLandscape;
    //     [Field("ALDocumentRatioDINAXLandscape", "__Internal")]
    //     nfloat ALDocumentRatioDINAXLandscape { get; }

    //     // extern const CGFloat ALDocumentRatioDINAXPortrait;
    //     [Field("ALDocumentRatioDINAXPortrait", "__Internal")]
    //     nfloat ALDocumentRatioDINAXPortrait { get; }

    //     // extern const CGFloat ALDocumentRatioCompimentsSlipLandscape;
    //     [Field("ALDocumentRatioCompimentsSlipLandscape", "__Internal")]
    //     nfloat ALDocumentRatioCompimentsSlipLandscape { get; }

    //     // extern const CGFloat ALDocumentRatioCompimentsSlipPortrait;
    //     [Field("ALDocumentRatioCompimentsSlipPortrait", "__Internal")]
    //     nfloat ALDocumentRatioCompimentsSlipPortrait { get; }

    //     // extern const CGFloat ALDocumentRatioBusinessCardLandscape;
    //     [Field("ALDocumentRatioBusinessCardLandscape", "__Internal")]
    //     nfloat ALDocumentRatioBusinessCardLandscape { get; }

    //     // extern const CGFloat ALDocumentRatioBusinessCardPortrait;
    //     [Field("ALDocumentRatioBusinessCardPortrait", "__Internal")]
    //     nfloat ALDocumentRatioBusinessCardPortrait { get; }

    //     // extern const CGFloat ALDocumentRatioLetterLandscape;
    //     [Field("ALDocumentRatioLetterLandscape", "__Internal")]
    //     nfloat ALDocumentRatioLetterLandscape { get; }

    //     // extern const CGFloat ALDocumentRatioLetterPortrait;
    //     [Field("ALDocumentRatioLetterPortrait", "__Internal")]
    //     nfloat ALDocumentRatioLetterPortrait { get; }
    // }

    // // @interface ALDocumentScanPlugin : NSObject
    // [BaseType(typeof(NSObject))]
    // [DisableDefaultCtor]
    // interface ALDocumentScanPlugin
    // {
    //     // @property (readonly, nonatomic, strong) NSHashTable<ALDocumentScanPluginDelegate> * _Nullable delegates;
    //     [NullAllowed, Export("delegates", ArgumentSemantic.Strong)]
    //     NSSet Delegates { get; }

    //     // @property (readonly, nonatomic, strong) NSHashTable<ALDocumentInfoDelegate> * _Nullable infoDelegates;
    //     [NullAllowed, Export("infoDelegates", ArgumentSemantic.Strong)]
    //     NSSet InfoDelegates { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable pluginID;
    //     [NullAllowed, Export("pluginID", ArgumentSemantic.Strong)]
    //     string PluginID { get; }

    //     // @property (readonly, nonatomic, strong) ALImage * _Nullable scanImage;
    //     [NullAllowed, Export("scanImage", ArgumentSemantic.Strong)]
    //     ALImage ScanImage { get; }

    //     // @property (nonatomic, strong) ALCoreController * _Nullable coreController;
    //     [NullAllowed, Export("coreController", ArgumentSemantic.Strong)]
    //     ALCoreController CoreController { get; set; }

    //     // @property (assign, nonatomic) id<ALImageProvider> _Nullable imageProvider;
    //     [NullAllowed, Export("imageProvider", ArgumentSemantic.Assign)]
    //     IALImageProvider ImageProvider { get; set; }

    //     // @property (assign, atomic) BOOL justDetectCornersIfPossible;
    //     [Export("justDetectCornersIfPossible")]
    //     bool JustDetectCornersIfPossible { get; set; }

    //     // -(instancetype _Nullable)initWithPluginID:(NSString * _Nullable)pluginID delegate:(id<ALDocumentScanPluginDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
    //     [Export ("initWithPluginID:delegate:error:")]
    //     [DesignatedInitializer]
    //     IntPtr Constructor ([NullAllowed] string pluginID, NSObject @delegate, [NullAllowed] out NSError error);

    //     // -(BOOL)start:(id<ALImageProvider> _Nonnull)imageProvider error:(NSError * _Nullable * _Nullable)error;
    //     [Export("start:error:")]
    //     bool Start(IALImageProvider imageProvider, [NullAllowed] out NSError error);

    //     // -(BOOL)stopAndReturnError:(NSError * _Nullable * _Nullable)error;
    //     [Export("stopAndReturnError:")]
    //     bool StopAndReturnError([NullAllowed] out NSError error);

    //     // -(void)enableReporting:(BOOL)enable;
    //     [Export("enableReporting:")]
    //     void EnableReporting(bool enable);

    //     // -(BOOL)isRunning;
    //     [Export("isRunning")]

    //     bool IsRunning { get; }

    //     // -(BOOL)triggerPictureCornerDetectionAndReturnError:(NSError * _Nullable * _Nullable)error;
    //     [Export("triggerPictureCornerDetectionAndReturnError:")]
    //     bool TriggerPictureCornerDetectionAndReturnError([NullAllowed] out NSError error);

    //     // -(BOOL)transformImageWithSquare:(ALSquare * _Nullable)square image:(UIImage * _Nullable)image error:(NSError * _Nullable * _Nullable)error;
    //     [Export("transformImageWithSquare:image:error:")]
    //     bool TransformImageWithSquare([NullAllowed] ALSquare square, [NullAllowed] UIImage image, [NullAllowed] out NSError error);

    //     // -(BOOL)transformALImageWithSquare:(ALSquare * _Nullable)square image:(ALImage * _Nullable)image error:(NSError * _Nullable * _Nullable)error;
    //     [Export("transformALImageWithSquare:image:error:")]
    //     bool TransformALImageWithSquare([NullAllowed] ALSquare square, [NullAllowed] ALImage image, [NullAllowed] out NSError error);

    //     // @property (nonatomic, strong) NSNumber * _Nonnull maxDocumentRatioDeviation;
    //     [Export("maxDocumentRatioDeviation", ArgumentSemantic.Strong)]
    //     NSNumber MaxDocumentRatioDeviation { get; set; }

    //     // @property (assign, nonatomic) CGSize maxOutputResolution;
    //     [Export("maxOutputResolution", ArgumentSemantic.Assign)]
    //     CGSize MaxOutputResolution { get; set; }

    //     // @property (nonatomic, strong) NSArray<NSNumber *> * _Nullable documentRatios;
    //     [NullAllowed, Export("documentRatios", ArgumentSemantic.Strong)]
    //     NSNumber[] DocumentRatios { get; set; }

    //     // @property (assign, nonatomic) BOOL postProcessingEnabled;
    //     [Export("postProcessingEnabled")]
    //     bool PostProcessingEnabled { get; set; }

    //     // -(void)addDelegate:(id<ALDocumentScanPluginDelegate> _Nonnull)delegate;
    //     [Export("addDelegate:")]
    //     void AddDelegate(NSObject @delegate);

    //     // -(void)removeDelegate:(id<ALDocumentScanPluginDelegate> _Nonnull)delegate;
    //     [Export("removeDelegate:")]
    //     void RemoveDelegate(NSObject @delegate);

    //     // -(void)addInfoDelegate:(id<ALDocumentInfoDelegate> _Nonnull)infoDelegate;
    //     [Export("addInfoDelegate:")]
    //     void AddInfoDelegate(ALDocumentInfoDelegate infoDelegate);

    //     // -(void)removeInfoDelegate:(id<ALDocumentInfoDelegate> _Nonnull)infoDelegate;
    //     [Export("removeInfoDelegate:")]
    //     void RemoveInfoDelegate(ALDocumentInfoDelegate infoDelegate);
    // }

    // // @protocol ALDocumentScanPluginDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface ALDocumentScanPluginDelegate
    // {
    //     // @required -(void)anylineDocumentScanPlugin:(ALDocumentScanPlugin * _Nonnull)anylineDocumentScanPlugin hasResult:(UIImage * _Nonnull)transformedImage fullImage:(UIImage * _Nonnull)fullFrame documentCorners:(ALSquare * _Nonnull)corners;
    //     [Abstract]
    //     [Export("anylineDocumentScanPlugin:hasResult:fullImage:documentCorners:")]
    //     void HasResult(ALDocumentScanPlugin anylineDocumentScanPlugin, UIImage transformedImage, UIImage fullFrame, ALSquare corners);
    // }

    // // @protocol ALDocumentInfoDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface ALDocumentInfoDelegate
    // {
    //     // @optional -(void)anylineDocumentScanPlugin:(ALDocumentScanPlugin * _Nonnull)anylineDocumentScanPlugin detectedPictureCorners:(ALSquare * _Nonnull)corners inImage:(UIImage * _Nonnull)image;
    //     [Export("anylineDocumentScanPlugin:detectedPictureCorners:inImage:")]
    //     void DetectedPictureCorners(ALDocumentScanPlugin anylineDocumentScanPlugin, ALSquare corners, UIImage image);

    //     // @optional -(void)anylineDocumentScanPlugin:(ALDocumentScanPlugin * _Nonnull)anylineDocumentScanPlugin reportsPreviewResult:(UIImage * _Nonnull)image;
    //     [Export("anylineDocumentScanPlugin:reportsPreviewResult:")]
    //     void ReportsPreviewResult(ALDocumentScanPlugin anylineDocumentScanPlugin, UIImage image);

    //     // @optional -(void)anylineDocumentScanPlugin:(ALDocumentScanPlugin * _Nonnull)anylineDocumentScanPlugin reportsPreviewProcessingFailure:(ALDocumentError)error;
    //     [Export("anylineDocumentScanPlugin:reportsPreviewProcessingFailure:")]
    //     void ReportsPreviewProcessingFailure(ALDocumentScanPlugin anylineDocumentScanPlugin, ALDocumentError error);

    //     // @optional -(void)anylineDocumentScanPlugin:(ALDocumentScanPlugin * _Nonnull)anylineDocumentScanPlugin reportsPictureProcessingFailure:(ALDocumentError)error;
    //     [Export("anylineDocumentScanPlugin:reportsPictureProcessingFailure:")]
    //     void ReportsPictureProcessingFailure(ALDocumentScanPlugin anylineDocumentScanPlugin, ALDocumentError error);

    //     // @optional -(void)anylineDocumentScanPlugin:(ALDocumentScanPlugin * _Nonnull)anylineDocumentScanPlugin reportInfo:(ALScanInfo * _Nonnull)scanInfo;
    //     [Export("anylineDocumentScanPlugin:reportInfo:")]
    //     void ReportInfo(ALDocumentScanPlugin anylineDocumentScanPlugin, ALScanInfo scanInfo);
    // }

    // // @interface ALDocumentScanViewPlugin : ALAbstractScanViewPlugin
    // [BaseType(typeof(ALAbstractScanViewPlugin))]
    // interface ALDocumentScanViewPlugin
    // {
    //     // @property (nonatomic, strong) ALDocumentScanPlugin * _Nullable documentScanPlugin;
    //     [NullAllowed, Export("documentScanPlugin", ArgumentSemantic.Strong)]
    //     ALDocumentScanPlugin DocumentScanPlugin { get; set; }

    //     // -(instancetype _Nullable)initWithScanPlugin:(ALDocumentScanPlugin * _Nonnull)documentScanPlugin;
    //     [Export("initWithScanPlugin:")]
    //     IntPtr Constructor(ALDocumentScanPlugin documentScanPlugin);

    //     // -(instancetype _Nullable)initWithScanPlugin:(ALDocumentScanPlugin * _Nonnull)documentScanPlugin scanViewPluginConfig:(ALScanViewPluginConfig * _Nonnull)scanViewPluginConfig;
    //     [Export("initWithScanPlugin:scanViewPluginConfig:")]
    //     IntPtr Constructor(ALDocumentScanPlugin documentScanPlugin, ALScanViewPluginConfig scanViewPluginConfig);
    // }

    // // @interface ALLicensePlateResult : ALScanResult
    // [BaseType(typeof(ALScanResult))]
    // interface ALLicensePlateResult
    // {
    //     // @property (readonly, nonatomic, strong) NSString * _Nullable country;
    //     [NullAllowed, Export ("country", ArgumentSemantic.Strong)]
    //     string Country { get; }

    //     // @property (readonly, nonatomic, strong) NSString * _Nullable area;
    //     [NullAllowed, Export ("area", ArgumentSemantic.Strong)]
    //     string Area { get; }
        
    //     // -(instancetype _Nullable)initWithResult:(NSString * _Nonnull)result image:(UIImage * _Nonnull)image fullImage:(UIImage * _Nullable)fullImage confidence:(NSInteger)confidence pluginID:(NSString * _Nonnull)pluginID country:(NSString * _Nullable)country;
    //     [Export("initWithResult:image:fullImage:confidence:pluginID:country:")]
    //     IntPtr Constructor(string result, UIImage image, [NullAllowed] UIImage fullImage, nint confidence, string pluginID, [NullAllowed] string country);
    // }

    // // @interface ALLicensePlateScanPlugin : ALAbstractScanPlugin
    // [BaseType(typeof(ALAbstractScanPlugin))]
    // [DisableDefaultCtor]
    // interface ALLicensePlateScanPlugin
    // {
    //     // -(instancetype _Nullable)initWithPluginID:(NSString * _Nullable)pluginID delegate:(id<ALLicensePlateScanPluginDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
    //     [Export ("initWithPluginID:delegate:error:")]
    //     [DesignatedInitializer]
    //     IntPtr Constructor ([NullAllowed] string pluginID, NSObject @delegate, [NullAllowed] out NSError error);

	// 	// @property (readonly, assign, nonatomic) ALLicensePlateScanMode scanMode;
	// 	[Export ("scanMode", ArgumentSemantic.Assign)]
	// 	ALLicensePlateScanMode ScanMode { get; }

	// 	// -(BOOL)setScanMode:(ALLicensePlateScanMode)scanMode error:(NSError * _Nullable * _Nullable)error;
	// 	[Export ("setScanMode:error:")]
	// 	bool SetScanMode (ALLicensePlateScanMode scanMode, [NullAllowed] out NSError error);

    //     // -(void)addDelegate:(id<ALLicensePlateScanPluginDelegate> _Nonnull)delegate;
    //     [Export("addDelegate:")]
    //     void AddDelegate(NSObject @delegate);

    //     // -(void)removeDelegate:(id<ALLicensePlateScanPluginDelegate> _Nonnull)delegate;
    //     [Export("removeDelegate:")]
    //     void RemoveDelegate(NSObject @delegate);

    //     // -(ALLicensePlateScanMode)parseScanModeString:(NSString * _Nonnull)scanModeString;
    //     [Export("parseScanModeString:")]
    //     ALLicensePlateScanMode ParseScanModeString(string scanModeString);

    //     // -(void)addValidationRegexEntry:(NSString * _Nullable)validationRegex forCountry:(ALLicensePlateScanMode)scanMode;
    //     [Export("addValidationRegexEntry:forCountry:")]
    //     void AddValidationRegexEntry([NullAllowed] string validationRegex, ALLicensePlateScanMode scanMode);

    //     // -(void)removeValidationRegexEntryForCountry:(ALLicensePlateScanMode)scanMode;
    //     [Export("removeValidationRegexEntryForCountry:")]
    //     void RemoveValidationRegexEntryForCountry(ALLicensePlateScanMode scanMode);

    //     // - (NSMutableDictionary<NSString *,NSString *> * _Nullable)validationRegex;
    //     [NullAllowed, Export("validationRegex")]
    //     NSMutableDictionary<NSString, NSString> ValidationRegex { get; }

    //     // -(void)addCharacterWhiteListEntry:(NSString * _Nullable)characterWhiteList forCountry:(ALLicensePlateScanMode)scanMode;
    //     [Export("addCharacterWhiteListEntry:forCountry:")]
    //     void AddCharacterWhiteListEntry([NullAllowed] string characterWhiteList, ALLicensePlateScanMode scanMode);

    //     // -(void)removeCharacterWhiteListEntryForCountry:(ALLicensePlateScanMode)scanMode;
    //     [Export("removeCharacterWhiteListEntryForCountry:")]
    //     void RemoveCharacterWhiteListEntryForCountry(ALLicensePlateScanMode scanMode);

    //     // - (NSMutableDictionary<NSString *,NSString *> * _Nullable)characterWhitelist;
    //     [NullAllowed, Export("characterWhitelist")]
    //     NSMutableDictionary<NSString, NSString> CharacterWhitelist { get; }
    // }

    // // @protocol ALLicensePlateScanPluginDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface ALLicensePlateScanPluginDelegate
    // {
    //     // @required -(void)anylineLicensePlateScanPlugin:(ALLicensePlateScanPlugin * _Nonnull)anylineLicensePlateScanPlugin didFindResult:(ALLicensePlateResult * _Nonnull)scanResult;
    //     [Abstract]
    //     [Export("anylineLicensePlateScanPlugin:didFindResult:")]
    //     void DidFindResult(ALLicensePlateScanPlugin anylineLicensePlateScanPlugin, ALLicensePlateResult scanResult);
    // }

    // // @interface ALLicensePlateScanViewPlugin : ALAbstractScanViewPlugin
    // [BaseType(typeof(ALAbstractScanViewPlugin))]
    // interface ALLicensePlateScanViewPlugin
    // {
    //     // @property (nonatomic, strong) ALLicensePlateScanPlugin * _Nullable licensePlateScanPlugin;
    //     [NullAllowed, Export("licensePlateScanPlugin", ArgumentSemantic.Strong)]
    //     ALLicensePlateScanPlugin LicensePlateScanPlugin { get; set; }

    //     // -(instancetype _Nullable)initWithScanPlugin:(ALLicensePlateScanPlugin * _Nonnull)licensePlateScanPlugin;
    //     [Export("initWithScanPlugin:")]
    //     IntPtr Constructor(ALLicensePlateScanPlugin licensePlateScanPlugin);

    //     // -(instancetype _Nullable)initWithScanPlugin:(ALLicensePlateScanPlugin * _Nonnull)licensePlateScanPlugin scanViewPluginConfig:(ALScanViewPluginConfig * _Nonnull)scanViewPluginConfig;
    //     [Export("initWithScanPlugin:scanViewPluginConfig:")]
    //     IntPtr Constructor(ALLicensePlateScanPlugin licensePlateScanPlugin, ALScanViewPluginConfig scanViewPluginConfig);
    // }

    // // @interface ALAbstractScanViewPluginComposite : ALAbstractScanViewPlugin
    // [BaseType(typeof(ALAbstractScanViewPlugin))]
    // interface ALAbstractScanViewPluginComposite
    // {
    //     // @property BOOL isRunning;
    //     [Export("isRunning")]
    //     bool IsRunning { get; set; }

    //     // @property (readonly, nonatomic) NSDictionary<NSString *,ALAbstractScanViewPlugin *> * _Nullable childPlugins;
    //     [NullAllowed, Export ("childPlugins")]
    //     NSDictionary<NSString, ALAbstractScanViewPlugin> ChildPlugins { get; }

    //     // -(void)addPlugin:(ALAbstractScanViewPlugin * _Nonnull)plugin;
    //     [Export("addPlugin:")]
    //     void AddPlugin(ALAbstractScanViewPlugin plugin);

    //     // -(void)removePlugin:(NSString * _Nonnull)pluginID;
    //     [Export("removePlugin:")]
    //     void RemovePlugin(string pluginID);

    //     // -(instancetype _Nonnull)initWithPluginID:(NSString * _Nonnull)pluginID;
    //     [Export("initWithPluginID:")]
    //     IntPtr Constructor(string pluginID);

    //     // -(void)addDelegate:(id<ALCompositeScanPluginDelegate> _Nonnull)delegate;
    //     [Export("addDelegate:")]
    //     void AddDelegate(NSObject @delegate);

    //     // -(void)removeDelegate:(id<ALCompositeScanPluginDelegate> _Nonnull)delegate;
    //     [Export("removeDelegate:")]
    //     void RemoveDelegate(NSObject @delegate);
    // }

    // // @interface ALSerialScanViewPluginComposite : ALAbstractScanViewPluginComposite
    // [BaseType(typeof(ALAbstractScanViewPluginComposite))]
    // interface ALSerialScanViewPluginComposite
    // {
    //     // -(BOOL)startFromID:(NSString * _Nonnull)pluginID andReturnError:(NSError * _Nullable * _Nullable)error;
    //     [Export("startFromID:andReturnError:")]
    //     bool StartFromID(string pluginID, [NullAllowed] out NSError error);
    // }

    // // @interface ALParallelScanViewPluginComposite : ALAbstractScanViewPluginComposite
    // [BaseType(typeof(ALAbstractScanViewPluginComposite))]
    // interface ALParallelScanViewPluginComposite
    // {
    // }

    // // @interface ALCompositeResult : ALScanResult
    // [BaseType(typeof(ALScanResult))]
    // interface ALCompositeResult
    // {
    // }

    // // @protocol ALCompositeScanPluginDelegate <NSObject>
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface ALCompositeScanPluginDelegate
    // {
    //     // @required -(void)anylineCompositeScanPlugin:(ALAbstractScanViewPluginComposite * _Nonnull)anylineCompositeScanPlugin didFindResult:(ALCompositeResult * _Nonnull)scanResult;
    //     [Abstract]
    //     [Export("anylineCompositeScanPlugin:didFindResult:")]
    //     void DidFindResult(ALAbstractScanViewPluginComposite anylineCompositeScanPlugin, ALCompositeResult scanResult);
    // }


    // // @interface ALDataGroup1 : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALDataGroup1
    // {
    //     // @property NSString * _Nonnull documentType;
    //     [Export("documentType")]
    //     string DocumentType { get; set; }

    //     // @property NSString * _Nonnull issuingStateCode;
    //     [Export("issuingStateCode")]
    //     string IssuingStateCode { get; set; }

    //     // @property NSString * _Nonnull documentNumber;
    //     [Export("documentNumber")]
    //     string DocumentNumber { get; set; }

    //     // @property NSDate * _Nonnull dateOfExpiry;
    //     [Export("dateOfExpiry", ArgumentSemantic.Assign)]
    //     NSDate DateOfExpiry { get; set; }

    //     // @property NSString * _Nonnull gender;
    //     [Export("gender")]
    //     string Gender { get; set; }

    //     // @property NSString * _Nonnull nationality;
    //     [Export("nationality")]
    //     string Nationality { get; set; }

    //     // @property NSString * _Nonnull lastName;
    //     [Export("lastName")]
    //     string LastName { get; set; }

    //     // @property NSString * _Nonnull firstName;
    //     [Export("firstName")]
    //     string FirstName { get; set; }

    //     // @property NSDate * _Nonnull dateOfBirth;
    //     [Export("dateOfBirth", ArgumentSemantic.Assign)]
    //     NSDate DateOfBirth { get; set; }

    //     // -(instancetype _Nonnull)initWithDocumentType:(NSString * _Nonnull)documentType issuingStateCode:(NSString * _Nonnull)issuingStateCode documentNumber:(NSString * _Nonnull)documentNumber dateOfExpiry:(NSDate * _Nonnull)dateOfExpiry gender:(NSString * _Nonnull)gender nationality:(NSString * _Nonnull)nationality lastName:(NSString * _Nonnull)lastName firstName:(NSString * _Nonnull)firstName dateOfBirth:(NSDate * _Nonnull)dateOfBirth;
    //     [Export("initWithDocumentType:issuingStateCode:documentNumber:dateOfExpiry:gender:nationality:lastName:firstName:dateOfBirth:")]
    //     IntPtr Constructor(string documentType, string issuingStateCode, string documentNumber, NSDate dateOfExpiry, string gender, string nationality, string lastName, string firstName, NSDate dateOfBirth);

    //     // -(instancetype _Nonnull)initWithPassportDataElements:(NSDictionary<NSString *,NSString *> * _Nonnull)passportDataElements;
    //     [Export("initWithPassportDataElements:")]
    //     IntPtr Constructor(NSDictionary<NSString, NSString> passportDataElements);
    // }

    // // @interface ALDataGroup2 : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALDataGroup2
    // {
    //     // @property UIImage * _Nonnull faceImage;
    //     [Export("faceImage", ArgumentSemantic.Assign)]
    //     UIImage FaceImage { get; set; }

    //     // -(instancetype _Nonnull)initWithFaceImage:(UIImage * _Nonnull)faceImage;
    //     [Export("initWithFaceImage:")]
    //     IntPtr Constructor(UIImage faceImage);
    // }

    // // @interface ALSOD : NSObject
    // [BaseType(typeof(NSObject))]
    // interface ALSOD
    // {
    //     // @property NSString * _Nonnull issuerCountry;
    //     [Export("issuerCountry")]
    //     string IssuerCountry { get; set; }

    //     // @property NSString * _Nonnull issuerCertificationAuthority;
    //     [Export("issuerCertificationAuthority")]
    //     string IssuerCertificationAuthority { get; set; }

    //     // @property NSString * _Nonnull issuerOrganization;
    //     [Export("issuerOrganization")]
    //     string IssuerOrganization { get; set; }

    //     // @property NSString * _Nonnull issuerOrganizationalUnit;
    //     [Export("issuerOrganizationalUnit")]
    //     string IssuerOrganizationalUnit { get; set; }

    //     // @property NSString * _Nonnull signatureAlgorithm;
    //     [Export("signatureAlgorithm")]
    //     string SignatureAlgorithm { get; set; }

    //     // @property NSString * _Nonnull ldsHashAlgorithm;
    //     [Export("ldsHashAlgorithm")]
    //     string LdsHashAlgorithm { get; set; }

    //     // @property NSString * _Nonnull validFromString;
    //     [Export("validFromString")]
    //     string ValidFromString { get; set; }

    //     // @property NSString * _Nonnull validUntilString;
    //     [Export("validUntilString")]
    //     string ValidUntilString { get; set; }
    // }

    // // @interface ALNFCResult : NSObject
    // [iOS(13, 0)]
    // [BaseType(typeof(NSObject))]
    // interface ALNFCResult
    // {
    //     // @property ALSOD * sod;
    //     [Export("sod", ArgumentSemantic.Assign)]
    //     ALSOD Sod { get; set; }

    //     // @property ALDataGroup1 * dataGroup1;
    //     [Export("dataGroup1", ArgumentSemantic.Assign)]
    //     ALDataGroup1 DataGroup1 { get; set; }

    //     // @property ALDataGroup2 * dataGroup2;
    //     [Export("dataGroup2", ArgumentSemantic.Assign)]
    //     ALDataGroup2 DataGroup2 { get; set; }

    //     // -(instancetype)initWithDataGroup1:(ALDataGroup1 *)dataGroup1 dataGroup2:(ALDataGroup2 *)dataGroup2 sod:(ALSOD *)sod;
    //     [Export("initWithDataGroup1:dataGroup2:sod:")]
    //     IntPtr Constructor(ALDataGroup1 dataGroup1, ALDataGroup2 dataGroup2, ALSOD sod);
    // }

    // // @protocol ALNFCDetectorDelegate <NSObject>
    // [iOS(13, 0)]
    // [Protocol, Model]
    // [BaseType(typeof(NSObject))]
    // interface ALNFCDetectorDelegate
    // {
    //     // @required -(void)nfcSucceededWithResult:(ALNFCResult * _Nonnull)nfcResult;
    //     [Abstract]
    //     [Export("nfcSucceededWithResult:")]
    //     void NfcSucceededWithResult(ALNFCResult nfcResult);

    //     // @required -(void)nfcFailedWithError:(NSError * _Nonnull)error;
    //     [Abstract]
    //     [Export("nfcFailedWithError:")]
    //     void NfcFailedWithError(NSError error);

    //     // @optional -(void)nfcSucceededWithDataGroup1:(ALDataGroup1 * _Nonnull)dataGroup1 __attribute__((availability(ios, introduced=13.0)));
    //     [iOS(13, 0)]
    //     [Export("nfcSucceededWithDataGroup1:")]
    //     void NfcSucceededWithDataGroup1(ALDataGroup1 dataGroup1);

    //     // @optional -(void)nfcSucceededWithDataGroup2:(ALDataGroup2 * _Nonnull)dataGroup2 __attribute__((availability(ios, introduced=13.0)));
    //     [iOS(13, 0)]
    //     [Export("nfcSucceededWithDataGroup2:")]
    //     void NfcSucceededWithDataGroup2(ALDataGroup2 dataGroup2);

    //     // @optional -(void)nfcSucceededWithSOD:(ALSOD * _Nonnull)sod __attribute__((availability(ios, introduced=13.0)));
    //     [iOS(13, 0)]
    //     [Export("nfcSucceededWithSOD:")]
    //     void NfcSucceededWithSOD(ALSOD sod);
    // }

    // // @interface ALNFCDetector : NSObject
    // [iOS(13, 0)]
    // [BaseType(typeof(NSObject))]
    // interface ALNFCDetector
    // {
    //     // +(BOOL)readingAvailable;
    //     [Static]
    //     [Export("readingAvailable")]
    //     bool ReadingAvailable { get; }

    //     // -(instancetype _Nullable)initWithDelegate:(id<ALNFCDetectorDelegate> _Nonnull)delegate;
    //     [Export("initWithDelegate:")]
    //     IntPtr Constructor(NSObject @delegate);

    //     // -(void)startNfcDetectionWithPassportNumber:(NSString * _Nonnull)passportNumber dateOfBirth:(NSDate * _Nonnull)dateOfBirth expirationDate:(NSDate * _Nonnull)expirationDate;
    //     [Export("startNfcDetectionWithPassportNumber:dateOfBirth:expirationDate:")]
    //     void StartNfcDetectionWithPassportNumber(string passportNumber, NSDate dateOfBirth, NSDate expirationDate);
    // }

    // // @interface AnylineSDK : NSObject
    // [BaseType(typeof(NSObject))]
    // interface AnylineSDK
    // {
    //     // +(BOOL)setupWithLicenseKey:(NSString * _Nonnull)licenseKey error:(NSError * _Nullable * _Nullable)error;
    //     [Static]
    //     [Export("setupWithLicenseKey:error:")]
    //     bool SetupWithLicenseKey(string licenseKey, [NullAllowed] out NSError error);
    // }

}
