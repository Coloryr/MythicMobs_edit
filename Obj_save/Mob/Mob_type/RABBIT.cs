using System;
using System.Collections.Generic;

namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    class RABBIT
    {
        /// <summary>
        /// 兔子种类
        /// </summary>
        public string RabbitType { get; set; }
        /// <summary>
        /// 是否为小兔子
        /// </summary>
        public bool Baby { get; set; } = false;

        public List<string> Type = new List<string>()
        {
            "BLACK","BLACK_AND_WHITE","BROWN","GOLD", "SALT_AND_PEPPER","THE_KILLER_BUNNY","WHITE"
        };
        public string get_type_r()
        {
            Random b = new Random();
            return Type[b.Next(Type.Count)];
        }
    }
}
