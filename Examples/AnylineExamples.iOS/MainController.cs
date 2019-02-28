using System;
using UIKit;

namespace AnylineExamples.iOS
{
	partial class MainController : UINavigationController
	{
		public MainController (IntPtr handle) : base (handle)
		{
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            return UIInterfaceOrientationMask.Portrait;
        }

        public override bool ShouldAutorotate()
        {
            return false;
        }
	}
}
