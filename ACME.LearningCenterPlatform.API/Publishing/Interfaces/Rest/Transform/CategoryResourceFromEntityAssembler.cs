using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.Rest.Resources;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.Rest.Transform;

public class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category category)
    {
        return new CategoryResource(category.Id, category.Name);
    }
}