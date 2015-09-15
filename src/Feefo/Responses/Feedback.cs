using System;

namespace Feefo.Responses
{
    public class Feedback
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
        public FurtherCommentsThread FurtherCommentsThread { get; set; }
        public string PRODUCTLATEST { get; set; }
        public string SERVICELATEST { get; set; }
        public string SHORTVENDORCOMMENT { get; set; }
        public string VENDORCOMMENT { get; set; }
    }
}