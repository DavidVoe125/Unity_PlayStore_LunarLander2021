using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarLander.ExtensionMethods
{
    public static class LunarLanderExtensions
    {
        public static T GetValueAs<T>(this object o)
        {
            return (T)o;
        }
    }
}
