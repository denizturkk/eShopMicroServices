using System;
using EventBus.Base.Abstraction;
using EventBus.Base.Events;

namespace EventBus.Base.SubscriptionManagers
{
	public class InMemoryEventBusSubscriptionManager:IEventBusSubscriptionManager
	{
        private readonly Dictionary <string,List<SubscriptionInfo>> _handlers;
        private readonly List<Type> _eventTypes;
        public event EventHandler<string> OnEventRemoved;
        public Func<string, string> eventNameGetter;

        public InMemoryEventBusSubscriptionManager(Func<string, string> eventNameGetter)
		{
            _handlers = new Dictionary<string, List<SubscriptionInfo>>();
            _eventTypes = new List<Type>();
            this.eventNameGetter = eventNameGetter;
        }

        public bool IsEmpty => !_handlers.Keys.Any();

        public void AddSubscription<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>
        {
            var eventName = GetEventKey<T>();
            AddSubscription(typeof(TH), eventName);

            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

        }

        private void AddSubscription(Type handlerType, string eventName)
        {
            if (!HasSubscriptionsForEvent(eventName))
            {
                _handlers.Add(eventName, new List<SubscriptionInfo>());
            }
            if (_handlers[eventName].Any(s=>s.HandlerType==handlerType))
            {
                throw new ArgumentException($"handler type {handlerType.Name} allready registered for '{eventName}'",nameof(handlerType));
            }

            _handlers[eventName].Add(SubscriptionInfo.Typed(handlerType));
        }

        public void Clear() => _handlers.Clear();


        public string GetEventKey<T>()
        {
            throw new NotImplementedException();
        }

        public Type GetEventTypeByName(string eventName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName)
        {
            throw new NotImplementedException();
        }

        public bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent
        {
            throw new NotImplementedException();
        }

        public bool HasSubscriptionsForEvent(string eventName)
        {
            throw new NotImplementedException();
        }

        public void RemoveSubscription<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }
    }
}

 