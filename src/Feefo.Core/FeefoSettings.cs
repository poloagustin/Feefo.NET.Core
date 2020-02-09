using System;

namespace Feefo.Core
{
    public static class FeefoDefaults
    {
        public static readonly Uri BaseUri = new Uri("http://www.feefo.com/feefo/xmlfeed.jsp");
    }

    public class FeefoSettings : IFeefoSettings
    {

        public FeefoSettings(string logon)
            : this(FeefoDefaults.BaseUri, logon)
        {
        }

        public FeefoSettings(Uri baseUri, string logon)
        {
            Logon = logon;
            BaseUri = baseUri;
        }

        public string Logon { get; }

        public Uri BaseUri { get; }
    }
}