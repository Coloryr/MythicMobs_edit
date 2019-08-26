namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    public class PRIMED_TNT
    {
        /// <summary>
        /// 爆炸时间
        /// </summary>
        public int FuseTicks { get; set; } = -1;
        /// <summary>
        /// 爆炸强度
        /// </summary>
        public int ExplosionYield { get; set; } = -1;
        /// <summary>
        /// 是否产生火焰
        /// </summary>
        public bool Incendiary { get; set; } = false;
    }
}
