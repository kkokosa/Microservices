﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesFramework.DDD
{
    public interface IDomainEvent : INotification
    {
    }
}
