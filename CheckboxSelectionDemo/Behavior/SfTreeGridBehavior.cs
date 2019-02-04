using Syncfusion.UI.Xaml.ScrollAxis;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;

namespace SelectionDemo
{
    class SfTreeGridBehavior:Behavior<SfTreeGrid>
    {
        SfTreeGrid treegrid = null;
        protected override void OnAttached()
        {
            treegrid = this.AssociatedObject as SfTreeGrid;
            treegrid.Loaded += Treegrid_Loaded;
            base.OnAttached();
        }

        private void Treegrid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var selectedItem = (this.treegrid.DataContext as ViewModel).SelectedItem;
            var rowindex = this.treegrid.ResolveToRowIndex(selectedItem);
            var columnindex = this.treegrid.ResolveToStartColumnIndex();
            //Make the row in to available on the view. 
            this.treegrid.ScrollInView(new RowColumnIndex(rowindex, columnindex));
            //Set the SelectedItem in SfTreeGrid.
            this.treegrid.SelectedItem = selectedItem;
        }
    }
}
