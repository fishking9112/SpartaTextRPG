using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    internal class MainGame
    {
        //메인게임 싱글톤으로 만들어주기
        private static MainGame? m_instance = null;

        public Player? player;

        public static MainGame Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new MainGame();
                }
                return m_instance;
            }
        }


        /// <summary>
        /// 구현
        /// </summary>
        /// 
        public void GameStart()
        {
            //플레이어 초기값 설정
            //player = new Player( "HuckP" , 1 , 100 , 10 , 20 , 5 , 15500);

            //player = LoadData();
            player = SaveLoadManager.Instance.LoadFromJson<Player>();
            if (player == null)
                player = new Player("HuckP", 1, 100, 10, 20, 5, 15500);


            SceneManager.Instance.InitScene(player);
            SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_TOWN);
        }

        public Player LoadData()
        {
            //경로 - 실행파일과 같은 경로
            string FilePath = "./PlayerData.json";

            try
            {
                if (File.Exists(FilePath))
                {
                    //역직렬화
                    string DeserializeJson = File.ReadAllText(FilePath);
                    return JsonConvert.DeserializeObject<Player>(DeserializeJson);
                }
                else // 데이터가 없는 경우
                {
                    //기본 캐릭터 생성
                    return new Player("HuckP", 1, 100, 10, 20, 5, 15500);
                }
            }
            catch (Exception ex)    // 로드 실패시
            {
                Console.WriteLine($"Load 실패 !! : {ex}");

                //기본 캐릭터 생성
                return new Player("HuckP", 1, 100, 10, 20, 5, 15500);
            }
        }
    }
}
