using System.ComponentModel;

namespace Enums.Api.Models
{
    public enum Language
    {
        [Description("C#")]
        CSharp = 1,

        [Description("Java")]
        Java = 2,

        [Description("JavaScript")]
        JavaScript = 3,
    }
}
