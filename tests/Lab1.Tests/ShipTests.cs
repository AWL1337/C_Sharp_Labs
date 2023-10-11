using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Shields;
using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShipTests
{
    public static IEnumerable<object[]> NebulaShuttleAugurData()
    {
        yield return new object[] { new Shuttle(), false };
        yield return new object[] { new Augur(), false };
    }

    public static IEnumerable<object[]> NebulaAntimatterFlaresVaklasVaklasWithPhotonicData()
    {
        yield return new object[] { new Vaklas(), false };
        yield return new object[] { new Vaklas(new PhotonShield()), true };
    }

    public static IEnumerable<object[]> NeutrinoNebulaWhalesVaklasAugurMeredianData()
    {
        yield return new object[] { new Vaklas(), false, 0 };
        yield return new object[] { new Augur(), true, 0 };
        yield return new object[] { new Meredian(), true, 30 };
    }

    public static IEnumerable<object[]> NeutrinoNebulaWhalesNormalSpaceMeteoritesAugurShuttleMeredianData()
    {
        yield return new object[] { new Augur(), true };
        yield return new object[] { new Shuttle(), false };
        yield return new object[] { new Meredian(), true };
    }

    [Theory]
    [MemberData(nameof(NebulaShuttleAugurData))]
    public void WillPassNebulaAugurShuttle(BaseShip ship, bool willpass)
    {
        // Arrange
        const double middleDistance = 1000;
        var environment = new Nebula(middleDistance);
        var route = new Route(new Collection<BaseShip>() { ship }, new Collection<BaseEnvironment>() { environment });

        // Act
        route.WillPass();

        // Assert
        Assert.Equal(ship?.IsPassed, willpass);
    }

    [Theory]
    [MemberData(nameof(NebulaAntimatterFlaresVaklasVaklasWithPhotonicData))]
    public void WillPassNebulaAntimatterFlaresVaklasVaklasWithPhotonic(BaseShip ship, bool willpass)
    {
        // Arrange
        const double middleDistance = 1000;
        const int amountOfFlares = 2;

        var obstacle = new AntimatterFlares(amountOfFlares);
        var environment = new Nebula(middleDistance, obstacle);
        var route = new Route(new Collection<BaseShip>() { ship }, new Collection<BaseEnvironment>() { environment });

        // Act
        route.WillPass();

        // Assert
        Assert.Equal(ship?.IsPassed, willpass);
    }

    [Theory]
    [MemberData(nameof(NeutrinoNebulaWhalesVaklasAugurMeredianData))]
    public void WillPassNeutrinoNebula(BaseShip ship, bool willpass, int shieldstatus)
    {
        // Arrange
        const double middleDistance = 1000;
        const int amountOfWhales = 1;

        var obstacle = new SpaceWhale(amountOfWhales);
        var environment = new NeutrinoNebula(middleDistance, obstacle);
        var route = new Route(new Collection<BaseShip>() { ship }, new Collection<BaseEnvironment>() { environment });

        // Act
        route.WillPass();

        // Assert
        Assert.Equal(ship?.IsPassed, willpass);
        Assert.Equal(shieldstatus, ship?.ShieldStatus());
    }

    [Fact]
    public void OptimalShipShortNormalSpace()
    {
        // Arrange
        const double shortDistance = 100;

        var shuttle = new Shuttle();
        var vaklas = new Vaklas();
        var environment = new NormalSpace(shortDistance);
        var route = new Route(new Collection<BaseShip>() { shuttle, vaklas }, new Collection<BaseEnvironment>() { environment });

        // Act
        BaseShip? ship = route.OptimalShip();

        // Assert
        Assert.True(ship is Shuttle);
    }

    [Fact]
    public void OptimalShipMiddleNebula()
    {
        // Arrange
        const double middleDistance = 1000;

        var stella = new Stella();
        var augur = new Augur();
        var environment = new NormalSpace(middleDistance);
        var route = new Route(new Collection<BaseShip>() { stella, augur }, new Collection<BaseEnvironment>() { environment });

        // Act
        BaseShip? ship = route.OptimalShip();

        // Assert
        Assert.True(ship is Stella);
    }

    [Fact]
    public void OptimalShipMiddleNeutrinoNebula()
    {
        // Arrange
        const double middleDistance = 1000;

        var shuttle = new Shuttle();
        var vaklas = new Vaklas();
        var environment = new NeutrinoNebula(middleDistance);
        var route = new Route(new Collection<BaseShip>() { shuttle, vaklas }, new Collection<BaseEnvironment>() { environment });

        // Act
        BaseShip? ship = route.OptimalShip();

        // Assert
        Assert.True(ship is Vaklas);
    }

    [Theory]
    [MemberData(nameof(NeutrinoNebulaWhalesNormalSpaceMeteoritesAugurShuttleMeredianData))]
    public void WillPassNeutrinoNebulaWhalesNormalSpaceMeteoritesAugurShuttleMeredian(BaseShip ship, bool willpass)
    {
        // Arrange
        const double middleDistance = 1000;
        const int amountOfWhales = 1;
        const int amountOfMeteorites = 5;

        var obstacleNebula = new SpaceWhale(amountOfWhales);
        var obstacleSpace = new Meteorite(amountOfMeteorites);

        var nebula = new NeutrinoNebula(middleDistance, obstacleNebula);
        var space = new NormalSpace(middleDistance, obstacleSpace);

        var route = new Route(new Collection<BaseShip>() { ship }, new Collection<BaseEnvironment>() { nebula, space });

        // Act
        route.WillPass();

        // Assert
        Assert.Equal(ship?.IsPassed, willpass);
    }
    }