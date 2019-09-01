using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythicMobs_edit.Obj_save.Mob.Effects_type
{
    public class BlockMask
    {
        /// <summary>
        /// 方块名字
        /// </summary>
        public string material { get; set; } = "gravel";
        /// <summary>
        /// 方块数据
        /// </summary>
        public int data { get; set; } = 0;
        /// <summary>
        /// 半径
        /// </summary>
        public int radius { get; set; } = 10;
        /// <summary>
        /// 持续时间
        /// </summary>
        public int noise { get; set; } = 0;
        /// <summary>
        /// 持续时间
        /// </summary>
        public int duration { get; set; } = 10;
        /// <summary>
        /// 形状
        /// </summary>
        public string shape { get; set; } = "sphere";
        /// <summary>
        /// 只有非空气方块掩护
        /// </summary>
        public bool noair { get; set; } = true;
        /// <summary>
        /// 只有空气方块掩护
        /// </summary>
        public bool onlyair { get; set; } = false;
    }
}
