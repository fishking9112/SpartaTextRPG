using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    internal class StateView : IScene
    {
        public StateView()
        {
            this._player = MainGame.Instance.player;
        }

        private ICharacter _player;
        public void SceneMenuDraw()
        {
            //장착된 아이템
            Equip_Item equip_Weapon;
            Equip_Item equip_Armor;

            equip_Weapon = ((Player)_player).equip_Item[(int)ItemSlotType.ITEMTYPE_WEAPON];
            equip_Armor = ((Player)_player).equip_Item[(int)ItemSlotType.ITEMTYPE_ARMOR];

            Console.Clear();
            Console.WriteLine("[ 상태보기 ]");
            Console.WriteLine(" 이름 : {0}", _player.Name);
            Console.WriteLine(" Lv : {0}" , _player.Level);
            Console.WriteLine(" HP : {0} / {1}", _player.HP , _player.MaxHP);

            //공격력
            if (equip_Weapon != null)
            {
                if (equip_Weapon.IsEquip == true) // 무기가 장착되어 있으면
                {
                    int bonusAtt = equip_Weapon.Bonus;
                    Console.WriteLine(" Att : {0} + ({2}) ~ {1} + ({2})", _player.AttackPower_Min, _player.AttackPower_Max, bonusAtt);
                }
                else
                {
                    Console.WriteLine(" Att : {0} ~ {1}", _player.AttackPower_Min, _player.AttackPower_Max);
                }
            }
            else
            {
                Console.WriteLine(" Att : {0} ~ {1}", _player.AttackPower_Min, _player.AttackPower_Max);
            }
            if (equip_Armor != null)
            {
                if (equip_Armor.IsEquip == true) // 방어구가 장착되어 있으면
                {
                    int bonusDef = equip_Armor.Bonus;   //방어력
                    Console.WriteLine(" Def : {0} + ({1})", _player.Defense, bonusDef);
                }
                else
                {
                    Console.WriteLine(" Def : {0}", _player.Defense);
                }
            }
            else // 장착된 갑옷이 없으면
            {
                Console.WriteLine(" Def : {0}", _player.Defense);
            }

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
