using System.Collections.Generic;

namespace MythicMobs_edit.Obj_save.Item
{
    class List
    {
        /// <summary>
        /// 身体部位
        /// </summary>
        public List<string> body = new List<string>()
        {
            "All", "MainHand", "OffHand", "Head", 
            "Chest", "Legs", "Feet"
        };
        public List<string> Enchantments = new List<string>()
        {
            "PROTECTION_ENVIRONMENTAL", "PROTECTION_FIRE", "PROTECTION_FALL", "PROTECTION_EXPLOSIONS",
            "PROTECTION_PROJECTILE", "OXYGEN", "WATER_WORKER", "THORNS", "DEPTH_STRIDER", "FROST_WALKER",
            "BINDING_CURSE", "DAMAGE_ALL","DAMAGE_UNDEAD", "DAMAGE_ARTHROPODS", "KNOCKBACK", "FIRE_ASPECT",
            "LOOT_BONUS_MOBS", "ARROW_DAMAGE", "ARROW_KNOCKBACK", "ARROW_FIRE", "ARROW_INFINITE", "LUCK",
            "LURE", "LOYALTY", "IMPALING", "RIPTIDE", "CHANNELING", "MULTISHOT", "QUICK_CHARGE", "PIERCING",
            "MENDING"
        };
        public List<string> PotionEffects = new List<string>()
        {
            "ABSORPTION", "BLINDNESS", "CONFUSION", "DAMAGE_RESISTANCE", "FAST_DIGGING", "FIRE_RESISTANCE",
            "GLOWING", "HARM", "HEAL", "HEALTH_BOOST", "HUNGER", "INCREASE_DAMAGE", "INVISIBILITY", "JUMP",
            "LEVITATION", "LUCK", "NIGHT_VISION", "POISON", "REGENERATION", "SATURATION", "SLOW", "SLOW_DIGGING",
            "SPEED", "UNLUCK", "WATER_BREATHING", "WEAKNESS", "WITHER"
        };
        public List<string> Color = new List<string>()
        {
            "WHILE", "ORANGE", "MAGENTA", "LIGHT_BLUE", "YELLOW", "LIME", "PINK", "GRAY",
            "SILVER", "CYAN", "PURPLE", "BLUE", "BROWN", "GREEN", "RED", "BLACK"
        };
        public List<string> BannerLayers = new List<string>()
        {
            "SQUARE_BOTTOM_LEFT", "SQUARE_BOTTOM_RIGHT", "SQUARE_TOP_LEFT", "SQUARE_TOP_RIGHT", "STRAIGHT_CROSS",
            "STRIPE_BOTTOM", "STRIPE_CENTER", "STRIPE_DOWNLEFT", "STRIPE_DOWNRIGHT", "STRIPE_LEFT", "STRIPE_MIDDLE",
            "STRIPE_RIGHT", "STRIPE_SMALL", "STRIPE_TOP", "TRIANGLE_BOTTOM", "TRIANGLE_TOP", "TRIANGLES_BOTTOM",
            "TRIANGLES_TOP", "RHOMBUS_MIDDLE", "SKULL"
        };
        public List<string> Hide = new List<string>()
        {
            "ATTRIBUTES", "ENCHANTS", "DESTROYS", "PLACED_ON", "POTION_EFFECTS", "UNBREAKABLE"
        };
    }
}
