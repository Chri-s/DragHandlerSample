using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using GongSolutions.Wpf.DragDrop;

namespace DragHandlerSample
{
    public class CustomFileDragSource : DefaultDragHandler
    {
        public override bool CanStartDrag(IDragInfo dragInfo)
        {
            // Check that the control which started the drag is a label and the content is a string.
            // Can be changed to the desired control type
            return (dragInfo.VisualSource is Label label && label.Content is string);
        }

        public override void StartDrag(IDragInfo dragInfo)
        {
            // Get the control that started the drag and the filename from the label
            Label sourceControl = dragInfo.VisualSource as Label;
            if (sourceControl == null || !(sourceControl.Content is string fileName))
                return;

            // Get the path of TextFile.txt in the output directory
            string folder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string path = Path.Combine(folder, fileName);

            // Drag the TextFile.txt in the output directory
            dragInfo.DataFormat = DataFormats.GetDataFormat(DataFormats.FileDrop);
            dragInfo.Data = new string[] { path };
            dragInfo.Effects = DragDropEffects.Copy;
        }
    }
}
