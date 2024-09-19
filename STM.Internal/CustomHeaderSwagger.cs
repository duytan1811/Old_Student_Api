namespace STM.API
{
    using Microsoft.OpenApi.Any;
    using Microsoft.OpenApi.Models;
    using STM.Common.Constants;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public class CustomHeaderSwagger : IOperationFilter
    {
        private IConfiguration Configuration { get; }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", true, true);

            var configAPIKey = builder.Build().GetValue<string>(ConfigurationKeys.APIKey);
            var configAPIKeyValue = builder.Build().GetValue<string>(ConfigurationKeys.APIKeyValue);

            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = configAPIKey,
                In = ParameterLocation.Header,
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString(configAPIKeyValue),
                },
            });
        }
    }
}
