namespace MythicMobs_edit.Obj_save.Mob.Mechanic_type
{
    public class Command
    {
        /// <summary>
        /// 命令
        /// </summary>
        public string command { get; set; }
        /// <summary>
        /// 发送至控制台
        /// </summary>
        public bool asCaster { get; set; } = false;
        /// <summary>
        /// OP
        /// </summary>
        public bool asOp { get; set; } = false;
    }
}
