namespace MythicMobs_edit.Obj_save.Mob.Mechanic_type
{
    public class Explosion
    {
        /// <summary>
        /// Y轴能量
        /// </summary>
        public double yield { get; set; } = 0.013d;
        /// <summary>
        /// 破坏方块
        /// </summary>
        public bool blockdamage { get; set; } = false;
        /// <summary>
        /// 火焰
        /// </summary>
        public bool fire { get; set; } = false;
    }
}
