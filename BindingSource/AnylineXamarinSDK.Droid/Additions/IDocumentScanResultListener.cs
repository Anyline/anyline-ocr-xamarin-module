using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace IO.Anyline.Plugin.Document
{

    // Metadata.xml XPath interface reference: path="/api/package[@name='io.anyline.plugin.document']/interface[@name='DocumentScanResultListener']"
    [Register("io/anyline/plugin/document/DocumentScanResultListener", "", "IO.Anyline.Plugin.Document.IDocumentScanResultListenerInvoker")]
    [global::Java.Interop.JavaTypeParameters(new string[] { "T extends io.anyline.plugin.ScanResult" })]
    public partial interface IDocumentScanResultListener : global::IO.Anyline.Plugin.IScanResultListener
    {

        // Metadata.xml XPath method reference: path="/api/package[@name='io.anyline.plugin.document']/interface[@name='DocumentScanResultListener']/method[@name='onDocumentOutlineDetected' and count(parameter)=2 and parameter[1][@type='java.util.List&lt;android.graphics.PointF&gt;'] and parameter[2][@type='boolean']]"
        [Register("onDocumentOutlineDetected", "(Ljava/util/List;Z)Z", "GetOnDocumentOutlineDetected_Ljava_util_List_ZHandler:IO.Anyline.Plugin.Document.IDocumentScanResultListenerInvoker, AnylineXamarinSDK.Droid")]
        bool OnDocumentOutlineDetected(global::System.Collections.Generic.IList<global::Android.Graphics.PointF> corners, bool documentShapeAndBrightnessValid);

        // Metadata.xml XPath method reference: path="/api/package[@name='io.anyline.plugin.document']/interface[@name='DocumentScanResultListener']/method[@name='onPictureCornersDetected' and count(parameter)=2 and parameter[1][@type='at.nineyards.anyline.models.AnylineImage'] and parameter[2][@type='java.util.List&lt;android.graphics.PointF&gt;']]"
        [Register("onPictureCornersDetected", "(Lat/nineyards/anyline/models/AnylineImage;Ljava/util/List;)V", "GetOnPictureCornersDetected_Lat_nineyards_anyline_models_AnylineImage_Ljava_util_List_Handler:IO.Anyline.Plugin.Document.IDocumentScanResultListenerInvoker, AnylineXamarinSDK.Droid")]
        void OnPictureCornersDetected(global::AT.Nineyards.Anyline.Models.AnylineImage fullFrame, global::System.Collections.Generic.IList<global::Android.Graphics.PointF> corners);

        // Metadata.xml XPath method reference: path="/api/package[@name='io.anyline.plugin.document']/interface[@name='DocumentScanResultListener']/method[@name='onPictureProcessingFailure' and count(parameter)=1 and parameter[1][@type='io.anyline.plugin.document.DocumentScanViewPlugin.DocumentError']]"
        [Register("onPictureProcessingFailure", "(Lio/anyline/plugin/document/DocumentScanViewPlugin$DocumentError;)V", "GetOnPictureProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_Handler:IO.Anyline.Plugin.Document.IDocumentScanResultListenerInvoker, AnylineXamarinSDK.Droid")]
        void OnPictureProcessingFailure(global::IO.Anyline.Plugin.Document.DocumentScanViewPlugin.DocumentError error);

        // Metadata.xml XPath method reference: path="/api/package[@name='io.anyline.plugin.document']/interface[@name='DocumentScanResultListener']/method[@name='onPictureTransformError' and count(parameter)=1 and parameter[1][@type='io.anyline.plugin.document.DocumentScanViewPlugin.DocumentError']]"
        [Register("onPictureTransformError", "(Lio/anyline/plugin/document/DocumentScanViewPlugin$DocumentError;)V", "GetOnPictureTransformError_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_Handler:IO.Anyline.Plugin.Document.IDocumentScanResultListenerInvoker, AnylineXamarinSDK.Droid")]
        void OnPictureTransformError(global::IO.Anyline.Plugin.Document.DocumentScanViewPlugin.DocumentError error);

        // Metadata.xml XPath method reference: path="/api/package[@name='io.anyline.plugin.document']/interface[@name='DocumentScanResultListener']/method[@name='onPictureTransformed' and count(parameter)=1 and parameter[1][@type='at.nineyards.anyline.models.AnylineImage']]"
        [Register("onPictureTransformed", "(Lat/nineyards/anyline/models/AnylineImage;)V", "GetOnPictureTransformed_Lat_nineyards_anyline_models_AnylineImage_Handler:IO.Anyline.Plugin.Document.IDocumentScanResultListenerInvoker, AnylineXamarinSDK.Droid")]
        void OnPictureTransformed(global::AT.Nineyards.Anyline.Models.AnylineImage transformedImage);

        // Metadata.xml XPath method reference: path="/api/package[@name='io.anyline.plugin.document']/interface[@name='DocumentScanResultListener']/method[@name='onPreviewProcessingFailure' and count(parameter)=1 and parameter[1][@type='io.anyline.plugin.document.DocumentScanViewPlugin.DocumentError']]"
        [Register("onPreviewProcessingFailure", "(Lio/anyline/plugin/document/DocumentScanViewPlugin$DocumentError;)V", "GetOnPreviewProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_Handler:IO.Anyline.Plugin.Document.IDocumentScanResultListenerInvoker, AnylineXamarinSDK.Droid")]
        void OnPreviewProcessingFailure(global::IO.Anyline.Plugin.Document.DocumentScanViewPlugin.DocumentError error);

        // Metadata.xml XPath method reference: path="/api/package[@name='io.anyline.plugin.document']/interface[@name='DocumentScanResultListener']/method[@name='onPreviewProcessingSuccess' and count(parameter)=1 and parameter[1][@type='at.nineyards.anyline.models.AnylineImage']]"
        [Register("onPreviewProcessingSuccess", "(Lat/nineyards/anyline/models/AnylineImage;)V", "GetOnPreviewProcessingSuccess_Lat_nineyards_anyline_models_AnylineImage_Handler:IO.Anyline.Plugin.Document.IDocumentScanResultListenerInvoker, AnylineXamarinSDK.Droid")]
        void OnPreviewProcessingSuccess(global::AT.Nineyards.Anyline.Models.AnylineImage anylineImage);

        // Metadata.xml XPath method reference: path="/api/package[@name='io.anyline.plugin.document']/interface[@name='DocumentScanResultListener']/method[@name='onTakePictureError' and count(parameter)=1 and parameter[1][@type='java.lang.Throwable']]"
        [Register("onTakePictureError", "(Ljava/lang/Throwable;)V", "GetOnTakePictureError_Ljava_lang_Throwable_Handler:IO.Anyline.Plugin.Document.IDocumentScanResultListenerInvoker, AnylineXamarinSDK.Droid")]
        void OnTakePictureError(global::Java.Lang.Throwable error);

        // Metadata.xml XPath method reference: path="/api/package[@name='io.anyline.plugin.document']/interface[@name='DocumentScanResultListener']/method[@name='onTakePictureSuccess' and count(parameter)=0]"
        [Register("onTakePictureSuccess", "()V", "GetOnTakePictureSuccessHandler:IO.Anyline.Plugin.Document.IDocumentScanResultListenerInvoker, AnylineXamarinSDK.Droid")]
        void OnTakePictureSuccess();

    }

    [global::Android.Runtime.Register("io/anyline/plugin/document/DocumentScanResultListener", DoNotGenerateAcw = true)]
    internal class IDocumentScanResultListenerInvoker : global::Java.Lang.Object, IDocumentScanResultListener
    {

        internal new static readonly JniPeerMembers _members = new JniPeerMembers("io/anyline/plugin/document/DocumentScanResultListener", typeof(IDocumentScanResultListenerInvoker));

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

        public static IDocumentScanResultListener GetObject(IntPtr handle, JniHandleOwnership transfer)
        {
            return global::Java.Lang.Object.GetObject<IDocumentScanResultListener>(handle, transfer);
        }

        static IntPtr Validate(IntPtr handle)
        {
            if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
                throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.",
                            JNIEnv.GetClassNameFromInstance(handle), "io.anyline.plugin.document.DocumentScanResultListener"));
            return handle;
        }

        protected override void Dispose(bool disposing)
        {
            if (this.class_ref != IntPtr.Zero)
                JNIEnv.DeleteGlobalRef(this.class_ref);
            this.class_ref = IntPtr.Zero;
            base.Dispose(disposing);
        }

        public IDocumentScanResultListenerInvoker(IntPtr handle, JniHandleOwnership transfer) : base(Validate(handle), transfer)
        {
            IntPtr local_ref = JNIEnv.GetObjectClass(((global::Java.Lang.Object)this).Handle);
            this.class_ref = JNIEnv.NewGlobalRef(local_ref);
            JNIEnv.DeleteLocalRef(local_ref);
        }

        static Delegate cb_onDocumentOutlineDetected_Ljava_util_List_Z;
#pragma warning disable 0169
        static Delegate GetOnDocumentOutlineDetected_Ljava_util_List_ZHandler()
        {
            if (cb_onDocumentOutlineDetected_Ljava_util_List_Z == null)
                cb_onDocumentOutlineDetected_Ljava_util_List_Z = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, bool, bool>)n_OnDocumentOutlineDetected_Ljava_util_List_Z);
            return cb_onDocumentOutlineDetected_Ljava_util_List_Z;
        }

        static bool n_OnDocumentOutlineDetected_Ljava_util_List_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_corners, bool documentShapeAndBrightnessValid)
        {
            global::IO.Anyline.Plugin.Document.IDocumentScanResultListener __this = global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.Document.IDocumentScanResultListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            var corners = global::Android.Runtime.JavaList<global::Android.Graphics.PointF>.FromJniHandle(native_corners, JniHandleOwnership.DoNotTransfer);
            bool __ret = __this.OnDocumentOutlineDetected(corners, documentShapeAndBrightnessValid);
            return __ret;
        }
#pragma warning restore 0169

        IntPtr id_onDocumentOutlineDetected_Ljava_util_List_Z;
        public unsafe bool OnDocumentOutlineDetected(global::System.Collections.Generic.IList<global::Android.Graphics.PointF> corners, bool documentShapeAndBrightnessValid)
        {
            if (id_onDocumentOutlineDetected_Ljava_util_List_Z == IntPtr.Zero)
                id_onDocumentOutlineDetected_Ljava_util_List_Z = JNIEnv.GetMethodID(class_ref, "onDocumentOutlineDetected", "(Ljava/util/List;Z)Z");
            IntPtr native_corners = global::Android.Runtime.JavaList<global::Android.Graphics.PointF>.ToLocalJniHandle(corners);
            JValue* __args = stackalloc JValue[2];
            __args[0] = new JValue(native_corners);
            __args[1] = new JValue(documentShapeAndBrightnessValid);
            bool __ret = JNIEnv.CallBooleanMethod(((global::Java.Lang.Object)this).Handle, id_onDocumentOutlineDetected_Ljava_util_List_Z, __args);
            JNIEnv.DeleteLocalRef(native_corners);
            return __ret;
        }

        static Delegate cb_onPictureCornersDetected_Lat_nineyards_anyline_models_AnylineImage_Ljava_util_List_;
#pragma warning disable 0169
        static Delegate GetOnPictureCornersDetected_Lat_nineyards_anyline_models_AnylineImage_Ljava_util_List_Handler()
        {
            if (cb_onPictureCornersDetected_Lat_nineyards_anyline_models_AnylineImage_Ljava_util_List_ == null)
                cb_onPictureCornersDetected_Lat_nineyards_anyline_models_AnylineImage_Ljava_util_List_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr, IntPtr>)n_OnPictureCornersDetected_Lat_nineyards_anyline_models_AnylineImage_Ljava_util_List_);
            return cb_onPictureCornersDetected_Lat_nineyards_anyline_models_AnylineImage_Ljava_util_List_;
        }

        static void n_OnPictureCornersDetected_Lat_nineyards_anyline_models_AnylineImage_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_fullFrame, IntPtr native_corners)
        {
            global::IO.Anyline.Plugin.Document.IDocumentScanResultListener __this = global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.Document.IDocumentScanResultListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::AT.Nineyards.Anyline.Models.AnylineImage fullFrame = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.Models.AnylineImage>(native_fullFrame, JniHandleOwnership.DoNotTransfer);
            var corners = global::Android.Runtime.JavaList<global::Android.Graphics.PointF>.FromJniHandle(native_corners, JniHandleOwnership.DoNotTransfer);
            __this.OnPictureCornersDetected(fullFrame, corners);
        }
#pragma warning restore 0169

        IntPtr id_onPictureCornersDetected_Lat_nineyards_anyline_models_AnylineImage_Ljava_util_List_;
        public unsafe void OnPictureCornersDetected(global::AT.Nineyards.Anyline.Models.AnylineImage fullFrame, global::System.Collections.Generic.IList<global::Android.Graphics.PointF> corners)
        {
            if (id_onPictureCornersDetected_Lat_nineyards_anyline_models_AnylineImage_Ljava_util_List_ == IntPtr.Zero)
                id_onPictureCornersDetected_Lat_nineyards_anyline_models_AnylineImage_Ljava_util_List_ = JNIEnv.GetMethodID(class_ref, "onPictureCornersDetected", "(Lat/nineyards/anyline/models/AnylineImage;Ljava/util/List;)V");
            IntPtr native_corners = global::Android.Runtime.JavaList<global::Android.Graphics.PointF>.ToLocalJniHandle(corners);
            JValue* __args = stackalloc JValue[2];
            __args[0] = new JValue((fullFrame == null) ? IntPtr.Zero : ((global::Java.Lang.Object)fullFrame).Handle);
            __args[1] = new JValue(native_corners);
            JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_onPictureCornersDetected_Lat_nineyards_anyline_models_AnylineImage_Ljava_util_List_, __args);
            JNIEnv.DeleteLocalRef(native_corners);
        }

        static Delegate cb_onPictureProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_;
#pragma warning disable 0169
        static Delegate GetOnPictureProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_Handler()
        {
            if (cb_onPictureProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_ == null)
                cb_onPictureProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_OnPictureProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_);
            return cb_onPictureProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_;
        }

        static void n_OnPictureProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_(IntPtr jnienv, IntPtr native__this, IntPtr native_error)
        {
            global::IO.Anyline.Plugin.Document.IDocumentScanResultListener __this = global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.Document.IDocumentScanResultListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::IO.Anyline.Plugin.Document.DocumentScanViewPlugin.DocumentError error = global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.Document.DocumentScanViewPlugin.DocumentError>(native_error, JniHandleOwnership.DoNotTransfer);
            __this.OnPictureProcessingFailure(error);
        }
#pragma warning restore 0169

        IntPtr id_onPictureProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_;
        public unsafe void OnPictureProcessingFailure(global::IO.Anyline.Plugin.Document.DocumentScanViewPlugin.DocumentError error)
        {
            if (id_onPictureProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_ == IntPtr.Zero)
                id_onPictureProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_ = JNIEnv.GetMethodID(class_ref, "onPictureProcessingFailure", "(Lio/anyline/plugin/document/DocumentScanViewPlugin$DocumentError;)V");
            JValue* __args = stackalloc JValue[1];
            __args[0] = new JValue((error == null) ? IntPtr.Zero : ((global::Java.Lang.Object)error).Handle);
            JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_onPictureProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_, __args);
        }

        static Delegate cb_onPictureTransformError_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_;
#pragma warning disable 0169
        static Delegate GetOnPictureTransformError_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_Handler()
        {
            if (cb_onPictureTransformError_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_ == null)
                cb_onPictureTransformError_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_OnPictureTransformError_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_);
            return cb_onPictureTransformError_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_;
        }

        static void n_OnPictureTransformError_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_(IntPtr jnienv, IntPtr native__this, IntPtr native_error)
        {
            global::IO.Anyline.Plugin.Document.IDocumentScanResultListener __this = global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.Document.IDocumentScanResultListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::IO.Anyline.Plugin.Document.DocumentScanViewPlugin.DocumentError error = global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.Document.DocumentScanViewPlugin.DocumentError>(native_error, JniHandleOwnership.DoNotTransfer);
            __this.OnPictureTransformError(error);
        }
#pragma warning restore 0169

        IntPtr id_onPictureTransformError_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_;
        public unsafe void OnPictureTransformError(global::IO.Anyline.Plugin.Document.DocumentScanViewPlugin.DocumentError error)
        {
            if (id_onPictureTransformError_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_ == IntPtr.Zero)
                id_onPictureTransformError_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_ = JNIEnv.GetMethodID(class_ref, "onPictureTransformError", "(Lio/anyline/plugin/document/DocumentScanViewPlugin$DocumentError;)V");
            JValue* __args = stackalloc JValue[1];
            __args[0] = new JValue((error == null) ? IntPtr.Zero : ((global::Java.Lang.Object)error).Handle);
            JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_onPictureTransformError_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_, __args);
        }

        static Delegate cb_onPictureTransformed_Lat_nineyards_anyline_models_AnylineImage_;
#pragma warning disable 0169
        static Delegate GetOnPictureTransformed_Lat_nineyards_anyline_models_AnylineImage_Handler()
        {
            if (cb_onPictureTransformed_Lat_nineyards_anyline_models_AnylineImage_ == null)
                cb_onPictureTransformed_Lat_nineyards_anyline_models_AnylineImage_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_OnPictureTransformed_Lat_nineyards_anyline_models_AnylineImage_);
            return cb_onPictureTransformed_Lat_nineyards_anyline_models_AnylineImage_;
        }

        static void n_OnPictureTransformed_Lat_nineyards_anyline_models_AnylineImage_(IntPtr jnienv, IntPtr native__this, IntPtr native_transformedImage)
        {
            global::IO.Anyline.Plugin.Document.IDocumentScanResultListener __this = global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.Document.IDocumentScanResultListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::AT.Nineyards.Anyline.Models.AnylineImage transformedImage = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.Models.AnylineImage>(native_transformedImage, JniHandleOwnership.DoNotTransfer);
            __this.OnPictureTransformed(transformedImage);
        }
#pragma warning restore 0169

        IntPtr id_onPictureTransformed_Lat_nineyards_anyline_models_AnylineImage_;
        public unsafe void OnPictureTransformed(global::AT.Nineyards.Anyline.Models.AnylineImage transformedImage)
        {
            if (id_onPictureTransformed_Lat_nineyards_anyline_models_AnylineImage_ == IntPtr.Zero)
                id_onPictureTransformed_Lat_nineyards_anyline_models_AnylineImage_ = JNIEnv.GetMethodID(class_ref, "onPictureTransformed", "(Lat/nineyards/anyline/models/AnylineImage;)V");
            JValue* __args = stackalloc JValue[1];
            __args[0] = new JValue((transformedImage == null) ? IntPtr.Zero : ((global::Java.Lang.Object)transformedImage).Handle);
            JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_onPictureTransformed_Lat_nineyards_anyline_models_AnylineImage_, __args);
        }

        static Delegate cb_onPreviewProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_;
#pragma warning disable 0169
        static Delegate GetOnPreviewProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_Handler()
        {
            if (cb_onPreviewProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_ == null)
                cb_onPreviewProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_OnPreviewProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_);
            return cb_onPreviewProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_;
        }

        static void n_OnPreviewProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_(IntPtr jnienv, IntPtr native__this, IntPtr native_error)
        {
            global::IO.Anyline.Plugin.Document.IDocumentScanResultListener __this = global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.Document.IDocumentScanResultListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::IO.Anyline.Plugin.Document.DocumentScanViewPlugin.DocumentError error = global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.Document.DocumentScanViewPlugin.DocumentError>(native_error, JniHandleOwnership.DoNotTransfer);
            __this.OnPreviewProcessingFailure(error);
        }
#pragma warning restore 0169

        IntPtr id_onPreviewProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_;
        public unsafe void OnPreviewProcessingFailure(global::IO.Anyline.Plugin.Document.DocumentScanViewPlugin.DocumentError error)
        {
            if (id_onPreviewProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_ == IntPtr.Zero)
                id_onPreviewProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_ = JNIEnv.GetMethodID(class_ref, "onPreviewProcessingFailure", "(Lio/anyline/plugin/document/DocumentScanViewPlugin$DocumentError;)V");
            JValue* __args = stackalloc JValue[1];
            __args[0] = new JValue((error == null) ? IntPtr.Zero : ((global::Java.Lang.Object)error).Handle);
            JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_onPreviewProcessingFailure_Lio_anyline_plugin_document_DocumentScanViewPlugin_DocumentError_, __args);
        }

        static Delegate cb_onPreviewProcessingSuccess_Lat_nineyards_anyline_models_AnylineImage_;
#pragma warning disable 0169
        static Delegate GetOnPreviewProcessingSuccess_Lat_nineyards_anyline_models_AnylineImage_Handler()
        {
            if (cb_onPreviewProcessingSuccess_Lat_nineyards_anyline_models_AnylineImage_ == null)
                cb_onPreviewProcessingSuccess_Lat_nineyards_anyline_models_AnylineImage_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_OnPreviewProcessingSuccess_Lat_nineyards_anyline_models_AnylineImage_);
            return cb_onPreviewProcessingSuccess_Lat_nineyards_anyline_models_AnylineImage_;
        }

        static void n_OnPreviewProcessingSuccess_Lat_nineyards_anyline_models_AnylineImage_(IntPtr jnienv, IntPtr native__this, IntPtr native_anylineImage)
        {
            global::IO.Anyline.Plugin.Document.IDocumentScanResultListener __this = global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.Document.IDocumentScanResultListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::AT.Nineyards.Anyline.Models.AnylineImage anylineImage = global::Java.Lang.Object.GetObject<global::AT.Nineyards.Anyline.Models.AnylineImage>(native_anylineImage, JniHandleOwnership.DoNotTransfer);
            __this.OnPreviewProcessingSuccess(anylineImage);
        }
#pragma warning restore 0169

        IntPtr id_onPreviewProcessingSuccess_Lat_nineyards_anyline_models_AnylineImage_;
        public unsafe void OnPreviewProcessingSuccess(global::AT.Nineyards.Anyline.Models.AnylineImage anylineImage)
        {
            if (id_onPreviewProcessingSuccess_Lat_nineyards_anyline_models_AnylineImage_ == IntPtr.Zero)
                id_onPreviewProcessingSuccess_Lat_nineyards_anyline_models_AnylineImage_ = JNIEnv.GetMethodID(class_ref, "onPreviewProcessingSuccess", "(Lat/nineyards/anyline/models/AnylineImage;)V");
            JValue* __args = stackalloc JValue[1];
            __args[0] = new JValue((anylineImage == null) ? IntPtr.Zero : ((global::Java.Lang.Object)anylineImage).Handle);
            JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_onPreviewProcessingSuccess_Lat_nineyards_anyline_models_AnylineImage_, __args);
        }

        static Delegate cb_onTakePictureError_Ljava_lang_Throwable_;
#pragma warning disable 0169
        static Delegate GetOnTakePictureError_Ljava_lang_Throwable_Handler()
        {
            if (cb_onTakePictureError_Ljava_lang_Throwable_ == null)
                cb_onTakePictureError_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_OnTakePictureError_Ljava_lang_Throwable_);
            return cb_onTakePictureError_Ljava_lang_Throwable_;
        }

        static void n_OnTakePictureError_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_error)
        {
            global::IO.Anyline.Plugin.Document.IDocumentScanResultListener __this = global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.Document.IDocumentScanResultListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::Java.Lang.Throwable error = global::Java.Lang.Object.GetObject<global::Java.Lang.Throwable>(native_error, JniHandleOwnership.DoNotTransfer);
            __this.OnTakePictureError(error);
        }
#pragma warning restore 0169

        IntPtr id_onTakePictureError_Ljava_lang_Throwable_;
        public unsafe void OnTakePictureError(global::Java.Lang.Throwable error)
        {
            if (id_onTakePictureError_Ljava_lang_Throwable_ == IntPtr.Zero)
                id_onTakePictureError_Ljava_lang_Throwable_ = JNIEnv.GetMethodID(class_ref, "onTakePictureError", "(Ljava/lang/Throwable;)V");
            JValue* __args = stackalloc JValue[1];
            __args[0] = new JValue((error == null) ? IntPtr.Zero : ((global::Java.Lang.Throwable)error).Handle);
            JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_onTakePictureError_Ljava_lang_Throwable_, __args);
        }

        static Delegate cb_onTakePictureSuccess;
#pragma warning disable 0169
        static Delegate GetOnTakePictureSuccessHandler()
        {
            if (cb_onTakePictureSuccess == null)
                cb_onTakePictureSuccess = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr>)n_OnTakePictureSuccess);
            return cb_onTakePictureSuccess;
        }

        static void n_OnTakePictureSuccess(IntPtr jnienv, IntPtr native__this)
        {
            global::IO.Anyline.Plugin.Document.IDocumentScanResultListener __this = global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.Document.IDocumentScanResultListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            __this.OnTakePictureSuccess();
        }
#pragma warning restore 0169

        IntPtr id_onTakePictureSuccess;
        public unsafe void OnTakePictureSuccess()
        {
            if (id_onTakePictureSuccess == IntPtr.Zero)
                id_onTakePictureSuccess = JNIEnv.GetMethodID(class_ref, "onTakePictureSuccess", "()V");
            JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_onTakePictureSuccess);
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
            global::IO.Anyline.Plugin.Document.IDocumentScanResultListener __this = global::Java.Lang.Object.GetObject<global::IO.Anyline.Plugin.Document.IDocumentScanResultListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            ScanResult result = global::Java.Lang.Object.GetObject<ScanResult>(native_result, JniHandleOwnership.DoNotTransfer);
            __this.OnResult(result);
        }
#pragma warning restore 0169

        IntPtr id_onResult_Lio_anyline_plugin_ScanResult_;
        public unsafe void OnResult(ScanResult result)
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
}
