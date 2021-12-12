using Bullshit.ServiceReference1;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Bullshit
{
	/// <summary>
	/// Interaction logic for StrarupUserControl.xaml
	/// </summary>
	public partial class CanbanControle : UserControl
    {

        public User User { get; set; }

        public CanbanControle()
        {
            InitializeComponent();
        }

        private void panel_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Object"))
            {
                e.Effects = DragDropEffects.Move;
            }
        }

        private void panel_Drop(object sender, DragEventArgs e)
        {
            if (e.Handled == false)
            {
               
                Panel _panel = (Panel)sender;
                UIElement _element = (UIElement)e.Data.GetData("Object");

                if (_panel != null && _element != null)
                {
                    Panel _parent = (Panel)VisualTreeHelper.GetParent(_element);

                    if (_parent != null)
                    {
                        if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                        {
                            _parent.Children.Remove(_element);
                            _panel.Children.Add(_element);
                            e.Effects = DragDropEffects.Move;
                        }
                    }
                }
            }
        }

        private void CreateNewTaskClick(object sender, MouseButtonEventArgs e)
        {
            var tmp = (sender as StackPanel);
            tmp.Children.Add(new MyVisualTask() { Height = 80, Margin = new Thickness() { Left = 5, Bottom = 5, Right = 5, Top = 5 }, UserWhoCreateTask = User  });
        }
    }
}
