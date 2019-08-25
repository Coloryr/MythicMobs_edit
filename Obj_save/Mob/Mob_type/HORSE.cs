using System;

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
        public class HorseArmor
        {
            public string IRON { get { return "IRON"; } }
            public string GOLD { get { return "GOLD"; } }
            public string DIAMOND { get { return "DIAMOND"; } }
        }
        public class Color
        {
            public string BLACK { get { return "BLACK"; } }
            public string BROWN { get { return "BROWN"; } }
            public string CHESTNUT { get { return "CHESTNUT"; } }
            public string CREAMY { get { return "CREAMY"; } }
            public string DARK_BROWN { get { return "DARK_BROWN"; } }
            public string GRAY { get { return "GRAY"; } }
            public string WHITE { get { return "WHITE"; } }
        }
        public class Style
        {
            public string BLACK_DOTS { get { return "BLACK_DOTS"; } }
            public string WHITE { get { return "WHITE"; } }
            public string WHITE_DOTS { get { return "WHITE_DOTS"; } }
            public string WHITEFIELD { get { return "WHITEFIELD"; } }
        }

        public string get_style_r()
        {
            Style Style = new Style();
            string[] a = { Style.BLACK_DOTS, Style.WHITE, Style.WHITE_DOTS, Style.WHITEFIELD };
            Random b = new Random();
            return a[b.Next(a.Length)];
        }
        public string get_color_r()
        {
            Color Color = new Color();
            string[] a = { Color.BLACK, Color.BROWN, Color.CHESTNUT,
                Color.CREAMY, Color.DARK_BROWN, Color.GRAY, Color.WHITE };
            Random b = new Random();
            return a[b.Next(a.Length)];
        }
    }
}
