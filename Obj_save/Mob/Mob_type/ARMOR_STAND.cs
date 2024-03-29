﻿namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    public class ARMOR_STAND
    {
        /// <summary>
        /// 盔甲架是否有手臂
        /// </summary>
        public bool HasArms { get; set; }
        /// <summary>
        /// 盔甲架是否被重力影响
        /// </summary>
        public bool HasGravity { get; set; }
        /// <summary>
        /// 盔甲架是否隐形
        /// </summary>
        public bool Invisible { get; set; }
        /// <summary>
        /// 盔甲架佩戴在身体的物品
        /// </summary>
        public string ItemBody { get; set; }
        /// <summary>
        /// 盔甲架佩戴在脚部的物品
        /// </summary>
        public string ItemFeet { get; set; }
        /// <summary>
        /// 盔甲架佩戴在手上的物品
        /// </summary>
        public string ItemHand { get; set; }
        /// <summary>
        /// 盔甲架佩戴在头部的物品
        /// </summary>
        public string ItemHead { get; set; }
        /// <summary>
        /// 盔甲架佩戴在腿部的物品
        /// </summary>
        public string ItemLegs { get; set; }
        /// <summary>
        /// 盔甲架是否为标记
        /// </summary>
        public bool Marker { get; set; }
        /// <summary>
        /// 是否是小盔甲架
        /// </summary>
        public bool Small { get; set; }
        /// <summary>
        /// 盔甲架动作坐标
        /// </summary>
        public Pose_ Pose { get; set; }
        public class Pose_
        {
            public string Head { get; set; }
            public string Body { get; set; }
            public string LeftArm { get; set; }
            public string RightArm { get; set; }
            public string LeftLeg { get; set; }
            public string RightLeg { get; set; }
        }
    }
}
