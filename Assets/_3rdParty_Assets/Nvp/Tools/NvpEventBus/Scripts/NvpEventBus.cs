using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Nvp.Tools.Events.EventBus
{
    public static class NvpEventBus
    {
        // +++ private fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        private static Dictionary<int, List<Action<object>>> _eventListenerCallbackMap;


        // +++ constructor ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        static NvpEventBus()
        {
            _eventListenerCallbackMap = new Dictionary<int, List<Action<object>>>();
        }



        // +++ IEventAggregator interface members +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public static void DispatchEvent(string eventName, object eventArgs)
        {
            int hash = eventName.GetHashCode();

            if (_eventListenerCallbackMap.ContainsKey(hash))
            {
                foreach (var callback in _eventListenerCallbackMap[hash])
                {
                    callback(eventArgs);
                }
            }
        }

        public static void DispatchEvent(GE ge, object eventArgs)
        {
            var eventId = (int)ge;

            if (_eventListenerCallbackMap.ContainsKey(eventId))
            {
                foreach (var callback in _eventListenerCallbackMap[eventId])
                {
                    callback(eventArgs);
                }
            }
        }

        public static void AddListener(string eventName, Action<object> callback)
        {
            var hash = eventName.GetHashCode();
            if (_eventListenerCallbackMap.ContainsKey(hash))
            {
                if (_eventListenerCallbackMap[hash] == null)
                {
                    _eventListenerCallbackMap[hash] = new List<Action<object>>();
                }
                else
                {
                    if (_eventListenerCallbackMap[hash].Contains(callback))
                    {
                        _eventListenerCallbackMap[hash].Remove(callback);
                    }
                }
                _eventListenerCallbackMap[hash].Add(callback);
            }
            else
            {
                _eventListenerCallbackMap.Add(hash, new List<Action<object>> { callback });
            }



        }

        public static void AddListener(GE ge, Action<object> callback)
        {
            var eventId = (int)ge;
            if (_eventListenerCallbackMap.ContainsKey(eventId))
            {
                if (_eventListenerCallbackMap[eventId] == null)
                {
                    _eventListenerCallbackMap[eventId] = new List<Action<object>>();
                }
                else
                {
                    if (_eventListenerCallbackMap[eventId].Contains(callback))
                    {
                        _eventListenerCallbackMap[eventId].Remove(callback);
                    }
                }
                _eventListenerCallbackMap[eventId].Add(callback);
            }
            else
            {
                _eventListenerCallbackMap.Add(eventId, new List<Action<object>> { callback });
            }



        }

        public static void RemoveListener(string eventName, Action<object> callback)
        {
            var hash = eventName.GetHashCode();

            if (_eventListenerCallbackMap.ContainsKey(hash))
            {
                if (_eventListenerCallbackMap[hash].Contains(callback))
                {
                    _eventListenerCallbackMap[hash].Remove(callback);
                }
            }
        }

        public static void RemoveListener(GE ge, Action<object> callback)
        {
            var eventId = (int)ge;

            if (_eventListenerCallbackMap.ContainsKey(eventId))
            {
                if (_eventListenerCallbackMap[eventId].Contains(callback))
                {
                    _eventListenerCallbackMap[eventId].Remove(callback);
                }
            }
        }
    }

    public enum GE
    {
        
    }

}
