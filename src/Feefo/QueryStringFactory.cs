namespace Feefo
{
    public class QueryStringFactory : IQueryStringFactory
    {
        public string Create(string logon)
        {
            return $"?logon={logon}&json=true";
        }
    }
}