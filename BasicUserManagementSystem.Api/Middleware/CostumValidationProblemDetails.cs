using Microsoft.AspNetCore.Mvc;

namespace BasicUserManagementSystem.Middleware;

public class CostumValidationProblemDetails:ProblemDetails
{ 
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}