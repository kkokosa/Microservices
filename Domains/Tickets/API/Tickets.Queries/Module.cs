﻿using Infrastructure.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketService.Queries;

namespace TicketService.Queries
{
    public class Module : IIoCModule
    {
        public void RegisterInContainer(IIoCContainerRegistration containerRegistration)
        {
        }
    }
}
