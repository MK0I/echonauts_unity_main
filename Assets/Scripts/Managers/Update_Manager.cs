using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Context))]
public sealed class Update_Manager : MonoBehaviour
{
    private Context context;

    private readonly List<IInit> _initSystems = new List<IInit>();
    private readonly List<ITick> _ticks = new List<ITick>();
    private readonly List<IFixedTick> _fixedTicks = new List<IFixedTick>();
    private readonly List<ILateTick> _lateTicks = new List<ILateTick>();
    private bool _lateTicksDirty;

    private void Awake()
    {
        context = GetComponent<Context>();
        context.Build();

        MonoBehaviour[] behaviours = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour behaviour in behaviours)
        {
            Register(behaviour);
        }

        foreach (IInit system in _initSystems)
        {
            system.Initialize(context);
        }

        Debug.Log("Initialization complete.");
    }

    // Kept for anything created after Awake (e.g. a runtime-spawned
    // object implementing one of these interfaces). Note this does NOT
    // call Initialize() on late registrants — call it yourself right
    // after Register() if the object needs Context.
    public void Register(object system)
    {
        if (system is IInit init) _initSystems.Add(init);
        if (system is ITick t) _ticks.Add(t);
        if (system is IFixedTick f) _fixedTicks.Add(f);
        if (system is ILateTick l)
        {
            _lateTicks.Add(l);
            _lateTicksDirty = true;
        }
    }

    public void Unregister(object system)
    {
        if (system is IInit init) _initSystems.Remove(init);
        if (system is ITick t) _ticks.Remove(t);
        if (system is IFixedTick f) _fixedTicks.Remove(f);
        if (system is ILateTick l)
        {
            _lateTicks.Remove(l);
            _lateTicksDirty = true;
        }
    }

    private void SortLateTicksIfNeeded()
    {
        if (!_lateTicksDirty) return;
        _lateTicks.Sort((a, b) => a.Order.CompareTo(b.Order));
        _lateTicksDirty = false;

#if UNITY_EDITOR
        var order = "";
        foreach (var lt in _lateTicks) order += $"{lt.GetType().Name}({lt.Order}) -> ";
        Debug.Log("[Update_Manager] LateTick order: " + order.TrimEnd(' ', '-', '>'));
#endif
    }

    private void Update()
    {
        for (int i = 0; i < _ticks.Count; i++) _ticks[i].Tick();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < _fixedTicks.Count; i++) _fixedTicks[i].FixedTick();
    }

    private void LateUpdate()
    {
        SortLateTicksIfNeeded();
        for (int i = 0; i < _lateTicks.Count; i++) _lateTicks[i].LateTick();
    }
}