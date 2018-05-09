using System;
using System.Collections.Generic;
using Android.Runtime;

// TODO: Fix. This file is manually added and modified because the GenerateXMLData tool currently has an issue with the binding.

namespace AT.Nineyards.Anyline
{

    // Metadata.xml XPath class reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']"
    [global::Android.Runtime.Register("at/nineyards/anyline/AnylineController", DoNotGenerateAcw = true)]
    public partial class AnylineController : global::Java.Lang.Object
    {
        
        // Metadata.xml XPath field reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/field[@name='ANYLINE_OCR_MODULE_IDENTIFIER']"
        [Register("ANYLINE_OCR_MODULE_IDENTIFIER")]
        public const string AnylineOcrModuleIdentifier = (string)"ANYLINE_OCR";

        // Metadata.xml XPath field reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/field[@name='BARCODE_MODULE_IDENTIFIER']"
        [Register("BARCODE_MODULE_IDENTIFIER")]
        public const string BarcodeModuleIdentifier = (string)"BARCODE";

        // Metadata.xml XPath field reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/field[@name='DEBITCARD_MODULE_IDENTIFIER']"
        [Register("DEBITCARD_MODULE_IDENTIFIER")]
        public const string DebitcardModuleIdentifier = (string)"DEBITCARD";

        // Metadata.xml XPath field reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/field[@name='DOCUMENT_MODULE_IDENTIFIER']"
        [Register("DOCUMENT_MODULE_IDENTIFIER")]
        public const string DocumentModuleIdentifier = (string)"DOCUMENT";

        // Metadata.xml XPath field reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/field[@name='ENERGY_MODULE_IDENTIFIER']"
        [Register("ENERGY_MODULE_IDENTIFIER")]
        public const string EnergyModuleIdentifier = (string)"ENERGY";

        // Metadata.xml XPath field reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/field[@name='GENERIC_MODULE_IDENTIFIER']"
        [Register("GENERIC_MODULE_IDENTIFIER")]
        public const string GenericModuleIdentifier = (string)"GENERIC";

        // Metadata.xml XPath field reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/field[@name='LICENSE_PLATE_MODULE_IDENTIFIER']"
        [Register("LICENSE_PLATE_MODULE_IDENTIFIER")]
        public const string LicensePlateModuleIdentifier = (string)"LICENSE_PLATE";

        // Metadata.xml XPath field reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/field[@name='MRZ_MODULE_IDENTIFIER']"
        [Register("MRZ_MODULE_IDENTIFIER")]
        public const string MrzModuleIdentifier = (string)"MRZ";
        internal static new IntPtr java_class_handle;
        internal static new IntPtr class_ref
        {
            get
            {
                return JNIEnv.FindClass("at/nineyards/anyline/AnylineController", ref java_class_handle);
            }
        }

        protected override IntPtr ThresholdClass
        {
            get { return class_ref; }
        }

        protected override global::System.Type ThresholdType
        {
            get { return typeof(AnylineController); }
        }

        protected AnylineController(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

        static Delegate cb_isDebug;
#pragma warning disable 0169
        static Delegate GetIsDebugHandler()
        {
            if (cb_isDebug == null)
                cb_isDebug = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, bool>)n_IsDebug);
            return cb_isDebug;
        }

        static bool n_IsDebug(IntPtr jnienv, IntPtr native__this)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            return __this.Debug;
        }
#pragma warning restore 0169

        static Delegate cb_setDebug_Z;
#pragma warning disable 0169
        static Delegate GetSetDebug_ZHandler()
        {
            if (cb_setDebug_Z == null)
                cb_setDebug_Z = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, bool>)n_SetDebug_Z);
            return cb_setDebug_Z;
        }

        static void n_SetDebug_Z(IntPtr jnienv, IntPtr native__this, bool p0)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            __this.Debug = p0;
        }
#pragma warning restore 0169

        static IntPtr id_isDebug;
        static IntPtr id_setDebug_Z;
        public virtual unsafe bool Debug
        {
            // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='isDebug' and count(parameter)=0]"
            [Register("isDebug", "()Z", "GetIsDebugHandler")]
            get
            {
                if (id_isDebug == IntPtr.Zero)
                    id_isDebug = JNIEnv.GetMethodID(class_ref, "isDebug", "()Z");
                try
                {

                    if (((object)this).GetType() == ThresholdType)
                        return JNIEnv.CallBooleanMethod(((global::Java.Lang.Object)this).Handle, id_isDebug);
                    else
                        return JNIEnv.CallNonvirtualBooleanMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "isDebug", "()Z"));
                }
                finally
                {
                }
            }
            // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='setDebug' and count(parameter)=1 and parameter[1][@type='boolean']]"
            [Register("setDebug", "(Z)V", "GetSetDebug_ZHandler")]
            set
            {
                if (id_setDebug_Z == IntPtr.Zero)
                    id_setDebug_Z = JNIEnv.GetMethodID(class_ref, "setDebug", "(Z)V");
                try
                {
                    JValue* __args = stackalloc JValue[1];
                    __args[0] = new JValue(value);

                    if (((object)this).GetType() == ThresholdType)
                        JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setDebug_Z, __args);
                    else
                        JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setDebug", "(Z)V"), __args);
                }
                finally
                {
                }
            }
        }

        static Delegate cb_isRunning;
#pragma warning disable 0169
        static Delegate GetIsRunningHandler()
        {
            if (cb_isRunning == null)
                cb_isRunning = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, bool>)n_IsRunning);
            return cb_isRunning;
        }

        static bool n_IsRunning(IntPtr jnienv, IntPtr native__this)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            return __this.IsRunning;
        }
#pragma warning restore 0169

        static IntPtr id_isRunning;
        public virtual unsafe bool IsRunning
        {
            // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='isRunning' and count(parameter)=0]"
            [Register("isRunning", "()Z", "GetIsRunningHandler")]
            get
            {
                if (id_isRunning == IntPtr.Zero)
                    id_isRunning = JNIEnv.GetMethodID(class_ref, "isRunning", "()Z");
                try
                {

                    if (((object)this).GetType() == ThresholdType)
                        return JNIEnv.CallBooleanMethod(((global::Java.Lang.Object)this).Handle, id_isRunning);
                    else
                        return JNIEnv.CallNonvirtualBooleanMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "isRunning", "()Z"));
                }
                finally
                {
                }
            }
        }

        static Delegate cb_getLicenseKey;
#pragma warning disable 0169
        static Delegate GetGetLicenseKeyHandler()
        {
            if (cb_getLicenseKey == null)
                cb_getLicenseKey = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr>)n_GetLicenseKey);
            return cb_getLicenseKey;
        }

        static IntPtr n_GetLicenseKey(IntPtr jnienv, IntPtr native__this)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            return JNIEnv.NewString(__this.LicenseKey);
        }
#pragma warning restore 0169

        static IntPtr id_getLicenseKey;
        public virtual unsafe string LicenseKey
        {
            // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='getLicenseKey' and count(parameter)=0]"
            [Register("getLicenseKey", "()Ljava/lang/String;", "GetGetLicenseKeyHandler")]
            get
            {
                if (id_getLicenseKey == IntPtr.Zero)
                    id_getLicenseKey = JNIEnv.GetMethodID(class_ref, "getLicenseKey", "()Ljava/lang/String;");
                try
                {

                    if (((object)this).GetType() == ThresholdType)
                        return JNIEnv.GetString(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_getLicenseKey), JniHandleOwnership.TransferLocalRef);
                    else
                        return JNIEnv.GetString(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getLicenseKey", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
                }
                finally
                {
                }
            }
        }

        static Delegate cb_cancel;
#pragma warning disable 0169
        static Delegate GetCancelHandler()
        {
            if (cb_cancel == null)
                cb_cancel = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr>)n_Cancel);
            return cb_cancel;
        }

        static void n_Cancel(IntPtr jnienv, IntPtr native__this)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            __this.Cancel();
        }
#pragma warning restore 0169

        static IntPtr id_cancel;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='cancel' and count(parameter)=0]"
        [Register("cancel", "()V", "GetCancelHandler")]
        public virtual unsafe void Cancel()
        {
            if (id_cancel == IntPtr.Zero)
                id_cancel = JNIEnv.GetMethodID(class_ref, "cancel", "()V");
            try
            {

                if (((object)this).GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_cancel);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "cancel", "()V"));
            }
            finally
            {
            }
        }

        static IntPtr id_getLicenseExpirationDate_Ljava_lang_String_;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='getLicenseExpirationDate' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
        [Register("getLicenseExpirationDate", "(Ljava/lang/String;)Ljava/lang/String;", "")]
        public static unsafe string GetLicenseExpirationDate(string licenseKey)
        {
            if (id_getLicenseExpirationDate_Ljava_lang_String_ == IntPtr.Zero)
                id_getLicenseExpirationDate_Ljava_lang_String_ = JNIEnv.GetStaticMethodID(class_ref, "getLicenseExpirationDate", "(Ljava/lang/String;)Ljava/lang/String;");
            IntPtr native_p0 = JNIEnv.NewString(licenseKey);
            try
            {
                JValue* __args = stackalloc JValue[1];
                __args[0] = new JValue(native_p0);
                string __ret = JNIEnv.GetString(JNIEnv.CallStaticObjectMethod(class_ref, id_getLicenseExpirationDate_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
                return __ret;
            }
            finally
            {
                JNIEnv.DeleteLocalRef(native_p0);
            }
        }

        static Delegate cb_loadCmdFile_Ljava_lang_String_;
#pragma warning disable 0169
        static Delegate GetLoadCmdFile_Ljava_lang_String_Handler()
        {
            if (cb_loadCmdFile_Ljava_lang_String_ == null)
                cb_loadCmdFile_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_LoadCmdFile_Ljava_lang_String_);
            return cb_loadCmdFile_Ljava_lang_String_;
        }

        static void n_LoadCmdFile_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            string p0 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
            __this.LoadCmdFile(p0);
        }
#pragma warning restore 0169

        static IntPtr id_loadCmdFile_Ljava_lang_String_;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='loadCmdFile' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
        [Register("loadCmdFile", "(Ljava/lang/String;)V", "GetLoadCmdFile_Ljava_lang_String_Handler")]
        public virtual unsafe void LoadCmdFile(string cmdFileName)
        {
            if (id_loadCmdFile_Ljava_lang_String_ == IntPtr.Zero)
                id_loadCmdFile_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "loadCmdFile", "(Ljava/lang/String;)V");
            IntPtr native_p0 = JNIEnv.NewString(cmdFileName);
            try
            {
                JValue* __args = stackalloc JValue[1];
                __args[0] = new JValue(native_p0);

                if (((object)this).GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_loadCmdFile_Ljava_lang_String_, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "loadCmdFile", "(Ljava/lang/String;)V"), __args);
            }
            finally
            {
                JNIEnv.DeleteLocalRef(native_p0);
            }
        }

        static Delegate cb_loadCmdFile_Ljava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
        static Delegate GetLoadCmdFile_Ljava_lang_String_Ljava_lang_String_Handler()
        {
            if (cb_loadCmdFile_Ljava_lang_String_Ljava_lang_String_ == null)
                cb_loadCmdFile_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr, IntPtr>)n_LoadCmdFile_Ljava_lang_String_Ljava_lang_String_);
            return cb_loadCmdFile_Ljava_lang_String_Ljava_lang_String_;
        }

        static void n_LoadCmdFile_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            string p0 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
            string p1 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
            __this.LoadCmdFile(p0, p1);
        }
#pragma warning restore 0169

        static IntPtr id_loadCmdFile_Ljava_lang_String_Ljava_lang_String_;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='loadCmdFile' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String']]"
        [Register("loadCmdFile", "(Ljava/lang/String;Ljava/lang/String;)V", "GetLoadCmdFile_Ljava_lang_String_Ljava_lang_String_Handler")]
        public virtual unsafe void LoadCmdFile(string cmdFileName, string pathInAssets)
        {
            if (id_loadCmdFile_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
                id_loadCmdFile_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "loadCmdFile", "(Ljava/lang/String;Ljava/lang/String;)V");
            IntPtr native_p0 = JNIEnv.NewString(cmdFileName);
            IntPtr native_p1 = JNIEnv.NewString(pathInAssets);
            try
            {
                JValue* __args = stackalloc JValue[2];
                __args[0] = new JValue(native_p0);
                __args[1] = new JValue(native_p1);

                if (((object)this).GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_loadCmdFile_Ljava_lang_String_Ljava_lang_String_, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "loadCmdFile", "(Ljava/lang/String;Ljava/lang/String;)V"), __args);
            }
            finally
            {
                JNIEnv.DeleteLocalRef(native_p0);
                JNIEnv.DeleteLocalRef(native_p1);
            }
        }

        static Delegate cb_loadScript_Ljava_lang_String_;
#pragma warning disable 0169
        static Delegate GetLoadScript_Ljava_lang_String_Handler()
        {
            if (cb_loadScript_Ljava_lang_String_ == null)
                cb_loadScript_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_LoadScript_Ljava_lang_String_);
            return cb_loadScript_Ljava_lang_String_;
        }

        static void n_LoadScript_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            string p0 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
            __this.LoadScript(p0);
        }
#pragma warning restore 0169

        static IntPtr id_loadScript_Ljava_lang_String_;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='loadScript' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
        [Register("loadScript", "(Ljava/lang/String;)V", "GetLoadScript_Ljava_lang_String_Handler")]
        public virtual unsafe void LoadScript(string script)
        {
            if (id_loadScript_Ljava_lang_String_ == IntPtr.Zero)
                id_loadScript_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "loadScript", "(Ljava/lang/String;)V");
            IntPtr native_p0 = JNIEnv.NewString(script);
            try
            {
                JValue* __args = stackalloc JValue[1];
                __args[0] = new JValue(native_p0);

                if (((object)this).GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_loadScript_Ljava_lang_String_, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "loadScript", "(Ljava/lang/String;)V"), __args);
            }
            finally
            {
                JNIEnv.DeleteLocalRef(native_p0);
            }
        }

        static Delegate cb_loadScript_Ljava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
        static Delegate GetLoadScript_Ljava_lang_String_Ljava_lang_String_Handler()
        {
            if (cb_loadScript_Ljava_lang_String_Ljava_lang_String_ == null)
                cb_loadScript_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr, IntPtr>)n_LoadScript_Ljava_lang_String_Ljava_lang_String_);
            return cb_loadScript_Ljava_lang_String_Ljava_lang_String_;
        }

        static void n_LoadScript_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            string p0 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
            string p1 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
            __this.LoadScript(p0, p1);
        }
#pragma warning restore 0169

        static IntPtr id_loadScript_Ljava_lang_String_Ljava_lang_String_;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='loadScript' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String']]"
        [Register("loadScript", "(Ljava/lang/String;Ljava/lang/String;)V", "GetLoadScript_Ljava_lang_String_Ljava_lang_String_Handler")]
        public virtual unsafe void LoadScript(string script, string bundlePath)
        {
            if (id_loadScript_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
                id_loadScript_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "loadScript", "(Ljava/lang/String;Ljava/lang/String;)V");
            IntPtr native_p0 = JNIEnv.NewString(script);
            IntPtr native_p1 = JNIEnv.NewString(bundlePath);
            try
            {
                JValue* __args = stackalloc JValue[2];
                __args[0] = new JValue(native_p0);
                __args[1] = new JValue(native_p1);

                if (((object)this).GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_loadScript_Ljava_lang_String_Ljava_lang_String_, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "loadScript", "(Ljava/lang/String;Ljava/lang/String;)V"), __args);
            }
            finally
            {
                JNIEnv.DeleteLocalRef(native_p0);
                JNIEnv.DeleteLocalRef(native_p1);
            }
        }

        static Delegate cb_loadScript_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
        static Delegate GetLoadScript_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler()
        {
            if (cb_loadScript_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == null)
                cb_loadScript_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>)n_LoadScript_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_);
            return cb_loadScript_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
        }

        static void n_LoadScript_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            string p0 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
            string p1 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
            string p2 = JNIEnv.GetString(native_p2, JniHandleOwnership.DoNotTransfer);
            __this.LoadScript(p0, p1, p2);
        }
#pragma warning restore 0169

        static IntPtr id_loadScript_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='loadScript' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String']]"
        [Register("loadScript", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "GetLoadScript_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler")]
        public virtual unsafe void LoadScript(string scriptName, string script, string bundlePath)
        {
            if (id_loadScript_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
                id_loadScript_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "loadScript", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V");
            IntPtr native_p0 = JNIEnv.NewString(scriptName);
            IntPtr native_p1 = JNIEnv.NewString(script);
            IntPtr native_p2 = JNIEnv.NewString(bundlePath);
            try
            {
                JValue* __args = stackalloc JValue[3];
                __args[0] = new JValue(native_p0);
                __args[1] = new JValue(native_p1);
                __args[2] = new JValue(native_p2);

                if (((object)this).GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_loadScript_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "loadScript", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V"), __args);
            }
            finally
            {
                JNIEnv.DeleteLocalRef(native_p0);
                JNIEnv.DeleteLocalRef(native_p1);
                JNIEnv.DeleteLocalRef(native_p2);
            }
        }

        static Delegate cb_reportIncludeValues_Ljava_lang_String_;
#pragma warning disable 0169
        static Delegate GetReportIncludeValues_Ljava_lang_String_Handler()
        {
            if (cb_reportIncludeValues_Ljava_lang_String_ == null)
                cb_reportIncludeValues_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_ReportIncludeValues_Ljava_lang_String_);
            return cb_reportIncludeValues_Ljava_lang_String_;
        }

        static void n_ReportIncludeValues_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            string p0 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
            __this.ReportIncludeValues(p0);
        }
#pragma warning restore 0169

        static IntPtr id_reportIncludeValues_Ljava_lang_String_;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='reportIncludeValues' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
        [Register("reportIncludeValues", "(Ljava/lang/String;)V", "GetReportIncludeValues_Ljava_lang_String_Handler")]
        public virtual unsafe void ReportIncludeValues(string jsonString)
        {
            if (id_reportIncludeValues_Ljava_lang_String_ == IntPtr.Zero)
                id_reportIncludeValues_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "reportIncludeValues", "(Ljava/lang/String;)V");
            IntPtr native_p0 = JNIEnv.NewString(jsonString);
            try
            {
                JValue* __args = stackalloc JValue[1];
                __args[0] = new JValue(native_p0);

                if (((object)this).GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_reportIncludeValues_Ljava_lang_String_, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "reportIncludeValues", "(Ljava/lang/String;)V"), __args);
            }
            finally
            {
                JNIEnv.DeleteLocalRef(native_p0);
            }
        }

        static Delegate cb_reportTriggerScanningCanceled;
#pragma warning disable 0169
        static Delegate GetReportTriggerScanningCanceledHandler()
        {
            if (cb_reportTriggerScanningCanceled == null)
                cb_reportTriggerScanningCanceled = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr>)n_ReportTriggerScanningCanceled);
            return cb_reportTriggerScanningCanceled;
        }

        static void n_ReportTriggerScanningCanceled(IntPtr jnienv, IntPtr native__this)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            __this.ReportTriggerScanningCanceled();
        }
#pragma warning restore 0169

        static IntPtr id_reportTriggerScanningCanceled;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='reportTriggerScanningCanceled' and count(parameter)=0]"
        [Register("reportTriggerScanningCanceled", "()V", "GetReportTriggerScanningCanceledHandler")]
        public virtual unsafe void ReportTriggerScanningCanceled()
        {
            if (id_reportTriggerScanningCanceled == IntPtr.Zero)
                id_reportTriggerScanningCanceled = JNIEnv.GetMethodID(class_ref, "reportTriggerScanningCanceled", "()V");
            try
            {

                if (((object)this).GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_reportTriggerScanningCanceled);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "reportTriggerScanningCanceled", "()V"));
            }
            finally
            {
            }
        }

        static Delegate cb_setAssetJsonPaths_arrayLjava_lang_String_;
#pragma warning disable 0169
        static Delegate GetSetAssetJsonPaths_arrayLjava_lang_String_Handler()
        {
            if (cb_setAssetJsonPaths_arrayLjava_lang_String_ == null)
                cb_setAssetJsonPaths_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_SetAssetJsonPaths_arrayLjava_lang_String_);
            return cb_setAssetJsonPaths_arrayLjava_lang_String_;
        }

        static void n_SetAssetJsonPaths_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            string[] p0 = (string[])JNIEnv.GetArray(native_p0, JniHandleOwnership.DoNotTransfer, typeof(string));
            __this.SetAssetJsonPaths(p0);
            if (p0 != null)
                JNIEnv.CopyArray(p0, native_p0);
        }
#pragma warning restore 0169

        static IntPtr id_setAssetJsonPaths_arrayLjava_lang_String_;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='setAssetJsonPaths' and count(parameter)=1 and parameter[1][@type='java.lang.String...']]"
        [Register("setAssetJsonPaths", "([Ljava/lang/String;)V", "GetSetAssetJsonPaths_arrayLjava_lang_String_Handler")]
        public virtual unsafe void SetAssetJsonPaths(params string[] assetJsonPaths)
        {
            if (id_setAssetJsonPaths_arrayLjava_lang_String_ == IntPtr.Zero)
                id_setAssetJsonPaths_arrayLjava_lang_String_ = JNIEnv.GetMethodID(class_ref, "setAssetJsonPaths", "([Ljava/lang/String;)V");
            IntPtr native_p0 = JNIEnv.NewArray(assetJsonPaths);
            try
            {
                JValue* __args = stackalloc JValue[1];
                __args[0] = new JValue(native_p0);

                if (((object)this).GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setAssetJsonPaths_arrayLjava_lang_String_, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setAssetJsonPaths", "([Ljava/lang/String;)V"), __args);
            }
            finally
            {
                if (assetJsonPaths != null)
                {
                    JNIEnv.CopyArray(native_p0, assetJsonPaths);
                    JNIEnv.DeleteLocalRef(native_p0);
                }
            }
        }

        static Delegate cb_setCancelOnResult_Z;
#pragma warning disable 0169
        static Delegate GetSetCancelOnResult_ZHandler()
        {
            if (cb_setCancelOnResult_Z == null)
                cb_setCancelOnResult_Z = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, bool>)n_SetCancelOnResult_Z);
            return cb_setCancelOnResult_Z;
        }

        static void n_SetCancelOnResult_Z(IntPtr jnienv, IntPtr native__this, bool p0)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            __this.SetCancelOnResult(p0);
        }
#pragma warning restore 0169

        static IntPtr id_setCancelOnResult_Z;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='setCancelOnResult' and count(parameter)=1 and parameter[1][@type='boolean']]"
        [Register("setCancelOnResult", "(Z)V", "GetSetCancelOnResult_ZHandler")]
        public virtual unsafe void SetCancelOnResult(bool isCancelOnResult)
        {
            if (id_setCancelOnResult_Z == IntPtr.Zero)
                id_setCancelOnResult_Z = JNIEnv.GetMethodID(class_ref, "setCancelOnResult", "(Z)V");
            try
            {
                JValue* __args = stackalloc JValue[1];
                __args[0] = new JValue(isCancelOnResult);

                if (((object)this).GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setCancelOnResult_Z, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setCancelOnResult", "(Z)V"), __args);
            }
            finally
            {
            }
        }

        static Delegate cb_setImageProvider_Lat_nineyards_anyline_ImageProvider_;
#pragma warning disable 0169
        static Delegate GetSetImageProvider_Lat_nineyards_anyline_ImageProvider_Handler()
        {
            if (cb_setImageProvider_Lat_nineyards_anyline_ImageProvider_ == null)
                cb_setImageProvider_Lat_nineyards_anyline_ImageProvider_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_SetImageProvider_Lat_nineyards_anyline_ImageProvider_);
            return cb_setImageProvider_Lat_nineyards_anyline_ImageProvider_;
        }

        static void n_SetImageProvider_Lat_nineyards_anyline_ImageProvider_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::AT.Nineyards.Anyline.IImageProvider p0 = (global::AT.Nineyards.Anyline.IImageProvider)global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.IImageProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
            __this.SetImageProvider(p0);
        }
#pragma warning restore 0169

        static IntPtr id_setImageProvider_Lat_nineyards_anyline_ImageProvider_;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='setImageProvider' and count(parameter)=1 and parameter[1][@type='at.nineyards.anyline.ImageProvider']]"
        [Register("setImageProvider", "(Lat/nineyards/anyline/ImageProvider;)V", "GetSetImageProvider_Lat_nineyards_anyline_ImageProvider_Handler")]
        public virtual unsafe void SetImageProvider(global::AT.Nineyards.Anyline.IImageProvider imageProvider)
        {
            if (id_setImageProvider_Lat_nineyards_anyline_ImageProvider_ == IntPtr.Zero)
                id_setImageProvider_Lat_nineyards_anyline_ImageProvider_ = JNIEnv.GetMethodID(class_ref, "setImageProvider", "(Lat/nineyards/anyline/ImageProvider;)V");
            try
            {
                JValue* __args = stackalloc JValue[1];
                __args[0] = new JValue(imageProvider);

                if (((object)this).GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setImageProvider_Lat_nineyards_anyline_ImageProvider_, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setImageProvider", "(Lat/nineyards/anyline/ImageProvider;)V"), __args);
            }
            finally
            {
            }
        }

        static Delegate cb_setReportingEnabled_Z;
#pragma warning disable 0169
        static Delegate GetSetReportingEnabled_ZHandler()
        {
            if (cb_setReportingEnabled_Z == null)
                cb_setReportingEnabled_Z = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, bool>)n_SetReportingEnabled_Z);
            return cb_setReportingEnabled_Z;
        }

        static void n_SetReportingEnabled_Z(IntPtr jnienv, IntPtr native__this, bool p0)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            __this.SetReportingEnabled(p0);
        }
#pragma warning restore 0169

        static IntPtr id_setReportingEnabled_Z;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='setReportingEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
        [Register("setReportingEnabled", "(Z)V", "GetSetReportingEnabled_ZHandler")]
        public virtual unsafe void SetReportingEnabled(bool isReportingEnabled)
        {
            if (id_setReportingEnabled_Z == IntPtr.Zero)
                id_setReportingEnabled_Z = JNIEnv.GetMethodID(class_ref, "setReportingEnabled", "(Z)V");
            try
            {
                JValue* __args = stackalloc JValue[1];
                __args[0] = new JValue(isReportingEnabled);

                if (((object)this).GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setReportingEnabled_Z, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setReportingEnabled", "(Z)V"), __args);
            }
            finally
            {
            }
        }

        static Delegate cb_setStartVariable_Ljava_lang_String_Ljava_lang_Object_;
#pragma warning disable 0169
        static Delegate GetSetStartVariable_Ljava_lang_String_Ljava_lang_Object_Handler()
        {
            if (cb_setStartVariable_Ljava_lang_String_Ljava_lang_Object_ == null)
                cb_setStartVariable_Ljava_lang_String_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr, IntPtr>)n_SetStartVariable_Ljava_lang_String_Ljava_lang_Object_);
            return cb_setStartVariable_Ljava_lang_String_Ljava_lang_Object_;
        }

        static void n_SetStartVariable_Ljava_lang_String_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            string p0 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
            global::Java.Lang.Object p1 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
            __this.SetStartVariable(p0, p1);
        }
#pragma warning restore 0169

        static IntPtr id_setStartVariable_Ljava_lang_String_Ljava_lang_Object_;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='setStartVariable' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.Object']]"
        [Register("setStartVariable", "(Ljava/lang/String;Ljava/lang/Object;)V", "GetSetStartVariable_Ljava_lang_String_Ljava_lang_Object_Handler")]
        public virtual unsafe void SetStartVariable(string p0, global::Java.Lang.Object p1)
        {
            if (id_setStartVariable_Ljava_lang_String_Ljava_lang_Object_ == IntPtr.Zero)
                id_setStartVariable_Ljava_lang_String_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "setStartVariable", "(Ljava/lang/String;Ljava/lang/Object;)V");
            IntPtr native_p0 = JNIEnv.NewString(p0);
            try
            {
                JValue* __args = stackalloc JValue[2];
                __args[0] = new JValue(native_p0);
                __args[1] = new JValue(p1);

                if (((object)this).GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setStartVariable_Ljava_lang_String_Ljava_lang_Object_, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setStartVariable", "(Ljava/lang/String;Ljava/lang/Object;)V"), __args);
            }
            finally
            {
                JNIEnv.DeleteLocalRef(native_p0);
            }
        }

        static Delegate cb_setWorkerThreadUncaughtExceptionHandler_Ljava_lang_Thread_UncaughtExceptionHandler_;
#pragma warning disable 0169
        static Delegate GetSetWorkerThreadUncaughtExceptionHandler_Ljava_lang_Thread_UncaughtExceptionHandler_Handler()
        {
            if (cb_setWorkerThreadUncaughtExceptionHandler_Ljava_lang_Thread_UncaughtExceptionHandler_ == null)
                cb_setWorkerThreadUncaughtExceptionHandler_Ljava_lang_Thread_UncaughtExceptionHandler_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_SetWorkerThreadUncaughtExceptionHandler_Ljava_lang_Thread_UncaughtExceptionHandler_);
            return cb_setWorkerThreadUncaughtExceptionHandler_Ljava_lang_Thread_UncaughtExceptionHandler_;
        }

        static void n_SetWorkerThreadUncaughtExceptionHandler_Ljava_lang_Thread_UncaughtExceptionHandler_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::Java.Lang.Thread.IUncaughtExceptionHandler p0 = (global::Java.Lang.Thread.IUncaughtExceptionHandler)global::Java.Lang.Object.GetObject<global::Java.Lang.Thread.IUncaughtExceptionHandler>(native_p0, JniHandleOwnership.DoNotTransfer);
            __this.SetWorkerThreadUncaughtExceptionHandler(p0);
        }
#pragma warning restore 0169

        static IntPtr id_setWorkerThreadUncaughtExceptionHandler_Ljava_lang_Thread_UncaughtExceptionHandler_;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='setWorkerThreadUncaughtExceptionHandler' and count(parameter)=1 and parameter[1][@type='java.lang.Thread.UncaughtExceptionHandler']]"
        [Register("setWorkerThreadUncaughtExceptionHandler", "(Ljava/lang/Thread$UncaughtExceptionHandler;)V", "GetSetWorkerThreadUncaughtExceptionHandler_Ljava_lang_Thread_UncaughtExceptionHandler_Handler")]
        public virtual unsafe void SetWorkerThreadUncaughtExceptionHandler(global::Java.Lang.Thread.IUncaughtExceptionHandler p0)
        {
            if (id_setWorkerThreadUncaughtExceptionHandler_Ljava_lang_Thread_UncaughtExceptionHandler_ == IntPtr.Zero)
                id_setWorkerThreadUncaughtExceptionHandler_Ljava_lang_Thread_UncaughtExceptionHandler_ = JNIEnv.GetMethodID(class_ref, "setWorkerThreadUncaughtExceptionHandler", "(Ljava/lang/Thread$UncaughtExceptionHandler;)V");
            try
            {
                JValue* __args = stackalloc JValue[1];
                __args[0] = new JValue(p0);

                if (((object)this).GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setWorkerThreadUncaughtExceptionHandler_Ljava_lang_Thread_UncaughtExceptionHandler_, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setWorkerThreadUncaughtExceptionHandler", "(Ljava/lang/Thread$UncaughtExceptionHandler;)V"), __args);
            }
            finally
            {
            }
        }

        static Delegate cb_start;
#pragma warning disable 0169
        static Delegate GetStartHandler()
        {
            if (cb_start == null)
                cb_start = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr>)n_Start);
            return cb_start;
        }

        static void n_Start(IntPtr jnienv, IntPtr native__this)
        {
            global::AT.Nineyards.Anyline.AnylineController __this = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.AnylineController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            __this.Start();
        }
#pragma warning restore 0169

        static IntPtr id_start;
        // Metadata.xml XPath method reference: path="/api/package[@name='at.nineyards.anyline']/class[@name='AnylineController']/method[@name='start' and count(parameter)=0]"
        [Register("start", "()V", "GetStartHandler")]
        public virtual unsafe void Start()
        {
            if (id_start == IntPtr.Zero)
                id_start = JNIEnv.GetMethodID(class_ref, "start", "()V");
            try
            {

                if (((object)this).GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_start);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "start", "()V"));
            }
            finally
            {
            }
        }

    }
}
