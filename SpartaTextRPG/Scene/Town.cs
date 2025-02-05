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

        private Player _player;
        public  void SceneMenuDraw()
        {
            Console.Clear();
            Console.WriteLine("1. [ 상태보기 ]");
            Console.WriteLine("2. [ 인벤토리 ]");
            Console.WriteLine("3. [  상  점  ]");
            Console.WriteLine("4. [  여  관  ]");
            Console.WriteLine("5. [ 던전입장 ]");
            Console.WriteLine("6. [  저  장  ]");
            Console.WriteLine("7. [  종  료  ]");
            Console.WriteLine(" 선택 : ");

            int iSelect = int.Parse( Console.ReadLine() );

            switch(iSelect)
            {
                case 6:     // 저장 하고 다시 TOWN 재입장
                    PlayerPrefs.getInt();
                    SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_TOWN);
                    break;
                case 7:     // 종료
                    return;

                default:
                    SceneManager.Instance.MoveScene((SceneManager.EnumScene)iSelect);
                    break;
            }
        }
    }
}
