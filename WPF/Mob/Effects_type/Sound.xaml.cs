using MythicMobs_edit.Obj_save.Mob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MythicMobs_edit.WPF.Mob.Effects_type
{
    /// <summary>
    /// Sound.xaml 的交互逻辑
    /// </summary>
    public partial class Sound : Window
    {
        public Effects Effects { get; set; }
        private List<string> Sound_list = new List<string>()
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
        public Sound(Effects Effects)
        {
            InitializeComponent();
            this.Effects = Effects;
            if (!(this.Effects.Option is Obj_save.Mob.Effects_type.Sound))
            {
                this.Effects.Option = new Obj_save.Mob.Effects_type.Sound();
            }
            Type.Type.SelectedItem = this.Effects.Skill_Tag.Tag_Type;
            Type.Option.Text = this.Effects.Skill_Tag.Tag_Option;
            Type.Skill_Tag_ = Effects.Skill_Tag.Tag_Filters;
            Triggers_.Option.Text = Effects.Triggers.Option;
            Triggers_.Type.SelectedItem = Effects.Triggers.Type;
            DataContext = this;
            Type_F.ItemsSource = Sound_list;
            Type.refash_SkillTag();
        }
        private void TextCompositionEventArgs(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            e.Handled = re.IsMatch(e.Text);
        }
        public Effects get_Effects_()
        {
            ShowDialog();
            Effects.Skill_Tag.Tag_Type = (string)Type.Type.SelectedItem;
            Effects.Skill_Tag.Tag_Option = Type.Option.Text;
            Effects.Skill_Tag.Tag_Filters = Type.Skill_Tag_;
            Effects.Triggers.Type = (string)Triggers_.Type.SelectedItem;
            Effects.Triggers.Option = Triggers_.Option.Text;
            return Effects;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            Type_F.SelectedItem = Sound_list[random.Next(Sound_list.Count)];
        }
    }
}
