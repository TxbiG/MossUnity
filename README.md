[![Build](https://github.com/TxbiG/MossUnity/actions/workflows/build.yml/badge.svg)](https://github.com/TxbiG/MossUnity/actions/workflows/build.yml)
# MossUnity

Unity integration for the [Moss Framework](https://github.com/TxbiG/Moss).

> **Status: Foundation / not yet connected to MossSharp physics APIs.**
>
> This package establishes the Unity package structure, runtime/editor assemblies,
> lifecycle components, documentation and CI scaffolding. It intentionally does not
> invent MossSharp types or method names. The adapter must be connected to the real
> MossSharp public API after that API has been audited.

## Direction

Use MossSharp as the managed C# binding to Moss. MossUnity should provide the Unity-facing
experience: components, inspectors, world lifecycle, transform synchronisation and editor
tools. It should not reimplement Moss's physics engine.

## Repository layout

```text
MossUnity/
├── package.json
├── Runtime/
│   ├── MossUnity.Runtime.asmdef
│   ├── MossPhysicsWorld.cs
│   ├── MossPhysicsBody.cs
│   └── Internal/
├── Editor/
│   ├── MossUnity.Editor.asmdef
│   └── MossPhysicsBodyEditor.cs
├── Tests/
├── Documentation~/
└── .github/workflows/
```

## Install

Once published as a Unity package, add the Git URL through Package Manager:

```text
https://github.com/TxbiG/MossUnity.git
```

For local development, add this repository as a package using its local folder path.

## MossSharp dependency

MossSharp is the intended bridge to the native framework. Before adding a hard package
dependency, confirm:
- the correct repository/package identity and version;
- the supported target frameworks and Unity scripting runtimes;
- how the native Moss library is located and deployed on each target;
- the exact public physics API and native object ownership rules.

The initial package deliberately keeps this boundary behind an internal adapter contract.
This allows the Unity-facing API to be developed without fabricating MossSharp calls.

## Initial scope

- Explicit Moss physics world component.
- Explicit Moss body component.
- Clear fixed-step simulation configuration.
- No implicit takeover of Unity Physics/PhysX.
- No claim of global physics replacement.
- Future support for colliders, joints, queries, events and debug visualisation.

## Roadmap

1. Audit MossSharp public source and its native dependency model.
2. Implement the internal adapter using verified MossSharp APIs.
3. Add world creation, fixed-step stepping and teardown.
4. Add body and collider creation and transform synchronisation.
5. Add queries, triggers and collision event dispatch.
6. Add editor tooling, samples, platform packaging and tests.
