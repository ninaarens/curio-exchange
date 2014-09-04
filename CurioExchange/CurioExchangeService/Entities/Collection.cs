﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurioExchangeService.Entities
{
    public class Collection : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Set> Sets { get; set; }
    }
}