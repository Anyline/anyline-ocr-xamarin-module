using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace IO.Anyline.View
{

    // Metadata.xml XPath class reference: path="/api/package[@name='io.anyline.view']/class[@name='ScanViewPlugin']"
    //[global::Android.Runtime.Register("io/anyline/view/ScanViewPlugin", DoNotGenerateAcw = true)]
    //[global::Java.Interop.JavaTypeParameters(new string[] { "ResultType extends io.anyline.plugin.ScanResult" })]
    public partial class ScanViewPlugin : global::Java.Lang.Object
    {

        static Delegate cb_addScanResultListener_Lio_anyline_plugin_ScanResultListener_;
#pragma warning disable 0169
        static Delegate GetAddScanResultListener_Lio_anyline_plugin_ScanResultListener_Handler()
        {
            if (cb_addScanResultListener_Lio_anyline_plugin_ScanResultListener_ == null)
                cb_addScanResultListener_Lio_anyline_plugin_ScanResultListener_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_AddScanResultListener_Lio_anyline_plugin_ScanResultListener_);
            return cb_addScanResultListener_Lio_anyline_plugin_ScanResultListener_;
        }

        static void n_AddScanResultListener_Lio_anyline_plugin_ScanResultListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_scanResultListener)
        {
            global::IO.Anyline.View.ScanViewPlugin __this = global::Java.Lang.Object.GetObject<global::IO.Anyline.View.ScanViewPlugin>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::IO.Anyline.Plugin.IScanResultListener scanResultListener = (global::IO.Anyline.Plugin.IScanResultListener)global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.IScanResultListener>(native_scanResultListener, JniHandleOwnership.DoNotTransfer);
            __this.AddScanResultListener(scanResultListener);
        }
#pragma warning restore 0169

        // Metadata.xml XPath method reference: path="/api/package[@name='io.anyline.view']/class[@name='ScanViewPlugin']/method[@name='addScanResultListener' and count(parameter)=1 and parameter[1][@type='io.anyline.plugin.ScanResultListener&lt;ResultType&gt;']]"
        [Register("addScanResultListener", "(Lio/anyline/plugin/ScanResultListener;)V", "GetAddScanResultListener_Lio_anyline_plugin_ScanResultListener_Handler")]
        public virtual unsafe void AddScanResultListener(global::IO.Anyline.Plugin.IScanResultListener scanResultListener)
        {
            const string __id = "addScanResultListener.(Lio/anyline/plugin/ScanResultListener;)V";
            try
            {
                JniArgumentValue* __args = stackalloc JniArgumentValue[1];
                __args[0] = new JniArgumentValue((scanResultListener == null) ? IntPtr.Zero : ((global::Java.Lang.Object)scanResultListener).Handle);
                _members.InstanceMethods.InvokeVirtualVoidMethod(__id, this, __args);
            }
            finally
            {
            }
        }

    }
}