using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using KuasCore.Models;
using KuasCore.Services.Impl;
using Core;
using Spring.Context;
using Spring.Context.Support;
using KuasCore.Services;

namespace KuasCoreTests.Core
{
    [TestClass]
    public class ObjectFactoryUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        [TestMethod]
        public void TestObjectFactory_GetApplicationContext()
        {

            // 利用 Spring Object Name 來依賴尋找找出我們要的 Spring Object.
            IApplicationContext applicationContext = ObjectFactory.GetApplicationContext();
            ICourseService courseService = (ICourseService)applicationContext["courseService"];

            Course course = courseService.GetCourseById("1");
            Assert.IsNotNull(course);

            Console.WriteLine("課程編號為 = " + course.Id);
            Console.WriteLine("課程名稱為 = " + course.Name);
            Console.WriteLine("課程描述為 = " + course.Description);

        }

        [TestMethod]
        public void TestObjectFactory_GetObject()
        {

            // 利用 Spring Object Name 來依賴尋找找出我們要的 Spring Object.
            ICourseService courseService = (ICourseService)ObjectFactory.GetObject("courseService");

            Course course = courseService.GetCourseById("1");
            Assert.IsNotNull(course);

            Console.WriteLine("課程編號為 = " + course.Id);
            Console.WriteLine("課程名稱為 = " + course.Name);
            Console.WriteLine("課程描述為 = " + course.Description);
        }

    }
}
