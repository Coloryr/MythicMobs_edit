namespace MythicMobs_edit.Obj_save.Mob.Mechanic_type
{
    public class Consume
    {
        /// <summary>
        /// 伤害
        /// </summary>
        public int damage { get; set; }
        /// <summary>
        /// 治疗
        /// </summary>
        public int heal { get; set; }
        /// <summary>
        /// 抵抗击退
        /// </summary>
        public bool preventknockback { get; set; } = false;
        /// <summary>
        /// 忽略保护
        /// </summary>
        public bool preventimmunity { get; set; } = false;
        /// <summary>
        /// 忽略目标装甲
        /// </summary>
        public bool ignorearmor { get; set; } = false;
    }
}
