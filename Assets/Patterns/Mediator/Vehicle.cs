namespace Patterns.Mediator
{
    public interface IVehicle
    {
        void BrakePressed();
        void BrakeReleased();
        void LeftPressed();
        void RightPressed();
        void ObstacleDetected();
    }
}