using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace IO.Anyline.Plugin
{

    // Metadata.xml XPath interface reference: path="/api/package[@name='io.anyline.plugin']/interface[@name='ScanResultListener']"
    [Register("io/anyline/plugin/ScanResultListener", "", "IO.Anyline.Plugin.IScanResultListenerInvoker")]
    [global::Java.Interop.JavaTypeParameters(new string[] { "T extends io.anyline.plugin.ScanResult" })]
    public partial interface IScanResultListener : IJavaObject
    {

        // Metadata.xml XPath method reference: path="/api/package[@name='io.anyline.plugin']/interface[@name='ScanResultListener']/method[@name='onResult' and count(parameter)=1 and parameter[1][@type='T']]"
        [Register("onResult", "(Lio/anyline/plugin/ScanResult;)V", "GetOnResult_Lio_anyline_plugin_ScanResult_Handler:IO.Anyline.Plugin.IScanResultListenerInvoker, AnylineXamarinSDK.Droid")]
        void OnResult(global::IO.Anyline.Plugin.ScanResult result);

    }

    [global::Android.Runtime.Register("io/anyline/plugin/ScanResultListener", DoNotGenerateAcw = true)]
    internal class IScanResultListenerInvoker : global::Java.Lang.Object, IScanResultListener
    {

        internal new static readonly JniPeerMembers _members = new JniPeerMembers("io/anyline/plugin/ScanResultListener", typeof(IScanResultListenerInvoker));

        static IntPtr java_class_ref
        {
            get { return _members.JniPeerType.PeerReference.Handle; }
        }

        public override global::Java.Interop.JniPeerMembers JniPeerMembers
        {
            get { return _members; }
        }

        protected override IntPtr ThresholdClass
        {
            get { return class_ref; }
        }

        protected override global::System.Type ThresholdType
        {
            get { return _members.ManagedPeerType; }
        }

        IntPtr class_ref;

        public static IScanResultListener GetObject(IntPtr handle, JniHandleOwnership transfer)
        {
            return global::Java.Lang.Object.GetObject<IScanResultListener>(handle, transfer);
        }

        static IntPtr Validate(IntPtr handle)
        {
            if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
                throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.",
                            JNIEnv.GetClassNameFromInstance(handle), "io.anyline.plugin.ScanResultListener"));
            return handle;
        }

        protected override void Dispose(bool disposing)
        {
            if (this.class_ref != IntPtr.Zero)
                JNIEnv.DeleteGlobalRef(this.class_ref);
            this.class_ref = IntPtr.Zero;
            base.Dispose(disposing);
        }

        public IScanResultListenerInvoker(IntPtr handle, JniHandleOwnership transfer) : base(Validate(handle), transfer)
        {
            IntPtr local_ref = JNIEnv.GetObjectClass(((global::Java.Lang.Object)this).Handle);
            this.class_ref = JNIEnv.NewGlobalRef(local_ref);
            JNIEnv.DeleteLocalRef(local_ref);
        }

        static Delegate cb_onResult_Lio_anyline_plugin_ScanResult_;
#pragma warning disable 0169
        static Delegate GetOnResult_Lio_anyline_plugin_ScanResult_Handler()
        {
            if (cb_onResult_Lio_anyline_plugin_ScanResult_ == null)
                cb_onResult_Lio_anyline_plugin_ScanResult_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_OnResult_Lio_anyline_plugin_ScanResult_);
            return cb_onResult_Lio_anyline_plugin_ScanResult_;
        }

        static void n_OnResult_Lio_anyline_plugin_ScanResult_(IntPtr jnienv, IntPtr native__this, IntPtr native_result)
        {
            global::IO.Anyline.Plugin.IScanResultListener __this = global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.IScanResultListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            //global::Java.Lang.Object result = global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
            ScanResult result = global::Java.Lang.Object.GetObject<ScanResult>(native_result, JniHandleOwnership.DoNotTransfer);
            __this.OnResult(result);
        }
#pragma warning restore 0169

        IntPtr id_onResult_Lio_anyline_plugin_ScanResult_;
        public unsafe void OnResult(global::IO.Anyline.Plugin.ScanResult result)
        {
            if (id_onResult_Lio_anyline_plugin_ScanResult_ == IntPtr.Zero)
                id_onResult_Lio_anyline_plugin_ScanResult_ = JNIEnv.GetMethodID(class_ref, "onResult", "(Lio/anyline/plugin/ScanResult;)V");
            IntPtr native_result = JNIEnv.ToLocalJniHandle(result);
            JValue* __args = stackalloc JValue[1];
            __args[0] = new JValue(native_result);
            JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_onResult_Lio_anyline_plugin_ScanResult_, __args);
            JNIEnv.DeleteLocalRef(native_result);
        }

    }

    // event args for io.anyline.plugin.ScanResultListener.onResult
    public partial class ScanResultEventArgs : global::System.EventArgs
    {

        public ScanResultEventArgs(global::IO.Anyline.Plugin.ScanResult result)
        {
            this.result = result;
        }

        global::IO.Anyline.Plugin.ScanResult result;
        public global::IO.Anyline.Plugin.ScanResult Result
        {
            get { return result; }
        }
    }

    [global::Android.Runtime.Register("mono/io/anyline/plugin/ScanResultListenerImplementor")]
    internal sealed partial class IScanResultListenerImplementor : global::Java.Lang.Object, IScanResultListener
    {

        object sender;

        public IScanResultListenerImplementor(object sender)
            : base(
                global::Android.Runtime.JNIEnv.StartCreateInstance("mono/io/anyline/plugin/ScanResultListenerImplementor", "()V"),
                JniHandleOwnership.TransferLocalRef)
        {
            global::Android.Runtime.JNIEnv.FinishCreateInstance(((global::Java.Lang.Object)this).Handle, "()V");
            this.sender = sender;
        }

#pragma warning disable 0649
        public EventHandler<ScanResultEventArgs> Handler;
#pragma warning restore 0649

        public void OnResult(global::IO.Anyline.Plugin.ScanResult result)
        {
            var __h = Handler;
            if (__h != null)
                __h(sender, new ScanResultEventArgs(result));
        }

        internal static bool __IsEmpty(IScanResultListenerImplementor value)
        {
            return value.Handler == null;
        }
    }
}