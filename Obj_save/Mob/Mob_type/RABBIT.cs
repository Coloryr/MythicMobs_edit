using System;
using System.Collections.Generic;

namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    public class RABBIT
    {
        /// <summary>
        /// 兔子种类
        /// </summary>
        public string RabbitType { get; set; }
        /// <summary>
        /// 是否为小兔子
        /// </summary>
        public bool Baby { get; set; } = false;

        public string get_type_r()
        {
            List List = new List();
            Random b = new Random();
            return List.RabbitType[b.Next(List.RabbitType.Count)];
        }
    }
}
