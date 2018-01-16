using ServicesFramework.CQRS;
using System;

namespace Trips.Commands
{
    public class CreateOfferCommand : ICommand
    {
    }    

    public class CreateOfferCommandResult : ICommandResult
    {
        public string Message { get; set; }
    }
}
