using RealCard.Contexts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Contexts
{
    public class BaseMSSQLContext
    {
        protected readonly IHandler handler;

        public BaseMSSQLContext(IHandler handler)
        {
            this.handler = handler;
        }
    }
}
