namespace SsiGroup.ProjectUsNormalizer.Models;

/// <summary>
///   A street component.
/// </summary>
/// <param name="Text">A text of street component.</param>
/// <param name="ComponentType">A component type.</param>
public record StreetComponent(string Text, StreetComponentType ComponentType);
