using System.Collections.Generic;
using UnityEngine;

public sealed class Pose_Control : MonoBehaviour, IInit, ILateTick
{
    public int Order => 100; // After Capture : Before FK_Control

    private Pose_State poseState;
    private List<IPoseModifier> modifiers;

    public Pose_State State => poseState;

    public void Initialize(Context ctx)
    {
        poseState = ctx.Pose_State;

        modifiers = new List<IPoseModifier>(GetComponentsInChildren<IPoseModifier>());
        modifiers.Sort((a, b) => a.Order.CompareTo(b.Order));
    }

    public void LateTick()
    {
        poseState.Clear();

        for (int i = 0; i < modifiers.Count; i++)
        {
            modifiers[i].Apply(poseState);
        }
    }
}