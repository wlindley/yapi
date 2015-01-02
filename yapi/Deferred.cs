/******************************************************************************
YAPI - Yet Another Promise Implementation
Copyright (c) 2014 Walker Wondra-Lindley

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

namespace yapi
{
    public class Deferred<T> : Promise<T>
    {
        private event PromiseCallback<T> success;
        private event PromiseCallback<T> failure;
        private PromiseState state = PromiseState.Pending;

        public Deferred<T> OnSuccess(PromiseCallback<T> callback)
        {
            success += callback;
            return this;
        }

        public Deferred<T> OnSuccess(params PromiseCallback<T>[] callbacks)
        {
            foreach (var c in callbacks)
                success += c;
            return this;
        }

        Promise<T> Promise<T>.OnSuccess(PromiseCallback<T> callback)
        {
            return OnSuccess(callback);
        }

        Promise<T> Promise<T>.OnSuccess(params PromiseCallback<T>[] callbacks)
        {
            return OnSuccess(callbacks);
        }

        public Deferred<T> OnFailure(PromiseCallback<T> callback)
        {
            failure += callback;
            return this;
        }

        public Deferred<T> OnFailure(params PromiseCallback<T>[] callbacks)
        {
            foreach (var c in callbacks)
                failure += c;
            return this;
        }

        Promise<T> Promise<T>.OnFailure(PromiseCallback<T> callback)
        {
            return OnFailure(callback);
        }

        Promise<T> Promise<T>.OnFailure(params PromiseCallback<T>[] callbacks)
        {
            return OnFailure(callbacks);
        }

        public Deferred<T> OnComplete(PromiseCallback<T> callback)
        {
            success += callback;
            failure += callback;
            return this;
        }

        public Deferred<T> OnComplete(params PromiseCallback<T>[] callbacks)
        {
            foreach (var c in callbacks)
            {
                success += c;
                failure += c;
            }
            return this;
        }

        Promise<T> Promise<T>.OnComplete(PromiseCallback<T> callback)
        {
            return OnComplete(callback);
        }

        Promise<T> Promise<T>.OnComplete(params PromiseCallback<T>[] callbacks)
        {
            return OnComplete(callbacks);
        }

        public PromiseState GetState()
        {
            return state;
        }

        public void Succeed(T arg)
        {
            if (PromiseState.Pending != state)
                return;
            state = PromiseState.Succeeded;
            if (null != success)
                success(arg);
        }

        public void Fail(T arg)
        {
            if (PromiseState.Pending != state)
                return;
            state = PromiseState.Failed;
            if (null != failure)
                failure(arg);
        }

        public Promise<T> Promise()
        {
            return this;
        }
    }
}