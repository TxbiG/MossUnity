# Contributing to MossUnity

Thank you for your interest in contributing to **MossUnity**.

MossUnity aims to provide a comprehensive integration between Unity and the [Moss Framework](https://github.com/TxbiG/Moss).

The project is not limited to physics. Its long-term objective is to expose the useful capabilities of Moss through Unity-friendly C# APIs, components, assets, editor tools and native integrations.

Contributions are welcome across all supported areas of the framework.

## 1. Project vision

MossUnity should allow Unity developers to access Moss functionality without unnecessarily recreating the underlying systems in C# or Unity-specific native code.

The intended integration areas include:

| Subsystem | Intended integration |
|---|---|
| Physics | 2D/3D simulation, bodies, shapes and collision queries |
| Audio | Audio playback, spatial sound and audio resource controls |
| Input | Input devices, actions, mappings, events and haptics |
| Navigation | 2D/3D navigation, pathfinding and queries |
| Rendering | Graphics resources, backend integration and rendering utilities |
| Networking | Multiplayer, communication and synchronisation |
| XR | OpenXR and supported XR functionality |
| Platform services | Platform-specific and cross-platform functionality |
| Diagnostics | Logging, timing, profiling and performance tools |
| Other framework systems | Additional functionality exposed by the Moss public API |

This is a long-term integration scope, not a claim that every feature is currently implemented or available through the public API.

## 2. Core principles

All contributions should follow these principles:

- **Moss owns the underlying implementation.** Do not recreate existing Moss systems unnecessarily.
- **Unity provides the developer experience.** Expose functionality through appropriate C# interfaces, MonoBehaviours, ScriptableObjects and editor tools.
- **Use verified public APIs.** Never invent Moss functions, types or structures.
- **Keep native and managed responsibilities clear.**
- **Make subsystems modular.** Developers should be able to use supported Moss systems independently where practical.
- **Avoid unnecessary interop overhead.** Reduce redundant managed/native calls, allocations and copies.
- **Respect Unity lifecycle and memory management.**
- **Document limitations honestly.** Do not advertise unimplemented functionality as a replacement for Unity systems.

## 3. Before contributing

Before starting work:

1. Read the README and architecture documentation.
2. Review the current subsystem support matrix.
3. Check existing issues and pull requests.
4. Confirm supported Unity and .NET versions.
5. Review the C# Runtime and Editor assemblies.
6. Inspect the corresponding Moss public headers.
7. Determine whether the work belongs in Moss or the Unity adapter.

Moss Framework:

https://github.com/TxbiG/Moss

Every native Moss API call must be verified against its actual declaration and implementation where appropriate.

## 4. Development requirements

Depending on the subsystem, contributors may need:

- Git.
- A supported Unity Editor.
- A compatible .NET SDK.
- Visual Studio or JetBrains Rider.
- A C++17-compatible compiler.
- CMake 3.20 or newer.
- Moss source code and native libraries.
- Platform-specific SDKs and build tools.

The README should document the exact supported versions and platform requirements.

## 5. Subsystem contribution guidelines

### 5.1 Physics

Expose the available Moss 2D and 3D physics capabilities through Unity-friendly interfaces.

Possible integration areas include:

- Physics worlds and simulation configuration.
- Static, dynamic and kinematic bodies where supported.
- Shapes and collision filtering.
- Raycasts and collision queries.
- Contacts and collision events.
- Joints and constraints.
- Fixed timestep and substeps.
- Debug drawing and diagnostics.

Keep the native simulation in Moss. Clearly define whether a body is controlled by Unity or Moss to prevent duplicate simulation.

### 5.2 Audio

Expose Moss audio functionality in ways that fit Unity's workflow.

Possible integration areas include:

- Audio system and device lifecycle.
- Audio playback and stopping.
- Audio resource management.
- Volume, pitch and playback controls where supported.
- Spatial audio and 3D positioning.
- Audio processing and effects where supported.
- Device configuration.
- Audio asset import or conversion workflows.

The integration should clearly distinguish Moss audio resources from Unity `AudioClip`, `AudioSource` and mixer resources.

Do not assume these resource types are interchangeable. Implement explicit conversions or bridging mechanisms where appropriate.

### 5.3 Input and haptics

Expose available Moss input functionality through suitable Unity interfaces.

Possible areas include:

- Keyboard and mouse input.
- Game controllers.
- Input device discovery.
- Input state and event processing.
- Input actions and mapping workflows.
- Device connection and disconnection.
- Haptic and vibration feedback.
- Input timing and update configuration.

Where Unity's Input System is used, avoid duplicate or conflicting input processing. Provide a clearly documented integration mode.

### 5.4 Navigation

Expose supported Moss 2D and 3D navigation functionality.

Possible areas include:

- Navigation worlds and settings.
- Navigation data and surfaces.
- Pathfinding.
- Navigation queries.
- Agent movement and updates.
- Obstacles and avoidance where supported.
- Debug visualisation.

Define how Moss navigation data relates to Unity NavMesh and AI Navigation resources. Do not assume that Unity assets can be passed directly into Moss.

### 5.5 Rendering

Make the relevant Moss rendering functionality accessible to Unity projects.

Possible areas include:

- Graphics backend configuration.
- Resource interoperability.
- Textures, buffers and other graphics resources.
- Shader and material workflows.
- Rendering utilities.
- Debug rendering.
- Render lifecycle and synchronisation.

Contributions must respect Unity's rendering pipeline and graphics resource ownership.

Consider Built-in Render Pipeline, Universal Render Pipeline and High Definition Render Pipeline differences where relevant. Do not claim compatibility with a pipeline without testing it.

### 5.6 Networking and multiplayer

Possible areas include:

- Network initialisation and teardown.
- Connections and disconnections.
- Data transport and messages.
- Multiplayer communication.
- Synchronisation facilities.
- Network configuration.
- Diagnostics.

Clearly document the relationship between Moss networking and Unity Netcode or other networking packages. Avoid assuming they have matching semantics or can share ownership of the same connection.

### 5.7 XR and platform services

Where supported, contributions may expose:

- OpenXR integration.
- VR/AR/MR device functionality.
- XR tracking and input.
- Platform backends.
- Desktop and mobile capabilities.
- Device configuration and diagnostics.

Respect Unity XR Plug-in Management and relevant platform-specific requirements.

### 5.8 Other Moss functionality

Contributions are also welcome for:

- Resource management.
- Timing and time utilities.
- Logging.
- Profiling.
- Platform abstractions.
- Additional framework systems exposed by Moss.

Keep new integrations consistent with the managed/native architecture.

## 6. Managed and native architecture

The intended architecture is:

```text
Unity Project
     |
     v
MossUnity C# Runtime
     |
     +---- Physics
     +---- Audio
     +---- Input
     +---- Navigation
     +---- Rendering
     +---- Networking
     +---- XR
     +---- Platform and Utility APIs
     |
     v
Managed / Native Interop
     |
     v
Moss Native Adapter
     |
     v
Moss Framework
```

The C# layer should provide the Unity-facing experience. The native adapter should connect it to the real Moss implementation.

Each subsystem should document:

- Native library requirements.
- Managed API surface.
- Resource ownership.
- Creation and disposal.
- Error handling.
- Threading requirements.
- Platform compatibility.
- Supported features and limitations.

Avoid unnecessary managed/native transitions, particularly in per-frame and real-time operations.

## 7. Code standards

### C#

- Follow existing formatting and naming conventions.
- Use clear public interfaces.
- Document public APIs.
- Prefer explicit disposal patterns for native resources.
- Avoid unnecessary allocations, boxing and reflection.
- Keep Editor-only code out of Runtime assemblies.
- Handle native errors explicitly.
- Avoid introducing unnecessary dependencies.

### C++

- Use C++17.
- Follow Moss and adapter conventions.
- Prefer RAII.
- Keep exported APIs small and stable.
- Validate pointers and handles.
- Document lifetime, ownership and threading.
- Avoid exposing internal Moss details through C#.

### Unity

- Respect MonoBehaviour lifecycles.
- Keep serialization predictable.
- Separate Runtime and Editor assemblies.
- Respect scene loading and unloading.
- Handle domain reload and application shutdown correctly.
- Avoid accessing Unity objects from unsupported threads.
- Follow UPM package conventions.

## 8. Branches and commit messages

Suggested branch names:

- `feature/audio-integration`
- `feature/input-integration`
- `feature/navigation-integration`
- `feature/rendering-integration`
- `feature/physics-world`
- `feature/networking`
- `feature/openxr`
- `fix/native-library-loading`
- `docs/subsystem-guide`
- `test/interop-lifecycle`

Suggested commits:

- `feat: expose Moss audio playback`
- `feat: add input device integration`
- `feat: add navigation query wrappers`
- `fix: release native resources on disposal`
- `docs: document supported rendering pipelines`
- `test: add managed native lifecycle coverage`

Keep commits focused.

## 9. Bug reports and feature requests

Bug reports should include the affected subsystem, reproduction steps, expected and actual behaviour, Unity version, .NET version, Moss version or commit, operating system, CPU architecture and relevant logs.

Feature requests should describe:

- The problem being solved.
- The Moss subsystem involved.
- The intended Unity-facing API.
- Whether Moss requires changes.
- Interop and lifecycle requirements.
- Platform compatibility.
- Performance implications.
- Testing requirements.

Discuss large changes before implementation begins.

## 10. Pull requests

Every pull request should:

1. Explain the change and affected subsystem.
2. Reference relevant issues.
3. Identify the Moss APIs being used.
4. Explain managed/native boundary changes.
5. Document resource ownership and threading.
6. Include build and test instructions.
7. Update the support matrix.
8. Update relevant examples and documentation.

Before submitting, confirm that all Moss APIs are real, native resources are released correctly and the package structure remains valid.

Clearly report any tests that could not be completed due to unavailable platforms, SDKs or dependencies.

## 11. Testing

Testing should be specific to the subsystem.

Examples include:

- Physics simulation and collision tests.
- Audio playback and resource tests.
- Input event and device tests.
- Haptic feedback tests.
- Navigation and pathfinding tests.
- Rendering pipeline and resource tests.
- Network communication tests.
- XR device and initialisation tests.
- Domain reload and scene lifecycle tests.
- Cross-platform native loading tests.
- Performance benchmarks.

A successful C# compilation does not prove that native integration works correctly.

## 12. Subsystem support matrix

Maintain a support matrix using these statuses:

- **Not started:** no integration available.
- **In development:** implementation is incomplete.
- **Experimental:** usable only in limited scenarios.
- **Partial:** selected capabilities are implemented and tested.
- **Supported:** documented capabilities pass the required tests.
- **Unsupported:** intentionally unavailable in this integration.

Update the matrix whenever support changes.

Do not claim complete parity with Unity systems unless that parity has been demonstrated.

## 13. Package and platform compatibility

Document supported Unity versions, operating systems, CPU architectures, scripting runtimes, native binaries and graphics pipelines.

Only claim platform or pipeline compatibility after building and testing the integration on that target.

## 14. Security and licensing

Never submit credentials, access tokens, private keys or confidential project data.

Report vulnerabilities privately to the repository maintainer.

By contributing, you agree that your contribution may be distributed under the repository's licence. Only submit material you have permission to redistribute.

## 15. Final note

MossUnity aims to give Unity developers access to the wider Moss Framework through efficient native integration and a clean managed API.

Physics is one part of the project. Audio, input, navigation, rendering, networking, XR and other supported framework systems are equally valid areas for contribution.

Thank you for contributing to MossUnity.
