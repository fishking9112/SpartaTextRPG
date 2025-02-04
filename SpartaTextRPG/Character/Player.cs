using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    internal class Player : ICharacter
    {
        //생성자에서 초기화
        public Player() { }
        public Player(string _Name , int _Level , int _MaxHP , int _AttMin , int _AttMax , int _Def , int _Gold) 
        {
            Name = _Name; 
            Level = _Level; 
            HP = _MaxHP;
            MaxHP = _MaxHP;
            AttackPower_Min = _AttMin;
            AttackPower_Max = _AttMax;
            Defense = _Def;
            Gold = _Gold;
        }
        public string Name { get; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Attack => new Random().Next(AttackPower_Min, AttackPower_Max);
        public int AttackPower_Min { get; }
        public int AttackPower_Max { get; }
        public int Defense { get; set; }
        public bool IsDead => HP <= 0;
        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
            else Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {HP}");
        }

        ///////// Player
        /// <summary>
        /// 
        /// </summary>

        public int Gold { get; set; }

        //인벤토리
        public List<Item> InvenItemList = new List<Item>();
    }
}
