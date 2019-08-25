using MythicMobs_edit.Obj_save.Mob.Mob_type;

namespace MythicMobs_edit.Obj_save.Mob
{
    class Obj_get
    {
        public static object Mob_Type_get(string type)
        {
            switch (type)
            {
                case "ARMOR_STAND":
                    return new ARMOR_STAND();
                case "CHICKEN":
                    return new CHICKEN();
                case "CREEPER":
                    return new CREEPER();
                case "ENDERMAN":
                    return new ENDERMAN();
                case "FALLING_BLOCKS":
                    return null;
                case "HORSE":
                    return new HORSE();
                case "OCELOT":
                    return new OCELOT();
                case "PIG":
                    return new PIG();
                case "RABBIT":
                    return new RABBIT();
                case "SILVERFISH":
                    return new SILVERFISH();
                case "SNOWMAN":
                    return new SNOWMAN();
                case "PRIMED_TNT":
                    return new PRIMED_TNT();
                case "VILLAGER":
                    return new VILLAGER();
                case "ZOMBIE":
                    return new ZOMBIE();
                case "ZOMBIE_VILLAGER":
                    return new ZOMBIE_VILLAGER();
                default:
                    return null;
            }
        }
    }
}
