## *Integration of Deep Learning-Based Crack Recognition with Mixed Reality for Enhanced Structural Inspection of Masonry Structures*

## 1- Overview

This project presents a Mixed Reality application developed using Unity and the Microsoft Mixed Reality Toolkit (MRTK), targeting HoloLens 2 and the Universal Windows Platform (UWP).

The system integrates real-time visual processing with an interactive mixed reality interface, enabling users to visualize classification results, overlays, and confidence indicators directly within the physical environment.

The application is designed to be reproducible, extensible, and deployment-ready.


## 2- Key Features

1. Mixed Reality user interface using MRTK

2. UWP-compatible build pipeline (IL2CPP, ARM64)

3. Visual overlay for model output

4. Toggle-based UI controls for enabling/disabling overlays

5. Confidence visualization (e.g., confidence label, uncertainty heatmap)

6. OpenXR-based XR configuration (no legacy XR)

7. Fully documented build and deployment steps

## 3- System Architecture

### Main components: 

+ ***Unity Engine*** – Core application logic and rendering

+ ***MRTK Foundation*** – Input, spatial interaction, UI

+ ***OpenXR Plugin*** – XR runtime abstraction

+ ***UWP Build Target*** – HoloLens deployment

+ ***Visual Studio 2022*** – App packaging and deployment

## 4- Requirements

### Software

+ Unity 2021.3.45f2

+ Microsoft Mixed Reality Toolkit (MRTK)

+ Visual Studio 2022

  + Universal Windows Platform development

  + Desktop development with C++

  + Windows 10 SDK (10.0.19041)

  + ARM64 build tools

### Hardware (Optional)

+ Microsoft HoloLens 2

## 5- Unity Project Settings 

Before building, ensure the following settings are configured:

### Build Settings

+ Platform: Universal Windows Platform (UWP)

+ Architecture: ARM64

+ Build Type: D3D

+ Target Device: HoloLens

+ Scripting Backend: IL2CPP

### Player Settings

+ API Compatibility Level: .NET Standard 2.1

+ Incremental GC: Enabled

+ XR Plug-in Management:

 + OpenXR enabled

## 6- Build Instructions

### Step 1 – Unity Build

+ Open the project in Unity

+ Switch platform to UWP

+ Open Build Settings

+ Click Build

+ Choose an empty output folder

### Step 2 – Visual Studio

+ Open the generated solution (.sln file)

+ Set configuration:

+ Release

+ ARM64

+ Remote Machine

+ Build the solution

+ (Optional) Create App Packages for Store or sideloading

## 8- Deployment Readiness Checklist

✅ Clean Unity build with no blocking errors

✅ IL2CPP + ARM64 configured

✅ OpenXR enabled (no legacy XR)

✅ Visual Studio solution builds successfully

✅ App package generation supported

**Note:** The repository validates successful compilation and build.  
Runtime deployment was not performed due to lack of physical device (e.g., HoloLens).

### License

This project is licensed under the MIT License.

(See the LICENSE file for details)

### Author

Farzaneh Zareian 

Amirkabir University of Technology, Department of Civil and Environmental Engineering

far.zareian@gmail.com
