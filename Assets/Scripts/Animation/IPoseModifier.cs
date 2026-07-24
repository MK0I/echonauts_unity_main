using UnityEngine;

public interface IPoseModifier
{
    int Order { get; }

    void Apply(Pose_State pose);
}