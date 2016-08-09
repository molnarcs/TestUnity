using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityTest
{
    public class InjectionMethodTestClass
    {

        public SomeOtherObject dependentObject;

        [InjectionMethod]
        public void Initialize(SomeOtherObject dep)
        {
            // assign the dependent object to a class-level variable
            dependentObject = dep;
        }

    }

    public class InjectionMethodTestClass2
    {

        public IMyInterface depObjectA;
        public MyBaseClass depObjectB;

        [InjectionMethod]
        public void Initialize(IMyInterface interfaceObj, MyBaseClass baseObj)
        {
            depObjectA = interfaceObj;
            depObjectB = baseObj;
        }

    }

    public interface IMyInterface
    {

    }

    public class MyBaseClass
    {

    }

    public class FirstObject : IMyInterface
    {

    }

    public class SecondObject : MyBaseClass
    {

    }

    public class SomeOtherObject
    {
        public string SomeProperty { get; set; }
    }
}
