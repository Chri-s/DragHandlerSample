using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using GongSolutions.Wpf.DragDrop;

namespace DragHandlerSample
{
    public class CustomTextDragSource : DefaultDragHandler
    {
        public override bool CanStartDrag(IDragInfo dragInfo)
        {
            // Check that the control which started the drag is a label.
            // Can be changed to the desired control type
            return (dragInfo.VisualSource is Label);
        }

        public override void StartDrag(IDragInfo dragInfo)
        {
            // Get the control that started the drag
            Label sourceControl = dragInfo.VisualSource as Label;
            if (sourceControl == null)
                return;

            // Drag the content of the label as text
            dragInfo.DataFormat = DataFormats.GetDataFormat(DataFormats.Text);
            dragInfo.Data = sourceControl.Content;
            dragInfo.Effects = DragDropEffects.Copy;
        }
    }
}
