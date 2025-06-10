using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.Rest.Resources;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.Rest.Transform;

public class AddVideoAssetToTutorialCommandFromResourceAssembler
{
    public AddVideoAssetToTutorialCommand ToCommandFromResource(AddVideoAssetToTutorialResource resource, int tutorialId)
    {
        return new AddVideoAssetToTutorialCommand(resource.VideoUrl, tutorialId);
    }
}