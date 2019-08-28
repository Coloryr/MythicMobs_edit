using System.Collections.Generic;

namespace MythicMobs_edit.Obj_save.Mob
{
    class List
    {
        public List<string> Type_list = new List<string>()
        {
            "ARMOR_STAND",
            "BABY_PIG_ZOMBIE",
            "BABY_PIG_ZOMBIE_VILLAGER",
            "BABY_ZOMBIE",
            "BABY_ZOMBIE_VILLAGER",
            "BAT",
            "BLAZE",
            "BOAT",
            "CAVE_SPIDER",
            "CHICKEN",
            "COW",
            "CREEPER",
            "ELDER_GUARDIAN",
            "ENDER_DRAGON",
            "ENDERMAN",
            "ENDERMITE",
            "EVOKER",
            "FALLING_BLOCKS",
            "GHAST",
            "GIANT",
            "GUARDIAN",
            "HORSE",
            "HUSK",
            "IRON_GOLEM",
            "LLAMA",
            "MAGMA_CUBE",
            "MUSHROOM_COW",
            "OCELOT",
            "PIG",
            "PIG_ZOMBIE",
            "PIG_ZOMBIE_VILLAGER",
            "PRIMED_TNT",
            "POLAR_BEAR",
            "RABBIT",
            "SHEEP",
            "SILVERFISH",
            "SKELETON",
            "SKELETON_HORSE",
            "SHULKER",
            "SLIME",
            "SNOWMAN",
            "SPIDER",
            "STRAY",
            "SQUID",
            "VEX",
            "VILLAGER",
            "VINDICATOR",
            "WITCH",
            "WITHER",
            "WITHER_SKELETON",
            "WOLF",
            "ZOMBIE",
            "ZOMBIE_HORSE",
            "ZOMBIE_VILLAGER"
        };

        public List<string> HorseArmor = new List<string>()
        {
            "IRON","GOLD","DIAMOND"
        };
        public List<string> HorseColor = new List<string>()
        {
            "BLACK","BROWN","CHESTNUT","CREAMY","DARK_BROWN","GRAY","WHITE"
        };
        public List<string> HorseStyle = new List<string>()
        {
            "BLACK_DOTS","WHITE","WHITE_DOTS","WHITEFIELD"
        };

        public List<string> OcelotType = new List<string>
        {
            "BLACK_CAT","RED_CAT","SIAMESE_CAT","WILD_OCELOT"
        };

        public List<string> RabbitType = new List<string>()
        {
            "BLACK","BLACK_AND_WHITE","BROWN","GOLD", "SALT_AND_PEPPER","THE_KILLER_BUNNY","WHITE"
        };

        public List<string> VillagerType = new List<string>()
        {
            "BLACKSMITH","BUTCHER","FARMER", "LIBRARIAN","PRIEST"
        };

        public List<string> BossBarColor = new List<string>
        {
            "PINK","BLUE","RED","GREEN","YELLOW","PURPLE","WHITE"
        };
        public List<string> BossBarStyle = new List<string>
        {
            "SOLID","SEGMENTED_6","SEGMENTED_10", "SEGMENTED_12", "SEGMENTED_20"
        };
        public List<string> WoolColor = new List<string>()
        {
            "WHILE", "ORANGE", "MAGENTA", "LIGHT_BLUE", "YELLOW", "LIME", "PINK", "GRAY",
            "SILVER", "CYAN", "PURPLE", "BLUE", "BROWN", "GREEN", "RED", "BLACK"
        };
        public List<string> AI_Goal_All = new List<string>()
        {
            "clear", "breakdoors", "eatgrass", "float", "lookatplayers", "opendoors", "closedoors",
            "randomlookaround", "avoidarrows", "avoidcreepers", "avoidskeletons", "avoidzombies",
            "fleesun", "meleeattack", "movetowardstarget", "randomstroll", "restrictsun",
            "fleeplayers", "fleegolems", "fleevillagers", "spiderattack", "leapattarget",
            "moveindoors", "movethroughvillage", "movetowardsrestriction", "patrol [x1,y1,z1;x2,y2,z2;x3,y3,z3]",
            "gotolocation [x,y,z]", "gotoowner", "arrowattack", "skeletonbowattack"
        };
        public List<string> AI_Target_All = new List<string>()
        {
            "clear", "attacker", "monsters", "players", "villagers", "golems",
            "OtherFaction", "OtherFactionMonsters", "OtherFactionVillagers",
            "SpecificFaction [faction_name]", "SpecificFactionMonsters [faction_name]"
        };
    }
}
