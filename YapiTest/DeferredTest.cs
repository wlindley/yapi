/******************************************************************************
YAPI - Yet Another Promise Implementation
Copyright (c) 2015 Walker Wondra-Lindley

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
******************************************************************************/

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
        public void PromiseReturnsNonNullObject()
        {
            Assert.NotNull(testObj.Promise());
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

        [Test]
        public void FailCallsAllOnCompleteMethodsWithParamWhenMultipleMethodsArePassed()
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

            testObj.Fail(expectedArg);

            Assert.True(wasCalled1);
            Assert.True(wasCalled2);
        }

        [Test]
        public void GetStateReturnsPendingByDefault()
        {
            Assert.AreEqual(PromiseState.Pending, testObj.Promise().GetState());
        }

        [Test]
        public void GetStateReturnsSucceededAfterSucceedCalled()
        {
            testObj.Succeed("some string");
            Assert.AreEqual(PromiseState.Succeeded, testObj.Promise().GetState());
        }

        [Test]
        public void GetStateReturnsFailedAfterFailCalled()
        {
            testObj.Fail("some string");
            Assert.AreEqual(PromiseState.Failed, testObj.Promise().GetState());
        }
    }
}
