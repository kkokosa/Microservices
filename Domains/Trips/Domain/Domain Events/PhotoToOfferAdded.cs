﻿using ServicesFramework.DDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trips.Domain.Events
{
    public class PhotoToOfferAdded : IDomainEvent
    {
        public string Title { get; set; }
    }
}
