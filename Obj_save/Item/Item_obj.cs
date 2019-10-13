using System.Collections.Generic;

namespace MythicMobs_edit.Obj_save.Item
{
    public class Item_obj
    {
        /// <summary>
        /// 物品ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 物品数据
        /// </summary>
        public int Data { get; set; }
        /// <summary>
        /// 物品名称
        /// </summary>
        public string Display { get; set; }
        /// <summary>
        /// 物品属性
        /// </summary>
        public Body Body { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// 子选项
        /// </summary>
        public Options Options { get; set; }
        /// <summary>
        /// 附魔
        /// </summary>
        public List<string> Enchantments { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> Lore { get; set; }
        /// <summary>
        /// 药水效果
        /// </summary>
        public List<string> PotionEffects { get; set; }
        /// <summary>
        /// 旗帜样式
        /// </summary>
        public List<string> BannerLayers { get; set; }
        /// <summary>
        /// 允许隐藏特定的属性
        /// </summary>
        public List<string> Hide { get; set; }
    }
}
