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
    public class Deferred : Promise
    {
        private event PromiseCallback success;
        private event PromiseCallback failure;
        private PromiseState state = PromiseState.Pending;

        public Deferred OnSuccess(PromiseCallback callback)
        {
            success += callback;
            return this;
        }

        public Deferred OnSuccess(params PromiseCallback[] callbacks)
        {
            foreach (var c in callbacks)
                success += c;
            return this;
        }

        Promise Promise.OnSuccess(PromiseCallback callback)
        {
            return OnSuccess(callback);
        }

        Promise Promise.OnSuccess(params PromiseCallback[] callbacks)
        {
            return OnSuccess(callbacks);
        }

        public Deferred OnFailure(PromiseCallback callback)
        {
            failure += callback;
            return this;
        }

        public Deferred OnFailure(params PromiseCallback[] callbacks)
        {
            foreach (var c in callbacks)
                failure += c;
            return this;
        }

        Promise Promise.OnFailure(PromiseCallback callback)
        {
            return OnFailure(callback);
        }

        Promise Promise.OnFailure(params PromiseCallback[] callbacks)
        {
            return OnFailure(callbacks);
        }

        public Deferred OnComplete(PromiseCallback callback)
        {
            success += callback;
            failure += callback;
            return this;
        }

        public Deferred OnComplete(params PromiseCallback[] callbacks)
        {
            foreach (var c in callbacks)
            {
                success += c;
                failure += c;
            }
            return this;
        }

        Promise Promise.OnComplete(PromiseCallback callback)
        {
            return OnComplete(callback);
        }

        Promise Promise.OnComplete(params PromiseCallback[] callbacks)
        {
            return OnComplete(callbacks);
        }

        public PromiseState GetState()
        {
            return state;
        }

        public void Succeed()
        {
            if (PromiseState.Pending != state)
                return;
            state = PromiseState.Succeeded;
            if (null != success)
                success();
        }

        public void Fail()
        {
            if (PromiseState.Pending != state)
                return;
            state = PromiseState.Failed;
            if (null != failure)
                failure();
        }

        public Promise Promise()
        {
            return this;
        }
    }

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

    public class Deferred<T, U> : Promise<T, U>
    {
        private event PromiseCallback<T, U> success;
        private event PromiseCallback<T, U> failure;
        private PromiseState state = PromiseState.Pending;

        public Deferred<T, U> OnSuccess(PromiseCallback<T, U> callback)
        {
            success += callback;
            return this;
        }

        public Deferred<T, U> OnSuccess(params PromiseCallback<T, U>[] callbacks)
        {
            foreach (var c in callbacks)
                success += c;
            return this;
        }

        Promise<T, U> Promise<T, U>.OnSuccess(PromiseCallback<T, U> callback)
        {
            return OnSuccess(callback);
        }

        Promise<T, U> Promise<T, U>.OnSuccess(params PromiseCallback<T, U>[] callbacks)
        {
            return OnSuccess(callbacks);
        }

        public Deferred<T, U> OnFailure(PromiseCallback<T, U> callback)
        {
            failure += callback;
            return this;
        }

        public Deferred<T, U> OnFailure(params PromiseCallback<T, U>[] callbacks)
        {
            foreach (var c in callbacks)
                failure += c;
            return this;
        }

        Promise<T, U> Promise<T, U>.OnFailure(PromiseCallback<T, U> callback)
        {
            return OnFailure(callback);
        }

        Promise<T, U> Promise<T, U>.OnFailure(params PromiseCallback<T, U>[] callbacks)
        {
            return OnFailure(callbacks);
        }

        public Deferred<T, U> OnComplete(PromiseCallback<T, U> callback)
        {
            success += callback;
            failure += callback;
            return this;
        }

        public Deferred<T, U> OnComplete(params PromiseCallback<T, U>[] callbacks)
        {
            foreach (var c in callbacks)
            {
                success += c;
                failure += c;
            }
            return this;
        }

        Promise<T, U> Promise<T, U>.OnComplete(PromiseCallback<T, U> callback)
        {
            return OnComplete(callback);
        }

        Promise<T, U> Promise<T, U>.OnComplete(params PromiseCallback<T, U>[] callbacks)
        {
            return OnComplete(callbacks);
        }

        public PromiseState GetState()
        {
            return state;
        }

        public void Succeed(T arg0, U arg1)
        {
            if (PromiseState.Pending != state)
                return;
            state = PromiseState.Succeeded;
            if (null != success)
                success(arg0, arg1);
        }

        public void Fail(T arg0, U arg1)
        {
            if (PromiseState.Pending != state)
                return;
            state = PromiseState.Failed;
            if (null != failure)
                failure(arg0, arg1);
        }

        public Promise<T, U> Promise()
        {
            return this;
        }
    }

    public class Deferred<T, U, V> : Promise<T, U, V>
    {
        private event PromiseCallback<T, U, V> success;
        private event PromiseCallback<T, U, V> failure;
        private PromiseState state = PromiseState.Pending;

        public Deferred<T, U, V> OnSuccess(PromiseCallback<T, U, V> callback)
        {
            success += callback;
            return this;
        }

        public Deferred<T, U, V> OnSuccess(params PromiseCallback<T, U, V>[] callbacks)
        {
            foreach (var c in callbacks)
                success += c;
            return this;
        }

        Promise<T, U, V> Promise<T, U, V>.OnSuccess(PromiseCallback<T, U, V> callback)
        {
            return OnSuccess(callback);
        }

        Promise<T, U, V> Promise<T, U, V>.OnSuccess(params PromiseCallback<T, U, V>[] callbacks)
        {
            return OnSuccess(callbacks);
        }

        public Deferred<T, U, V> OnFailure(PromiseCallback<T, U, V> callback)
        {
            failure += callback;
            return this;
        }

        public Deferred<T, U, V> OnFailure(params PromiseCallback<T, U, V>[] callbacks)
        {
            foreach (var c in callbacks)
                failure += c;
            return this;
        }

        Promise<T, U, V> Promise<T, U, V>.OnFailure(PromiseCallback<T, U, V> callback)
        {
            return OnFailure(callback);
        }

        Promise<T, U, V> Promise<T, U, V>.OnFailure(params PromiseCallback<T, U, V>[] callbacks)
        {
            return OnFailure(callbacks);
        }

        public Deferred<T, U, V> OnComplete(PromiseCallback<T, U, V> callback)
        {
            success += callback;
            failure += callback;
            return this;
        }

        public Deferred<T, U, V> OnComplete(params PromiseCallback<T, U, V>[] callbacks)
        {
            foreach (var c in callbacks)
            {
                success += c;
                failure += c;
            }
            return this;
        }

        Promise<T, U, V> Promise<T, U, V>.OnComplete(PromiseCallback<T, U, V> callback)
        {
            return OnComplete(callback);
        }

        Promise<T, U, V> Promise<T, U, V>.OnComplete(params PromiseCallback<T, U, V>[] callbacks)
        {
            return OnComplete(callbacks);
        }

        public PromiseState GetState()
        {
            return state;
        }

        public void Succeed(T arg0, U arg1, V arg2)
        {
            if (PromiseState.Pending != state)
                return;
            state = PromiseState.Succeeded;
            if (null != success)
                success(arg0, arg1, arg2);
        }

        public void Fail(T arg0, U arg1, V arg2)
        {
            if (PromiseState.Pending != state)
                return;
            state = PromiseState.Failed;
            if (null != failure)
                failure(arg0, arg1, arg2);
        }

        public Promise<T, U, V> Promise()
        {
            return this;
        }
    }

    public class Deferred<T, U, V, W> : Promise<T, U, V, W>
    {
        private event PromiseCallback<T, U, V, W> success;
        private event PromiseCallback<T, U, V, W> failure;
        private PromiseState state = PromiseState.Pending;

        public Deferred<T, U, V, W> OnSuccess(PromiseCallback<T, U, V, W> callback)
        {
            success += callback;
            return this;
        }

        public Deferred<T, U, V, W> OnSuccess(params PromiseCallback<T, U, V, W>[] callbacks)
        {
            foreach (var c in callbacks)
                success += c;
            return this;
        }

        Promise<T, U, V, W> Promise<T, U, V, W>.OnSuccess(PromiseCallback<T, U, V, W> callback)
        {
            return OnSuccess(callback);
        }

        Promise<T, U, V, W> Promise<T, U, V, W>.OnSuccess(params PromiseCallback<T, U, V, W>[] callbacks)
        {
            return OnSuccess(callbacks);
        }

        public Deferred<T, U, V, W> OnFailure(PromiseCallback<T, U, V, W> callback)
        {
            failure += callback;
            return this;
        }

        public Deferred<T, U, V, W> OnFailure(params PromiseCallback<T, U, V, W>[] callbacks)
        {
            foreach (var c in callbacks)
                failure += c;
            return this;
        }

        Promise<T, U, V, W> Promise<T, U, V, W>.OnFailure(PromiseCallback<T, U, V, W> callback)
        {
            return OnFailure(callback);
        }

        Promise<T, U, V, W> Promise<T, U, V, W>.OnFailure(params PromiseCallback<T, U, V, W>[] callbacks)
        {
            return OnFailure(callbacks);
        }

        public Deferred<T, U, V, W> OnComplete(PromiseCallback<T, U, V, W> callback)
        {
            success += callback;
            failure += callback;
            return this;
        }

        public Deferred<T, U, V, W> OnComplete(params PromiseCallback<T, U, V, W>[] callbacks)
        {
            foreach (var c in callbacks)
            {
                success += c;
                failure += c;
            }
            return this;
        }

        Promise<T, U, V, W> Promise<T, U, V, W>.OnComplete(PromiseCallback<T, U, V, W> callback)
        {
            return OnComplete(callback);
        }

        Promise<T, U, V, W> Promise<T, U, V, W>.OnComplete(params PromiseCallback<T, U, V, W>[] callbacks)
        {
            return OnComplete(callbacks);
        }

        public PromiseState GetState()
        {
            return state;
        }

        public void Succeed(T arg0, U arg1, V arg2, W arg3)
        {
            if (PromiseState.Pending != state)
                return;
            state = PromiseState.Succeeded;
            if (null != success)
                success(arg0, arg1, arg2, arg3);
        }

        public void Fail(T arg0, U arg1, V arg2, W arg3)
        {
            if (PromiseState.Pending != state)
                return;
            state = PromiseState.Failed;
            if (null != failure)
                failure(arg0, arg1, arg2, arg3);
        }

        public Promise<T, U, V, W> Promise()
        {
            return this;
        }
    }
}