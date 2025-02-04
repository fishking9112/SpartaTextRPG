using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    internal class ShowInven : IScene
    {
        public ShowInven()
        {
            this._player = MainGame.Instance.player;
            InvenItemList = ((Player)_player).InvenItemList;
        }

        private ICharacter _player;
        private List<Item> InvenItemList;

        public void SceneMenuDraw()
        {
            Console.Clear();
            Console.WriteLine("[ 아이템 목록 ]");

            ShowInvenList(false);

            Console.WriteLine(" 0. 나가기 : ");
            Console.WriteLine(" 1. 장착 관리 : ");
            Console.WriteLine(" 선택 : ");

            int iSelect = int.Parse(Console.ReadLine());

            switch (iSelect)
            {
                case 0://나가기
                    SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_TOWN);
                    break;
                case 1://장착 관리
                    EquipItem();
                    break;
                default://다시 인벤토리
                    SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_SHOWINVEN);
                    break;
            }
        }

        private void ShowInvenList(bool isEquip)
        {
            int MenuNumber = 1;
            foreach (Item item in InvenItemList)
            {
                // 장착관리 중이면 목록 번호 넣기
                if (isEquip)
                    Console.Write($"- {MenuNumber} ");
                else
                    Console.Write($"- ");

                // 장창중인 아이템에 [E] 표시
                if(item is Equip_Item)
                {
                    Equip_Item equip = item as Equip_Item;
                    if(equip.IsEquip == true)
                    {
                        Console.Write($"[E]");
                    }
                }

                //이름 칸맞추기
                if (item.Name.Length > 6)
                    Console.Write($"{item.Name}\t");
                else
                    Console.Write($"{item.Name}\t\t");

                if (item is Equip_Item)
                {
                    Equip_Item equip = item as Equip_Item;
                    if (equip.SlotType == ItemSlotType.ITEMTYPE_WEAPON)
                    {
                        Console.Write($"| 공격력");
                    }
                    else
                    {
                        Console.Write($"| 방어력");
                    }
                }

                Console.Write($" + {item.Bonus}\t");
                Console.WriteLine($"| {item.Description}\t");

                MenuNumber++;
            }
        }
        private void EquipItem()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("[ 아이템 목록 - 장착 관리]");

                ShowInvenList(true);

                Console.WriteLine(" 0. 나가기 : ");

                /*
                 * 장착 + 장착개선
                 * 장착관리가 시작되면 아이템 목록 앞에 숫자가 표시됩니다.
                 * 
                 * - 일치하는 아이템을 선택했다면 (예제에서 1~3선택시)
                 * - 장착중이지 않다면 → 장착
                 * [E] 표시 추가
                 * - 이미 장착중이라면 → 장착 해제
                 * [E] 표시 없애기
                 * 
                 * 일치하는 아이템을 선택했지 않았다면 (예제에서 1~3이외 선택시)
                 * 잘못된 입력입니다 출력
                 * 
                 * 각 타입별로 하나의 아이템만 장착가능 - ( 방어구 / 무기 )
                 * 방어구를 장착하면 기존 방어구가 있다면 해제하고 장착
                 * 무기를 장착하면 기존 무기가 있다면 해제하고 장착
                 */

                int iSelect = int.Parse(Console.ReadLine());

                if (iSelect == 0)   // 나가기
                {
                    SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_TOWN);
                    break;
                }

                if (iSelect < 0 || iSelect > InvenItemList.Count)
                {
                    Console.WriteLine(" 잘못된 입력입니다. ");
                    Thread.Sleep(1000);
                    continue;
                }

                Item SelectItem = InvenItemList[iSelect - 1];

                //장착 중인 아이템인지 확인

                //장착중이 아님
                // 해당 슬롯 칸이 비어있으면 ?
                // 장착
                // 안비어있으면 ?
                // 교체
                //장착중이면
                // 장착 해제

                //웨폰인지 아머인지
                ItemSlotType Type = ((Equip_Item)InvenItemList[iSelect - 1]).SlotType;

                if (((Equip_Item)InvenItemList[iSelect - 1]).IsEquip == false) //장착중이 아님
                {

                    if(((Player)_player).equip_Item[(int)Type] == null) // 해당 슬롯 칸이 비어있으면 ?
                    {
                        // 장착
                        ((Player)_player).equip_Item[(int)Type] = (Equip_Item)InvenItemList[iSelect - 1];
                        ((Equip_Item)InvenItemList[iSelect - 1]).IsEquip = true;
                    }
                    else  // 안비어있으면 ?
                    {
                        // 교체
                        // 장착 해제
                        ((Player)_player).equip_Item[(int)Type].IsEquip = false;
                        ((Equip_Item)InvenItemList[iSelect - 1]).IsEquip = false;
                        // 장착
                        ((Player)_player).equip_Item[(int)Type] = (Equip_Item)InvenItemList[iSelect - 1];
                        ((Equip_Item)InvenItemList[iSelect - 1]).IsEquip = true;
                    }
                }
                else //장착중이면
                {
                    // 장착 해제
                    ((Player)_player).equip_Item[(int)Type].IsEquip = false;
                    ((Equip_Item)InvenItemList[iSelect - 1]).IsEquip = false;

                }
            }

        }
    }
}
