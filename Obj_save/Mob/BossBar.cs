using System;

namespace MythicMobs_edit.Obj_save.Mob
{
    class BossBar
    {
        /// <summary>
        /// BOSS血条启用
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// BOSS血条标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// BOSS血条显示范围
        /// </summary>
        public int Range { get; set; }
        /// <summary>
        /// BOSS血条颜色
        /// </summary>
        public string Color_save { get; set; }
        /// <summary>
        /// BOSS血条风格
        /// </summary>
        public string Style_save { get; set; }
        /// <summary>
        /// BOSS血条颜色
        /// </summary>
        public bool CreateFog { get; set; }
        /// <summary>
        /// BOSS血条黑色天空
        /// </summary>
        public bool DarkenSky { get; set; }
        /// <summary>
        /// BOSS血条音乐播放
        /// </summary>
        public bool PlayMusic { get; set; }
        public class Color
        {
            public string PINK { get { return "PINK"; } }
            public string BLUE { get { return "BLUE"; } }
            public string RED { get { return "RED"; } }
            public string GREEN { get { return "GREEN"; } }
            public string YELLOW { get { return "YELLOW"; } }
            public string PURPLE { get { return "PURPLE"; } }
            public string WHITE { get { return "WHITE"; } }
        }
        public class Style
        {
            public string SOLID { get { return "SOLID"; } }
            public string SEGMENTED_6 { get { return "SEGMENTED_6"; } }
            public string SEGMENTED_10 { get { return "SEGMENTED_10"; } }
            public string SEGMENTED_12 { get { return "SEGMENTED_12"; } }
            public string SEGMENTED_20 { get { return "SEGMENTED_20"; } }
        }

        public string get_color_r()
        {
            Color Color = new Color();
            string[] a = { Color .BLUE, Color .GREEN, Color .PINK, Color .PURPLE,
            Color.RED,Color.WHITE,Color.YELLOW};
            Random b = new Random();
            return a[b.Next(a.Length)];
        }
        public string get_style_r()
        {
            Style Style = new Style();
            string[] a = { Style .SEGMENTED_10, Style .SEGMENTED_12, Style .SEGMENTED_20,
            Style.SEGMENTED_6,Style.SOLID};
            Random b = new Random();
            return a[b.Next(a.Length)];
        }
    }
}
