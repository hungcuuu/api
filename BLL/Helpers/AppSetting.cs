﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helpers
{
    public class AppSetting
    {
        public string Secret { get; set; }
        public string ServerKey { get; set; }
        public string AWSProfileName { get; set; }
        public string AWSAccessKey { get; set; }
        public string AWSSecretKey { get; set; }
        public string BucketName { get; set; }
    }
}
