namespace MythicMobs_edit.Obj_save.Mob.Effects_type
{
    public class ParticleTornado : Particles
    {
        /// <summary>
        /// 最大半径
        /// </summary>
        public int maxradius { get; set; } = 3;
        /// <summary>
        /// Y轴偏移
        /// </summary>
        public double yoffset { get; set; } = 0.8;
        /// <summary>
        /// 高度
        /// </summary>
        public int height { get; set; } = 4;
        /// <summary>
        /// 间歇
        /// </summary>
        public int interval { get; set; } = 4;
        /// <summary>
        /// 持续时间
        /// </summary>
        public int duration { get; set; } = 200;
        /// <summary>
        /// 旋转速度
        /// </summary>
        public double rotationspeed { get; set; } = 0.04;
        /// <summary>
        /// 层高度
        /// </summary>
        public int sliceheight { get; set; } = 64;
        /// <summary>
        /// 烟雾粒子
        /// </summary>
        public string cloudparticle { get; set; } = "largeexplode";
        /// <summary>
        /// 烟雾尺寸
        /// </summary>
        public int cloudsize { get; set; } = 5;
        /// <summary>
        /// 烟雾数量
        /// </summary>
        public int cloudamount { get; set; } = 1;
        /// <summary>
        /// 水平大小
        /// </summary>
        public int cloudhspread { get; set; } = 1;
        /// <summary>
        /// 垂直大小
        /// </summary>
        public double cloudvspread { get; set; } = 1.8;
        /// <summary>
        /// 烟雾速度
        /// </summary>
        public int cloudpspeed { get; set; } = 2;
        /// <summary>
        /// 烟雾Y轴偏移
        /// </summary>
        public double cloudyoffset { get; set; } = 1.8;
    }
}
