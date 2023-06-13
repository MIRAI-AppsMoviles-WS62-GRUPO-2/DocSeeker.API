namespace DocSeeker.API.Security.Authorization.Attributes;

// All classes that are annotation attributes end with the suffix Attribute.
// This attribute only applies to methods.
[AttributeUsage(AttributeTargets.Method)]
public class AllowAnonymousAttribute: Attribute
{
    
}