using System;

namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    public class BABY_ZOMBIE_VILLAGER
    {
        /// <summary>
        /// 职业
        /// </summary>
        public string Profession { get; set; }
        /// <summary>
        /// 生成僵尸几率为它们加强伤害
        /// </summary>
        public double ReinforcementsChance { get; set; } = 0;

        public string get_type_r()
        {
            List List = new List();
            Random b = new Random();
            return List.VillagerType[b.Next(List.VillagerType.Count)];
        }
    }
}
