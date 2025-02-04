using SpartaTextRPG.Character;
using SpartaTextRPG.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG.Scene
{
    internal class Town : IScene
    {
        public Town() { }
        public Town(ICharacter player) { this._player = player; }

        private ICharacter _player;
        public  void SceneMenuDraw()
        {
            Console.WriteLine("Town Scene");
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine(" 선택 : ");

            int iSelect = int.Parse( Console.ReadLine() ) - 1;

            SceneManager.Instance.MoveScene((SceneManager.EnumScene)iSelect);
        }
    }
}
