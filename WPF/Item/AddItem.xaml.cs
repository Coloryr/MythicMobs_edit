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
        public List<Attributes_obj> Attributes_L { get; set; } = new List<Attributes_obj>();
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
            Attributes attributes = new Attributes((string)Attributes_S.SelectedItem);
            switch (Attributes_S.SelectedItem)
            {
                case "All":
                    item.Body.All = attributes.obj_get();
                    break;
            }
            Attributes_T.Items.Add(item.Body.All);
            have_body.Remove((string)Attributes_S.SelectedItem);
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
            if (Attributes_T.SelectedItems == null)
                return;
            Attributes_T.Items.Remove(Attributes_T.SelectedItems);
            Attributes_obj a = (Attributes_obj)Attributes_T.SelectedItems;

        }
        private void ChangeAttributes_TEvent(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
