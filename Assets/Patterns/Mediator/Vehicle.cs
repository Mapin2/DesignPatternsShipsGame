namespace Patterns.Mediator
{
    public interface Vehicle
    {
        void BrakePressed();
        void BrakeReleased();
        void LeftPressed();
        void RightPressed();
        void ObstacleDetected();
    }
}