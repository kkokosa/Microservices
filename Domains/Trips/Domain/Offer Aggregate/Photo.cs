using ServicesFramework.DDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trips.Domain
{
    public class Photo : Entity<Photo, string>
    {
        public override string Id { get; protected set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
    }
}
