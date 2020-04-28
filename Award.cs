﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Entities
{
    public class Award
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return $" {Title}";
        }
    }
}
