namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public sealed class AntimatterFlares : BaseObstacle
{
    private const int ObstacleDamage = 0;
    public AntimatterFlares(int obstacleAmount)
        : base(ObstacleDamage, obstacleAmount)
    {
    }
}