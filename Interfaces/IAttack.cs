using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDevProject.Interfaces;

namespace GameDevProject.Interfaces
{
    public interface IAttack : IGameObject
    {
        //IGameObject for update and draw
        void ExecuteAttack(Vector2 position, Vector2 direction);
        bool IsActive { get; }
        //float AttackSpeed { get; set; }
    }
}