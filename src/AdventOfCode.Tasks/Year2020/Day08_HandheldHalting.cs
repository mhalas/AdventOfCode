using AdventOfCode.Shared.Contracts;
using AdventOfCode.Shared.Dto;
using AdventOfCode.Shared.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Tasks.Year2020
{
    public class Day08_HandheldHalting : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day08_HandheldHalting(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var fixProgram = false;
            if (parameters.Count() == 2)
                fixProgram = bool.Parse(parameters.ElementAt(1));

            var data = _readListFromFile.ReadFile(parameters.First());
            var instructions = data
                .Select(x => x.Split(' '))
                .Select(x => new { Operation = x[0], Argument = x[1] })
                .Select(x => new HandheldHaltingInstructionDto(x.Operation, x.Argument[0] == '+', int.Parse(x.Argument.Remove(0, 1))))
                .ToList();

            if (fixProgram)
                return Task.FromResult(CountAccumulatorValueAfterFixingProgram(instructions)?.Value.ToString());

            return Task.FromResult(CountAccumulatorValue(instructions).Value.ToString());
        }

        private HandheldHaltingResult CountAccumulatorValueAfterFixingProgram(List<HandheldHaltingInstructionDto> instructions)
        {
            var nopAndJmpCounts = instructions.Count(x => x.Operation == "jmp" || x.Operation == "nop");
            var currentFixingOperation = 0;

            for (int i = 0; i < nopAndJmpCounts; i++)
            {
                var tempInstructions = new List<HandheldHaltingInstructionDto>(instructions)
                    .Select(x=> new HandheldHaltingInstructionDto(x.Operation, x.IsIncrement, x.Value))
                    .ToList();
                currentFixingOperation = FindNextOperationToFix(tempInstructions, currentFixingOperation);

                var instructionToFix = tempInstructions[currentFixingOperation];
                if (instructionToFix.Operation == "jmp")
                    instructionToFix.Operation = "nop";
                else if(instructionToFix.Operation == "nop")
                    instructionToFix.Operation = "jmp";

                var result = CountAccumulatorValue(tempInstructions);
                if (!result.IsCorrupted)
                    return result;
            }

            return null;
        }

        private int FindNextOperationToFix(List<HandheldHaltingInstructionDto> instructions, int currentFixingOperation)
            => instructions.FindIndex(currentFixingOperation + 1, x => x.Operation == "jmp" || x.Operation == "nop");

        private HandheldHaltingResult CountAccumulatorValue(List<HandheldHaltingInstructionDto> instructions)
        {
            var operationsVisited = new List<int>();
            int currentOperation = 0;
            int accumulatorValue = 0;

            bool isCorrupted = true;

            do
            {
                operationsVisited.Add(currentOperation);

                var instruction = instructions[currentOperation];

                switch (instruction.Operation)
                {
                    case "acc":
                        if (instruction.IsIncrement)
                            accumulatorValue += instruction.Value;
                        else
                            accumulatorValue -= instruction.Value;
                        currentOperation++;
                        break;
                    case "jmp":
                        if (instruction.IsIncrement)
                            currentOperation += instruction.Value == 0? 1: instruction.Value;
                        else
                            currentOperation -= instruction.Value == 0 ? 1 : instruction.Value;
                        break;
                    case "nop":
                        currentOperation++;
                        break;
                }

                if (instructions.Count < currentOperation + 1)
                {
                    isCorrupted = false;
                    break;
                }
            }
            while (!operationsVisited.Contains(currentOperation));

            return new HandheldHaltingResult(accumulatorValue, isCorrupted);
        }
    }
}
