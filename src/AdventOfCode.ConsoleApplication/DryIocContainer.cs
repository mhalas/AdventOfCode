using AdventOfCode.Shared.Common;
using AdventOfCode.Shared.Contracts;
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
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day01_ReportRepair>(serviceKey: "2020-01");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day02_PasswordPhilosophy>(serviceKey: "2020-02");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day03_TobogganTrajectory>(serviceKey: "2020-03");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day04_PassportProcessing>(serviceKey: "2020-04");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day05_BinaryBoarding>(serviceKey: "2020-05");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day06_CustomCustoms>(serviceKey: "2020-06");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day07_HandyHaversacks>(serviceKey: "2020-07");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day08_HandheldHalting>(serviceKey: "2020-08");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day09_EncodingError>(serviceKey: "2020-09");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day10_AdapterArray>(serviceKey: "2020-10");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day11_SeatingSystem>(serviceKey: "2020-11");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day12_RainRisk>(serviceKey: "2020-12");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day13_ShuttleSearch>(serviceKey: "2020-13");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day14_DockingData>(serviceKey: "2020-14");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day15_RambunctiousRecitation>(serviceKey: "2020-15");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2020.Day16_TicketTranslation>(serviceKey: "2020-16");

            ApplicationContainer.Register<IAdventTask, Tasks.Year2021.Day1_SonarSweep>(serviceKey: "2021-01");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2021.Day02_Dive>(serviceKey: "2021-02");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2021.Day03_BinaryDiagnostic>(serviceKey: "2021-03");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2021.Day04_GiantSquid>(serviceKey: "2021-04");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2021.Day05_HydrothermalVenture>(serviceKey: "2021-05");

            ApplicationContainer.Register<IAdventTask, Tasks.Year2022.Day01_CalorieCounting>(serviceKey: "2022-01");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2022.Day02_RockPaperScissors>(serviceKey: "2022-02");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2022.Day03_RucksackReorganization>(serviceKey: "2022-03");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2022.Day04_CampCleanup>(serviceKey: "2022-04");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2022.Day05_SupplyStacks> (serviceKey: "2022-05");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2022.Day06_TuningTrouble>(serviceKey: "2022-06");

            ApplicationContainer.Register<IAdventTask, Tasks.Year2023.Day01_Trebuchet>(serviceKey: "2023-01");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2023.Day02_CubeConundrum>(serviceKey: "2023-02");
            ApplicationContainer.Register<IAdventTask, Tasks.Year2023.Day03_GearRatios>(serviceKey: "2023-03");
        }
    }
}
