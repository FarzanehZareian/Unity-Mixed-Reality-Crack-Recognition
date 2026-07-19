# An End-to-End Deep Learning and Mixed Reality Framework for Automated Crack Inspection of Masonry Structures

![Unity](https://img.shields.io/badge/Unity-2021.3%20LTS-black?logo=unity)
![Platform](https://img.shields.io/badge/Platform-UWP-red)
![Architecture](https://img.shields.io/badge/Architecture-ARM64-purple)
![Backend](https://img.shields.io/badge/Backend-IL2CPP-success)
![XR](https://img.shields.io/badge/XR-OpenXR-yellow)
![Build Status](https://img.shields.io/badge/UWP%20Build-Passing-indigo)
![License](https://img.shields.io/badge/License-MIT-brown)
![Release](https://img.shields.io/github/v/release/FarzanehZareian/Unity-Mixed-Reality-Crack-Recognition)

---

## Overview

This repository contains an open-source, end-to-end mixed reality (MR) framework for automated masonry crack inspection, developed in Unity using the Microsoft Mixed Reality Toolkit (MRTK) and OpenXR. Designed for deployment on the Microsoft HoloLens 2, the framework integrates deep learning–based crack classification and semantic segmentation with real-time holographic visualization to support AI-assisted structural inspection.

The framework performs on-device inference using Unity Barracuda and visualizes analytical outputs as spatially anchored holographic overlays aligned with the inspected masonry surface. The repository includes the Unity project, deep learning notebooks, model integration scripts, and representative validation resources to support reproducibility, future research, and practical deployment.

<p align="center">
  <img width="180" alt="image" src="https://github.com/user-attachments/assets/13359c8b-ba9f-42af-a330-d276f80a251d" />
  <img width="180" alt="image" src="https://github.com/user-attachments/assets/b11cf27d-b91c-4ca1-98b0-462a26cec3d8" />
  <img width="180" alt="image" src="https://github.com/user-attachments/assets/25cad0ae-233e-4748-b352-f9b9048f49ef" />
  <img width="180" alt="image" src="https://github.com/user-attachments/assets/f9015a9a-2ec9-456d-a33d-d271743471d6" />
</p>

<p align="center">
<strong>Fig. 1.</strong> Crack segmentation and classification results on representative prerecorded masonry inspection videos.
</p>

---

## Key Features

- End-to-end mixed reality framework for automated masonry crack inspection
- Real-time semantic segmentation and crack-type classification
- On-device ONNX inference using Unity Barracuda
- Spatially anchored holographic visualization of AI predictions
- Prediction confidence visualization
- Interactive MR interface using hand gestures, gaze, and air-tap input
- Microsoft HoloLens 2 deployment via UWP (IL2CPP + ARM64)
- OpenXR- and MRTK-based implementation
- Modular, reproducible, and open-source project architecture

---

## System Architecture

The framework is organized into three modular layers that support real-time mixed reality inspection.

### 1. Input Acquisition Layer

- Captures real-time RGB images from the Microsoft HoloLens 2 camera.
- Preprocesses acquired frames and converts them into tensors for neural network inference.

### 2. Deep Learning Inference Layer

- Executes ONNX crack segmentation and classification models using Unity Barracuda.
- Performs low-latency on-device inference in real time.

### 3. Mixed Reality Visualization and Interaction Layer

- Displays segmentation masks as spatially anchored holographic overlays.
- Visualizes the predicted crack type and associated confidence score.
- Supports intuitive interaction through hand gestures, gaze input, and air-tap gestures using MRTK.
- Enables users to toggle segmentation overlays for direct comparison between conventional visual inspection and AI-assisted analysis.

<p align="center">
  <img width="800" alt="System Architecture" src="https://github.com/user-attachments/assets/37d892f2-d843-4c69-bbdc-596a8c0b175d" />
</p>

<p align="center">
<strong>Fig. 2.</strong> End-to-end architecture of the mixed reality crack inspection framework.
</p>

The implementation is built on the following software stack:

| Component | Purpose |
|-----------|---------|
| **Unity 2021.3 LTS** | Core application framework for rendering, scene management, and workflow orchestration |
| **Unity Barracuda** | On-device ONNX model inference |
| **Microsoft Mixed Reality Toolkit (MRTK)** | Hand tracking, gaze interaction, spatial UI, and user interaction |
| **OpenXR Plugin** | Cross-platform XR runtime |
| **IL2CPP** | Native ARM64 code generation |
| **Universal Windows Platform (UWP)** | Deployment platform for Microsoft HoloLens 2 |

The modular architecture facilitates independent testing, maintenance, and future extension of individual components.

---

## Software Requirements

The following software components are required to build and deploy the application.

### Unity

- Unity **2021.3 LTS** (tested on **2021.3.45f2**)
- Microsoft Mixed Reality Toolkit (MRTK)
- OpenXR Plugin
- Unity Barracuda

### Visual Studio

- Visual Studio 2022
- Desktop Development with C++
- Universal Windows Platform Development
- Windows 10 SDK (10.0.19041)
- ARM64 Build Tools (v143)

### Deployment Target

- Microsoft HoloLens 2
- Universal Windows Platform (UWP)
- ARM64 Architecture

> **Note:** A physical HoloLens 2 is required only for live deployment. The Unity project and UWP build can be validated without the device.

---

## Installation

Clone the repository:

```bash
git clone https://github.com/FarzanehZareian/Unity-Mixed-Reality-Crack-Recognition.git
cd Unity-Mixed-Reality-Crack-Recognition
```

Open the project using **Unity 2021.3 LTS**.

Unity Package Manager will automatically restore all required packages.

---

## Unity Configuration

Configure the project using the following settings.

### Build Settings

- Platform: Universal Windows Platform (UWP)
- Target Device: HoloLens
- Architecture: ARM64
- Build Type: D3D11
- Scripting Backend: IL2CPP

### Player Settings

- API Compatibility Level: .NET Standard 2.1
- Incremental GC: Enabled

### XR Plug-in Management

- OpenXR: Enabled
- Legacy XR: Disabled

---

## Build Instructions

### Step 1 — Unity Build

1. Open the Unity project.
2. Switch the build platform to **Universal Windows Platform (UWP)**.
3. Verify the build settings.
4. Select **Build**.
5. Choose an empty output directory.


### Step 2 — Visual Studio Deployment

1. Open the generated `.sln` file.
2. Select:

- Configuration: **Release**
- Platform: **ARM64**
- Deployment Target: **Remote Device**

3. Build the solution.
4. Deploy to Microsoft HoloLens 2.

Optionally, generate an **App Package** for sideloading or Microsoft Store deployment.

---

## Running the Application

After deployment to Microsoft HoloLens 2:

1. Launch the application.
2. Grant camera permission if prompted.
3. Point the RGB camera toward a masonry surface containing visible cracks.
4. The framework automatically performs crack segmentation and crack-type classification.
5. Segmentation masks are displayed as holographic overlays.
6. Use hand gestures or air-tap interactions to toggle the overlay on or off.
7. Inspect the predicted crack class and confidence score displayed within the MR interface.

---

## Validation Status

| Component | Status |
|-----------|--------|
| Unity Project Compilation | ✅ Passed |
| Unity Barracuda Inference | ✅ Verified |
| UWP ARM64 Build | ✅ Passed |
| Visual Studio Solution Generation | ✅ Passed |
| Application Packaging | ✅ Supported |
| Microsoft HoloLens 2 Deployment | ⚠ Pending in-situ validation |

---

## Repository Structure

| Folder/File | Description |
|--------------|-------------|
| **Assets/** | Unity scenes, scripts, prefabs, shaders, materials, and runtime assets |
| **Classification Dataset/** | Dataset for crack classification |
| **Packages/** | Unity Package Manager configuration |
| **ProjectSettings/** | Unity project configuration |
| **Screenshots/** | Application screenshots and documentation figures |
| **MobileNet Crack Classification.ipynb** | Classification model training notebook |
| **MobileNetV2 Crack Segmentation.ipynb** | Segmentation model training notebook |
| **README.md** | Project documentation |
| **LICENSE** | MIT License |

---

## License

This project is released under the MIT License. See the **LICENSE** file for details.

---

## Author

**Farzaneh Zareian**

Department of Civil and Environmental Engineering  
Amirkabir University of Technology  
Tehran, Iran

📧 far.zareian@gmail.com
