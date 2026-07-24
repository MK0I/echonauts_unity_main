using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

[RequireComponent(typeof(Context))]
public class Update_Manager : MonoBehaviour
{
    Context context;

    readonly List<IInit> initializeSystems = new();

    readonly List<ITick> tickSystems = new();

    readonly List<ILateTick> lateSystems = new();

    readonly List<IFixedTick> fixedSystems = new();

    void Awake()
    {
        context = GetComponent<Context>();

        context.Build(); // Builds Context and its components

        MonoBehaviour[] behaviours = GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour behaviour in behaviours)
        {
            if (behaviour is IInit init)
                initializeSystems.Add(init);

            if (behaviour is ITick tick)
                tickSystems.Add(tick);

            if (behaviour is ILateTick late)
                lateSystems.Add(late);

            if (behaviour is IFixedTick fixedTick)
                fixedSystems.Add(fixedTick);
        }

        foreach (IInit system in initializeSystems)
        {
            system.Initialize(context);
        }

        Debug.Log("Initialization complete.");

    }

    void Update()
    {
        foreach (ITick system in tickSystems)
        {
            system.Tick();
        }
    }

    void LateUpdate()
    {
        foreach (ILateTick system in lateSystems)
        {
            system.LateTick();
        }
            
    }

    void FixedUpdate()
    {
        foreach (IFixedTick system in fixedSystems)
        {
            system.FixedTick();
        }
            
    }

}