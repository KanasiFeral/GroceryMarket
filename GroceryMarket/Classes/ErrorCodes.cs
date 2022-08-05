namespace GroceryMarket.Classes
{
    public static class ErrorCodes
    {
        public static readonly string PRODUCT_CODE_LENGHT_ERROR_MESSAGE = "ProductCode cannot be more than 50 symbols";
        public static readonly string PRODUCT_CODE_ICORRECT_FORMAT_ERROR_MESSAGE = "ProductCode has incorrect format";
        public static readonly string PRODUCT_CODE_VALUE_ERROR_MESSAGE = "ProductCode cannot be empty";
        public static readonly string PRODUCT_CODE_LETTERS_ERROR_MESSAGE = "ProductCode must using only latin letters";
        public static readonly string PRODUCT_CODE_NOT_FOUND_ERROR_MESSAGE = "ProductCode not found";
        public static readonly string PRODUCT_CODE_LIST_ARE_EMPTY_ERROR_MESSAGE = "ProductCode list are empty";

        public static readonly string PRICE_LENGHT_ERROR_MESSAGE = "Price cannot be less 0";
        public static readonly string PRICE_VALUE_ERROR_MESSAGE = "Price cannot be more than 1m";

        public static readonly string WHOLESALE_LENGHT_ERROR_MESSAGE = "WholesalePrice cannot be less 0";
        public static readonly string WHOLESALE_VALUE_ERROR_MESSAGE = "WholesalePrice cannot be more than 1m";

        public static readonly string WHOLESALE_COUNT_LENGHT_ERROR_MESSAGE = "Wholesale count cannot be less 0";
        public static readonly string WHOLESALE_COUNT_VALUE_ERROR_MESSAGE = "Wholesale count cannot be more than 1m";

        public static readonly string CONFIGURATION_DATA_ARE_EMPTY_ERROR_MESSAGE = "Configuration data are empty";

    }
}