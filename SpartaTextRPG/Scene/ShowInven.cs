using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    internal class ShowInven : IScene
    {
        public ShowInven() { }
        public ShowInven(ICharacter player) { this._player = player; }

        private ICharacter _player;

        public void SceneMenuDraw()
        {
            Console.Clear();
            Console.WriteLine("[ 아이템 목록 ]");
            Console.WriteLine(" \n 1. 장착 관리 ");
            Console.WriteLine(" \n 0. 돌아가기 : ");
        }
    }
}
