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
        public Player(string _Name, int _Level, int _MaxHP, int _AttMin, int _AttMax, int _Def, int _Gold)
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
        public int Attack => new Random().Next(AttackPower_Min, AttackPower_Max);
        public int AttackPower_Min { get; }
        public int AttackPower_Max { get; }
        public int Defense { get; set; }
        public bool IsDead => HP <= 0;

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
        public int FinalAtt()
        {
            int equip_Att = 0;

            if (equip_Item[(int)ItemSlotType.ITEMTYPE_WEAPON] != null)
            {
                equip_Att = equip_Item[(int)ItemSlotType.ITEMTYPE_WEAPON].Bonus;
            }

            int _finalAtt = ((AttackPower_Min + AttackPower_Max) / 2)  + equip_Att;

            return _finalAtt;
        }

    }
}
