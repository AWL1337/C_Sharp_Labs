using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Shields;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship;

public class Shuttle : BaseShip
{
    private const double LightMass = 0.33;

    public Shuttle(PhotonShield? photonShield = null)
        : base(
            new HullClass1(),
            null,
            new ImpulseEngineC(),
            null,
            photonShield,
            null,
            LightMass)
    {
    }
}