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
        void ExecuteAttack(IAttackable target);
        void SetDirection(Vector2 direction);
        bool IsActive { get; }
        float AttackSpeed { get; set; }
        int AttackAmount { get; set; }
    }
}