using System;
using System.Collections.Generic;

namespace Nvp.Events
{

    public delegate void EventMessageDelegate(object sender, object eventArgs);
    
    public static class EventManager
    {
        private static Dictionary<int, EventMessageDelegate> _eventHandlers;

        static EventManager()
        {
            _eventHandlers = new Dictionary<int, EventMessageDelegate>();
        }




        // +++ adding event listeners +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void AddEventListener(GameEvents ge, EventMessageDelegate listener)
        {
            EventMessageDelegate temp;
            if (_eventHandlers.TryGetValue((int)ge, out temp))
            {
                temp += listener;
                _eventHandlers[(int)ge] = temp;
            }
            else
            {
                temp = delegate { };
                temp += listener;
                _eventHandlers.Add((int)ge, temp);
            }
        }

        public static void AddEventListener(string gameEvent, EventMessageDelegate listener)
        {
            var hash = gameEvent.GetHashCode();
            EventMessageDelegate temp;
            if (_eventHandlers.TryGetValue(hash, out temp))
            {
                temp += listener;
                _eventHandlers[hash] = temp;
            }
            else
            {
                temp = delegate { };
                temp += listener;
                _eventHandlers.Add(hash, temp);
            }
        }




        // +++ removing event listeners +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++    
        public static void RemoveEventListener(GameEvents ge, EventMessageDelegate listener)
        {
            EventMessageDelegate temp;
            if (_eventHandlers.TryGetValue((int)ge, out temp))
            {
                temp -= listener;
                _eventHandlers[(int)ge] = temp;
            }
        }

        public static void RemoveEventListener(string gameEvent, EventMessageDelegate listener)
        {
            var hash = gameEvent.GetHashCode();

            EventMessageDelegate temp;
            if (_eventHandlers.TryGetValue(hash, out temp))
            {
                temp -= listener;
                _eventHandlers[hash] = temp;
            }
        }




        // +++ Invoking events ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void Invoke(GameEvents ge, object sender, object eventArgs)
        {
            EventMessageDelegate temp;
            if (_eventHandlers.TryGetValue((int)ge, out temp))
            {
                temp.Invoke(sender, eventArgs);
            }
            else
            {
                UnityEngine.Debug.LogWarning($"No subscribers to invoked event [{ge}]");
            }
        }

        public static void Invoke(string gameEvent, object sender, object eventArgs)
        {
            var hash = gameEvent.GetHashCode();
            EventMessageDelegate temp;
            if (_eventHandlers.TryGetValue(hash, out temp))
            {
                var list = temp.GetInvocationList();

                temp.Invoke(sender, eventArgs);
            }
            else
            {
                UnityEngine.Debug.LogWarning($"No subscribers to invoked event [{gameEvent}]");
            }
        }
    }

    
}