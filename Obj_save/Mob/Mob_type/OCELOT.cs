using System;
using System.Collections.Generic;

namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    class OCELOT
    {
        public string type { get; set; }

        public List<string> Type = new List<string>
        {
            "BLACK_CAT","RED_CAT","SIAMESE_CAT","WILD_OCELOT"
        };

        public string get_type_r()
        {
            Random b = new Random();
            return Type[b.Next(Type.Count)];
        }
    }
}
