using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    internal class SaveData
    {
        //저장 할 Player의 변수
        public String Name {  get; set; }
        public int Level { get; set; }
        public int HP {  get; set; }
        public int MaxHP {  get; set; }
        public float AttMin { get; set; }
        public float AttMax { get; set; }
        public int Def {  get; set; }
        public int Gold {  get; set; }
        public int Exp { get; set; }
        public int ExpMax { get; set; }

        public List<Item> InvenItemList = new List<Item>();

        public Equip_Item[] equip_Item = new Equip_Item[(int)ItemSlotType.ITEMTYPE_MAX];
    }
}
