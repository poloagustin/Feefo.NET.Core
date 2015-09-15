using System;

namespace Feefo.Responses
{

    public class Rootobject
    {
        public FEEDBACKLIST FEEDBACKLIST { get; set; }
    }

    public class FEEDBACKLIST
    {
        public FEEDBACK[] FEEDBACK { get; set; }
        public SUMMARY SUMMARY { get; set; }
    }

    public class SUMMARY
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
        public VENDORREF VENDORREF { get; set; }
        public int WORST { get; set; }
    }

    public class VENDORREF
    {
    }

    public class FEEDBACK
    {
        public int COUNT { get; set; }
        public string CUSTOMERCOMMENT { get; set; }
        public string DATE { get; set; }
        public string DESCRIPTION { get; set; }
        public string FACEBOOKSHARELINK { get; set; }
        public int FEEDBACKID { get; set; }
        public DateTime HREVIEWDATE { get; set; }
        public int HREVIEWRATING { get; set; }
        public string LINK { get; set; }
        public object PRODUCTCODE { get; set; }
        public string PRODUCTRATING { get; set; }
        public string READMOREURL { get; set; }
        public string SERVICERATING { get; set; }
        public string SHORTCUSTOMERCOMMENT { get; set; }
        public FURTHERCOMMENTSTHREAD FURTHERCOMMENTSTHREAD { get; set; }
        public string PRODUCTLATEST { get; set; }
        public string SERVICELATEST { get; set; }
        public string SHORTVENDORCOMMENT { get; set; }
        public string VENDORCOMMENT { get; set; }
    }

    public class FURTHERCOMMENTSTHREAD
    {
        public object POST { get; set; }
    }

}