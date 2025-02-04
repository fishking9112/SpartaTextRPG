using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    internal class Dungeon : IScene
    {
        public Dungeon() { }
        public Dungeon(ICharacter player) { this._player = player; }

        private ICharacter _player;
        public void SceneMenuDraw()
        {
            throw new NotImplementedException();
        }
    }
}
