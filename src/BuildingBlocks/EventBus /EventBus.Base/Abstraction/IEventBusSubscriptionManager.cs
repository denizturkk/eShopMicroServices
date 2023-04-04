  using EventBus.Base.Events;
using System;
using System.Collections.Generic;

namespace EventBus.Base.Abstraction
{
    public interface IEventBusSubscriptionManager
    {
        //herhangi bir event'i dinliyor muyuz
        bool IsEmpty { get; }

       // event that will be triggered when an unsubscribe happens
        event EventHandler<string> OnEventRemoved;

        void AddSubscription<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;

        void RemoveSubscription<T, TH>() where TH : IIntegrationEventHandler<T> where T : IntegrationEvent;

        bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent;

        bool HasSubscriptionsForEvent(string eventName);

        Type GetEventTypeByName(string eventName);

        void Clear();

        IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent;

        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);

        string GetEventKey<T>() where T : IntegrationEvent;
    }
}