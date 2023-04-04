using System;
namespace EventBus.Base
{
	public class SubscriptionInfo
	{
        //dışarıdan gönderilen verilerin ıcerıde tutulması için
        //bize gonderilen integration eventın tipini tutucaz
		public Type HandlerType { get; }

        public SubscriptionInfo(Type handlerType)
        {
            HandlerType = handlerType ?? throw new ArgumentNullException(nameof(handlerType));
        }

        
        public static SubscriptionInfo Typed(Type handlerType)
        {
            return new SubscriptionInfo(handlerType);
        }
    }
} 

 