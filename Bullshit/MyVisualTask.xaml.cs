using Bullshit.ServiceReference1;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bullshit
{
	public partial class MyVisualTask : UserControl
    {
        public User UserWhoCreateTask { get; set; }

        public MyVisualTask()
        {
            InitializeComponent();
            
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                
                    DataObject data = new DataObject();
                    data.SetData("Double", MyTask.Height);
                    data.SetData("Object", this);

                    DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
            }
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            try
            {
                base.OnGiveFeedback(e);
                if (e.Effects.HasFlag(DragDropEffects.Move))
                {
                    Mouse.SetCursor(Cursors.Pen);
                }
                else
                {
                    Mouse.SetCursor(Cursors.No);
                }
                e.Handled = true;
            }
            catch (Exception)
            {

            }

        }

        private void ApplyClick(object sender, MouseButtonEventArgs e)
        {
            CretedByBox.IsEnabled = false;
            DescriptionBox.IsEnabled = false;
        }

        private void EditClick(object sender, MouseButtonEventArgs e)
        {
            CretedByBox.IsEnabled = true;
            DescriptionBox.IsEnabled = true;
        }
    }
}
