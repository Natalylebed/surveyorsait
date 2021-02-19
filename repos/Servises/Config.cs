using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repos.Servises
{
    public class Config
    { public static string ConnectionString { get; set; }
        public static string CompaniName { get; set;}
      public static string CompaniPhone { get; set;}
      public static string CompanyshotPhon { get; set; }
      public static string CompanyEmayl { get; set; }
       
    }
}
