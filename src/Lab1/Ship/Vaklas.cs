using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Shields;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship;

public class Vaklas : BaseShip
{
    private const double MediumMass = 1;

    public Vaklas(PhotonShield? photonShield = null)
        : base(
            new HullClass2(),
            new ShieldClass1(),
            new ImpulseEngineE(),
            new JumpEngineGamma(),
            photonShield,
            null,
            MediumMass)
    {
    }
}