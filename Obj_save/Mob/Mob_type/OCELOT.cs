using System;

namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    public class OCELOT
    {
        /// <summary>
        /// 豹猫种类
        /// </summary>
        public string type { get; set; }

        public string get_type_r()
        {
            List List = new List();
            Random b = new Random();
            return List.OcelotType[b.Next(List.OcelotType.Count)];
        }
    }
}
