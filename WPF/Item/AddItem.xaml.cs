using MythicMobs_edit.Obj_save.Item;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace MythicMobs_edit.WPF.Item
{
    /// <summary>
    /// AddItem.xaml 的交互逻辑
    /// </summary>
    public partial class AddItem : Window
    {
        public Item_obj item { get; set; } = new Item_obj()
        { 
            Body = new Body(),
            Options = new Options(),
            Hide = new List<string>()
        };

        private List<string> have_body;
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
            have_body = list.body;
            Attributes_S.ItemsSource = have_body;
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
                    attributes = new Attributes(new Attributes_obj()
                    {
                        Name = "All"
                    }).obj_get();
                    item.Body.All = attributes;
                    break;
                case "MainHand":
                    attributes = new Attributes(new Attributes_obj()
                    {
                        Name = "MainHand"
                    }).obj_get();
                    item.Body.MainHand = attributes;
                    break;
                case "OffHand":
                    attributes = new Attributes(new Attributes_obj()
                    {
                        Name = "OffHand"
                    }).obj_get();
                    item.Body.OffHand = attributes;
                    break;
                case "Head":
                    attributes = new Attributes(new Attributes_obj()
                    {
                        Name = "Head"
                    }).obj_get();
                    item.Body.Head = attributes;
                    break;
                case "Chest":
                    attributes = new Attributes(new Attributes_obj()
                    {
                        Name = "Chest"
                    }).obj_get();
                    item.Body.Chest = attributes;
                    break;
                case "Legs":
                    attributes = new Attributes(new Attributes_obj()
                    {
                        Name = "Legs"
                    }).obj_get();
                    item.Body.Legs = attributes;
                    break;
                case "Feet":
                    attributes = new Attributes(new Attributes_obj()
                    {
                        Name = "Feet"
                    }).obj_get();
                    item.Body.Feet = attributes;
                    break;
            }
            Attributes_T.Items.Add(attributes);
            have_body.Remove((string)Attributes_S.SelectedItem);
            Attributes_S.ItemsSource = null;
            Attributes_S.ItemsSource = have_body;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
            have_body.Add(attributes.Name);
            Attributes_S.ItemsSource = have_body;
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
    }
}
