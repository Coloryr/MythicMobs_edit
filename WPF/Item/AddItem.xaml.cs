using MythicMobs_edit.Obj_save.Item;
using MythicMobs_edit.WPF.Use;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Effects;
using YamlDotNet.Serialization;

namespace MythicMobs_edit.WPF.Item
{
    /// <summary>
    /// AddItem.xaml 的交互逻辑
    /// </summary>
    public partial class AddItem : Window
    {
        /// <summary>
        /// 物品名字
        /// </summary>
        public string item_Name { get; set; } = "item";
        public Item_obj item { get; set; } = new Item_obj()
        {
            Id = "minectaft:stone",
            Display = "item",
            Body = new Body(),
            Options = new Options(),
            Enchantments = new List<string>(),
            Hide = new List<string>(),
            Lore = new List<string>(),
            PotionEffects = new List<string>(),
            BannerLayers = new List<string>()
        };

        private List<Enchantments_obj> Enchantments_L = new List<Enchantments_obj>();
        private List<PotionEffects_obj> PotionEffects_L = new List<PotionEffects_obj>();
        private List<BannerLayers_obj> BannerLayers_L = new List<BannerLayers_obj>();
        public AddItem(bool gs)
        {
            InitializeComponent();
            init();
            DataContext = this;
            BlurEffect BlurEffect = new BlurEffect();
            BlurEffect.Radius = gs == true ? 15 : 0;
            BG.Effect = BlurEffect;
            BG.Visibility = Visibility.Visible;
        }
        public void init()
        {
            List list = new List();
            Attributes_S.ItemsSource = list.body;
            Enchantments_S.ItemsSource = list.Enchantments;
            Hide_S.ItemsSource = list.Hide;
        }
        private void TextCompositionEventArgs(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            e.Handled = re.IsMatch(e.Text);
        }
        private void Attributes_Add(object sender, RoutedEventArgs e)
        {
            if (Attributes_S.SelectedItem == null)
                return;
            Attributes_obj attributes = new Attributes_obj();
            switch (Attributes_S.SelectedItem)
            {
                case "All":
                    attributes = new Attributes(new Attributes_obj()).obj_get();
                    item.Body.All = attributes;
                    break;
                case "MainHand":
                    attributes = new Attributes(new Attributes_obj()).obj_get();
                    item.Body.MainHand = attributes;
                    break;
                case "OffHand":
                    attributes = new Attributes(new Attributes_obj()).obj_get();
                    item.Body.OffHand = attributes;
                    break;
                case "Head":
                    attributes = new Attributes(new Attributes_obj()).obj_get();
                    item.Body.Head = attributes;
                    break;
                case "Chest":
                    attributes = new Attributes(new Attributes_obj()).obj_get();
                    item.Body.Chest = attributes;
                    break;
                case "Legs":
                    attributes = new Attributes(new Attributes_obj()).obj_get();
                    item.Body.Legs = attributes;
                    break;
                case "Feet":
                    attributes = new Attributes(new Attributes_obj()).obj_get();
                    item.Body.Feet = attributes;
                    break;
            }
            Attributes_T.Items.Add(attributes);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Out.Text = null;
            item.Enchantments.Clear();
            foreach (var obj in Enchantments_L)
            {
                item.Enchantments.Add(obj.ID + ":" + obj.Level);
            }
            item.PotionEffects.Clear();
            foreach (var obj in PotionEffects_L)
            {
                item.PotionEffects.Add(obj.type + " " + obj.duration + " " + obj.level);
            }
            item.BannerLayers.Clear();
            foreach (var obj in BannerLayers_L)
            {
                item.BannerLayers.Add(obj.color + " " + obj.pattern);
            }
            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(item);
            List<string> listLines = new List<string>();
            listLines.Add(item_Name + ":");
            StreamReader reader = new StreamReader(new MemoryStream(Encoding.Default.GetBytes(yaml)));
            string line = reader.ReadLine();
            bool isskill = false;
            while (string.IsNullOrWhiteSpace(line) != true)
            {
                if (line.IndexOf("Skills:") != -1)
                {
                    isskill = true;
                }
                if (isskill == true)
                    listLines.Add(("  " + line).Replace("'", ""));
                else
                    listLines.Add(("  " + line));
                line = reader.ReadLine();
            }
            foreach (string a in listLines)
            {
                Out.Text += a + "\n";
            }
            reader.Close();
        }
        private void Return(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
        private void DelectAttributes_TEvent(object sender, RoutedEventArgs e)
        {
            if (Attributes_T.SelectedItems.Count == 0)
                return;
            Attributes_obj attributes = (Attributes_obj)Attributes_T.SelectedItems[0];
            Attributes_T.Items.Remove(attributes);
        }
        private void ChangeAttributes_TEvent(object sender, RoutedEventArgs e)
        {
            if (Attributes_T.SelectedItems.Count == 0)
                return;
            Attributes_obj attributes = (Attributes_obj)Attributes_T.SelectedItems[0];
            Attributes_T.Items.Remove(attributes);
            attributes = new Attributes(attributes).obj_get();
            Attributes_T.Items.Add(attributes);
        }

        private void CheckBox_Check(object sender, RoutedEventArgs e)
        {
            if (Optiong_Repairable.IsChecked == true)
                RepaireCost.IsEnabled = true;
            else
                RepaireCost.IsEnabled = false;
        }

        private void Enchantments_Add(object sender, RoutedEventArgs e)
        {
            if (Enchantments_S.SelectedItem == null)
                return;
            Enchantments_obj Enchantments_obj = new Enchantments_obj()
            {
                ID = (string)Enchantments_S.SelectedItem,
                Level = 1
            };
            Enchantments_obj = new Enchantments(Enchantments_obj).obj_get();
            Enchantments_L.Add(Enchantments_obj);
            Enchantments_T.Items.Add(Enchantments_obj);
        }
        private void DelectEnchantments_TEvent(object sender, RoutedEventArgs e)
        {
            if (Enchantments_T.SelectedItems.Count == 0)
                return;
            Enchantments_obj Enchantments_obj = (Enchantments_obj)Enchantments_T.SelectedItems[0];
            Enchantments_L.Remove(Enchantments_obj);
            Enchantments_T.Items.Remove(Enchantments_obj);
        }
        private void ChangeEnchantments_TEvent(object sender, RoutedEventArgs e)
        {
            if (Enchantments_T.SelectedItems.Count == 0)
                return;
            Enchantments_obj Enchantments_obj = (Enchantments_obj)Enchantments_T.SelectedItems[0];
            Enchantments_L.Remove(Enchantments_obj);
            Enchantments_T.Items.Remove(Enchantments_obj);
            Enchantments_obj = new Enchantments(Enchantments_obj).obj_get();
            Enchantments_L.Add(Enchantments_obj);
            Enchantments_T.Items.Add(Enchantments_obj);
        }

        private void Lore_Add(object sender, RoutedEventArgs e)
        {
            string message = new MessageEdit("Lore", false).KillMessages_set();
            Lore_T.Items.Add(message);
            item.Lore.Add(message);
        }
        private void DelectLore_TEvent(object sender, RoutedEventArgs e)
        {
            if (Lore_T.SelectedItems.Count == 0)
                return;
            string message = (string)Lore_T.SelectedItems[0];
            Lore_T.Items.Remove(message);
            item.Lore.Remove(message);
        }
        private void ChangeLore_TEvent(object sender, RoutedEventArgs e)
        {
            if (Lore_T.SelectedItems.Count == 0)
                return;
            string message = (string)Lore_T.SelectedItems[0];
            item.Lore.Remove(message);
            Lore_T.Items.Remove(message);
            message = new MessageEdit(message, false).KillMessages_set();
            item.Lore.Add(message);
            Lore_T.Items.Add(message);
        }

        private void PotionEffects_Add(object sender, RoutedEventArgs e)
        {
            PotionEffects_obj obj =  new PotionEffects(new PotionEffects_obj()).obj_get();
            PotionEffects_L.Add(obj);
            PotionEffects_T.Items.Add(obj);
        }
        private void DelectPotionEffect_TEvent(object sender, RoutedEventArgs e)
        {
            if (PotionEffects_T.SelectedItems.Count == 0)
                return;
            PotionEffects_obj obj = (PotionEffects_obj)PotionEffects_T.SelectedItems[0];
            PotionEffects_T.Items.Remove(obj);
            PotionEffects_L.Remove(obj);
        }
        private void ChangePotionEffect_TEvent(object sender, RoutedEventArgs e)
        {
            if (PotionEffects_T.SelectedItems.Count == 0)
                return;
            PotionEffects_obj obj = (PotionEffects_obj)PotionEffects_T.SelectedItems[0];
            PotionEffects_L.Remove(obj);
            PotionEffects_T.Items.Remove(obj);
            obj = new PotionEffects(obj).obj_get();
            PotionEffects_L.Add(obj);
            PotionEffects_T.Items.Add(obj);
        }

        private void BannerLayers_Add(object sender, RoutedEventArgs e)
        {
            BannerLayers_obj obj = new BannerLayers(new BannerLayers_obj()).obj_get();
            BannerLayers_L.Add(obj);
            BannerLayers_T.Items.Add(obj);
        }
        private void DelectBannerLayers_TEvent(object sender, RoutedEventArgs e)
        {
            if (BannerLayers_T.SelectedItems.Count == 0)
                return;
            BannerLayers_obj obj = (BannerLayers_obj)BannerLayers_T.SelectedItems[0];
            BannerLayers_L.Remove(obj);
            BannerLayers_T.Items.Remove(obj);
        }
        private void ChangeBannerLayers_TEvent(object sender, RoutedEventArgs e)
        {
            if (BannerLayers_T.SelectedItems.Count == 0)
                return;
            BannerLayers_obj obj = (BannerLayers_obj)BannerLayers_T.SelectedItems[0];
            BannerLayers_L.Remove(obj);
            BannerLayers_T.Items.Remove(obj);
            obj = new BannerLayers(obj).obj_get();
            BannerLayers_L.Add(obj);
            BannerLayers_T.Items.Add(obj);
        }

        private void Hide_Add(object sender, RoutedEventArgs e)
        {
            if (Hide_S.SelectedItem == null)
                return;
            item.Hide.Add((string)Hide_S.SelectedItem);
            Hide_T.Items.Add((string)Hide_S.SelectedItem);
        }
        private void DelectHide_TEvent(object sender, RoutedEventArgs e)
        {
            if (Hide_T.SelectedItems.Count == 0)
                return;
            item.Hide.Remove((string)Hide_T.SelectedItem);
            Hide_T.Items.Remove((string)Hide_T.SelectedItem);
        }
    }
}
