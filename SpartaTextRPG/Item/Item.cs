using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    enum ItemType { ItemType_Weapon , ItemType_Armor}
    internal class Item
    {
        public string Name { get; set; }
        public string Description { get; }
        public int Bonus { get; set; }

        public ItemType Type { get; set; }

        public int Price { get; set; }

        public Item(string _Name , string _Des , ItemType _Type , int _Bonus , int _Price)
        {
            Name = _Name; 
            Description = _Des;
            Type = _Type;
            Bonus = _Bonus;
            Price = _Price;
        }
    }
}

/*
 소비 아이템이 없네 .. ?

일단 확장성 생각해서 만듦
아이템을 장착 / 소비 나누자

 */