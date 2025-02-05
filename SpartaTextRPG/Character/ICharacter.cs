using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 캐릭터의 인터페이스 cs
// 플레이어 , 몬스터 둘다 캐릭터 인터페이스를 상속받는다.

namespace SpartaTextRPG
{
    public interface ICharacter
    {
        string Name { get; }
        int Level { get; set; }
        int HP { get; set; }
        int MaxHP { get; set; }
        float AttackPower_Min { get; }
        float AttackPower_Max { get; }
        int Defense { get; set; }
        bool IsDead { get; }
    }
}
