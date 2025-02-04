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

        private ICharacter _player;
        private List<Item> ShopItemList = new List<Item>();
        public void ShopInit()
        {
            // 아이템 셋팅
            // 이거
            Console.WriteLine("[ ShopInit ]");

            ShopItemList.Add(new Item("TestItem_1" , "Test_1" , ItemType.ItemType_Weapon , 5 , 100));
            ShopItemList.Add(new Item("TestItem_2", "Test_2", ItemType.ItemType_Weapon, 15 , 200));
            ShopItemList.Add(new Item("TestItem_3", "Test_3", ItemType.ItemType_Weapon, 35 , 300));
            ShopItemList.Add(new Item("TestItem_4", "Test_4", ItemType.ItemType_Armor, 5 , 100));
            ShopItemList.Add(new Item("TestItem_5", "Test_5", ItemType.ItemType_Armor, 15 , 300));

        }
        public void ShowShopMenu(bool isBuying)
        {
            int MenuNumber = 1;
            foreach (var item in ShopItemList)
            {
                // 구매중이면 목록 번호 넣기
                if (isBuying)
                    Console.Write($"- {MenuNumber} ");
                else
                    Console.Write($"- ");

              
                Console.Write($"{item.Name}\t");
                if (item.Type == ItemType.ItemType_Weapon)
                    Console.Write($"| 공격력");
                else
                    Console.Write($"| 방어력");
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
            Console.WriteLine($"현재 보유 금화 : {((Player)_player).Gold}");

            ShowShopMenu(false);

            Console.WriteLine(" 0. 나가기 : ");
            Console.WriteLine(" 1. 아이템 구매 : ");
            Console.WriteLine(" 선택 : ");

            int iSelect = int.Parse(Console.ReadLine());

            switch(iSelect)
            {
                case 0:
                    //나가기
                    SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_TOWN);
                    break;
                case 1:
                    //아이템 구매
                    BuyItem();
                    break;
                default:
                    //다시 상점 띄워주기
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
                Console.WriteLine($"현재 보유 금화 : {((Player)_player).Gold}");

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

                int iSelect = int.Parse(Console.ReadLine());

                if (iSelect == 0)   // 나가기
                    SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_TOWN);

                if(iSelect < 0 || iSelect > ShopItemList.Count)
                {
                    Console.WriteLine(" 잘못된 입력입니다. ");
                    Thread.Sleep(1000);
                    continue;
                }

                Item SelectItem = ShopItemList[iSelect - 1];

                //이미 구매한 아이템인지 체크
                int findIndex = ((Player)_player).InvenItemList.FindIndex(x => x.Name.Equals(SelectItem.Name));

                 
                if (findIndex < 0) // 보유중이 아님
                {

                    // 금화 체크
                    if( ((Player)_player).Gold >= SelectItem.Price)
                    {
                        ((Player)_player).Gold -= SelectItem.Price;
                        ((Player)_player).InvenItemList.Add(SelectItem);
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
    }
}
