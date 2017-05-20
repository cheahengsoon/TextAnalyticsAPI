using System.ComponentModel;
using com.refractored.monodroidtoolkit;
using TextAnalyticsAPI.Custom;
using TextAnalyticsAPI.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PieChartsView), typeof(PieChartsRenderer))]

namespace TextAnalyticsAPI.Droid.Renderers
{
    /// <summary>
    /// CrossPieChart Renderer
    /// </summary>
    public class PieChartsRenderer : ViewRenderer<PieChartsView, HoloCircularProgressBar>
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<PieChartsView> e)
        {
            base.OnElementChanged(e);

            var progressBar = Element as PieChartsView;

            if (e.OldElement != null || progressBar == null)
            {
                return;
            }

            var progress = new HoloCircularProgressBar(Forms.Context)
            {
                Progress = progressBar.Progress,
                ProgressColor = progressBar.ProgressColor.ToAndroid(),
                ProgressBackgroundColor = progressBar.ProgressBackgroundColor.ToAndroid(),
                CircleStrokeWidth = progressBar.StrokeThickness,
            };

            //var display = Resources.DisplayMetrics;

            progressBar.HeightRequest = progressBar.Radius * 2;
            progressBar.WidthRequest = progressBar.Radius * 2;

            SetNativeControl(progress);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || Element == null)
                return;

            if (e.PropertyName == PieChartsView.ProgressProperty.PropertyName)
            {
                Control.Progress = Element.Progress;
            }
            else if (e.PropertyName == PieChartsView.ProgressBackgroundColorProperty.PropertyName)
            {
                Control.ProgressBackgroundColor = Element.ProgressBackgroundColor.ToAndroid();
            }
            else if (e.PropertyName == PieChartsView.ProgressColorProperty.PropertyName)
            {
                Control.ProgressColor = Element.ProgressColor.ToAndroid();
            }
            else if (e.PropertyName == PieChartsView.StrokeThicknessProperty.PropertyName)
            {
                Control.IndeterminateInterval = Element.StrokeThickness;
            }
            else if (e.PropertyName == PieChartsView.RadiusProperty.PropertyName)
            {
                Control.IndeterminateInterval = Element.Radius;
            }
        }
    }
}