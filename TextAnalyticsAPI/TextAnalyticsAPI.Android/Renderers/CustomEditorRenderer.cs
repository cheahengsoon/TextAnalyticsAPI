using System.ComponentModel;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using TextAnalyticsAPI.Custom;
using TextAnalyticsAPI.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]

namespace TextAnalyticsAPI.Droid.Renderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var nativeEditText = (global::Android.Widget.EditText) Control;
                var shape = new ShapeDrawable(new RectShape());
                shape.Paint.Color = Xamarin.Forms.Color.Transparent.ToAndroid();
                shape.Paint.StrokeWidth = 0;
                shape.Paint.SetStyle(Paint.Style.Stroke);
#pragma warning disable 618
                nativeEditText.SetBackgroundDrawable(shape);
#pragma warning restore 618

                var element = e.NewElement as CustomEditor;
                this.Control.Hint = element.Placeholder;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == CustomEditor.PlaceholderProperty.PropertyName)
            {
                var element = this.Element as CustomEditor;
                this.Control.Hint = element.Placeholder;
            }
        }
    }
}