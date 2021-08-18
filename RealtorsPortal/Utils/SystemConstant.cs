using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealtorsPortal.Utils
{
    public static class SystemConstant
    {
        public static string EMAIL_ADMIN = "thuyvt.dev@gmail.com";
        public static string NAME = "Realtors Portal";

        public static int ADMIN = 1;
        public static int AGENT = 2;
        public static int PRIVATE_SELLER = 3;
        public static int VISITOR = 4;

        public static bool MALE = true;
        public static bool FEMALE = false;

        public static int APPROVED = 0;
        public static int UNAPPROVED = 1;
        public static int UNVERIFIED = 2;
    }
}