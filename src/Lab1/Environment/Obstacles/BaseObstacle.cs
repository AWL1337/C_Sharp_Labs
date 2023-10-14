using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public abstract class BaseObstacle
{
    private readonly string errorMesage = "Amount Of Obstacles cannot be less than 0.";
    private int _obstacleAmount;
    protected BaseObstacle(int damage, int obstacleAmount)
    {
        Damage = damage;
        ObstacleAmount = obstacleAmount;
    }

    public int Damage { get; }

    public int ObstacleAmount
    {
        get => _obstacleAmount;

        private set
        {
            if (value < 0)
            {
                throw new WrongAmountOfObstaclesException(errorMesage);
            }

            _obstacleAmount = value;
        }
    }

    public void Crush(int amount = 1)
    {
        ObstacleAmount -= amount;
    }
}