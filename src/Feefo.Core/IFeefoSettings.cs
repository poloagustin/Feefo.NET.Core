using System;

namespace Feefo.Core
{
    public interface IFeefoSettings
    {
        string Logon { get; }

        Uri BaseUri { get; }
    }
}