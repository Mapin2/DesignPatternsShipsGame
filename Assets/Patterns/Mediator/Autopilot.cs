using System;
using UnityEngine;

namespace Patterns.Mediator
{
    public class Autopilot : MonoBehaviour
    {
        private IVehicle _vehicle;

        public void Configure(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        private void OnTriggerEnter(Collider other)
        {
            _vehicle.ObstacleDetected();
        }
    }
}