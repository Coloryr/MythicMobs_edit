namespace MythicMobs_edit.Obj_save.Mob.Mechanic_type
{
    public class ShootFireball
    {
        /// <summary>
        /// 能量
        /// </summary>
        public int yield { get; set; } = 1;
        /// <summary>
        /// 速度
        /// </summary>
        public int velocity { get; set; } = 1;
        /// <summary>
        /// 火球后面产生火焰
        /// </summary>
        public bool incendiary { get; set; } = false;
        /// <summary>
        /// 后面火焰燃烧tick
        /// </summary>
        public int fireTicks { get; set; } = 1;
        /// <summary>
        /// 小型火球
        /// </summary>
        public bool smallfireball { get; set; } = false;
        /// <summary>
        /// 播放音效
        /// </summary>
        public bool playsound { get; set; } = false;
    }
}
