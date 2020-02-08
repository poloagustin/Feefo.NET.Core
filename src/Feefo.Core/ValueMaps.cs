using System.Collections.Generic;
using Feefo.Requests;

namespace Feefo
{
    public class ValueMaps
    {
        public IDictionary<SortBy, string> SortByValueMap { get; } = new Dictionary<SortBy, string>()
        {
            {SortBy.ProductFeedback, "product_feedback"},
            {SortBy.Date, "date"},
            {SortBy.Description, "description"},
            {SortBy.Relevance, "relevance"},
            {SortBy.ServiceFeedback, "service_feedback"},
        };

        public IDictionary<Since, string> SinceValueMap { get; } = new Dictionary<Since, string>()
        {
            {Since.Week, "week"},
            {Since.Month, "month"},
            {Since.SixMonths, "6months"},
            {Since.Year, "year"}
        };

        public IDictionary<Mode, string> ModeValueMap { get; } = new Dictionary<Mode, string>()
        {
            {Mode.Service, "service"},
            {Mode.Product, "product"},
            {Mode.ServiceAndProduct, "both"},
            {Mode.ProductOnly, "productonly"},
            {Mode.ProductCo, "productco"}
        };
    }
}