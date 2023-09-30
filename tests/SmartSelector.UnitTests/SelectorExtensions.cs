using SmartSelector.UnitTests.TestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSelector.UnitTests
{
    public class SelectorExtensions
    {
        [Fact]
        public void SelectFields_CanSelectOnlySpecificFields_IQueryableWithSpecificFields()
        {
            IQueryable<MyTestObject> myTestObjects = new List<MyTestObject>() 
            {
                new MyTestObject
                {
                    FirstProperty = "a1",
                    SecondProperty = "a2",
                    ThirdProperty = "a3",
                },
                new MyTestObject
                {
                    FirstProperty = "b1",
                    SecondProperty = "b2",
                    ThirdProperty = "b3",
                },
                new MyTestObject
                {
                    FirstProperty = "c1",
                    SecondProperty = "c2",
                    ThirdProperty = "c3",
                },
            }.AsQueryable();
            IQueryable<MyTestObject> result = myTestObjects.SelectFields(new List<string>() 
            { 
                nameof(MyTestObject.SecondProperty), 
                nameof(MyTestObject.ThirdProperty) 
            });
            string expectedFinalString = @"FirstProperty: '', SecondProperty: 'a2', ThirdProperty: 'a3'
FirstProperty: '', SecondProperty: 'b2', ThirdProperty: 'b3'
FirstProperty: '', SecondProperty: 'c2', ThirdProperty: 'c3'";
            Assert.Equal(expectedFinalString, string.Join("\r\n", result.ToList().Select(x => new string($"FirstProperty: '{x.FirstProperty}', SecondProperty: '{x.SecondProperty}', ThirdProperty: '{x.ThirdProperty}'"))));
        }
    }
}
