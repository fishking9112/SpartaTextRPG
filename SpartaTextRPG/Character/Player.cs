using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    internal class Player : ICharacter
    {
        public Player() { }
        public Player(string _Name, int _Level, int _MaxHP, float _AttMin, float _AttMax, int _Def, int _Gold)
        {
            Name = _Name;
            Level = _Level;
            HP = _MaxHP;
            MaxHP = _MaxHP;
            AttackPower_Min = _AttMin;
            AttackPower_Max = _AttMax;
            Defense = _Def;
            Gold = _Gold;

            //장착 아이템 초기화
            equip_Item[(int)ItemSlotType.ITEMTYPE_WEAPON] = null;
            equip_Item[(int)ItemSlotType.ITEMTYPE_ARMOR] = null;
        }

        //Player 멤버변수
        public int Gold { get; set; }
        //인벤토리
        public List<Item> InvenItemList = new List<Item>();
        //장착
        public Equip_Item[] equip_Item = new Equip_Item[(int)ItemSlotType.ITEMTYPE_MAX];

        //프로퍼티
        public string Name { get; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public float AttackPower_Min { get; set; }
        public float AttackPower_Max { get; set; }
        public int Defense { get; set; }
        public bool IsDead => HP <= 0;

        //밥먹고 레벨업 만들기
        //경험치 / max경험치 만들고
        // 던전 클리어시 경험치 올려주고
        // 맥스 닿으면 레벨업 , 경험치 0 ,맥스 올려주기
        // 레벨 따라 공 , 방 증가
        // 공격력 0.5 오르므로 , 실수형으로 변경

        public int Exp { get; set; } = 0;
        public int MaxExp { get; set; } = 1;

        ///////// Player
        public int FinalDef()
        {
            int equip_Def = 0;

            if (equip_Item[(int)ItemSlotType.ITEMTYPE_ARMOR] != null)
            {
                equip_Def = equip_Item[(int)ItemSlotType.ITEMTYPE_ARMOR].Bonus;
            }

            int _finalDef = Defense + equip_Def;

            return _finalDef;
        }
        public float FinalAtt()
        {
            int equip_Att = 0;

            if (equip_Item[(int)ItemSlotType.ITEMTYPE_WEAPON] != null)
            {
                equip_Att = equip_Item[(int)ItemSlotType.ITEMTYPE_WEAPON].Bonus;
            }

            float _finalAtt = ((AttackPower_Min + AttackPower_Max) / 2)  + equip_Att;

            return _finalAtt;
        }
        public void ExpUp(int _Exp)
        {
            Exp += _Exp;

            if(Exp >= MaxExp)
            {
                Exp -= MaxExp;
                Level += 1;
                MaxExp = Level;

                //레벨업 시 공 , 방 올라가기
                AttackPower_Min += 0.5f;
                AttackPower_Max += 0.5f;
                Defense += 1;
            }
        }

    }
}
