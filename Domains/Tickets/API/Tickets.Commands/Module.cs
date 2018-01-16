using Infrastructure.IoC;
using ServicesFramework.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.Commands
{
    public class Module : IIoCModule
    {
        public void RegisterInContainer(IIoCContainerRegistration containerRegistration)
        {
            containerRegistration.Register<ICommandHandler<BuyTicketCommand, BuyTicketCommandResult>, BuyTicketCommandHandler>();
        }
    }
}
