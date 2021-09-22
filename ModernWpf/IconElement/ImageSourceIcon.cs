using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ModernWpf.Controls
{
    public class ImageSourceIcon : IconElement
    {
        private Image _image;

        /// <summary>
        /// The identifier for the Glyph dependency property.
        /// </summary>
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register(
                nameof(ImageSource),
                typeof(ImageSource),
                typeof(ImageSourceIcon),
                new FrameworkPropertyMetadata(null, OnImageSourceChanged));

        /// <summary>
        /// Gets or sets the character code that identifies the icon glyph.
        /// </summary>
        /// <returns>The hexadecimal character code for the icon glyph.</returns>
        public ImageSource ImageSource
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        private static void OnImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var imageSourceIcon = (ImageSourceIcon)d;
            if (imageSourceIcon._image != null)
            {
                imageSourceIcon._image.Source = (ImageSource)e.NewValue;
            }
        }

        private protected override void InitializeChildren()
        {
            _image = new Image
            {
                Style = null,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                Width = Width,
                Height = Height,
                Source = ImageSource
            };

            Children.Add(_image);
        }
    }
}
