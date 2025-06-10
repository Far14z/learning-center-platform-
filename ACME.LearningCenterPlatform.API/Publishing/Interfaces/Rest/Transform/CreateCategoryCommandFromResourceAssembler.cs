using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.Rest.Resources;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.Rest.Transform;

public class CreateCategoryCommandFromResourceAssembler
{
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(resource.Name);
    }
    
}