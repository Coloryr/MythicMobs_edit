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
        public string BlockMask_Attributes_material { get; set; } = "gravel";
        /// <summary>
        /// 方块数据
        /// </summary>
        public int BlockMask_Attributes_data { get; set; } = 0;
        /// <summary>
        /// 半径
        /// </summary>
        public int BlockMask_Attributes_radius { get; set; } = 0;
        /// <summary>
        /// 非空气
        /// </summary>
        public bool BlockMask_Attributes_noair { get; set; } = true;
        /// <summary>
        /// 持续时间
        /// </summary>
        public int BlockMask_Attributes_duration { get; set; } = 0;
        /// <summary>
        /// 形状
        /// </summary>
        public string BlockMask_Attributes_shape { get; set; } = "sphere";
        /// <summary>
        /// 只有非空气方块掩护
        /// </summary>
        public bool BlockMask_Attributes_noair_ { get; set; } = true;
        /// <summary>
        /// 只有空气方块掩护
        /// </summary>
        public bool BlockMask_Attributes_onlyair { get; set; } = false;
    }
}
