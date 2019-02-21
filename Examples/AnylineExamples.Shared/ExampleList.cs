using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace AnylineExamples.Shared
{

    public enum ItemType
    {
        Item = 0, 
        Header = 1
    }

    public static class Category
    {
        public static readonly string Energy = "Energy";
        public static readonly string ID = "Identity Documents";
        public static readonly string Vehicle = "Vehicle";
        public static readonly string MRO = "MRO";
        public static readonly string Others = "Others";
        public static readonly string Version = "";

        public static List<string> GetItems()
        {
            return new List<string>
            {
                Energy, ID, Vehicle, MRO, Others,
                Version

            };
        }
    }

    public static class Example
    {
        public static readonly string AnalogDigital = "Analog/Digital Meter";
        public static readonly string DialMeter = "Dial Meter";
        public static readonly string MRZ = "Passport/MRZ";
        public static readonly string DrivingLicense = "AUT/GER Driving License";
        public static readonly string LicensePlate = "EU License Plate";
        public static readonly string SerialNumber = "Universal Serial Number";
        public static readonly string VIN = "Vehicle Identification Number";
        public static readonly string ShippingContainer = "Shipping Container";
        public static readonly string Barcode = "Barcode";
        public static readonly string Bottlecap = "Bottlecap";
        public static readonly string VoucherCode = "Voucher Code";

        public static List<string> GetItems()
        {
            return new List<string>
            {
                AnalogDigital, DialMeter, MRZ, DrivingLicense,
                LicensePlate, SerialNumber, VIN, ShippingContainer,
                Barcode, Bottlecap, VoucherCode
            };
        }
    }
    
    public static class ExampleList
    {
        public static List<ExampleModel> Items { get; } = new List<ExampleModel>
        {
            new ExampleModel(ItemType.Header, Category.Energy, Category.Energy, ""),
            new ExampleModel(ItemType.Item, Example.AnalogDigital, Category.Energy, "energy_config_analog_digital.json"),
            new ExampleModel(ItemType.Item, Example.DialMeter, Category.Energy, "energy_config_dial.json"),

            new ExampleModel(ItemType.Header, Category.ID, Category.ID, ""),
            new ExampleModel(ItemType.Item, Example.MRZ, Category.ID, "id_config_mrz.json"),
            new ExampleModel(ItemType.Item, Example.DrivingLicense, Category.ID, "id_config_driving_license.json"),
            
            new ExampleModel(ItemType.Header, Category.Vehicle, Category.Vehicle, ""),
            new ExampleModel(ItemType.Item, Example.LicensePlate, Category.Vehicle, "vehicle_config_license_plate.json"),
            
            new ExampleModel(ItemType.Header, Category.MRO, Category.MRO, ""),
            new ExampleModel(ItemType.Item, Example.SerialNumber, Category.MRO, "mro_config_seial.json"),
            new ExampleModel(ItemType.Item, Example.VIN, Category.MRO, "mro_config_vin.json"),
            new ExampleModel(ItemType.Item, Example.ShippingContainer, Category.MRO, "mro_config_shipping_container.json"),
            
            new ExampleModel(ItemType.Header, Category.Others, Category.Others, ""),
            new ExampleModel(ItemType.Item, Example.Barcode, Category.Others, "others_config_barcode.json"),
            new ExampleModel(ItemType.Item, Example.Bottlecap, Category.Others, "others_config_bottlecap.json"),
            new ExampleModel(ItemType.Item, Example.VoucherCode, Category.Others, "others_config_voucher_code.json"),
            
            new ExampleModel(ItemType.Header, Category.Version, Category.Version, ""),
        };
    }
}

