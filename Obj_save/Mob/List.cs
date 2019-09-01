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
        public List<string> Drops_Type = new List<string>()
        {
            "<item>", "exp", "<droptable>", "champions-exp", "skillapi-exp",
            "heroesexp", "mcmmo-exp", "money", "mythicdrop <item>", "phatloot <item>"
        };
        public List<string> DamageModifiers_All = new List<string>()
        {
            "DROWNING", "BLOCK_EXPLOSION", "ENTITY_EXPLOSION", "VOID", "LIGHTNING",
            "SUICIDE", "STARVATION", "POISON", "MAGIC", "DRAGON_BREATH", "WITHER",
            "FALLING_BLOCK", "THORNS", "CUSTOM", "LAVA", "MELTING", "FIRE_TICK",
            "FIRE", "HOT_FLOOR", "FALL", "SUFFOCATION", "PROJECTILE", "ENTITY_ATTACK",
            "CONTACT"
        };
        public List<string> Disguise_Type = new List<string>()
        {
            "arrow", "babyzombievillager", "bat", "blaze", "block", "boat", "cave_spider",
            "chicken", "cow", "creeper", "donkey", "dropped_item", "egg", "ender_crystal",
            "ender_dragon", "ender_pearl", "ender_signal", "enderman", "experience_orb",
            "fireball", "firework", "fishing_hook", "ghast", "giant", "horse", "iron_golem",
            "item_frame", "leash_hitch", "magma_cube", "minecart", "minecart_chest",
            "minecart_furnace", "minecart_hopper", "minecart_mob_spawner", "minecart_tnt",
            "mule", "mushroom_cow", "ocelot", "painting", "pig", "pig_zombie", "player",
            "polar_bear", "primed_tnt", "sheep", "silverfish", "skeleton", "skeleton_horse",
            "slime", "small_fireball", "snowball", "snowman", "spider", "splash_potion",
            "squid", "thrown_exp_bottle", "undead_horse", "villager", "witch", "wither",
            "wither_skeleton", "wither_skull", "wolf", "zombie", "zombievillager"
        };
        public List<string> Skills_effect = new List<string>()
        {
            "blockmask", "ender", "enderbeam", "explosion", "firework", "flames", "geyser",
            "itemspray", "lightning", "particles", "particlebox", "particleline", "particlering",
            "particlesphere", "particletornado", "smoke", "smokeswirl", "sound", "spin",
            "atom"
        };
        public List<string> Skill_Tag = new List<string>()
        {
            "@Self", "@Target", "@Trigger", "@NearestPlayer", "@WolfOwner", "@Owner", "@Mount",
            "@LivingEntitiesInRadius", "@PlayersInRadius", "@MobsInRadius", "@EntitiesInRadius",
            "@PlayersInWorld", "@PlayersOnServer", "@PlayersInRing", "@PlayersNearOrigin",
            "@MobsNearOrigin", "@EntitiesNearOrigin", "@RandomThreatTarget", "@ThreatTable",
            "@ThreatTablePlayers", "@SelfLocation", "@TargetLocation", "@TriggerLocation",
            "@Location", "@Origin", "@Spawner", "@RLNTE", "@PlayerLocationsInRadius",
            "@Ring", "@Cone", "@EntitiesInCone", "@Line", "@EntitiesInLine", "@p", "@a", "@r", "@e"
        };
        public List<string> Skill_Tag_no = new List<string>()
        {
            "animals", "creative", "creatures", "flyingmobs", "monsters", "NPCs", "players",
            "samefaction", "spectators", "watermobs"
        };
        public List<string> Skill_Triggers = new List<string>()
        {
            "onCombat", "onAttack", "onDamaged", "onSpawn", "onFirstSpawn", "onDeath", "onTimer",
            "onInteract", "onKillPlayer", "onPlayerDeath", "onEnterCombat", "onDropCombat",
            "onChangeTarget", "onExplode", "onTeleport", "onSignal", "onShoot"
        };
    }
}
