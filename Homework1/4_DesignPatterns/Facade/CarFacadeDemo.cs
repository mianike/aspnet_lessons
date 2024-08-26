using Facade.Interfaces;

namespace Facade
{
    public class CarFacadeDemo
    {
        private readonly ITurnSignals _turnSignals;
        private readonly ISteeringWheel _steeringWheel;
        private readonly IEngine _engine;
        private readonly IBrakingSystem _brakingSystem;

        public CarFacadeDemo(ITurnSignals turnSignals, ISteeringWheel steeringWheel, IEngine engine, IBrakingSystem brakingSystem)
        {
            _turnSignals = turnSignals;
            _steeringWheel = steeringWheel;
            _engine = engine;
            _brakingSystem = brakingSystem;
        }

        public void Movement()
        {
            _turnSignals.TurnOnLeft();
            _steeringWheel.TurnOnLeft();
            _engine.IncreaseFuelSupply();
            _steeringWheel.TurnOnRight();
            _turnSignals.TurnOffLeft();
        }

        public void Stop()
        {
            _turnSignals.TurnOnRight();
            _engine.EngineIdling();
            _brakingSystem.Braking();
            _brakingSystem.ReleaseBrake();
            _steeringWheel.TurnOnRight();
            _steeringWheel.TurnOnLeft();
            _brakingSystem.Braking();
            _turnSignals.TurnOffRight();
        }
    }
}
