📘 Project Title

⟦Your Project Name Here⟧


# Overview

This project presents a Mixed Reality application developed using Unity and the Microsoft Mixed Reality Toolkit (MRTK), targeting HoloLens 2 and the Universal Windows Platform (UWP).

The system integrates real-time visual processing with an interactive mixed reality interface, enabling users to visualize classification results, overlays, and confidence indicators directly within the physical environment.
The application is designed to be reproducible, extensible, and deployment-ready.


# Key Features

1- Mixed Reality user interface using MRTK

2- UWP-compatible build pipeline (IL2CPP, ARM64)

3- Optional visual overlay for model input/output

4- Toggle-based UI controls for enabling/disabling overlays

5- Confidence visualization (e.g., confidence label)

6- OpenXR-based XR configuration (no legacy XR)

7- Fully documented build and deployment steps

# System Architecture

## Main components: ##

1- Unity Engine – Core application logic and rendering

2- MRTK Foundation – Input, spatial interaction, UI

3- OpenXR Plugin – XR runtime abstraction

4- UWP Build Target – HoloLens deployment

5- Visual Studio 2022 – App packaging and deployment

## High-level flow:

1- Unity scene initializes MRTK and OpenXR

2- User interacts with UI elements (toggles, buttons)

3- Visual overlays and classification results are rendered

4- Application is built via IL2CPP for ARM64

5- Visual Studio generates UWP AppX/MSIX packages

🧰 Requirements
Software

Unity Hub

Unity Editor ⟦VERSION⟧
(Recommended: Unity 2021 LTS or 2022 LTS)

Microsoft Mixed Reality Toolkit (MRTK)

Visual Studio 2022

Universal Windows Platform development

Desktop development with C++

Windows 10/11 SDK (10.0.19041 or newer)

ARM64 build tools

Hardware (Optional)

Microsoft HoloLens 2
(Project can be built and validated without a physical device)

⚙️ Unity Project Settings (Required)

Before building, ensure the following settings are configured:

Build Settings

Platform: Universal Windows Platform (UWP)

Architecture: ARM64

Build Type: D3D

Target Device: HoloLens

Scripting Backend: IL2CPP

Player Settings

API Compatibility Level: .NET Standard 2.1

Incremental GC: Enabled

XR Plug-in Management:

OpenXR enabled

Initialize XR on Startup: Enabled

🧪 Build & Deployment Instructions
Step 1 – Unity Build

Open the project in Unity

Switch platform to UWP

Open Build Settings

Click Build

Choose an empty output folder

Step 2 – Visual Studio

Open the generated .sln file

Set configuration:

Release

ARM64

Local Machine

Build the solution

(Optional) Create App Packages for Store or sideloading

📦 Repository Structure
📁 ProjectRoot
 ├── 📁 Assets
 ├── 📁 Packages
 ├── 📁 ProjectSettings
 ├── 📁 Documentation
 ├── README.md
 ├── .gitignore
 └── LICENSE


⚠️ The following folders are intentionally excluded from Git:

Library/

Temp/

Obj/

Build/

Logs/

🚀 Deployment Readiness Checklist

✅ Clean Unity build with no blocking errors

✅ IL2CPP + ARM64 configured

✅ OpenXR enabled (no legacy XR)

✅ Visual Studio solution builds successfully

✅ App package generation supported

✅ Documentation provided for reviewers

🧾 Known Limitations

Some features may require a physical HoloLens for full validation

Visual Studio UWP tooling depends on installed workloads

Performance profiling is limited without hardware

📄 License

This project is licensed under the ⟦MIT License⟧.
See the LICENSE file for details.
