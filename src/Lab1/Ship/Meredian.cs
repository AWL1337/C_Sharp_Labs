using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Shields;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship;

public class Meredian : BaseShip
{
    private const double MediumMass = 1;

    public Meredian(PhotonShield? photonShield = null)
        : base(
            new HullClass2(),
            new ShieldClass2(),
            new ImpulseEngineE(),
            null,
            photonShield,
            new AntiNeutrinoEmitter(),
            MediumMass)
    {
    }
}