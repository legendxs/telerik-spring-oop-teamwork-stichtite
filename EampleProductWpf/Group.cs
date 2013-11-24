using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ExampleProductWpf
{
    public class Group : ICloneable
    {
        public string GroupName { get; set; }
        public Image Picture { get; set; }

        public Group(string groupName, Image picture = null)
        {
            if (picture == null)
            {
                var defaultPicture = (Image)Application.Current.FindResource("GroupImage");
                this.Picture = CloneImage(defaultPicture);
            }
            else
            {
                this.Picture = picture;
            }
            this.GroupName = groupName;
        }

        public virtual object Clone()
        {
            return new Group(GroupName, CloneImage(Picture));
        }

        public virtual UIElement Render()
        {
            Button groupButton = CreateImageButton(this.Picture, this.GroupName);
            return groupButton;
        }

        public static Button CreateImageButton(Image icon, string productName)
        {
            var grid = new Grid();
            for (int i = 0; i < 2; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(col);
            }

            grid.Children.Add(icon);
            grid.Height = 52;

            var label = new Label();
            Grid.SetColumn(label, 1);
            label.Content = productName;
            label.FontWeight = FontWeights.Bold;
            label.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(label);

            Button groupButton = new Button();
            groupButton.Content = grid;
            return groupButton;
        }

        public static Image CloneImage(Image source)
        {
            Image cloned = null;
            string sourceXaml = XamlWriter.Save(source);
            if (sourceXaml != null)
            {
                StringReader stringReader = new StringReader(sourceXaml);
                System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(stringReader);
                cloned = (Image)XamlReader.Load(xmlReader);
            }
            return cloned;
        }
    }
}
