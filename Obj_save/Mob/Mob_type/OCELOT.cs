using System;

namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    public class OCELOT
    {
        /// <summary>
        /// 豹猫种类
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public double Age { get; set; } = 1;
        /// <summary>
        /// 是否锁住生物的年龄
        /// </summary>
        public bool AgeLock { get; set; } = false;
        /// <summary>
        /// 是否能被玩家驯服
        /// </summary>
        public bool Tameable { get; set; } = false;

        public string get_type_r()
        {
            List List = new List();
            Random b = new Random();
            return List.OcelotType[b.Next(List.OcelotType.Count)];
        }
    }
}
