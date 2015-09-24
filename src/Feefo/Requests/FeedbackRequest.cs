namespace Feefo.Requests
{
    public class FeedbackRequest
    {
        /// <summary>
        /// VendorRef is the product search code for product feedback. Each order item submitted to Feefo is
        /// submitted with a product code.If this parameter is specified, then only feedback items associated
        /// with the product code supplied will be shown.This is useful when displaying feedback on a product
        /// page.
        /// The wildcard character* is supported for this parameter, so that feedback for multiple products
        /// with a common element in their product code can be returned.
        /// </summary>
        /// <example>vendorref=abc123-4567</example>
        /// <example>vendorref =abc123*</example>
        /// <example>vendorref =*123*</example>
        public string VendorRef { get; set; }

        /// <summary>
        /// Since is the feedback data time period that should be returned.
        /// </summary>
        public Since Since { get; set; }

        /// <summary>
        /// How the data will be sorted.
        /// </summary>
        public Sort Sort { get; set; }

        /// <summary>
        /// Limit defines the number of returned feedback items to be the limit most recent. Its value must be a positive integer.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Mode determines which type of feedback data is returned.
        /// </summary>
        public Mode Mode { get; set; }
    }
}