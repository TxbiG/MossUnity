# Architecture

## Layers

1. Unity-facing components and editor tooling (`MossUnity`).
2. Internal adapter contract (to be implemented).
3. MossSharp public C# binding.
4. Moss native framework.

## Rules

- MossUnity must not duplicate the physics solver.
- Do not call guessed MossSharp APIs.
- Do not assume that a C# object owns the native object it wraps.
- Dispose native resources deterministically.
- Keep callbacks and native handles safe across domain reload and scene unload.
- Make coordinate, unit, timestep and threading conversions explicit.
- Do not silently disable Unity Physics globally.

## First integration milestone

Audit MossSharp's current source and document exact types and methods for:
world creation, stepping, body creation, shape creation, transform access,
queries, events and disposal. Then implement the adapter and add tests.
