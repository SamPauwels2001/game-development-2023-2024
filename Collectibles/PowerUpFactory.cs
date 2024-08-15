using System;
using GameDevProject;

public class PowerUpFactory : ICollectibleFactory
{
    public ICollectible Create(string type)
    {
        return type switch
        {
            "tea" => new Tea(),
            "watch" => new Watch(),
            "boot" => new Boot(),
            "orangemarmalade" => new OrangeMarmalade(),
        };
    }
}
