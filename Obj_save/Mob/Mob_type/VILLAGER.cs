using System;

namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    public class VILLAGER
    {
        /// <summary>
        /// 职业类型
        /// </summary>
        public string VillagerType { get; set; }

        public string get_type_r()
        {
            List List = new List();
            Random b = new Random();
            return List.VillagerType[b.Next(List.VillagerType.Count)];
        }
    }
}
