using ServicesFramework.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trips.Commands.Handlers
{
    public class CreateOfferCommandHandler : ICommandHandler<CreateOfferCommand, CreateOfferCommandResult>
    {
        public CreateOfferCommandResult Handle(CreateOfferCommand command)
        {
            return new CreateOfferCommandResult()
            {
                Message = $"Hello {command.Name}!"
            };
        }
    }
}
