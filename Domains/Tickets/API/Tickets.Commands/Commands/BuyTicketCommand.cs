using ServicesFramework.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.Commands
{
    public class BuyTicketCommand : ICommand
    {
        public string Name { get; set; }
    }

    public class BuyTicketCommandResult : ICommandResult
    {
        public string Message { get; set; }
    }
}
