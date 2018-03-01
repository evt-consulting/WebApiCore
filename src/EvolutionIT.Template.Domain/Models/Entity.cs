using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionIT.Template.Domain.Models
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}
