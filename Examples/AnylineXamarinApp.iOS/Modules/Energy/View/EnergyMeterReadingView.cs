using System;
using System.Collections.Generic;
using System.Diagnostics;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using UIKit;

namespace AnylineXamarinApp.iOS.Modules.Energy.View
{
    /*
     * Custom Label
     */
    class AnylineMeterLabel : UILabel
    {
        private int _cornerRadius;
        public AnylineMeterLabel()
        {
            CustomInit();
        }
        public AnylineMeterLabel(CGRect frame) : base(frame)
        {
            CustomInit();
        }
        private void CustomInit()
        {
            _cornerRadius = 3;
            TextColor = new UIColor(85.0f / 255f, 144f / 255f, 163f / 255f, 1f);
            BackgroundColor = UIColor.White;
            Font = UIFont.SystemFontOfSize(28);
            TextAlignment = UITextAlignment.Center;
        }

        public override void Draw(CGRect rect)
        {
 	        base.Draw(rect);
            Layer.CornerRadius = _cornerRadius;
        }     
    }

    /*
     * Energy Meter Reading View
     */

    sealed class EnergyMeterReadingView : UIView
    {
        const int KMeterLabelWidth = 30;
        const int KMeterLabelHeight = 45;

        const int KMeterLabelGap = 3;

        //const int KCommaWidth = 5;

        const int KUnitKwhWidth = 56;
        //const int KUnitM3Width = 28;

        List<AnylineMeterLabel> _digits;
        
        UILabel _unit;

        UIImageView _meterIcon;
        
        public EnergyMeterReadingView(CGRect frame) : base(frame)
        {
            if (Self != null)
            {
                Debug.Assert(frame.Size.Width > 300, @"View width should be 300px min");
                Debug.Assert(frame.Size.Height > 80, @"View height should be 80px min");
            }            
        }

        private void InitSubViews(int digitsCount)
        {
            _meterIcon = new UIImageView(new UIImage());
            _meterIcon.Center = new CGPoint(Frame.Size.Width / 2, Frame.Size.Height / 4);

            AddSubview(_meterIcon);

            nfloat digitYPosition = Frame.Size.Height / 2 + (Frame.Size.Height / 2 - KMeterLabelHeight) / 2;

            _unit = new UILabel(new CGRect(0, digitYPosition, KUnitKwhWidth, KMeterLabelHeight));
            _unit.TextColor = UIColor.White;            
            _unit.Font = UIFont.SystemFontOfSize(digitsCount == 1 ? 22 : 28);

            _digits = new List<AnylineMeterLabel>();

            for (int i = 0; i < digitsCount; i++)
                _digits.Add(new AnylineMeterLabel(new CGRect(0, digitYPosition, KMeterLabelWidth, KMeterLabelHeight)));
            
            foreach (var d in _digits)
                AddSubview(d);
            
            AddSubview(_unit);            
        }

        private void LayoutViewForDigits(int d)
        {
            nfloat offset = (Frame.Size.Width - (d * KMeterLabelWidth + KUnitKwhWidth + d * KMeterLabelGap)) / 2;
            
            for (int i = 0; i < _digits.Count; i++)
            {
                _digits[i].Frame = new CGRect(offset + (KMeterLabelWidth + KMeterLabelGap) * (i+1),
                    _digits[i].Frame.Y, _digits[i].Frame.Size.Width, _digits[i].Frame.Size.Height);
            }
            if (_unit.Text != "")
            {
                _unit.Frame = new CGRect(offset + (KMeterLabelWidth + KMeterLabelGap) * (_digits.Count + 1), _unit.Frame.Y,
                    _unit.Frame.Size.Width, _unit.Frame.Size.Height);
            }

            if (d == 1) // big frame for extra long results
            {
                _digits[0].Frame = new CGRect(KMeterLabelWidth * .5,
                    _digits[0].Frame.Y, Frame.Size.Width - KMeterLabelWidth, _digits[0].Frame.Size.Height);
            }
        }
        
        public void SetText(string text)
        {            
            if (text.Length <= 9)
            {
                InitSubViews(text.Length);

                for (int i = 0; i < text.Length; i++)
                    _digits[i].Text = text.Substring(i, 1);
                LayoutViewForDigits(text.Length);
            }
            else
            {
                InitSubViews(1);
                _digits[0].Text = text;
                LayoutViewForDigits(1);
            }
        }        
    }
}
