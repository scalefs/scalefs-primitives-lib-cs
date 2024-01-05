// Copyright (c) ScaleFS LLC; used with permission
// Licensed under the MIT License

using System.ComponentModel;

namespace ScaleFS.Primitives;

public class ObservableBase : INotifyPropertyChanged
{
     // INotifyPropertyChanged events
     //
     public event PropertyChangedEventHandler? PropertyChanged;
     //
     // NOTE: this OnPropertyChanged function allows subclasses to handle property change events; be aware that those classes MUST call Base.OnPropertyChanged at the end of their functions if they override this function
     protected void OnPropertyChanged(PropertyChangedEventArgs e)
     {
          this.PropertyChanged?.Invoke(this, e);
     }

     //

     protected void SetPropertyWithNotification<T>(string propertyName, ref T backingVariable, T newValue)
     {
          if (object.Equals(backingVariable, newValue) == false)
          {
               backingVariable = newValue;
               this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
          }
     }
}
