using System;
using ObjCRuntime;

[assembly: LinkWith ("Anyline.a",    
    LinkTarget = LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64,
    Frameworks = "ImageIO AssetsLibrary AVFoundation CoreMedia CoreVideo AudioToolbox QuartzCore Accelerate Security CoreMotion",
    LinkerFlags = "-lz -lstdc++.6.0.9 -lc++ -liconv -all_load -ObjC -v",
    ForceLoad = true,
    SmartLink = true,
    IsCxx = false)]

