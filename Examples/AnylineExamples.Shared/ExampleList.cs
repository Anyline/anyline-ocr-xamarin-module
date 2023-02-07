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
        public static readonly string MRO = "Maintenance, Repair & Operations";
        public static readonly string Barcode = "Barcode";
        public static readonly string Composite = "Composite";
        public static readonly string NFC = "NFC";
        public static readonly string Version = "Version";

        public static List<string> GetItems()
        {
            return new List<string>
            {
                Energy, ID, Vehicle, MRO, Barcode, Composite,
                Version
            };
        }
    }

    public static class Example
    {
        public static readonly string AnalogDigital = "Analog/Digital Meter";
        public static readonly string DialMeter = "Dial Meter";
        public static readonly string UniversalID = "Universal ID - Latin";
        public static readonly string ArabicID = "Universal ID - Arabic";
        public static readonly string CyrillicID = "Universal ID - Cyrillic";
        public static readonly string MRZ = "MRZ / Passport";
        public static readonly string LicensePlate = "License Plate - EU";
        public static readonly string LicensePlateUSA = "License Plate - USA";
        public static readonly string LicensePlateAfrica = "License Plate - Africa";
        public static readonly string VIN = "Vehicle Identification Number (VIN)";
        public static readonly string VRC = "Vehicle Registration Certificate";
        public static readonly string TIN_UNIVERSAL = "Tire Identification Number (TIN) - Universal";
        public static readonly string TIN_DOT = "Tire Identification Number (TIN) - DOT";
        public static readonly string TireSize = "Tire Size Specifications";
        public static readonly string CommercialTireID = "Commercial Tire Identification Numbers";
        public static readonly string UniversalSerialNumber = "Serial Number";
        public static readonly string ShippingContainerHorizontal = "Shipping Container - Horizontal";
        public static readonly string ShippingContainerVertical = "Shipping Container - Vertical";
        public static readonly string Barcode = "Barcode";
        public static readonly string BarcodeFullFrame = "Barcode - PDF417 - AAMVA";
        public static readonly string SerialScanning = "Serial - License Plate (EU) + Driver's License + VIN";
        public static readonly string ParallelScanning = "Parallel - Meter + Serial Number";
        public static readonly string NFCScanning = "Scan NFC of Passports";

    }
    
    public static class ExampleList
    {
        public static List<ExampleModel> Items { get; } = new List<ExampleModel>
        {
            new ExampleModel(ItemType.Header, Category.Energy, Category.Energy, ""),
            new ExampleModel(ItemType.Item, Example.AnalogDigital, Category.Energy, "analog_digital_meter_config.json"),
            new ExampleModel(ItemType.Item, Example.DialMeter, Category.Energy, "dial_meter_config.json"),

            new ExampleModel(ItemType.Header, Category.ID, Category.ID, ""),
            new ExampleModel(ItemType.Item, Example.UniversalID, Category.ID, "universal_id_config.json"),
            new ExampleModel(ItemType.Item, Example.ArabicID, Category.ID, "arabic_id_config.json"),
            new ExampleModel(ItemType.Item, Example.CyrillicID, Category.ID, "cyrillic_id_config.json"),
            new ExampleModel(ItemType.Item, Example.MRZ, Category.ID, "mrz_config.json"),

            new ExampleModel(ItemType.Header, Category.Vehicle, Category.Vehicle, ""),
            new ExampleModel(ItemType.Item, Example.LicensePlate, Category.Vehicle, "license_plate_eu_config.json"),
            new ExampleModel(ItemType.Item, Example.LicensePlateUSA, Category.Vehicle, "license_plate_us_config.json"),
            new ExampleModel(ItemType.Item, Example.LicensePlateAfrica, Category.Vehicle, "license_plate_af_config.json"),
            new ExampleModel(ItemType.Item, Example.VIN, Category.Vehicle, "vin_config.json"),
            new ExampleModel(ItemType.Item, Example.VRC, Category.Vehicle, "vrc_config.json"),

            new ExampleModel(ItemType.Header, Category.TIRE, Category.TIRE, ""),
            new ExampleModel(ItemType.Item, Example.TIN_UNIVERSAL, Category.TIRE, "tin_config.json"),
            new ExampleModel(ItemType.Item, Example.TIN_DOT, Category.TIRE, "tire_config_tin_dot.json"),
            new ExampleModel(ItemType.Item, Example.TireSize, Category.TIRE, "tire_size_config.json"),
            new ExampleModel(ItemType.Item, Example.CommercialTireID, Category.TIRE, "commercial_tire_id_config.json"),

            new ExampleModel(ItemType.Header, Category.MRO, Category.MRO, ""),
            new ExampleModel(ItemType.Item, Example.UniversalSerialNumber, Category.MRO, "serial_number_config.json"),
            new ExampleModel(ItemType.Item, Example.ShippingContainerHorizontal, Category.MRO, "container_horizontal_config.json"),
            new ExampleModel(ItemType.Item, Example.ShippingContainerVertical, Category.MRO, "container_vertical_config.json"),

            new ExampleModel(ItemType.Header, Category.Barcode, Category.Barcode, ""),
            new ExampleModel(ItemType.Item, Example.Barcode, Category.Barcode, "barcode_config.json"),
            new ExampleModel(ItemType.Item, Example.BarcodeFullFrame, Category.Barcode, "barcode_pdf417_config.json"),

            new ExampleModel(ItemType.Header, Category.Composite, Category.Composite, ""),
            new ExampleModel(ItemType.Item, Example.SerialScanning, Category.Composite, "composite_serial_config.json"),
            new ExampleModel(ItemType.Item, Example.ParallelScanning, Category.Composite, "composite_parallel_config.json"),

            new ExampleModel(ItemType.Header, Category.NFC, Category.NFC, ""),
            new ExampleModel(ItemType.Item, Example.NFCScanning, Category.NFC, "mrz_config.json"),

            new ExampleModel(ItemType.Header, Category.Version, Category.Version, ""),

        };
    }
}

