using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    internal class INN :IScene
    {
        public INN()
        {
            this._player = MainGame.Instance.player;
            price = 500;
        }
        private ICharacter _player;

        private int price;

        public void SceneMenuDraw()
        {
            Console.Clear();
            Console.WriteLine("[ 여관 ]");
            Console.WriteLine($"{price} G 를 내면 체력을 회복할 수 있습니다. \t ( 보유 골드 : {((Player)_player).Gold} G ) \n");
            Console.WriteLine(" 1. 휴식하기 ");
            Console.WriteLine(" 0. 돌아가기 ");

            int iSelect = int.Parse(Console.ReadLine());

            switch (iSelect)
            {
                case 0://나가기
                    SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_TOWN);
                    break;
                case 1://아이템 구매
                    UseINN();
                    break;
                default://다시 상점 띄워주기
                    SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_INN);
                    break;
            }

        }
        private void UseINN()
        {
            Console.Clear();
            Console.WriteLine("[ 여관 - 잠자는중 ]");
            Console.WriteLine($" 체력을 회복하는중 . ");
            Thread.Sleep( 1000 );
            Console.Clear();
            Console.WriteLine("[ 여관 - 잠자는중 ]");
            Console.WriteLine($" 체력을 회복하는중 .. ");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("[ 여관 - 잠자는중 ]");
            Console.WriteLine($" 체력을 회복하는중 ... ");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("[ 여관 - 잠자는중 ]");
            Console.WriteLine($" 체력을 회복하는중 . ");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("[ 여관 - 잠자는중 ]");
            Console.WriteLine($" 체력을 회복하는중 .. ");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("[ 여관 - 잠자는중 ]");
            Console.WriteLine($" 체력을 회복하는중 ... ");
            Thread.Sleep(1000);


            _player.HP = _player.MaxHP;

            Console.Clear();
            Console.WriteLine("[ 여관 ]");
            Console.WriteLine($" 체력이 전부 회복되었습니다 !");
            Thread.Sleep(1000);
            SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_TOWN);
        }
    }
}
