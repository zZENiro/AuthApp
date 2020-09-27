using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AuthApp
{
    public class ViewModelTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
            {
                return null;
            }

            var itemType = item.GetType();
            
            var componentName = itemType.Name.Replace("ViewModel", "Role");
            var templatePath = $"pack://application:,,,/views/{componentName}.xaml";

            var resourceDictonary = new ResourceDictionary
            {
                Source = new Uri(templatePath, UriKind.Absolute)
            };

            return resourceDictonary
                .Values
                .OfType<DataTemplate>()
                .SingleOrDefault(_ => ReferenceEquals(_.DataType, itemType));
        }
    }
}
