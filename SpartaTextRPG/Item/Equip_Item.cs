using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    internal class Equip_Item : Item
    {
        public Equip_Item(string _Name, string _Des, ItemType _Type, int _Bonus, int _Price) : base(_Name, _Des , _Type , _Bonus, _Price)
        {
            Name = _Name;
            Description = _Des;
            Type = _Type;
            Bonus = _Bonus;
            Price = _Price;

            IsEquip = false;
        }

        string Name { get; set; }
        string Description { get; }
        public int Bonus { get; set; }
        public ItemType Type { get; set; }
        public int Price { get; set; }

        // 장착 여부
        bool IsEquip {  get; set; }
    }
}
