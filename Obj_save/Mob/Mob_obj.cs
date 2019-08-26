using System.Collections.Generic;
using System.ComponentModel;

namespace MythicMobs_edit.Obj_save.Mob
{
    public class Mob_obj
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string Display { get; set; } = "Mob";
        /// <summary>
        /// 血量
        /// </summary>
        public int Health { get; set; } = 20;
        /// <summary>
        /// 攻击力
        /// </summary>
        public int Damage { get; set; } = 5;
        /// <summary>
        /// 护甲
        /// </summary>
        public int Armor { get; set; } = 1;
        /// <summary>
        /// BOSS血条
        /// </summary>
        public BossBar BossBar { get; set; } = new BossBar();
        /// <summary>
        /// 派系名称
        /// </summary>
        public string Faction { get; set; }
        /// <summary>
        /// 坐骑
        /// </summary>
        public string Mount { get; set; }
        /// <summary>
        /// 选项
        /// </summary>
        public Options Options { get; set; } = new Options();
    }
}
