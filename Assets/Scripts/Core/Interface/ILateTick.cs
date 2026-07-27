using UnityEngine;

public interface ILateTick
{
    int Order { get; }
    void LateTick();

}
