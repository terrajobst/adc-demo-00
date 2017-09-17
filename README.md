# CLI

## Step 1

```
$ dotnet new console -o hello
$ cd hello
$ dotnet run
Hello World!
```

## Step 2

```
$ cd ..
$ dotnet new library -o logic
$ cd logic
```

```C#
namespace logic
{
  public static class HelloWorld
  {
      public static string GetMessage(string name) => $"Hello {name}!";
  }
}
```

```
$ mv Class1.cs HelloWorld.cs
```

```
$ cd ../hello
$ dotnet add reference ../logic/logic.csproj
```

```C#
using System;
using logic;
namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What's your name: ");
            var name = Console.ReadLine();
            var message = HelloWorld.GetMessage(name);
            Console.WriteLine(message);
        }
    }
}
```

```
$ dotnet run
What's your name: Immo
Hello Immo!
```

## Step 3

```
$ cd ..
$ dotnet new xunit -o tests
$ cd tests
$ dotnet add reference ../logic/logic.csproj
```

```C#
using System;
using Xunit;
using logic;

namespace tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var expectedMessage = "Hello Immo!";
            var actualMessage = HelloWorld.GetMessage("Immo");
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}
```

```
$ dotnet test
Total tests: 1. Passed: 1. Failed: 0. Skipped: 0.
Test Run Successful.
```

## Step 4

```
$ cd ..
$ dotnet new web -o web
$ cd web
$ dotnet add reference ../logic/logic.csproj
```

```C#
app.Run(async (context) =>
{
  var name = Environment.UserName;
  var message = logic.HelloWorld.GetMessage(name);
  await context.Response.WriteAsync(message);
});
```

```
$ dotnet run
Hosting environment: Production
Now listening on: http://localhost:5000
Application started. Press Ctrl+C to shut down.
```

## Step 5

```
$ dotnet new sln
```

```
$ ls -rec -fi *.csproj | % { dotnet sln add $_.FullName }
```
