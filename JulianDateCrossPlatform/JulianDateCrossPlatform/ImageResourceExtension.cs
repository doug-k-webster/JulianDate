namespace JulianDateCrossPlatform
{
    using System;
    using System.Reflection;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this.Source == null)
            {
                return null;
            }

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(
                this.Source,
                typeof(ImageResourceExtension).GetTypeInfo()
                    .Assembly);

            return imageSource;
        }
    }
}