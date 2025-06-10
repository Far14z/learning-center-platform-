namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.Rest.Resources;

public record TutorialResource(int Id, string Title, string Summary, CategoryResource Category, string Status, DateTime CreatedAt, DateTime UpdatedAt);