namespace MythicMobs_edit.Obj_save.Mob.Mechanic_type
{
    public class HealPercent
    {
        /// <summary>
        /// 概率
        /// </summary>
        public double multiplier { get; set; } = 0.1d;
        /// <summary>
        /// 超出治疗
        /// </summary>
        public bool overheal { get; set; } = false;
    }
}
