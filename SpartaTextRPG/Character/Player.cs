using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

//using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpartaTextRPG
{
    internal class Player : ICharacter
    {
        public Player() { }
        public Player(string _Name, int _Level, int _MaxHP, float _AttMin, float _AttMax, int _Def, int _Gold)
        {
            Name = _Name;
            Level = _Level;
            HP = _MaxHP;
            MaxHP = _MaxHP;
            AttackPower_Min = _AttMin;
            AttackPower_Max = _AttMax;
            Defense = _Def;
            Gold = _Gold;

            //장착 아이템 초기화
            //equip_Item[(int)ItemSlotType.ITEMTYPE_WEAPON] = null;
            //equip_Item[(int)ItemSlotType.ITEMTYPE_ARMOR] = null;
        }

        //Player 멤버변수
        public int Gold { get; set; }
        //인벤토리
        public List<Item> InvenItemList = new List<Item>();
        //장착
        public Equip_Item[] equip_Item = new Equip_Item[(int)ItemSlotType.ITEMTYPE_MAX];

        //프로퍼티
        public string Name { get; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public float AttackPower_Min { get; set; }
        public float AttackPower_Max { get; set; }
        public int Defense { get; set; }
        public bool IsDead => HP <= 0;

        //밥먹고 레벨업 만들기
        //경험치 / max경험치 만들고
        // 던전 클리어시 경험치 올려주고
        // 맥스 닿으면 레벨업 , 경험치 0 ,맥스 올려주기
        // 레벨 따라 공 , 방 증가
        // 공격력 0.5 오르므로 , 실수형으로 변경

        public int Exp { get; set; } = 0;
        public int MaxExp { get; set; } = 1;

        ///////// Player
        public int FinalDef()
        {
            int equip_Def = 0;

            if (equip_Item[(int)ItemSlotType.ITEMTYPE_ARMOR] != null)
            {
                equip_Def = equip_Item[(int)ItemSlotType.ITEMTYPE_ARMOR].Bonus;
            }

            int _finalDef = Defense + equip_Def;

            return _finalDef;
        }
        public float FinalAtt()
        {
            int equip_Att = 0;

            if (equip_Item[(int)ItemSlotType.ITEMTYPE_WEAPON] != null)
            {
                equip_Att = equip_Item[(int)ItemSlotType.ITEMTYPE_WEAPON].Bonus;
            }

            float _finalAtt = ((AttackPower_Min + AttackPower_Max) / 2)  + equip_Att;

            return _finalAtt;
        }
        public void ExpUp(int _Exp)
        {
            Exp += _Exp;

            if(Exp >= MaxExp)
            {
                Exp -= MaxExp;
                Level += 1;
                MaxExp = Level;

                //레벨업 시 공 , 방 올라가기
                AttackPower_Min += 0.5f;
                AttackPower_Max += 0.5f;
                Defense += 1;
            }
        }
        public void SaveDate()
        {
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream fs = new FileStream("../SaveData.txt",FileMode.Create);

            SaveData data = new SaveData();

            data.Name = this.Name;
            data.Level = this.Level;
            data.HP = this.HP;
            data.MaxHP = this.MaxHP;
            data.AttMin = this.AttackPower_Min;
            data.AttMax = this.AttackPower_Max;
            data.Def = this.Defense;
            data.Gold = this.Gold;
            data.Exp = this.Exp;
            data.ExpMax = this.MaxExp;

            //인벤토리 저장
            data.InvenItemList = this.InvenItemList;

            //장착 아이템 저장

            data.equip_Item[(int)ItemSlotType.ITEMTYPE_WEAPON] = this.equip_Item[(int)ItemSlotType.ITEMTYPE_WEAPON];
            data.equip_Item[(int)ItemSlotType.ITEMTYPE_ARMOR] = this.equip_Item[(int)ItemSlotType.ITEMTYPE_ARMOR];

            //bf.Serialize(fs, data);
            //fs.Close();

            // 저장기능 만들다가 실패 ㅠ
            // 시리얼라이즈 해서 바이너리 파일로 만들어보려 했으나 ,
            // 방법을 서칭해도 잘 나오지 않아 실패 ...
            // 제이슨 포멧을 만드는법을 공부하다 시간부족으로 제출합니당 ㅠ


            //브랜치 테스트 - 성공
            //Json 을 이용해서 저장 해보자.

            //경로 - 실행파일과 같은 경로
            string FilePath = "./PlayerData.json";
            
            try
            {
                // 직렬화 시키고
                string serializeJson = JsonConvert.SerializeObject(this);
                //Data 클래스를 따로 만들지 말고 자기 자신을 바로 저장해보자

                //테스트를 위한 출력
                //Console.WriteLine(serializeJson);

                //파일로 만들자
                File.WriteAllText(FilePath, serializeJson);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Save 실패 !! : {ex}");
            }
        }
       
    }
}
