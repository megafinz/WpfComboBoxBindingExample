using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ComboBoxBindingExample;

internal record Device(string Name);

// ObservableObject implements INotifyPropertyChanged
// which will allow to update Views that are bound to this object if it changes. 
internal sealed partial class MainViewModel : ObservableObject
{
    // CommunityToolkit.Mvvm will use a source generator during build to
    // add a property to this class that exposes this field and automatically triggers INotifyPropertyChanged logic
    // if it changes.
    [ObservableProperty] private Device? _selectedDevice;

    public MainViewModel()
    {
        AddNewDeviceCommand = new RelayCommand(DoAddNewDevice);
    }
    
    // ObservableCollection needs to be created only once.
    // It will then take care of notifying the View when items are added or removed from it.
    public ObservableCollection<Device> Devices { get; } = new();
    
    public ICommand AddNewDeviceCommand { get; }

    private void DoAddNewDevice()
    {
        var rnd = Random.Shared;
        var newDevice = new Device($"Device {rnd.Next(100)}");
        
        // Here ComboBox will update its item list. 
        Devices.Add(newDevice);
        
        // Here ComboBox will refresh its selected item.
        SelectedDevice = newDevice;
    }
}
