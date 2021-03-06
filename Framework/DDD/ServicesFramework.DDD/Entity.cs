﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesFramework.DDD
{
    /// <summary>
    /// This is a trivial class that is used to make sure that Equals and GetHashCode
    /// are properly overloaded with the correct semantics. This is exteremely important
    /// if you are going to deal with objects outside the current Unit of Work.
    /// https://ayende.com/blog/2500/generic-entity-equality
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TDomainId"></typeparam>
    public abstract class Entity<T, TDomainId> : IEntity
        where T : Entity<T, TDomainId>
    {
        protected int _technicalId;

        private List<IDomainEvent> domainEvents;

        public List<IDomainEvent> DomainEvents => domainEvents;

        public void AddDomainEvent(IDomainEvent @event)
        {
            if (domainEvents == null)
                domainEvents = new List<IDomainEvent>();
            domainEvents.Add(@event);
        }

        private int? cachedHashCode;

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            T other = obj as T;
            if (other == null)
                return false;
            //to handle the case of comparing two new objects
            bool otherIsTransient = Equals(other.Id, default(TDomainId));
            bool thisIsTransient = Equals(this.Id, default(TDomainId));
            if (otherIsTransient && thisIsTransient)
                return ReferenceEquals(other, this);
            return other.Id.Equals(Id);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. <see cref="M:System.Object.GetHashCode"></see> is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override int GetHashCode()
        {
            //This is done se we won't change the hash code
            if (cachedHashCode.HasValue)
                return cachedHashCode.Value;
            bool thisIsTransient = Equals(this.Id, default(TDomainId));
            //When we are transient, we use the base GetHashCode()
            //and remember it, so an instance can't change its hash code.
            if (thisIsTransient)
            {
                cachedHashCode = base.GetHashCode();
                return cachedHashCode.Value;
            }
            return Id.GetHashCode();
        }

        /// <summary>
        /// Get or set the Id of this entity
        /// </summary>
        public abstract TDomainId Id { get; protected set; }

        /// <summary>
        /// Equality operator so we can have == semantics
        /// </summary>
        public static bool operator==(Entity<T, TDomainId> x, Entity<T, TDomainId> y)
        {
            return Equals(x, y);
        }

        /// <summary>
        /// Inequality operator so we can have != semantics
        /// </summary>
        public static bool operator!=(Entity<T, TDomainId> x, Entity<T, TDomainId> y)
        {
            return !(x == y);
        }
    }
}
