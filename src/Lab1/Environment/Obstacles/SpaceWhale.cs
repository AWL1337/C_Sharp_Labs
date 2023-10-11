namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public sealed class SpaceWhale : BaseObstacle
{
    private const int ObstacleDamage = 1000;
    public SpaceWhale(int obstacleAmount)
        : base(ObstacleDamage, obstacleAmount)
    {
    }
}