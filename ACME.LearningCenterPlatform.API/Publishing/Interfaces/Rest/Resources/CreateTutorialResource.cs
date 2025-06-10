namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.Rest.Resources;

public record CreateTutorialResource(String Title, String Summary, int CategoryId);