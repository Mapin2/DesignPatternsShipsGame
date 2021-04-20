using UnityEngine;

namespace Ships
{
    public class ShipInstaller : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        [SerializeField] private bool _useAI;
        [SerializeField] private float maxAIDistance;

        [SerializeField] private bool _useJoystick;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Ship _ship;

        private void Awake()
        {
            _ship.Configure(GetInput(), GetCheckLimitsStrategy());
        }

        private Input GetInput()
        {
            if (_useAI)
            {
                Destroy(_joystick.gameObject);
                return new AIInputAdapter(_ship.transform, _camera);
            }

            if (_useJoystick)
            {
                return new JoystickInputAdapter(_joystick);
            }

            Destroy(_joystick.gameObject);
            return new UnityInputAdapter();
        }

        private ICheckLimits GetCheckLimitsStrategy()
        {
            // TODO: With this ICheckLimit strategy on the IA, the AIInputAdapter won't work, bcs it was based on viewport to change movement, maybe create another adapter
            if (_useAI)
                return new InitialPositionCheckLimits(_ship.transform, maxAIDistance);

            return new ViewportCheckLimits(_ship.transform, _camera);
        }
    }
}