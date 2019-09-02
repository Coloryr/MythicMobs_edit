namespace MythicMobs_edit.Obj_save.Mob.Effects_type
{
    public class ParticleLine :Particles
    {
        /// <summary>
        /// 相聚距离
        /// </summary>
        public double distanceBetween { get; set; } = 0.25d;
        /// <summary>
        /// Y轴开始偏移
        /// </summary>
        public int yStartOffset { get; set; } = 0;
    }
}
