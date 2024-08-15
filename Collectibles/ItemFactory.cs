﻿using System;
using GameDevProject;

public class ItemFactory : ICollectibleFactory
{
    public ICollectible Create(string type)
    {
        return type switch
        {
            "cake" => new Cake(),
            "potion" => new Potion(),
        };
    }
}