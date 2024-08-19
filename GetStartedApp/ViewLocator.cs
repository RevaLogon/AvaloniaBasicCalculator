using Avalonia.Controls;
using Avalonia.Controls.Templates;
using System;

namespace GetStartedApp
{
    public class ViewLocator : IDataTemplate
    {
        public Control? Build(object? data)
        {
            if (data == null)
                return null;

            var name = data.GetType().FullName?.Replace("ViewModel", "View");
            if (name == null)
                return new TextBlock { Text = "Invalid ViewModel name." };

            var type = Type.GetType(name);
            if (type == null)
                return new TextBlock { Text = "Not Found: " + name };

            return (Control?)Activator.CreateInstance(type);
        }

        public bool Match(object? data)
        {
            return data != null && data.GetType().FullName?.EndsWith("ViewModel") == true;
        }
    }
}

