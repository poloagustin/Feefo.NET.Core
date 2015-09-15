namespace Feefo.Responses
{
    public class Summary
    {
        public int AVERAGE { get; set; }
        public int BEST { get; set; }
        public int COUNT { get; set; }
        public string FEEDGENERATION { get; set; }
        public int LIMIT { get; set; }
        public string MODE { get; set; }
        public int PRODUCTBAD { get; set; }
        public int PRODUCTEXCELLENT { get; set; }
        public int PRODUCTGOOD { get; set; }
        public int PRODUCTPOOR { get; set; }
        public int SERVICEBAD { get; set; }
        public int SERVICEEXCELLENT { get; set; }
        public int SERVICEGOOD { get; set; }
        public int SERVICEPOOR { get; set; }
        public int START { get; set; }
        public string SUPPLIERLOGO { get; set; }
        public string TITLE { get; set; }
        public int TOTALPRODUCTCOUNT { get; set; }
        public int TOTALRESPONSES { get; set; }
        public int TOTALSERVICECOUNT { get; set; }
        public string VENDORLOGON { get; set; }
        public VendorRef VendorRef { get; set; }
        public int WORST { get; set; }
    }
}