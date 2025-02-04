using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    enum Item_Type { ITEM_USE , ITEM_EQUIP , ITEM_END }
    internal class Item
    {
        public string Name { get; set; }
        public string Description { get; }
        public int Bonus { get; set; }
        public Item_Type Type { get; set; }

        public int Price { get; set; }

        public Item(string _Name , string _Des  , int _Bonus , int _Price , Item_Type _Type)
        {
            Name = _Name; 
            Description = _Des;
            Bonus = _Bonus;
            Price = _Price;
            Type = _Type;
        }
    }
}

/*
 소비 아이템이 없네 .. ?

일단 확장성 생각해서 만듦
아이템을 장착 / 소비 나누자

 */