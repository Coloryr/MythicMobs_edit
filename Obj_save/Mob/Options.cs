﻿namespace MythicMobs_edit.Obj_save.Mob
{
    class Options
    {
        public Options(Type type)
        {
            Type = Obj_get.Mob_Type_get(type);
        }
        /// <summary>
        /// 总是显示名称
        /// </summary>
        public bool AlwaysShowName { get; set; } = false;
        /// <summary>
        /// 攻击速度
        /// </summary>
        public int AttackSpeed { get; set; }
        /// <summary>
        /// 是否可碰撞
        /// </summary>
        public bool Collidable { get; set; } = true;
        /// <summary>
        /// 没有玩家时会不会被删除
        /// </summary>
        public bool Despawn { get; set; } = true;
        /// <summary>
        /// 生物跟随目标的最大距离
        /// </summary>
        public int FollowRange { get; set; }
        /// <summary>
        /// 生物是否发光
        /// </summary>
        public bool Glowing { get; set; } = false;
        /// <summary>
        /// 是否对所有伤害无敌
        /// </summary>
        public bool Invincible { get; set; } = false;
        /// <summary>
        /// 抗击退
        /// </summary>
        public int KnockbackResistance { get; set; } = 0;
        /// <summary>
        /// 在多远以外不能被玩家伤害
        /// </summary>
        public int MaxCombatDistance { get; set; }
        /// <summary>
        /// 移动速度
        /// </summary>
        public float MovementSpeed { get; set; } = 0.2f;
        /// <summary>
        /// 生物有没有AI
        /// </summary>
        public bool NoAI { get; set; } = false;
        /// <summary>
        /// 生物遭到伤害以后的无敌时间
        /// </summary>
        public int NoDamageTicks { get; set; } = 10;
        /// <summary>
        /// 生物是否有重力
        /// </summary>
        public bool NoGravity { get; set; } = false;
        /// <summary>
        /// 让生物在 “mm m kilall” 命令下无敌
        /// </summary>
        public bool Persistent { get; set; } = false;
        /// <summary>
        /// 防止生物捡起物品
        /// </summary>
        public bool PreventItemPickup { get; set; } = true;
        /// <summary>
        /// 防止被栓绳拉住
        /// </summary>
        public bool PreventLeashing { get; set; } = true;
        /// <summary>
        /// 防止被 MythicMob 击杀后掉落物品
        /// </summary>
        public bool PreventMobKillDrops { get; set; } = false;
        /// <summary>
        /// MythicMobs 是否应该阻止原版掉落
        /// </summary>
        public bool PreventOtherDrops { get; set; } = false;
        /// <summary>
        /// 是否阻止生物出生时有随机装备
        /// </summary>
        public bool PreventRandomEquipment { get; set; } = false;
        /// <summary>
        /// 阻止使用命名牌重命名生物
        /// </summary>
        public bool PreventRenaming { get; set; } = true;
        /// <summary>
        /// 如果生物的血量恢复到技能设置的血量阈值以上，是否可以重新使用此技能
        /// </summary>
        public bool RepeatAllSkills { get; set; } = false;
        /// <summary>
        /// 显示生命信息
        /// </summary>
        public bool ShowHealth { get; set; } = false;
        /// <summary>
        /// 阻止生物发出原版音效
        /// </summary>
        public bool Silent { get; set; }
        /// <summary>
        /// 阻止生物发出原版音效
        /// </summary>
        public object Type { get; set; }
    }
}
