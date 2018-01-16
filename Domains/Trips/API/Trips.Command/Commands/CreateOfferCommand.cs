using ServicesFramework.CQRS;
using System;

namespace Trips.Commands
{
    public class CreateOfferCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfDays { get; set; }        
    }    

    public class CreateOfferCommandResult : ICommandResult
    {
        public string Message { get; set; }
    }
}
