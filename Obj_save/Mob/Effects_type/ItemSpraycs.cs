using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythicMobs_edit.Obj_save.Mob.Effects_type
{
    public class ItemSpraycs
    {
        /// <summary>
        /// 物品
        /// </summary>
        public string item { get; set; } = "iron_sword";
        // <summary>
        /// 数量
        /// </summary>
        public int amount { get; set; } = 10;
        // <summary>
        /// 持续时间
        /// </summary>
        public int duration { get; set; } = 20;
        // <summary>
        /// 半径
        /// </summary>
        public int radius { get; set; } = 0;
        // <summary>
        /// 速度
        /// </summary>
        public int velocity { get; set; } = 1;
        // <summary>
        /// Y轴速度
        /// </summary>
        public int yVelocity { get; set; } = 1;
        // <summary>
        /// Y轴偏移
        /// </summary>
        public int yOffset { get; set; } = 1;
        // <summary>
        /// 允许捡起
        /// </summary>
        public bool allowpickup { get; set; } = false;
    }
}
