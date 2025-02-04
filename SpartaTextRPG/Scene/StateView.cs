using SpartaTextRPG.Character;
using SpartaTextRPG.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG.Scene
{
    internal class StateView : IScene
    {
        public StateView() { }
        public StateView(ICharacter player) { this._player = player; }

        private ICharacter _player;
        public void SceneMenuDraw()
        {
            Console.Clear();
            Console.WriteLine("[ 상태보기 ]");
            Console.WriteLine(" 이름 : {0}", _player.Name);
            Console.WriteLine(" Lv : {0}" , _player.Level);
            Console.WriteLine(" HP : {0} / {1}", _player.HP , _player.MaxHP);
            Console.WriteLine(" Att : {0} ~ {1}", _player.AttackPower_Min , _player.AttackPower_Max);
            Console.WriteLine(" Def : {0}", _player.Defense);
            Console.WriteLine(" Gold : {0}", ((Player)_player).Gold);
            Console.WriteLine(" \n 0. 돌아가기 : ");

            int iSelect = int.Parse(Console.ReadLine());

            if( iSelect == 0)
                SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_TOWN);
            else
            {
                SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_STATEVIEW);
            }
        }
    }
}
