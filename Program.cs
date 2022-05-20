using WinUI.Extension;
using WinUI.Utilities;
using CliFx;

await new CliApplicationBuilder()
            .AddCommandsFromThisAssembly()
            .Build()
            .RunAsync();
// switch (args.Length)
// {
//     case 0:
//         CommandlineHelper.PrintError("Missing arguments");
//         return;
//     case 1:
//         CommandlineHelper.PrintError("Missing object");
//         return;
//     case 2:
//         CommandlineHelper.PrintError("Missing target");
//         return;
//     case > 4:
//         CommandlineHelper.PrintError("Too many arguments");
//         return;
// }

// var Action = args[0].ToTitleCase();
// var Object = args[1].ToTitleCase();
// var Target = args[2];

// ClassUtility.InvokeStaticMethod(Action, Object, Target);
