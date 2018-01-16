using ServicesFramework.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.Commands
{
    public class BuyTicketCommandHandler : ICommandHandler<BuyTicketCommand, BuyTicketCommandResult>
    {
        public BuyTicketCommandResult Handle(BuyTicketCommand command)
        {
            return new BuyTicketCommandResult()
            {
                Message = $"Hello {command.Name}!"
            };
        }
    }
}
