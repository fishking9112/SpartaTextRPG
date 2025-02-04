using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    internal class Town : IScene
    {
        public Town()
        { 
            this._player = MainGame.Instance.player;
        }

        private ICharacter _player;
        public  void SceneMenuDraw()
        {
            Console.Clear();
            Console.WriteLine("Town Scene");
            Console.WriteLine("1. [ 상태보기 ]");
            Console.WriteLine("2. [ 인벤토리 ]");
            Console.WriteLine("3. [  상  점  ]");
            Console.WriteLine("4. [  여  관  ]");
            Console.WriteLine(" 선택 : ");

            int iSelect = int.Parse( Console.ReadLine() );

            SceneManager.Instance.MoveScene((SceneManager.EnumScene)iSelect);
        }
    }
}
