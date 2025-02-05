﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public bool Status { get; set; }
    }
}
