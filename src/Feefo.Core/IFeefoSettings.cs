using System;

namespace Feefo
{
    public interface IFeefoSettings
    {
        string Logon { get; }

        Uri BaseUri { get; }
    }
}