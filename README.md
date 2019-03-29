# Calculator

This is a simple web calculator where you can write an expression and get the result.
This is for educational purposes so, you can do whathever you need with this code.

## Prerequisites & Installing
This was made with Visual Studio 2017 using ASP.NET Core MVC, .NET Standard, C# and Windows.

If you want to inspect the code you can use any editor or code editor of your choice.
I recommend one of these:
* [Visual Studio Code](https://code.visualstudio.com/download)
* [Visual Studio](https://visualstudio.microsoft.com/vs/community/)

If you choose Visual Studio Code you may want to install this extension:
* [C# for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)

To run you'll just need:
* [.NET Core SDK](https://dotnet.microsoft.com/download)

Running with a .NET Core CLI:
1. Open a terminal and go to the cloned projects folder.
2. Go to "UI" directory.
3. Run this command:

    ```
      dotnet run
    ```

4. Navigate the url generated with a browser.

Running with Visual Studio:
1. Just click on Play Button.

## Some implementation details
### Front-end:
* I adapted [this css template](https://fribly.com/2015/03/14/pure-css3-blackboardchalkboard-contact-form/) to make the front-end.
* I used a few lines in JavaScript and JQuery for functionality.

### Back-end:
* It has two projects:
  * The UI project. This is the main ASP.NET Core MVC Web App project.
  * The Business project. This project solves the entered expression. It's a .NET Standard Class Library.
* I used dependency injection to inject factory objects.

## Usage
First of all, this is a simple app made in a short period of time. So, its functionality is limited, and it has a lot of things to improve. If you want to crash the app, you'll definitely achieve it.

The functionality is limited to the basic arithmetic operations (+, -, *, /). You can chain several operations at the same time. But you have to write the parentheses if you want to resolve some operation first.

Let's see some examples:
* If you enter ***4 * 5 + 5*** the result will be ***25***.
* If you enter ***4 * (5 + 5)*** the result will be ***40***.

It supports negative numbers and you can enter them as you wish.
Some examples:
* ***-50 + (-2 * -4) - -7 = -35***
* ***5 / (-5) = -1***

White spaces make no difference.

## Authors

* **Agustín Binci** 
