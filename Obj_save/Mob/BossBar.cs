using MythicMobs_edit.Obj_save.Mob.Mob_type;
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

        public string get_color_r()
        {
            List List = new List();
            Random b = new Random();
            return List.BossBarColor[b.Next(List.BossBarColor.Count)];
        }
        public string get_style_r()
        {
            List List = new List();
            Random b = new Random();
            return List.BossBarStyle[b.Next(List.BossBarStyle.Count)];
        }
    }
}
