using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace AnylineExamples.Shared
{

    public enum ItemType
    {
        Item = 0, 
        Header = 1,
        DocumentUI = 2
    }

    public static class Category
    {
        public static readonly string Energy = "Energy";
        public static readonly string ID = "Identity Documents";
        public static readonly string Vehicle = "Vehicle";
        public static readonly string TIRE = "Tire";
        public static readonly string MRO = "MRO";
        public static readonly string Document = "Documents";
        public static readonly string Barcode = "Barcode";
        public static readonly string Workflows = "Workflows";
        public static readonly string NFC = "NFC";
        public static readonly string Version = "Version";

        public static List<string> GetItems()
        {
            return new List<string>
            {
                Energy, ID, Vehicle, MRO, Document, Barcode, Workflows,
                Version
            };
        }
    }

    public static class Example
    {
        public static readonly string AnalogDigital = "Analog/Digital Meter";
        public static readonly string DialMeter = "Dial Meter";
        public static readonly string UniversalID = "Universal ID";
        public static readonly string ArabicID = "Arabic IDs";
        public static readonly string CyrillicID = "Cyrillic IDs";
        public static readonly string MRZ = "MRZ / Passport";
        public static readonly string JapaneseLandingPermission = "Japanese Landing Permission";
        public static readonly string LicensePlate = "License Plates";
        public static readonly string LicensePlateUS = "License Plate - US";
        public static readonly string LicensePlateAfrica = "License Plate - Africa";
        public static readonly string VIN = "Vehicle Identification Number (VIN)";
        public static readonly string TIN_OCR = "TIN - OCR";
        public static readonly string TIN_UNIVERSAL = "TIN - Universal";
        public static readonly string TIN_DOT = "TIN - DOT (North America only)";
        public static readonly string TireSize = "Tire Size Specifications";
        public static readonly string CommercialTireID = "Commercial Tire Identification Numbers";
        public static readonly string UniversalSerialNumber = "Universal Serial Number";
        public static readonly string ShippingContainerHorizontal = "Shipping Container - Horizontal";
        public static readonly string ShippingContainerVertical = "Shipping Container - Vertical";
        public static readonly string Barcode = "Barcode";
        public static readonly string BarcodeFullFrame = "Barcode - Full Frame";
        //public static readonly string Document = "Document";
        //public static readonly string VoucherCode = "Voucher Code";
        //public static readonly string IBAN = "IBAN";
        //public static readonly string CowTag = "Cattle Tag";
        public static readonly string SerialScanning = "Serial Scanning (LPT > ID > VIN)";
        public static readonly string ParallelScanning = "Parallel Scanning (Meter / Barcode)";
        public static readonly string NFCScanning = "Scan NFC of Passports";

    }
    
    public static class ExampleList
    {
        public static List<ExampleModel> Items { get; } = new List<ExampleModel>
        {
            new ExampleModel(ItemType.Header, Category.Energy, Category.Energy, ""),
            new ExampleModel(ItemType.Item, Example.AnalogDigital, Category.Energy, "meter_config.json"),
            //new ExampleModel(ItemType.Item, Example.DialMeter, Category.Energy, "energy_config_dial.json"),

            new ExampleModel(ItemType.Header, Category.ID, Category.ID, ""),
            new ExampleModel(ItemType.Item, Example.UniversalID, Category.ID, "universal_id_front_config.json"),
            //new ExampleModel(ItemType.Item, Example.ArabicID, Category.ID, "id_config_arabic.json"),
            //new ExampleModel(ItemType.Item, Example.CyrillicID, Category.ID, "id_config_cyrillic.json"),
            new ExampleModel(ItemType.Item, Example.MRZ, Category.ID, "mrz_config.json"),
            //new ExampleModel(ItemType.Item, Example.JapaneseLandingPermission, Category.ID, "id_config_jlp.json"),

            new ExampleModel(ItemType.Header, Category.Vehicle, Category.Vehicle, ""),
            new ExampleModel(ItemType.Item, Example.LicensePlate, Category.Vehicle, "license_plate_eu_config.json"),
            new ExampleModel(ItemType.Item, Example.LicensePlateUS, Category.Vehicle, "license_plate_us_config.json"),
            new ExampleModel(ItemType.Item, Example.LicensePlateAfrica, Category.Vehicle, "license_plate_af_config.json"),
            new ExampleModel(ItemType.Item, Example.VIN, Category.Vehicle, "vin_ocr_config.json"),

            new ExampleModel(ItemType.Header, Category.TIRE, Category.TIRE, ""),
            new ExampleModel(ItemType.Item, Example.TIN_UNIVERSAL, Category.TIRE, "tire_tin_config.json"),
            //new ExampleModel(ItemType.Item, Example.TIN_DOT, Category.TIRE, "mro_config_tin_dot.json"),
            new ExampleModel(ItemType.Item, Example.TireSize, Category.TIRE, "tire_size_config.json"),
            new ExampleModel(ItemType.Item, Example.CommercialTireID, Category.TIRE, "commercial_tire_id_config.json"),

            new ExampleModel(ItemType.Header, Category.MRO, Category.MRO, ""),
            new ExampleModel(ItemType.Item, Example.UniversalSerialNumber, Category.MRO, "serial_number_view_config.json"),
            new ExampleModel(ItemType.Item, Example.ShippingContainerHorizontal, Category.MRO, "horizontal_container_scanner_capture_config.json"),
            new ExampleModel(ItemType.Item, Example.ShippingContainerVertical, Category.MRO, "vertical_container_scanner_capture_config.json"),

            //new ExampleModel(ItemType.Header, Category.Document, Category.Document, ""),
            //new ExampleModel(ItemType.Item, Example.Document, Category.Document, "document_config.json"),

            new ExampleModel(ItemType.Header, Category.Barcode, Category.Barcode, ""),
            new ExampleModel(ItemType.Item, Example.Barcode, Category.Barcode, "sample_barcode_config.json"),
            new ExampleModel(ItemType.Item, Example.BarcodeFullFrame, Category.Barcode, "sample_barcode_fullframe_config.json"),

            //new ExampleModel(ItemType.Item, Example.VoucherCode, Category.Others, "others_config_voucher_code.json"),
            //new ExampleModel(ItemType.Item, Example.IBAN, Category.Others, "iban_view_config.json"),
            //new ExampleModel(ItemType.Item, Example.CowTag, Category.Others, "others_config_cow_tag.json"),

            //new ExampleModel(ItemType.Header, Category.Workflows, Category.Workflows, ""),
            //new ExampleModel(ItemType.Item, Example.SerialScanning, Category.Workflows, "workflows_config_serial_scanning.json"),
            //new ExampleModel(ItemType.Item, Example.ParallelScanning, Category.Workflows, "workflows_config_parallel_scanning.json"),

            new ExampleModel(ItemType.Header, Category.NFC, Category.NFC, ""),
            new ExampleModel(ItemType.Item, Example.NFCScanning, Category.NFC, "mrz_config.json"),

            new ExampleModel(ItemType.Header, Category.Version, Category.Version, ""),

        };
    }
}

