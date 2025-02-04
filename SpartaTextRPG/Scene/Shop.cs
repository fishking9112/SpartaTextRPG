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
        public void ShopInit()
        {
            // 아이템 셋팅
            // 이거
            Console.WriteLine("[ ShopInit ]");
        }
        public void SceneMenuDraw()
        {
            Console.WriteLine("[ 상점 ]");
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine(" 선택 : ");
        }
    }
}
