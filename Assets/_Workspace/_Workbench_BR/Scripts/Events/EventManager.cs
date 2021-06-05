using System.Collections.Generic;

namespace Nvp.Events
{

    public delegate void EventMessageDelegate(object sender, object eventArgs);

    public static class EventManager
    {
        private static Dictionary<GameEvents, EventMessageDelegate> _eventHandlers;

        static EventManager()
        {
            _eventHandlers = new Dictionary<GameEvents, EventMessageDelegate>();
        }

        public static void AddEventListener(GameEvents ge, EventMessageDelegate listener)
        {
            EventMessageDelegate temp;
            if (_eventHandlers.TryGetValue(ge, out temp))
            {
                temp += listener;
            }
            else
            {
                temp += listener;
                _eventHandlers.Add(ge, temp);
            }
        }

        public static void RemoveEventListener(GameEvents ge, EventMessageDelegate listener)
        {
            EventMessageDelegate temp;
            if (_eventHandlers.TryGetValue(ge, out temp))
            {
                temp -= listener;
            }
        }

        public static void Invoke(GameEvents ge, object sender, object eventArgs)
        {
            EventMessageDelegate temp;
            if (_eventHandlers.TryGetValue(ge, out temp))
            {
                temp.Invoke(sender, eventArgs);
            }
            else
            {
                UnityEngine.Debug.LogWarning($"No subscribers to invoked event [{ge}");
            }
        }

        
    }
}