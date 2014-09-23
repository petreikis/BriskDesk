using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace BriskDesk.Web
{
    public class TestModule : NancyModule
    {
        public TestModule()
        {
            Get["/"] = _ =>
            {
                return "This is a test module";
            };
        }
    }
}