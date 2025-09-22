# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.3] - 2025-09-21

### Changed

- Package now targets .NET Standard 2.0 for maximum framework compatibility.

## [1.1.2] - 2024-12-06

### Fixed

- Fix `ToPascalCase` by reverting changes in 1.1.1 that caused non-abbreviation substrings to unintentionally be rendered in all caps when less than 3 characters long.

## [1.1.1] - 2024-12-01

### Fixed

- Fix `ToPascalCase` so that substrings under 3 characters in length are set to all caps instead of title case.

## [1.1.0] - 2024-11-30

### Added

- Add `ToPascalCase` string extension method.

### Fixed

- Fix type in URL for initial release version link in this changelog.

## [1.0.0] - 2024-11-29

Initial release.

### Added

- Add initial `string` extension methods.
  - Add `TrimStart` and `TrimEnd` method overloads that accept `string` parameters.
  - Add `Base64Encode` method for quickly encoding text.

[1.1.3]: https://github.com/twcrews/primitive-extensions/compare/1.1.2...1.1.3
[1.1.2]: https://github.com/twcrews/primitive-extensions/compare/1.1.1...1.1.2
[1.1.1]: https://github.com/twcrews/primitive-extensions/compare/1.1.0...1.1.1
[1.1.0]: https://github.com/twcrews/primitive-extensions/compare/1.0.0...1.1.0
[1.0.0]: https://github.com/twcrews/primitive-extensions/releases/tag/1.0.0
