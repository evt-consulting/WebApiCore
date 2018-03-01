using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionIT.Template.Domain.Models
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
