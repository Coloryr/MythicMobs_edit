using System.Collections.Generic;
using System.ComponentModel;

namespace MythicMobs_edit.Obj_save.Mob
{
    public class Mob
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; } = "newMob";
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

        public List<string> Type_list = new List<string>()
        {
            "ARMOR_STAND",
            "BABY_PIG_ZOMBIE",
            "BABY_PIG_ZOMBIE_VILLAGER",
            "BABY_ZOMBIE",
            "BABY_ZOMBIE_VILLAGER",
            "BAT",
            "BLAZE",
            "BOAT",
            "CAVE_SPIDER",
            "CHICKEN",
            "COW",
            "CREEPER",
            "ELDER_GUARDIAN",
            "ENDER_DRAGON",
            "ENDERMAN",
            "ENDERMITE",
            "EVOKER",
            "FALLING_BLOCKS",
            "GHAST",
            "GIANT",
            "GUARDIAN",
            "HORSE",
            "HUSK",
            "IRON_GOLEM",
            "LLAMA",
            "MAGMA_CUBE",
            "MUSHROOM_COW",
            "OCELOT",
            "PIG",
            "PIG_ZOMBIE",
            "PIG_ZOMBIE_VILLAGER",
            "PRIMED_TNT",
            "POLAR_BEAR",
            "RABBIT",
            "SHEEP",
            "SILVERFISH",
            "SKELETON",
            "SKELETON_HORSE",
            "SHULKER",
            "SLIME",
            "SNOWMAN",
            "SPIDER",
            "STRAY",
            "SQUID",
            "VEX",
            "VILLAGER",
            "VINDICATOR",
            "WITCH",
            "WITHER",
            "WITHER_SKELETON",
            "WOLF",
            "ZOMBIE",
            "ZOMBIE_HORSE",
            "ZOMBIE_VILLAGER"
        };
    }
}
