using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamCustomEntry.Shared;

[assembly: ExportRenderer(typeof(XamEntry), typeof(XamCustomEntry.iOS.XamEntryRenderer))]

namespace XamCustomEntry.iOS
{
    public class XamEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var view = (XamEntry)Element;

            if (view != null)
            {
                SetBorder(view);
                SetFont(view);
                SetFontFamily(view);
                SetMaxLength(view);
                SetTextAlignment(view);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || this.Element == null)
                return;

            var view = (XamEntry)Element;

            if (e.PropertyName == XamEntry.FontProperty.PropertyName)
                SetFont(view);

            if (e.PropertyName == XamEntry.FontFamilyProperty.PropertyName)
                SetFontFamily(view);

            if (e.PropertyName == XamEntry.HasBorderProperty.PropertyName)
                SetBorder(view);

            if (e.PropertyName == XamEntry.MaxLengthProperty.PropertyName)
                SetMaxLength(view);

            if (e.PropertyName == XamEntry.XAlignProperty.PropertyName)
                SetTextAlignment(view);
        }

        void SetFont(XamEntry view)
        {
            UIFont uiFont;
            if (view.Font != Font.Default && (uiFont = view.Font.ToUIFont()) != null)
                Control.Font = uiFont;
            else if (view.Font == Font.Default)
                Control.Font = UIFont.SystemFontOfSize(17f);
        }

        void SetFontFamily(XamEntry view)
        {
            UIFont uiFont;

            if (!string.IsNullOrWhiteSpace(view.FontFamily) && (uiFont = view.Font.ToUIFont()) != null)
            {
                var ui = UIFont.FromName(view.FontFamily, (nfloat)(view.Font != null ? view.Font.FontSize : 17f));
                Control.Font = uiFont;
            }
        }

        void SetMaxLength(XamEntry view)
        {
            Control.ShouldChangeCharacters = (textField, range, replacementString) =>
            {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= view.MaxLength;
            };
        }

        void SetBorder(XamEntry view)
        {
            Control.BorderStyle = view.HasBorder ? UITextBorderStyle.RoundedRect : UITextBorderStyle.None;
        }

        void SetTextAlignment(XamEntry view)
        {
            switch (view.XAlign)
            {
                case TextAlignment.Center:
                    Control.TextAlignment = UITextAlignment.Center;
                    break;
                case TextAlignment.End:
                    Control.TextAlignment = UITextAlignment.Right;
                    break;
                case TextAlignment.Start:
                    Control.TextAlignment = UITextAlignment.Left;
                    break;
            }
        }
    }
}