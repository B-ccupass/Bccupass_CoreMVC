﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Models.DTO.Account
{
    public class CreateAccountInputDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
