using Enums.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Enums.Api.Controllers
{
    [ApiController]
    [Route("/api/enums")]
    public class EnumController : ControllerBase
    {
        private readonly Dictionary<string, Type> Enums = new()
        {
            { nameof(Country), typeof(Country) },
            { nameof(Language), typeof(Language) },
        };

        private IMemoryCache Cache { get; }

        public EnumController(IMemoryCache cache)
        {
            Cache = cache;
        }

        [HttpGet]
        public ActionResult<EnumViewModel> Get()
        {
            return Ok(Cache.GetOrCreate("_Enums", entry =>
            {
                var result = new List<EnumViewModel>();

                foreach (var @enum in Enums)
                {
                    var values = @enum.Value.GetEnumValues();

                    foreach (var value in values)
                    {
                        var name = Enum.GetName(@enum.Value, value);

                        var descriptionAttr = @enum.Value.GetField(name).GetCustomAttributes(typeof(DescriptionAttribute), false);

                        var description = "";

                        if (descriptionAttr != null && descriptionAttr.Length > 0)
                        {
                            var attr = descriptionAttr.FirstOrDefault() as DescriptionAttribute;
                            description = attr.Description;
                        }

                        result.Add(new EnumViewModel
                        {
                            Name = @enum.Key,
                            Description = description,
                            Key = name,
                            Value = (int)value,
                        });
                    }
                }
                return result;
            }));
        }
    }
}
