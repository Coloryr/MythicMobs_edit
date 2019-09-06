using System.Collections.Generic;

namespace MythicMobs_edit.Obj_save.Mob
{
    class List
    {
        public List<string> Sound_list = new List<string>()
        {
            "ambient.cave", "block.anvil.break", "block.glass.place", "block.metal.break", "block.metal.place",
            "block.stone.break", "block.stone.place", "block.anvil.destroy", "block.anvil.fall", "block.anvil.hit",
            "block.anvil.step", "block.glass.fall", "block.glass.hit", "block.glass.step", "block.metal.fall",
            "block.metal.hit", "block.metal.step", "block.stone.fall", "block.stone.hit", "block.stone.step",
            "block.anvil.land", "block.anvil.place", "block.anvil.use", "block.chest.close", "block.enderchest.close",
            "block.chest.locked", "block.fence_gate.close", "block.fence_gate.open", "block.iron_door.close",
            "block.iron_door.open", "block.trapdoor.close", "block.trapdoor.open", "block.wooden_door.close",
            "block.wooden_door.open", "block.chest.open", "block.enderchest.open", "block.cloth.break", "block.cloth.place",
            "block.cloth.fall", "block.cloth.hit", "block.cloth.step", "block.comparator.click", "block.dispenser.dispense",
            "block.dispenser.fail", "block.lever.click", "block.metal_pressureplate.click_off",
            "block.metal_pressureplate.click_on", "block.stone_button.click_off", "block.stone_button.click_on",
            "block.stone_pressureplate.click_off", "block.stone_pressureplate.click_on", "block.tripwire.attach",
            "block.tripwire.click_off", "block.tripwire.click_on", "block.wood_pressureplate.click_off",
            "block.wood_pressureplate.click_on", "ui.button.click", "block.dispenser.launch", "entity.arrow.shoot",
            "entity.bobber.throw", "entity.egg.throw", "entity.endereye.launch", "entity.enderpearl.throw",
            "entity.experience_bottle.throw", "entity.firework.shoot", "entity.lingeringpotion.throw", "entity.skeleton.shoot",
            "entity.snowball.throw", "entity.snowman.shoot", "entity.splash_potion.throw", "block.end_gateway.spawn",
            "entity.enderdragon_fireball.explode", "entity.generic.explode", "entity.lightning.impact",
            "block.fire.ambient", "entity.blaze.burn", "block.fire.extinguish", "block.lava.extinguish",
            "block.redstone_torch.burnout", "entity.generic.burn", "entity.generic.extinguish_fire", "block.glass.break",
            "entity.splash_potion.break", "block.grass.break", "block.grass.place", "block.grass.fall", "block.grass.hit",
            "block.grass.step", "block.gravel.break", "block.gravel.place", "block.gravel.fall", "block.gravel.hit",
            "block.gravel.step", "block.ladder.break", "block.ladder.place", "block.wood.break", "block.wood.place",
            "block.ladder.fall", "block.ladder.hit", "block.ladder.step", "block.lava.ambient", "block.lava.pop",
            "block.note.basedrum", "block.note.bass", "block.note.harp", "block.note.hat", "block.note.snare",
            "block.piston.contract", "block.piston.extend", "block.portal.ambient", "block.portal.travel", "block.portal.trigger",
            "block.sand.break", "block.sand.place", "block.sand.fall", "block.sand.hit", "block.sand.step",
            "block.slime.break", "block.slime.place", "entity.magmacube.death", "entity.magmacube.hurt", "entity.slime.death",
            "entity.slime.hurt", "entity.slime.jump", "entity.slime.squish", "block.slime.fall", "block.slime.hit",
            "block.slime.step", "entity.small_magmacube.death", "entity.small_magmacube.hurt", "entity.small_slime.death",
            "entity.small_slime.hurt", "entity.small_slime.squish", "block.snow.break", "block.snow.place",
            "block.snow.fall", "block.snow.hit", "block.snow.step", "block.tripwire.detach", "entity.arrow.hit",
            "block.water.ambient", "block.wood.fall", "block.wood.hit", "block.wood.step", "block.wood_button.click_off",
            "block.wood_button.click_on", "entity.arrow.successful_hit", "entity.bat.ambient", "entity.bat.death",
            "entity.bat.hurt", "entity.bat.takeoff", "entity.blaze.ambient", "entity.blaze.death", "entity.blaze.hurt",
            "entity.blaze.shoot", "entity.enderdragon.shoot", "entity.ghast.shoot", "entity.shulker.shoot", "item.firecharge.use",
            "entity.bobber.splash", "entity.cat.ambient", "entity.cat.death", "entity.cat.hurt", "entity.cat.purr",
            "entity.cat.purreow", "entity.chicken.ambient", "entity.chicken.death", "entity.chicken.hurt", "entity.chicken.egg",
            "entity.donkey.chest", "entity.chicken.step", "entity.cow.ambient", "entity.cow.death", "entity.cow.hurt",
            "entity.cow.step", "entity.creeper.death", "entity.creeper.hurt", "entity.creeper.primed", "entity.tnt.primed",
            "entity.donkey.ambient", "entity.mule.ambient", "entity.donkey.angry", "entity.donkey.death", "entity.mule.death",
            "entity.donkey.hurt", "entity.mule.hurt", "entity.elder_guardian.ambient", "entity.elder_guardian.ambient_land",
            "entity.guardian.ambient_land", "entity.elder_guardian.curse", "entity.elder_guardian.death",
            "entity.elder_guardian.death_land", "entity.guardian.death_land", "entity.elder_guardian.hurt",
            "entity.elder_guardian.hurt_land", "entity.guardian.hurt_land", "entity.enderdragon.ambient",
            "entity.enderdragon.growl", "entity.enderdragon.death", "entity.enderdragon.flap", "entity.enderdragon.hurt",
            "entity.endermen.ambient", "entity.endermen.death", "entity.endermen.hurt", "entity.endermen.scream",
            "entity.endermen.stare", "entity.endermen.teleport", "entity.shulker.teleport", "entity.experience_orb.pickup",
            "entity.experience_orb.touch", "entity.firework.blast", "entity.firework.blast_far", "entity.firework.large_blast",
            "entity.firework.large_blast_far", "entity.firework.launch", "entity.firework.twinkle", "entity.firework.twinkle_far",
            "entity.generic.big_fall", "entity.hostile.big_fall", "entity.player.big_fall", "entity.generic.death",
            "entity.generic.hurt", "entity.hostile.death", "entity.hostile.hurt", "entity.player.death", "entity.player.hurt",
            "entity.generic.drink", "entity.generic.eat", "entity.generic.small_fall", "entity.hostile.small_fall",
            "entity.player.small_fall", "entity.generic.splash", "entity.hostile.splash", "entity.player.splash",
            "entity.generic.swim", "entity.hostile.swim", "entity.player.swim", "entity.ghast.ambient", "entity.ghast.death",
            "entity.ghast.hurt", "entity.ghast.warn", "entity.guardian.ambient", "entity.guardian.attack", "entity.guardian.death",
            "entity.guardian.flop", "entity.guardian.hurt", "entity.horse.ambient", "entity.horse.angry", "entity.horse.armor",
            "entity.horse.breathe", "entity.horse.death", "entity.horse.gallop", "entity.horse.hurt", "entity.horse.jump",
            "entity.horse.land", "entity.horse.saddle", "entity.pig.saddle", "entity.horse.step", "entity.horse.step_wood",
            "entity.irongolem.attack", "entity.irongolem.death", "entity.irongolem.hurt", "entity.shulker.hit",
            "entity.shulker.hurt", "entity.irongolem.step", "entity.item.break", "entity.shield.break", "entity.item.pickup",
            "entity.lightning.thunder", "entity.magmacube.jump", "entity.magmacube.squish", "entity.minecart.inside",
            "entity.minecart.riding", "entity.pig.ambient", "entity.pig.hurt", "entity.pig.death", "entity.pig.step",
            "entity.player.burp", "entity.player.levelup", "entity.rabbit.ambient", "entity.rabbit.death", "entity.rabbit.hurt",
            "entity.rabbit.jump", "entity.sheep.ambient", "entity.sheep.death", "entity.sheep.hurt", "entity.sheep.shear",
            "entity.mooshroom.shear", "entity.sheep.step", "entity.silverfish.ambient", "entity.endermite.ambient",
            "entity.silverfish.death", "entity.endermite.death", "entity.silverfish.hurt", "entity.endermite.hurt",
            "entity.silverfish.step", "entity.endermite.step", "entity.skeleton.ambient", "entity.skeleton.death", "entity.skeleton.hurt",
            "entity.skeleton.step", "entity.skeleton_horse.ambient", "entity.skeleton_horse.death", "entity.skeleton_horse.hurt",
            "entity.slime.attack", "entity.small_magmacube.squish", "entity.spider.ambient", "entity.spider.hurt", "entity.spider.death",
            "entity.spider.step", "entity.villager.ambient", "entity.villager.death", "entity.villager.hurt", "entity.villager.no",
            "entity.villager.trading", "entity.villager.yes", "entity.wither.ambient", "entity.wither.death", "entity.wither.hurt",
            "entity.wither.shoot", "entity.wither.spawn", "entity.wolf.ambient", "entity.wolf.death", "entity.wolf.growl",
            "entity.wolf.hurt", "entity.wolf.pant", "entity.wolf.shake", "entity.wolf.step", "entity.wolf.whine", "entity.zombie.ambient",
            "entity.zombie.attack_door_wood", "entity.zombie.attack_iron_door", "entity.zombie.break_door_wood", "entity.wither.break_block",
            "entity.zombie.cure", "entity.zombie.death", "entity.zombie.hurt", "entity.zombie.step", "entity.zombie.unfect",
            "entity.zombie_horse.ambient", "entity.zombie_horse.death", "entity.zombie_horse.hurt", "entity.zombie_pig.ambient",
            "entity.zombie_pig.angry", "entity.zombie_pig.death", "entity.zombie_pig.hurt", "enttiy.zombie.infect",
            "item.flintandsteel.use", "music.creative", "music.credits", "music.dragon", "music.end", "music.game", "music.menu",
            "music.nether", "record.11", "record.13", "record.blocks", "record.cat", "record.chirp", "record.far", "record.mall",
            "record.mellohi", "record.stal", "record.strad", "record.wait", "record.ward", "weather.rain", "weather.rain.above"
        };
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
            "particlesphere", "particletornado", "smoke", "smokeswirl", "sound", "spin", "glow"
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
        public List<string> Skill_Mechanic = new List<string>()
        {
            "activatespawner", "arrowvolley", "command", "consume", "disguise", "undisguise",
            "dismount", "currencygive", "currencytake", "damage", "basedamage", "percentDamage",
            "decapitate", "doppleganger", "ejectpassenger", "equip", "explosion", "feed",
            "forcepull", "heal", "healpercent", "ignite", "jsonmessage", "jump", "leap",
            "lightning", "look", "message", "modifyglobalscore", "modifytargetscore", "modifyscore",
            "mount", "mounttarget", "potion", "prison", "pull", "pushbutton", "rally", "randommessage",
            "remount", "remove", "runaigoalselector", "runaitargetselector", "actionmessage",
            "sendtitle", "setblock", "setgliding", "setglobalscore", "setlevel", "setmobscore",
            "setowner", "settargetscore", "setscore", "setstance", "shootfireball", "shootpotion",
            "shootskull", "signal", "spring", "suicide", "summon", "addtag", "removetag",
            "teleport", "threat", "togglelever", "velocity", "weather",

        };
        public List<string> Conditions = new List<string>()
        {
            "altitude", "biome", "blocktype", "blocking", "crouching", "cuboid","dawn",
            "day", "distance", "distancefromspawn", "dusk", "entitytype", "fallspeed",
            "fieldofview", "gliding", "globalscore", "hasaura", "hascurrency",
            "hasinventoryspace", "hasowner", "hasparent", "hastag", "haspermission",
            "height", "heightabove", "heightbelow", "holding", "inblock", "incombat",
            "inside", "itemrecharging", "lastdamagecause", "lastsignal", "level","lightlevel",
            "lineofsight", "lunarphase", "mobsinchunk", "mobsinworld", "mounted", "moving",
            "mythicmobtype", "night", "notinregion", "offgcd", "onblock", "onground",
            "outside", "owner", "ownerisonline", "pitch", "playerkills", "playernotwithin",
            "playerwithin", "raining", "region", "score", "stance", "stringequals",
            "sunny", "targetinlineofsight", "targetnotinlineofsight", "targetwithin",
            "targetnotwithin", "targets", "thundering", "variableInRange", "variableisset",
            "varEquals", "wearing", "world", "worldtime", "yaw"
        };
        public List<string> Particle = new List<string>()
        {
            "barrier", "block_crack", "bubble", "bubble_column","bubble_pop","cloud",
            "crit", "crit_magic", "current_down", "damage_indicator", "dolphin", "dragon_breath",
            "drip_lava", "drip_water", "enchantment_table", "end_rod", "explosion_normal",
            "explosion_huge", "explosion_large", "falling_dust", "fireworks_spark", "flame",
            "footstep", "heart", "item_crack", "lava", "mob_appearance", "nautilus", "note",
            "portal", "redstone", "slime", "smoke_large", "smoke_normal", "snowball", "snow_shovel",
            "spell", "spell_instant", "spell_mob", "spell_mob_ambient", "spell_witch", "splash",
            "squid_ink", "suspended", "suspended_depth", "sweep_attack", "town_aura", "villager_angry",
             "villager_happy", "wake"
        };
        public List<string> Modify = new List<string>()
        {
            "SET", "ADD", "SUBTRACT", "MULTIPLY", "DIVIDE", "MOD"
        };
        public List<string> Modify_ = new List<string>()
        {
            "SET", "ADD", "SUBTRACT", "MULTIPLY", "DIVIDE"
        };
        public List<string> PotionEffects = new List<string>()
        {
            "ABSORPTION", "BLINDNESS", "CONDUIT_POWER", "CONFUSION", "DAMAGE_RESISTANCE", "DOLPHINS_GRACE",
            "FAST_DIGGING", "FIRE_RESISTANCE", "GLOWING", "HARM", "HEAL", "HEALTH_BOOST", "HUNGER",
            "INCREASE_DAMAGE", "INVISIBILITY", "JUMP", "LEVITATION", "LUCK", "NIGHT_VISION", "POISON",
            "REGENERATION", "SATURATION", "SLOW", "SLOW_DIGGING", "SLOW_FALLING", "SPEED", "UNLUCK",
            "WATER_BREATHING", "WEAKNESS", "WITHER"
        };
    }
}
