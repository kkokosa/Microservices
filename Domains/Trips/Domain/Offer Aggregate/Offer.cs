using System;
using System.Collections.Generic;
using System.Text;
using ServicesFramework.DDD;

namespace Trips.Domain
{
    public class Offer : 
        Entity<Offer, string>,
        IAggregateRoot
    {
        public override string Id { get; protected set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int NumberOfDays { get; private set; }

        public IReadOnlyCollection<Photo> Photos => _photos;

        protected Offer()
        {
            _photos = new List<Photo>();
        }

        public Offer(string name, string description, int numberOfDays)
        {
            _photos = new List<Photo>();

        }

        private List<Photo> _photos;
    }
}
