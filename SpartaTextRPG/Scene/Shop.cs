using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    internal class Shop : IScene
    {
        public Shop()
        {
            this._player = MainGame.Instance.player;
            ShopInit();
        }

        private Player _player;
        private List<Item> ShopItemList = new List<Item>();
        public void ShopInit()
        {
            // 아이템 셋팅

            //무기
            ShopItemList.Add(new Equip_Item("낡은 검" , "쉽게 볼 수 있는 낡은 검 입니다." , ItemSlotType.ITEMTYPE_WEAPON, 2 , 600 , Item_Type.ITEM_EQUIP));
            ShopItemList.Add(new Equip_Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", ItemSlotType.ITEMTYPE_WEAPON, 5 , 1500, Item_Type.ITEM_EQUIP));
            ShopItemList.Add(new Equip_Item("스파르타의 창 ", "스파르타의 전사들이 사용했다는 전설의 창입니다.", ItemSlotType.ITEMTYPE_WEAPON, 7 , 2500, Item_Type.ITEM_EQUIP));
            ShopItemList.Add(new Equip_Item("노오력", "과제를 다 부수는 몽둥이 입니다.", ItemSlotType.ITEMTYPE_WEAPON, 10, 5000, Item_Type.ITEM_EQUIP));

            //방어구
            ShopItemList.Add(new Equip_Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", ItemSlotType.ITEMTYPE_ARMOR, 5 , 1000, Item_Type.ITEM_EQUIP));
            ShopItemList.Add(new Equip_Item("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", ItemSlotType.ITEMTYPE_ARMOR, 9 , 2000, Item_Type.ITEM_EQUIP));
            ShopItemList.Add(new Equip_Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", ItemSlotType.ITEMTYPE_ARMOR, 15, 3500, Item_Type.ITEM_EQUIP));
            ShopItemList.Add(new Equip_Item("그은성", "과제를 막아내는 마법의 갑옷입니다.", ItemSlotType.ITEMTYPE_ARMOR, 20, 5000, Item_Type.ITEM_EQUIP));

        }
        private void ShowShopMenu(bool isBuying)
        {
            int MenuNumber = 1;
            foreach (var item in ShopItemList)
            {
                // 구매중이면 목록 번호 넣기
                if (isBuying)
                    Console.Write($"- {MenuNumber} ");
                else
                    Console.Write($"- ");

                //이름 칸맞추기
                if (item.Name.Length > 6)
                    Console.Write($"{item.Name}\t");
                else
                    Console.Write($"{item.Name}\t\t");

                if (item.Type == Item_Type.ITEM_EQUIP)
                {
                    Equip_Item equip = item as Equip_Item;
                    if(equip.SlotType == ItemSlotType.ITEMTYPE_WEAPON)
                    {
                        Console.Write($"| 공격력");
                    }
                    else
                    {
                        Console.Write($"| 방어력");
                    }
                }

                Console.Write($" + {item.Bonus}\t");
                Console.Write($"| G : {item.Price}\t");
                Console.WriteLine($"| {item.Description}\t");

                MenuNumber++;
            }
        }
        public void SceneMenuDraw()
        {
            Console.Clear();
            
            Console.WriteLine("[ 상점 ]");
            Console.WriteLine($"현재 보유 금화 : {_player.Gold}");

            ShowShopMenu(false);

            Console.WriteLine(" 0. 나가기 : ");
            Console.WriteLine(" 1. 아이템 구매 : ");
            Console.WriteLine(" 2. 아이템 판매 : ");
            Console.WriteLine(" 선택 : ");

            if (int.TryParse(Console.ReadLine(), out int iSelect) == false)
            {
                SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_SHOP);
            }
            switch (iSelect)
            {
                case 0://나가기
                    SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_TOWN);
                    break;
                case 1://아이템 구매
                    BuyItem();
                    break;
                case 2:
                    SellItem();
                    break;
                default://다시 상점 띄워주기
                    SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_SHOP);
                    break;
            }
        }
        private void BuyItem()
        {
            while(true)
            {
                Console.Clear();

                Console.WriteLine("[ 상점 - 아이템 구매]");
                Console.WriteLine($"현재 보유 금화 : {_player.Gold}");

                ShowShopMenu(true);

                Console.WriteLine(" 0. 나가기 : ");

                /*
                 * 이미 구입한 아이템이면
                 * -> 이미 구매한 아이템입니다. 출력
                 * 
                 * 구매가 가능하다면
                 * -> 보유 금화 체크
                 * 
                 * 목록에 없는거 선택시
                 * -> 잘못된 입력입니다 출력
                 */

                if (int.TryParse(Console.ReadLine(), out int iSelect) == false)
                {
                    continue;
                }

                if (iSelect == 0)   // 나가기
                {
                    SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_TOWN);
                    break;
                }


                if(iSelect < 0 || iSelect > ShopItemList.Count)
                {
                    Console.WriteLine(" 잘못된 입력입니다. ");
                    Thread.Sleep(1000);
                    continue;
                }

                Item SelectItem = ShopItemList[iSelect - 1];

                //이미 구매한 아이템인지 체크
                int findIndex = _player.InvenItemList.FindIndex(x => x.Name.Equals(SelectItem.Name));

                 
                if (findIndex < 0) // 보유중이 아님
                {

                    // 금화 체크
                    if( _player.Gold >= SelectItem.Price)
                    {
                        _player.Gold -= SelectItem.Price;
                        _player.InvenItemList.Add(SelectItem);
                        Console.WriteLine($"{SelectItem.Name} 을(를) {SelectItem.Price} 금화에 구매하였습니다 !");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        //금화 부족
                        Console.WriteLine($"돈이 부족합니다.");
                        Thread.Sleep(1000);
                    }
                    
                }
                else // 해당 아이템 보유중일 경우
                {
                    Console.WriteLine($"{SelectItem.Name} 은 이미 인벤토리에 있습니다.");
                    Thread.Sleep(1000);
                }
            }
        }
        
        private void ShowSellMenu()
        {
            List<Item> InvenItemList = _player.InvenItemList;

            int MenuNumber = 1;
            foreach (Item item in InvenItemList)
            {
                // 목록 번호 넣기
                
                Console.Write($"- {MenuNumber} ");

                // 장창중인 아이템에 [E] 표시
                if (item is Equip_Item)
                {
                    Equip_Item equip = item as Equip_Item;
                    if (equip.IsEquip == true)
                    {
                        Console.Write($"[E]");
                    }
                }

                //이름 칸맞추기
                if(item.Name.Length > 6)
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

                //판매 가격은 구매가격의 85%
                float sellPrice = ((float)item.Price / 100) * 85;

                Console.Write($"| {(int)sellPrice}\t");
                Console.WriteLine($"| {item.Description}\t");

                MenuNumber++;
            }
        }
        private void SellItem()
        {
            while(true)
            {
                List<Item> InvenItemList = _player.InvenItemList;

                Console.Clear();

                Console.WriteLine("[ 상점 - 아이템 판매]");
                Console.WriteLine($"현재 보유 금화 : {_player.Gold}");

                ShowSellMenu();

                Console.WriteLine(" 0. 나가기 : ");

                if (int.TryParse(Console.ReadLine(), out int iSelect) == false)
                {
                    continue;
                }

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

                ///////////선택한 아이템 판매//////////

                //장착중인지 검사
                //웨폰인지 아머인지
                ItemSlotType Type = ((Equip_Item)InvenItemList[iSelect - 1]).SlotType;

                if (((Equip_Item)InvenItemList[iSelect - 1]).IsEquip == true) //장착중이면
                {
                    //장착슬롯에서 빼주고
                    _player.equip_Item[(int)Type].IsEquip = false;
                    ((Equip_Item)InvenItemList[iSelect - 1]).IsEquip = false;
                }

                //리스트에서 해당 아이템 빼기
                InvenItemList.RemoveAt(iSelect - 1);

                //판매 가격은 구매가격의 85%
                float sellPrice = ((float)SelectItem.Price / 100) * 85;
                _player.Gold += (int)sellPrice;
            }
        }
    }
}
