using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Color Color { get; set; }
        /// <summary>
        /// BOSS血条风格
        /// </summary>
        public Style Style { get; set; }
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
    }
}
