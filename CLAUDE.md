# .NET MAUI HelloWorld Project Guidelines

## Build and Run Commands
- Build solution: `dotnet build HelloWorld.sln`
- Run on Android: `dotnet build -t:Run -f net8.0-android`
- Run on iOS: `dotnet build -t:Run -f net8.0-ios`
- Clean solution: `dotnet clean`

## Code Style Guidelines
- Use nullable reference types (already enabled)
- Follow C# naming conventions:
  - PascalCase for class names, public properties, and methods
  - camelCase for private fields and parameters
  - Prefix private fields with underscore (_fieldName)
- Group XAML attributes logically (layout properties together, etc.)
- Use descriptive SemanticProperties for accessibility
- Organize code with clear region separators when appropriate
- Handle exceptions with try/catch blocks rather than allowing crashes
- Use string interpolation (`$"text {variable}"`) over concatenation
- Maintain proper spacing and indentation (4 spaces)
- Keep methods small and focused on a single responsibility