using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Shields;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship;

public class Augur : BaseShip
{
    private const double BigMass = 7;

    public Augur(PhotonShield? photonShield = null)
        : base(
            new HullClass3(),
            new ShieldClass3(),
            new ImpulseEngineE(),
            new JumpEngineAlpha(),
            photonShield,
            null,
            BigMass)
    {
    }
}