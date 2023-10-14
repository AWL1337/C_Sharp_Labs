namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public sealed class Meteorite : BaseObstacle
{
    private const int ObstacleDamage = 5;
    public Meteorite(int obstacleAmount)
        : base(ObstacleDamage, obstacleAmount)
    {
    }
}