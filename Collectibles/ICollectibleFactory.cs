using System;
using GameDevProject;

public interface ICollectibleFactory
{
    ICollectible Create(string type);
}
