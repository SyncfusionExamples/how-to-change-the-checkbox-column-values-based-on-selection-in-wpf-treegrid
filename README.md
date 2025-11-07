# How to Change the Checkbox Column Values Based on Selection in WPF TreeGrid?

This sample illustrates how to change the checkbox column values based on selection in [WPF TreeGrid](https://www.syncfusion.com/wpf-controls/treegrid) (SfTreeGrid).

In TreeGrid, you can select multiple rows using the [SelectionMode](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_SelectionMode) property. You can process the CheckBoxSelection using [TreeGridCheckBoxColumn](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeGrid.TreeGridCheckBoxColumn.html) and a boolean property called **IsSelected** in Model. You can also select all the rows in TreeGrid by defining the CheckBox in header cell of **GridCheckBoxColumn** using [GridColumn.HeaderTemplate](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html#Syncfusion_UI_Xaml_TreeGrid_SfTreeGrid_HeaderTemplate).

``` c#
public static class Commands
{
    static Commands()
    {
        CommandManager.RegisterClassCommandBinding(typeof(CheckBox), new CommandBinding(CheckAndUnCheck, OnCheckUnCheckCommand, OnCanExecuteCheckAndUnCheck));
    }

    public static RoutedCommand CheckAndUnCheck = new RoutedCommand("CheckAndUnCheck", typeof(CheckBox));

    private static void OnCheckUnCheckCommand(object sender, ExecutedRoutedEventArgs args)
    {
        var treegrid = (args.Parameter as SfTreeGrid);
        var viewmodel = (treegrid.DataContext as ViewModel);
        var checkbox = (sender as CheckBox).IsChecked;
        if (viewmodel != null)
        {
            if (checkbox == true)
            {
                treegrid.SelectAll();
                foreach (var collection in viewmodel.EmployeeInfo)
                {
                    if (collection.IsSelected == false)
                        collection.IsSelected = true;
                }
            }
            else if (checkbox == false)
            {
                treegrid.ClearSelections(false);
                foreach (var collection in viewmodel.EmployeeInfo)
                {  
                    if (collection.IsSelected == true)
                        collection.IsSelected = false;
                }
            }
        }
    }

    private static void OnCanExecuteCheckAndUnCheck(object sender, CanExecuteRoutedEventArgs args)
    {
        args.CanExecute = true;
    }     
}
```
