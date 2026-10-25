

namespace ElectroParts.Common.Constants
{
    public static class EntityValidation
    {
        public static class Device
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;

            public const int ModelMaxLength = 100;
            public const int DescriptionMaxLength = 2000;
        }

        public static class DeviceType
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class Part
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;

            public const int ShortDescriptionMaxLength = 250;
            public const int DescriptionMaxLength = 2000;
        }

        public static class PartType
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class Manufacturer
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;

            public const int AddressMaxLength = 250;
            public const int UrlMaxLength = 2048;
        }
    }
}
