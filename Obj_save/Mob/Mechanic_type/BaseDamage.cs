namespace MythicMobs_edit.Obj_save.Mob.Mechanic_type
{
    public class BaseDamage
    {
        /// <summary>
        /// 数量
        /// </summary>
        public int multiplier { get; set; } = 1;
        /// <summary>
        /// 数量
        /// </summary>
        public bool ignoreArmor { get; set; } = false;
        /// <summary>
        /// 数量
        /// </summary>
        public bool preventknockback { get; set; } = false;
        /// <summary>
        /// 数量
        /// </summary>
        public bool preventimmunity { get; set; } = false;
    }
}
