namespace Feefo
{
    public enum SortBy
    {
        None = 0,
        /// <summary>
        /// The results will be sorted by the date the feedback was left.
        /// </summary>
        Date,
        /// <summary>
        /// The results will be sorted by their numerical ‘relevance’ value.
        /// </summary>
        Relevance,
        /// <summary>
        /// The results will be sorted by the description of the item purchased. 
        /// </summary>
        Description,
        /// <summary>
        ///  The results will be sorted by the customer’s service feedback comments. The results will be sorted alphabetically.
        /// </summary>
        ServiceFeedback,
        /// <summary>
        /// The results will be sorted by the customer’s product feedback comments. The results will be sorted alphabetically.
        /// </summary>
        ProductFeedback
    }
}