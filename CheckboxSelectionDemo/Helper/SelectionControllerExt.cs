using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.Utility;
using System.Windows.Threading;
using Syncfusion.UI.Xaml.ScrollAxis;
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid.Cells;
using Syncfusion.Windows.Shared;
using Syncfusion.UI.Xaml.TreeGrid;

namespace SelectionDemo
{

    public class RowSelectionController : TreeGridRowSelectionController
    {
        public RowSelectionController(SfTreeGrid treeGrid)
            : base(treeGrid)
        { }

        protected override void ProcessPointerReleased(MouseButtonEventArgs args, RowColumnIndex rowColumnIndex)
        {
            base.ProcessPointerReleased(args, rowColumnIndex);
            CheckBoxSelection(rowColumnIndex);
            args.Handled = true;
            this.TreeGrid.Focus();
        }

        protected override void ProcessKeyDown(KeyEventArgs args)
        {
            base.ProcessKeyDown(args);
            if (args.Key == Key.Space)
                CheckBoxSelection(this.CurrentCellManager.CurrentRowColumnIndex);
        }

        private void CheckBoxSelection(RowColumnIndex rowcolumnIndex)
        {
            var selectedrow = this.SelectedRows.FindAll(item => item.RowIndex == rowcolumnIndex.RowIndex);
            if (selectedrow.Count == 0)
            {
                var row = this.TreeGrid.GetNodeAtRowIndex(rowcolumnIndex.RowIndex).Item;
                (row as EmployeeInfo).IsSelected = false;
            }
            else
                (selectedrow[0].RowData as EmployeeInfo).IsSelected = true;
            var collectioncount = (this.TreeGrid.DataContext as ViewModel).EmployeeInfo.Count;
            var selecteditemcount = this.TreeGrid.SelectedItems.Count;
            if (selecteditemcount == collectioncount)
                (this.TreeGrid.DataContext as ViewModel).IsSelectAll = true;
            else if (selecteditemcount == 0)
                (this.TreeGrid.DataContext as ViewModel).IsSelectAll = false;
            else
                (this.TreeGrid.DataContext as ViewModel).IsSelectAll = null;
        }
    }
}
