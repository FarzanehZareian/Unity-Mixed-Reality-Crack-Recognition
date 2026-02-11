# Integration of Deep Learning-Based Crack Recognition with Mixed Reality for Structural Inspection

![Unity](https://img.shields.io/badge/Unity-2021.3%20LTS-black?logo=unity)
![Platform](https://img.shields.io/badge/Platform-UWP-blue)
![Architecture](https://img.shields.io/badge/Architecture-ARM64-yellow)
![Backend](https://img.shields.io/badge/Backend-IL2CPP-success)
![XR](https://img.shields.io/badge/XR-OpenXR-purple)
![Build Status](https://img.shields.io/badge/UWP%20Build-Passing-brown)
![License](https://img.shields.io/badge/License-MIT-violet)

---

## Overview

This repository presents a Mixed Reality (MR) inspection system developed in Unity using the Microsoft Mixed Reality Toolkit (MRTK) and OpenXR. The application targets Microsoft HoloLens 2 via the Universal Windows Platform (UWP).

The system integrates deep learning–based crack classification and segmentation with real-time holographic visualization. Model outputs are rendered as overlays within the user’s physical environment, enabling intuitive and interactive structural inspection.

The project is structured for reproducibility, modularity, and deployment readiness.

---

## Key Features

- Mixed Reality interface using MRTK
- Real-time ONNX model inference via Unity Barracuda
- Crack classification and segmentation
- Overlay visualization of predictions
- Confidence and uncertainty visualization
- Toggle-based UI controls for overlays
- OpenXR-based XR configuration (no legacy XR pipeline)
- UWP deployment pipeline (IL2CPP + ARM64)
- Fully documented build and configuration steps

---

## System Architecture

The system consists of the following components:

- **Unity Engine** – Core application logic and rendering  
- **Barracuda Inference Engine** – ONNX model execution  
- **MRTK Foundation** – Spatial interaction and UI system  
- **OpenXR Plugin** – XR runtime abstraction  
- **UWP Build Target** – HoloLens deployment platform  
- **Visual Studio 2022** – Application packaging and validation  

The architecture separates input acquisition, inference processing, visualization, and deployment layers to ensure modularity and extensibility.

---

## Software Requirements

- Unity 2021.3 LTS (tested on 2021.3.45f2)
- Microsoft Mixed Reality Toolkit (MRTK)
- OpenXR Plugin
- Visual Studio 2022
  - Desktop development with C++
  - Universal Windows Platform tools
  - Windows 10 SDK (10.0.19041)
  - ARM64 build tools (v143)

---

## Optional Hardware

- Microsoft HoloLens 2

Note: Physical hardware is required only for live deployment testing. Build validation can be performed without the device.

---

## Unity Configuration

Before building, ensure the following settings:

### Build Settings

- Platform: Universal Windows Platform (UWP)
- Architecture: ARM64
- Build Type: D3D11
- Target Device: HoloLens
- Scripting Backend: IL2CPP

### Player Settings

- API Compatibility Level: .NET Standard 2.1
- Incremental GC: Enabled
- XR Plug-in Management:
  - OpenXR enabled
  - Legacy XR disabled

---

## Build Instructions

### Step 1 – Unity Build

1. Open the project in Unity.
2. Switch platform to **Universal Windows Platform**.
3. Confirm:
   - Architecture = ARM64
   - Backend = IL2CPP
4. Click **Build**.
5. Select an empty output directory.

### Step 2 – Visual Studio

1. Open the generated `.sln` file.
2. Set:
   - Configuration: **Release**
   - Architecture: **ARM64**
   - Deployment target: **Local Machine** (or Remote Device if available)
3. Build the solution.

Optional: Create App Packages for sideloading or Store submission.

---

## Deployment Readiness

The project has been validated using:

- Unity 2021.3 LTS
- IL2CPP backend
- ARM64 UWP configuration
- OpenXR runtime
- Visual Studio 2022 (v143 toolchain)

A successful UWP build confirms deployment readiness.

---

## Validation Status

| Component | Status |
|-----------|--------|
| Unity Compilation | ✅ Pass |
| UWP ARM64 Build | ✅ Pass |
| Visual Studio Solution | ✅ Pass |
| App Packaging | ✅ Supported |
| Device Deployment | ⚠ Requires Hardware |

---

## Repository Structure

Assets/ Unity project assets
Packages/ Unity package manifest
ProjectSettings/ Unity configuration
Docs/ Architecture diagrams and documentation
Screenshots/ Visual references

---

## Limitations

Deployment validation on physical hardware requires access to a HoloLens 2 device. Performance profiling has been limited to editor testing and build validation environments.

---

## License

This project is released under the MIT License.  
See the LICENSE file for full details.

---

## Author

Farzaneh Zareian  
Amirkabir University of Technology  
Department of Civil and Environmental Engineering  

Email: far.zareian@gmail.com

