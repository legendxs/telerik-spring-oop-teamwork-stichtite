using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace StichtitePizzaForm.Products
{
    /// <summary>
    /// Product group
    /// </summary>
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

        //Used for storing data in files
        public virtual object Serialize()
        {
            //TODO implement it!
            var serializedForm = new StringBuilder();
            serializedForm.AppendFormat("{0}\n",GroupName);
            return serializedForm;
        }

        //Used for restoring the objects
        public virtual Group DeSerialize(object serializedForm)
        {
            //TODO implement it!
            throw new NotImplementedException();
        }

        //Creates button with icon
        protected static Button CreateImageButton(Image icon, string productName)
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

        // Clones the xaml UIelement. In this case - image
        protected static Image CloneImage(Image source)
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

        public static ProductListOld GetAllByGroup(string group, List<Group> products)
        {
            var result = new List<Group>();
            foreach (var item in products)
            {
                if (item.GroupName.Equals(group))
                {
                    result.Add(item);
                }
            }
            return new ProductListOld(result);
        }
    }
}
