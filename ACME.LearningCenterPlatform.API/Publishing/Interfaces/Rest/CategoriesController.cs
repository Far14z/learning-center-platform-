using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.Rest.Resources;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Category Endpoints")]
public class CategoriesController(ICategoryCommandService categoryCommandService, ICategoryQueryService categoryQueryService) : ControllerBase
{
    [HttpGet("{categoryId:int}")]
    [SwaggerOperation(
        summary: "Get Category by Id",
        Description = "Returns a category by its unique identifier.",
        OperationId = "GetCategoryById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Category found", typeof(CategoryResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Category not found")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var getCategoryByIdQuery= new GetCategoryByIdQuery(categoryId);
        var category = await categoryQueryService.Handle(getCategoryByIdQuery);

        if (category is null) return NotFound();

        var resource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(resource);
    }

    [HttpGet]
    [SwaggerOperation(
        summary: "Get All Categories",
        Description = "Returns a list of all categories.",
        OperationId = "GetAllCategories")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of categories", typeof(IEnumerable<CategoryResource>))]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await categoryQueryService.Handle(new GetAllCategoriesQuery());
        var categoryResources = categories
            .Select(CategoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(categoryResources);
    }

    [HttpPost]
    [SwaggerOperation(
        summary: "Create Category",
        Description = "Creates a new category and returns the created category resource.",
        OperationId = "CreateCategory")]
    [SwaggerResponse(StatusCodes.Status201Created, "Category created", typeof(CategoryResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryResource resource)
    {
        var createCategoryCommand = CreateCategoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var category = await categoryCommandService.Handle(createCategoryCommand);
        
        if (category is null) return BadRequest("Category could not be created.");
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        
        return CreatedAtAction(nameof(GetCategoryById), new { categoryId = categoryResource.Id }, categoryResource);
    }
}