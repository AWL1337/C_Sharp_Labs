namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Shields;

public class PhotonShield
{
    private const int ShieldHp = 3;
    private const int DeactivatedShield = 0;
    public PhotonShield()
    {
        Durability = ShieldHp;
    }

    public int Durability { get; private set; }

    public void TakeDamage(int amount)
    {
        Durability -= amount;
    }

    public bool IsActive()
    {
        return Durability > DeactivatedShield;
    }
}