﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XanElectronics.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
