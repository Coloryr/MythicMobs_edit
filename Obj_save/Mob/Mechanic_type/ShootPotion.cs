namespace MythicMobs_edit.Obj_save.Mob.Mechanic_type
{
    public class ShootPotion
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string type { get; set; } = "None";
        /// <summary>
        /// 持续时间
        /// </summary>
        public int duration { get; set; } = 100;
        /// <summary>
        /// 等级
        /// </summary>
        public int level { get; set; } = 1;
        /// <summary>
        /// 速度
        /// </summary>
        public int velocity { get; set; } = 1;
        /// <summary>
        /// 有粒子
        /// </summary>
        public bool hasParticles { get; set; } = true;
        /// <summary>
        /// 有粒子图标
        /// </summary>
        public bool hasIcon { get; set; } = true;
    }
}
