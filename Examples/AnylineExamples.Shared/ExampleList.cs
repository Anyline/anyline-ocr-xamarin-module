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
        public static readonly string TIN = "Tire Identification Number (TIN)";
        public static readonly string MRO = "MRO";
        public static readonly string Document = "Documents";
        public static readonly string Others = "Others";
        public static readonly string Workflows = "Workflows";
        public static readonly string NFC = "NFC";
        public static readonly string Version = "Version";

        public static List<string> GetItems()
        {
            return new List<string>
            {
                Energy, ID, Vehicle, MRO, Document, Others, Workflows,
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
        /* Deprecated modes -> Will be removed in December/2021 */
        //public static readonly string DrivingLicense = "AT/DE/UK Driving License";
        //public static readonly string GermanIDFront = "German ID Front";
        //public static readonly string JapaneseLandingPermission = "Japanese Landing Permission";
        public static readonly string LicensePlate = "License Plates";
        public static readonly string LicensePlateUS = "License Plate - US";
        public static readonly string LicensePlateAfrica = "License Plate - Africa";
        public static readonly string VIN = "Vehicle Identification Number (VIN)";
        public static readonly string TIN_UNIVERSAL = "TIN - Universal";
        public static readonly string TIN_DOT = "TIN - DOT (North America only)";
        public static readonly string UniversalSerialNumber = "Universal Serial Number";
        public static readonly string ShippingContainerHorizontal = "Shipping Container - Horizontal";
        public static readonly string ShippingContainerVertical = "Shipping Container - Vertical";
        public static readonly string Barcode = "Barcode";
        public static readonly string Document = "Document";
        public static readonly string VoucherCode = "Voucher Code";
        public static readonly string IBAN = "IBAN";
        public static readonly string CowTag = "Cattle Tag";
        public static readonly string SerialScanning = "Serial Scanning (LPT > DL > VIN)";
        public static readonly string ParallelScanning = "Parallel Scanning (Meter / Barcode)";
        public static readonly string NFCScanning = "Scan NFC of Passports";

    }
    
    public static class ExampleList
    {
        public static List<ExampleModel> Items { get; } = new List<ExampleModel>
        {
            new ExampleModel(ItemType.Header, Category.Energy, Category.Energy, ""),
            new ExampleModel(ItemType.Item, Example.AnalogDigital, Category.Energy, "energy_config_analog_digital.json"),
            new ExampleModel(ItemType.Item, Example.DialMeter, Category.Energy, "energy_config_dial.json"),

            new ExampleModel(ItemType.Header, Category.ID, Category.ID, ""),
            new ExampleModel(ItemType.Item, Example.UniversalID, Category.ID, "id_config_universal.json"),
            new ExampleModel(ItemType.Item, Example.ArabicID, Category.ID, "id_config_arabic.json"),
            new ExampleModel(ItemType.Item, Example.CyrillicID, Category.ID, "id_config_cyrillic.json"),
            new ExampleModel(ItemType.Item, Example.MRZ, Category.ID, "id_config_mrz.json"),
            //new ExampleModel(ItemType.Item, Example.DrivingLicense, Category.ID, "id_config_driving_license.json"),
            //new ExampleModel(ItemType.Item, Example.GermanIDFront, Category.ID, "id_config_german_id_front.json"),
            // new ExampleModel(ItemType.Item, Example.JapaneseLandingPermission, Category.ID, "id_config_jlp.json"),

            new ExampleModel(ItemType.Header, Category.Vehicle, Category.Vehicle, ""),
            new ExampleModel(ItemType.Item, Example.LicensePlate, Category.Vehicle, "vehicle_config_license_plate.json"),
            new ExampleModel(ItemType.Item, Example.LicensePlateUS, Category.Vehicle, "vehicle_config_license_plate_us.json"),
            new ExampleModel(ItemType.Item, Example.LicensePlateAfrica, Category.Vehicle, "vehicle_config_license_plate_africa.json"),
            new ExampleModel(ItemType.Item, Example.VIN, Category.Vehicle, "mro_config_vin.json"),

            new ExampleModel(ItemType.Header, Category.TIN, Category.TIN, ""),
            new ExampleModel(ItemType.Item, Example.TIN_UNIVERSAL, Category.TIN, "mro_config_tin_universal.json"),
            new ExampleModel(ItemType.Item, Example.TIN_DOT, Category.TIN, "mro_config_tin_dot.json"),

            new ExampleModel(ItemType.Header, Category.MRO, Category.MRO, ""),
            new ExampleModel(ItemType.Item, Example.UniversalSerialNumber, Category.MRO, "mro_config_usnr.json"),
            new ExampleModel(ItemType.Item, Example.ShippingContainerHorizontal, Category.MRO, "mro_config_shipping_container_horizontal.json"),
            new ExampleModel(ItemType.Item, Example.ShippingContainerVertical, Category.MRO, "mro_config_shipping_container_vertical.json"),

            new ExampleModel(ItemType.Header, Category.Document, Category.Document, ""),
            new ExampleModel(ItemType.Item, Example.Document, Category.Document, "document_config.json"),

            new ExampleModel(ItemType.Header, Category.Others, Category.Others, ""),
            new ExampleModel(ItemType.Item, Example.Barcode, Category.Others, "others_config_barcode.json"),
            new ExampleModel(ItemType.Item, Example.VoucherCode, Category.Others, "others_config_voucher_code.json"),
            new ExampleModel(ItemType.Item, Example.IBAN, Category.Others, "iban_view_config.json"),
            new ExampleModel(ItemType.Item, Example.CowTag, Category.Others, "others_config_cow_tag.json"),

            new ExampleModel(ItemType.Header, Category.Workflows, Category.Workflows, ""),
            new ExampleModel(ItemType.Item, Example.SerialScanning, Category.Workflows, "workflows_config_serial_scanning.json"),
            new ExampleModel(ItemType.Item, Example.ParallelScanning, Category.Workflows, "workflows_config_parallel_scanning.json"),

            new ExampleModel(ItemType.Header, Category.NFC, Category.NFC, ""),
            new ExampleModel(ItemType.Item, Example.NFCScanning, Category.NFC, "id_config_mrz.json"),

            new ExampleModel(ItemType.Header, Category.Version, Category.Version, ""),

        };
    }
}

