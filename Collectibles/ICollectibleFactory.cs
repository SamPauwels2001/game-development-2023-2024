using System;

public interface ICollectibleFactory
{
    ICollectible Create(string type);
}
