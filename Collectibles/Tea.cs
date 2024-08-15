public class Tea : IPowerUp
{
    public void Collect(Player player)
    {
        ApplyEffect(player);
    }

    public void ApplyEffect(Player player)
    {
        // Increase attack speed
    }
}
