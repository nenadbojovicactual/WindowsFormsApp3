using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp3;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var r = new Form1();
          string result=   r.GetString("r");
            List<object> inputValues = new List<object> { "r" };
            List<object> expectedValues = new List<object> { "rjup", "testjup", "no value" };
            List<object> insertedValues = new List<object> { null, "test" };
            alltests("GetString", inputValues, expectedValues, insertedValues);
     

        }
        [TestMethod]
        public void TestMethod2()
        {
            var r = new Form1();
            string result = r.GetString("r");

            List<object> inputValues = new List<object> { "r", "2" };
            List<object>  expectedValues = new List<object> { "r2" };
            List<object> insertedValues = new List<object> { null };
            alltests("GetString2", inputValues, expectedValues, insertedValues);

        }
        public TestContext TestContext { get; set; }
        public void alltests (string methodName, List<object> inputValues, List<object> expectedValues, List<object> insertedValues)
        {
     
            List<object> getInputValues= inputValues;
               Type thisType = typeof(Form1);
                  MethodInfo theMethod = thisType.GetMethod(methodName);

            /*   foreach (var prop  in theMethod.GetParameters())
               {
             System.Diagnostics.Debug.WriteLine(prop);
         } */
            int position = 0;
            foreach (object listValues in inputValues)
            {
               
            foreach (object checkValue in insertedValues)
           {
            // List<object> alteredList = inputValues;
                    object[] alteredList = new object[inputValues.Count];
                    inputValues.CopyTo(alteredList);
                    alteredList[position] = checkValue;
             var result = theMethod.Invoke(new Form1(), alteredList);
 
                    string getValue = checkValue == null ? "null " : checkValue.ToString();
                    // ovo je zbog custom poruka
                    if (expectedValues.Contains(result))
                    {
                        // ovde upisite naravno nesto drugo ako proveravate datasetove, ovo je za jednostavan primer....
                        Console.WriteLine("Testing of the method " + methodName + " for the Value  " + getValue + " at position " + position.ToString() + " has passed ");
                    }
                    else
                    {
                        Console.WriteLine("Testing of the method " + methodName + " for the Value " + getValue + " at position " + position.ToString() + " has failed ");
                    }
                    try
                    {
                    
                    Assert.IsTrue(expectedValues.Contains(result));}
                        catch (AssertFailedException af)
                    {
                        Console.WriteLine(af.Message+ "\nTesting of the method " + methodName + " for the Value " + getValue + " at position " + position.ToString() + " has failed ");

                    }
                 
                  
          
                }
                position++;
            }
          
        }
    }
}
