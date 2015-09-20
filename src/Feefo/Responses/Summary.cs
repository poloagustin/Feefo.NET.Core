using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Feefo.Responses
{
    public class Summary
    {
        /// <summary>
        /// The average rating given to the reviews.
        /// </summary>
        [JsonProperty(PropertyName = "AVERAGE")]
        public int Average { get; set; }

        /// <summary>
        /// The highest rating given in the range of reviews returned by the query.
        /// </summary>
        [JsonProperty(PropertyName = "BEST")]
        public int Best { get; set; }

        /// <summary>
        /// The count of feedbacks that have been received – either service or product – in the given time period.
        /// </summary>
        [JsonProperty(PropertyName = "COUNT")]
        public int Count { get; set; }

        /// <summary>
        /// The date/time of the feed generation, e.g. Mon May 20 13:46:04 BST 2013. If this value lags behind the current time then the feed being viewed is a cached copy.
        /// </summary>
        [JsonProperty(PropertyName = "FEEDGENERATION")]
        public string FeedGeneration { get; set; }

        /// <summary>
        /// The number of feedbacks returned in the query, e.g. 20. If the limit parameter is used then this value will match.
        /// </summary>
        [JsonProperty(PropertyName = "LIMIT")]
        public int Limit { get; set; }

        /// <summary>
        /// Shows if the feed mode has been set to show 'product' or 'service' feedback. This is usually set by the mode parameter or will always be set to 'product' upon the inclusion of the vendorref parameter.
        /// </summary>
        [JsonProperty(PropertyName = "MODE")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Mode Mode { get; set; }

        /// <summary>
        /// An integer with the number of product feedbacks rated as Bad
        /// </summary>
        [JsonProperty(PropertyName = "PRODUCTBAD")]
        public int ProductBad { get; set; }

        /// <summary>
        /// An integer with the number of product feedbacks rated as Excellent.
        /// </summary>
        [JsonProperty(PropertyName = "PRODUCTEXCELLENT")]
        public int ProductExcellent { get; set; }

        /// <summary>
        /// An integer with the number of product feedbacks rated as Good.
        /// </summary>
        [JsonProperty(PropertyName = "PRODUCTGOOD")]
        public int ProductGood { get; set; }

        /// <summary>
        /// An integer with the number of Product feedbacks rated as Poor.
        /// </summary>
        [JsonProperty(PropertyName = "PRODUCTPOOR")]
        public int ProductPoor { get; set; }

        /// <summary>
        /// An integer with the number of service feedbacks rated as Bad.
        /// </summary>
        [JsonProperty(PropertyName = "SERVICEBAD")]
        public int ServiceBad { get; set; }

        /// <summary>
        /// An integer with the number of service feedbacks rated as Excellent.
        /// </summary>
        [JsonProperty(PropertyName = "SERVICEEXCELLENT")]
        public int ServiceExcellent { get; set; }

        /// <summary>
        /// An integer with the number of service feedbacks rated as Good.
        /// </summary>
        [JsonProperty(PropertyName = "SERVICEGOOD")]
        public int ServiceGood { get; set; }

        /// <summary>
        /// An integer with the number of service feedbacks rated as Poor.
        /// </summary>
        [JsonProperty(PropertyName = "SERVICEPOOR")]
        public int ServicePoor { get; set; }

        /// <summary>
        /// The start number of the first feedback in the returned feedback list – usually 1 but may change if multiple pages are requested.
                /// </summary>
        [JsonProperty(PropertyName = "START")]
        public int Start { get; set; }

        /// <summary>
        /// An http link to display the supplier's logo as stored within Feefo.
        /// </summary>
        [JsonProperty(PropertyName = "SUPPLIERLOGO")]
        public string SupplierLogo { get; set; }

        /// <summary>
        /// A field, suggested for use as a page title, containing the name of the supplier.
        /// </summary>
        [JsonProperty(PropertyName = "TITLE")]
        public string Title { get; set; }

        /// <summary>
        /// Count of all the product feedbacks received for the supplier.
        /// </summary>
        [JsonProperty(PropertyName = "TOTALPRODUCTCOUNT")]
        public int TotalProductCount { get; set; }

        /// <summary>
        /// A count of every single feedback response recorded against the supplier.
        /// </summary>
        [JsonProperty(PropertyName = "TOTALRESPONSES")]
        public int TotalResponses { get; set; }

        /// <summary>
        /// Count of all the service feedbacks that have been received for the supplier.
        /// </summary>
        [JsonProperty(PropertyName = "TOTALSERVICECOUNT")]
        public int TotalServiceCount { get; set; }

        /// <summary>
        /// The supplier's Feefo logon. If a sub-brand is required then the format is logon/brand, e.g. www.examplesupplier.com/computer_shop
        /// </summary>
        [JsonProperty(PropertyName = "VENDORLOGON")]
        public string VendorLogon { get; set; }

        /// <summary>
        /// If the XML Feed is in ‘product’ mode then the vendorref parameter (usually the SKU as stored by Feefo) will be shown here.If in 'service' mode then this will be included but not contain a value. 
        /// </summary>
        [JsonProperty(PropertyName = "VendorRef")]
        public VendorRef VendorRef { get; set; }

        /// <summary>
        /// The lowest rating given in the range of reviews returned by the query.
        /// </summary>
        [JsonProperty(PropertyName = "WORST")]
        public int Worst { get; set; }
    }
}