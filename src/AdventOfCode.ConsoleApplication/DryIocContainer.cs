using AdventOfCode.Shared.Common;
using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2020;
using DryIoc;

namespace AdventOfCode.ConsoleApplication
{
    public class DryIocContainer
    {
        public static IContainer ApplicationContainer { get; private set; }

        public static void Configure()
        {
            ApplicationContainer = new Container();

            ApplicationContainer.Register<IReadListFromFile, ReadListFromFile>();
            ApplicationContainer.Register<IAdventTask, Day1_ReportRepair>(serviceKey: "2020-01");
            ApplicationContainer.Register<IAdventTask, Day2_PasswordPhilosophy>(serviceKey: "2020-02");
            ApplicationContainer.Register<IAdventTask, Day3_TobogganTrajectory>(serviceKey: "2020-03");
            ApplicationContainer.Register<IAdventTask, Day4_PassportProcessing>(serviceKey: "2020-04");
            ApplicationContainer.Register<IAdventTask, Day5_BinaryBoarding>(serviceKey: "2020-05");
            ApplicationContainer.Register<IAdventTask, Day6_CustomCustoms>(serviceKey: "2020-06");
            ApplicationContainer.Register<IAdventTask, Day7_HandyHaversacks>(serviceKey: "2020-07");
            ApplicationContainer.Register<IAdventTask, Day8_HandheldHalting>(serviceKey: "2020-08");
            ApplicationContainer.Register<IAdventTask, Day9_EncodingError>(serviceKey: "2020-09");
        }
    }
}
