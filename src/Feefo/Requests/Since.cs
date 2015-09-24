namespace Feefo.Requests
{
    public enum Since
    {
        None = 0,
        /// <summary>
        /// Returns the last 7 days of feedback data.
        /// </summary>
        Week = 1,
        /// <summary>
        /// Returns the last 30 days of feedback data.
        /// </summary>
        Month,
        /// <summary>
        /// Returns the last 180 days of feedback data.
        /// </summary>
        SixMonths,
        /// <summary>
        /// Returns the last 365 days of feedback data.
        /// </summary>
        Year 
    }
}