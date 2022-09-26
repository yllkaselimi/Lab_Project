using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Trainer { get; set; }
        public string Description { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }

    }
}