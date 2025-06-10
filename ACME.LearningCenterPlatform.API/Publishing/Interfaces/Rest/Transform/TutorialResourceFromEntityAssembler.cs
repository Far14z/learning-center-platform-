using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.Rest.Resources;
using Microsoft.OpenApi.Extensions;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.Rest.Transform;

public class TutorialResourceFromEntityAssembler
{
    public static TutorialResource ToResourceFromEntity(Tutorial entity)
    {
        return new TutorialResource(
            entity.Id,
            entity.Title,
            entity.Summary,
            CategoryResourceFromEntityAssembler.ToResourceFromEntity(entity.Category),
            entity.Status.GetDisplayName());
    }
}