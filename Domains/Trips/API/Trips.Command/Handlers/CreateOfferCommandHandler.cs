using ServicesFramework.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using Trips.Domain;

namespace Trips.Commands.Handlers
{
    public class CreateOfferCommandHandler : ICommandHandler<CreateOfferCommand, CreateOfferCommandResult>
    {
        private readonly IOfferRepository offerRepository;

        public CreateOfferCommandHandler(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public CreateOfferCommandResult Handle(CreateOfferCommand command)
        {
            var offer = new Offer(command.Name, command.Description, command.NumberOfDays);
            offerRepository.Add(offer);
            offerRepository.SaveChangesAsync();
            return new CreateOfferCommandResult()
            {
                Message = $"Hello {command.Name}!"
            };
        }
    }
}
