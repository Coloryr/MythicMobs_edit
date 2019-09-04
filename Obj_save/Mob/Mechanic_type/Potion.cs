using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythicMobs_edit.Obj_save.Mob.Mechanic_type
{
    public class Potion
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int duration { get; set; } = 100;
        /// <summary>
        /// 类型
        /// </summary>
        public int level { get; set; } = 1;
        /// <summary>
        /// 类型
        /// </summary>
        public bool force { get; set; } = false;
        /// <summary>
        /// 类型
        /// </summary>
        public bool hasParticles { get; set; } = true;
        /// <summary>
        /// 类型
        /// </summary>
        public bool hasIcon { get; set; } = true;
    }
}
