using System;
using System.Collections.Generic;

namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    class ZOMBIE_VILLAGER
    {
        /// <summary>
        /// 职业
        /// </summary>
        public string Profession { get; set; }

        public string get_type_r()
        {
            List List = new List();
            Random b = new Random();
            return List.VillagerType[b.Next(List.VillagerType.Count)];
        }
    }
}
