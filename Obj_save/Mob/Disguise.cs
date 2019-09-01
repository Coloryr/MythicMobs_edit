using System;

namespace MythicMobs_edit.Obj_save.Mob
{
    public class Disguise
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 皮肤名字
        /// </summary>
        public string Skin { get; set; }
        /// <summary>
        /// 生物燃烧
        /// </summary>
        public bool Burning { get; set; }
        /// <summary>
        /// 保持阻挡动作
        /// </summary>
        public bool Blocking { get; set; }
        /// <summary>
        /// 永久隐形
        /// </summary>
        public bool Invisible { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public bool ShowName { get; set; }
        /// <summary>
        /// 保持潜行动作
        /// </summary>
        public bool Sneaking { get; set; }
        /// <summary>
        /// 保持疾跑动作
        /// </summary>
        public bool Sprinting { get; set; }
        /// <summary>
        /// 不使用原来的碰撞箱
        /// </summary>
        public bool ModifyBoundingBox { get; set; }
        /// <summary>
        /// 永久发光
        /// </summary>
        public bool Glowing { get; set; }
        /// <summary>
        /// 永久滑翔
        /// </summary>
        public bool Gliding { get; set; }

        public string Type_r()
        {
            List List = new List();
            Random random = new Random();
            return List.Disguise_Type[random.Next(List.Disguise_Type.Count)];
        }
    }
}
