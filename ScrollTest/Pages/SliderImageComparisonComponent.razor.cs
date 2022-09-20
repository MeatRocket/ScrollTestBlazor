using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using ScrollTest;
using ScrollTest.Shared;
using System.Reflection;

namespace ScrollTest.Pages
{
    public partial class SliderImageComparisonComponent
    {
        [Parameter]
        public string BeforeURl { get; set; } 

        [Parameter]
        public string AfterUrl { get; set; }

        public ElementReference component { get; set; }


        public async Task OnSliderChangeAsync()
        {
            await JSRuntime.InvokeVoidAsync("slide", component);
        }

    }

}