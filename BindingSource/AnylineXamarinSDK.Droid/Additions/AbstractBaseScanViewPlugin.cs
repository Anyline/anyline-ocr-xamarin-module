﻿//using System;
//using System.Collections.Generic;
//using Android.Runtime;
//using Java.Interop;

//namespace IO.Anyline.View
//{

//    // Metadata.xml XPath class reference: path="/api/package[@name='io.anyline.view']/class[@name='AbstractBaseScanViewPlugin']"
//    public abstract partial class AbstractBaseScanViewPlugin : global::Java.Lang.Object
//    {
//        static Delegate cb_addScanResultListener_Lio_anyline_plugin_ScanResultListener_;
//#pragma warning disable 0169
//        static Delegate GetAddScanResultListener_Lio_anyline_plugin_ScanResultListener_Handler()
//        {
//            if (cb_addScanResultListener_Lio_anyline_plugin_ScanResultListener_ == null)
//                cb_addScanResultListener_Lio_anyline_plugin_ScanResultListener_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_AddScanResultListener_Lio_anyline_plugin_ScanResultListener_);
//            return cb_addScanResultListener_Lio_anyline_plugin_ScanResultListener_;
//        }

//        static void n_AddScanResultListener_Lio_anyline_plugin_ScanResultListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//        {
//            global::IO.Anyline.View.AbstractBaseScanViewPlugin __this = global::Java.Lang.Object.GetObject<global::IO.Anyline.View.AbstractBaseScanViewPlugin>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            global::IO.Anyline.Plugin.IScanResultListener p0 = (global::IO.Anyline.Plugin.IScanResultListener)global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.IScanResultListener>(native_p0, JniHandleOwnership.DoNotTransfer);
//            __this.AddScanResultListener(p0);
//        }
//#pragma warning restore 0169

//        // Metadata.xml XPath method reference: path="/api/package[@name='io.anyline.view']/class[@name='AbstractBaseScanViewPlugin']/method[@name='addScanResultListener' and count(parameter)=1 and parameter[1][@type='io.anyline.plugin.ScanResultListener&lt;ResultType&gt;']]"
//        [Register("addScanResultListener", "(Lio/anyline/plugin/ScanResultListener;)V", "GetAddScanResultListener_Lio_anyline_plugin_ScanResultListener_Handler")]
//        public virtual void AddScanResultListener(global::IO.Anyline.Plugin.IScanResultListener scanResultListener) { }
        
//        static Delegate cb_removeScanResultListener_Lio_anyline_plugin_ScanResultListener_;
//#pragma warning disable 0169
//        static Delegate GetRemoveScanResultListener_Lio_anyline_plugin_ScanResultListener_Handler()
//        {
//            if (cb_removeScanResultListener_Lio_anyline_plugin_ScanResultListener_ == null)
//                cb_removeScanResultListener_Lio_anyline_plugin_ScanResultListener_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_RemoveScanResultListener_Lio_anyline_plugin_ScanResultListener_);
//            return cb_removeScanResultListener_Lio_anyline_plugin_ScanResultListener_;
//        }

//        static void n_RemoveScanResultListener_Lio_anyline_plugin_ScanResultListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//        {
//            global::IO.Anyline.View.AbstractBaseScanViewPlugin __this = global::Java.Lang.Object.GetObject<global::IO.Anyline.View.AbstractBaseScanViewPlugin>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            global::IO.Anyline.Plugin.IScanResultListener p0 = (global::IO.Anyline.Plugin.IScanResultListener)global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.IScanResultListener>(native_p0, JniHandleOwnership.DoNotTransfer);
//            __this.RemoveScanResultListener(p0);
//        }
//#pragma warning restore 0169

//        // Metadata.xml XPath method reference: path="/api/package[@name='io.anyline.view']/class[@name='AbstractBaseScanViewPlugin']/method[@name='removeScanResultListener' and count(parameter)=1 and parameter[1][@type='io.anyline.plugin.ScanResultListener&lt;ResultType&gt;']]"
//        [Register("removeScanResultListener", "(Lio/anyline/plugin/ScanResultListener;)V", "GetRemoveScanResultListener_Lio_anyline_plugin_ScanResultListener_Handler")]
//        public virtual void RemoveScanResultListener(global::IO.Anyline.Plugin.IScanResultListener scanResultListener) { }
        
//    }

//}
