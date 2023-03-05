using System;
using EventBus.Base.Events;

namespace EventBus.Base.Abstraction
{
	public interface IEventBusSubscriptionManager
	{
		//is there any subscription
		bool IsEmpty { get; }

		//when an event is unsubscribed from an external source
		//this event will be trigered
		event EventHandler<string> OnEventRemoved;

		void AddSubscription<T, TH> () where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;

        void RemoveSubscription<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;

		bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent;

		bool HasSubscriptionsForEvent(string eventName);

		Type GetEventTypeByName(string eventName);	

		void Clear();

		IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent;

		IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);

		string GetEventKey<T>();
    }
}

 