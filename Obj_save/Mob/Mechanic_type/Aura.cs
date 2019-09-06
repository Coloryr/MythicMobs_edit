using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythicMobs_edit.Obj_save.Mob.Mechanic_type
{
    public class Aura
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string auraName { get; set; }
        /// <summary>
        /// 开始于
        /// </summary>
        public string onStart { get; set; }
        /// <summary>
        /// tick开始于
        /// </summary>
        public string onTick { get; set; }
        /// <summary>
        /// 结束于
        /// </summary>
        public string onEnd { get; set; }
        /// <summary>
        /// 几率
        /// </summary>
        public int Charges { get; set; } = 0;
        /// <summary>
        /// 持续时间
        /// </summary>
        public int Duration { get; set; } = 200;
        /// <summary>
        /// 间隔
        /// </summary>
        public int Interval { get; set; } = 1;
        /// <summary>
        /// 最大堆叠
        /// </summary>
        public int maxStacks { get; set; }
        /// <summary>
        /// 刷新持续时间
        /// </summary>
        public bool refreshDuration { get; set; }
        /// <summary>
        /// 合并所有
        /// </summary>
        public bool mergeAll { get; set; }
        /// <summary>
        /// 在获得伤害后取消
        /// </summary>
        public bool CancelOnGiveDamage { get; set; }
        /// <summary>
        /// 在取得伤害后取消
        /// </summary>
        public bool CancelOnTakeDamage { get; set; }
        /// <summary>
        /// 在死亡后取消
        /// </summary>
        public bool CancelOnDeath { get; set; } = true;
        /// <summary>
        /// 在传送后取消
        /// </summary>
        public bool CancelOnTeleport { get; set; }
        /// <summary>
        /// 在更改世界后取消
        /// </summary>
        public bool CancelOnChangeWorld { get; set; }
        /// <summary>
        /// 在使用技能后取消
        /// </summary>
        public bool CancelOnSkillUse { get; set; }
        /// <summary>
        /// 在退出后取消
        /// </summary>
        public bool CancelOnQuit { get; set; } = true;
    }
}
