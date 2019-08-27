namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    public class CREEPER
    {
        /// <summary>
        /// 设置爬行者爆炸半径
        /// </summary>
        public int ExplosionRadius { get; set; }
        /// <summary>
        /// 引爆需要的时间
        /// </summary>
        public int FuseTicks { get; set; }
        /// <summary>
        /// 是否充能
        /// </summary>
        public bool SuperCharged { get; set; }
        /// <summary>
        /// 阻止爬行者被自己的爆炸炸死
        /// </summary>
        public bool PreventSuicide { get; set; }
    }
}
