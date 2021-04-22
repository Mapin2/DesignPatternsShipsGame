using UnityEngine;

namespace Input
{
    public interface IInput
    {
        Vector2 GetDirection();
        bool IsFireActionPressed();
    }
}