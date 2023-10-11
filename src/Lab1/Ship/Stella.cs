using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Shields;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship;

public class Stella : BaseShip
{
    private const double LightMass = 0.4;

    public Stella(PhotonShield? photonShield = null)
        : base(
            new HullClass1(),
            new ShieldClass1(),
            new ImpulseEngineC(),
            new JumpEngineOmega(),
            photonShield,
            null,
            LightMass)
    {
    }
}