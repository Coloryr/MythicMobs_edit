using System;
using System.Collections.Generic;

namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    class VILLAGER
    {
        public string VillagerType { get; set; }

        public string get_type_r()
        {
            List List = new List();
            Random b = new Random();
            return List.VillagerType[b.Next(List.VillagerType.Count)];
        }
    }
}
