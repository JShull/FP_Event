# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.3.0] - 2026-03-24

### 0.3.0 Changed

- [@JShull](https://github.com/jshull)
  - Updated the package to require Unity `6.4+` with a minimum Unity version of `6000.4`.
  - Refreshed package metadata and repository document links for the current GitHub default branch layout.

### 0.3.0 Fixed

- [@JShull](https://github.com/jshull)
  - Replaced deprecated component instance ID usage in `FPEventComponent.cs` by switching `GetUniqueComponentID()` from `GetInstanceID()` to `GetEntityId()` for Unity 6.4 compatibility.

## [0.2.0] - 2025-7-1

### 0.2.0 Added

- [@JShull](https://github.com/jshull).
  - Support for FuzzPhyte Dependency Installer
  
## [0.1.0] - 2024-7-1

### 0.1.0 Added

- [@JShull](https://github.com/jshull).
  - Moved all test files to a Unity Package Distribution
  - Setup the ChangeLog.md
  - FP_Event Asmdef FuzzPhyte.SystemEvent
    - FPEvent.cs
    - FPEventComponent.cs
    - FP_EventManager.cs
    - This package is a "stack" package that sits onto core packages and helps connect other independent packages under one wider use case scenario. It combines Inventory, Dialogue, SGraph, and possibly others for future and existing FuzzPhyte packages.
  - SamplesURP

### 0.1.0 Changed

- None... yet

### 0.1.0 Fixed

- Setup the contents to align with Unity naming conventions

### 0.1.0 Removed

- None... yet
