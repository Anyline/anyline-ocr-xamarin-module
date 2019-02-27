using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AnylineExamples.Shared;

namespace AnylineExamples.Droid
{
    /// <summary>
    /// Wraps the Example Model because the ActivityListAdapter needs to work with Java.Lang.Object types
    /// </summary>
    public class AndroidExampleModelWrapper : Java.Lang.Object
    {
        public ExampleModel Model { get; private set; }

        public AndroidExampleModelWrapper(ExampleModel model)
        {
            Model = model;
        }
    }
}