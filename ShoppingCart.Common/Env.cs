using System;
using System.Data.SqlClient;
using System.Linq;

namespace ShoppingCart.Common
{
    public static class Env
    {
#if DEBUG
        public static readonly bool IsRunningFromXUnit = 
            AppDomain.CurrentDomain.GetAssemblies().Any(
                a => a.FullName.ToLowerInvariant().StartsWith("xunit"));

        public static SqlConnection TestDbConnection = new SqlConnection("DataSource=:memory:");
#endif
    }
}