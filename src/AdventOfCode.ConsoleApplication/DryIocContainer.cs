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
        }
    }
}
