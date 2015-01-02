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
    public enum PromiseState
    {
        Pending,
        Succeeded,
        Failed
    }

    public delegate void PromiseCallback();
    public delegate void PromiseCallback<T>(T arg);
    public delegate void PromiseCallback<T, U>(T arg0, U arg1);
    public delegate void PromiseCallback<T, U, V>(T arg0, U arg1, V arg2);
    public delegate void PromiseCallback<T, U, V, W>(T arg0, U arg1, V arg2, W arg3);

    public interface Promise
    {
        Promise OnSuccess(PromiseCallback callback);
        Promise OnSuccess(params PromiseCallback[] callbacks);
        Promise OnFailure(PromiseCallback callback);
        Promise OnFailure(params PromiseCallback[] callbacks);
        Promise OnComplete(PromiseCallback callback);
        Promise OnComplete(params PromiseCallback[] callbacks);
        PromiseState GetState();
    }

    public interface Promise<T>
    {
        Promise<T> OnSuccess(PromiseCallback<T> callback);
        Promise<T> OnSuccess(params PromiseCallback<T>[] callbacks);
        Promise<T> OnFailure(PromiseCallback<T> callback);
        Promise<T> OnFailure(params PromiseCallback<T>[] callbacks);
        Promise<T> OnComplete(PromiseCallback<T> callback);
        Promise<T> OnComplete(params PromiseCallback<T>[] callbacks);
        PromiseState GetState();
    }

    public interface Promise<T, U>
    {
        Promise<T, U> OnSuccess(PromiseCallback<T, U> callback);
        Promise<T, U> OnSuccess(params PromiseCallback<T, U>[] callbacks);
        Promise<T, U> OnFailure(PromiseCallback<T, U> callback);
        Promise<T, U> OnFailure(params PromiseCallback<T, U>[] callbacks);
        Promise<T, U> OnComplete(PromiseCallback<T, U> callback);
        Promise<T, U> OnComplete(params PromiseCallback<T, U>[] callbacks);
        PromiseState GetState();
    }

    public interface Promise<T, U, V>
    {
        Promise<T, U, V> OnSuccess(PromiseCallback<T, U, V> callback);
        Promise<T, U, V> OnSuccess(params PromiseCallback<T, U, V>[] callbacks);
        Promise<T, U, V> OnFailure(PromiseCallback<T, U, V> callback);
        Promise<T, U, V> OnFailure(params PromiseCallback<T, U, V>[] callbacks);
        Promise<T, U, V> OnComplete(PromiseCallback<T, U, V> callback);
        Promise<T, U, V> OnComplete(params PromiseCallback<T, U, V>[] callbacks);
        PromiseState GetState();
    }

    public interface Promise<T, U, V, W>
    {
        Promise<T, U, V, W> OnSuccess(PromiseCallback<T, U, V, W> callback);
        Promise<T, U, V, W> OnSuccess(params PromiseCallback<T, U, V, W>[] callbacks);
        Promise<T, U, V, W> OnFailure(PromiseCallback<T, U, V, W> callback);
        Promise<T, U, V, W> OnFailure(params PromiseCallback<T, U, V, W>[] callbacks);
        Promise<T, U, V, W> OnComplete(PromiseCallback<T, U, V, W> callback);
        Promise<T, U, V, W> OnComplete(params PromiseCallback<T, U, V, W>[] callbacks);
        PromiseState GetState();
    }
}