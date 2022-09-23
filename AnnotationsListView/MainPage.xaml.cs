using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using Syncfusion.SfPdfViewer.XForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnnotationsListView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            lockStatusToolbar.IsVisible = false;
            listView.ItemsSourceChangeCachingStrategy = ItemsSourceChangeCachingStrategy.ClearItems;
            pdfViewer.ShapeAnnotationSelected += PdfViewer_AnnotationSelected;
            pdfViewer.ShapeAnnotationDeselected += PdfViewer_AnnotationDeselected;
            pdfViewer.TextMarkupSelected += PdfViewer_AnnotationSelected;
            pdfViewer.TextMarkupDeselected += PdfViewer_AnnotationDeselected;
            pdfViewer.FreeTextAnnotationSelected += PdfViewer_AnnotationSelected;
            pdfViewer.FreeTextAnnotationDeselected += PdfViewer_AnnotationDeselected;
            pdfViewer.InkSelected += PdfViewer_AnnotationSelected;
            pdfViewer.InkDeselected += PdfViewer_AnnotationDeselected;
            hamburgerButton.ImageSource = (FileImageSource)ImageSource.FromFile("hamburgericon.png");
        }

        private void PdfViewer_AnnotationDeselected(object sender, EventArgs args)
        {
            lockStatusToolbar.IsVisible = false;
        }

        private void PdfViewer_AnnotationSelected(object sender, EventArgs args)
        {
            DetermineLockStatus(sender as IAnnotation, false);
            lockStatusToolbar.IsVisible = true;
        }

        private void hamburgerButton_Clicked(object sender, EventArgs e)
        {
            if (listView.ItemsSource != null)
                listView.ItemsSource = null;

            listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "PageNumber",
                KeySelector = (object obj) =>
                {
                    var item = (obj as IAnnotation);
                    return "PAGE " + item.PageNumber;
                },
            });
            listView.ItemsSource = pdfViewer.Annotations;
            navigationDrawer.ToggleDrawer();
        }

        private void lockOrUnlockButton_Clicked(object sender, EventArgs e)
        {
            DetermineLockStatus(pdfViewer.SelectedAnnotation, true);
        }

        private void listView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            double x = 0;
            double y = 0;

            if (e.ItemType != Syncfusion.ListView.XForms.ItemType.GroupHeader)
            {
                pdfViewer.AnnotationMode = AnnotationMode.None;

                IAnnotation annotation = e.ItemData as IAnnotation;
                pdfViewer.SelectAnnotation(annotation);                

                if (annotation is ShapeAnnotation shape)
                {
                    x = shape.Bounds.X;
                    y = shape.Bounds.Y;
                }
                else if (annotation is TextMarkupAnnotation textMarkup)
                {
                    x = textMarkup.Bounds[0].X;
                    y = textMarkup.Bounds[0].Y;
                }
                else if (annotation is FreeTextAnnotation freeText)
                {
                    x = freeText.Bounds.X;
                    y = freeText.Bounds.Y;
                }
                else if (annotation is InkAnnotation ink)
                {
                    x = ink.Bounds.X;
                    y = ink.Bounds.Y;
                }

                DetermineLockStatus(annotation, false);

                var points = pdfViewer.ConvertPagePointToScrollPoint(new Point(x, y), annotation.PageNumber);
                pdfViewer.VerticalOffset = (float)points.Y - 30;

                navigationDrawer.ToggleDrawer();
            }

        }

        /// <summary>
        /// Determines the annotation's locked status and changes its status from locked to unlocked and vice versa.
        /// </summary>
        /// <param name="annotation">Selected annotation</param>
        /// <param name="changeLockStatus">Indicates whether the annotation's locked status has to be changed or not</param>
        private void DetermineLockStatus(IAnnotation annotation, bool changeLockStatus)
        {
            bool isLocked = false;

            if (annotation is ShapeAnnotation shape)
            {
                isLocked = shape.Settings.IsLocked;
                if (changeLockStatus)
                {
                    isLocked = shape.Settings.IsLocked = shape.Settings.IsLocked ? false : true;
                }
            }
            else if (annotation is TextMarkupAnnotation textMarkup)
            {
                isLocked = textMarkup.Settings.IsLocked;
                if (changeLockStatus)
                {
                    isLocked = textMarkup.Settings.IsLocked = textMarkup.Settings.IsLocked ? false : true;
                }
            }
            else if (annotation is FreeTextAnnotation freeText)
            {
                isLocked = freeText.Settings.IsLocked;
                if (changeLockStatus)
                {
                    isLocked = freeText.Settings.IsLocked = freeText.Settings.IsLocked ? false : true;
                }
            }
            else if (annotation is InkAnnotation ink)
            {
                isLocked = ink.Settings.IsLocked;
                if (changeLockStatus)
                {
                    isLocked = ink.Settings.IsLocked = ink.Settings.IsLocked ? false : true;
                }
            }

            lockOrUnlockImage.Source = isLocked ? ImageSource.FromResource("AnnotationsListView.Assets.Locked.png")
                : ImageSource.FromResource("AnnotationsListView.Assets.Unlocked.png");
            lockOrUnlockButton.Text = isLocked ? "UNLOCK" : "LOCK";
        }
    }
}