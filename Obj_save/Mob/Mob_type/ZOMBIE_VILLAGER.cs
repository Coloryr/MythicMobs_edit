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

        public List<string> Type = new List<string>()
        {
            "BLACKSMITH","BUTCHER","FARMER", "LIBRARIAN","PRIEST"
        };
        public string get_type_r()
        {
            Random b = new Random();
            return Type[b.Next(Type.Count)];
        }
    }
}
