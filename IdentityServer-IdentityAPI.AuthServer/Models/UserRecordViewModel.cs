﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerIdentityAPI.AuthServer.Models
{
    public class UserRecordViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password{ get; set; }
        public string City { get; set; }
    }
}
