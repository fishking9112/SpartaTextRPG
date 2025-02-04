using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    enum ItemSlotType { ITEMTYPE_WEAPON, ITEMTYPE_ARMOR, ITEMTYPE_MAX }
    internal class Equip_Item : Item
    {
        public Equip_Item(string _Name, string _Des, ItemSlotType _SlotType, int _Bonus, int _Price , Item_Type _Type) : base(_Name, _Des , _Bonus, _Price , _Type)
        {
            IsEquip = false;
            SlotType = _SlotType;
        }

        public ItemSlotType SlotType { get; set; }
        // 장착 여부
        public bool IsEquip {  get; set; }
    }
}
