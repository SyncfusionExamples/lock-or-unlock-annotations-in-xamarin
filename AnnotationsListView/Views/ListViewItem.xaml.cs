using Syncfusion.SfPdfViewer.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnnotationsListView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewItem : ContentView
    {
        public ListViewItem()
        {
            InitializeComponent();
            BindingContextChanged += ListViewItem_BindingContextChanged;
        }

        private void ListViewItem_BindingContextChanged(object sender, EventArgs e)
        {
            if (BindingContext == null)
                return;

            bool isLocked = false;

            annotationFontIcon.FontFamily = FontMappingHelper.FontFamily;

            if (BindingContext is ShapeAnnotation shape)
            {
                isLocked = shape.Settings.IsLocked;
                annotationLabel.Text = shape.ShapeAnnotationType.ToString();
                if (shape.ShapeAnnotationType == ShapeAnnotationType.Line)
                {
                    annotationFontIcon.Text = FontMappingHelper.Line;
                }
                else if (shape.ShapeAnnotationType == ShapeAnnotationType.Rectangle)
                {
                    annotationFontIcon.Text = FontMappingHelper.Rectangle;
                }
                else if (shape.ShapeAnnotationType == ShapeAnnotationType.Circle)
                {
                    annotationFontIcon.Text = FontMappingHelper.Circle;
                }
                else if (shape.ShapeAnnotationType == ShapeAnnotationType.Arrow)
                {
                    annotationFontIcon.Text = FontMappingHelper.Arrow;
                }
                else if (shape.ShapeAnnotationType == ShapeAnnotationType.Polygon)
                {
                    annotationFontIcon.Text = FontMappingHelper.Polygon;
                }
            }
            else if (BindingContext is TextMarkupAnnotation textMarkup)
            {
                isLocked = textMarkup.Settings.IsLocked;
                annotationLabel.Text = textMarkup.TextMarkupAnnotationType.ToString();
                if (textMarkup.TextMarkupAnnotationType == TextMarkupAnnotationType.Highlight)
                {
                    annotationFontIcon.Text = FontMappingHelper.Highlight;
                }
                else if (textMarkup.TextMarkupAnnotationType == TextMarkupAnnotationType.Strikethrough)
                {
                    annotationFontIcon.Text = FontMappingHelper.StrikeThrough;
                }
                else if (textMarkup.TextMarkupAnnotationType == TextMarkupAnnotationType.Underline)
                {
                    annotationFontIcon.Text = FontMappingHelper.Underline;
                }
            }
            else if (BindingContext is FreeTextAnnotation freeText)
            {
                isLocked = freeText.Settings.IsLocked;
                annotationLabel.Text = "Free Text";
                annotationFontIcon.Text = FontMappingHelper.EditText;
            }
            else if (BindingContext is InkAnnotation ink)
            {
                isLocked = ink.Settings.IsLocked;
                annotationLabel.Text = "Ink";
                annotationFontIcon.Text = FontMappingHelper.Ink;
            }

            annotationLockedStatus.Source = isLocked ? ImageSource.FromResource("AnnotationsListView.Assets.Locked_Status.png")
                    : null;

            //else if (BindingContext is StampAnnotation stamp)
            //{
            //    annotationLabel.Text = $"{ToString(stamp)}";
            //    annotationFontIcon.FontFamily = FontMappingHelper.StampFont;
            //    annotationFontIcon.Text = FontMappingHelper.Stamp;
            //}
            //else if (BindingContext is HandwrittenSignature signature)
            //{
            //    annotationLabel.Text = $"{ToString(signature)}";
            //    annotationFontIcon.FontFamily = FontMappingHelper.SignatureFont;
            //    annotationFontIcon.Text = FontMappingHelper.Signature;
            //}
        }
    }
}