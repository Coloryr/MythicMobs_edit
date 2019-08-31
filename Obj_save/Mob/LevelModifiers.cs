using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythicMobs_edit.Obj_save.Mob
{
    public class LevelModifiers
    {
        /// <summary>
        /// 血量
        /// </summary>
        public int Health { get; set; }
        /// <summary>
        /// 基础伤害
        /// </summary>
        public int Damage { get; set; }
        /// <summary>
        /// 击倒距离
        /// </summary>
        public int KnockbackResistance { get; set; }
        /// <summary>
        /// 力量
        /// </summary>
        public int Power { get; set; }
        /// <summary>
        /// 装甲
        /// </summary>
        public int Armor { get; set; }
        /// <summary>
        /// 移动速度
        /// </summary>
        public double MovementSpeed { get; set; }
        /// <summary>
        /// 攻击速度
        /// </summary>
        public int AttackSpeed { get; set; }
    }
}
