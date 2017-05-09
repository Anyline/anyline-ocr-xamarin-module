using Foundation;
using System;
namespace AnylineXamarinSDK.iOS
{
    // document ratio presets
    public static class DocumentRatio
    {
        public static readonly NSNumber DINAXLandscape = 1.41;
        public static readonly NSNumber DINAXPortrait = 0.707;
        public static readonly NSNumber ComplimentsSlipLandscape = 2.12;
        public static readonly NSNumber ComplimentsSlipPortrait = 0.47;
        public static readonly NSNumber BusinessCardLandscape = 1.58;
        public static readonly NSNumber BusinessCardPortrait = 0.633;
        public static readonly NSNumber LetterLandscape = 1.296;
        public static readonly NSNumber LetterPortrait = 0.772;
    }
    
    // predefined regexes for OCR module
    public static class AnylineOcrRegex
    {
        public static readonly string Email = "^(([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,64}){1,64})+([;.](([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,64}){1,64})+)*$";
        public static readonly string URL = "((([A-Za-z]{3,9}:(?:\\/\\/)?)(?:[\\-;:&=\\+\\$,\\w]+@)?[A-Za-z0-9\\.\\-]+|(?:www\\.|[\\-;:&=\\+\\$,\\w]+@)[A-Za-z0-9\\.\\-]+)((?:\\/[\\+~%\\/\\.\\w\\-_]*)?\\??(?:[\\-\\+=&;%@\\.\\w_]*)#?(?:[\\.\\!\\/\\\\\\w]*))?)";
        public static readonly string PriceTag = "^(€|$)?( )?([0-9]{1,3}(\\.|\\,))*[0-9]{1,3}((\\\\.|\\\\,)([0-9]{2,2}|-))?( )?(€|$)?$";
        public static readonly string ISBN = "^ISBN((-)?\\s*(13|10))?:?\\s*((978|979){1}-?\\s*)*[0-9]{1,5}-?\\s*[0-9]{2,7}-?\\s*[0-9]{2,7}-?\\s*[0-9X]$";
        public static readonly string VIN = "^[A-HJ-NPR-Z\\d]{8}[\\dX][A-HJ-NPR-Z\\d]{2}\\d{6}$";
        public static readonly string IMEI = "^([0-9](\\\\ |-|\\/)?){15}";        
    }

    // predefined character whitelist for OCR module
    public static class AnylineOcrCharWhiteList
    {
        public static readonly string Email = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZÄÜÖ0123456789.@_-";
        public static readonly string URL = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZÄÜÖ0123456789./:@%_+-~#?&=";
        public static readonly string PriceTag = @"0123456789.,-€$";
        public static readonly string ISBN = @"ISBN0123456789<>-X";
        public static readonly string VIN = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static readonly string IMEI = @"-/0123456789";         
    }
}