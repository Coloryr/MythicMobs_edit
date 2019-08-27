using System;

namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    public class WOLF
    {
        /// <summary>
        /// 年龄
        /// </summary>
        public double Age { get; set; }
        /// <summary>
        /// 是否锁住生物的年龄
        /// </summary>
        public bool AgeLock { get; set; }
        /// <summary>
        /// 是否能被玩家驯服
        /// </summary>
        public bool Tameable { get; set; }
        /// <summary>
        /// 是否愤怒
        /// </summary>
        public bool Angry { get; set; }
        /// <summary>
        /// 羊毛颜色
        /// </summary>
        public string Color { get; set; }
        public string get_color_r()
        {
            List List = new List();
            Random b = new Random();
            return List.WoolColor[b.Next(List.WoolColor.Count)];
        }
    }
}
