﻿using System;
using System.Collections.Generic;

namespace DbFirstApproach.Models.DomainModels
{
    public partial class UserInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
