using System;

namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    class ZOMBIE_VILLAGER
    {
        /// <summary>
        /// 职业
        /// </summary>
        public string Profession { get; set; }
        public class Type
        {
            public string BLACKSMITH { get { return "BLACKSMITH"; } }
            public string BUTCHER { get { return "BUTCHER"; } }
            public string FARMER { get { return "FARMER"; } }
            public string LIBRARIAN { get { return "LIBRARIAN"; } }
            public string PRIEST { get { return "PRIEST"; } }
        }
        public string get_type_r()
        {
            Type Type = new Type();
            string[] a = { Type.BLACKSMITH, Type .BUTCHER, Type .FARMER, Type .LIBRARIAN,
            Type.PRIEST};
            Random b = new Random();
            return a[b.Next(a.Length)];
        }
    }
}
