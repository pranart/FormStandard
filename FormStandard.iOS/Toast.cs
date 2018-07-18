using System;
using NeatLibrary.iOS;
using CoreGraphics;
using System.Collections.Generic;
using UIKit;
using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(Toast))]
namespace NeatLibrary.iOS
{
    public class Toast : IToast
    {
        public Toast()
        {
        }

        void IToast.Toast(string message)
        {
            ToastIOS.Toast.MakeText(message).Show();
        }
    }
}


namespace ToastIOS
{
    public enum ToastGravity
    {
        Top = 1000001,
        Bottom,
        Center
    }
    public enum ToastDuration
    {
        Long = 10000,
        Short = 1000,
        Normal = 3000
    }
    public enum ToastType
    {
        Info = -100000,
        Notice,
        Warning,
        Error,
        None
    }
    public enum ToastImageLocation
    {
        Top,
        Left
    }
    public class ToastSetting : ICloneable
    {
        public nint duration;
        public ToastGravity gravity;
        public CGPoint position;
        public ToastType toastType;
        public nfloat fontSize;
        public bool useShadow = false;
        public nfloat cornerRadius;
        public nfloat bgRed;
        public nfloat bgGreen;
        public nfloat bgBlue;
        public nfloat bgAlpha;
        public nint offsetLeft;
        public nint offsetTop;
        public ToastImageLocation imageLocation;

        public Dictionary<int, UIImage> images = null;
        public bool positionIsSet = false;

        public static ToastSetting SharedSettings { get; set; }

        public void SetImage(UIImage img, ToastType type)
        {
            SetImage(img, ToastImageLocation.Left, type);
        }
        public void SetImage(UIImage img, ToastImageLocation location, ToastType type)
        {
            if (type == ToastType.None)
            {
                return;
            }
            images = images ?? new Dictionary<int, UIImage>();
            if (img != null)
            {
                images[(int)type] = img;
            }
            imageLocation = location;
        }
        public static void MakeNewSetting()
        {
            SharedSettings = null;
        }
        public static ToastSetting GetSharedSettings()
        {
            if (SharedSettings == null)
            {
                SharedSettings = new ToastSetting();
                SharedSettings.gravity = ToastGravity.Bottom;
                SharedSettings.duration = (nint)(int)ToastDuration.Short;
                SharedSettings.fontSize = 16.0f;
                SharedSettings.useShadow = true;
                SharedSettings.cornerRadius = 5.0f;
                SharedSettings.bgRed = 0;
                SharedSettings.bgGreen = 0;
                SharedSettings.bgBlue = 0;
                SharedSettings.bgAlpha = 0.7f;
                SharedSettings.offsetLeft = 0;
                SharedSettings.offsetTop = 0;

                SharedSettings.imageLocation = ToastImageLocation.Left;

                SharedSettings.images = new Dictionary<int, UIImage>();
                SharedSettings.images[(int)ToastType.Error] = UIImage.FromBundle("error.png");
                SharedSettings.images[(int)ToastType.Info] = UIImage.FromBundle("info.png");
                SharedSettings.images[(int)ToastType.None] = null;
                SharedSettings.images[(int)ToastType.Notice] = UIImage.FromBundle("notice.png");
                SharedSettings.images[(int)ToastType.Warning] = UIImage.FromBundle("warning.png");

                return SharedSettings;
            }
            return SharedSettings;
        }

        public object Clone()
        {
            var cloner = new ToastSetting();
            cloner.gravity = this.gravity;
            cloner.duration = this.duration;
            cloner.position = this.position;
            cloner.fontSize = this.fontSize;
            cloner.useShadow = this.useShadow;
            cloner.cornerRadius = this.cornerRadius;
            cloner.bgRed = this.bgRed;
            cloner.bgGreen = this.bgGreen;
            cloner.bgBlue = this.bgBlue;
            cloner.bgAlpha = this.bgAlpha;
            cloner.offsetLeft = this.offsetLeft;
            cloner.offsetTop = this.offsetTop;

            cloner.imageLocation = this.imageLocation;

            cloner.images = new Dictionary<int, UIImage>();
            foreach (KeyValuePair<int, UIImage> eachPair in this.images)
            {
                cloner.images[eachPair.Key] = eachPair.Value;
            }
            return cloner;
        }
    }
    public class Toast
    {
        const long CURRENT_TOAST_TAG = 6984678;
        public nfloat kComponentPadding = 5;
        public const int LENGTH_SHORT = 2000;
        public const int LENGTH_LONG = 3500;

        public static ToastSetting settings;
        private string text;
        public UIView view;

        public Toast()
        {

        }
        public Toast(string itext)
        {
            text = itext;
        }
        public void Show()
        {
            Show(ToastType.None);
        }
        public void Show(ToastType type)
        {
            nint times = 0;
            times = NSUserDefaults.StandardUserDefaults.IntForKey("ToastIOSTestPackageUsed");
            if (times > 40)
            {
                this.text = "Trial Package can be used only 40 times";
                this.SetFontSize(14);
            }
            times++;
            NSUserDefaults.StandardUserDefaults.SetInt(times, "ToastIOSTestPackageUsed");
            UIImage image = theSettings().images[(int)type];
            UIFont font = UIFont.SystemFontOfSize(theSettings().fontSize);
            NSAttributedString attrText = new NSAttributedString(text, font);
            CGRect rect = attrText.GetBoundingRect(new CGSize(260, 60), NSStringDrawingOptions.UsesLineFragmentOrigin, null);
            CGSize textSize = rect.Size;
            textSize.Width += 5;
            UILabel label = new UILabel(new CGRect(0, 0, textSize.Width + kComponentPadding, textSize.Height + kComponentPadding));
            label.BackgroundColor = UIColor.Clear;
            label.TextColor = UIColor.White;
            label.TextAlignment = UITextAlignment.Center;
            label.Text = text;
            label.Lines = 0;
            label.Font = UIFont.SystemFontOfSize(theSettings().fontSize);
            if (theSettings().useShadow)
            {
                label.ShadowColor = UIColor.DarkGray;
                label.ShadowOffset = new CGSize(1, 1);
            }
            UIButton v = new UIButton(UIButtonType.Custom);
            if (image != null)
            {
                v.Frame = ToastFrameForImageSize(image.Size, theSettings().imageLocation, textSize);
                switch (theSettings().imageLocation)
                {
                    case ToastImageLocation.Left:
                        label.TextAlignment = UITextAlignment.Left;
                        label.Center =
                            new CGPoint(
                            image.Size.Width + kComponentPadding * 2 + (v.Frame.Size.Width - image.Size.Width - kComponentPadding * 2) / 2,
                            v.Frame.Size.Height / 2);
                        break;
                    case ToastImageLocation.Top:
                        label.TextAlignment = UITextAlignment.Center;
                        label.Center =
                            new CGPoint(
                            v.Frame.Size.Width / 2,
                            (image.Size.Height + kComponentPadding * 2 + (v.Frame.Size.Height - image.Size.Height - kComponentPadding * 2) / 2));
                        break;
                    default:
                        break;
                }
            }
            else
            {
                v.Frame = new CGRect(0, 0, textSize.Width + kComponentPadding * 2, textSize.Height + kComponentPadding * 2);
                label.Center = new CGPoint(v.Frame.Size.Width / 2, v.Frame.Size.Height / 2);
            }
            CGRect lbfrm = label.Frame;
            lbfrm.X = (nfloat)Math.Ceiling(lbfrm.X);
            lbfrm.Y = (nfloat)Math.Ceiling(lbfrm.Y);
            label.Frame = lbfrm;
            v.AddSubview(label);
            if (image != null)
            {
                UIImageView imageView = new UIImageView(image);
                imageView.Frame = FrameForImage(type, v.Frame);
                v.AddSubview(imageView);
            }
            v.BackgroundColor = UIColor.FromRGBA(theSettings().bgRed, theSettings().bgGreen, theSettings().bgBlue, theSettings().bgAlpha);
            v.Layer.CornerRadius = theSettings().cornerRadius;

            UIWindow window = UIApplication.SharedApplication.Windows[0];
            CGPoint point = CGPoint.Empty;

            UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;
            switch (orientation)
            {//LATER
                case UIInterfaceOrientation.Portrait:
                    {
                        switch (theSettings().gravity)
                        {
                            case ToastGravity.Top:
                                point = new CGPoint(window.Frame.Size.Width / 2, 45);
                                break;
                            case ToastGravity.Bottom:
                                point = new CGPoint(window.Frame.Size.Width / 2, window.Frame.Size.Height - 45);
                                break;
                            case ToastGravity.Center:
                                point = new CGPoint(window.Frame.Size.Width / 2, window.Frame.Size.Height / 2);
                                break;
                            default:
                                break;
                        }
                        point = new CGPoint(point.X + theSettings().offsetLeft, point.Y + theSettings().offsetTop);
                    }
                    break;
                case UIInterfaceOrientation.PortraitUpsideDown:
                    {
                        v.Transform = CGAffineTransform.MakeRotation((nfloat)Math.PI);

                        nfloat width = window.Frame.Size.Width;
                        nfloat height = window.Frame.Size.Height;

                        switch (theSettings().gravity)
                        {
                            case ToastGravity.Top:
                                point = new CGPoint(width / 2, height - 45);
                                break;
                            case ToastGravity.Bottom:
                                point = new CGPoint(width / 2, 45);
                                break;
                            case ToastGravity.Center:
                                point = new CGPoint(width / 2, height / 2);
                                break;
                            default:
                                point = theSettings().position;
                                break;
                        }
                        point = new CGPoint(point.X - theSettings().offsetLeft, point.Y - theSettings().offsetTop);
                    }
                    break;
                case UIInterfaceOrientation.LandscapeLeft:
                    {
                        v.Transform = CGAffineTransform.MakeRotation((nfloat)(Math.PI / 2.0));

                        switch (theSettings().gravity)
                        {
                            case ToastGravity.Top:
                                point = new CGPoint(window.Frame.Size.Width - 45, window.Frame.Size.Height / 2);
                                break;
                            case ToastGravity.Bottom:
                                point = new CGPoint(45, window.Frame.Size.Height / 2);
                                break;
                            case ToastGravity.Center:
                                point = new CGPoint(window.Frame.Size.Width / 2, window.Frame.Size.Height / 2);
                                break;
                            default:
                                point = theSettings().position;
                                break;
                        }
                        point = new CGPoint(point.X - theSettings().offsetTop, point.Y - theSettings().offsetLeft);
                    }
                    break;
                case UIInterfaceOrientation.LandscapeRight:
                    {
                        v.Transform = CGAffineTransform.MakeRotation((nfloat)(-Math.PI / 2));

                        switch (theSettings().gravity)
                        {
                            case ToastGravity.Top:
                                point = new CGPoint(45, window.Frame.Size.Height / 2);
                                break;
                            case ToastGravity.Bottom:
                                point = new CGPoint(window.Frame.Size.Width - 45, window.Frame.Size.Height / 2);
                                break;
                            case ToastGravity.Center:
                                point = new CGPoint(window.Frame.Size.Width / 2, window.Frame.Size.Height / 2);
                                break;
                            default:
                                point = new CGPoint(point.X + theSettings().offsetTop, point.Y + theSettings().offsetLeft);
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
            v.Center = point;
            v.Frame = v.Frame.Integral();
            NSTimer timer1 = NSTimer.CreateTimer(TimeSpan.FromSeconds(theSettings().duration / 1000.0),
                                 (timer) =>
                                 {
                                     HideToast();
                                 });
            NSRunLoop.Main.AddTimer(timer1, NSRunLoopMode.Default);
            v.Tag = (nint)CURRENT_TOAST_TAG;

            UIView currentToast = window.ViewWithTag((nint)CURRENT_TOAST_TAG);
            if (currentToast != null)
            {
                currentToast.RemoveFromSuperview();
            }

            v.Alpha = 0;
            window.AddSubview(v);
            UIView.BeginAnimations(null, IntPtr.Zero);
            v.Alpha = 1;
            UIView.CommitAnimations();

            view = v;

            v.AddTarget(HideToastEventHandler, UIControlEvent.TouchDown);
            ToastSetting.SharedSettings = null;
        }
        private CGRect ToastFrameForImageSize(CGSize imageSize, ToastImageLocation location, CGSize textSize)
        {
            CGRect theRect = CGRect.Empty;
            switch (location)
            {
                case ToastImageLocation.Left:
                    theRect = new CGRect(0.0f, 0.0f,
                    imageSize.Width + textSize.Width + kComponentPadding * 3,
                    (nfloat)Math.Max(textSize.Height, imageSize.Height) + kComponentPadding * 2);
                    break;
                case ToastImageLocation.Top:
                    theRect = new CGRect(0.0f, 0.0f,
                    (nfloat)Math.Max(textSize.Width, imageSize.Width) + kComponentPadding * 2,
                    imageSize.Height + textSize.Height + kComponentPadding * 3);
                    break;
                default:
                    break;
            }
            return theRect;
        }

        private CGRect FrameForImage(ToastType type, CGRect toastFrame)
        {
            UIImage image = theSettings().images[(int)type];
            if (image == null)
            {
                return CGRect.Empty;
            }
            CGRect imageFrame = CGRect.Empty;
            switch (theSettings().imageLocation)
            {
                case ToastImageLocation.Left:
                    imageFrame = new CGRect(
                        kComponentPadding, (toastFrame.Size.Height - image.Size.Height) / 2,
                        image.Size.Width, image.Size.Height);
                    break;
                case ToastImageLocation.Top:
                    imageFrame = new CGRect(
                        (toastFrame.Size.Width - image.Size.Width) / 2, kComponentPadding,
                        image.Size.Width, image.Size.Height);
                    break;
                default:
                    break;
            }
            return imageFrame;
        }
        private void HideToastEventHandler(object sender, EventArgs e)
        {
            HideToast();
        }
        private void HideToast()
        {
            UIView.BeginAnimations(null, IntPtr.Zero);
            view.Alpha = 0;
            UIView.CommitAnimations();

            NSTimer timer2 = NSTimer.CreateTimer(TimeSpan.FromSeconds(0.5), (timer) =>
            {
                HideToast();
            });
            NSRunLoop.Main.AddTimer(timer2, NSRunLoopMode.Default);
        }
        private void RemoveToast()
        {
            view.RemoveFromSuperview();
        }
        public Toast SetDuration(nint duration)
        {
            theSettings().duration = duration;
            return this;
        }
        public Toast SetType(ToastType type)
        {
            theSettings().toastType = type;
            return this;
        }
        public Toast SetGravity(ToastGravity gravity, nint left, nint top)
        {
            theSettings().gravity = gravity;
            theSettings().offsetLeft = left;
            theSettings().offsetTop = top;
            return this;
        }
        public Toast SetGravity(ToastGravity gravity)
        {
            theSettings().gravity = gravity;
            return this;
        }
        public Toast SetPosition(CGPoint position)
        {
            theSettings().position = position;
            return this;
        }
        public Toast SetFontSize(nfloat fontSize)
        {
            theSettings().fontSize = fontSize;
            return this;
        }
        public Toast SetUseShadow(bool useShadow)
        {
            theSettings().useShadow = useShadow;
            return this;
        }
        public Toast SetCornerRadius(nfloat cornerRadius)
        {
            theSettings().cornerRadius = cornerRadius;
            return this;
        }
        public Toast SetBgRed(nfloat bgRed)
        {
            theSettings().bgRed = bgRed;
            return this;
        }
        public Toast SetBgGreen(nfloat bgGreen)
        {
            theSettings().bgGreen = bgGreen;
            return this;
        }
        public Toast SetBgBlue(nfloat bgBlue)
        {
            theSettings().bgBlue = bgBlue;
            return this;
        }
        public Toast SetBgAlpha(nfloat bgAlpha)
        {
            theSettings().bgAlpha = bgAlpha;
            return this;
        }

        public static Toast MakeText(string text)
        {
            Toast newToast = new Toast(text);
            newToast.MakeNewSetting();
            return newToast;
        }
        public static Toast MakeText(string text, nint duration)
        {
            return (Toast.MakeText(text).SetDuration(duration));
        }
        public ToastSetting theSettings()
        {
            return ToastSetting.GetSharedSettings();
        }
        public void MakeNewSetting()
        {
            ToastSetting.MakeNewSetting();
        }

    }
}



