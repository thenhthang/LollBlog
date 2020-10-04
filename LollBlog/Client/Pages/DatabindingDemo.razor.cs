using System;
using LollBlog.Shared;
using Microsoft.AspNetCore.Components;

namespace LollBlog.Client.Pages
{
    public class DatabindingDemoBase: ComponentBase
    {
        public string Name { get; set; } = "Tom";
        public string Gender { get; set; } = "Male";
        public string Color { get; set; } = "background-color:white";
        public string Description { get; set; } = string.Empty;
    }
}
