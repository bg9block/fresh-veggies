using System;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace ShoppingCart.Common
{
    public static class Env
    {
        static Env()
        {
            TestDbConnection = new SqliteConnection("Data Source=:memory:");
            IsRunningFromXUnit = 
                AppDomain.CurrentDomain.GetAssemblies().Any(
                    a => a.FullName.ToLowerInvariant().StartsWith("xunit"));
        }

        public static readonly bool IsRunningFromXUnit;

        public static SqliteConnection TestDbConnection { get; }
    }
}