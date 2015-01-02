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

            testObj.Promise().OnSuccess((string arg) =>
            {
                if (arg == expectedArg)
                    wasCalled = true;
            });

            testObj.Succeed(expectedArg);

            Assert.True(wasCalled);
        }

        [Test]
        public void SucceedCallsAllOnSuccessMethodsWithParamWhenMultipleMethodsArePassed()
        {
            var expectedArg = "expected argument";
            var wasCalled1 = false;
            var wasCalled2 = false;

            testObj.Promise().OnSuccess((string arg) =>
            {
                if (arg == expectedArg)
                    wasCalled1 = true;
            }, (string arg) =>
            {
                if (arg == expectedArg)
                    wasCalled2 = true;
            });

            testObj.Succeed(expectedArg);

            Assert.True(wasCalled1);
            Assert.True(wasCalled2);
        }

        [Test]
        public void SucceedCallsAllOnCompleteMethodsWithParam()
        {
            var expectedArg = "expected argument";
            var wasCalled = false;

            testObj.Promise().OnComplete((string arg) =>
            {
                if (arg == expectedArg)
                    wasCalled = true;
            });

            testObj.Succeed(expectedArg);

            Assert.True(wasCalled);
        }

        [Test]
        public void SucceedCallsAllOnCompleteMethodsWithParamWhenMultipleMethodsArePassed()
        {
            var expectedArg = "expected argument";
            var wasCalled1 = false;
            var wasCalled2 = false;

            testObj.Promise().OnComplete((string arg) =>
            {
                if (arg == expectedArg)
                    wasCalled1 = true;
            }, (string arg) =>
            {
                if (arg == expectedArg)
                    wasCalled2 = true;
            });

            testObj.Succeed(expectedArg);

            Assert.True(wasCalled1);
            Assert.True(wasCalled2);
        }

        [Test]
        public void FailCallsAllOnFailureMethodsWithParam()
        {
            var expectedArg = "expected argument";
            var wasCalled = false;

            testObj.Promise().OnFailure((string arg) =>
            {
                if (arg == expectedArg)
                    wasCalled = true;
            });

            testObj.Fail(expectedArg);

            Assert.True(wasCalled);
        }

        [Test]
        public void FailCallsAllOnFailureMethodsWithParamWhenMultipleMethodsArePassed()
        {
            var expectedArg = "expected argument";
            var wasCalled1 = false;
            var wasCalled2 = false;

            testObj.Promise().OnFailure((string arg) =>
            {
                if (arg == expectedArg)
                    wasCalled1 = true;
            }, (string arg) =>
            {
                if (arg == expectedArg)
                    wasCalled2 = true;
            });

            testObj.Fail(expectedArg);

            Assert.True(wasCalled1);
            Assert.True(wasCalled2);
        }

        [Test]
        public void FailCallsAllOnCompleteMethodsWithParam()
        {
            var expectedArg = "expected argument";
            var wasCalled = false;

            testObj.Promise().OnComplete((string arg) =>
            {
                if (arg == expectedArg)
                    wasCalled = true;
            });

            testObj.Fail(expectedArg);

            Assert.True(wasCalled);
        }
    }
}
