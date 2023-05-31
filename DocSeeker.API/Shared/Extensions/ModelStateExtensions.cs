using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DocSeeker.API.Shared.Extensions;

// The external elements that arrive (Example: SavePrescriptionResource) will be
// validated (required and maxlengh) and for each property that fails, it returns
// a collection of errors. But we want a single collection of errors to be
// returned for each entity. So we are going to extend a class called ModelState.
public static class ModelStateExtensions
{
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        return dictionary
            .SelectMany(m => m.Value.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }
}