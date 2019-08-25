using System;
using System.Collections.Generic;

namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    class HORSE
    {
        /// <summary>
        /// 马的盔甲种类
        /// </summary>
        public string HorseArmor_save { get; set; } = null;
        /// <summary>
        /// 是否携带箱子
        /// </summary>
        public bool HorseCarryingChest { get; set; }
        /// <summary>
        /// 马的颜色
        /// </summary>
        public string HorseColor { get; set; }
        /// <summary>
        /// 马是否带鞍
        /// </summary>
        public bool HorseSaddled { get; set; } = false;
        /// <summary>
        /// 马的斑点
        /// </summary>
        public string HorseStyle { get; set; }
        /// <summary>
        /// 马的斑点
        /// </summary>
        public bool HorseTamed { get; set; } = false;

        public List<string> HorseArmor = new List<string>()
        {
            "IRON","GOLD","DIAMOND"
        };
        public List<string> Color = new List<string>()
        {
            "BLACK","BROWN","CHESTNUT","CREAMY","DARK_BROWN","GRAY","WHITE"
        };
        public List<string> Style = new List<string>()
        {
            "BLACK_DOTS","WHITE","WHITE_DOTS","WHITEFIELD"
        };

        public string get_style_r()
        {
            Random b = new Random();
            return Style[b.Next(Style.Count)];
        }
        public string get_color_r()
        {
            Random b = new Random();
            return Color[b.Next(Color.Count)];
        }
    }
}
