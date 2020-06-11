﻿using System;

namespace RestApi.Model
{
    public class Auditor
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy{ get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}