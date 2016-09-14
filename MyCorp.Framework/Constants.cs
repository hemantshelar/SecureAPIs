using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCorp.Framework
{
    public class Constants
    {
        public const string IssuireURI = @"https://mycorpidentityserverapp.azurewebsites.net/identity";


        public const string STSPublicOrigin = @"https://mycorpidentityserverapp.azurewebsites.net";

        public static string MyCorpSTS = STSPublicOrigin +  @"/identity";

        public static string MyCorpMvcAppSecret = @"mymvcclientsecret";
        public static string MyCorpMvcAppId = @"mymvcclient";
    }
}
