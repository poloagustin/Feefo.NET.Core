using System;

namespace Feefo
{
    public class FeefoSettings : IFeefoSettings
    {
        public string Logon { get; set; }

        public Uri BaseUri { get; set; }
    }
}