using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    enum DUNGEON_LEVEL { EASY , NOMAL , HARD , END}
    internal class Dungeon : IScene
    {
        public Dungeon()
        {
            this._player = MainGame.Instance.player;
            DungeonInit();
        }

        //필드
        private Player _player;
        private int[] needDef = new int[(int)DUNGEON_LEVEL.END];
        private int[] dungeonReward = new int[(int)DUNGEON_LEVEL.END];
        private void DungeonInit()
        {
            //권장 방어력 셋팅
            needDef[(int)DUNGEON_LEVEL.EASY] = 5;
            needDef[(int)DUNGEON_LEVEL.NOMAL] = 11;
            needDef[(int)DUNGEON_LEVEL.HARD] = 17;

            //던전 보상 셋팅
            dungeonReward[(int)DUNGEON_LEVEL.EASY] = 1000;
            dungeonReward[(int)DUNGEON_LEVEL.NOMAL] = 1700;
            dungeonReward[(int)DUNGEON_LEVEL.HARD] = 2500;
        }
        public void SceneMenuDraw()
        {
            Console.Clear();
            Console.WriteLine("   [ 던전입장 ]");
            Console.WriteLine("1. [  쉬   움 ]");
            Console.WriteLine("2. [  일   반 ]");
            Console.WriteLine("3. [  어려움  ]");
            Console.WriteLine("0. [ 돌아가기 ]");
            Console.WriteLine(" 선택 : ");

            if (int.TryParse(Console.ReadLine(), out int iSelect) == false)
            {
                SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_DUNGEON);
            }

            if (iSelect == 0)   // 나가기
            {
                SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_TOWN);
            }

            bool isClear = EnterDungeon((DUNGEON_LEVEL)iSelect - 1);

            if(isClear)
            {
                // 클리어
                SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_DUNGEON);

            }
            else
            {
                Console.WriteLine("[ 던전 공략 실패 ! ]");
                Console.WriteLine("강해져서 돌아오세요 ㅠㅠ");
                Thread.Sleep(2000);
                // 실패
                SceneManager.Instance.MoveScene(SceneManager.EnumScene.SCENE_TOWN);
            }

            
            //던전에서 해야할것
            //난이도 분기
            //입장 함수에 매개변수로 난이도 넣어주기 ?
            //입장 함수 내에서 클리어 여부 연산 후 반환
            //난이도별로 보상
        }
        private bool EnterDungeon(DUNGEON_LEVEL _dungeon_Level)
        {
            //권장 방어력에 따른 클리어 유무 결정
            if (needDef[(int)_dungeon_Level] > _player.FinalDef())
            {
                // 보상 없고 체력 감소 절반
                int random = new Random().Next(0,10);

                if(random < 4) // 40프로 확률로 실패
                {
                    _player.HP = _player.HP / 2; 

                    if(_player.HP <= 0)
                    {
                        // 캐릭터 사망
                        return false;
                    }
                }

                //던전 클리어 실패
                return false;
            }
            else // 방어력이 더 높다면
            {
                //던전 클리어

                //기본 체력 감소량
                int DefValue = needDef[(int)_dungeon_Level] - _player.FinalDef();
                int HpMinus = new Random().Next(20 + DefValue, 36 + DefValue);
                _player.HP -= HpMinus;
                
                if (_player.HP <= 0)
                {
                    // 캐릭터 사망
                    return false;
                }

                GetReward(_dungeon_Level);

                //던전 클리어 성공
                return true;
            }
        }

        private void GetReward(DUNGEON_LEVEL _dungeon_Level)
        {
            //던전 보상
            //공격력에 의한 추가보상
            int AttValue = new Random().Next( (int)_player.FinalAtt() , (int)_player.FinalAtt() * 2);
            int RewardBonus = ( dungeonReward[(int)_dungeon_Level] / 100 ) * AttValue;
            int finalReward = dungeonReward[(int)_dungeon_Level] + RewardBonus;

            _player.Gold += finalReward;

            //경험치 ( 던전 난이도 따라 경험치 다르게 만들자)
            _player.ExpUp((int)_dungeon_Level + 1);

            Console.WriteLine("[ 던전 클리어 ! ]");
            Console.WriteLine($"클리어 보상 : {dungeonReward[(int)_dungeon_Level]} G + {RewardBonus} G ");
            Console.WriteLine($"현재 보유 골드 : {_player.Gold} G");
            Thread.Sleep(2000);
        }
    }
}
