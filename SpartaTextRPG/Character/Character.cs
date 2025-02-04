using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 캐릭터의 인터페이스 cs
// 플레이어 , 몬스터 둘다 캐릭터 인터페이스를 상속받는다.

namespace SpartaTextRPG.Character
{
    public interface ICharacter
    {
        string Name { get; }
        int Level { get; set; }
        int HP { get; set; }
        int MaxHP { get; set; }
        int Attack { get; }
        int AttackPower_Min { get; }
        int AttackPower_Max { get; }
        int Defense { get; set; }
        bool IsDead { get; }
        void TakeDamage(int damage);
    }
}
