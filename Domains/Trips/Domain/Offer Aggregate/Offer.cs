using System;
using System.Collections.Generic;
using System.Text;
using ServicesFramework.DDD;
using Trips.Domain.Events;

namespace Trips.Domain
{
    public class Offer : 
        Entity<Offer, string>,
        IAggregateRoot
    {
        private List<Photo> _photos;
        public override string Id { get; protected set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int NumberOfDays { get; private set; }
        public string PlaceId { get; private set; }

        public IReadOnlyCollection<Photo> Photos => _photos;

        protected Offer()
        {
            _photos = new List<Photo>();
        }

        public Offer(string name, string description, int numberOfDays)
        {
            Name = name;
            Description = description;
            NumberOfDays = numberOfDays;
            _photos = new List<Photo>();
        }

        public void AssignPhoto()
        {
            var photo = new Photo();
            photo.Title = "Zolwie";
            photo.FilePath = "//d/Photos";
            photo.Description = "Pedzace zoltwie";
            _photos.Add(photo);
            this.AddDomainEvent(new PhotoToOfferAdded() { Title = photo.Title });
        }
    }
}
