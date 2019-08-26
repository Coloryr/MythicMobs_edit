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

        public string get_style_r()
        {
            List List = new List();
            Random b = new Random();
            return List.HorseStyle[b.Next(List.HorseStyle.Count)];
        }
        public string get_color_r()
        {
            List List = new List();
            Random b = new Random();
            return List.HorseColor[b.Next(List.HorseColor.Count)];
        }
    }
}
