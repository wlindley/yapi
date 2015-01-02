using System;
using NUnit.Framework;
using yapi;

namespace YapiTest
{
    public class DeferredTest
    {
        private Deferred<string> testObj;

        [SetUp]
        public void Setup()
        {
            testObj = new Deferred<string>();
        }

        [Test]
        public void PromiseReturnsSameObject()
        {
            Assert.AreSame(testObj, testObj.Promise());
        }

        [Test]
        public void SucceedCallsAllOnSuccessMethodsWithParam()
        {
            var expectedArg = "expected argument";
            var wasCalled = false;

            testObj.OnSuccess((string arg) =>
            {
                if (arg == expectedArg)
                    wasCalled = true;
            });

            testObj.Succeed(expectedArg);

            Assert.True(wasCalled);
        }

        [Test]
        public void SucceedCallsAllOnCompleteMethodsWithParam()
        {
            var expectedArg = "expected argument";
            var wasCalled = false;

            testObj.OnComplete((string arg) =>
            {
                if (arg == expectedArg)
                    wasCalled = true;
            });

            testObj.Succeed(expectedArg);

            Assert.True(wasCalled);
        }

        [Test]
        public void FailCallsAllOnFailureMethodsWithParam()
        {
            var expectedArg = "expected argument";
            var wasCalled = false;

            testObj.OnFailure((string arg) =>
            {
                if (arg == expectedArg)
                    wasCalled = true;
            });

            testObj.Fail(expectedArg);

            Assert.True(wasCalled);
        }

        [Test]
        public void FailCallsAllOnCompleteMethodsWithParam()
        {
            var expectedArg = "expected argument";
            var wasCalled = false;

            testObj.OnComplete((string arg) =>
            {
                if (arg == expectedArg)
                    wasCalled = true;
            });

            testObj.Fail(expectedArg);

            Assert.True(wasCalled);
        }
    }
}
