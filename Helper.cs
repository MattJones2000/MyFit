using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace MyFit
{
    public static class Helper
    {
        public static string ConnectionStringVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
