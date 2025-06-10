using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.Rest.Resources;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.Rest.Transform;

public class CreateTutorialCommandFromResourceAssembler
{
    public static CreateTutorialCommand ToCommandFromResource(CreateTutorialResource resource)
    {
        return new CreateTutorialCommand(resource.Title, resource.Summary, resource.CategoryId);
    }
}