namespace MythicMobs_edit.Obj_save.Item
{
    public class Options
    {
        /// <summary>
        /// 是否可以修复
        /// </summary>
        public bool Repairable { get; set; }
        /// <summary>
        /// 修复花费的经验
        /// </summary>
        public int RepairCost { get; set; }
        /// <summary>
        /// 物品不可损坏
        /// </summary>
        public bool Unbreakable { get; set; }
        /// <summary>
        /// （头颅）玩家名字
        /// </summary>
        public string Player { get; set; }
        /// <summary>
        /// 头颅材质
        /// </summary>
        public string SkinTexture { get; set; }
        /// <summary>
        /// 可染色物品颜色
        /// </summary>
        public string Color { get; set; }
    }
}
