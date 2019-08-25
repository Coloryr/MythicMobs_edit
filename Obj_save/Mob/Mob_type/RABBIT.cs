using System;

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
        public class Type
        {
            public string BLACK { get { return "BLACK"; } }
            public string BLACK_AND_WHITE { get { return "BLACK_AND_WHITE"; } }
            public string BROWN { get { return "BROWN"; } }
            public string GOLD { get { return "GOLD"; } }
            public string SALT_AND_PEPPER { get { return "SALT_AND_PEPPER"; } }
            public string THE_KILLER_BUNNY { get { return "THE_KILLER_BUNNY"; } }
            public string WHITE { get { return "WHITE"; } }
        }
        public string get_type_r()
        {
            Type Type = new Type();
            string[] a = { Type .BLACK, Type .BLACK_AND_WHITE, Type .BROWN, Type .GOLD,
            Type.SALT_AND_PEPPER,Type.THE_KILLER_BUNNY,Type.WHITE};
            Random b = new Random();
            return a[b.Next(a.Length)];
        }
    }
}
