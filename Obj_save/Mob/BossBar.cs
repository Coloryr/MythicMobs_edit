using System;
using System.Collections.Generic;

namespace MythicMobs_edit.Obj_save.Mob
{
    public class BossBar
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
        /// BOSS血条雾
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

        public List<string> Color = new List<string>
        {
            "PINK","BLUE","RED","GREEN","YELLOW","PURPLE","WHITE"
        };
        public List<string> Style = new List<string>
        {
            "SOLID","SEGMENTED_6","SEGMENTED_10", "SEGMENTED_12", "SEGMENTED_20"
        };

        public string get_color_r()
        {
            Random b = new Random();
            return Color[b.Next(Color.Count)];
        }
        public string get_style_r()
        {
            Random b = new Random();
            return Style[b.Next(Style.Count)];
        }
    }
}
