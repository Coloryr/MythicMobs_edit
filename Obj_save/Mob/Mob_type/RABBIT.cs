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
        public bool Baby { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public double Age { get; set; }
        /// <summary>
        /// 是否锁住生物的年龄
        /// </summary>
        public bool AgeLock { get; set; }

        public string get_type_r()
        {
            List List = new List();
            Random b = new Random();
            return List.RabbitType[b.Next(List.RabbitType.Count)];
        }
    }
}
