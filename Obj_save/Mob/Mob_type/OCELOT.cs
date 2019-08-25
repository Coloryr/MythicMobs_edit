using System;

namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    class OCELOT
    {
        public string type { get; set; }
        public class Type
        {
            public string BLACK_CAT { get { return "BLACK_CAT"; } }
            public string RED_CAT { get { return "RED_CAT"; } }
            public string SIAMESE_CAT { get { return "SIAMESE_CAT"; } }
            public string WILD_OCELOT { get { return "WILD_OCELOT"; } }
        }

        public string get_type_r()
        {
            Type Type = new Type();
            string[] a = { Type.BLACK_CAT, Type.RED_CAT, Type.SIAMESE_CAT, Type.WILD_OCELOT };
            Random b = new Random();
            return a[b.Next(a.Length)];
        }
    }
}
