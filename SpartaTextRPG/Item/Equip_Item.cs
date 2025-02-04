using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG.Item
{
    internal class Equip_Item : Item
    {
        public Equip_Item(string _Name, string _Des) : base(_Name, _Des)
        {
            Name = _Name;
            Description = _Des;
            IsEquip = false;
        }

        string Name { get; set; }
        string Description { get; }

        // 장착 여부
        bool IsEquip {  get; set; }
    }
}
