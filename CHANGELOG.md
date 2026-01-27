# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.0] - 2025-01-27

### Changed
- Updated to latest Cult of the Lamb/CotL API version (Woolhaven-compatible).
- Renamed BepInEx Configuration option "Allow Siblings to Mate" to "Allow Inbreeding" (`.dll` only. It was already like that on the Source Code).

### Removed
- Officially removed unused BepInEx Configuration option "Allow Children to Mate".

## [1.0.0] - 2023-03-05

## Initial Version
### Added
- Change chance of producing an egg when two followers mate in a Mating Tent to always be 100%, regardless of outside factors like follower relations or follower traits like "Celibate".
- Add BepInEx Configuration option to toggle whether or not siblings will be affected by the mod (Default to `true`)

### Known Issues
- Unused BepInEx Configuration option to "Allow Children to Mate" kept in the release. This was for testing only. I could not get it to work, *and I do not want it to work.* Will be removed on the next release.