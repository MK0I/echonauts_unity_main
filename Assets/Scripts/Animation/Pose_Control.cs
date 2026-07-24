using System.Collections.Generic;
using UnityEngine;

public sealed class Pose_Control : MonoBehaviour, IInit, ILateTick
{
    private Pose_State poseState;

    private readonly List<IPoseModifier> poseModifiers = new();

    public void Initialize(Context context)
    {
        poseState = context.Pose_State;

        foreach (MonoBehaviour behaviour in GetComponents<MonoBehaviour>())
        {
            if (behaviour is IPoseModifier modifier)
                poseModifiers.Add(modifier);
        }

        poseModifiers.Sort((a, b) => a.Order.CompareTo(b.Order));

    }

    public void LateTick()
    {
        ResetPose();

        foreach (IPoseModifier modifier in poseModifiers)
        {
            modifier.Apply(poseState);
        }
    }

    private void ResetPose()
    {
        poseState.SpineRotation = 0f;
        poseState.NeckRotation = 0f;

        poseState.UpperArmNearRotation = 0f;
        poseState.LowerArmNearRotation = 0f;
        poseState.HandNearRotation = 0f;

        poseState.UpperArmFarRotation = 0f;
        poseState.LowerArmFarRotation = 0f;
        poseState.HandFarRotation = 0f;
    }
}