using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentAssertions;
using LSL.NSwag.CommonTypes.Client;
using NUnit.Framework;

namespace LSL.NSwag.CommonTypes.Tests
{
    public class SwaggerExceptionTests
    {
        [Test]
        public void GivenASwaggerExceptionIsCreated_ItShouldHaveTheExpectedProperties()
        {
            new SwaggerException(
                "my message", 
                400, 
                "a response", 
                new ReadOnlyDictionary<string, IEnumerable<string>>(new Dictionary<string, IEnumerable<string>>
                {
                    ["Header"] = new List<string>
                    {
                        "header-value"
                    }
                }),
                new Exception()
            )
            .Should()
            .BeEquivalentTo(
                new {
                    StatusCode = 400,
                    Response = "a response",
                    Headers = new Dictionary<string,  IEnumerable<string>>()
                    {
                        ["Header"] = new[] { "header-value" }
                    },
                    InnerException = new Exception()
                }
            );
        }

        [Test]
        public void GivenASwaggerExceptionIsCreated_ItShouldHaveTheExpectedToStringValue()
        {
            var result = new SwaggerException(
                "my message", 
                400, 
                "a response", 
                new ReadOnlyDictionary<string, IEnumerable<string>>(new Dictionary<string, IEnumerable<string>>
                {
                    ["Header"] = new List<string>
                    {
                        "header-value"
                    }
                }),
                new Exception()
            )
            .ToString();

            result.Should()
            .Be("HTTP Response: \n\na response\n\nLSL.NSwag.CommonTypes.Client.SwaggerException: my message\n\nStatus: 400\nResponse: \na response\r\n ---> System.Exception: Exception of type 'System.Exception' was thrown.\r\n   --- End of inner exception stack trace ---");
        }
    }
}
