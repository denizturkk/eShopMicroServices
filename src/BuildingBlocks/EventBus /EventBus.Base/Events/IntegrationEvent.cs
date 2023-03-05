using System;
using Newtonsoft.Json;

namespace EventBus.Base.Events
{
	public class IntegrationEvent
	{
        [JsonProperty]
		public Guid Id { get; private set; }
        [JsonProperty]
        public DateTime CreatedDate { get; private set; }

       
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }

        [JsonConstructor]
        public IntegrationEvent(Guid ıd, DateTime createdDate )
        {
            Id = ıd;
            CreatedDate = createdDate;
        }
    }
}

