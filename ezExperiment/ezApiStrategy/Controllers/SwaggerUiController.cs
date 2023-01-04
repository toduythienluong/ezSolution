﻿using System;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace ezApiStrategy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SwaggerUiController
    {
        public SwaggerUiController()
        {
        }

        [HttpGet]
        [Produces("text/html")]
        public ContentResult GenerateSwaggerUi()
        {
            string responseString = @" 
            <!DOCTYPE html>
<html lang=""en"">
  <head>
    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
    <meta
      name=""description""
      content=""SwaggerUI""
    />
    <title>SwaggerUI</title>
    <link rel=""stylesheet"" href=""https://unpkg.com/swagger-ui-dist@4.5.0/swagger-ui.css"" />
  </head>
  <body>
  <div id=""swagger-ui""></div>
  <script src=""https://unpkg.com/swagger-ui-dist@4.5.0/swagger-ui-bundle.js"" crossorigin></script>
  <script src=""https://unpkg.com/swagger-ui-dist@4.5.0/swagger-ui-standalone-preset.js"" crossorigin></script>
  <script>
    window.onload = () => {
      window.ui = SwaggerUIBundle({
        url: 'https://petstore3.swagger.io/api/v3/openapi.json',
        dom_id: '#swagger-ui',
        presets: [
          SwaggerUIBundle.presets.apis,
          SwaggerUIStandalonePreset
        ],
        layout: ""StandaloneLayout"",
      });
    };
  </script>
  </body>
</html>
            ";

            return new ContentResult
            {
                Content = responseString,
                ContentType = "text/html"
            };
        }
    }
}
