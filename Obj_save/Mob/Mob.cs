using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythicMobs_edit.Obj_save.Mob
{
    class Mob
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public Type Type { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string Display { get; set; }
        /// <summary>
        /// 血量
        /// </summary>
        public int Health { get; set; }
        /// <summary>
        /// 攻击力
        /// </summary>
        public int Damage { get; set; }
        /// <summary>
        /// 护甲
        /// </summary>
        public int Armor { get; set; }
        /// <summary>
        /// BOSS血条
        /// </summary>
        public BossBar BossBar { get; set; }
        /// <summary>
        /// 派系名称
        /// </summary>
        public BossBar Faction { get; set; }
    }
}
