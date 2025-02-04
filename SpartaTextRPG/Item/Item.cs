using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG.Item
{
    internal class Item
    {
        string Name { get; set; }
        string Description { get; }

        public Item(string _Name , string _Des)
        {
            Name = _Name; 
            Description = _Des;
        }
    }
}

/*
 소비 아이템이 없네 .. ?

일단 확장성 생각해서 만듦
아이템을 장착 / 소비 나누자
 */