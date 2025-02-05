using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    internal class SceneManager
    {
        private static SceneManager? m_instance = null;

        public static SceneManager Instance
        {
            get
            {
                if(m_instance == null)
                {
                    m_instance = new SceneManager();
                }
                return m_instance;
            }
        }


        // Scene 을 위한 Enum
        public enum EnumScene { SCENE_TOWN , SCENE_STATEVIEW, SCENE_SHOWINVEN, SCENE_SHOP, SCENE_INN, SCENE_DUNGEON , SCENE_MAX}

        EnumScene curScene = EnumScene.SCENE_TOWN;
        EnumScene PreScene = EnumScene.SCENE_MAX;

        private List<IScene> SceneList = new List<IScene>();

        //Player 갖고있기
        Player? player;

        public void InitScene(Player player)
        {
            this.player = player;

            SceneList.Add( new Town() );
            SceneList.Add( new StateView());
            SceneList.Add( new ShowInven());
            SceneList.Add( new Shop() );
            SceneList.Add(new INN());
            SceneList.Add( new Dungeon() );
        }

        public void MoveScene(EnumScene _Scene)
        {
            //이전 씬 저장
            PreScene = curScene;

            curScene = _Scene;

            SceneList[(int)curScene].SceneMenuDraw();
        }
    }
}
