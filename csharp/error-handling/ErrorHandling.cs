﻿using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException() => throw new Exception("Danger, Will Robinson, Danger");

    public static int? HandleErrorByReturningNullableType(string input)=> int.TryParse(input, out int i) ? i : new int?();

    public static bool HandleErrorWithOutParam(string input, out int result) => int.TryParse(input, out result);

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        using(disposableObject)
        {
            throw new Exception("Danger, Will Robinson, Danger");
        }
    }
}
