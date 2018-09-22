using MediatR;
using ServicesFramework.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using Trips.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Trips.Commands.Handlers
{
    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, CreateOfferCommandResult>
    {
        private readonly IOfferRepository offerRepository;
        private readonly IMediator mediator;

        public CreateOfferCommandHandler(IOfferRepository offerRepository, IMediator mediator)
        {
            this.offerRepository = offerRepository;
            this.mediator = mediator;
        }

        public Task<CreateOfferCommandResult> Handle(CreateOfferCommand command, CancellationToken cancellationToken)
        {
            var offer = new Offer(command.Name, command.Description, command.NumberOfDays);

            offer.AssignPhoto();
            offerRepository.Add(offer);
            offerRepository.SaveChangesAndPublishEventsAsync();

            return Task.FromResult(new CreateOfferCommandResult()
            {
                Message = $"Hello {command.Name}!"
            });
        }
    }
}
