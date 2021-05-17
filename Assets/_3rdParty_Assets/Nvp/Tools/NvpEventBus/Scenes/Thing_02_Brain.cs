using System.Collections;
using System.Collections.Generic;
using Nvp.Tools.Events;
using Nvp.Tools.Events.EventBus;
using UnityEngine;

public class Thing_02_Brain : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    // +++ unity event functions ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Start()
    {
        
    }

    void OnEnable()
    {
        NvpEventBus.AddListener("AttackAll", OnAttacked);
    }

    void OnDisable()
    {
        NvpEventBus.RemoveListener("AttackAll", OnAttacked);
    }

    // Update is called once per frame

    void Update()
    {
        
    }


    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnAttacked(object eventArgs)
    {
        // unbox eventArgs
        var damage = (int) eventArgs;

        _health -= damage;

        if (_health <= 0)
        {
            Debug.Log($"{this.gameObject.name}: still dies");

            Destroy(this.gameObject,0.01f);
        }
        else
        {
            Debug.Log($"{this.gameObject.name}: still alive");
        }

        NvpEventBus.DispatchEvent("Thing02Hit", _health);
    }
}
