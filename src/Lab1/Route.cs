using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Route
{
    private readonly Collection<BaseShip> _ships;
    private readonly Collection<BaseEnvironment> _environments;

    public Route(Collection<BaseShip> ships, Collection<BaseEnvironment> environments)
    {
        _ships = ships;
        _environments = environments;
    }

    public void WillPass()
    {
        foreach (BaseShip ship in _ships)
        {
            bool passFlag = _environments.Aggregate(true, (current, environment) => current && environment.Pass(ship));
            ship.IsPassed = passFlag;
        }
    }

    public BaseShip? OptimalShip()
    {
        WillPass();

        BaseShip? optimalShip = _ships.Where(obj => obj.IsPassed).MinBy(ship => ship.FlightCost);

        return optimalShip;
    }
}