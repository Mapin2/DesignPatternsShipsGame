using UnityEngine;

namespace Ships
{
    public class UnityInputAdapter : Input
    {
        public Vector2 GetDirection()
        {
            var horizontal = UnityEngine.Input.GetAxis("Horizontal");
            var vertical = UnityEngine.Input.GetAxis("Vertical");
            return new Vector2(horizontal, vertical);
        }
    }
}