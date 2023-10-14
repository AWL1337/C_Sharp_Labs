namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public sealed class Asteroid : BaseObstacle
{
    private const int ObstacleDamage = 1;
    public Asteroid(int obstacleAmount)
        : base(ObstacleDamage, obstacleAmount)
    {
    }
}