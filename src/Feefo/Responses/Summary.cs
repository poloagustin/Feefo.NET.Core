using Newtonsoft.Json;

namespace Feefo.Responses
{
    public class Summary
    {
        [JsonProperty(PropertyName = "AVERAGE")]
        public int Average { get; set; }

        [JsonProperty(PropertyName = "BEST")]
        public int Best { get; set; }

        [JsonProperty(PropertyName = "COUNT")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "FEEDGENERATION")]
        public string FeedGeneration { get; set; }

        [JsonProperty(PropertyName = "LIMIT")]
        public int Limit { get; set; }

        [JsonProperty(PropertyName = "MODE")]
        public string Mode { get; set; }

        [JsonProperty(PropertyName = "PRODUCTBAD")]
        public int ProductBad { get; set; }

        [JsonProperty(PropertyName = "PRODUCTEXCELLENT")]
        public int ProductExcellent { get; set; }

        [JsonProperty(PropertyName = "PRODUCTGOOD")]
        public int ProductGood { get; set; }

        [JsonProperty(PropertyName = "PRODUCTPOOR")]
        public int ProductPoor { get; set; }

        [JsonProperty(PropertyName = "SERVICEBAD")]
        public int ServiceBad { get; set; }

        [JsonProperty(PropertyName = "SERVICEEXCELLENT")]
        public int ServiceExcellent { get; set; }

        [JsonProperty(PropertyName = "SERVICEGOOD")]
        public int ServiceGood { get; set; }
        
        [JsonProperty(PropertyName = "SERVICEPOOR")]
        public int ServicePoor { get; set; }

        [JsonProperty(PropertyName = "START")]
        public int Start { get; set; }

        [JsonProperty(PropertyName = "SUPPLIERLOGO")]
        public string SupplierLogo { get; set; }

        [JsonProperty(PropertyName = "TITLE")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "TOTALPRODUCTCOUNT")]
        public int TotalProductCount { get; set; }

        [JsonProperty(PropertyName = "TOTALRESPONSES")]
        public int TotalResponses { get; set; }

        [JsonProperty(PropertyName = "TOTALSERVICECOUNT")]
        public int TotalServiceCount { get; set; }

        [JsonProperty(PropertyName = "VENDORLOGON")]
        public string VendorLogon { get; set; }

        [JsonProperty(PropertyName = "VendorRef")]
        public VendorRef VendorRef { get; set; }

        [JsonProperty(PropertyName = "WORST")]
        public int Worst { get; set; }
    }
}